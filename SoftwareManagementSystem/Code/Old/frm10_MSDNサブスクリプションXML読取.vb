Imports System.Text

Public Class _frm10_MSDNサブスクリプションXML読取

    Private SQL As New StringBuilder



    Private Sub btn参照_Click(sender As Object, e As EventArgs) Handles btn参照.Click
        If ofdXML.ShowDialog(Me) = DialogResult.OK Then
            tbxXMLパス.Text = ofdXML.FileName
            グリッド表示(tbxXMLパス.Text)
        End If
    End Sub

    Private Sub btn読取_Click(sender As Object, e As EventArgs) Handles btn読取.Click
        'グリッド表示(tbxXMLパス.Text)
    End Sub



    Private Sub btn更新_Click(sender As Object, e As EventArgs) Handles btn更新.Click

        If Not 入力チェック() Then
            Return
        End If

        ' DBへの登録及び更新処理

        ' MicrosoftのメーカーIDを取得する
        SQL.Length = 0
        SQL.AppendLine("SELECT")
        SQL.AppendLine("    メーカーID")
        SQL.AppendLine("FROM")
        SQL.AppendLine("    M01_メーカー")
        SQL.AppendLine("WHERE")
        SQL.AppendLine("    メーカー名称 = 'Microsoft'")
        Dim strメーカーID As String = GetValue(Of String)(SQL.ToString)

        If strメーカーID Is Nothing Then
            MsgBox("メーカーIDを取得できませんでした。")
            Return
        End If

        ' 削除するとXMLから取得できない情報も消えてしまうので、既存の場合は更新する。

        Dim dtb読込データ As DataTable = DirectCast(dgv一覧.DataSource, DataTable)

        Dim XMLソフト名一覧 =
            dtb読込データ.AsEnumerable.Select(Function(r) sNvl(r("ProductName"))).Distinct


        'Dim XMLソフト名一覧2 = dtb読込データ.AsEnumerable.Select(
        '    Function(r)
        '        Return New With {
        '        Key .ProductName = sNvl(r("ProductName")),
        '            .ProductID = "",
        '            .KeyType = sNvl(r("KeyType")),
        '            .ClaimedDate = sNvl(r("ClaimedDate")),
        '            .ProductKey = sNvl(r("ProductKey"))
        '        }
        '    End Function).Distinct(New ProductNameComp)

        ' Microsoftのソフト名称一覧を取得
        SQL.Length = 0
        'SQL.AppendLine("SELECT")
        'SQL.AppendLine("    ソフトID,")
        'SQL.AppendLine("    ソフト名称")
        'SQL.AppendLine("FROM")
        'SQL.AppendLine("    M02_ソフト基本情報")
        'SQL.AppendLine("WHERE")
        'SQL.AppendLine("    メーカーID = '" & strメーカーID & "'")

        SQL.AppendLine("SELECT")
        SQL.AppendLine("    M02.ソフトID,")
        SQL.AppendLine("    M02.ソフト名称,")
        SQL.AppendLine("    M03.サブスクライバーID,")
        SQL.AppendLine("    M03.アクティベーションキー")
        SQL.AppendLine("FROM")
        SQL.AppendLine("    M02_ソフト基本情報 M02")
        SQL.AppendLine("    LEFT JOIN")
        SQL.AppendLine("    M03_アクティベーション M03 ON")
        SQL.AppendLine("    m02.ソフトID = m03.ソフトID")
        SQL.AppendLine("WHERE")
        SQL.AppendLine("    M02.メーカーID = '" & strメーカーID & "'")

        Dim dtbDBデータ As DataTable = GetDataTable(SQL.ToString)

        Dim DBソフト名一覧 = dtbDBデータ.AsEnumerable.Select(Function(r) sNvl(r("ソフト名称"))).Distinct

        ' 最大のソフトIDを取得
        Dim DBソフトID As Integer

        If dtbDBデータ.Rows.Count = 0 Then
            ' 指定メーカーの製品がDBになければ、ソフトIDを作成
            DBソフトID = CInt(strメーカーID & "0000")
        Else
            ' 既存メーカーのソフトIDの最大値を取得
            DBソフトID = dtbDBデータ.AsEnumerable.Max(Function(r) CInt((r("ソフトID"))))
        End If

        ' Insert分リスト ※２つのシーケンスの差集合を取得する（重複除去される）
        Dim 差分登録ソフト名 As IEnumerable(Of String) = XMLソフト名一覧.Except(DBソフト名一覧)

        'If 差分登録ソフト名.Count = 0 Then
        '    Return
        'End If

        SQL.Length = 0

        Dim dicソフトIDと名称保存 As New Dictionary(Of String, Integer)
        Dim int連番 As Integer = 0
        ' M02へ差分ソフト基本情報を登録、M03へアクティベーション情報を新規登録
        For Each softname In 差分登録ソフト名
            DBソフトID += 1
            SQL.AppendLine("INSERT")
            SQL.AppendLine("INTO")
            SQL.AppendLine("    M02_ソフト基本情報")
            SQL.AppendLine("VALUES")
            SQL.AppendLine("(")
            SQL.AppendLine("    '" & DBソフトID & "',")
            SQL.AppendLine("    '" & softname & "',")
            SQL.AppendLine("    '" & strメーカーID & "',")
            SQL.AppendLine("    NULL,")
            SQL.AppendLine("    NULL,")
            SQL.AppendLine("    GETDATE(),")
            SQL.AppendLine("    GETDATE(),")
            SQL.AppendLine("    0")
            SQL.AppendLine(");")

            dicソフトIDと名称保存.Add(softname, DBソフトID)

            ' ソフト名称からプロダクトIDを探す
            Dim detail As EnumerableRowCollection(Of DataRow) =
                From r In dtb読込データ.AsEnumerable
                Where sNvl(r("ProductName")) = softname




            For Each drw In detail
                int連番 += 1
                SQL.AppendLine("INSERT")
                SQL.AppendLine("INTO")
                SQL.AppendLine("    M03_アクティベーション")
                SQL.AppendLine("VALUES")
                SQL.AppendLine("(")
                SQL.AppendLine("    '" & DBソフトID & "',")
                ' 要求日が空欄のデータのキーは共有であり特定のユーザーに依存しなためIDはNULL
                If sNvl(drw("ClaimedDate")).Trim = "" Then
                    SQL.AppendLine("    '',")
                Else
                    SQL.AppendLine("    '" & editサブスクリプションID.Text.Trim & "',")
                End If
                ' キータイプがカスタムキーの場合、プロダクトキー情報が正常ではなく長いので設定しない
                If sNvl(drw("KeyType")).Trim = "Custom Key" Then
                    SQL.AppendLine("    '',")
                Else
                    SQL.AppendLine("    '" & sNvl(drw("ProductKey")) & "',")
                End If
                SQL.AppendLine("    '" & int連番 & "',")
                SQL.AppendLine("    '" & sNvl(drw("KeyType")) & "',")
                ' 要求日時
                If sNvl(drw("ClaimedDate")).Trim = "" Then
                    SQL.AppendLine("    NULL,")
                Else
                    SQL.AppendLine("    '" & sNvl(drw("ClaimedDate")) & "',")
                End If
                SQL.AppendLine("    NULL,")
                SQL.AppendLine("    GETDATE(),")
                SQL.AppendLine("    GETDATE(),")
                SQL.AppendLine("    0")
                SQL.AppendLine(");")
            Next
        Next


        ' 既存更新分 ※M02_ソフト基本情報　で更新する情報は無いのでM03だけ更新する

        ' Update分リスト
        Dim 重複更新ソフト名 As IEnumerable(Of String) = XMLソフト名一覧.Intersect(DBソフト名一覧)
        Dim 連番 As Integer = 0

        Dim xxx As New StringBuilder

        For Each drw As DataRow In dtb読込データ.Rows
            'sNvl(r("サブスクライバーID")) = editサブスクリプションID.Text.Trim AndAlso
            xxx.Length = 0
            xxx.AppendLine("SELECT COUNT(*)")
            xxx.AppendLine("FROM")
            xxx.AppendLine("    M03_アクティベーション")
            xxx.AppendLine("WHERE")
            xxx.AppendLine("    ソフトID = (select top 1 ソフトID from M02_ソフト基本情報 WHERE ソフト名称='" & drw("ProductName") & "')")
            xxx.AppendLine("    AND サブスクライバーID = '" & editサブスクリプションID.Text.Trim & "'")
            xxx.AppendLine("    AND アクティベーションキー = '" & sNvl(drw("ProductKey")) & "'")



            Dim 件数 As Integer = GetValue(Of Integer)(xxx.ToString)

            Dim MAXソフトID As String = GetValue(Of String)("select max(ソフトID) from M02_ソフト基本情報 where ソフト名称 = '" & drw("ProductName") & "'")

            If MAXソフトID Is Nothing Then

            End If

            If 件数 = 0 Then
                ' 未登録のため新規
                連番 = 0

                SQL.AppendLine("INSERT")
                SQL.AppendLine("INTO")
                SQL.AppendLine("    M03_アクティベーション")
                SQL.AppendLine("VALUES")
                SQL.AppendLine("(")
                SQL.AppendLine("    '" & DBソフトID & "',")
                ' 要求日が空欄のデータのキーは共有であり特定のユーザーに依存しなためIDはNULL
                If sNvl(drw("ClaimedDate")).Trim = "" Then
                    SQL.AppendLine("    '',")
                Else
                    SQL.AppendLine("    '" & editサブスクリプションID.Text.Trim & "',")
                End If
                ' キータイプがカスタムキーの場合、プロダクトキー情報が正常ではなく長いので設定しない
                If sNvl(drw("KeyType")).Trim = "Custom Key" Then
                    SQL.AppendLine("    '',")
                Else
                    SQL.AppendLine("    '" & sNvl(drw("ProductKey")) & "',")
                End If
                SQL.AppendLine("    '" & int連番 & "',")
                SQL.AppendLine("    '" & sNvl(drw("KeyType")) & "',")
                ' 要求日時
                If sNvl(drw("ClaimedDate")).Trim = "" Then
                    SQL.AppendLine("    NULL,")
                Else
                    SQL.AppendLine("    '" & sNvl(drw("ClaimedDate")) & "',")
                End If
                SQL.AppendLine("    NULL,")
                SQL.AppendLine("    GETDATE(),")
                SQL.AppendLine("    GETDATE(),")
                SQL.AppendLine("    0")
                SQL.AppendLine(");")

            Else
                ' 登録済みにより更新

            End If
        Next

        For Each softname In 重複更新ソフト名
            ' DB登録済みデータからソフト名称からプロダクトIDを探す
            Dim detail As EnumerableRowCollection(Of DataRow) =
                From r In dtb読込データ.AsEnumerable
                Where sNvl(r("ProductName")) = softname


            ' 指定したソフト名称毎に、「認証方式」と「要求日時」を更新する
            For Each drw In detail
                SQL.AppendLine("UPDATE")
                SQL.AppendLine("    M03_アクティベーション")
                SQL.AppendLine("SET")
                SQL.AppendLine("    認証方式 = '" & sNvl(drw("KeyType")) & "',")
                SQL.AppendLine("    要求日時 = '" & sNvl(drw("ClaimedDate")) & "'")
                SQL.AppendLine("WHERE")
                SQL.AppendLine("    ソフトID = '" & softname & "'")
                ' 要求日が空欄のデータのキーは共有であり特定のユーザーに依存しなためIDはNULL
                If sNvl(drw("ClaimedDate")).Trim = "" Then
                    SQL.AppendLine("    AND サブスクライバーID = ''")
                Else
                    SQL.AppendLine("    AND サブスクライバーID = '" & editサブスクリプションID.Text.Trim & "'")
                End If
                SQL.AppendLine("    AND アクティベーションキー = '" & sNvl(drw("ProductKey")) & "'")
                ' 基本的に連番は１つだけであるため、更新レコード指定で連番は指定しない。
                ' よって複数連番あるレコードは全部同情報で更新される
            Next
        Next

        ' Insert処理実行
        If Not ExecNonQuery(SQL.ToString, True) Then
            MsgBox("更新に失敗しました。")
            Return
        End If

        MsgBox("更新が成功しました。")
    End Sub



    Private Sub グリッド表示(ByVal vstrXML As String)

        If Not IO.File.Exists(vstrXML) Then
            MsgBox("指定されたファイルは存在しないかアクセスできません。")
            Return
        End If

        ' 【XML構成】
        '<YourKey>　※ルートノード
        '    <Product_Key Name="製品名1">
        '        <Key ID="1" Type="認証タイプ" ClaimedDate="">プロダクトキー1-1</Key>
        '      ︙
        '        <Key ID="1" Type="認証タイプ" ClaimedDate="">プロダクトキー1-m</Key>
        '    </Product_Key>
        '   ︙
        '    <Product_Key Name="製品名n">
        '        <Key ID="n" Type="認証タイプ" ClaimedDate="">プロダクトキーn-1</Key>
        '        <Key ID="n" Type="認証タイプ" ClaimedDate="">プロダクトキーn-2</Key>
        '    </Product_Key>
        '</YourKey>
        '
        ' ｎ個の製品名に対して、それぞれｍ個の認証キーが割り当てられている

        Dim xDoc As XDocument

        Try
            xDoc = XDocument.Load(vstrXML)
        Catch ex As Exception
            MsgBox("指定されたファイルをXMLとして読み込めませんでした。")
            Return
        End Try

        Dim dtb As New DataTable
        dtb.Columns.Add("ProductName")
        dtb.Columns.Add("KeyType")
        dtb.Columns.Add("ClaimedDate")
        dtb.Columns.Add("ID")
        dtb.Columns.Add("ProductKey")

        ' Product_Key レベルで要素を取得
        For Each l1 As XElement In xDoc.Descendants("Product_Key")
            ' Key レベルで要素を取得
            For Each l2 As XElement In l1.Descendants("Key")
                ' DataRowを追加していく ※順番注意
                dtb.Rows.Add(l1.Attribute("Name").Value,
                             l2.Attribute("Type").Value,
                             l2.Attribute("ClaimedDate").Value,
                             l2.Attribute("ID").Value,
                             l2.Value)
            Next
        Next
        dgv一覧.DataSource = dtb

        ' Product_Key レベルで要素を取得
        'Dim xmlDataSource = xDoc.Descendants("Product_Key").SelectMany(
        '    Function(l1)
        '        ' Key レベルで要素を取得
        '        Return l1.Descendants("Key").Select(
        '        Function(l2)
        '            ' 匿名型のプロパティ名はDataGridViewのDataPropertyNameに一致させる
        '            Return New With {
        '            .ProductName = l1.Attribute("Name").Value,
        '            .KeyType = l2.Attribute("Type").Value,
        '            .ClaimedDate = l2.Attribute("ClaimedDate").Value,
        '            .ID = l2.Attribute("ID").Value,
        '            .ProductKey = l1.Value
        '            }
        '        End Function)
        '    End Function)
        ''
        'dgv一覧.DataSource = xmlDataSource.ToList
    End Sub

    Private Function 入力チェック() As Boolean

        If dgv一覧.RowCount = 0 Then
            MsgBox("更新すべきデータがありません。")
            Return False
        End If

        If editサブスクリプションID.Text.Trim = "" Then
            MsgBox("サブスクリプションIDが入力されていません。")
            Return False
        End If

        Return True

    End Function


    'Private Class ProductNameComp
    '    Inherits EqualityComparer(Of DataRow)
    '    Public Overrides Function Equals(x As DataRow, y As DataRow) As Boolean
    '        Return sNvl(x("ProductName")).Equals(sNvl(y("ProductName")))
    '    End Function

    '    Public Overrides Function GetHashCode(obj As DataRow) As Integer
    '        Return sNvl(obj("ProductName")).GetHashCode
    '    End Function
    'End Class

End Class