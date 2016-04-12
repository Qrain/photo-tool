Imports System.Text

Public Class frm31_プロダクトキー情報照会

    Private SQL As New StringBuilder

    Private Sub frm23_サブスクリプション_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ComboBoxの準備   
        SQL.Length = 0
        SQL.AppendLine("SELECT")
        SQL.AppendLine("    社員ID,")
        SQL.AppendLine("    社員名")
        SQL.AppendLine("FROM")
        SQL.AppendLine("    M02_社員")
        SQL.AppendLine("WHERE")
        SQL.AppendLine("    権利者区分 = '1'")
        SQL.AppendLine("    AND 削除区分 = 0")
        cbx権利者.Items.Add("<未指定>")
        cbx権利者.SelectedIndex = 0
        cbx権利者.Items.AddRange(GetDataTable(SQL.ToString).exGeneratePairArray("社員ID", "社員名"))
        '
        SQL.Length = 0
        SQL.AppendLine("SELECT")
        SQL.AppendLine("    メーカーID,")
        SQL.AppendLine("    メーカー名称")
        SQL.AppendLine("FROM")
        SQL.AppendLine("    M11_メーカー")
        SQL.AppendLine("WHERE")
        SQL.AppendLine("    削除区分 = 0")
        cbxメーカーID.Items.Add("<未指定>")
        cbxメーカーID.SelectedIndex = 0
        cbxメーカーID.Items.AddRange(GetDataTable(SQL.ToString).exGeneratePairArray("メーカーID", "メーカー名称"))
        '
        SQL.Length = 0
        SQL.AppendLine("SELECT")
        SQL.AppendLine("    社員ID,")
        SQL.AppendLine("    社員名")
        SQL.AppendLine("FROM")
        SQL.AppendLine("    M02_社員")
        SQL.AppendLine("WHERE")
        SQL.AppendLine("    削除区分 = 0")
        cbx利用者.Items.Add("<未指定>")
        cbx利用者.SelectedIndex = 0
        cbx利用者.Items.AddRange(GetDataTable(SQL.ToString).exGeneratePairArray("社員ID", "社員名"))
        '
        SetupDataGridViewProperties(dgv一覧)
        SetupDataGridViewCellMerge(dgv一覧, dgvcメーカー, dgvcソフトウェア, dgvc権利者, dgvcサブスクリプションID)
        '
        グリッド表示()
    End Sub


    Private Sub btn終了_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub グリッド表示()
        SQL.Length = 0
        SQL.AppendLine("SELECT")
        SQL.AppendLine("    M03.権利者ID,")
        SQL.AppendLine("    M02.社員名 AS 権利者,")
        SQL.AppendLine("    M03.メーカーID,")
        SQL.AppendLine("    M11.メーカー名称,")
        SQL.AppendLine("    M13.ソフトウェアID,")
        SQL.AppendLine("    M12.ソフトウェア名称,")
        SQL.AppendLine("    M13.プロダクトキー,")
        SQL.AppendLine("    M13.利用者ID,")
        SQL.AppendLine("    M02B.社員名 AS 利用者,")
        SQL.AppendLine("    M03.サブスクリプション連番,")
        SQL.AppendLine("    M03.サブスクリプションID,")
        SQL.AppendLine("    M03.有効期間開始日,")
        SQL.AppendLine("    M03.有効期間終了日,")
        SQL.AppendLine("    M03.購入日")
        SQL.AppendLine("FROM")
        SQL.AppendLine("    M13_プロダクトキー M13")
        SQL.AppendLine("    INNER JOIN")
        SQL.AppendLine("    M03_サブスクリプション M03 ON")
        SQL.AppendLine("    M13.サブスクリプション連番 = M03.サブスクリプション連番")
        SQL.AppendLine("    INNER JOIN")
        SQL.AppendLine("    M02_社員 M02 ON")
        SQL.AppendLine("    M03.権利者ID = m02.社員ID")
        SQL.AppendLine("    INNER JOIN")
        SQL.AppendLine("    M11_メーカー M11 ON")
        SQL.AppendLine("    M03.メーカーID = M11.メーカーID")
        SQL.AppendLine("    INNER JOIN")
        SQL.AppendLine("    M12_ソフトウェア M12 ON")
        SQL.AppendLine("    M13.ソフトウェアID = M12.ソフトウェアID")
        SQL.AppendLine("    LEFT JOIN")
        SQL.AppendLine("    M02_社員 M02B ON")
        SQL.AppendLine("    M13.利用者ID = M02B.社員ID")
        SQL.AppendLine("WHERE")
        SQL.AppendLine("        M13.削除区分 = 0")

        If cbx権利者.SelectedIndex > 0 Then
            SQL.AppendLine("    AND M03.権利者ID = '" & DirectCast(cbx権利者.SelectedItem, CbxItem).L & "'")
        End If
        If cbxメーカーID.SelectedIndex > 0 Then
            SQL.AppendLine("    AND M11.メーカーID = '" & DirectCast(cbxメーカーID.SelectedItem, CbxItem).L & "'")
        End If
        If cbx利用者.SelectedIndex > 0 Then
            SQL.AppendLine("    AND M13.利用者ID = '" & DirectCast(cbx利用者.SelectedItem, CbxItem).L & "'")
        End If

        ' 曖昧検索を行う
        If txt検索.Text.Trim <> "" Then
            If rbtソフト名称.Checked Then
                SQL.AppendLine("    AND M12.ソフトウェア名称 LIKE '%" & txt検索.Text.Trim & "%'")
            ElseIf rbtサブスクリプションID.Checked Then
                SQL.AppendLine("    AND M03.サブスクリプションID LIKE '%" & txt検索.Text.Trim & "%'")
            ElseIf rbtプロダクトキー.Checked Then
                SQL.AppendLine("    AND M13.プロダクトキー LIKE '%" & txt検索.Text.Trim & "%'")
            End If
        End If

        SQL.AppendLine("ORDER BY")
        'SQL.AppendLine("        M11.メーカーID,")
        SQL.AppendLine("        M11.メーカー名称,")
        SQL.AppendLine("        M12.ソフトウェア名称,")
        SQL.AppendLine("        M03.権利者ID,")
        SQL.AppendLine("        M03.サブスクリプションID,")
        SQL.AppendLine("        M13.プロダクトキー")

        ' 不用意なイベント発生を防ぐため一旦外す
        'RemoveHandler dgvプロダクトキー一覧.RowEnter, AddressOf dgvサブスクリプション一覧_RowEnter
        dgv一覧.DataSource = GetDataTable(SQL.ToString)
        'AddHandler dgvプロダクトキー一覧.RowEnter, AddressOf dgvサブスクリプション一覧_RowEnter
    End Sub


    Private Sub btn検索_Click(sender As Object, e As EventArgs) Handles btn検索.Click
        グリッド表示()
    End Sub

    Private Sub dgv一覧_Scroll(sender As Object, e As ScrollEventArgs) Handles dgv一覧.Scroll

    End Sub

    'Private Function IsSameCellValue(ByVal column As Integer, ByVal row As Integer) As Boolean
    '    Dim cell1 As DataGridViewCell = dgv一覧(column, row)
    '    Dim cell2 As DataGridViewCell = dgv一覧(column, row - 1)
    '    '
    '    ' ※列「名称区分」のみ、合併する
    '    If dgv一覧.Columns(column) IsNot dgvc権利者 AndAlso
    '       dgv一覧.Columns(column) IsNot dgvcメーカー AndAlso
    '       dgv一覧.Columns(column) IsNot dgvcソフトウェア Then
    '        Return False
    '    End If

    '    If IsDBNull(cell1.Value) OrElse cell1.Value Is Nothing OrElse
    '       IsDBNull(cell2.Value) OrElse cell2.Value Is Nothing Then
    '        Return False
    '    End If

    '    ' ここでは文字列としてセルの値を比較
    '    If cell1.Value.ToString() = cell2.Value.ToString() Then
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function

    'Private Sub dgv名称一覧_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgv一覧.CellFormatting
    '    ' 1行目については何もしない
    '    If e.RowIndex = 0 Then
    '        Return
    '    End If
    '    ' 
    '    If IsSameCellValue(e.ColumnIndex, e.RowIndex) Then
    '        e.Value = ""
    '        e.FormattingApplied = True ' 以降の書式設定は不要
    '    End If
    'End Sub

    'Private Sub dgv名称一覧_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgv一覧.CellPainting
    '    ' セルの下側の境界線を「境界線なし」に設定
    '    e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None
    '    ' 1行目や列ヘッダ、行ヘッダの場合は何もしない
    '    If e.RowIndex < 1 OrElse e.ColumnIndex < 0 Then
    '        Return
    '    End If
    '    If IsSameCellValue(e.ColumnIndex, e.RowIndex) Then
    '        ' セルの上側の境界線を「境界線なし」に設定
    '        e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None
    '    Else
    '        ' セルの上側の境界線を既定の境界線に設定
    '        e.AdvancedBorderStyle.Top = dgv一覧.AdvancedCellBorderStyle.Top
    '    End If
    'End Sub

End Class