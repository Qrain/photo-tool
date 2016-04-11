Imports System.Text

Public Class frm11_データインポート

    Private SQL As New StringBuilder
    Private m_dtbComboBox As DataTable

    Private Sub frm11_データインポート_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 
        SetupDataGridViewProperties(dgv一覧)
        SetupDataGridViewCellMerge(dgv一覧, dgvcKeyName, dgvcKeyType)
        lbl件数.Text = ""
        ' コンボボックス設定
        cbxメーカーID.Enabled = False
        cbxサブスクリプションID.Enabled = False
        ComboBox設定()
    End Sub

    Private Sub ComboBox設定()
        ' ComboBoxの準備   
        SQL.Length = 0
        SQL.AppendLine("SELECT")
        SQL.AppendLine("    M03.サブスクリプション連番,")
        SQL.AppendLine("    M03.権利者ID,")
        SQL.AppendLine("    M02.社員名,")
        SQL.AppendLine("    M03.メーカーID,")
        SQL.AppendLine("    M11.メーカー名称,")
        SQL.AppendLine("    CASE")
        SQL.AppendLine("    WHEN M03.サブスクリプションID IS NULL THEN '" & gs名称("代替文字列")("02") & "'")
        SQL.AppendLine("    ELSE M03.サブスクリプションID")
        SQL.AppendLine("    END AS サブスクリプションID")
        SQL.AppendLine("FROM")
        SQL.AppendLine("    M03_サブスクリプション M03")
        SQL.AppendLine("    LEFT JOIN")
        SQL.AppendLine("    M02_社員 M02 ON")
        SQL.AppendLine("    M03.権利者ID = M02.社員ID")
        SQL.AppendLine("    LEFT JOIN")
        SQL.AppendLine("    M11_メーカー M11 ON")
        SQL.AppendLine("    M03.メーカーID = M11.メーカーID")
        SQL.AppendLine("WHERE")
        SQL.AppendLine("    M03.メーカーID = '" & gs名称("MSメーカーID")("1") & "'")
        SQL.AppendLine("    AND M03.削除区分 = 0")
        m_dtbComboBox = GetDataTable(SQL.ToString)
        '
        ' 権利者を重複を除去して設定する
        cbx権利者ID.Items.AddRange(m_dtbComboBox.GeneratePairArray("権利者ID", "社員名"))
    End Sub


    Private Sub cbx権利者ID_TextChanged(sender As Object, e As EventArgs) Handles cbx権利者ID.TextChanged
        ' メーカー選択コンボボックスを有効にする
        cbxメーカーID.Enabled = cbx権利者ID.SelectedIndex >= 0
        ' 下位コンボボックスの選択を解除する
        cbxメーカーID.SelectedIndex = -1
        '
        Dim str権利者 = If(cbx権利者ID.SelectedIndex < 0, "", DirectCast(cbx権利者ID.SelectedItem, CbxItem).L)
        ' 各項目のデータは
        Dim lstメーカー =
            From x In m_dtbComboBox
            Where str権利者 = "" OrElse sNvl(x("権利者ID")) = str権利者
            Select New CbxItem(x("メーカーID"), x("メーカー名称"))
        ' 取得したアイテムを設定する
        cbxメーカーID.Items.Clear()
        cbxメーカーID.Items.AddRange(lstメーカー.Distinct.ToArray)

        If cbxメーカーID.Items.Count = 1 Then
            cbxメーカーID.SelectedIndex = 0
        End If
        ' 下位
    End Sub

    Private Sub cbxメーカーID_TextChanged(sender As Object, e As EventArgs) Handles cbxメーカーID.TextChanged
        ' サブスクリプションID選択コンボボックスを有効にする
        cbxサブスクリプションID.Enabled = cbxメーカーID.SelectedIndex >= 0
        ' 下位コンボボックスの選択を解除する
        cbxサブスクリプションID.SelectedIndex = -1
        '
        Dim str権利者 = If(cbx権利者ID.SelectedIndex < 0, "", DirectCast(cbx権利者ID.SelectedItem, CbxItem).L)
        Dim strメーカー = If(cbxメーカーID.SelectedIndex < 0, "", DirectCast(cbxメーカーID.SelectedItem, CbxItem).L)
        ' 各項目のデータは
        Dim lstサブスクリプション =
            From x In m_dtbComboBox.AsEnumerable
            Where sNvl(x("権利者ID")) = str権利者 AndAlso sNvl(x("メーカーID")) = strメーカー
            Select sNvl(x("サブスクリプションID"))
        ' 取得したアイテムを設定する
        cbxサブスクリプションID.Items.Clear()
        cbxサブスクリプションID.Items.AddRange(lstサブスクリプション.Distinct.ToArray)
        If cbxサブスクリプションID.Items.Count = 1 Then
            cbxサブスクリプションID.SelectedIndex = 0
        End If
    End Sub

    Private Sub btn参照_Click(sender As Object, e As EventArgs) Handles btn参照.Click
        If ofdXML.ShowDialog(Me) = DialogResult.OK Then
            tbxXMLパス.Text = ofdXML.FileName
        End If
    End Sub

    Private Sub btn読込_Click(sender As Object, e As EventArgs) Handles btn読込.Click
        '
        If Not IO.File.Exists(tbxXMLパス.Text) Then
            MsgBox("指定されたファイルは存在しないかアクセスできません。")
            Return
        End If
        '
        Dim xDoc As XDocument = Nothing
        Try
            xDoc = XDocument.Load(tbxXMLパス.Text)
        Catch ex As Exception
            MsgBox("指定されたファイルをXMLとして読み込めませんでした。")
            Return
        End Try
        ' 列を定義
        Dim dtb As New DataTable
        dtb.Columns.Add("KeyName")
        dtb.Columns.Add("KeyType")
        dtb.Columns.Add("ClaimedDate")
        dtb.Columns.Add("ProductKey")
        dtb.Columns.Add("Validity") ' プロダクトキーの妥当性 
        ' Product_Key レベルで要素を取得
        For Each Lv1 As XElement In xDoc.Descendants("Product_Key")
            ' Key レベルで要素を取得
            For Each Lv2 As XElement In Lv1.Descendants("Key")
                ' DataRowを追加していく ※順番注意
                dtb.Rows.Add(Lv1.Attribute("Name").Value,
                             Lv2.Attribute("Type").Value,
                             If(Lv2.Attribute("ClaimedDate").Value = "", "", CDate(Lv2.Attribute("ClaimedDate").Value).ToString("yyyy/MM/dd")),
                             Lv2.Value,
                             If(Lv2.Attribute("Type").Value = "Custom Key", "✕", "○"))
            Next
        Next
        '
        dgv一覧.DataSource =
            (From r In dtb
             Order By r("KeyName"), r("KeyType")).CopyToDataTable
        '
        ' 集計結果
        Dim cnt全件 As Integer = dtb.Rows.Count
        Dim cnt有効 As Integer = dtb.AsEnumerable.Count(Function(x) x("Validity") = "○")
        Dim cnt無効 As Integer = cnt全件 - cnt有効
        ' ラベル更新
        lbl件数.Text = "全" & cnt全件 & "件中　有効: " & cnt有効 & "件　無効: " & cnt無効 & "件"
    End Sub

    Private Sub btn更新_Click(sender As Object, e As EventArgs) Handles btn更新.Click

        If Not 入力チェック() Then
            Return
        End If

        ' 読み込んだXMLによるDB更新手順
        ' 1.正確なソフト名ではないプロダクトキー名をソフト名としてソフトウェアマスタに登録する
        ' 　※既存のはそのままで差分があれば追加していく

        ' DB登録済みのMSソフト一覧取得
        SQL.Length = 0
        SQL.AppendLine("SELECT")
        SQL.AppendLine("    ソフトウェアID,")
        SQL.AppendLine("    ソフトウェア名称,")
        SQL.AppendLine("    ファイル名,")
        SQL.AppendLine("    作成日時,")
        SQL.AppendLine("    更新日時")
        SQL.AppendLine("FROM")
        SQL.AppendLine("    M12_ソフトウェア")
        SQL.AppendLine("WHERE")
        SQL.AppendLine("    メーカーID = '" & gs名称("MSメーカーID")("1") & "'")

        Dim dtbDB As DataTable = GetDataTable(SQL.ToString)
        Dim seqDBソフト一覧 = dtbDB.AsEnumerable.Select(Function(x) sNvl(x("ソフトウェア名称")).Trim).Distinct

        Dim dtbXMLデータ As DataTable = DirectCast(dgv一覧.DataSource, DataTable)
        Dim seqXMLソフト一覧 = dtbXMLデータ.AsEnumerable.Select(Function(r) sNvl(r("KeyName")).Trim).Distinct

        ' Insert分リスト ※２つのシーケンスの差集合を取得する（重複除去される）
        Dim seq差分登録ソフト名 As IEnumerable(Of String) = seqXMLソフト一覧.Except(seqDBソフト一覧)
        '
        ' トランザクションではなく、先にソフトウェアマスタに追加処理しておく
        If seq差分登録ソフト名.Count > 0 Then
            Dim intソフトID採番 As Integer

            If dtbDB.Rows.Count = 0 Then
                intソフトID採番 = CInt(gs名称("MSメーカーID")("1") & "0000")
            Else
                intソフトID採番 = dtbDB.AsEnumerable.Max(Function(r) CInt(r("ソフトウェアID")))
            End If
            SQL.Length = 0
            For Each foftname In seq差分登録ソフト名
                intソフトID採番 += 1
                SQL.AppendLine("INSERT")
                SQL.AppendLine("INTO")
                SQL.AppendLine("    M12_ソフトウェア")
                SQL.AppendLine("VALUES")
                SQL.AppendLine("(")
                SQL.AppendLine("    '" & intソフトID採番.ToString("0000000") & "',")
                SQL.AppendLine("    '" & gs名称("MSメーカーID")("1") & "',")
                SQL.AppendLine("    '" & foftname & "',")
                SQL.AppendLine("    NULL,")
                SQL.AppendLine("    GETDATE(),")
                SQL.AppendLine("    GETDATE(),")
                SQL.AppendLine("    0")
                SQL.AppendLine(");")
            Next
            If Not ExecNonQuery(SQL.ToString) Then
                Return
            End If
        End If

        ' 2.DB登録済のソフトウェア情報
        SQL.Length = 0
        SQL.AppendLine("SELECT")
        SQL.AppendLine("    M13.ソフトウェアID,")
        SQL.AppendLine("    M12.ソフトウェア名称,")
        SQL.AppendLine("    M13.プロダクトキー,")
        SQL.AppendLine("    M03.権利者ID,")
        SQL.AppendLine("    M03.サブスクリプションID")
        SQL.AppendLine("FROM")
        SQL.AppendLine("    M13_プロダクトキー M13")
        SQL.AppendLine("    LEFT JOIN")
        SQL.AppendLine("    M12_ソフトウェア M12 ON")
        SQL.AppendLine("    M13.ソフトウェアID = M12.ソフトウェアID")
        SQL.AppendLine("    LEFT JOIN")
        SQL.AppendLine("    M03_サブスクリプション M03 ON")
        SQL.AppendLine("    M13.サブスクリプション連番 = M03.サブスクリプション連番")
        SQL.AppendLine("WHERE")
        SQL.AppendLine("    M12.メーカーID = '" & gs名称("MSメーカーID")("1") & "'")
        Dim seq登録済キー As DataTable = GetDataTable(SQL.ToString)
        Dim str権利者ID As String = DirectCast(cbx権利者ID.SelectedItem, CbxItem).L
        Dim strメーカーID As String = DirectCast(cbxメーカーID.SelectedItem, CbxItem).L
        Dim strサブスクリプションID As String = cbxサブスクリプションID.SelectedItem.ToString
        '
        ' 選択されているコンボボックス情報からサブスクリプション連番を取得する
        Dim intサブスクリプション連番 As Integer =
            (From
                 r In m_dtbComboBox
             Where
                 r("権利者ID") = str権利者ID AndAlso
                 r("メーカーID") = strメーカーID AndAlso
                 r("サブスクリプションID") = strサブスクリプションID
             Select
                 CInt(r("サブスクリプション連番"))).First

        Dim int法人MSサブスクリプション連番 As Integer = Get法人MSサブスクリプション連番()

        ' 1 → プロダクトキー名とプロダクトキーに関して重複を除去
        ' 2 → 認証タイプが Custom Key の場合は、プロダクトキーを空にする
        ' 3 → 認証タイプを 名称コードに変換する  01:認証無し 02:静的認証 03:期間認証（動的）
        Dim seqXML整形データ =
            From
                x In dtbXMLデータ
            Select
                New With {
                Key .キー名 = sNvl(x("KeyName")).Trim,
                Key .プロダクトキー = If(sNvl(x("KeyType")).Trim = "Custom Key", gs名称("代替文字列")("01"), sNvl(x("ProductKey")).Trim),
                    .要求日 = If(sNvl(x("ClaimedDate")).Trim = "", Nothing, x("ClaimedDate")),
                    .認証方式コード = Get認証方式名称コード(x)
                }

        SQL.Length = 0
        For Each x In seqXML整形データ.Distinct

            Dim seq既存プロダクトキー =
                From
                    r In seq登録済キー
                Where
                    r("ソフトウェア名称") = x.キー名 AndAlso
                    r("プロダクトキー") = x.プロダクトキー

            If seq既存プロダクトキー.Count > 0 Then
                Dim drw既存プロダクトキー As DataRow = seq既存プロダクトキー.First
                ' 取り込もうとするプロダクトキーが既に有り、自分のものならば
                SQL.AppendLine("UPDATE")
                SQL.AppendLine("    M13_プロダクトキー")
                SQL.AppendLine("SET")
                '
                ' もしも同ソフト同キーかつ他の権利者のプロダクトキー情報が既にあれば
                If sNvl(drw既存プロダクトキー("権利者ID")) <> str権利者ID Then
                    ' 会社で共有できるのもとみなしてサブスクリプション情報を"法人"のものに変更
                    SQL.AppendLine("    サブスクリプション連番 = " & int法人MSサブスクリプション連番 & ",")
                ElseIf sNvl(drw既存プロダクトキー("サブスクリプションID")) <> strサブスクリプションID Then
                    ' 同ソフト同キーかつ同権利者かつ異なるサブスクリプションIDならば連番を入れ替え
                    SQL.AppendLine("    サブスクリプション連番 = " & intサブスクリプション連番 & ",")
                End If
                '
                SQL.AppendLine("    認証タイプ = '" & x.認証方式コード & "',")
                SQL.AppendLine("    要求日付 = " & If(x.要求日 Is Nothing, "NULL", "'" & x.要求日 & "'") & ",")
                SQL.AppendLine("    更新日時 = GETDATE()")
                SQL.AppendLine("WHERE")
                SQL.AppendLine("    ソフトウェアID = '" & drw既存プロダクトキー("ソフトウェアID") & "'")
                SQL.AppendLine("    AND プロダクトキー = '" & drw既存プロダクトキー("プロダクトキー") & "';")
            Else
                ' ここにくるということは、反復処理中のソフトウェアについて
                ' まだDBにに登録されていないということになる。

                'まだ重複がある。
                ' 新規インサート
                SQL.AppendLine("INSERT INTO")
                SQL.AppendLine("    M13_プロダクトキー")
                SQL.AppendLine("(")
                SQL.AppendLine("    ソフトウェアID,")
                SQL.AppendLine("    プロダクトキー,")
                SQL.AppendLine("    サブスクリプション連番,")
                SQL.AppendLine("    認証タイプ,")
                SQL.AppendLine("    要求日付,")
                SQL.AppendLine("    利用者ID,")
                SQL.AppendLine("    作成日時,")
                SQL.AppendLine("    更新日時,")
                SQL.AppendLine("    削除区分")
                SQL.AppendLine(") VALUES (")
                SQL.AppendLine("    (")
                SQL.AppendLine("    SELECT")
                SQL.AppendLine("        TOP 1 ソフトウェアID")
                SQL.AppendLine("    FROM")
                SQL.AppendLine("        M12_ソフトウェア")
                SQL.AppendLine("    WHERE")
                SQL.AppendLine("        ソフトウェア名称 = '" & x.キー名 & "'")
                SQL.AppendLine("        AND メーカーID = '" & gs名称("MSメーカーID")("1") & "'")
                SQL.AppendLine("    ),")
                ' ※カスタムキーの場合は、プロダクトキーを取得・登録しない（非常に長く有益データではないため）
                SQL.AppendLine("    '" & x.プロダクトキー & "',")
                SQL.AppendLine("    " & intサブスクリプション連番 & ",") ' 連番
                SQL.AppendLine("    '" & x.認証方式コード & "',")
                SQL.AppendLine("    " & If(x.要求日 Is Nothing, "NULL", "'" & x.要求日 & "'") & ",")
                SQL.AppendLine("    NULL,") ' 利用者IDは現在 NULL固定
                SQL.AppendLine("    GETDATE(),")
                SQL.AppendLine("    GETDATE(),")
                SQL.AppendLine("    0")
                SQL.AppendLine(");")
            End If
        Next

        If Not ExecNonQuery(SQL.ToString, True) Then
            Return
        End If

        MsgInfo("更新結果", "XMLインポートが完了しました。")

    End Sub


    Private Function 入力チェック() As Boolean

        If dgv一覧.RowCount = 0 Then
            MsgWarn("入力チェック", "更新すべきデータがありません。")
            Return False
        ElseIf cbx権利者ID.SelectedIndex < 0 Then
            MsgWarn("入力チェック", "権利者が選択されてません。")
            cbx権利者ID.Focus()
            Return False
        ElseIf cbxメーカーID.SelectedIndex < 0 Then
            MsgWarn("入力チェック", "メーカーが選択されてません。")
            cbxメーカーID.Focus()
            Return False
        ElseIf DirectCast(cbxメーカーID.SelectedItem, CbxItem).L <> gs名称("MSメーカーID")("1") Then
            MsgWarn("入力チェック", "この機能はメーカーが""001:Microsoft""のときのみ有効です。")
            cbxメーカーID.Focus()
            Return False
        ElseIf cbxサブスクリプションID.SelectedIndex < 0 Then
            MsgWarn("入力チェック", "サブスクリプションIDが選択されてません。")
            cbxサブスクリプションID.Focus()
            Return False
        End If

        Return True

    End Function

    ''' <summary>
    ''' 権利者かつ法人である社員のMicrosoftとして登録されているサブスクリプション連番を取得する。
    ''' </summary>
    ''' <returns></returns>
    Private Function Get法人MSサブスクリプション連番() As Integer
        Dim sql As New StringBuilder
        sql.AppendLine("SELECT")
        sql.AppendLine("    TOP 1 サブスクリプション連番")
        sql.AppendLine("FROM")
        sql.AppendLine("    M03_サブスクリプション M03")
        sql.AppendLine("    LEFT JOIN")
        sql.AppendLine("    M02_社員 M02 ON")
        sql.AppendLine("    M03.権利者ID = M02.社員ID")
        sql.AppendLine("WHERE")
        sql.AppendLine("        権利者区分 = '1'")
        sql.AppendLine("    AND 社員区分 = '法人'")
        sql.AppendLine("    AND メーカーID = '" & gs名称("MSメーカーID")("1") & "'")
        Return GetValue(Of Integer)(sql.ToString)
    End Function

    Private Function Get認証方式名称コード(ByVal vstrKeyType As DataRow) As String
        Select Case sNvl(vstrKeyType("KeyType")).Trim
            Case "Static Activation Key",
                 "Retail",
                 "MultipleActivation",
                 "VA 1.0"
                If sNvl(vstrKeyType("ProductKey")).Trim = "No key is required for this product." Then
                    ' Case of 01: 認証不要
                    Return "01"
                Else
                    ' Case of 02: 静的認証
                    Return "02"
                End If
            Case "Custom Key"
                ' Case of 03: 期間認証
                Return "03"
            Case Else
                ' Case of 99: 不明
                Return "99"
        End Select
    End Function

End Class