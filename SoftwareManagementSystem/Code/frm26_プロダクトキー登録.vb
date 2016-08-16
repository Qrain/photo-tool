Imports System.Text


Public Class frm26_プロダクトキー登録

    Private SQL As New StringBuilder
    Private m_dtbComboBox As DataTable
    Private m_dtbDataSource As DataTable
    Private m_intDGV1CurrentRowIndex As Integer = 0
    Private m_intDGV2CurrentRowIndex As Integer = 0

    Private Sub frm26_プロダクトキー_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' DataGridViewのセットアップを行う
        SetupDataGridViewProperties(dgvソフトウェア)
        SetupDataGridViewProperties(dgvプロダクトキー)
        SetupDataGridViewCellMerge(dgvソフトウェア, dgvcメーカー)
        SetupDataGridViewCellMerge(dgvプロダクトキー, dgvc権利者ID, dgvcサブスクリプション)
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
        表示_dgvソフトウェア()
        表示_dgvプロダクトキー()
        各項目更新及び設定()
        コントロール有効設定()
    End Sub

    Private Sub cbx権利者ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbx権利者ID.SelectedIndexChanged

        If dgvソフトウェア.Rows.Count = 0 OrElse
           cbx権利者ID.SelectedIndex < 0 Then
            Return
        End If
        ' 各項目を取得する
        Dim str権利者 As String = DirectCast(cbx権利者ID.SelectedItem, CbxItem).L
        Dim strメーカーID As String = dgvソフトウェア(2, m_intDGV1CurrentRowIndex).Value

        ' 下位レベルのコンボボックスの依存設定を行う
        If Not rbt削除.Checked Then
            ' 削除モードの時は、ラジオボタンイベントで一括処理している
            cbxサブスクリプションID.Enabled = True
        End If

        ' 事前に取得したコンボボックス用のDataTableから指定の権利者・メーカーに一致するサブスクリプションIDリストを抽出する
        Dim seqサブスクリプション =
            (From x In m_dtbComboBox
             Where sNvl(x("権利者ID")) = str権利者 AndAlso sNvl(x("メーカーID")) = strメーカーID
             Select sNvl(x("サブスクリプションID"))).Distinct.ToArray

        ' 取得したアイテムを設定する　※Clearしてるので SelectedIndex → -1 になっている
        cbxサブスクリプションID.Items.Clear()
        cbxサブスクリプションID.Items.AddRange(seqサブスクリプション)

        ' プロダクトキー一覧に表示データが存在する場合、そのデータからサブスクプションIDを取得する
        If Not rbt登録.Checked AndAlso dgvプロダクトキー.Rows.Count > 0 Then
            ' 登録モード以外 → プロダクトキー一覧が少なくとも一件は存在するのでそのデータを利用する
            Dim drw As DataRow = DirectCast(dgvプロダクトキー.DataSource, DataTable)(m_intDGV2CurrentRowIndex)
            ' 権利者IDが同一のときは自動更新とみなし、サブスクリプションIDをグリッド上から取得する
            ' 逆に、グリッドの権利者とコンボボックスの権利者IDが異なるときは手動変更とみなし、Nothingのまま
            If drw IsNot Nothing AndAlso str権利者 = drw("権利者ID") Then
                ' 自動選択してリターン
                Dim seq対象サブ = seqサブスクリプション.Where(Function(x) x = sNvl(drw("サブスクリプションID")))
                ' 対象サブスクリプションが見つからない場合は、Nothing設定
                cbxサブスクリプションID.SelectedItem = If(seq対象サブ.Count = 0, Nothing, seq対象サブ.First)
                Return
            End If
        End If

        ' 要素が１つだけ、かつ未選択状態なら場合は勝手にソレを選択する
        If cbxサブスクリプションID.Items.Count = 1 AndAlso cbxサブスクリプションID.SelectedIndex = -1 Then
            cbxサブスクリプションID.SelectedIndex = 0
        End If

    End Sub

    Private Sub dgvソフトウェア一覧_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvソフトウェア.RowEnter
        ' 普通、一覧データが０件の状態でRowEnterイベントは呼ばれないが、検索結果表示などで
        ' 強制的に呼び出した場合には以下の条件を通る
        If dgvソフトウェア.Rows.Count = 0 Then
            ' プロダクトキー一覧は空状態になる
            表示_dgvプロダクトキー()
        Else
            ' 行インデックスを更新と初期化　※表示_dgvプロダクトキー処理で使われるので先に初期化必要
            m_intDGV1CurrentRowIndex = e.RowIndex
            m_intDGV2CurrentRowIndex = 0
            ' メーカーとソフトウェアを指定して呼出
            Dim strメーカーID As String = dgvソフトウェア.Rows(e.RowIndex).Cells(2).Value
            Dim strソフトウェアID As String = dgvソフトウェア.Rows(e.RowIndex).Cells(3).Value
            表示_dgvプロダクトキー(strメーカーID, strソフトウェアID)
        End If
    End Sub

    Private Sub dgvプロダクトキー一覧_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvプロダクトキー.RowEnter
        ' 選択行を更新
        m_intDGV2CurrentRowIndex = If(e Is Nothing, 0, e.RowIndex)
        ' 表示更新
        各項目更新及び設定()
        ' ロック状態更新
        コントロール有効設定()
    End Sub

    Private Sub rbt共通_CheckedChanged(sender As Object, e As EventArgs) Handles rbt登録.CheckedChanged, rbt更新.CheckedChanged, rbt削除.CheckedChanged
        ' CheckedChangedは各ボタンから１回づつ計２回呼ばれてしまうので、Trueのもの１度だけ通す条件
        If sender Is rbt登録 AndAlso rbt登録.Checked OrElse
           sender Is rbt更新 AndAlso rbt更新.Checked OrElse
           sender Is rbt削除 AndAlso rbt削除.Checked Then

            If rbt登録.Checked OrElse rbt更新.Checked Then
                SetupControls(SetupType.必須, cbx権利者ID, cbxサブスクリプションID, cbx認証タイプ)
                SetupControls(SetupType.通常, editプロダクトキー, ndtp要求日, cbx利用者ID)
            ElseIf rbt削除.Checked Then
                SetupControls(SetupType.参照, editプロダクトキー, cbx権利者ID, cbxサブスクリプションID, ndtp要求日, cbx認証タイプ, cbx利用者ID)
            End If
            ' 項目情報を更新
            各項目更新及び設定()
            コントロール有効設定()
        End If
    End Sub

    Private Sub btn更新_Click(sender As Object, e As EventArgs) Handles btn更新.Click
        '
        If Not 入力チェック() Then
            Return
        End If
        '
        Dim preMode As RadioButton = Nothing
        Dim int行壱, int行弐 As Integer
        Dim dtbプロダクトキー As DataTable = DirectCast(dgvプロダクトキー.DataSource, DataTable)
        ' 現在選択している行のプロダクトキー一覧のDataRowを取得 ※キーにする更新前データ
        Dim drw選択中 As DataRow = If(dtbプロダクトキー Is Nothing, Nothing, dtbプロダクトキー(m_intDGV2CurrentRowIndex))
        Dim strメーカーID As String = dgvソフトウェア.CurrentRow.Cells(2).Value
        Dim strソフトウェアID As String = dgvソフトウェア.CurrentRow.Cells(3).Value
        Dim strプロダクトキー As String = editプロダクトキー.Text.Trim
        Dim strサブスクリプション連番 As String = Getサブスクリプション連番()

        If strサブスクリプション連番 Is Nothing Then
            MsgWarn("警告", "サブスクリプション連番を取得できなかったため更新処理を継続できませんでした。")
            Return
        End If

        ' 重複チェックを行い、もし重複していたら「更新モード」にする
        If drw選択中 IsNot Nothing AndAlso (rbt登録.Checked OrElse rbt更新.Checked) Then
            SQL.Length = 0
            SQL.AppendLine("SELECT")
            SQL.AppendLine("    COUNT(*)")
            SQL.AppendLine("FROM")
            SQL.AppendLine("    M13_プロダクトキー")
            SQL.AppendLine("WHERE")
            SQL.AppendLine("        ソフトウェアID = '" & strソフトウェアID & "'")
            SQL.AppendLine("    AND プロダクトキー = '" & strプロダクトキー & "'")
            SQL.AppendLine("    AND サブスクリプション連番 = " & strサブスクリプション連番 & "")

            ' 更新モード AND 選択中の行データと同じ場合は、重複チェックをスキップする
            If rbt登録.Checked OrElse
               drw選択中("ソフトウェアID") <> strソフトウェアID OrElse
               drw選択中("プロダクトキー") <> strプロダクトキー OrElse
               drw選択中("サブスクリプション連番") <> strサブスクリプション連番 Then
                '
                If GetValue(Of Integer)(SQL.ToString) > 0 Then
                    ' すでにある者のサブスクリプションのプロダクトキーが何らかのソフトウェアに関連付けられているとき
                    If rbt登録.Checked Then
                        MsgInfo("更新情報", "このプロダクトキー情報は既に他の製品に関連付けられています。更新モードに移行します。")
                        ' 選択させる
                        Dim rows =
                        From
                            r In dtbプロダクトキー
                        Where
                            r("プロダクトキー") = strプロダクトキー AndAlso
                            r("サブスクリプション連番") = strサブスクリプション連番 AndAlso
                            r("ソフトウェアID") = strソフトウェアID
                        'RemoveHandler dgvプロダクトキー一覧.RowEnter, AddressOf dgvソフトウェア一覧_RowEnter
                        dgvプロダクトキー.CurrentCell = dgvプロダクトキー(0, dtbプロダクトキー.Rows.IndexOf(rows.First))
                        'AddHandler dgvプロダクトキー一覧.RowEnter, AddressOf dgvソフトウェア一覧_RowEnter
                        rbt更新.Checked = True
                    ElseIf rbt更新.Checked Then
                        MsgInfo("更新情報", "このプロダクトキー情報は既に他の製品に関連付けられています。")
                    End If
                    ' リターン
                    Return
                End If
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
            SQL.AppendLine("    '" & strソフトウェアID & "',")
            SQL.AppendLine("    '" & strプロダクトキー & "',")
            SQL.AppendLine("    " & strサブスクリプション連番 & ",")
            SQL.AppendLine("    '" & DirectCast(cbx認証タイプ.SelectedItem, CbxItem).L & "',")
            SQL.AppendLine("    " & If(ndtp要求日.IsNull, "NULL", "'" & ndtp要求日.Value.Value.ToString("yyyy/MM/dd") & "'") & ",")
            SQL.AppendLine("    " & If(cbx利用者ID.SelectedIndex > 0, "'" & DirectCast(cbx利用者ID.SelectedItem, CbxItem).L & "'", "NULL") & ",")
            SQL.AppendLine("    GETDATE(),")
            SQL.AppendLine("    GETDATE(),")
            SQL.AppendLine("    0")
            SQL.AppendLine(");")
        ElseIf rbt更新.Checked Then
            preMode = rbt更新
            SQL.Length = 0
            SQL.AppendLine("UPDATE")
            SQL.AppendLine("    M13_プロダクトキー")
            SQL.AppendLine("SET")
            SQL.AppendLine("    プロダクトキー = '" & strプロダクトキー & "',")
            SQL.AppendLine("    サブスクリプション連番 = " & strサブスクリプション連番 & ",")
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
            SQL.AppendLine("        ソフトウェアID = '" & strソフトウェアID & "'")
            SQL.AppendLine("    AND プロダクトキー = '" & strプロダクトキー & "'")
            SQL.AppendLine("    AND サブスクリプション連番 = " & strサブスクリプション連番 & ";")
            ' 削除後の行を設定（１つ上の行にする）
            int行壱 = dgvソフトウェア.CurrentRow.Index
            int行弐 = dgvプロダクトキー.CurrentRow.Index - 1
        End If
        ' 実行
        If Not ExecNonQuery(SQL.ToString, True) Then
            Return
        End If
        '
        MsgInfo("DB更新結果", "データベースの更新に成功しました。")
        ' ここでrbt登録　がチェックされる？
        表示_dgvソフトウェア()
        ' 選択させる
        表示_dgvプロダクトキー(strメーカーID, strソフトウェアID)
        ' コンボボックステーブルデータをリフレッシュ
        m_dtbComboBox = GetComboBox用DTB()
        ' 新規登録の時は、追加したデータを修正モードにする
        If preMode IsNot rbt削除 Then
            ' 初期化
            int行壱 = -1
            int行弐 = -1
            '
            For i = 0 To dgvソフトウェア.Rows.Count - 1
                If dgvソフトウェア(3, i).Value = strソフトウェアID Then
                    int行壱 = i
                    Exit For
                End If
            Next
            '
            If dgvプロダクトキー.DataSource IsNot Nothing Then
                Dim dtb = DirectCast(dgvプロダクトキー.DataSource, DataTable)
                For i = 0 To dtb.Rows.Count - 1
                    ' 1: サブスクリプションID, 2: プロダクトキー
                    If dtb(i)("サブスクリプション連番") = strサブスクリプション連番 AndAlso
                       dtb(i)("プロダクトキー") = strプロダクトキー Then
                        int行弐 = i
                        Exit For
                    End If
                Next
            End If
        End If
        ' 適切なグリッドの行を選択状態にする
        If int行壱 >= 0 Then
            RemoveHandler dgvソフトウェア.RowEnter, AddressOf dgvソフトウェア一覧_RowEnter
            dgvソフトウェア.CurrentCell = dgvソフトウェア(0, int行壱)
            AddHandler dgvソフトウェア.RowEnter, AddressOf dgvソフトウェア一覧_RowEnter
            m_intDGV1CurrentRowIndex = int行壱
        End If
        If int行弐 >= 0 Then
            RemoveHandler dgvプロダクトキー.RowEnter, AddressOf dgvプロダクトキー一覧_RowEnter
            dgvプロダクトキー.CurrentCell = dgvプロダクトキー(0, int行弐)
            AddHandler dgvプロダクトキー.RowEnter, AddressOf dgvプロダクトキー一覧_RowEnter
            m_intDGV2CurrentRowIndex = int行弐
        End If

        ' 項目情報を更新する ※登録モードなら更新モードに
        If preMode Is rbt登録 Then
            rbt更新.Checked = True
        Else
            各項目更新及び設定()
            コントロール有効設定()
        End If
    End Sub

    Private Sub btnAll_Click(sender As Object, e As EventArgs) Handles btnAll.Click, btnElse.Click, btnHasKey.Click, btnNonKey.Click,
        btnA.Click, btnB.Click, btnC.Click, btnD.Click, btnE.Click,
        btnF.Click, btnG.Click, btnH.Click, btnI.Click, btnJ.Click,
        btnK.Click, btnL.Click, btnM.Click, btnN.Click, btnO.Click,
        btnP.Click, btnQ.Click, btnR.Click, btnS.Click, btnT.Click,
        btnU.Click, btnV.Click, btnW.Click, btnX.Click, btnY.Click, btnZ.Click
        '
        If m_dtbDataSource Is Nothing Then
            Return
        End If

        Dim filtered As IEnumerable(Of DataRow)

        If sender Is btnAll Then
            ' 全て ※そのまま設定
            filtered = m_dtbDataSource.AsEnumerable
        ElseIf sender Is btnHasKey Then
            ' プロダクトキー登録済みのものだけ抽出
            filtered =
                From r In m_dtbDataSource
                Where Not IsDBNull(r("サブスクリプション連番"))

        ElseIf sender Is btnNonKey Then
            ' プロダクトキー無いものだけ抽出
            filtered =
                From r In m_dtbDataSource
                Where IsDBNull(r("サブスクリプション連番"))

        ElseIf sender Is btnElse Then
            ' A-Z以外
            ' ソフトウェア名称の頭文字がA~Z又はa~z以外のものをフィルタ
            filtered =
                From r In m_dtbDataSource
                Where Not RegularExpressions.Regex.IsMatch(sNvl(r("ソフトウェア名称")).Trim, "^[a-zA-Z]")
        Else
            ' A-Z
            ' ソフトウェア名称の頭文字がボタンテキスト（A~Z）に一致するもののみフィルタ
            filtered =
                From r In m_dtbDataSource
                Where sNvl(r("ソフトウェア名称")).Trim.ToUpper.StartsWith(DirectCast(sender, Button).Text)
        End If

        ' 重複除去するために匿名型にしてソートする
        Dim selected As List(Of Object) = Selectソフトウェア一覧データ(filtered)
        m_intDGV1CurrentRowIndex = 0
        m_intDGV2CurrentRowIndex = 0

        ' 検索結果をソフトウェア一覧に設定
        dgvソフトウェア.DataSource = selected

        ' ０件の場合、RowEnterイベントが呼ばれないので強制的に呼出
        If selected.Count = 0 Then
            Call dgvソフトウェア一覧_RowEnter(dgvソフトウェア, Nothing)
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

    ''' <summary>
    ''' 基本的に選択中のプロダクトキー一覧情報に基いて、各項目の値を設定します。
    ''' ただし次の場合は、各項目のデータをクリアします。
    ''' ・登録モードのとき
    ''' ・プロダクトキー一覧に表示行がないとき
    ''' </summary>
    Private Sub 各項目更新及び設定()

        ' ソフトウェアに関連付けられているプロダクトキーがなければ更新・削除モードを無効にする
        If dgvプロダクトキー.Rows.Count = 0 Then
            '
            rbt更新.Enabled = False
            rbt削除.Enabled = False
            If Not rbt登録.Checked Then
                ' RadioButtonイベント経由で再帰呼出
                rbt登録.Checked = True
                Return
            End If
        Else
            rbt更新.Enabled = True
            rbt削除.Enabled = True
        End If

        ' データをクリアする
        cbx権利者ID.Items.Clear()

        ' メーカー情報を項目に表示し、そのメーカーに関する権利者をコンボボックスに設定する処理
        If dgvソフトウェア.Rows.Count = 0 Then
            '初期化
            editメーカー.Text = ""
        Else

            Dim dgvr = dgvソフトウェア.Rows(m_intDGV1CurrentRowIndex)
            ' メーカーID : メーカー名称
            editメーカー.Text = dgvr.Cells(2).Value & gs名称("分割文字")("01") & dgvr.Cells(0).Value

            Dim seq権利者抽出byメーカー As IEnumerable(Of DataRow)
            ' 登録モードの場合は削除されていない権利者のみを抽出する
            ' 更新モードではあるが、現在の権利者が

            ' 更新又は削除モードで尚且つ現在選択されている権利者が論理削除されている場合は、
            ' 権利者コンボボックスに設定する権利者一覧にその削除されている権利者を含める
            ' 理由 → 更新及び削除モードのときは削除されていてもその権利者をコンボボックスに表示したいため
            If Not rbt登録.Checked AndAlso
               dgvプロダクトキー.Rows.Count > m_intDGV2CurrentRowIndex Then

                ' 現在のDataRoweを取得
                Dim drw = DirectCast(dgvプロダクトキー.DataSource, DataTable)(m_intDGV2CurrentRowIndex)

                If drw("状態") = gs名称("キー状態区分")("02") OrElse drw("状態") = gs名称("キー状態区分")("03") Then
                    '「02:メーカー不一致」の場合
                    ' 更新及び削除モードではメーカーが異なるので表示したくはないが、一応登録されている権利者を表示する
                    seq権利者抽出byメーカー =
                        From x In m_dtbComboBox
                        Where x("メーカーID") = dgvr.Cells(2).Value AndAlso x("権利者削除区分") = 0 OrElse x("権利者ID") = drw("権利者ID")
                ElseIf drw("状態") = gs名称("キー状態区分")("01") Then
                    ' 「01:権利者削除済」の場合
                    seq権利者抽出byメーカー =
                        From x In m_dtbComboBox
                        Where x("メーカーID") = dgvr.Cells(2).Value AndAlso x("権利者削除区分") = 0 OrElse x("権利者ID") = drw("権利者ID")
                Else
                    ' ※下と同条件な冗長記述
                    seq権利者抽出byメーカー =
                        From x In m_dtbComboBox
                        Where x("メーカーID") = dgvr.Cells(2).Value AndAlso x("権利者削除区分") = 0
                End If
            Else
                ' 上記以外は論理削除されていない権利者のみを抽出
                seq権利者抽出byメーカー =
                From x In m_dtbComboBox
                Where x("メーカーID") = dgvr.Cells(2).Value AndAlso x("権利者削除区分") = 0
            End If

            ' 選択中のソフトウェアメーカーのサブスクリプション情報を持つ権利者のみをコンボボックスに設定
            ' 実験の結果、ClearやAddRange操作でSelectedIndexChangedは反応しないことを確認済
            cbx権利者ID.Items.AddRange(seq権利者抽出byメーカー.exGeneratePairArray("権利者ID", "社員名"))
        End If

        ' プロダクトキー一覧データに依存する処理
        '
        ' 権利者コンボボックスの値に依存するサブスクリプションIDコンボボックスは別途イベント処理します
        If rbt登録.Checked OrElse dgvプロダクトキー.Rows.Count = 0 Then
            editプロダクトキー.Text = ""
            cbx権利者ID.SelectedIndex = -1
            ' 権利者イベント呼ばない代わりに手動設定
            cbxサブスクリプションID.SelectedIndex = -1
            cbxサブスクリプションID.Enabled = False
            cbx認証タイプ.SelectedIndex = -1
            cbx利用者ID.SelectedIndex = If(cbx利用者ID.Items.Count > 0, 0, -1)
            ndtp要求日.Value = Nothing
        Else
            ' プロダクトキー一覧に表示がある AND (修正モード OR 削除モード)
            ' 行数パラメータが指定されていればそれを優先して使う
            Dim drw As DataRow = DirectCast(dgvプロダクトキー.DataSource, DataTable)(m_intDGV2CurrentRowIndex)
            '
            ' サブスクリプションIDがDBNullならば不要とみなしてチェック入れる
            editプロダクトキー.Text = sNvl(drw("プロダクトキー"))
            '
            RemoveHandler cbx権利者ID.SelectedIndexChanged, AddressOf cbx権利者ID_SelectedIndexChanged
            cbx権利者ID.SelectedItem = GetComboBoxItem(cbx権利者ID, sNvl(drw("権利者ID")))
            AddHandler cbx権利者ID.SelectedIndexChanged, AddressOf cbx権利者ID_SelectedIndexChanged
            ' 登録モードの時は権利者未選択状態にするので呼ぶ必要な無い
            ' 同じIndexの場合はイベントが反応しないので強制的に呼ぶ
            cbx権利者ID_SelectedIndexChanged(cbx権利者ID, Nothing)

            ' 一時保存
            cbx認証タイプ.SelectedItem = GetComboBoxItem(cbx認証タイプ, sNvl(drw("認証タイプ")))
            ' もし利用者IDがなければコンボボックスを未選択にする
            If IsDBNull(drw("利用者ID")) Then
                cbx利用者ID.SelectedIndex = 0
            Else
                ' 対象の利用者IDのコンボボックスアイテムを取得する
                cbx利用者ID.SelectedItem = GetComboBoxItem(cbx利用者ID, drw("利用者ID"))
            End If
            ndtp要求日.Value = dNvl(drw("要求日付"))
        End If
    End Sub

    ''' <summary>
    ''' DBから取得したソフトウェア一覧情報をグリッドに表示します。
    ''' この処理ではRowEnterイベントを呼び出しません。
    ''' ベースとなるデータをDataTableとして取得しグローバル変数に格納します。
    ''' </summary>
    Private Sub 表示_dgvソフトウェア()
        SQL.Length = 0
        SQL.AppendLine("SELECT")
        SQL.AppendLine("    M12.ソフトウェアID,")
        SQL.AppendLine("    M12.メーカーID,")
        SQL.AppendLine("    M11.メーカー名称,")
        SQL.AppendLine("    M12.ソフトウェア名称,")
        SQL.AppendLine("    M13.プロダクトキー,")
        ' 連番 not null → サブスクリプション情報あり AND ID is null → ID不要
        ' ならば名称マスタの登録している置換文字列を使用する
        SQL.AppendLine("    CASE")
        SQL.AppendLine("    WHEN M03.サブスクリプション連番 IS NOT NULL AND M03.サブスクリプションID IS NULL THEN")
        SQL.AppendLine("        '" & gs名称("代替文字列")("02") & "'")
        SQL.AppendLine("    ELSE")
        SQL.AppendLine("        M03.サブスクリプションID")
        SQL.AppendLine("    END AS サブスクリプションID,")
        SQL.AppendLine("    M13.サブスクリプション連番,")
        SQL.AppendLine("    M03.権利者ID,") 'M02権利
        SQL.AppendLine("    M02.社員名 AS 権利者,")
        SQL.AppendLine("    M13.認証タイプ,")
        SQL.AppendLine("    M13.利用者ID,")
        SQL.AppendLine("    M13.要求日付,")
        SQL.AppendLine("    M12.ファイル名,")
        ' ソフトウェアメーカ変更や社員削除された場合のアラートメッセージ表示用のフラグ列
        SQL.AppendLine("    CASE")
        SQL.AppendLine("    WHEN M03.削除区分 = 1 THEN '" & gs名称("キー状態区分")("03") & "'")
        SQL.AppendLine("    WHEN M03.メーカーID <> M12.メーカーID THEN '" & gs名称("キー状態区分")("02") & "'")
        SQL.AppendLine("    WHEN M02.削除区分 = 1 THEN '" & gs名称("キー状態区分")("01") & "'")
        SQL.AppendLine("    WHEN M13.利用者ID is not NULL THEN '" & gs名称("キー状態区分")("04") & "'")
        SQL.AppendLine("    ELSE '" & gs名称("キー状態区分")("00") & "'") ' 未使用状態のプロダクトキー
        SQL.AppendLine("    END AS 状態")
        '
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
        SQL.AppendLine("    M02_社員 M02 ON")
        SQL.AppendLine("    M03.権利者ID = M02.社員ID")
        SQL.AppendLine("WHERE")
        SQL.AppendLine("    M12.削除区分 = 0")
        '
        m_dtbDataSource = GetDataTable(SQL.ToString)
        RemoveHandler dgvソフトウェア.RowEnter, AddressOf dgvソフトウェア一覧_RowEnter
        dgvソフトウェア.DataSource = Selectソフトウェア一覧データ(m_dtbDataSource.AsEnumerable)
        AddHandler dgvソフトウェア.RowEnter, AddressOf dgvソフトウェア一覧_RowEnter
        ' 行インデックスをリセット
        m_intDGV1CurrentRowIndex = 0
    End Sub

    ''' <summary>
    ''' DataTableから選択中のソフトウェアに関するプロダクトキー情報を抽出しててグリッドに表示します。
    ''' この処理は必ずRowEnterイベントを呼び出します。
    ''' </summary>
    Private Sub 表示_dgvプロダクトキー(Optional ByVal vstrメーカーID As String = Nothing, Optional ByVal vstrソフトウェアID As String = Nothing)
        ' ソフトウェア一覧に一件も表示されていなければグリッドをクリア
        If dgvソフトウェア.Rows.Count = 0 Then
            dgvプロダクトキー.DataSource = Nothing
        Else
            ' どちらか一方のパラメータがNothingならば、グリッドビューから取得を試みる
            If vstrメーカーID Is Nothing OrElse vstrソフトウェアID Is Nothing Then
                ' ※ただしRowEnterイベントからの呼出の場合は、正しい行インデックスが取得できないので注意
                vstrメーカーID = dgvソフトウェア.CurrentRow.Cells(2).Value
                vstrソフトウェアID = dgvソフトウェア.CurrentRow.Cells(3).Value
            End If
            '
            Dim seq選択中詳細 =
                From r In m_dtbDataSource
                Where r("メーカーID") = vstrメーカーID AndAlso r("ソフトウェアID") = vstrソフトウェアID AndAlso Not IsDBNull(r("サブスクリプション連番"))
                Order By r("権利者ID"), r("サブスクリプションID"), r("プロダクトキー")
            ' DataTableをコピーして設定 ※DataRowの内容は元と同じ
            RemoveHandler dgvプロダクトキー.RowEnter, AddressOf dgvプロダクトキー一覧_RowEnter
            dgvプロダクトキー.DataSource = If(seq選択中詳細.Count = 0, Nothing, seq選択中詳細.CopyToDataTable)
            AddHandler dgvプロダクトキー.RowEnter, AddressOf dgvプロダクトキー一覧_RowEnter
        End If

        ' イベント呼出
        Call dgvプロダクトキー一覧_RowEnter(dgvプロダクトキー, Nothing)
        ' ラベル更新
        lblプロダクトキー数.Text = dgvプロダクトキー.Rows.Count & "件"
    End Sub

    Private Sub コントロール有効設定()

        Dim drwプロダクトキー As DataRow = Nothing
        ' ソフトウェアメーカーと サブスクリプション連番のメーカー　が不整合の場合はラベルで通知

        ' DataRow取得できる条件が整ってれば、現在選択中のプロダクトキーグリッド上のDataRowを取得
        If dgvプロダクトキー.Rows.Count > m_intDGV2CurrentRowIndex Then
            drwプロダクトキー = DirectCast(dgvプロダクトキー.DataSource, DataTable)(m_intDGV2CurrentRowIndex)
        End If

        ' 次の場合は、削除や更新だけでなく登録操作もできないので、画面をロック状態にする
        ' 1. 選択中のソフトメーカーに関するサブスクリプション情報が１つも無い場合
        ' 2. ソフトウェア一覧に１件もソフト情報がない時
        If cbx権利者ID.Items.Count = 0 Then
            rbt登録.Enabled = False
            rbt更新.Enabled = False
            rbt削除.Enabled = False
            editプロダクトキー.Enabled = False
            editメーカー.Enabled = False
            cbx権利者ID.Enabled = False
            cbx利用者ID.Enabled = False
            cbx認証タイプ.Enabled = False
            ndtp要求日.Enabled = False
            btn更新.Enabled = False

            ' 権利者が設定されていないのにプロダクトキー情報があるということは、
            ' データの整合性に問題がある場合のみ考えられる

            ' ソフトウェアとサブスクリプション情報はあるが、互いのメーカーが一致していない場合
            If drwプロダクトキー IsNot Nothing AndAlso (
               drwプロダクトキー("状態") = gs名称("キー状態区分")("01") OrElse
               drwプロダクトキー("状態") = gs名称("キー状態区分")("02") OrElse
               drwプロダクトキー("状態") = gs名称("キー状態区分")("03")) Then
                ' サブスクリプション情報はあるものの、その権利者が論理削除されている場合
                ' この時点で登録モードならば、更新モードにする処理、　またその後登録モードにしても弾き返す処理
                ' 更新及び削除モードは許可する
                rbt削除.Enabled = True
                btn更新.Enabled = True
                '
                If Not rbt削除.Checked Then
                    'If drwプロダクトキー("状態") = gs名称("キー状態区分")("01") Then
                    '    MsgBox("プロダクトキー情報はありますが、関連付けられている権利者IDは論理削除されているため登録モードは使用できません。")
                    'ElseIf drwプロダクトキー("状態") = gs名称("キー状態区分")("02") Then
                    '    MsgBox("プロダクトキー情報はありますが、関連付けられているソフトウェアとサブスクリプションのメーカーが一致しないため登録モードは使用できません。")
                    'End If
                    ' 登録モードは不可能なので自動的に更新モードに変更する
                    rbt削除.Checked = True
                End If
            End If
        Else
            ' 権利者がいないということはプロダクトキー一覧も０件であるはずなので、
            ' 詳細項目更新で自動的に「登録モード」になっている

            ' True条件 → 正常レコード　又は 権利者2件以上（2以上なら必ず1つは正常あるため）
            Dim flg登録更新有効条件 As Boolean = True

            If drwプロダクトキー IsNot Nothing Then
                flg登録更新有効条件 =
                    sNvl(drwプロダクトキー("状態")) = gs名称("キー状態区分")("00") OrElse
                    cbx権利者ID.Items.Count > 1 OrElse
                    rbt登録.Checked
            End If

            rbt登録.Enabled = flg登録更新有効条件
            rbt更新.Enabled = dgvプロダクトキー.Rows.Count > 0 AndAlso flg登録更新有効条件 ' 条件付きでTrueに設定
            rbt削除.Enabled = dgvプロダクトキー.Rows.Count > 0
            editプロダクトキー.Enabled = Not rbt削除.Checked
            editメーカー.Enabled = Not rbt削除.Checked
            cbx権利者ID.Enabled = Not rbt削除.Checked
            cbx利用者ID.Enabled = Not rbt削除.Checked
            cbx認証タイプ.Enabled = Not rbt削除.Checked
            ndtp要求日.Enabled = Not rbt削除.Checked
            btn更新.Enabled = True

            ' ソフトウェアメーカーと サブスクリプション連番のメーカー　が不整合の場合はラベルで通知
            ' 更新モードで尚且つ、プロダクトキーが正常では無く、権利者が1人だけの場合は、更新を向こうにして削除モードのみ許容
            If rbt更新.Checked AndAlso Not flg登録更新有効条件 Then
                rbt削除.Checked = True
            End If

        End If
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
        SQL.AppendLine("    WHEN M03.サブスクリプションID IS NULL THEN")
        SQL.AppendLine("        '" & gs名称("代替文字列")("02") & "'")
        SQL.AppendLine("    ELSE")
        SQL.AppendLine("        M03.サブスクリプションID")
        SQL.AppendLine("    END AS サブスクリプションID,")
        SQL.AppendLine("    M02.削除区分 AS 権利者削除区分")
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

    Private Function Getサブスクリプション連番() As String
        If rbt登録.Checked OrElse rbt更新.Checked Then
            ' 登録モードの時はコンボボックス情報からサブスクリプション連番を割り出す

            ' 次の場合はサブスクリプション連番を取得できないのでNothingを返す
            If cbx権利者ID.SelectedIndex < 0 OrElse
               cbxサブスクリプションID.SelectedIndex < 0 OrElse
               dgvソフトウェア.CurrentRow Is Nothing Then
                Return Nothing
            End If
            '
            Dim str権利者ID As String = DirectCast(cbx権利者ID.SelectedItem, CbxItem).L
            Dim strメーカーID As String = dgvソフトウェア(2, dgvソフトウェア.CurrentRow.Index).Value
            Dim strサブスクリプションID As String = cbxサブスクリプションID.SelectedItem
            ' DBから条件に一致する連番を取得する
            Dim seq連番 =
                From
                    r In m_dtbComboBox
                Where
                    r("権利者ID") = str権利者ID AndAlso r("メーカーID") = strメーカーID AndAlso r("サブスクリプションID") = strサブスクリプションID
                Select
                    r("サブスクリプション連番")
            Return If(seq連番.Count = 0, Nothing, sNvl(seq連番.First))
        Else
            ' 更新又は削除モードの時はグリッド上から直接サブスクリプション連番を取得する
            If dgvプロダクトキー.Rows.Count = 0 Then
                Return Nothing
            End If
            Dim drw選択行 As DataRow = DirectCast(dgvプロダクトキー.DataSource, DataTable)(dgvプロダクトキー.CurrentRow.Index)
            Return sNvl(drw選択行("サブスクリプション連番"))
        End If
    End Function


    ''' <summary>
    ''' ソフトウェア一覧のDataGridViewのDataSourceとして設定するためのリストを取得する。
    ''' DataSourceにはDataTableやDataSetを始めとした特定のオブジェクトしか設定できない。
    ''' そのなかで、IListインターフェースを実装したオブジェクトは対象になっているためListとして取得する必要がある。
    ''' </summary>
    ''' <param name="vdtb">抽出する大元のDataTable</param>
    ''' <returns></returns>
    Private Function Selectソフトウェア一覧データ(ByVal vdtb As IEnumerable(Of DataRow)) As List(Of Object)
        ' 戻り値型として匿名型を直接指定することはできないので、基底のObject型として定義する
        Dim tmp As IEnumerable(Of Object) =
              From
                r In vdtb
              Select ' 名称ではなくより正確にIDをKeyにして重複を除去する
                x = New With {
                Key .メーカーID = sNvl(r("メーカーID")),
                Key .ソフトウェアID = sNvl(r("ソフトウェアID")),
                    .メーカー名称 = sNvl(r("メーカー名称")),
                    .ソフトウェア名称 = sNvl(r("ソフトウェア名称"))
                }
              Order By x.メーカー名称, x.ソフトウェア名称 ' ソートは各名称順
        ' 匿名型のKey指定した項目を基準として重複除去して、List型に変換してリターン
        Return tmp.Distinct.ToList
    End Function

End Class