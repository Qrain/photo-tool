Imports System.Text

Public Class frm26_プロダクトキー登録

    Private SQL As New StringBuilder
    Private m_dtbComboBox As DataTable

    Private m_objPreItem権利者ID As Object
    Private m_objPreItemメーカーID As Object
    Private m_objPreItemサブスクリプションID As Object

    Private Sub frm26_プロダクトキー_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' DataGridViewのセットアップを行う
        SetupDataGridViewProperties(dgvプロダクトキー一覧)
        SetupDataGridViewCellMerge(dgvプロダクトキー一覧, dgvc権利者, dgvcメーカー名称, dgvcサブスクリプションID)

        SQL.Length = 0
        SQL.AppendLine("SELECT")
        SQL.AppendLine("    名称コード,")
        SQL.AppendLine("    名称")
        SQL.AppendLine("FROM")
        SQL.AppendLine("    M01_名称")
        SQL.AppendLine("WHERE")
        SQL.AppendLine("    名称区分 = '認証方式'")
        SQL.AppendLine("    AND 削除区分 = 0")
        '
        Dim dtb As DataTable
        '
        dtb = GetDataTable(SQL.ToString)
        cbx認証タイプ.Items.AddRange(dtb.GeneratePairArray("名称コード", "名称"))
        '
        cbx利用者ID.Items.Add("<未指定>")
        cbx利用者ID.SelectedIndex = 0
        SQL.Length = 0
        SQL.AppendLine("SELECT")
        SQL.AppendLine("    社員ID,")
        SQL.AppendLine("    社員名")
        SQL.AppendLine("FROM")
        SQL.AppendLine("    M02_社員")
        SQL.AppendLine("WHERE")
        SQL.AppendLine("    削除区分 = 0")
        '
        dtb = GetDataTable(SQL.ToString)
        cbx利用者ID.Items.AddRange(dtb.GeneratePairArray("社員ID", "社員名"))

        cbxメーカーID.Enabled = False
        cbxサブスクリプションID.Enabled = False

        ' ComboBoxへ設定するための   
        m_dtbComboBox = GetComboBox設定用DTB()
        ' 
        ' 権利者を重複を除去して設定する
        cbx権利者ID.Items.AddRange(m_dtbComboBox.GeneratePairArray("権利者ID", "社員名"))
        '
        グリッド表示()
    End Sub

    Private Sub cbx権利者ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbx権利者ID.SelectedIndexChanged
        ' このイベントは同じ項目クリック（選択）でも、
        ' つまりSelectedIndexがChangeしてなくても何故か呼ばれるので、無駄な処理を回避するための処理
        If m_objPreItem権利者ID IsNot Nothing AndAlso
           m_objPreItem権利者ID Is cbx権利者ID.SelectedItem Then
            Return
        End If
        ' 前のアイテムを更新
        m_objPreItem権利者ID = cbx権利者ID.SelectedItem

        ' メーカー選択コンボボックスを有効にする
        cbxメーカーID.Enabled = rbt登録.Checked AndAlso cbx権利者ID.SelectedIndex >= 0
        ' 下位コンボボックスの選択を解除する
        cbxメーカーID.SelectedIndex = -1
        '
        Dim str権利者 = If(cbx権利者ID.SelectedIndex < 0, "", DirectCast(cbx権利者ID.SelectedItem, CbxItem).L)
        ' 各項目のデータは
        Dim lstメーカー =
            From x In m_dtbComboBox.AsEnumerable
            Where If(str権利者 = "", True, sNvl(x("権利者ID")) = str権利者)
            Select New CbxItem(x("メーカーID"), x("メーカー名称"))
        ' 取得したアイテムを設定する
        cbxメーカーID.Items.Clear()
        cbxメーカーID.Items.AddRange(lstメーカー.Distinct.ToArray)
        ' この権利者に関連するメーカーIDが一つだけなら自動選択する
        If cbxメーカーID.Items.Count = 1 Then
            cbxメーカーID.SelectedIndex = 0
        End If
    End Sub

    Private Sub cbxメーカーID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxメーカーID.SelectedIndexChanged
        ' つまりSelectedIndexがChangeしてなくても何故か呼ばれるので、無駄な処理を回避するための処理
        If m_objPreItemメーカーID IsNot Nothing AndAlso
           m_objPreItemメーカーID Is cbxメーカーID.SelectedItem Then
            Return
        End If
        ' 前のアイテムを更新
        m_objPreItemメーカーID = cbxメーカーID.SelectedItem
        '
        ' サブスクリプションID選択コンボボックスを有効にする
        cbxサブスクリプションID.Enabled = rbt登録.Checked AndAlso cbxメーカーID.SelectedIndex >= 0
        ' 下位コンボボックスの選択を解除する
        cbxサブスクリプションID.SelectedIndex = -1
        '
        Dim str権利者 = If(cbx権利者ID.SelectedIndex < 0, "", DirectCast(cbx権利者ID.SelectedItem, CbxItem).L)
        Dim strメーカー = If(cbxメーカーID.SelectedIndex < 0, "", DirectCast(cbxメーカーID.SelectedItem, CbxItem).L)
        ' 下位レベルのデータを取得し設定する
        Dim lstサブスクリプション =
            From x In m_dtbComboBox.AsEnumerable
            Where sNvl(x("権利者ID")) = str権利者 AndAlso sNvl(x("メーカーID")) = strメーカー
            Select sNvl(x("サブスクリプションID"))
        ' 取得したアイテムを設定する
        cbxサブスクリプションID.Items.Clear()
        cbxサブスクリプションID.Items.AddRange(lstサブスクリプション.Distinct.ToArray)
        ' 要素が１つだけの場合ははじめからソレを選択させる
        If cbxサブスクリプションID.Items.Count = 1 Then
            cbxサブスクリプションID.SelectedIndex = 0
        End If
        '  
        ソフト一覧ListBoxリセット()
    End Sub

    Private Sub cbxサブスクリプションID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxサブスクリプションID.SelectedIndexChanged
        If m_objPreItemサブスクリプションID IsNot Nothing AndAlso
           m_objPreItemサブスクリプションID Is cbxサブスクリプションID.SelectedItem Then
            Return
        End If
        ' 前のアイテムを更新
        m_objPreItemサブスクリプションID = cbxサブスクリプションID.SelectedItem
        ' 
        If cbxサブスクリプションID.SelectedIndex < 0 Then
            tbx隠_サブスクリプション連番.Text = ""
        Else
            Dim str権利者ID = DirectCast(cbx権利者ID.SelectedItem, CbxItem).L
            Dim strメーカーID = DirectCast(cbxメーカーID.SelectedItem, CbxItem).L
            '
            tbx隠_サブスクリプション連番.Text =
                (From r In m_dtbComboBox.AsEnumerable
                 Where r("権利者ID") = str権利者ID AndAlso r("メーカーID") = strメーカーID AndAlso r("サブスクリプションID") = cbxサブスクリプションID.SelectedItem.ToString
                 Select CInt(r("サブスクリプション連番"))).First


        End If
    End Sub

    Private Sub btn更新_Click(sender As Object, e As EventArgs) Handles btn更新.Click
        '
        If Not 入力チェック() Then
            Return
        End If
        '
        Dim dtb As DataTable = DirectCast(dgvプロダクトキー一覧.DataSource, DataTable)
        Dim int行 As Integer = 0
        '
        If rbt登録.Checked Then
            ' ※ここで重複チェックを行い、もし重複していたら「更新モード」にする
            Dim rows = From r In dtb.AsEnumerable
                       Where r("プロダクトキー") = editプロダクトキー.Text.Trim AndAlso
                                r("サブスクリプション連番") = tbx隠_サブスクリプション連番.Text

            If rows.Count > 0 Then
                ' すでにある者のサブスクリプションのプロダクトキーが何らかのソフトウェアに関連付けられているとき
                MsgInfo("更新情報", "このプロダクトキー情報は既に他の製品に関連付けられています。更新モードに移行します。")
                ' 選択させる
                RemoveHandler dgvプロダクトキー一覧.RowEnter, AddressOf dgvプロダクトキー一覧_RowEnter
                dgvプロダクトキー一覧.CurrentCell = dgvプロダクトキー一覧(0, dtb.Rows.IndexOf(rows.First))
                AddHandler dgvプロダクトキー一覧.RowEnter, AddressOf dgvプロダクトキー一覧_RowEnter
                rbt更新.Checked = True
                ソフト一覧ListBoxリセット()
                Return
            End If

            ' 選択されたコンボボックス情報からサブスクリプション連番を取得する
            ' Delete 
            SQL.Length = 0
            ' 処理的には一度対象レコードの削除を試みてからインサート処理する
            ' これは、PK制約違反を防ぐためである。結果的に差分登録される。
            For Each pair In chklsbソフト情報.CheckedItems.Cast(Of CbxItem)
                SQL.AppendLine("DELETE M13_プロダクトキー")
                SQL.AppendLine("WHERE")
                SQL.AppendLine("        ソフトウェアID = '" & pair.L & "'")
                SQL.AppendLine("    AND プロダクトキー = '" & editプロダクトキー.Text & "'")
                SQL.AppendLine("    AND サブスクリプション連番 = " & tbx隠_サブスクリプション連番.Text & ";")
                '
                SQL.AppendLine("INSERT")
                SQL.AppendLine("INTO")
                SQL.AppendLine("    M13_プロダクトキー")
                SQL.AppendLine("VALUES")
                SQL.AppendLine("(")
                SQL.AppendLine("    '" & pair.L & "',")
                SQL.AppendLine("    '" & editプロダクトキー.Text.Trim & "',")
                SQL.AppendLine("    " & tbx隠_サブスクリプション連番.Text & ",")
                SQL.AppendLine("    '" & DirectCast(cbx認証タイプ.SelectedItem, CbxItem).L & "',")
                SQL.AppendLine("    " & If(ndtp要求日.IsNull, "NULL", "'" & ndtp要求日.Value.Value.ToString("yyyy/MM/dd") & "'") & ",")
                SQL.AppendLine("    " & If(cbx利用者ID.SelectedIndex > 0, "'" & DirectCast(cbx利用者ID.SelectedItem, CbxItem).L & "'", "NULL") & ",")
                SQL.AppendLine("    GETDATE(),")
                SQL.AppendLine("    GETDATE(),")
                SQL.AppendLine("    0")
                SQL.AppendLine(");")
            Next
            '
        ElseIf rbt更新.Checked Then
            ' 更新の場合 → 
            ' 一度対象の「プロダクトキー、サブスクリプション」のデータを全て消してから、指定のソフトウェアを全部登録する
            SQL.Length = 0
            SQL.AppendLine("DELETE M13_プロダクトキー")
            SQL.AppendLine("WHERE")
            SQL.AppendLine("        プロダクトキー = '" & editプロダクトキー.Text.Trim & "'")
            SQL.AppendLine("    AND サブスクリプション連番 = " & tbx隠_サブスクリプション連番.Text & ";")
            '
            For Each pair In chklsbソフト情報.CheckedItems.Cast(Of CbxItem)
                SQL.AppendLine("INSERT")
                SQL.AppendLine("INTO")
                SQL.AppendLine("    M13_プロダクトキー")
                SQL.AppendLine("VALUES")
                SQL.AppendLine("(")
                SQL.AppendLine("    '" & pair.L & "',")
                SQL.AppendLine("    '" & editプロダクトキー.Text.Trim & "',")
                SQL.AppendLine("    " & tbx隠_サブスクリプション連番.Text & ",")
                SQL.AppendLine("    '" & DirectCast(cbx認証タイプ.SelectedItem, CbxItem).L & "',")
                SQL.AppendLine("    " & If(ndtp要求日.IsNull, "NULL", "'" & ndtp要求日.Value.Value.ToString("yyyy/MM/dd") & "'") & ",")
                SQL.AppendLine("    " & If(cbx利用者ID.SelectedIndex > 0, "'" & DirectCast(cbx利用者ID.SelectedItem, CbxItem).L & "'", "NULL") & ",")
                SQL.AppendLine("    GETDATE(),")
                SQL.AppendLine("    GETDATE(),")
                SQL.AppendLine("    0")
                SQL.AppendLine(");")
            Next
            int行 = dgvプロダクトキー一覧.CurrentRow.Index
        ElseIf rbt削除.Checked Then
            If MessageBox.Show("本当に削除してよろしいですか？", "削除確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.Cancel Then
                Return
            End If
            SQL.Length = 0
            SQL.AppendLine("DELETE M13_プロダクトキー")
            SQL.AppendLine("WHERE")
            SQL.AppendLine("        プロダクトキー = '" & editプロダクトキー.Text & "'")
            SQL.AppendLine("    AND サブスクリプション連番 = " & tbx隠_サブスクリプション連番.Text & ";")
            ' 削除後の行を設定（１つ上の行にする）
            int行 = dgvプロダクトキー一覧.CurrentRow.Index - 1
            int行 = If(int行 < 0, 0, int行)
        End If
        ' 実行
        If ExecNonQuery(SQL.ToString, True) Then
            MsgInfo("DB更新結果", "データベースの更新に成功しました。")
        End If
        '
        グリッド表示()
        ' 新規登録の時は、追加したデータを修正モードにする
        If rbt登録.Checked Then
            Dim 対象行 =
                From
                    x In dtb.AsEnumerable
                Where
                    sNvl(x("サブスクリプション連番")) = tbx隠_サブスクリプション連番.Text AndAlso
                    sNvl(x("プロダクトキー")) = editプロダクトキー.Text AndAlso
                    sNvl(x("権利者ID")) = DirectCast(cbx権利者ID.SelectedItem, CbxItem).L

            int行 = If(対象行.Count = 0, 0, dtb.Rows.IndexOf(対象行.First))
            ' 選択させる
            RemoveHandler dgvプロダクトキー一覧.RowEnter, AddressOf dgvプロダクトキー一覧_RowEnter
            dgvプロダクトキー一覧.CurrentCell = dgvプロダクトキー一覧(0, int行)
            AddHandler dgvプロダクトキー一覧.RowEnter, AddressOf dgvプロダクトキー一覧_RowEnter
        End If

        RemoveHandler dgvプロダクトキー一覧.RowEnter, AddressOf dgvプロダクトキー一覧_RowEnter
        dgvプロダクトキー一覧.CurrentCell = dgvプロダクトキー一覧(0, int行)
        AddHandler dgvプロダクトキー一覧.RowEnter, AddressOf dgvプロダクトキー一覧_RowEnter

        If rbt登録.Checked Then
            rbt更新.Checked = True
            Return
        End If

        ' 項目情報を更新する
        詳細項目更新()
        ソフト一覧ListBoxリセット()
    End Sub

    Private Sub rbt共通_CheckedChanged(sender As Object, e As EventArgs) Handles rbt登録.CheckedChanged, rbt更新.CheckedChanged, rbt削除.CheckedChanged
        If sender Is rbt登録 AndAlso rbt登録.Checked Then
            SetupControls(SetupType.必須, cbx権利者ID, cbxメーカーID, cbxサブスクリプションID, cbx認証タイプ)
            SetupControls(SetupType.通常, editプロダクトキー, ndtp要求日, cbx利用者ID)
            chklsbソフト情報.Enabled = True
            詳細項目更新()
        ElseIf sender Is rbt更新 AndAlso rbt更新.Checked Then
            SetupControls(SetupType.参照, editプロダクトキー, cbx権利者ID, cbxメーカーID, cbxサブスクリプションID)
            SetupControls(SetupType.通常, ndtp要求日, cbx認証タイプ, cbx利用者ID)
            chklsbソフト情報.Enabled = True
            詳細項目更新()
        ElseIf sender Is rbt削除 AndAlso rbt削除.Checked Then
            SetupControls(SetupType.参照, editプロダクトキー, cbx権利者ID, cbxメーカーID,
                          cbxサブスクリプションID, ndtp要求日, cbx認証タイプ, cbx利用者ID)
            chklsbソフト情報.Enabled = False
            詳細項目更新()
        End If
    End Sub

    Private Sub dgvプロダクトキー一覧_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvプロダクトキー一覧.RowEnter
        詳細項目更新(e.RowIndex)
        ソフト一覧ListBoxリセット()
    End Sub


    Private Sub btn終了_Click(sender As Object, e As EventArgs) Handles btn終了.Click
        Me.Close()
    End Sub

    Private Function 入力チェック() As Boolean

        ' 削除モードの時は無チェック
        If rbt削除.Checked Then
            Return True
        End If
        ' 
        Dim caption As String = "入力チェック"

        If cbx権利者ID.SelectedIndex < 0 Then
            MsgWarn(caption, "権利者を選択して下さい。")
            cbx権利者ID.Focus()
            Return False
        ElseIf cbxメーカーID.SelectedIndex < 0 Then
            MsgWarn(caption, "メーカーを選択して下さい。")
            cbxメーカーID.Focus()
            Return False
        ElseIf cbxサブスクリプションID.SelectedIndex < 0 Then
            MsgWarn(caption, "サブスクリプションIDを選択して下さい。")
            cbxサブスクリプションID.Focus()
            Return False
        ElseIf cbx認証タイプ.SelectedIndex < 0 Then
            MsgWarn(caption, "認証タイプを選択して下さい。")
            cbx認証タイプ.Focus()
            Return False
        ElseIf chklsbソフト情報.CheckedItems.Count = 0 Then
            ' 削除以外（登録・更新）の場合のチェック
            MsgWarn(caption, "登録及び更新すべきソフトウェアが選択されていません。")
            Return False
        End If
        '
        Return True
    End Function

    Private Sub グリッド表示()
        SQL.Length = 0
        SQL.AppendLine("SELECT DISTINCT")
        'SQL.AppendLine("    M13.ソフトウェアID,")
        'SQL.AppendLine("    M12.ソフトウェア名称,")
        SQL.AppendLine("    M13.プロダクトキー,")
        SQL.AppendLine("    M13.サブスクリプション連番,")
        SQL.AppendLine("    M03.権利者ID,")
        SQL.AppendLine("    M02.社員名 AS 権利者,")
        SQL.AppendLine("    M11.メーカーID,")
        SQL.AppendLine("    M11.メーカー名称,")
        SQL.AppendLine("    M03.サブスクリプションID,")
        SQL.AppendLine("    M13.認証タイプ,")
        SQL.AppendLine("    M13.利用者ID,")
        SQL.AppendLine("    M13.要求日付")
        SQL.AppendLine("FROM")
        SQL.AppendLine("    M13_プロダクトキー M13")
        SQL.AppendLine("    INNER JOIN") ' INNER JOIN 
        SQL.AppendLine("    M12_ソフトウェア M12 ON")
        SQL.AppendLine("    M13.ソフトウェアID = M12.ソフトウェアID")
        SQL.AppendLine("    INNER JOIN")
        SQL.AppendLine("    M11_メーカー M11 ON")
        SQL.AppendLine("    M12.メーカーID = M11.メーカーID")
        SQL.AppendLine("    INNER JOIN")
        SQL.AppendLine("    M03_サブスクリプション M03 ON")
        SQL.AppendLine("    M13.サブスクリプション連番 = M03.サブスクリプション連番")
        SQL.AppendLine("    INNER JOIN")
        SQL.AppendLine("    M02_社員 M02 ON")
        SQL.AppendLine("    M03.権利者ID = M02.社員ID")
        SQL.AppendLine("WHERE")
        SQL.AppendLine("    M13.削除区分 = 0")
        SQL.AppendLine("ORDER BY")
        SQL.AppendLine("    M03.権利者ID,")
        SQL.AppendLine("    M11.メーカーID")
        ' 不用意なイベント発生を防ぐため一旦外す
        RemoveHandler dgvプロダクトキー一覧.RowEnter, AddressOf dgvプロダクトキー一覧_RowEnter
        dgvプロダクトキー一覧.DataSource = GetDataTable(SQL.ToString)
        AddHandler dgvプロダクトキー一覧.RowEnter, AddressOf dgvプロダクトキー一覧_RowEnter
    End Sub

    Private Sub 詳細項目更新(Optional ByVal vintrow As Integer? = Nothing)

        If rbt登録.Checked OrElse dgvプロダクトキー一覧.RowCount = 0 Then
            tbx隠_サブスクリプション連番.Text = ""
            editプロダクトキー.Text = ""
            cbx権利者ID.SelectedIndex = -1
            'cbxメーカーID.SelectedIndex = -1
            'cbxサブスクリプションID.SelectedIndex = -1
            cbx認証タイプ.SelectedIndex = -1
            cbx利用者ID.SelectedIndex = If(cbx利用者ID.Items.Count > 0, 0, -1)
            '
            ndtp要求日.Value = Nothing
        Else
            ' 修正 or 削除 モード
            ' 行数がパラメータによって指定されていればそっちを優先して使う
            Dim row As Integer = If(vintrow Is Nothing, dgvプロダクトキー一覧.CurrentCellAddress.Y, vintrow)
            With DirectCast(dgvプロダクトキー一覧.DataSource, DataTable)(row)
                ' サブスクリプションIDがDBNullならば不要とみなしてチェック入れる
                tbx隠_サブスクリプション連番.Text = .Item("サブスクリプション連番")
                editプロダクトキー.Text = sNvl(.Item("プロダクトキー"))
                cbx権利者ID.SelectedItem = cbx権利者ID.Items.Cast(Of CbxItem).Where(Function(x) x.L = sNvl(.Item("権利者ID"))).First
                cbxメーカーID.SelectedItem = cbxメーカーID.Items.Cast(Of CbxItem).Where(Function(x) x.L = sNvl(.Item("メーカーID"))).First
                cbxサブスクリプションID.SelectedItem = cbxサブスクリプションID.Items.Cast(Of String).Where(Function(x) x = sNvl(.Item("サブスクリプションID"))).First
                cbx認証タイプ.SelectedItem = cbx認証タイプ.Items.Cast(Of CbxItem).Where(Function(x) x.L = sNvl(.Item("認証タイプ"))).First
                ' もし利用者IDがなければコンボボックスを未選択にする
                If IsDBNull(.Item("利用者ID")) Then
                    cbx利用者ID.SelectedIndex = 0
                Else
                    Dim sps =
                        From x In cbx利用者ID.Items.Cast(Of Object)
                        Where TypeOf x Is CbxItem ' <未指定>=Stringなので　StringPairだけを抽出
                        Select DirectCast(x, CbxItem)
                    ' 対象の利用者IDのコンボボックスアイテムを取得する
                    Dim selected =
                        From x In sps
                        Where x.L = .Item("利用者ID")
                    cbx利用者ID.SelectedItem = selected.First
                End If
                '
                ndtp要求日.Value = dNvl(.Item("要求日付"))
                ' 
            End With
        End If
    End Sub

    Private Function GetComboBox設定用DTB() As DataTable
        ' ComboBoxの準備   
        SQL.Length = 0
        SQL.AppendLine("SELECT")
        SQL.AppendLine("    M03.サブスクリプション連番,")
        SQL.AppendLine("    M03.権利者ID,")
        SQL.AppendLine("    M02.社員名,")
        SQL.AppendLine("    M03.メーカーID,")
        SQL.AppendLine("    M11.メーカー名称,")
        SQL.AppendLine("    CASE")
        SQL.AppendLine("    WHEN M03.サブスクリプションID IS NULL THEN")
        SQL.AppendLine("        (")
        SQL.AppendLine("        SELECT")
        SQL.AppendLine("            名称")
        SQL.AppendLine("        FROM")
        SQL.AppendLine("            M01_名称")
        SQL.AppendLine("        WHERE")
        SQL.AppendLine("                名称区分 = 'SID-NULL置換文字列'")
        SQL.AppendLine("            AND 名称コード = '01'")
        SQL.AppendLine("        )")
        SQL.AppendLine("    ELSE")
        SQL.AppendLine("        M03.サブスクリプションID")
        SQL.AppendLine("    END AS サブスクリプションID")
        SQL.AppendLine("FROM")
        SQL.AppendLine("    M03_サブスクリプション M03")
        SQL.AppendLine("    INNER JOIN")
        SQL.AppendLine("    M02_社員 M02 ON")
        SQL.AppendLine("    M03.権利者ID = M02.社員ID")
        SQL.AppendLine("    INNER JOIN")
        SQL.AppendLine("    M11_メーカー M11 ON")
        SQL.AppendLine("    M03.メーカーID = M11.メーカーID")
        SQL.AppendLine("WHERE")
        SQL.AppendLine("    M03.削除区分 = 0")
        Return GetDataTable(SQL.ToString)
    End Function

    Private m_dtbリストボックス As DataTable

    Private Sub ソフト一覧ListBoxリセット()
        ' メーカーIDが変わったらどちらにせよリストボックスをクリアする
        chklsbソフト情報.Items.Clear()
        '
        If cbxメーカーID.SelectedIndex < 0 Then
            lblソフト件数.Text = "0件"
            Return
        End If
        '
        ' 現在選択しているメーカーIDに基いてソフト一覧を取得する
        SQL.Length = 0
        SQL.AppendLine("SELECT")
        SQL.AppendLine("    M12.ソフトウェアID,")
        SQL.AppendLine("    M12.ソフトウェア名称,")
        SQL.AppendLine("    M13.プロダクトキー")
        SQL.AppendLine("FROM")
        SQL.AppendLine("    M12_ソフトウェア M12")
        SQL.AppendLine("    LEFT JOIN")
        SQL.AppendLine("    M13_プロダクトキー M13 ON")
        SQL.AppendLine("    M13.ソフトウェアID = M12.ソフトウェアID")
        SQL.AppendLine("WHERE")
        SQL.AppendLine("        M12.メーカーID = '" & DirectCast(cbxメーカーID.SelectedItem, CbxItem).L & "'")
        SQL.AppendLine("    AND M12.削除区分 = 0")
        '
        m_dtbリストボックス = GetDataTable(SQL.ToString)
        ソフト一覧ListBoxデータ設定(m_dtbリストボックス.AsEnumerable)
    End Sub

    Private Sub ソフト一覧ListBoxデータ設定(ByVal vseq As IEnumerable(Of DataRow))
        ' 初めにクリアする
        chklsbソフト情報.Items.Clear()
        '
        ' 登録モードの場合、データを設定のみしてチェックせずここでリターン
        If rbt登録.Checked Then
            Dim seqAllNoCheck =
                From x In vseq
                Order By x("ソフトウェア名称")
                Select New CbxItem(x("ソフトウェアID"), x("ソフトウェア名称"))

            ' ファイル名順位ソートして追加
            chklsbソフト情報.Items.AddRange(seqAllNoCheck.Distinct.ToArray)
        Else
            ' 既にこのプロダクトキーに関連付けてあるソフト一覧を取得しソフト名でソート
            Dim seq関連付済 =
                From x In vseq
                Where Not IsDBNull(x("プロダクトキー")) AndAlso sNvl(x("プロダクトキー")) = editプロダクトキー.Text
                Order By x("ソフトウェア名称")
            ' 関連付けてあるソフト以外のソフト一覧を取得しソフト名でソート
            Dim seq上記以外 =
                From x In vseq.Except(seq関連付済)
                Order By x("ソフトウェア名称")
            ' 上記2つを連結してペアシーケンスを生成
            Dim seqAll =
                From x In seq関連付済.Concat(seq上記以外)
                Select New CbxItem(x("ソフトウェアID"), x("ソフトウェア名称"))

            chklsbソフト情報.Items.AddRange(seqAll.Distinct.ToArray)
            ' 関連付けてあるソフトをチェックして、チェック順にソートする
            ' 関連付け済みのソフト一覧を取得する
            For i = 0 To seq関連付済.Count - 1
                chklsbソフト情報.SetItemChecked(i, True)
            Next
        End If
        ' 件数を更新
        lblソフト件数.Text = chklsbソフト情報.Items.Count & "件"
    End Sub

    Private Sub btnAll_Click(sender As Object, e As EventArgs) Handles btnAll.Click, btnElse.Click,
        btnA.Click, btnB.Click, btnC.Click, btnD.Click, btnE.Click, btnF.Click,
        btnG.Click, btnH.Click, btnI.Click, btnJ.Click, btnK.Click, btnL.Click,
        btnM.Click, btnN.Click, btnO.Click, btnP.Click, btnQ.Click, btnR.Click,
        btnS.Click, btnT.Click, btnU.Click, btnV.Click, btnW.Click, btnX.Click, btnY.Click, btnZ.Click
        '
        If m_dtbリストボックス Is Nothing Then
            Return
        End If

        If sender Is btnAll Then
            ' 全て
            ソフト一覧ListBoxデータ設定(m_dtbリストボックス.AsEnumerable)
        ElseIf sender Is btnElse Then
            ' A-Z以外
            ' ソフトウェア名称の頭文字がA~Z又はa~z以外のものをフィルタ
            Dim filterd =
                From x In m_dtbリストボックス
                Where Not System.Text.RegularExpressions.Regex.IsMatch(sNvl(x("ソフトウェア名称")).Trim, "^[a-zA-Z]")
            ソフト一覧ListBoxデータ設定(filterd)
        Else
            ' A-Z
            ' ソフトウェア名称の頭文字がボタンテキスト（A~Z）に一致するもののみフィルタ
            Dim filterd =
                From x In m_dtbリストボックス
                Where sNvl(x("ソフトウェア名称")).Trim.ToUpper.StartsWith(DirectCast(sender, Button).Text)
            ソフト一覧ListBoxデータ設定(filterd)
        End If
    End Sub

End Class