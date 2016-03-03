Imports System.Data.SQLite
Imports System.Text
Imports System.Net
Imports System.Xml

''' <summary>
''' 経度と緯度で指定された位置情報の取得、及び結果のキャッシュを行うクラスです。
''' キャッシュ用のデータベースとしてSQLiteを使用しています。
''' </summary>
''' <remarks></remarks>
Public Class CacheGPS

    '座標→住所解決に使用するWebAPI のURLフォーマット
    Private Const apiUrl = "http://geoapi.heartrails.com/api/xml?method=searchByGeoLocation&x={0}&y={1}"

    '緯度及び経度を四捨五入したときに残す小数部の桁数
    ' 目安として、緯度及び経度 の値と距離の関係は
    ' 0.01      ≒ 1000m → Round(n, 2)
    ' 0.001     ≒ 100m  → Round(n, 3)
    ' 0.0001    ≒ 10m   → Round(n, 4)
    ' よって、100m 程度の誤差を許すなら、小数点以下3桁あればよく、
    ' Math.Round(n, 3) で４桁目で四捨五入すればいいようだ。
    ' ちなみに、iPhone4s では 6桁あったので、計算上は 10cm 程度の誤差になる。
    Private Const decs = 3

    Private sql As New StringBuilder

    ''' <summary>
    ''' 引数に指定した経度と緯度に対応するLocationInfoオブジェクトを返却します。
    ''' このメソッドは SQLite データベースに結果をキャッシュします。
    ''' </summary>
    ''' <param name="x">経度（60でなく10進数）</param>
    ''' <param name="y">緯度（60でなく10進数）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetLocation(x As Double, y As Double) As LocationInfo

        '有効桁数を丸めて補正
        x = FixXY(x)
        y = FixXY(y)

        '１．x, y のキャッシュがあるか探す
        sql.Length = 0
        sql.AppendLine("SELECT *")
        sql.AppendLine("FROM")
        sql.AppendLine("    GPS_CACHE")
        sql.AppendLine("WHERE")
        sql.AppendLine("    Y = " & y & " AND")
        sql.AppendLine("    X = " & x & "")

        Dim dtb = SQLite_GetDataTable(sql.ToString)
        Dim loc As LocationInfo = Nothing

        '返却する Location オブジェクト
        If dtb.Rows.Count > 0 Then
            'キャッシュ存在すればそれを元に Location を作成
            ' DataRowを取得
            Dim drw = dtb.Rows(0)

            loc = New LocationInfo(
                x,
                y,
                CDbl(drw.Item("DISTANCE")),
                drw.Item("ADDRESS_L").ToString,
                drw.Item("ADDRESS_M").ToString,
                drw.Item("ADDRESS_S").ToString,
                "",
                drw.Item("POSTAL").ToString)

        Else

            ' DB上にキャッシュが無い場合は WebAPI を使い新規に取得する

            'WebサービスのURLを作成する
            Dim url = String.Format(apiUrl, x, y)

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
    Private Function ClearCache(x As Double?, y As Double?) As Boolean

        sql.Length = 0
        sql.AppendLine("DELETE")
        sql.AppendLine("FROM")
        sql.AppendLine("    GPS_CACHE")
        sql.AppendLine("WHERE")

        If x IsNot Nothing Then
            sql.AppendLine("    X = " & FixXY(x) & " AND")
        End If

        If y IsNot Nothing Then
            sql.AppendLine("    Y = " & FixXY(y) & " AND")
        End If

        sql.AppendLine("    1 = 1")

        '削除を実行する（成功→True、失敗→False）
        Return SQLite_NonQuery(sql.ToString)
    End Function

    Public Function ClearCacheX(x As Double)
        Return ClearCache(x, Nothing)
    End Function

    Public Function ClearCacheY(y As Double)
        Return ClearCache(Nothing, y)
    End Function

    Public Function ClearCacheAll()
        Return ClearCache(Nothing, Nothing)
    End Function

    ''' <summary>
    ''' 所定の桁数で値を丸めて返します。
    ''' </summary>
    ''' <param name="xy"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FixXY(ByVal xy As Double) As Double
        Return Math.Round(xy, decs)
    End Function

End Class


''' <summary>
''' 位置情報を管理するための値クラスです。
''' 全ての変数は ReadOnly なのでコンストラクターでのみ一度だけ初期化されます。
''' </summary>
''' <remarks></remarks>
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

    Public Overrides Function ToString() As String
        Return AddressL & AddressM & AddressS
    End Function

End Class
