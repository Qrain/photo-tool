Imports System.Data.SqlClient
Imports System.Text
Imports SPWinFormControls

Module mdl共通

    ' gs名称("<名称区分>")("<名称コード>")
    Public gs名称 As New Dictionary(Of String, Dictionary(Of String, String))

    Public Sub Reload名称マスタ()

        ' Dictionary初期化
        gs名称.Clear()

        Dim sql As New StringBuilder
        sql.AppendLine("SELECT")
        sql.AppendLine("    名称区分,")
        sql.AppendLine("    名称コード,")
        sql.AppendLine("    名称")
        sql.AppendLine("FROM")
        sql.AppendLine("    M01_名称")
        sql.AppendLine("WHERE")
        sql.AppendLine("    削除区分 = 0")

        Dim str一時名称区分 As String = Nothing
        Dim dtb = GetDataTable(sql.ToString)
        '
        For Each r As DataRow In dtb.Rows
            If r("名称区分") <> str一時名称区分 Then
                ' 新たな名称区分としてDictionaryを追加する
                gs名称.Add(r("名称区分"), New Dictionary(Of String, String) From {{r("名称コード"), r("名称")}})
            Else
                ' 既存の名称区分に名称コードと名称を追加する
                gs名称(str一時名称区分).Add(r("名称コード"), r("名称"))
            End If
            ' 更新
            str一時名称区分 = r("名称区分")
        Next

    End Sub

    ''' <summary>
    ''' コンボボックスから指定のキーに一致するアイテムを取得します。
    ''' </summary>
    ''' <param name="cbx">検索するコンボボックス</param>
    ''' <param name="key">キー</param>
    ''' <returns>キーに対応するアイテム、見つからなければNohing</returns>
    Public Function GetComboBoxItem(ByVal cbx As ComboBox, ByVal key As String) As CbxItem
        ' <未指定>=Stringなので　StringPairだけを抽出
        Dim seqCbxItem =
            From x In cbx.Items
            Where TypeOf x Is CbxItem
            Select DirectCast(x, CbxItem)

        Dim seqResult = From x In seqCbxItem Where x.L = key
        Return If(seqResult.Count > 0, seqResult.First, Nothing)
    End Function

    ''' <summary>
    ''' コンボボックスから指定のキーに一致する値を取得します。
    ''' </summary>
    ''' <param name="cbx"></param>
    ''' <param name="key"></param>
    ''' <returns></returns>
    Public Function GetComboBoxValue(ByVal cbx As ComboBox, ByVal key As String) As String
        Return GetComboBoxItem(cbx, key).R
    End Function


    <System.Runtime.CompilerServices.Extension()>
    Public Function GeneratePairArray(ByVal dtb As DataTable, ByVal col1 As String, ByVal col2 As String) As CbxItem()
        Return dtb.AsEnumerable.Select(Function(r) New CbxItem(sNvl(r(col1)), sNvl(r(col2)))).Distinct.ToArray
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Public Function GeneratePairArray(ByVal seq As IEnumerable(Of DataRow), ByVal col1 As String, ByVal col2 As String) As CbxItem()
        Return seq.Select(Function(r) New CbxItem(sNvl(r(col1)), sNvl(r(col2)))).Distinct.ToArray
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Public Function extSelectedKey(ByVal cbx As ComboBox) As String
        Dim item As Object = cbx.SelectedItem
        If TypeOf item Is CbxItem Then
            Return DirectCast(cbx.SelectedItem, CbxItem).L
        Else
            Return cbx.SelectedItem.ToString
        End If

    End Function

    <System.Runtime.CompilerServices.Extension()>
    Public Function extSelectedValue(ByVal cbx As ComboBox) As String
        Dim item As Object = cbx.SelectedItem
        If TypeOf item Is CbxItem Then
            Return DirectCast(cbx.SelectedItem, CbxItem).R
        Else
            Return cbx.SelectedItem.ToString
        End If
    End Function

    ''' <summary>
    ''' 同じ Name を持つフォームが既に開かれていればTrue
    ''' </summary>
    ''' <param name="parent">親フォーム</param>
    ''' <param name="child">探す子フォーム</param>
    ''' <returns></returns>
    Public Function IsOpen(ByVal parent As Form, ByVal child As Form) As Boolean
        Return parent.OwnedForms.Select(Function(f) f.Name).Contains(child.Name)
    End Function


    Public Function MsgInfo(ByVal cap As String, ByVal msg As String) As DialogResult
        Return MessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Function

    Public Function MsgWarn(ByVal cap As String, ByVal msg As String) As DialogResult
        Return MessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Function

    Public Function MsgErr(ByVal cap As String, ByVal msg As String) As DialogResult
        Return MessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Function

    Public Function MsgOKCancel(ByVal cap As String, ByVal msg As String) As DialogResult
        Return MessageBox.Show(msg, cap, MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
    End Function

    ''' <summary>
    ''' 指定のSQLを実行します。
    ''' </summary>
    ''' <param name="sql">実行するSQL文</param>
    ''' <param name="isTransaction">トランザクション処理とする場合はTrueを指定</param>
    ''' <returns>SQLの実行に成功すればTrue, そうでなければ False</returns>
    ''' <remarks></remarks>
    Public Function ExecNonQuery(ByVal sql As String, Optional ByVal isTransaction As Boolean = False) As Boolean
        Using con As New SqlConnection(My.Settings.DB接続文字列)
            Using com = con.CreateCommand
                Try
                    'DB接続を開いて指定のSQLを実行します
                    con.Open()
                    'トランザクションを開始
                    'SQLite のトランザクション処理: http://kurokawh.blogspot.jp/2013/11/sqlite-sqlite.html
                    If isTransaction Then
                        com.Transaction = con.BeginTransaction
                    End If
                    'SQL文を設定
                    com.CommandText = sql
                    'クエリを実行
                    com.ExecuteNonQuery()
                    'コミットを実行
                    If isTransaction Then
                        com.Transaction.Commit()
                    End If
                    '
                    Return True
                Catch ex As Exception
                    '途中で失敗した場合は変更をロールバック
                    If isTransaction Then
                        Try
                            com.Transaction.Rollback()
                        Catch rbex As Exception
                            MsgErr("RollBack Error @ DB_NonQuery", rbex.Message)
                        End Try
                    End If
                    '
                    MsgErr("Error @ DB_NonQuery", ex.Message)
                    Return False
                End Try
            End Using
        End Using
    End Function

    ''' <summary>
    ''' 指定のSQLクエリを実行して、結果をDataTableで取得します。
    ''' </summary>
    ''' <param name="sql">実行するSQL文</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDataTable(ByVal sql As String) As DataTable
        Dim dtb As New DataTable
        Try
            'DB と DataTableオブジェクトを関連づけるアダプターを作成
            Using adt As New SqlDataAdapter(sql, My.Settings.DB接続文字列)
                adt.SelectCommand.CommandTimeout = 300
                adt.Fill(dtb)
            End Using
        Catch ex As Exception
            MsgErr("Error @ SQLite_GetDataTable", ex.Message)
        End Try
        Return dtb
    End Function

    ''' <summary>
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="sql"></param>
    ''' <returns>型パラメータTに変換された単一値、エラーが発生した場合はNothing</returns>
    ''' <remarks></remarks>
    Public Function GetValue(Of T)(ByVal sql As String) As T
        Using conn As New SqlConnection(My.Settings.DB接続文字列)
            Using comm = conn.CreateCommand
                Try
                    conn.Open()
                    comm.CommandText = sql
                    Return CType(comm.ExecuteScalar, T)
                Catch ex As Exception
                    'MsgErr("Error @ DB_GetValue", ex.Message)
                    Return Nothing
                End Try
            End Using
        End Using
    End Function

    Public Function sNvl(ByVal o As Object) As String
        Return If(IsNothing(o) OrElse IsDBNull(o), "", o)
    End Function

    Public Function dNvl(ByVal o As Object) As Date
        Return If(IsNothing(o) OrElse IsDBNull(o), New Date(), CDate(o))
    End Function

    Public Enum SetupType
        必須 '入力が必須な項目
        参照 '参照のみ可能な項目
        通常 'コントロールの標準な設定
    End Enum

    Sub SetupControls(ByVal venmType As SetupType, ByVal ParamArray vctrls() As Control)
        SetupControls(venmType, vctrls.AsEnumerable)
    End Sub

    Sub SetupControls(ByVal venmType As SetupType, ByVal venuCtrls As IEnumerable(Of Control))
        For Each ctrl In venuCtrls
            Select Case venmType
                Case SetupType.参照
                    ctrl.BackColor = Color.FromArgb(192, 255, 255)
                    ctrl.TabStop = False
                    '
                    If TypeOf ctrl Is TextBox OrElse
                       TypeOf ctrl Is MaskedTextBox OrElse
                       TypeOf ctrl Is SPEdit OrElse
                       TypeOf ctrl Is SPNumber Then

                        '共通の基底クラスに変換
                        With CType(ctrl, TextBoxBase)
                            .ReadOnly = True
                        End With
                    Else
                        'それ以外の未定義なコントロール
                        ctrl.Enabled = False
                    End If
                   ' 
                Case SetupType.必須, SetupType.通常
                    '
                    ctrl.TabStop = True

                    If venmType = SetupType.必須 Then
                        '必須項目ならば背景色を黄色に設定
                        ctrl.BackColor = Color.FromArgb(255, 255, 192)
                    ElseIf venmType = SetupType.通常 Then
                        '通常項目ならば背景色をWindow標準に設定
                        ctrl.BackColor = Drawing.SystemColors.Window
                    End If
                    '
                    If TypeOf ctrl Is TextBox OrElse
                       TypeOf ctrl Is MaskedTextBox OrElse
                       TypeOf ctrl Is SPEdit OrElse
                       TypeOf ctrl Is SPNumber Then
                        '
                        With CType(ctrl, TextBoxBase)
                            .ReadOnly = False
                        End With
                    Else
                        'それ以外の未定義なコントロール
                        ctrl.Enabled = True
                    End If
            End Select
        Next
    End Sub

    ''' <summary>
    ''' データグリッドビューをよく使っている設定にセットアップする
    ''' </summary>
    ''' <param name="dgv"></param>
    Public Sub SetupDataGridViewProperties(ByVal dgv As DataGridView)
        ' 編集不可とする
        dgv.ReadOnly = True
        ' データソースの項目名によって勝手に列が生成されないよう設定
        dgv.AutoGenerateColumns = False
        ' ユーザーが行を追加及び削除できないよう設定
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False

        ' 列ヘッダの高さを調節できないように設定
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        ' 行ヘッダーについてユーザーが調節できないよう設定し、幅を２５に固定
        dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgv.RowHeadersWidth = 25
        ' 複数選択を無効にする
        dgv.MultiSelect = False
        ' ユーザーが各項目をソートできないよう設定
        For Each col As DataGridViewColumn In dgv.Columns
            ' NotSortable: クリックしてもソートしない
            col.SortMode = DataGridViewColumnSortMode.NotSortable
            ' Automatic: ユーザーが列ヘッダクリックでソート
            'col.SortMode = DataGridViewColumnSortMode.Automatic
        Next

        ' ユーザが行および列をリサイズできないよう設定
        dgv.AllowUserToResizeColumns = True
        dgv.AllowUserToResizeRows = False

        ' 単一セルではなく行全体を選択できるように設定
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    ''' <summary>
    ''' dgvで指定したDataGridViewについて、colsで指定した列の同値セル同士を結合します。
    ''' また、スクロール時の表示制御を行います。
    ''' </summary>
    ''' <param name="dgv">設定対象のDataGridView</param>
    ''' <param name="cols">結合したい列オブジェクト</param>
    Public Sub SetupDataGridViewCellMerge(ByVal dgv As DataGridView, ParamArray ByVal cols As DataGridViewColumn())
        ' 結合対象の列が未指定ならリターン
        If cols.Count = 0 Then
            Return
        End If

        ' 一個前のセルを記憶するためのコレクション
        Dim preCells As IEnumerable(Of DataGridViewCell) = Nothing

        ' 同一セル判断関数定義
        Dim IsSameCellValue =
            Function(col As Integer, row As Integer) As Boolean
                ' １行目の場合は上のセルを取得できないのでスキップ
                If row = 0 Then
                    Return False
                End If
                ' ※ colsで指定した列のみを結合処理する
                If Not cols.Contains(dgv.Columns(col)) Then
                    Return False
                End If
                '
                Dim cell1 As DataGridViewCell = dgv(col, row)
                Dim cell2 As DataGridViewCell = dgv(col, row - 1)
                '
                If cell1.Value Is Nothing OrElse IsDBNull(cell1.Value) OrElse
                   cell2.Value Is Nothing OrElse IsDBNull(cell2.Value) Then
                    Return False
                End If
                ' ここではセル値のオブジェクトを文字列として比較
                Return cell1.Value.ToString() = cell2.Value.ToString()
            End Function
        '
        ' Scrollイベントを追加　※ユーザーがグリッドを上下左右にスクロールしたとき呼ばれる
        AddHandler dgv.Scroll,
            Sub(s, e)
                ' 指定された結合対象列の現在1行目に表示されているセルを取得
                Dim cells = From c In cols Select dgv(c.Index, e.NewValue)
                ' 上方向へのスクロール時は CellFormattingイベントで値表示を制御する
                If e.OldValue < e.NewValue Then
                    ' 下スクロールの時のみ制御する
                    For Each cell In cells
                        ' 前景色を元に戻す
                        cell.Style.ForeColor = dgv.DefaultCellStyle.ForeColor
                        cell.Style.SelectionForeColor = dgv.DefaultCellStyle.SelectionForeColor
                    Next
                Else
                    ' 上スクロール
                    If preCells IsNot Nothing Then
                        For Each cell In preCells
                            If IsSameCellValue(cell.ColumnIndex, cell.RowIndex) Then
                                ' 前のセルの前景色を透明にして表示を消す
                                cell.Style.ForeColor = Color.Transparent
                                cell.Style.SelectionForeColor = Color.Transparent
                            End If
                        Next
                    End If
                End If
                ' 値を更新
                preCells = cells
            End Sub
        '
        ' CellFormattingイベントを追加する ※セルに表示する文字列が取得・要求されたとき呼ばれる
        AddHandler dgv.CellFormatting,
            Sub(s, e)
                ' 当該セルの行数が表示行１行目以降である場合
                If dgv.FirstDisplayedScrollingRowIndex < e.RowIndex Then
                    ' 当該セルと１つ上のセルの値が同一と判断されたら
                    If IsSameCellValue(e.ColumnIndex, e.RowIndex) Then
                        e.CellStyle.ForeColor = Color.Transparent
                        e.CellStyle.SelectionForeColor = Color.Transparent
                        e.FormattingApplied = True '以降の書式設定は不要
                    End If
                End If
            End Sub
        '
        ' CellPaintingイベントを追加　※ セルが画面に描画されたとき呼ばれる？
        AddHandler dgv.CellPainting,
            Sub(s, e)
                ' セルの下側の境界線を「境界線なし」に設定
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None
                ' 1行目や列ヘッダ、行ヘッダの場合は何もしない
                If e.RowIndex < 1 OrElse e.ColumnIndex < 0 Then
                    Return
                End If
                If IsSameCellValue(e.ColumnIndex, e.RowIndex) Then
                    ' セルの上側の境界線を「境界線なし」に設定
                    e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None
                Else
                    ' セルの上側の境界線を既定の境界線に設定
                    e.AdvancedBorderStyle.Top = dgv.AdvancedCellBorderStyle.Top
                End If
            End Sub
    End Sub

End Module

' 主にコンボボックスのアイテムに使用する文字列同士のペアオブジェクト
Public Class CbxItem
    Inherits Pair(Of String, String)
    ' 区切り文字を再定義
    Protected Overrides Property Delimiter As String = gs名称("分割文字")("01")

    Public Sub New(ByVal l As String, ByVal r As String)
        MyBase.New(l, r)
    End Sub
End Class

Public Class Pair(Of T, U)
    ' 値同士の区切り文字（デフォルトはカンマ）
    Protected Overridable Property Delimiter As String = ", "
    ''' <summary>
    ''' ペアオブジェクトの左側の値
    ''' </summary>
    ''' <returns></returns>
    Public Property L As T
    ''' <summary>
    ''' ペアオブジェクトの右側の値
    ''' </summary>
    ''' <returns></returns>
    Public Property R As U

    Public Sub New(ByVal l As T, ByVal r As U)
        Me.L = l
        Me.R = r
    End Sub

    Public Overrides Function ToString() As String
        Return If(L Is Nothing, "", L.ToString) & Delimiter & If(R Is Nothing, "", R.ToString)
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        ' 比較対象が自分と同型でなければfalse
        If TypeOf obj IsNot Pair(Of T, U) Then
            Return False
        End If
        '
        Dim o = DirectCast(obj, Pair(Of T, U))
        Dim eqL, eqR As Boolean
        ' L=Nullで対象のLもNullなら同一とみなす、
        If L Is Nothing Then
            eqL = o.L Is Nothing
        Else
            eqL = L.Equals(o.L)
        End If
        '
        If R Is Nothing Then
            eqR = o.R Is Nothing
        Else
            eqR = R.Equals(o.R)
        End If
        '
        Return eqL AndAlso eqR
    End Function

    Public Overrides Function GetHashCode() As Integer
        Dim result As Long = 1
        result = result * 31 + L.GetHashCode
        result = result * 31 + R.GetHashCode
        ' Integer型のOverflow対策
        Return result And &H7FFFFFFFL
    End Function
End Class

