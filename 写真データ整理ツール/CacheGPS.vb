Imports System.Data.SQLite
Imports System.Text
Imports System.Net
Imports System.Xml


Public Class CacheGPS




    Enum CacheType
        DB_SQLite
        JSON
        XML
        CSV
    End Enum

    Sub New(ByVal type As CacheType)


        Select Case type
            Case CacheType.DB_SQLite

                Try
                    Using con As New SQLiteConnection(My.Settings.DB接続文字列)
                        '接続をオープン
                        con.Open()
                        Using com = con.CreateCommand
                            Dim sql As New StringBuilder
                            sql.AppendLine("")
                            com.CommandText = "SELECT * FROM GPS_CACHE"

                            'INSERT操作を実行
                            'com.ExecuteNonQuery()
                            'データリーダーにデータ取得
                            Using dr = com.ExecuteReader
                                'データを全件出力
                                Do Until Not dr.Read
                                    Debug.Print(dr.Item("LAT").ToString)
                                    Debug.Print(dr.Item("LONG").ToString)
                                    Debug.Print(dr.Item("ADDRESS_L").ToString)
                                    Debug.Print(dr.Item("ADDRESS_M").ToString)
                                    Debug.Print(dr.Item("ADDRESS_S").ToString)
                                Loop

                            End Using
                        End Using
                    End Using
                Catch ex As Exception

                    MsgBox(ex.Message)

                End Try


            Case CacheType.JSON

            Case CacheType.CSV

            Case CacheType.XML
        End Select



    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="x">経度（60でなく10進数）</param>
    ''' <param name="y">緯度（60でなく10進数）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAddress(x As Double, y As Double) As LocationInfo

        '有効桁数を丸めて補正
        x = FixXY(x)
        y = FixXY(y)

        '１．x, y のキャッシュがあるか探す
        sql.Length = 0
        sql.AppendLine("SELECT *")
        sql.AppendLine("FROM")
        sql.AppendLine("    GPS_CACHE")
        sql.AppendLine("WHERE")
        sql.AppendLine("    LAT = " & y & " AND")
        sql.AppendLine("    LONG = " & x & "")


        Dim dtb = SQLite_GetDataTable(sql.ToString)

        '返却する Location オブジェクト
        Dim loc As LocationInfo = Nothing

        If dtb.Rows.Count > 0 Then
            ' DB上にキャッシュが存在する
            Dim drw = dtb.Rows(0)

            With dtb.Rows(0)
                loc = New LocationInfo(
                    x,
                    y,
                    CDbl(.Item("DISTANCE")),
                    .Item("ADDRESS_L").ToString,
                    .Item("ADDRESS_M").ToString,
                    .Item("ADDRESS_S").ToString,
                    "",
                    .Item("POSTAL").ToString)
            End With

            ' 位置情報があるなら、位置情報オブジェクトを返す


        Else
            ' DB上にキャッシュが無い場合は WebAPI を使い新規に取得する

            'WebサービスのURLを作成する
            Dim url = String.Format("http://geoapi.heartrails.com/api/xml?method=searchByGeoLocation&x={0}&y={1}", x, y)

            'URLへのRequestを生成
            Dim req = System.Net.WebRequest.Create(url)

            'Response取得
            Using res = req.GetResponse()
                'Stream取得
                Using stream = res.GetResponseStream
                    ' 文字列として扱うためのStreamReader
                    Using reader = New System.IO.StreamReader(stream)

                        Dim xDoc = New XmlDocument

                        '文字列のXMLを XmlDocument に読み込む
                        xDoc.LoadXml(reader.ReadToEnd)

                        'ここのAPIでは緯度・経度による住所検索で、距離が近い順で１０件の住所結果が帰ってくる。
                        'なので、最初の location 要素（最も誤差が少ない）の住所情報を取得する
                        Dim location = xDoc.Item("response").Item("location")

                        ' 位置情報があるなら、位置情報オブジェクトを設定
                        If location IsNot Nothing Then
                            loc = New LocationInfo(x,
                                                   y,
                                                   CDbl(location.Item("distance").InnerText),
                                                   location.Item("prefecture").InnerText,
                                                   location.Item("city").InnerText,
                                                   location.Item("town").InnerText,
                                                   "",
                                                   location.Item("postal").InnerText)

                            ' 結果をキャッシュする
                            sql.Length = 0
                            sql.AppendLine("INSERT")
                            sql.AppendLine("INTO")
                            sql.AppendLine("    GPS_CACHE")
                            sql.AppendLine("VALUES")
                            sql.AppendLine("(")
                            sql.AppendLine("    " & y & ",")
                            sql.AppendLine("    " & x & ",")
                            sql.AppendLine("    '" & loc.AddressL & "',")
                            sql.AppendLine("    '" & loc.AddressM & "',")
                            sql.AppendLine("    '" & loc.AddressS & "',")
                            sql.AppendLine("    " & loc.Distance & ",")
                            sql.AppendLine("    '" & loc.Postal & "'")
                            sql.AppendLine(")")

                            SQLite_NonQuery(sql.ToString)
                        End If

                    End Using
                End Using
            End Using

        End If






  

        Return loc

    End Function


    ''' <summary>
    ''' 指定された緯度・経度のキャッシュを削除する
    ''' </summary>
    ''' <param name="x">削除するキャッシュの経度</param>
    ''' <param name="y">削除するキャッシュの緯度</param>
    ''' <returns>削除に成功すればTrue、失敗または指定のキャッシュが存在しない場合はFlase</returns>
    ''' <remarks></remarks>
    Public Function ClearCache(x As Double, y As Double) As Boolean

        '小数点3桁程度でOKかと・・・
        ' 目安として： 緯度経度 0.01≒1km なので
        ' 100m程度の誤差を許すならば、 0.001 と3桁程度あればいい
        ' ちなみに、iphone だと6桁あるので、計算上は 10cm 程度の誤差になる
        sql.Length = 0
        sql.AppendLine("DELETE")
        sql.AppendLine("FROM")
        sql.AppendLine("    GPS_CACHE")
        sql.AppendLine("WHERE")
        sql.AppendLine("    LAT = " & FixXY(y) & " AND")
        sql.AppendLine("    LONG = " & FixXY(x))

        '削除を実行する（成功→True、失敗→False）
        Return SQLite_NonQuery(sql.ToString)

    End Function



    Private sql As New StringBuilder


    ''' <summary>
    ''' 所定の桁数で値を丸めて返します。
    ''' 小数点3桁程度でOKかと・・・
    ''' 目安として： 緯度経度 0.01≒1km なので
    ''' 100m程度の誤差を許すならば、 0.001 と3桁程度あればいい
    ''' ちなみに、iphone だと6桁あるので、計算上は 10cm 程度の誤差になる
    ''' </summary>
    ''' <param name="xy"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FixXY(ByVal xy As Double) As Double
        Return Math.Round(xy, 4)
    End Function


End Class


'位置情報のクラス
Public Class LocationInfo
    Public Sub New(ByVal x As Double,
                   ByVal y As Double,
                   ByVal distance As Double,
                   ByVal addressL As String,
                   ByVal addressM As String,
                   ByVal addressS As String,
                   ByVal addressElse As String,
                   ByVal postal As String)
        Me.X = x
        Me.Y = y
        Me.Distance = distance
        Me.AddressL = addressL
        Me.AddressM = addressM
        Me.AddressS = addressS
        Me.AddressElse = addressElse
        Me.Postal = postal
    End Sub

    '緯度と軽度
    Public ReadOnly X As Double
    Public ReadOnly Y As Double
    '緯度・経度と住所との誤差目安（m）
    Public ReadOnly Distance As Double
    '各住所（大区分、中区分、小区分、それ以降）
    Public ReadOnly AddressL As String
    Public ReadOnly AddressM As String
    Public ReadOnly AddressS As String
    Public ReadOnly AddressElse As String
    '郵便番号
    Public ReadOnly Postal As String
End Class
