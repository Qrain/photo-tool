Imports System.Text
Imports Microsoft.Win32
Public Class アンインストールツール

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MsgBox(sysIsInstalled("GIMP 2.8.15"))
        'sysUninstall("GIMP 2.8.16")
        Try
            インストール済PG一覧表示()
            lst一覧.SelectedIndex = 0
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn共通_Click(sender As Object, e As EventArgs) Handles btnUninstall.Click, btnModify.Click
        ' 選択中のリストアイテムに関連するRegistryKeyを取得、UninstallString のコマンドを実行する
        Dim cmd As String = ""
        Dim item = DirectCast(lst一覧.SelectedItem, ListItem)
        If sender Is btnUninstall Then
            ' アンインストールボタンが押された場合
            cmd = item.UninstallPath
        ElseIf sender Is btnModify Then
            ' 修正ボタンが押された場合
            cmd = item.ModifyPath
        End If
        'Processオブジェクトを作成
        Dim p As New System.Diagnostics.Process()
        'ComSpec(cmd.exe)のパスを取得して、FileNameプロパティに指定
        p.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec")
        '出力を読み取れるようにする
        p.StartInfo.UseShellExecute = False
        p.StartInfo.RedirectStandardOutput = True
        'p.StartInfo.RedirectStandardInput = False
        'ウィンドウを表示しないようにする
        p.StartInfo.CreateNoWindow = True
        'コマンドラインを指定（"/c"は実行後閉じるために必要）
        p.StartInfo.Arguments = "/c " & cmd
        '起動
        p.Start()
        'プロセス終了まで待機する
        'WaitForExitはReadToEndの後である必要がある
        '(親プロセス、子プロセスでブロック防止のため)
        p.WaitForExit()
        p.Close()
        Dim preIndex = lst一覧.SelectedIndex
        インストール済PG一覧表示()
        lst一覧.SelectedIndex = preIndex
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim preIndex = lst一覧.SelectedIndex
        インストール済PG一覧表示()
        lst一覧.SelectedIndex = preIndex
    End Sub

    Private Function インストール済PG一覧表示() As Boolean
        ' 一覧取得
        Dim instedRegs As Dictionary(Of String, RegistryKey) = GetInstalledPrograms(System.Environment.Is64BitOperatingSystem)
        ' 諸情報をラベルに表示
        lbl情報.Text = instedRegs.Count & " 件のインストール済プログラム"
        'リストボックス用のデータに変形する
        Dim lsls As List(Of ListItem) = instedRegs.Select(Function(e) New ListItem(e.Key, e.Value)).ToList
        ' 表示名順でソート
        lsls.Sort(Function(a, b)
                      Dim dispNameA = a.SubRegistry.GetValue("DisplayName", "").ToString
                      Dim dispNameB = b.SubRegistry.GetValue("DisplayName", "").ToString
                      Return dispNameA.CompareTo(dispNameB)
                  End Function)
        ' リスト内容を更新
        lst一覧.Items.Clear()
        lst一覧.Items.AddRange(lsls.ToArray)
        Return True
    End Function

    Private Sub lst一覧_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lst一覧.SelectedIndexChanged
        ' 選択項目のオブエジェクトを取得してListItemにキャスト
        Dim item = DirectCast(lst一覧.SelectedItem, ListItem)
        Dim reg = item.SubRegistry
        ' ModifyPathがあれば「修正」ボタンを有効、なければ無効に設定
        btnModify.Enabled = item.ModifyPath <> ""
        ' データソースとしてキーペア型のListを指定するので、そのListを作成
        Dim lstValues = reg.GetValueNames.Select(Function(s) New With {.Name = s, .Value = reg.GetValue(s, "").ToString}).ToList
        ' Name（項目名）で昇順ソート
        lstValues.Sort(Function(a, b) a.Name.CompareTo(b.Name))
        ' グリッドを更新
        dgv値一覧.DataSource = lstValues
    End Sub

    Class ListItem
        Public ReadOnly Property KeyName As String
        Public ReadOnly Property SubRegistry As RegistryKey
        Public ReadOnly Property ModifyPath As String
        Public ReadOnly Property UninstallPath As String

        Public Sub New(ByVal keyName As String, ByVal subRegistry As RegistryKey)
            Me.KeyName = keyName
            Me.SubRegistry = subRegistry
            Me.UninstallPath = GetSafeUninstallString(keyName, subRegistry)
            Me.ModifyPath = CStr(subRegistry.GetValue("ModifyPath", ""))
        End Sub

        Public Overrides Function ToString() As String
            Return SubRegistry.GetValue("DisplayName", "").ToString
        End Function
    End Class
End Class
