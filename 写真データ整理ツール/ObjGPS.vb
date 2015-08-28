Imports System.IO
Imports System.Xml
Imports System.Drawing.Imaging


Class ObjGPS

    Private _住所大区分 As String
    Private _住所中区分 As String
    Private _住所小区分 As String
    Private _距離誤差目安 As Single
    Private _郵便番号 As String


    ReadOnly Property 住所大区分 As String
        Get
            Return _住所大区分
        End Get
    End Property

    ReadOnly Property 住所中区分 As String
        Get
            Return _住所中区分
        End Get
    End Property

    ReadOnly Property 住所小区分 As String
        Get
            Return _住所小区分
        End Get
    End Property


    ReadOnly Property 距離誤差目安 As Single
        Get
            Return _距離誤差目安
        End Get
    End Property


    ReadOnly Property 郵便番号 As String
        Get
            Return _郵便番号
        End Get
    End Property



    ' 経度を表す変数
    Private _X As Double


    ' 緯度を表す変数
    Private _Y As Double

    Private Function GetExifTags(ByVal filename As String) As IEnumerable(Of PropertyItem)
        Using img = Image.FromFile(filename)
            Return img.PropertyItems
        End Using
    End Function


    Private Sub SetLocationInfo(x As Double, y As Double)

        'WebサービスのURLを作成する
        Dim url = String.Format("http://geoapi.heartrails.com/api/xml?method=searchByGeoLocation&x={0}&y={1}", x, y)

        'URLへのRequestを生成
        Dim req = System.Net.WebRequest.Create(url)

        'Response取得
        Using res = req.GetResponse()
            'Stream取得
            Using stream = res.GetResponseStream
                ' 文字列として扱うためのStreamReader
                Using reader = New StreamReader(stream)

                    Dim xDoc = New XmlDocument

                    '結果XMLを読み込む
                    Dim xml = reader.ReadToEnd

                    'XMLを読み込む
                    xDoc.LoadXml(xml)

                    'ここのAPIでは緯度・経度による住所検索で、距離が近い順で１０件の住所結果が帰ってくる。
                    'なので、最初の location 要素（最も誤差が少ない）の住所情報を取得する

                    Dim location = xDoc.Item("response").Item("location")

                    'ロケーション情報が無い場合は情報をクリア
                    If location Is Nothing Then
                        _住所大区分 = ""
                        _住所中区分 = ""
                        _住所小区分 = ""
                        _距離誤差目安 = 0
                        _郵便番号 = ""
                    Else
                        _住所大区分 = location.Item("prefecture").InnerText
                        _住所中区分 = location.Item("city").InnerText
                        _住所小区分 = location.Item("town").InnerText
                        _距離誤差目安 = location.Item("distance").Value
                        _郵便番号 = location.Item("postal").Value
                    End If

                End Using
            End Using
        End Using


    End Sub





    Private Function GetCaptureLocation(ByVal filename As String) As ObjGPS
        ' Exif tags ID: GPSInfo = 0x8825
        'Exif GPS: http://www.sno.phy.queensu.ca/~phil/exiftool/TagNames/GPS.html
        Dim meta = GetExifTags(filename)

        ' 0x0001: 緯度の南北を示す文字 'N'→North 'S'→South
        'Dim 緯度南北Row = meta.Where(Function(p) p.Id = 1).First.Value
        'Dim 緯度南北 = Encoding.ASCII.GetString(緯度南北Row)

        ' 0x0002: 
        Dim 緯度Row = meta.Where(Function(p) p.Id = 2).First.Value
        Dim 緯度_度 = BitConverter.ToInt32(緯度Row, 0) / BitConverter.ToInt32(緯度Row, 4)
        Dim 緯度_分 = BitConverter.ToInt32(緯度Row, 8) / BitConverter.ToInt32(緯度Row, 12)
        Dim 緯度_秒 = BitConverter.ToInt32(緯度Row, 16) / BitConverter.ToInt32(緯度Row, 20)
        Dim 緯度_Dec = 緯度_度 + 緯度_分 / 60 + 緯度_秒 / 3600

        ' 0x0003: 経度の東西を表す文字 'W' West 'E' East
        'Dim 経度東西 = meta.Where(Function(p) p.Id = 3).First

        ' 0x0004
        Dim 経度Row = meta.Where(Function(p) p.Id = 4).First.Value
        Dim 経度_度 = BitConverter.ToInt32(経度Row, 0) / BitConverter.ToInt32(経度Row, 4)
        Dim 経度_分 = BitConverter.ToInt32(経度Row, 8) / BitConverter.ToInt32(経度Row, 12)
        Dim 経度_秒 = BitConverter.ToInt32(経度Row, 16) / BitConverter.ToInt32(経度Row, 20)
        Dim 経度_Dec = 経度_度 + 経度_分 / 60 + 経度_秒 / 3600


        'WebサービスのURLを作成する
        Dim url =
            String.Format(
                "http://geoapi.heartrails.com/api/xml?method=searchByGeoLocation&x={0}&y={1}",
                経度_Dec,
                緯度_Dec)

        'URLへのRequestを生成
        Dim req = System.Net.WebRequest.Create(url)

        'Response取得
        Using res = req.GetResponse()
            'Stream取得
            Using stream = res.GetResponseStream
                ' 文字列として扱うためのStreamReader
                Using reader = New StreamReader(stream)

                    Dim xDoc = New XmlDocument

                    '結果XMLを読み込む
                    Dim xml = reader.ReadToEnd

                    'XMLを読み込む
                    xDoc.LoadXml(xml)

                    'ここのAPIでは緯度・経度による住所検索で、距離が近い順で１０件の住所結果が帰ってくる。
                    'なので、最初の location 要素（最も誤差が少ない）の住所情報を取得する

                    Dim location = xDoc.Item("response").Item("location")

                    If location IsNot Nothing Then

                        Dim 都道府県 = location.Item("prefecture").InnerText
                        Dim 市区町村 = location.Item("city").InnerText
                        Dim 詳細 = location.Item("town").InnerText

                    End If

                End Using
            End Using
        End Using

        Return Nothing
    End Function


End Class
