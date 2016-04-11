
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
        Dim str社員ID As String = edit社員ID.Text.Trim
        ' 
        If rbt登録.Checked Then
            ' 重複チェック
            SQL.Length = 0
            SQL.AppendLine("SELECT")
            SQL.AppendLine("    社員名,")
            SQL.AppendLine("    社員区分,")
            SQL.AppendLine("    削除区分")
            SQL.AppendLine("FROM")
            SQL.AppendLine("    M02_社員")
            SQL.AppendLine("WHERE")
            SQL.AppendLine("    社員ID = '" & str社員ID & "'")

            Dim dtb As DataTable = GetDataTable(SQL.ToString)
            '
            SQL.Length = 0
            If dtb.Rows.Count > 0 Then
                'Dim drw As DataRow = dtb(0)
                'If drw("削除区分") = 0 Then
                ' 削除されてない表示データに重複がある
                MsgWarn("重複チェック", "社員ID: """ & str社員ID & """ は既に登録されています。")
                Return
                'Else
                '    Dim msg =
                '        "社員ID: """ & str社員ID & """ は既に登録されていますが論理削除されています。" & vbNewLine &
                '        "社員名: """ & drw("社員名") & """  社員区分: """ & drw("社員区分") & """" & vbNewLine &
                '        "物理削除して登録処理を続行しますか？"
                '    ' 論理削除されているデータに重複がある
                '    If MsgOKCancel("重複チェック", msg) = DialogResult.Cancel Then
                '        Return
                '    End If
                '    ' 削除SQLを追加
                '    SQL.AppendLine("DELETE")
                '    SQL.AppendLine("    M02_社員")
                '    SQL.AppendLine("WHERE")
                '    SQL.AppendLine("        社員ID = '" & str社員ID & "';")
                'End If
            End If
            '
            SQL.AppendLine("INSERT")
            SQL.AppendLine("INTO")
            SQL.AppendLine("    M02_社員")
            SQL.AppendLine("VALUES")
            SQL.AppendLine("(")
            SQL.AppendLine("    '" & str社員ID & "',")
            SQL.AppendLine("    '" & edit社員名.Text & "',")
            SQL.AppendLine("    '" & If(rbt個人.Checked, "個人", "法人") & "',")
            SQL.AppendLine("    '" & If(chk権利者区分.Checked, "1", "0") & "',")
            SQL.AppendLine("    GETDATE(),")
            SQL.AppendLine("    GETDATE(),")
            SQL.AppendLine("    0")
            SQL.AppendLine(");")
            's
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
            SQL.AppendLine("        社員ID = '" & str社員ID & "'")
            int行 = dgv社員一覧.CurrentRow.Index
            '
        ElseIf rbt削除.Checked Then
            If MessageBox.Show("本当に削除してよろしいですか？", "削除確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.Cancel Then
                Return
            End If
            ' 論理削除する
            SQL.Length = 0
            SQL.AppendLine("UPDATE")
            SQL.AppendLine("    M02_社員")
            SQL.AppendLine("SET")
            SQL.AppendLine("    削除区分 = 1,")
            SQL.AppendLine("    更新日時 = GETDATE()")
            SQL.AppendLine("WHERE")
            SQL.AppendLine("        社員ID = '" & str社員ID & "'")
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
        SQL.AppendLine("    更新日時,")
        SQL.AppendLine("    削除区分")
        SQL.AppendLine("FROM")
        SQL.AppendLine("    M02_社員")
        ' 不用意なイベント発生を防ぐため一旦外す
        RemoveHandler dgv社員一覧.RowEnter, AddressOf dgv社員一覧_RowEnter
        Dim dtb As DataTable = GetDataTable(SQL.ToString)

        ' 削除表示が指定されていたら全て表示する
        If chk削除済表示.Checked Then
            dgv社員一覧.DataSource = dtb
            ' 論理削除済みの項目を表示し前景色を変更する
            For i = 0 To dtb.Rows.Count - 1
                ' 削除区分=1 ならば前景色を変える
                If dtb(i)("削除区分") = 1 Then
                    For Each ce As DataGridViewCell In dgv社員一覧.Rows(i).Cells
                        ce.Style.ForeColor = Color.LightBlue
                    Next
                End If
            Next
        Else
            ' 削除区分=0 ものだけ表示する
            dgv社員一覧.DataSource = (From r In dtb Where r("削除区分") = 0).CopyToDataTable
        End If
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
            edit削除区分.Text = ""
            btn更新.Enabled = True
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
                edit削除区分.Text = .Item("削除区分")
                btn更新.Enabled = .Item("削除区分") = 0
            End With
        End If
    End Sub

    Private Sub chk削除済表示_CheckedChanged(sender As Object, e As EventArgs) Handles chk削除済表示.CheckedChanged
        グリッド表示()
        詳細項目更新()
    End Sub
End Class