Imports System.Text

Public Class frm26_プロダクトキー登録v2

    Private SQL As New StringBuilder
    Private m_dtbComboBox As DataTable
    Private m_dtbDataSource As DataTable
    Private m_objPreItem権利者ID As Object

    Private Sub frm26_プロダクトキー_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' DataGridViewのセットアップを行う
        SetupDataGridViewProperties(dgvソフトウェア一覧)
        SetupDataGridViewProperties(dgvプロダクトキー一覧)
        SetupDataGridViewCellMerge(dgvソフトウェア一覧, dgvcメーカー)
        SetupDataGridViewCellMerge(dgvプロダクトキー一覧, dgvc権利者ID, dgvcサブスクリプション)
        '
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
        cbx認証タイプ.Items.AddRange(dtb.exGeneratePairArray("名称コード", "名称"))
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
        cbx利用者ID.Items.AddRange(dtb.exGeneratePairArray("社員ID", "社員名"))
        ' ComboBoxへ設定するための   
        m_dtbComboBox = GetComboBox用DTB()
        ' 
        ' 権利者を重複を除去して設定する
        cbx権利者ID.Items.AddRange(m_dtbComboBox.exGeneratePairArray("権利者ID", "社員名"))
        '
        グリッド表示()
    End Sub

    Private Sub cbx権利者ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbx権利者ID.SelectedIndexChanged
        ' このイベントは同じ項目クリック（選択）でも、
        ' つまりSelectedIndexがChangeしてなくても何故か呼ばれるので、無駄な処理を回避するための処理
        ' 前のアイテムを更新
        If dgvソフトウェア一覧.CurrentRow Is Nothing Then
            cbxサブスクリプションID.Enabled = False
            cbxサブスクリプションID.SelectedIndex = -1
            Return
        End If

        Dim str権利者 = If(cbx権利者ID.SelectedIndex < 0, "", DirectCast(cbx権利者ID.SelectedItem, CbxItem).L)
        Dim strメーカーID As String = dgvソフトウェア一覧.CurrentRow.Cells(2).Value
        Dim strサブスクリプションID As String = Nothing

        ' プロダクトキー一覧に表示データが存在する場合、そのデータからサブスクプションIDを取得する
        If Not rbt登録.Checked AndAlso dgvプロダクトキー一覧.CurrentRow IsNot Nothing Then
            ' 登録モード以外 → プロダクトキー一覧が少なくとも一件は存在するのでそのデータを利用する
            Dim dtb = DirectCast(dgvプロダクトキー一覧.DataSource, DataTable)

            If dgvプロダクトキー一覧.CurrentRow.Index < dtb.Rows.Count Then
                Dim drw As DataRow = dtb(dgvプロダクトキー一覧.CurrentRow.Index)
                ' 権利者IDが同一の場合、自動更新とみなして、サブスクリプションIDをグリッド上から取得する
                ' グリッドの権利者と コンボボックスの権利者IDが異なる → 手動変更
                ' 自動変更の場合は、必ず選択グリッドの権利者と同一になる
                If str権利者 = drw("権利者ID") Then
                    'strメーカーID = drw("メーカーID")
                    'str権利者 = drw("権利者ID")
                    strサブスクリプションID = If(IsDBNull(drw("サブスクリプションID")), gs名称("代替文字列")("02"), drw("サブスクリプションID"))
                End If
            End If
        End If

        ' 下位レベルのコンボボックスの依存設定を行う
        cbxサブスクリプション選択値設定(str権利者, strメーカーID, strサブスクリプションID)
    End Sub

    Private Sub cbxサブスクリプション選択値設定(ByVal s権利者ID As String, ByVal sメーカーID As String, Optional ByVal sサブスクリプションID As String = Nothing)

        If Not rbt削除.Checked Then
            ' 権利者が未選択ならコンボボックスが無効になる ※ただ削除モードの時は、ラジオボタンイベントで一括処理している
            If cbx権利者ID.SelectedIndex < 0 Then
                cbxサブスクリプションID.Enabled = False
                cbxサブスクリプションID.SelectedIndex = -1
                Return
            Else
                cbxサブスクリプションID.Enabled = True
            End If
        End If

        ' 事前に取得したコンボボックス用のDataTableから指定の権利者・メーカーに一致するサブスクリプションIDリストを抽出する
        Dim seqサブスクリプション =
            (From x In m_dtbComboBox
             Where sNvl(x("権利者ID")) = s権利者ID AndAlso sNvl(x("メーカーID")) = sメーカーID
             Select sNvl(x("サブスクリプションID"))).Distinct.ToArray
        ' 取得したアイテムを設定する　※Clearしてるので SelectedIndex=-1 になっている
        cbxサブスクリプションID.Items.Clear()
        cbxサブスクリプションID.Items.AddRange(seqサブスクリプション)

        ' 自動選択させる
        If cbxサブスクリプションID.Items.Count = 1 Then
            ' 要素が１つだけの場合ははじめからソレを選択させる
            cbxサブスクリプションID.SelectedIndex = 0
        ElseIf Not rbt登録.Checked AndAlso sサブスクリプションID IsNot Nothing Then
            '登録モード以外 AND サブスクリプションIDが指定されている時は選択設定する
            Dim seq対象サブ = seqサブスクリプション.Where(Function(x) x = sサブスクリプションID)
            If seq対象サブ.Count > 0 Then
                cbxサブスクリプションID.SelectedItem = seq対象サブ.First
            End If
        End If
    End Sub

    ' ２回呼ばれるということか・・・
    Private Sub dgvソフトウェア一覧_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvソフトウェア一覧.RowEnter
        ' 重複呼出防止
        If dgvソフトウェア一覧.CurrentRow IsNot Nothing AndAlso dgvソフトウェア一覧.CurrentRow.Index = e.RowIndex Then
            Return
        End If
        '
        Dim strメーカーID As String = dgvソフトウェア一覧.Rows(e.RowIndex).Cells(2).Value
        Dim strメーカー名称 As String = dgvソフトウェア一覧.Rows(e.RowIndex).Cells(0).Value
        Dim strソフトウェアID As String = dgvソフトウェア一覧.Rows(e.RowIndex).Cells(3).Value
        Dim seq選択中詳細 =
            From
                r In m_dtbDataSource
            Where
                r("メーカーID") = strメーカーID AndAlso
                r("ソフトウェアID") = strソフトウェアID AndAlso
                Not IsDBNull(r("サブスクリプション連番"))
            Order By r("権利者ID"), r("サブスクリプションID"), r("プロダクトキー")
        '
        RemoveHandler dgvプロダクトキー一覧.RowEnter, AddressOf dgvプロダクトキー一覧_RowEnter
        ' DataTableをコピーして設定 ※DataRowの内容は元と同じ
        dgvプロダクトキー一覧.DataSource = If(seq選択中詳細.Count = 0, Nothing, seq選択中詳細.CopyToDataTable)
        AddHandler dgvプロダクトキー一覧.RowEnter, AddressOf dgvプロダクトキー一覧_RowEnter

        ' メーカー表示を更新する
        editメーカー.Text = strメーカーID & gs名称("分割文字")("01") & strメーカー名称

        ' 選択中のソフトウェアメーカーのサブスクリプション情報を持つ権利者のみをコンボボックスに設定
        ' 実験の結果、ClearやAddRange操作でSelectedIndexChangedは反応しないことを確認済
        Dim seqメーカー抽出 = From x In m_dtbComboBox Where x("メーカーID") = strメーカーID
        cbx権利者ID.Items.Clear()
        cbx権利者ID.Items.AddRange(seqメーカー抽出.exGeneratePairArray("権利者ID", "社員名"))

        ' もし選択中のメーカーのサブスクリプションがなければ、登録不可能なので登録ボタンも無効にする
        Dim flg権利者有り As Boolean = cbx権利者ID.Items.Count > 0

        If cbx権利者ID.Items.Count = 0 Then
            rbt登録.Enabled = False
            btn更新.Enabled = False
            cbx権利者ID.Enabled = False
            cbxサブスクリプションID.Enabled = False
            lbl登録不可.Visible = True
        Else
            rbt登録.Enabled = True
            btn更新.Enabled = True
            cbx権利者ID.Enabled = True AndAlso Not rbt削除.Checked
            cbxサブスクリプションID.Enabled = cbx権利者ID.Enabled AndAlso cbx権利者ID.SelectedIndex <> -1
            lbl登録不可.Visible = False
        End If

        ' ソフトウェアに関連付けられているプロダクトキーがなければ、編集・削除モードを無効にする
        If seq選択中詳細.Count = 0 Then
            rbt更新.Enabled = False
            rbt削除.Enabled = False
            rbt登録.Checked = True ' イベントによる詳細項目の更新
        Else
            rbt更新.Enabled = True
            rbt削除.Enabled = True
            詳細項目更新() ' 手動更新
        End If
        ' ラベル更新
        lblプロダクトキー数.Text = dgvプロダクトキー一覧.RowCount & "件"
    End Sub


    Private Sub dgvプロダクトキー一覧_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvプロダクトキー一覧.RowEnter
        ' RowEnterイベントは特に最初のとき、２回発生するので、抑える処理
        ' 正常ならば、 e.RowIndex=変更先インデックス、 CurrentRow.Index=変更元インデックス というように
        ' 取得インデックスに遅延が発生し、値が異なるはずなので、同値ならば重複呼出とみなしリターン
        If dgvプロダクトキー一覧.CurrentRow IsNot Nothing AndAlso
           dgvプロダクトキー一覧.CurrentRow.Index = e.RowIndex Then
            Return
        End If

        詳細項目更新(e.RowIndex)
        '
        Dim dtb As DataTable = DirectCast(dgvプロダクトキー一覧.DataSource, DataTable)
        If dtb.Rows.Count = 0 Then
            Return
        End If
        Dim str権利者 As String = dtb(e.RowIndex)("権利者ID")
        Dim strメーカーID As String = dtb(e.RowIndex)("メーカーID")
        Dim strサブスクリプションID As String = dtb(e.RowIndex)("サブスクリプションID")
        cbxサブスクリプション選択値設定(str権利者, strメーカーID, strサブスクリプションID)
    End Sub

    Private Sub btn更新_Click(sender As Object, e As EventArgs) Handles btn更新.Click
        '
        If Not 入力チェック() Then
            Return
        End If
        '
        Dim dtbPdtKey As DataTable = DirectCast(dgvプロダクトキー一覧.DataSource, DataTable)
        Dim preMode As RadioButton = Nothing
        Dim int行壱, int行弐 As Integer
        Dim strNewソフトウェアID As String = dgvソフトウェア一覧.CurrentRow.Cells(3).Value
        Dim strNewサブスクリプション連番 As String = Getサブスクリプション連番()
        Dim strNewプロダクトキー As String = editプロダクトキー.Text.Trim
        ' 現在選択している行のプロダクトキー一覧のDataRowを取得 ※キーにする更新前データ
        Dim drw選択中 As DataRow = dtbPdtKey(dgvプロダクトキー一覧.CurrentRow.Index)

        If rbt登録.Checked OrElse rbt更新.Checked Then
            ' ※ここで重複チェックを行い、もし重複していたら「更新モード」にする
            SQL.Length = 0
            SQL.AppendLine("SELECT")
            SQL.AppendLine("    COUNT(*)")
            SQL.AppendLine("FROM")
            SQL.AppendLine("    M13_プロダクトキー")
            SQL.AppendLine("WHERE")
            SQL.AppendLine("        ソフトウェアID = '" & strNewソフトウェアID & "'")
            SQL.AppendLine("    AND プロダクトキー = '" & strNewプロダクトキー & "'")
            SQL.AppendLine("    AND サブスクリプション連番 = " & strNewサブスクリプション連番 & "")

            ' 更新モード AND 選択中の行データと同じ場合は、重複チェックをスキップする
            If rbt更新.Checked AndAlso
               drw選択中("ソフトウェアID") = strNewソフトウェアID AndAlso
               drw選択中("プロダクトキー") = strNewプロダクトキー AndAlso
               drw選択中("サブスクリプション連番") = strNewサブスクリプション連番 Then
                Return
            End If
            '
            If GetValue(Of Integer)(SQL.ToString) > 0 Then
                ' すでにある者のサブスクリプションのプロダクトキーが何らかのソフトウェアに関連付けられているとき
                If rbt登録.Checked Then
                    MsgInfo("更新情報", "このプロダクトキー情報は既に他の製品に関連付けられています。更新モードに移行します。")
                    ' 選択させる
                    Dim rows =
                        From
                            r In dtbPdtKey
                        Where
                            r("プロダクトキー") = strNewプロダクトキー AndAlso
                            r("サブスクリプション連番") = strNewサブスクリプション連番 AndAlso
                            r("ソフトウェアID") = strNewソフトウェアID
                    'RemoveHandler dgvプロダクトキー一覧.RowEnter, AddressOf dgvソフトウェア一覧_RowEnter
                    dgvプロダクトキー一覧.CurrentCell = dgvプロダクトキー一覧(0, dtbPdtKey.Rows.IndexOf(rows.First))
                    'AddHandler dgvプロダクトキー一覧.RowEnter, AddressOf dgvソフトウェア一覧_RowEnter
                    rbt更新.Checked = True
                ElseIf rbt更新.Checked Then
                    MsgInfo("更新情報", "このプロダクトキー情報は既に他の製品に関連付けられています。")
                End If
                ' リターン
                Return
            End If
        End If

        '
        If rbt登録.Checked Then
            preMode = rbt登録

            ' Insert処理
            SQL.Length = 0
            SQL.AppendLine("INSERT")
            SQL.AppendLine("INTO")
            SQL.AppendLine("    M13_プロダクトキー")
            SQL.AppendLine("VALUES")
            SQL.AppendLine("(")
            SQL.AppendLine("    '" & strNewソフトウェアID & "',")
            SQL.AppendLine("    '" & strNewプロダクトキー & "',")
            SQL.AppendLine("    " & strNewサブスクリプション連番 & ",")
            SQL.AppendLine("    '" & DirectCast(cbx認証タイプ.SelectedItem, CbxItem).L & "',")
            SQL.AppendLine("    " & If(ndtp要求日.IsNull, "NULL", "'" & ndtp要求日.Value.Value.ToString("yyyy/MM/dd") & "'") & ",")
            SQL.AppendLine("    " & If(cbx利用者ID.SelectedIndex > 0, "'" & DirectCast(cbx利用者ID.SelectedItem, CbxItem).L & "'", "NULL") & ",")
            SQL.AppendLine("    GETDATE(),")
            SQL.AppendLine("    GETDATE(),")
            SQL.AppendLine("    0")
            SQL.AppendLine(");")
            ' 処理的には一度対象レコードの削除を試みてからインサート処理する
            ' これは、PK制約違反を防ぐためである。結果的に差分登録される。
        ElseIf rbt更新.Checked Then
            preMode = rbt更新
            ' 更新の場合 → 
            ' 一度対象の「プロダクトキー、サブスクリプション」のデータを全て消してから、指定のソフトウェアを全部登録する
            SQL.Length = 0
            SQL.AppendLine("UPDATE")
            SQL.AppendLine("    M13_プロダクトキー")
            SQL.AppendLine("SET")
            SQL.AppendLine("    プロダクトキー = '" & strNewプロダクトキー & "',")
            SQL.AppendLine("    サブスクリプション連番 = " & strNewサブスクリプション連番 & ",")
            SQL.AppendLine("    認証タイプ = '" & DirectCast(cbx認証タイプ.SelectedItem, CbxItem).L & "',")
            SQL.AppendLine("    要求日付 = " & If(ndtp要求日.IsNull, "NULL", "'" & ndtp要求日.Value.Value.ToString("yyyy/MM/dd") & "'") & ",")
            SQL.AppendLine("    利用者ID = " & If(cbx利用者ID.SelectedIndex > 0, "'" & DirectCast(cbx利用者ID.SelectedItem, CbxItem).L & "'", "NULL") & ",")
            SQL.AppendLine("    更新日時 = GETDATE()")
            SQL.AppendLine("WHERE")
            SQL.AppendLine("        ソフトウェアID = '" & drw選択中("ソフトウェアID") & "'")
            SQL.AppendLine("    AND プロダクトキー = '" & drw選択中("プロダクトキー") & "'")
            SQL.AppendLine("    AND サブスクリプション連番 = " & drw選択中("サブスクリプション連番") & ";")
        ElseIf rbt削除.Checked Then
            If MessageBox.Show("本当に削除してよろしいですか？", "削除確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.Cancel Then
                Return
            End If
            preMode = rbt削除
            SQL.Length = 0
            SQL.AppendLine("DELETE M13_プロダクトキー")
            SQL.AppendLine("WHERE")
            SQL.AppendLine("        ソフトウェアID = '" & strNewソフトウェアID & "'")
            SQL.AppendLine("    AND プロダクトキー = '" & strNewプロダクトキー & "'")
            SQL.AppendLine("    AND サブスクリプション連番 = " & strNewサブスクリプション連番 & ";")
            ' 削除後の行を設定（１つ上の行にする）
            int行壱 = dgvソフトウェア一覧.CurrentRow.Index
            int行弐 = dgvプロダクトキー一覧.CurrentRow.Index - 1
        End If
        ' 実行
        If Not ExecNonQuery(SQL.ToString, True) Then
            Return
        End If
        '
        MsgInfo("DB更新結果", "データベースの更新に成功しました。")
        ' ここでrbt登録　がチェックされる？
        グリッド表示()
        ' 新規登録の時は、追加したデータを修正モードにする
        If preMode IsNot rbt削除 Then
            'Dim xxx =
            '    From x In dgvソフトウェア一覧.Rows.Cast(Of DataGridViewRow)
            '    Where x.Cells(3).Value = strNewソフトウェアID
            'int行壱 = dgvソフトウェア一覧.Rows.IndexOf(xxx.First)

            For i = 0 To dgvソフトウェア一覧.Rows.Count - 1
                If dgvソフトウェア一覧(3, i).Value = strNewソフトウェアID Then
                    int行壱 = i
                    Exit For
                End If
            Next

            Dim seq選択中詳細 =
            From
                r In m_dtbDataSource
            Where
                r("ソフトウェアID") = strNewソフトウェアID AndAlso
                Not IsDBNull(r("サブスクリプション連番"))
            Order By r("権利者ID"), r("サブスクリプションID"), r("プロダクトキー")

            Dim 対象行 =
                From
                    x In seq選択中詳細
                Where
                    sNvl(x("サブスクリプション連番")) = strNewサブスクリプション連番 AndAlso
                    sNvl(x("プロダクトキー")) = strNewプロダクトキー

            int行弐 = If(対象行.Count = 0, -1, seq選択中詳細.ToList.IndexOf(対象行.First))
        End If
        ' 選択させる
        RemoveHandler dgvプロダクトキー一覧.RowEnter, AddressOf dgvプロダクトキー一覧_RowEnter
        dgvソフトウェア一覧.CurrentCell = dgvソフトウェア一覧(0, int行壱)
        If int行弐 >= 0 Then
            dgvプロダクトキー一覧.CurrentCell = dgvプロダクトキー一覧(0, int行弐)
        End If
        AddHandler dgvプロダクトキー一覧.RowEnter, AddressOf dgvプロダクトキー一覧_RowEnter

        If preMode Is rbt登録 Then
            rbt更新.Checked = True
            Return
        End If
        ' 項目情報を更新する
        詳細項目更新()
    End Sub

    Private Sub rbt共通_CheckedChanged(sender As Object, e As EventArgs) Handles rbt登録.CheckedChanged, rbt更新.CheckedChanged, rbt削除.CheckedChanged
        If sender Is rbt登録 AndAlso rbt登録.Checked Then
            SetupControls(SetupType.必須, cbx権利者ID, cbxサブスクリプションID, cbx認証タイプ)
            SetupControls(SetupType.通常, editプロダクトキー, ndtp要求日, cbx利用者ID)
            詳細項目更新()
        ElseIf sender Is rbt更新 AndAlso rbt更新.Checked Then
            SetupControls(SetupType.必須, cbx権利者ID, cbxサブスクリプションID, cbx認証タイプ)
            SetupControls(SetupType.通常, editプロダクトキー, ndtp要求日, cbx利用者ID)
            詳細項目更新()
        ElseIf sender Is rbt削除 AndAlso rbt削除.Checked Then
            SetupControls(SetupType.参照, editプロダクトキー, cbx権利者ID, cbxサブスクリプションID, ndtp要求日, cbx認証タイプ, cbx利用者ID)
            詳細項目更新()
        End If
    End Sub

    Private Sub btn終了_Click(sender As Object, e As EventArgs) Handles btn終了.Click
        Me.Close()
    End Sub

    Private Function 入力チェック() As Boolean
        ' 削除モードの時は無チェック
        If rbt削除.Checked Then
            Return True
        End If

        Dim caption As String = "入力チェック"

        If m_dtbDataSource.Rows.Count = 0 Then
            MsgWarn(caption, "操作できるデータが存在しません。")
            Return False
        End If
        '
        If cbx権利者ID.SelectedIndex < 0 Then
            MsgWarn(caption, "権利者を選択して下さい。")
            cbx権利者ID.Focus()
            Return False
        ElseIf cbxサブスクリプションID.SelectedIndex < 0 Then
            MsgWarn(caption, "サブスクリプションIDを選択して下さい。")
            cbxサブスクリプションID.Focus()
            Return False
        ElseIf cbx認証タイプ.SelectedIndex < 0 Then
            MsgWarn(caption, "認証タイプを選択して下さい。")
            cbx認証タイプ.Focus()
            Return False
        End If
        '
        Return True
    End Function

    Private Sub グリッド表示()
        SQL.Length = 0
        SQL.AppendLine("SELECT")
        SQL.AppendLine("    M12.ソフトウェアID,")
        SQL.AppendLine("    M12.メーカーID,")
        SQL.AppendLine("    M11.メーカー名称,")
        SQL.AppendLine("    M12.ソフトウェア名称,")
        SQL.AppendLine("    M13.プロダクトキー,")
        SQL.AppendLine("    M03.サブスクリプションID,")
        SQL.AppendLine("    M13.サブスクリプション連番,")
        SQL.AppendLine("    M03.権利者ID,") 'M02権利
        SQL.AppendLine("    M02権利.社員名 AS 権利者,")
        SQL.AppendLine("    M13.認証タイプ,")
        SQL.AppendLine("    M13.利用者ID,")
        SQL.AppendLine("    M13.要求日付,")
        SQL.AppendLine("    M12.ファイル名")
        SQL.AppendLine("FROM")
        SQL.AppendLine("    M12_ソフトウェア M12")
        SQL.AppendLine("    LEFT JOIN")
        SQL.AppendLine("    M13_プロダクトキー M13 ON")
        SQL.AppendLine("    M12.ソフトウェアID = M13.ソフトウェアID")
        SQL.AppendLine("    LEFT JOIN")
        SQL.AppendLine("    M11_メーカー M11 ON")
        SQL.AppendLine("    M12.メーカーID = M11.メーカーID")
        SQL.AppendLine("    LEFT JOIN")
        SQL.AppendLine("    M03_サブスクリプション M03 ON")
        SQL.AppendLine("    M13.サブスクリプション連番 = M03.サブスクリプション連番")
        SQL.AppendLine("    LEFT JOIN")
        SQL.AppendLine("    M02_社員 M02権利 ON")
        SQL.AppendLine("    M03.権利者ID = M02権利.社員ID")
        SQL.AppendLine("WHERE")
        SQL.AppendLine("    M12.削除区分 = 0")
        '
        m_dtbDataSource = GetDataTable(SQL.ToString)
        Dim seq重複除去 =
            From
                r In m_dtbDataSource
            Select ' 名称ではなくより正確にIDをKeyにして重複を除去する
                x = New With {
                Key .メーカーID = sNvl(r("メーカーID")),
                Key .ソフトウェアID = sNvl(r("ソフトウェアID")),
                    .メーカー名称 = sNvl(r("メーカー名称")),
                    .ソフトウェア名称 = sNvl(r("ソフトウェア名称"))
                }
            Order By x.メーカー名称, x.ソフトウェア名称 ' ソートは各名称順
        ' 不用意なイベント発生を防ぐため一旦外す
        ' 重複除去してデータを設定 ※DataSourceはToListでList化しないと表示できない
        'RemoveHandler dgvソフトウェア一覧.RowEnter, AddressOf dgvソフトウェア一覧_RowEnter
        dgvソフトウェア一覧.DataSource = seq重複除去.Distinct.ToList
        'AddHandler dgvソフトウェア一覧.RowEnter, AddressOf dgvソフトウェア一覧_RowEnter
    End Sub

    Private Sub 詳細項目更新(Optional ByVal vintrow As Integer? = Nothing)
        RemoveHandler cbx権利者ID.SelectedIndexChanged, AddressOf cbx権利者ID_SelectedIndexChanged
        '
        If rbt登録.Checked OrElse dgvプロダクトキー一覧.Rows.Count = 0 Then
            editプロダクトキー.Text = ""
            cbx権利者ID.SelectedIndex = -1
            cbx認証タイプ.SelectedIndex = -1
            cbx利用者ID.SelectedIndex = If(cbx利用者ID.Items.Count > 0, 0, -1)
            ndtp要求日.Value = Nothing
        Else
            ' 修正 or 削除 モード
            ' 行数がパラメータによって指定されていればそっちを優先して使う
            Dim int行番 As Integer = If(vintrow Is Nothing, dgvプロダクトキー一覧.CurrentRow.Index, vintrow)
            Dim drw As DataRow = DirectCast(dgvプロダクトキー一覧.DataSource, DataTable)(int行番)
            '
            ' サブスクリプションIDがDBNullならば不要とみなしてチェック入れる
            editプロダクトキー.Text = sNvl(drw("プロダクトキー"))
            '
            cbx権利者ID.SelectedItem = cbx権利者ID.Items.Cast(Of CbxItem).Where(Function(x) x.L = sNvl(drw("権利者ID"))).First
            ' 一時保存
            cbx認証タイプ.SelectedItem = cbx認証タイプ.Items.Cast(Of CbxItem).Where(Function(x) x.L = sNvl(drw("認証タイプ"))).First
            ' もし利用者IDがなければコンボボックスを未選択にする
            If IsDBNull(drw("利用者ID")) Then
                cbx利用者ID.SelectedIndex = 0
            Else
                ' 対象の利用者IDのコンボボックスアイテムを取得する
                Dim selected =
                    From x In cbx利用者ID.Items.Cast(Of Object)
                    Where TypeOf x Is CbxItem ' <未指定>=Stringなので　StringPairだけを抽出
                    Select y = DirectCast(x, CbxItem)
                    Where y.L = drw("利用者ID")
                cbx利用者ID.SelectedItem = selected.First
            End If
            ndtp要求日.Value = dNvl(drw("要求日付"))
        End If
        '
        AddHandler cbx権利者ID.SelectedIndexChanged, AddressOf cbx権利者ID_SelectedIndexChanged
        ' 
        ' 同じIndexの場合はイベントが反応しないので強制的に呼ぶ
        Call cbx権利者ID_SelectedIndexChanged(cbx権利者ID, Nothing)
    End Sub

    Private Function GetComboBox用DTB() As DataTable
        ' ComboBoxの準備   
        SQL.Length = 0
        SQL.AppendLine("SELECT")
        SQL.AppendLine("    M03.サブスクリプション連番,")
        SQL.AppendLine("    M03.権利者ID,")
        SQL.AppendLine("    M02.社員名,")
        SQL.AppendLine("    M03.メーカーID,")
        SQL.AppendLine("    M11.メーカー名称,")
        SQL.AppendLine("    CASE")
        SQL.AppendLine("    WHEN M03.サブスクリプション連番 IS NOT NULL AND M03.サブスクリプションID IS NULL THEN '" & gs名称("代替文字列")("02") & "'")
        SQL.AppendLine("    ELSE M03.サブスクリプションID")
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

    Private Sub btnAll_Click(sender As Object, e As EventArgs) Handles btnAll.Click, btnElse.Click,
        btnA.Click, btnB.Click, btnC.Click, btnD.Click, btnE.Click, btnF.Click,
        btnG.Click, btnH.Click, btnI.Click, btnJ.Click, btnK.Click, btnL.Click,
        btnM.Click, btnN.Click, btnO.Click, btnP.Click, btnQ.Click, btnR.Click,
        btnS.Click, btnT.Click, btnU.Click, btnV.Click, btnW.Click, btnX.Click, btnY.Click, btnZ.Click
        '
        If m_dtbDataSource Is Nothing Then
            Return
        End If

        Dim filtered As IEnumerable(Of DataRow)

        If sender Is btnAll Then
            ' 全て ※そのまま設定
            filtered = m_dtbDataSource.AsEnumerable

        ElseIf sender Is btnElse Then
            ' A-Z以外
            ' ソフトウェア名称の頭文字がA~Z又はa~z以外のものをフィルタ
            filtered =
                From
                    r In m_dtbDataSource
                Where
                    Not System.Text.RegularExpressions.Regex.IsMatch(sNvl(r("ソフトウェア名称")).Trim, "^[a-zA-Z]")
        Else
            ' A-Z
            ' ソフトウェア名称の頭文字がボタンテキスト（A~Z）に一致するもののみフィルタ
            filtered =
                From
                    r In m_dtbDataSource
                Where
                    sNvl(r("ソフトウェア名称")).Trim.ToUpper.StartsWith(DirectCast(sender, Button).Text)
        End If

        ' 重複除去するために匿名型にしてソートする
        Dim selected As IEnumerable(Of Object) =
            From r In filtered
            Select x = New With {
                    Key .メーカーID = sNvl(r("メーカーID")),
                    Key .ソフトウェアID = sNvl(r("ソフトウェアID")),
                        .メーカー名称 = sNvl(r("メーカー名称")),
                        .ソフトウェア名称 = sNvl(r("ソフトウェア名称"))
                    }
            Order By x.メーカー名称, x.ソフトウェア名称 ' ソートは各名称順

        selected = selected.Distinct

        If selected.Count = 0 Then
            rbt登録.Enabled = False
            rbt更新.Enabled = False
            rbt削除.Enabled = False
            btn更新.Enabled = False
            dgvプロダクトキー一覧.DataSource = Nothing
            dgvソフトウェア一覧.DataSource = Nothing
            詳細項目更新()
        Else
            rbt登録.Enabled = True
            rbt更新.Enabled = True
            rbt削除.Enabled = True
            btn更新.Enabled = True
            dgvソフトウェア一覧.DataSource = selected.ToList
        End If


    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns>サブスクリプション連番を取得する情報が整っていなければNothing</returns>
    Private Function Getサブスクリプション連番() As String

        If cbx権利者ID.SelectedIndex < 0 OrElse
           cbxサブスクリプションID.SelectedIndex < 0 OrElse
           dgvソフトウェア一覧.CurrentRow Is Nothing Then
            Return Nothing
        End If

        Dim s権利者ID As String = DirectCast(cbx権利者ID.SelectedItem, CbxItem).L
        Dim sメーカーID As String = dgvソフトウェア一覧(2, dgvソフトウェア一覧.CurrentRow.Index).Value
        Dim sサブスクリプションID As String = cbxサブスクリプションID.SelectedItem

        Dim seq連番 =
            From
                r In m_dtbComboBox
            Where
                r("権利者ID") = s権利者ID AndAlso r("メーカーID") = sメーカーID AndAlso r("サブスクリプションID") = sサブスクリプションID
            Select
                r("サブスクリプション連番")
        Return If(seq連番.Count = 0, Nothing, sNvl(seq連番.First))
    End Function

End Class