Imports System.Text

Public Class frm21_名称マスタ保守

    Private SQL As New StringBuilder

    Private Sub frm21_名称マスタ保守_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbt登録.Checked = True
        SetupDataGridViewProperties(dgv名称一覧)
        グリッド表示()
    End Sub

    Private Sub btn更新_Click(sender As Object, e As EventArgs) Handles btn更新.Click

        If Not 入力チェック() Then
            Return
        End If
        '
        Dim int行 As Integer
        If rbt登録.Checked Then
            ' 重複チェック
            SQL.Length = 0
            SQL.AppendLine("SELECT")
            SQL.AppendLine("    COUNT(*)")
            SQL.AppendLine("FROM")
            SQL.AppendLine("    M01_名称")
            SQL.AppendLine("WHERE")
            SQL.AppendLine("    名称区分 = '" & edit名称区分.Text.Trim & "'")
            SQL.AppendLine("    AND 名称コード = '" & edit名称コード.Text.Trim & "'")
            '
            If GetValue(Of Integer)(SQL.ToString) > 0 Then
                MsgWarn("重複チェック", "この名称マスタ情報は既に登録されています。ご確認下さい。")
                Return
            End If
            '
            SQL.Length = 0
            SQL.AppendLine("INSERT")
            SQL.AppendLine("INTO")
            SQL.AppendLine("    M01_名称")
            SQL.AppendLine("VALUES")
            SQL.AppendLine("(")
            SQL.AppendLine("    '" & edit名称区分.Text.Trim & "',")
            SQL.AppendLine("    '" & edit名称コード.Text.Trim & "',")
            SQL.AppendLine("    '" & edit名称.Text & "',")
            SQL.AppendLine("    '" & edit備考.Text & "',")
            SQL.AppendLine("    GETDATE(),")
            SQL.AppendLine("    GETDATE(),")
            SQL.AppendLine("    0")
            SQL.AppendLine(")")

        ElseIf rbt更新.Checked Then
            SQL.Length = 0
            SQL.AppendLine("UPDATE")
            SQL.AppendLine("    M01_名称")
            SQL.AppendLine("SET")
            SQL.AppendLine("    名称 = '" & edit名称.Text & "',")
            SQL.AppendLine("    備考 = '" & edit備考.Text & "',")
            SQL.AppendLine("    更新日時 = GETDATE()")
            SQL.AppendLine("WHERE")
            SQL.AppendLine("        名称区分 = '" & edit名称区分.Text & "'")
            SQL.AppendLine("    AND 名称コード = '" & edit名称コード.Text & "'")
            int行 = dgv名称一覧.CurrentRow.Index
        ElseIf rbt削除.Checked Then
            If MessageBox.Show("本当に削除してよろしいですか？", "削除確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.Cancel Then
                Return
            End If
            SQL.Length = 0
            SQL.AppendLine("DELETE")
            SQL.AppendLine("    M01_名称")
            SQL.AppendLine("WHERE")
            SQL.AppendLine("        名称区分 = '" & edit名称区分.Text & "'")
            SQL.AppendLine("    AND 名称コード = '" & edit名称コード.Text & "'")
            int行 = If(dgv名称一覧.CurrentRow.Index = 0, 0, dgv名称一覧.CurrentRow.Index - 1)
        End If

        ' 実行
        If ExecNonQuery(SQL.ToString) Then
            MsgInfo("DB更新結果", "データベースの更新に成功しました。")
        End If

        グリッド表示()

        ' 新規登録の時は、追加したデータを修正モードにする
        If rbt登録.Checked Then
            Dim dtb = DirectCast(dgv名称一覧.DataSource, DataTable)
            Dim 対象行 =
                From x In dtb.AsEnumerable
                Where x("名称区分") = edit名称区分.Text.Trim AndAlso x("名称コード") = edit名称コード.Text.Trim
            int行 = If(対象行.Count = 0, 0, dtb.Rows.IndexOf(対象行.First))
        End If

        ' 選択させる
        RemoveHandler dgv名称一覧.RowEnter, AddressOf dgv名称一覧_RowEnter
        dgv名称一覧.CurrentCell = dgv名称一覧(0, int行)
        AddHandler dgv名称一覧.RowEnter, AddressOf dgv名称一覧_RowEnter

        If rbt登録.Checked Then
            rbt更新.Checked = True
            Return
        End If

        ' 項目情報を更新する
        詳細項目更新()
    End Sub


    Private Sub rbt共通_CheckedChanged(sender As Object, e As EventArgs) Handles rbt登録.CheckedChanged, rbt更新.CheckedChanged, rbt削除.CheckedChanged
        If sender Is rbt登録 AndAlso rbt登録.Checked Then
            SetupControls(SetupType.必須, edit名称区分, edit名称コード) ', edit名称
            SetupControls(SetupType.通常, edit名称, edit備考)
            詳細項目更新()
        ElseIf sender Is rbt更新 AndAlso rbt更新.Checked Then
            SetupControls(SetupType.参照, edit名称区分, edit名称コード)
            SetupControls(SetupType.通常, edit名称, edit備考)
            詳細項目更新()
        ElseIf sender Is rbt削除 AndAlso rbt削除.Checked Then
            SetupControls(SetupType.参照, edit名称区分, edit名称コード, edit名称, edit備考) ', edit名称
            詳細項目更新()
        End If
    End Sub

    Private Sub dgv名称一覧_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv名称一覧.RowEnter
        詳細項目更新(e.RowIndex)
    End Sub

    Private Sub btn終了_Click(sender As Object, e As EventArgs) Handles btn終了.Click
        Me.Close()
    End Sub

    Private Sub グリッド表示()
        SQL.Length = 0
        SQL.AppendLine("SELECT")
        SQL.AppendLine("    名称区分,")
        SQL.AppendLine("    名称コード,")
        SQL.AppendLine("    名称,")
        SQL.AppendLine("    備考,")
        SQL.AppendLine("    作成日時,")
        SQL.AppendLine("    更新日時")
        SQL.AppendLine("FROM")
        SQL.AppendLine("    M01_名称")
        SQL.AppendLine("WHERE")
        SQL.AppendLine("    削除区分 = 0")
        ' 不用意なイベント発生を防ぐため一旦外す
        RemoveHandler dgv名称一覧.RowEnter, AddressOf dgv名称一覧_RowEnter
        dgv名称一覧.DataSource = GetDataTable(SQL.ToString)
        AddHandler dgv名称一覧.RowEnter, AddressOf dgv名称一覧_RowEnter
    End Sub

    Private Function 入力チェック() As Boolean

        If edit名称区分.Text.Trim = "" Then
            MsgWarn("入力チェック", "名称区分を入力して下さい。")
            edit名称区分.Focus()
            Return False
        ElseIf edit名称コード.Text.Trim = "" Then
            MsgWarn("入力チェック", "名称コードを入力して下さい。")
            edit名称コード.Focus()
            Return False
        End If

        Return True
    End Function


    Private Sub 詳細項目更新(Optional ByVal vintrow As Integer = -1)
        If rbt登録.Checked OrElse dgv名称一覧.RowCount = 0 Then
            edit名称区分.Text = ""
            edit名称コード.Text = ""
            edit名称.Text = ""
            edit備考.Text = ""
            edit作成日時.Text = ""
            edit更新日時.Text = ""
        Else
            ' 修正 or 削除 モード

            ' 行数がパラメータによって指定されていればそっちを優先して使う
            Dim row As Integer = If(vintrow < 0, dgv名称一覧.CurrentCellAddress.Y, vintrow)
            With DirectCast(dgv名称一覧.DataSource, DataTable)(row)
                edit名称区分.Text = sNvl(.Item("名称区分"))
                edit名称コード.Text = sNvl(.Item("名称コード"))
                edit名称.Text = sNvl(.Item("名称"))
                edit備考.Text = sNvl(.Item("備考"))
                edit作成日時.Text = dNvl(.Item("作成日時")).ToString("yyyy/MM/dd")
                edit更新日時.Text = dNvl(.Item("更新日時")).ToString("yyyy/MM/dd")
            End With
        End If
    End Sub

End Class