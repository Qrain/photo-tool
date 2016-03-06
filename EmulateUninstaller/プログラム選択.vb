Imports Microsoft.Win32

Public Class プログラム選択

    Public Property Uninstaller As String = ""

    Sub New(ByVal vdic As IEnumerable(Of KeyValuePair(Of String, RegistryKey)))
        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()
        ' 指定のDictionaryをDataGridViewのDataSource用に加工して設定する
        dgvList.DataSource = vdic.Select(
            Function(x)
                ' 匿名型としてデータを加工する　※プロパティ名はデータバインドのとき指定する
                Return New With {
                .Name = CStr(x.Value.GetValue("DisplayName", "")),
                .Version = CStr(x.Value.GetValue("DisplayVersion", "")),
                .Size = CStr(x.Value.GetValue("EstimatedSize", "-")) & " KB",
                .KeyName = x.Key,
                .UninstallString = GetSafeUninstallString(x.Key, x.Value)
                }
            End Function).ToList
    End Sub

    Private Sub btn選択_Click(sender As Object, e As EventArgs) Handles btn選択.Click
        Uninstaller = dgvList.CurrentRow.Cells("隠_アンインストーラー").Value.ToString
        Me.Close()
    End Sub

    Private Sub btnキャンセル_Click(sender As Object, e As EventArgs) Handles btnキャンセル.Click
        Me.Close()
    End Sub

End Class