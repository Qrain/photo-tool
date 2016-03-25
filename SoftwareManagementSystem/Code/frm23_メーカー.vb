﻿Imports System.Text

Public Class frm23_メーカー

    Private SQL As New StringBuilder

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
        '
        If rbt登録.Checked Then
            '
            SQL.Length = 0
            SQL.AppendLine("INSERT")
            SQL.AppendLine("INTO")
            SQL.AppendLine("    M11_メーカー")
            SQL.AppendLine("VALUES")
            SQL.AppendLine("(")
            SQL.AppendLine("    RIGHT('000'+CONVERT(varchar,ISNULL((SELECT MAX(メーカーID) FROM M11_メーカー), 0)+1), 3),")
            'SQL.AppendLine("    '" & メーカーID採番.ToString("000") & "',")
            SQL.AppendLine("    '" & editメーカー名称.Text.Trim & "',")
            SQL.AppendLine("    GETDATE(),")
            SQL.AppendLine("    GETDATE(),")
            SQL.AppendLine("    0")
            SQL.AppendLine(")")

        ElseIf rbt更新.Checked Then
            SQL.Length = 0
            SQL.AppendLine("UPDATE")
            SQL.AppendLine("    M11_メーカー")
            SQL.AppendLine("SET")
            SQL.AppendLine("    メーカー名称 = '" & editメーカー名称.Text.Trim & "',")
            SQL.AppendLine("    更新日時 = GETDATE()")
            SQL.AppendLine("WHERE")
            SQL.AppendLine("        メーカーID = '" & editメーカーID.Text & "'")
            int行 = dgvメーカー一覧.CurrentRow.Index
        ElseIf rbt削除.Checked Then
            If MessageBox.Show("本当に削除してよろしいですか？", "削除確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.Cancel Then
                Return
            End If
            SQL.Length = 0
            SQL.AppendLine("DELETE")
            SQL.AppendLine("    M11_メーカー")
            SQL.AppendLine("WHERE")
            SQL.AppendLine("        メーカーID = '" & editメーカーID.Text & "'")
            int行 = If(dgvメーカー一覧.CurrentRow.Index = 0, 0, dgvメーカー一覧.CurrentRow.Index - 1)
        End If

        ' 実行
        If ExecNonQuery(SQL.ToString) Then
            MsgInfo("DB更新結果", "データベースの更新に成功しました。")
        End If
        '
        グリッド表示()
        ' 新規登録の時は、追加したデータを修正モードにする
        If rbt登録.Checked Then
            Dim dtb = DirectCast(dgvメーカー一覧.DataSource, DataTable)
            Dim 対象行 = dtb.AsEnumerable.Where(Function(x) x("メーカーID") = editメーカーID.Text.Trim)
            int行 = If(対象行.Count = 0, 0, dtb.Rows.IndexOf(対象行.First))
        End If
        ' 選択させる
        RemoveHandler dgvメーカー一覧.RowEnter, AddressOf dgvメーカー一覧_RowEnter
        dgvメーカー一覧.CurrentCell = dgvメーカー一覧(0, int行)
        AddHandler dgvメーカー一覧.RowEnter, AddressOf dgvメーカー一覧_RowEnter
        '
        If rbt登録.Checked Then
            rbt更新.Checked = True
            Return
        End If

        ' 項目情報を更新する
        詳細項目更新()
    End Sub

    Private Sub rbt共通_CheckedChanged(sender As Object, e As EventArgs) Handles rbt登録.CheckedChanged, rbt更新.CheckedChanged, rbt削除.CheckedChanged
        If sender Is rbt登録 AndAlso rbt登録.Checked Then
            SetupControls(SetupType.必須, editメーカー名称)
            詳細項目更新()
        ElseIf sender Is rbt更新 AndAlso rbt更新.Checked Then
            SetupControls(SetupType.必須, editメーカー名称)
            詳細項目更新()
        ElseIf sender Is rbt削除 AndAlso rbt削除.Checked Then
            SetupControls(SetupType.参照, editメーカー名称)
            詳細項目更新()
        End If
    End Sub

    Private Sub dgvメーカー一覧_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvメーカー一覧.RowEnter
        詳細項目更新(e.RowIndex)
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
        SQL.AppendLine("    更新日時")
        SQL.AppendLine("FROM")
        SQL.AppendLine("    M11_メーカー")
        SQL.AppendLine("WHERE")
        SQL.AppendLine("    削除区分 = 0")
        ' 不用意なイベント発生を防ぐため一旦外す
        RemoveHandler dgvメーカー一覧.RowEnter, AddressOf dgvメーカー一覧_RowEnter
        dgvメーカー一覧.DataSource = GetDataTable(SQL.ToString)
        AddHandler dgvメーカー一覧.RowEnter, AddressOf dgvメーカー一覧_RowEnter
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

    Private Sub 詳細項目更新(Optional ByVal vintrow As Integer = -1)
        If rbt登録.Checked OrElse dgvメーカー一覧.RowCount = 0 Then
            editメーカーID.Text = ""
            editメーカー名称.Text = ""
            edit作成日時.Text = ""
            edit更新日時.Text = ""
        Else
            ' 修正 or 削除 モード
            ' 行数がパラメータによって指定されていればそっちを優先して使う
            Dim row As Integer = If(vintrow < 0, dgvメーカー一覧.CurrentCellAddress.Y, vintrow)
            With DirectCast(dgvメーカー一覧.DataSource, DataTable)(row)
                editメーカーID.Text = sNvl(.Item("メーカーID"))
                editメーカー名称.Text = sNvl(.Item("メーカー名称"))
                edit作成日時.Text = dNvl(.Item("作成日時")).ToString("yyyy/MM/dd")
                edit更新日時.Text = dNvl(.Item("更新日時")).ToString("yyyy/MM/dd")
            End With
        End If
    End Sub

End Class