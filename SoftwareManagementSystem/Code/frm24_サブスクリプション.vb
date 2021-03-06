﻿Imports System.Text

Public Class frm24_サブスクリプション

    Private SQL As New StringBuilder
    Private m_intDGV1CurrentRowIndex As Integer = 0


    Private Sub frm23_サブスクリプション_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ComboBoxの準備   
        cbx権利者ID.Text = ""
        SQL.Length = 0
        SQL.AppendLine("SELECT")
        SQL.AppendLine("    社員ID,")
        SQL.AppendLine("    社員名")
        SQL.AppendLine("FROM")
        SQL.AppendLine("    M02_社員")
        SQL.AppendLine("WHERE")
        SQL.AppendLine("        権利者区分 = 1")
        SQL.AppendLine("    AND 削除区分 = 0")
        For Each drw As DataRow In GetDataTable(SQL.ToString).Rows
            cbx権利者ID.Items.Add(New CbxItem(drw("社員ID"), sNvl(drw("社員名"))))
        Next

        cbxメーカーID.Text = ""
        SQL.Length = 0
        SQL.AppendLine("SELECT")
        SQL.AppendLine("    メーカーID,")
        SQL.AppendLine("    メーカー名称")
        SQL.AppendLine("FROM")
        SQL.AppendLine("    M11_メーカー")
        SQL.AppendLine("WHERE")
        SQL.AppendLine("    削除区分 = 0")
        For Each drw As DataRow In GetDataTable(SQL.ToString).Rows
            cbxメーカーID.Items.Add(New CbxItem(drw("メーカーID"), sNvl(drw("メーカー名称"))))
        Next

        ' サブスクリプション不要時の代替文字列を設定
        tbxサブスクリプションオーバーレイ.Text = gs名称("代替文字列")("02")

        SetupDataGridViewProperties(dgvサブスクリプション一覧)
        SetupDataGridViewCellMerge(dgvサブスクリプション一覧, Column1, Column2)
        グリッド表示()
    End Sub

    Private Sub chkサブスクリプション不要_CheckedChanged(sender As Object, e As EventArgs) Handles chkサブスクリプション不要.CheckedChanged
        ' チェックされたら表示する
        tbxサブスクリプションオーバーレイ.Visible = chkサブスクリプション不要.Checked
    End Sub

    Private Sub btn更新_Click(sender As Object, e As EventArgs) Handles btn更新.Click

        If Not 入力チェック() Then
            Return
        End If
        '
        Dim int行 As Integer
        Dim intサブスクリプション連番 As Integer = CInt(tbxサブスクリプション連番.Text)
        '
        If rbt登録.Checked Then
            Dim 連番最大 As Integer? = GetValue(Of Integer?)("SELECT MAX(サブスクリプション連番) FROM M03_サブスクリプション")
            intサブスクリプション連番 = If(連番最大 Is Nothing, 1, 連番最大 + 1)
            SQL.Length = 0
            SQL.AppendLine("INSERT")
            SQL.AppendLine("INTO")
            SQL.AppendLine("    M03_サブスクリプション")
            SQL.AppendLine("VALUES")
            SQL.AppendLine("(")
            SQL.AppendLine("    " & intサブスクリプション連番 & ",")
            SQL.AppendLine("    '" & DirectCast(cbx権利者ID.SelectedItem, CbxItem).L & "',")
            SQL.AppendLine("    '" & DirectCast(cbxメーカーID.SelectedItem, CbxItem).L & "',")
            SQL.AppendLine("    " & If(chkサブスクリプション不要.Checked, "NULL", "'" & editサブスクリプションID.Text & "'") & ",")
            SQL.AppendLine("    " & If(ndtp開始日.IsNull, "NULL", "'" & ndtp開始日.Value.Value.ToString("yyyy/MM/dd") & "'") & ",")
            SQL.AppendLine("    " & If(ndtp終了日.IsNull, "NULL", "'" & ndtp終了日.Value.Value.ToString("yyyy/MM/dd") & "'") & ",")
            SQL.AppendLine("    " & If(ndtp購入日.IsNull, "NULL", "'" & ndtp購入日.Value.Value.ToString("yyyy/MM/dd") & "'") & ",")
            SQL.AppendLine("    GETDATE(),")
            SQL.AppendLine("    GETDATE(),")
            SQL.AppendLine("    0")
            SQL.AppendLine(")")
        ElseIf rbt更新.Checked Then
            SQL.Length = 0
            SQL.AppendLine("UPDATE")
            SQL.AppendLine("    M03_サブスクリプション")
            SQL.AppendLine("SET")
            SQL.AppendLine("    権利者ID = '" & DirectCast(cbx権利者ID.SelectedItem, CbxItem).L & "',")
            SQL.AppendLine("    メーカーID = '" & DirectCast(cbxメーカーID.SelectedItem, CbxItem).L & "',")
            SQL.AppendLine("    サブスクリプションID = " & If(chkサブスクリプション不要.Checked, "NULL", "'" & editサブスクリプションID.Text & "'") & ",")
            SQL.AppendLine("    有効期間開始日 = " & If(ndtp開始日.IsNull, "NULL", "'" & ndtp開始日.Value.Value.ToString("yyyy/MM/dd") & "'") & ",")
            SQL.AppendLine("    有効期間終了日 = " & If(ndtp終了日.IsNull, "NULL", "'" & ndtp終了日.Value.Value.ToString("yyyy/MM/dd") & "'") & ",")
            SQL.AppendLine("    購入日 = " & If(ndtp購入日.IsNull, "NULL", "'" & ndtp購入日.Value.Value.ToString("yyyy/MM/dd") & "'") & ",")
            SQL.AppendLine("    削除区分 = " & If(chk削除済.Checked, "1", "0") & ",")
            SQL.AppendLine("    更新日時 = GETDATE()")
            SQL.AppendLine("WHERE")
            SQL.AppendLine("        サブスクリプション連番 = " & intサブスクリプション連番 & "")
        ElseIf rbt削除.Checked Then
            If MessageBox.Show("本当に削除してよろしいですか？", "削除確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.Cancel Then
                Return
            End If
            SQL.Length = 0
            SQL.AppendLine("UPDATE")
            SQL.AppendLine("    M03_サブスクリプション")
            SQL.AppendLine("SET")
            SQL.AppendLine("    削除区分 = 1,")
            SQL.AppendLine("    更新日時 = GETDATE()")
            SQL.AppendLine("WHERE")
            SQL.AppendLine("    サブスクリプション連番 = " & tbxサブスクリプション連番.Text & "")
            int行 = dgvサブスクリプション一覧.CurrentRow.Index - 1
            int行 = If(int行 < 0, 0, int行)
        End If

        ' 実行
        If ExecNonQuery(SQL.ToString) Then
            MsgInfo("DB更新結果", "データベースの更新に成功しました。")
        End If

        グリッド表示()

        ' 新規登録の時は、追加したデータを修正モードにする
        If rbt登録.Checked OrElse rbt更新.Checked Then
            Dim dtb = DirectCast(dgvサブスクリプション一覧.DataSource, DataTable)
            Dim 対象行 = dtb.AsEnumerable.Where(Function(x) x("サブスクリプション連番") = intサブスクリプション連番)
            int行 = If(対象行.Count = 0, 0, dtb.Rows.IndexOf(対象行.First))
        End If

        'RemoveHandler dgvサブスクリプション一覧.RowEnter, AddressOf dgvサブスクリプション一覧_RowEnter
        dgvサブスクリプション一覧.CurrentCell = dgvサブスクリプション一覧(0, int行)
        'AddHandler dgvサブスクリプション一覧.RowEnter, AddressOf dgvサブスクリプション一覧_RowEnter

        If rbt登録.Checked Then
            rbt更新.Checked = True
            Return
        End If
        '' 項目情報を更新する
        '詳細項目更新()
    End Sub


    Private Sub rbt共通_CheckedChanged(sender As Object, e As EventArgs) Handles rbt登録.CheckedChanged, rbt更新.CheckedChanged, rbt削除.CheckedChanged
        ' ラジオボタン変更の際、選択されたボタンについて1回のみ処理する条件
        If sender Is rbt登録 AndAlso rbt登録.Checked OrElse
           sender Is rbt更新 AndAlso rbt更新.Checked OrElse
           sender Is rbt削除 AndAlso rbt削除.Checked Then

            If rbt登録.Checked OrElse rbt更新.Checked Then
                SetupControls(SetupType.必須, editサブスクリプションID, cbx権利者ID, cbxメーカーID)
                SetupControls(SetupType.通常, ndtp開始日, ndtp終了日, ndtp購入日)
                chkサブスクリプション不要.Enabled = True

            ElseIf rbt削除.Checked Then
                SetupControls(SetupType.参照, editサブスクリプションID, cbx権利者ID, cbxメーカーID, ndtp開始日, ndtp終了日, ndtp購入日)
                chkサブスクリプション不要.Enabled = False
            End If

            詳細項目更新()
        End If
    End Sub

    Private Sub dgvサブスクリプション一覧_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvサブスクリプション一覧.RowEnter
        m_intDGV1CurrentRowIndex = e.RowIndex
        詳細項目更新()
    End Sub

    Private Sub btn終了_Click(sender As Object, e As EventArgs) Handles btn終了.Click
        Me.Close()
    End Sub


    Private Function 入力チェック() As Boolean

        If rbt削除.Checked Then
            Return True
        End If

        If Not chkサブスクリプション不要.Checked AndAlso editサブスクリプションID.Text.Trim = "" Then
            MsgWarn("入力チェック", "サブスクリプションIDを入力して下さい。")
            editサブスクリプションID.Focus()
            Return False
        ElseIf cbx権利者ID.SelectedIndex < 0 Then
            MsgWarn("入力チェック", "権利者を選択して下さい。")
            cbx権利者ID.Focus()
            Return False
        ElseIf cbxメーカーID.SelectedIndex < 0 Then
            MsgWarn("入力チェック", "メーカーを選択して下さい。")
            cbxメーカーID.Focus()
            Return False
        End If

        '重複チェック
        SQL.Length = 0
        SQL.AppendLine("SELECT")
        SQL.AppendLine("    COUNT(*)")
        SQL.AppendLine("FROM")
        SQL.AppendLine("    M03_サブスクリプション")
        SQL.AppendLine("WHERE")
        SQL.AppendLine("        権利者ID = '" & cbx権利者ID.exSelectedKey & "'")
        SQL.AppendLine("    AND メーカーID = '" & cbxメーカーID.exSelectedKey & "'")
        SQL.AppendLine("    AND ISNULL(サブスクリプションID,'') = '" & If(chkサブスクリプション不要.Checked, "", editサブスクリプションID.Text.Trim) & "'")
        ' 登録の場合は単純な重複チェックだが
        ' 更新の場合は、変更前と変更後のPKが不変ならば許容する
        If rbt更新.Checked Then
            SQL.AppendLine("    AND サブスクリプション連番 <> " & tbxサブスクリプション連番.Text)
        End If

        If GetValue(Of Integer)(SQL.ToString) > 0 Then
            MsgWarn("入力チェック", "入力されたサブスクリプション情報は「権利者ID・メーカーID・サブスクリプションID」のいずれかが重複しています。ご確認下さい。")
            Return False
        End If

        Return True
    End Function

    Private Sub グリッド表示()
        SQL.Length = 0
        SQL.AppendLine("SELECT")
        SQL.AppendLine("    M03.サブスクリプション連番,")
        SQL.AppendLine("    M03.権利者ID,")
        SQL.AppendLine("    M02.社員名 AS 権利者,")
        SQL.AppendLine("    M03.メーカーID,")
        SQL.AppendLine("    M11.メーカー名称 AS メーカー,")
        'SQL.AppendLine("    CASE")
        'SQL.AppendLine("    WHEN M03.サブスクリプションID IS NULL THEN '" & gsSID置換文字列 & "'")
        'SQL.AppendLine("    ELSE M03.サブスクリプションID")
        'SQL.AppendLine("    END AS サブスクリプションID,")
        SQL.AppendLine("    M03.サブスクリプションID,")
        SQL.AppendLine("    M03.有効期間開始日,")
        SQL.AppendLine("    M03.有効期間終了日,")
        SQL.AppendLine("    M03.購入日,")
        SQL.AppendLine("    M03.作成日時,")
        SQL.AppendLine("    M03.更新日時,")
        SQL.AppendLine("    M03.削除区分")
        SQL.AppendLine("FROM")
        SQL.AppendLine("    M03_サブスクリプション M03")
        SQL.AppendLine("    INNER JOIN")
        SQL.AppendLine("    M02_社員 M02 ON")
        SQL.AppendLine("    M03.権利者ID = m02.社員ID")
        SQL.AppendLine("    INNER JOIN")
        SQL.AppendLine("    M11_メーカー M11 ON")
        SQL.AppendLine("    M03.メーカーID = M11.メーカーID")
        SQL.AppendLine("ORDER BY")
        SQL.AppendLine("    M03.権利者ID,")
        SQL.AppendLine("    M03.削除区分,")
        SQL.AppendLine("    M03.メーカーID,")
        SQL.AppendLine("    M03.サブスクリプションID")

        ' 不用意なイベント発生を防ぐため一旦外す
        RemoveHandler dgvサブスクリプション一覧.RowEnter, AddressOf dgvサブスクリプション一覧_RowEnter
        Dim dtb As DataTable = GetDataTable(SQL.ToString)
        ' 削除表示が指定されていたら全て表示する
        If chk削除済表示.Checked Then
            dgvサブスクリプション一覧.DataSource = dtb
            ' 論理削除済みの項目を表示し前景色を変更する
            For i = 0 To dtb.Rows.Count - 1
                ' 削除区分=1 ならば前景色を変える
                If dtb(i)("削除区分") = 1 Then
                    For Each ce As DataGridViewCell In dgvサブスクリプション一覧.Rows(i).Cells
                        ce.Style.ForeColor = Color.Red
                    Next
                End If
            Next
        Else
            ' 削除区分=0 ものだけ表示する
            dgvサブスクリプション一覧.DataSource = (From r In dtb Where r("削除区分") = 0).CopyToDataTable
        End If
        AddHandler dgvサブスクリプション一覧.RowEnter, AddressOf dgvサブスクリプション一覧_RowEnter
        ' 行インデックス初期化
        m_intDGV1CurrentRowIndex = 0
    End Sub

    Private Sub 詳細項目更新(Optional ByVal vintrow As Integer = -1)
        Dim drw As DataRow = Nothing

        ' 表示行あれば選択中のDataRowを取得
        If dgvサブスクリプション一覧.Rows.Count > m_intDGV1CurrentRowIndex Then
            drw = DirectCast(dgvサブスクリプション一覧.DataSource, DataTable)(m_intDGV1CurrentRowIndex)
        End If

        ' DataRowを取得できた場合、削除区分=1ならば削除モードを無効等に設定
        If drw IsNot Nothing Then
            ' 削除モードかつ削除済ならば更新モードに移りリターン再帰
            If rbt削除.Checked AndAlso drw("削除区分") = 1 Then
                rbt更新.Checked = True
                Return
            End If
            ' 削除されてない:0 ならば有効:true
            rbt削除.Enabled = drw("削除区分") = 0
        End If
        '
        If rbt登録.Checked OrElse dgvサブスクリプション一覧.RowCount = 0 Then
            tbxサブスクリプション連番.Text = ""
            chkサブスクリプション不要.Checked = False
            editサブスクリプションID.Text = ""
            cbx権利者ID.SelectedIndex = -1
            cbxメーカーID.SelectedIndex = -1
            ndtp開始日.Value = Nothing
            ndtp終了日.Value = Nothing
            ndtp購入日.Value = Nothing
            edit作成日時.Text = ""
            edit更新日時.Text = ""
            With chk削除済
                .Checked = False
                .Enabled = False
            End With
        Else
            ' 修正 or 削除 モード
            ' サブスクリプションIDがDBNullならば不要とみなしてチェック入れる
            tbxサブスクリプション連番.Text = drw("サブスクリプション連番")
            chkサブスクリプション不要.Checked = IsDBNull(drw("サブスクリプションID"))
            editサブスクリプションID.Text = sNvl(drw("サブスクリプションID"))
            cbx権利者ID.SelectedItem = GetComboBoxItem(cbx権利者ID, drw("権利者ID"))
            cbxメーカーID.SelectedItem = GetComboBoxItem(cbxメーカーID, drw("メーカーID"))
            ndtp開始日.Value = dNvl(drw("有効期間開始日"))
            ndtp終了日.Value = dNvl(drw("有効期間終了日"))
            ndtp購入日.Value = dNvl(drw("購入日"))
            edit作成日時.Text = dNvl(drw("作成日時")).ToString("yyyy/MM/dd")
            edit更新日時.Text = dNvl(drw("更新日時")).ToString("yyyy/MM/dd")
            ' 削除済のものだけ、チェックボックスを有効する
            With chk削除済
                .Checked = drw("削除区分") = 1
                .Enabled = .Checked
            End With
        End If
    End Sub

    Private Sub chk削除済表示_CheckedChanged(sender As Object, e As EventArgs) Handles chk削除済表示.CheckedChanged
        グリッド表示()
        詳細項目更新()
    End Sub
End Class