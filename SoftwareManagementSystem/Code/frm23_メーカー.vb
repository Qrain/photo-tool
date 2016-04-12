Imports System.Text

Public Class frm23_メーカー

    Private SQL As New StringBuilder
    Private m_intDGV1CurrentRowIndex As Integer = 0

    Private Sub frm23_メーカー_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDataGridViewProperties(dgvメーカー一覧)
        グリッド表示()
    End Sub

    Private Sub btn更新_Click(sender As Object, e As EventArgs) Handles btn更新.Click
        If Not 入力チェック() Then
            Return
        End If
        '
        Dim int行 As Integer
        Dim strメーカーID As String = editメーカーID.Text.Trim
        '
        If rbt登録.Checked Then
            ' メーカーIDを採番する。採番ルールは単純に最大のメーカーID＋１の値
            SQL.Length = 0
            SQL.AppendLine("SELECT")
            SQL.AppendLine("    RIGHT ('000' + CONVERT(VARCHAR,ISNULL(MAX(メーカーID),0) + 1),3)")
            SQL.AppendLine("FROM")
            SQL.AppendLine("    M11_メーカー")
            strメーカーID = GetValue(Of String)(SQL.ToString)
            ' 登録SQL
            SQL.Length = 0
            SQL.AppendLine("INSERT")
            SQL.AppendLine("INTO")
            SQL.AppendLine("    M11_メーカー")
            SQL.AppendLine("VALUES")
            SQL.AppendLine("(")
            SQL.AppendLine("    '" & strメーカーID & "',")
            SQL.AppendLine("    '" & editメーカー名称.Text.Trim & "',")
            SQL.AppendLine("    GETDATE(),")
            SQL.AppendLine("    GETDATE(),")
            SQL.AppendLine("    0")
            SQL.AppendLine(")")
            '
        ElseIf rbt更新.Checked Then
            SQL.Length = 0
            SQL.AppendLine("UPDATE")
            SQL.AppendLine("    M11_メーカー")
            SQL.AppendLine("SET")
            SQL.AppendLine("    メーカー名称 = '" & editメーカー名称.Text.Trim & "',")
            SQL.AppendLine("    削除区分 = " & If(chk削除済.Checked, "1", "0") & ",")
            SQL.AppendLine("    更新日時 = GETDATE()")
            SQL.AppendLine("WHERE")
            SQL.AppendLine("        メーカーID = '" & strメーカーID & "'")
            '
        ElseIf rbt削除.Checked Then
            If MessageBox.Show("本当に削除してよろしいですか？", "削除確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.Cancel Then
                Return
            End If
            ' 論理削除に変更
            SQL.Length = 0
            SQL.AppendLine("UPDATE")
            SQL.AppendLine("    M11_メーカー")
            SQL.AppendLine("SET")
            SQL.AppendLine("    削除区分 = 1,")
            SQL.AppendLine("    更新日時 = GETDATE()")
            SQL.AppendLine("WHERE")
            SQL.AppendLine("        メーカーID = '" & strメーカーID & "'")
            int行 = If(dgvメーカー一覧.CurrentRow.Index = 0, 0, dgvメーカー一覧.CurrentRow.Index - 1)
        End If

        ' 実行
        If ExecNonQuery(SQL.ToString) Then
            MsgInfo("DB更新結果", "データベースの更新に成功しました。")
        End If
        '
        グリッド表示()

        ' 行インデックスを割り出す
        If rbt登録.Checked OrElse rbt更新.Checked Then
            Dim dtb = DirectCast(dgvメーカー一覧.DataSource, DataTable)
            Dim 対象行 = From r In dtb Where r("メーカーID") = strメーカーID
            int行 = If(対象行.Count = 0, 0, dtb.Rows.IndexOf(対象行.First))
        End If

        ' 選択させる
        dgvメーカー一覧.CurrentCell = dgvメーカー一覧(0, int行)
        '
        If rbt登録.Checked Then
            rbt更新.Checked = True
            Return
        End If

    End Sub

    Private Sub rbt共通_CheckedChanged(sender As Object, e As EventArgs) Handles rbt登録.CheckedChanged, rbt更新.CheckedChanged, rbt削除.CheckedChanged
        If sender Is rbt登録 AndAlso rbt登録.Checked OrElse
           sender Is rbt更新 AndAlso rbt更新.Checked OrElse
           sender Is rbt削除 AndAlso rbt削除.Checked Then

            If rbt登録.Checked OrElse rbt更新.Checked Then
                SetupControls(SetupType.必須, editメーカー名称)
            ElseIf rbt削除.Checked Then
                SetupControls(SetupType.参照, editメーカー名称)
            End If

            詳細項目更新()
        End If
    End Sub

    Private Sub chk削除済表示_CheckedChanged(sender As Object, e As EventArgs) Handles chk削除済表示.CheckedChanged
        グリッド表示()
        詳細項目更新()
    End Sub

    Private Sub dgvメーカー一覧_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvメーカー一覧.RowEnter
        m_intDGV1CurrentRowIndex = e.RowIndex
        詳細項目更新()
    End Sub
    Private Sub btn終了_Click(sender As Object, e As EventArgs) Handles btn終了.Click
        Me.Close()
    End Sub

    Private Sub グリッド表示()
        SQL.Length = 0
        SQL.AppendLine("SELECT")
        SQL.AppendLine("    メーカーID,")
        SQL.AppendLine("    メーカー名称,")
        SQL.AppendLine("    作成日時,")
        SQL.AppendLine("    更新日時,")
        SQL.AppendLine("    削除区分")
        SQL.AppendLine("FROM")
        SQL.AppendLine("    M11_メーカー")
        ' 不用意なイベント発生を防ぐため一旦外す
        RemoveHandler dgvメーカー一覧.RowEnter, AddressOf dgvメーカー一覧_RowEnter
        Dim dtb As DataTable = GetDataTable(SQL.ToString)
        ' 削除表示が指定されていたら全て表示する
        If chk削除済表示.Checked Then
            dgvメーカー一覧.DataSource = dtb
            ' 論理削除済みの項目を表示し前景色を変更する
            For i = 0 To dtb.Rows.Count - 1
                ' 削除区分=1 ならば前景色を変える
                If dtb(i)("削除区分") = 1 Then
                    For Each ce As DataGridViewCell In dgvメーカー一覧.Rows(i).Cells
                        ce.Style.ForeColor = Color.Red
                    Next
                End If
            Next
        Else
            ' 削除区分=0 ものだけ表示する
            dgvメーカー一覧.DataSource = (From r In dtb Where r("削除区分") = 0).CopyToDataTable
        End If
        AddHandler dgvメーカー一覧.RowEnter, AddressOf dgvメーカー一覧_RowEnter
        ' 行インデックス初期化
        m_intDGV1CurrentRowIndex = 0
    End Sub

    Private Function 入力チェック() As Boolean

        If rbt削除.Checked Then
            Return True
        End If

        If editメーカー名称.Text.Trim = "" Then
            MsgWarn("入力チェック", "メーカー名称を入力して下さい。")
            editメーカー名称.Focus()
            Return False
        End If

        ' 重複チェック
        SQL.Length = 0
        SQL.AppendLine("SELECT")
        SQL.AppendLine("    COUNT(*)")
        SQL.AppendLine("FROM")
        SQL.AppendLine("    M11_メーカー")
        SQL.AppendLine("WHERE")
        SQL.AppendLine("    メーカー名称 = '" & editメーカー名称.Text.Trim & "'")
        If rbt更新.Checked Then
            SQL.AppendLine("    AND メーカーID <> '" & editメーカーID.Text & "'")
        End If
        '
        If GetValue(Of Integer)(SQL.ToString) > 0 Then
            MsgWarn("重複チェック", "このメーカー情報は既に登録されています。ご確認下さい。")
            詳細項目更新()
            Return False
        End If

        Return True
    End Function

    Private Sub 詳細項目更新()
        Dim drw As DataRow = Nothing

        ' 表示行あれば選択中のDataRowを取得
        If dgvメーカー一覧.Rows.Count > m_intDGV1CurrentRowIndex Then
            drw = DirectCast(dgvメーカー一覧.DataSource, DataTable)(m_intDGV1CurrentRowIndex)
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
        If rbt登録.Checked OrElse drw Is Nothing Then
            editメーカーID.Text = ""
            editメーカー名称.Text = ""
            edit作成日時.Text = ""
            edit更新日時.Text = ""
            With chk削除済
                .Checked = False
                .Enabled = False
            End With
        Else
            ' 修正 or 削除 モード
            editメーカーID.Text = sNvl(drw("メーカーID"))
            editメーカー名称.Text = sNvl(drw("メーカー名称"))
            edit作成日時.Text = dNvl(drw("作成日時")).ToString("yyyy/MM/dd")
            edit更新日時.Text = dNvl(drw("更新日時")).ToString("yyyy/MM/dd")
            ' 削除済のものだけ、チェックボックスを有効する
            With chk削除済
                .Checked = drw("削除区分") = 1
                .Enabled = .Checked
            End With
        End If
    End Sub

End Class