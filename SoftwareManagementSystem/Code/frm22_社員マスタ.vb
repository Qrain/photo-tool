
Imports System.Text

Public Class frm22_社員マスタ

    Private SQL As New StringBuilder

    Private Sub frm22_社員マスタ_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDataGridViewProperties(dgv社員一覧)
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
            ' 重複チェック
            SQL.Length = 0
            SQL.AppendLine("SELECT")
            SQL.AppendLine("    COUNT(*)")
            SQL.AppendLine("FROM")
            SQL.AppendLine("    M02_社員")
            SQL.AppendLine("WHERE")
            SQL.AppendLine("    社員ID = '" & edit社員ID.Text.Trim & "'")
            '
            If GetValue(Of Integer)(SQL.ToString) > 0 Then
                MsgWarn("重複チェック", "この社員IDは既に登録されています。ご確認下さい。")
                Return
            End If
            '
            SQL.Length = 0
            SQL.AppendLine("INSERT")
            SQL.AppendLine("INTO")
            SQL.AppendLine("    M02_社員")
            SQL.AppendLine("VALUES")
            SQL.AppendLine("(")
            SQL.AppendLine("    '" & edit社員ID.Text.Trim & "',")
            SQL.AppendLine("    '" & edit社員名.Text & "',")
            SQL.AppendLine("    '" & If(rbt個人.Checked, "個人", "法人") & "',")
            SQL.AppendLine("    '" & If(chk権利者区分.Checked, "1", "0") & "',")
            SQL.AppendLine("    GETDATE(),")
            SQL.AppendLine("    GETDATE(),")
            SQL.AppendLine("    0")
            SQL.AppendLine(")")
        ElseIf rbt更新.Checked Then
            SQL.Length = 0
            SQL.AppendLine("UPDATE")
            SQL.AppendLine("    M02_社員")
            SQL.AppendLine("SET")
            SQL.AppendLine("    社員名 = '" & edit社員名.Text & "',")
            SQL.AppendLine("    社員区分 = '" & If(rbt個人.Checked, "個人", "法人") & "',")
            SQL.AppendLine("    権利者区分 = '" & If(chk権利者区分.Checked, "1", "0") & "',")
            SQL.AppendLine("    更新日時 = GETDATE()")
            SQL.AppendLine("WHERE")
            SQL.AppendLine("        社員ID = '" & edit社員ID.Text & "'")
            int行 = dgv社員一覧.CurrentRow.Index
        ElseIf rbt削除.Checked Then
            If MessageBox.Show("本当に削除してよろしいですか？", "削除確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.Cancel Then
                Return
            End If
            SQL.Length = 0
            SQL.AppendLine("DELETE")
            SQL.AppendLine("    M02_社員")
            SQL.AppendLine("WHERE")
            SQL.AppendLine("        社員ID = '" & edit社員ID.Text.Trim & "'")
            int行 = If(dgv社員一覧.CurrentRow.Index = 0, 0, dgv社員一覧.CurrentRow.Index - 1)
        End If

        ' 実行
        If ExecNonQuery(SQL.ToString) Then
            MsgInfo("DB更新結果", "データベースの更新に成功しました。")
        End If

        ' グリッド再描画
        グリッド表示()
        ' 
        If rbt登録.Checked Then
            Dim dtb = DirectCast(dgv社員一覧.DataSource, DataTable)
            Dim 対象行 = dtb.AsEnumerable.Where(Function(x) x("社員ID") = edit社員ID.Text.Trim)
            int行 = If(対象行.Count = 0, 0, dtb.Rows.IndexOf(対象行.First))
        End If

        ' 選択させる
        RemoveHandler dgv社員一覧.RowEnter, AddressOf dgv社員一覧_RowEnter
        dgv社員一覧.CurrentCell = dgv社員一覧(0, int行)
        AddHandler dgv社員一覧.RowEnter, AddressOf dgv社員一覧_RowEnter

        ' 新規登録の時は、追加したデータを修正モードにする
        If rbt登録.Checked Then
            rbt更新.Checked = True
            Return
        End If
        ' 項目情報を更新する
        詳細項目更新()
    End Sub

    Private Sub rbt共通_CheckedChanged(sender As Object, e As EventArgs) Handles rbt登録.CheckedChanged, rbt更新.CheckedChanged, rbt削除.CheckedChanged
        If sender Is rbt登録 AndAlso rbt登録.Checked Then
            SetupControls(SetupType.必須, edit社員ID, edit社員名)
            詳細項目更新()
        ElseIf sender Is rbt更新 AndAlso rbt更新.Checked Then
            SetupControls(SetupType.参照, edit社員ID)
            SetupControls(SetupType.必須, edit社員名)
            詳細項目更新()
        ElseIf sender Is rbt削除 AndAlso rbt削除.Checked Then
            SetupControls(SetupType.参照, edit社員ID, edit社員名)
            詳細項目更新()
        End If
    End Sub

    Private Sub dgv社員一覧_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv社員一覧.RowEnter
        詳細項目更新(e.RowIndex)
    End Sub

    Private Sub btn終了_Click(sender As Object, e As EventArgs) Handles btn終了.Click
        Me.Close()
    End Sub

    Private Sub グリッド表示()
        SQL.Length = 0
        SQL.AppendLine("SELECT")
        SQL.AppendLine("    社員ID,")
        SQL.AppendLine("    社員名,")
        SQL.AppendLine("    社員区分,")
        SQL.AppendLine("    権利者区分,")
        SQL.AppendLine("    作成日時,")
        SQL.AppendLine("    更新日時")
        SQL.AppendLine("FROM")
        SQL.AppendLine("    M02_社員")
        SQL.AppendLine("WHERE")
        SQL.AppendLine("    削除区分 = 0")
        ' 不用意なイベント発生を防ぐため一旦外す
        RemoveHandler dgv社員一覧.RowEnter, AddressOf dgv社員一覧_RowEnter
        dgv社員一覧.DataSource = GetDataTable(SQL.ToString)
        AddHandler dgv社員一覧.RowEnter, AddressOf dgv社員一覧_RowEnter
    End Sub

    Private Function 入力チェック() As Boolean

        If edit社員ID.Text.Trim = "" Then
            MsgWarn("入力チェック", "社員IDを入力して下さい。")
            edit社員ID.Focus()
            Return False
        ElseIf edit社員名.Text.Trim = "" Then
            MsgWarn("入力チェック", "社員名を入力して下さい。")
            edit社員名.Focus()
            Return False
        End If



        Return True
    End Function

    Private Sub 詳細項目更新(Optional ByVal vintrow As Integer = -1)
        If rbt登録.Checked OrElse dgv社員一覧.RowCount = 0 Then
            edit社員ID.Text = ""
            edit社員名.Text = ""
            rbt個人.Checked = True
            chk権利者区分.Checked = False
            edit作成日時.Text = ""
            edit更新日時.Text = ""
        Else
            ' 修正 or 削除 モード
            ' 行数がパラメータによって指定されていればそっちを優先して使う
            Dim row As Integer = If(vintrow < 0, dgv社員一覧.CurrentRow.Index, vintrow)
            With DirectCast(dgv社員一覧.DataSource, DataTable)(row)
                edit社員ID.Text = sNvl(.Item("社員ID"))
                edit社員名.Text = sNvl(.Item("社員名"))
                rbt個人.Checked = sNvl(.Item("社員区分")) = "個人"
                rbt法人.Checked = sNvl(.Item("社員区分")) = "法人"
                chk権利者区分.Checked = sNvl(.Item("権利者区分")) = "1"
                edit作成日時.Text = dNvl(.Item("作成日時")).ToString("yyyy/MM/dd")
                edit更新日時.Text = dNvl(.Item("更新日時")).ToString("yyyy/MM/dd")
            End With
        End If
    End Sub


End Class