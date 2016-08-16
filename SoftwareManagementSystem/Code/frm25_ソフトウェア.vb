Imports System.Text

Public Class frm25_ソフトウェア

    Private SQL As New StringBuilder

    Private Sub frm23_サブスクリプション_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ComboBoxの準備   
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
        ' グリッドの設定
        SetupDataGridViewProperties(dgvソフトウェア一覧)
        SetupDataGridViewCellMerge(dgvソフトウェア一覧, Column2)
        '
        グリッド表示()
    End Sub


    Private Sub btn更新_Click(sender As Object, e As EventArgs) Handles btn更新.Click

        If Not 入力チェック() Then
            Return
        End If
        '
        Dim int行 As Integer
        Dim strメーカーID As String = DirectCast(cbxメーカーID.SelectedItem, CbxItem).L
        Dim strソフトID As String = editソフトウェアID.Text.Trim
        '
        If rbt登録.Checked Then
            ' ソフトウェアID構成 → メーカーID（3桁）＋連番（4桁）
            strソフトID = Get採番ソフトウェアID()
            '
            SQL.Length = 0
            SQL.AppendLine("INSERT")
            SQL.AppendLine("INTO")
            SQL.AppendLine("    M12_ソフトウェア")
            SQL.AppendLine("VALUES")
            SQL.AppendLine("(")
            SQL.AppendLine("    '" & strソフトID & "',") ' ソフトウェアID
            SQL.AppendLine("    '" & strメーカーID & "',")
            SQL.AppendLine("    '" & editソフトウェア名称.Text.Trim & "',")
            SQL.AppendLine("    '" & If(chkDL済.Checked, "1", "0") & "',")
            SQL.AppendLine("    '" & If(chkDL済.Checked, editファイル名.Text.Trim, "") & "',")
            SQL.AppendLine("    GETDATE(),")
            SQL.AppendLine("    GETDATE(),")
            SQL.AppendLine("    0")
            SQL.AppendLine(")")
            '
        ElseIf rbt更新.Checked Then

            ' メーカーIDが変更された場合は再度ソフトウェアIDを採番する
            Dim str新採番 As String = Get採番ソフトウェアID()

            ' 元々のメーカーID
            Dim str元メーカーID As String = sNvl(DirectCast(dgvソフトウェア一覧.DataSource, DataTable)(dgvソフトウェア一覧.CurrentRow.Index)("メーカーID"))

            SQL.Length = 0
            ' メーカーIDが変更された場合は再度ソフトウェアIDを採番する
            SQL.AppendLine("UPDATE")
            SQL.AppendLine("    M12_ソフトウェア")
            SQL.AppendLine("SET")
            ' メーカーIDが変更され主キーが変わった場合は更新する
            If str元メーカーID <> strメーカーID Then
                SQL.AppendLine("    ソフトウェアID = '" & str新採番 & "',")
            End If
            SQL.AppendLine("    ソフトウェア名称 = '" & editソフトウェア名称.Text.Trim & "',")
            SQL.AppendLine("    DL区分 = '" & If(chkDL済.Checked, "1", "0") & "',")
            SQL.AppendLine("    ファイル名 = '" & If(chkDL済.Checked, editファイル名.Text.Trim, "") & "',")
            SQL.AppendLine("    メーカーID = '" & strメーカーID & "',")
            SQL.AppendLine("    更新日時 = GETDATE()")
            SQL.AppendLine("WHERE")
            SQL.AppendLine("    ソフトウェアID = '" & strソフトID & "';")

            ' メーカーIDが変更された場合、プロダクトキーテーブルのソフトウェアIDも共に変更する
            If str元メーカーID <> strメーカーID Then
                SQL.AppendLine("UPDATE")
                SQL.AppendLine("    M13_プロダクトキー")
                SQL.AppendLine("SET")
                ' メーカーIDが変更され主キーが変わった場合は更新する
                SQL.AppendLine("    ソフトウェアID = '" & str新採番 & "',")
                SQL.AppendLine("    更新日時 = GETDATE()")
                SQL.AppendLine("WHERE")
                SQL.AppendLine("    ソフトウェアID = '" & strソフトID & "';")
                ' ソフトIDを新たにする
                strソフトID = str新採番
            End If

            ' ※ プロダクトキーのメーカー変更した場合は合わせて、サブスクリプションのメーカーも変更したほうが親切かも

        ElseIf rbt削除.Checked Then
            If MessageBox.Show("ソフトウェアを削除すると関連するプロダクトキーも合わせて削除されます。" & vbNewLine & "本当に削除してよろしいですか？", "削除確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.Cancel Then
                Return
            End If
            'ソフトウェア管理でメインなので、これは物理削除する
            SQL.Length = 0
            SQL.AppendLine("DELETE")
            SQL.AppendLine("    M12_ソフトウェア")
            SQL.AppendLine("WHERE")
            SQL.AppendLine("    ソフトウェアID = '" & editソフトウェアID.Text.Trim & "';")
            ' ソフトウェアを削除したらプロダクトキーも合わせて削除する
            SQL.AppendLine("DELETE")
            SQL.AppendLine("    M13_プロダクトキー")
            SQL.AppendLine("WHERE")
            SQL.AppendLine("    ソフトウェアID = '" & editソフトウェアID.Text.Trim & "';")
            int行 = If(dgvソフトウェア一覧.CurrentRow.Index = 0, 0, dgvソフトウェア一覧.CurrentRow.Index - 1)
        End If

        ' 実行
        If ExecNonQuery(SQL.ToString, True) Then
            MsgInfo("DB更新結果", "データベースの更新に成功しました。")
        End If

        グリッド表示()

        ' 新規登録の時は、追加したデータを修正モードにする
        If rbt登録.Checked OrElse rbt更新.Checked Then
            Dim dtb = DirectCast(dgvソフトウェア一覧.DataSource, DataTable)
            Dim 対象行 = dtb.AsEnumerable.Where(Function(x) sNvl(x("ソフトウェアID")) = strソフトID)
            int行 = If(対象行.Count = 0, 0, dtb.Rows.IndexOf(対象行.First))
        End If

        ' 選択させる
        RemoveHandler dgvソフトウェア一覧.RowEnter, AddressOf dgvソフトウェア一覧_RowEnter
        dgvソフトウェア一覧.CurrentCell = dgvソフトウェア一覧(0, int行)
        AddHandler dgvソフトウェア一覧.RowEnter, AddressOf dgvソフトウェア一覧_RowEnter

        If rbt登録.Checked Then
            rbt更新.Checked = True
            Return
        End If

        ' 項目情報を更新する
        詳細項目更新()
    End Sub

    Private Sub rbt共通_CheckedChanged(sender As Object, e As EventArgs) Handles rbt登録.CheckedChanged, rbt更新.CheckedChanged, rbt削除.CheckedChanged
        If sender Is rbt登録 AndAlso rbt登録.Checked Then
            SetupControls(SetupType.必須, editソフトウェア名称, cbxメーカーID)
            SetupControls(SetupType.通常, editファイル名)
            詳細項目更新()
        ElseIf sender Is rbt更新 AndAlso rbt更新.Checked Then
            SetupControls(SetupType.必須, editソフトウェア名称, cbxメーカーID)
            SetupControls(SetupType.通常, editファイル名)
            詳細項目更新()
        ElseIf sender Is rbt削除 AndAlso rbt削除.Checked Then
            SetupControls(SetupType.参照, editソフトウェア名称, cbxメーカーID, editファイル名)
            詳細項目更新()
        End If
    End Sub

    Private Sub dgvソフトウェア一覧_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvソフトウェア一覧.RowEnter
        詳細項目更新(e.RowIndex)
    End Sub

    Private Sub btn終了_Click(sender As Object, e As EventArgs) Handles btn終了.Click
        Me.Close()
    End Sub


    Private Function 入力チェック() As Boolean

        If rbt削除.Checked Then
            Return True
        End If

        If editソフトウェア名称.Text.Trim = "" Then
            MsgWarn("入力チェック", "ソフトウェア名称を入力して下さい。")
            editソフトウェア名称.Focus()
            Return False
        ElseIf cbxメーカーID.SelectedIndex < 0 Then
            MsgWarn("入力チェック", "メーカーを選択して下さい。")
            cbxメーカーID.Focus()
            Return False
        End If

        ' 重複チェック
        SQL.Length = 0
        SQL.AppendLine("SELECT")
        SQL.AppendLine("    COUNT(*)")
        SQL.AppendLine("FROM")
        SQL.AppendLine("    M12_ソフトウェア")
        SQL.AppendLine("WHERE")
        SQL.AppendLine("    ソフトウェア名称 = '" & editソフトウェア名称.Text.Trim & "'")
        SQL.AppendLine("    AND メーカーID = '" & DirectCast(cbxメーカーID.SelectedItem, CbxItem).L & "'")
        If rbt更新.Checked Then
            SQL.AppendLine("    AND ソフトウェアID <> '" & editソフトウェアID.Text.Trim & "'")
        End If
        '
        If GetValue(Of Integer)(SQL.ToString) > 0 Then
            MsgWarn("重複チェック", "このソフトウェア情報は既に登録されています。ご確認下さい。")
            詳細項目更新()
            Return False
        End If

        Return True
    End Function

    Private Sub グリッド表示()
        SQL.Length = 0
        SQL.AppendLine("SELECT")
        SQL.AppendLine("    M12.ソフトウェアID,")
        SQL.AppendLine("    M12.ソフトウェア名称,")
        SQL.AppendLine("    M12.DL区分,")
        SQL.AppendLine("    M12.ファイル名,")
        SQL.AppendLine("    M12.メーカーID,")
        SQL.AppendLine("    M11.メーカー名称,")
        SQL.AppendLine("    M12.更新日時,")
        SQL.AppendLine("    M12.作成日時")
        SQL.AppendLine("FROM")
        SQL.AppendLine("    M12_ソフトウェア M12")
        SQL.AppendLine("    INNER JOIN")
        SQL.AppendLine("    M11_メーカー M11 ON")
        SQL.AppendLine("    M12.メーカーID = M11.メーカーID")
        SQL.AppendLine("WHERE")
        SQL.AppendLine("    M12.削除区分 = 0")
        ' 不用意なイベント発生を防ぐため一旦外す
        RemoveHandler dgvソフトウェア一覧.RowEnter, AddressOf dgvソフトウェア一覧_RowEnter
        Dim dtb As DataTable = GetDataTable(SQL.ToString)
        Dim sorted = ' メーカー名 ソフト名順でソートする
            From x In dtb
            Order By x("メーカー名称"), x("ソフトウェア名称")
        dgvソフトウェア一覧.DataSource = sorted.CopyToDataTable
        AddHandler dgvソフトウェア一覧.RowEnter, AddressOf dgvソフトウェア一覧_RowEnter
    End Sub

    Private Sub 詳細項目更新(Optional ByVal vintrow As Integer = -1)
        If rbt登録.Checked OrElse dgvソフトウェア一覧.RowCount = 0 Then
            editソフトウェアID.Text = ""
            editソフトウェア名称.Text = ""
            chkDL済.Checked = False
            editファイル名.Enabled = False
            editファイル名.Text = ""
            cbxメーカーID.SelectedIndex = -1
            edit作成日時.Text = ""
            edit更新日時.Text = ""
        Else
            ' 修正 or 削除 モード
            ' 行数がパラメータによって指定されていればそっちを優先して使う
            Dim row As Integer = If(vintrow < 0, dgvソフトウェア一覧.CurrentCellAddress.Y, vintrow)
            With DirectCast(dgvソフトウェア一覧.DataSource, DataTable)(row)
                ' サブスクリプションIDがDBNullならば不要とみなしてチェック入れる
                editソフトウェアID.Text = sNvl(.Item("ソフトウェアID"))
                editソフトウェア名称.Text = sNvl(.Item("ソフトウェア名称"))
                chkDL済.Checked = sNvl(.Item("DL区分")) = "1"
                editファイル名.Enabled = sNvl(.Item("DL区分")) = "1"
                editファイル名.Text = sNvl(.Item("ファイル名"))
                cbxメーカーID.SelectedItem = GetComboBoxItem(cbxメーカーID, .Item("メーカーID"))
                edit作成日時.Text = dNvl(.Item("作成日時")).ToString("yyyy/MM/dd")
                edit更新日時.Text = dNvl(.Item("更新日時")).ToString("yyyy/MM/dd")
            End With
        End If
    End Sub

    Private Function Get採番ソフトウェアID() As String
        Dim strメーカーID As String = DirectCast(cbxメーカーID.SelectedItem, CbxItem).L
        SQL.Length = 0

        Dim base = CInt(strメーカーID) * 10000

        SQL.AppendLine("SELECT")
        SQL.AppendLine("    RIGHT('0000000' + CONVERT(VARCHAR,ISNULL(MAX(ソフトウェアID)," & base & ") + 1),7)")
        SQL.AppendLine("FROM")
        SQL.AppendLine("    M12_ソフトウェア")
        SQL.AppendLine("WHERE")
        SQL.AppendLine("    LEFT(ソフトウェアID,3) = '" & strメーカーID & "'")
        Return GetValue(Of String)(SQL.ToString)
    End Function

    Private Sub chkDL済_CheckedChanged(sender As Object, e As EventArgs) Handles chkDL済.CheckedChanged
        editファイル名.Enabled = chkDL済.Checked
    End Sub
End Class