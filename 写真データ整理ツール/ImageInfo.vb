Imports System.IO

''' <summary>
''' 画像ファイルから情報を取得するためのクラスです。
''' このクラスのインスタンスは画像ファイルに対して1つ作成でき、使いまわせません。
''' </summary>
''' <remarks></remarks>
Public Class ImageInfo
    Implements IDisposable

    Private _FileName As String ' ファイル名
    Private _CaptureLocation As LocationInfo '区分毎に分割した住所
    Private _CaptureDate As Date '撮影日時


    '現在のファイル名に対応するビットマップイメージを格納する変数
    Private img As Image = Nothing

    'GPSキャッシュオブジェクト
    Private cache As New CacheGPS

    '画像のExifデータの取得を試行したか示すフラグ
    '１度でも試行すればTrue（何度も情報取得を試みてオーバーヘッドを増やさないため）
    Private doneCaptureDate As Boolean
    Private doneCaptureLocaton As Boolean

    ''' <summary>
    ''' 撮影日時を表すDateオブジェクトを参照します。撮影日時情報が無い場合は、常にNothingを返します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CaptureDate As Date
        Get
            If IsImage AndAlso _CaptureDate = Nothing AndAlso Not doneCaptureDate Then
                _CaptureDate = GetCaptureDate(img)
                doneCaptureDate = True
            End If

            Return _CaptureDate
        End Get
    End Property

    ''' <summary>
    ''' 撮影場所を表すオブジェクトを参照します。撮影場所情報が無い場合は、常にNothingを返します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CaptureLocation As LocationInfo
        Get
            If IsImage AndAlso _CaptureLocation Is Nothing AndAlso Not doneCaptureLocaton Then
                _CaptureLocation = GetCaptureLocation(img)
                doneCaptureLocaton = True
            End If

            Return _CaptureLocation
        End Get
    End Property


    ''' <summary>
    ''' このファイルが画像ならばTrueを返します。それ以外は、Falseを返します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsImage As Boolean
        Get
            Return img IsNot Nothing
        End Get
    End Property

    ''' <summary>
    ''' 画像ファイルのパスを参照または設定するプロパティです。
    ''' このクラスで唯一、変更できるプロパティです。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FileName As String
        Get
            Return _FileName
        End Get
        Set(val As String)

            If val <> _FileName Then

                If Not System.IO.File.Exists(val) Then
                    Throw New FileNotFoundException("存在しない、またはアクセスできないファイル: " & _FileName)
                End If

                _FileName = val

                '画像情報を初期化
                _CaptureDate = Nothing
                _CaptureLocation = Nothing
                ' フラグを初期化
                doneCaptureDate = False
                doneCaptureLocaton = False

                '前回のイメージオブジェクトを破棄
                If img IsNot Nothing Then
                    img.Dispose()
                End If

                ' IsImage プロパティは img が Nothingか否かで判断する
                Try
                    img = Image.FromFile(_FileName)
                Catch ex As Exception
                    img = Nothing
                End Try
            End If
        End Set
    End Property


    ''' <summary>
    ''' コンストラクター
    ''' </summary>
    ''' <param name="filename">画像ファイルパス</param>
    ''' <remarks></remarks>
    Public Sub New(filename As String)
        Me.FileName = filename
    End Sub

    Public Sub New()
    End Sub

    '画像ファイル判定関数２（ファイル存在チェックは行わず 引数の文字列だけで判断するため高速）
    'Private Function IsImageByExt(ByVal filename As String) As Boolean
    '    '拡張子を小文字に変換して取得
    '    Select Case Path.GetExtension(filename).ToLower
    '        Case ".jpeg", ".jpg", ".jpe", ".tiff", ".tif", ".hdp", ".wdp", ".jxr", ".bmp", ".gif", ".png", ".ico"
    '            '.Net の Image.fromFile() がサポートする画像フォーマットの拡張子
    '            Return True
    '        Case Else
    '            '未知の画像拡張子、または画像以外のファイル
    '            Return False
    '    End Select
    'End Function

    Private Function GetCaptureDate(ByVal img As Image) As Date
        ' Exif情報で「撮影日時」を格納するタグのIDは「0x9003」
        ' EXIF Tags: http://www.sno.phy.queensu.ca/~phil/exiftool/TagNames/EXIF.html
        Dim meta = img.PropertyItems.Where(Function(p) p.Id = &H9003)

        '撮影日時情報が無ければ Nothing を返す
        If meta.Count = 0 Then
            Return Nothing
        End If

        '撮影日時情報をDateに変換して返す
        Dim rawCapDate = meta.First.Value ' 生バイトデータ
        Dim strCapDate = System.Text.Encoding.ASCII.GetString(rawCapDate, 0, 19) '末尾のNUL文字除去
        'カルチャーに依存せず不変的な日付を取得するためのカルチャー
        Dim culture = System.Globalization.CultureInfo.InvariantCulture

        Return DateTime.ParseExact(strCapDate, "yyyy:MM:dd HH:mm:ss", culture)
    End Function

    ''' <summary>
    ''' 画像ファイルから位置情報を取得する。
    ''' </summary>
    ''' <param name="img">情報抽出元画像データ</param>
    ''' <returns>位置情報オブジェクト、画像に座標情報がない、または解決できない座標なら Nothing</returns>
    ''' <remarks></remarks>
    Private Function GetCaptureLocation(ByVal img As Image) As LocationInfo

        '24bytes のバイト配列から10進数にした緯度及び経度を取得する
        Dim bytes2XY =
            Function(bytes As Byte()) As Double
                '緯度と経度のデータはそれぞれ次のような形式になってる 
                ' Int32（4バイト） のデータが、 (度),(係数),(分),(係数),(秒),(係数)
                ' というように6つ続いており、合計で 4*6=24bytes ある。
                If bytes.Count = 24 Then
                    ' 度、分、秒を取得する。 ※精度が低い場合、秒が0の事が多い
                    Dim deg = BitConverter.ToInt32(bytes, 0) / BitConverter.ToInt32(bytes, 4)
                    Dim min = BitConverter.ToInt32(bytes, 8) / BitConverter.ToInt32(bytes, 12)
                    Dim sec = BitConverter.ToInt32(bytes, 16) / BitConverter.ToInt32(bytes, 20)
                    ' 分や秒は60進法なので10進法に変える
                    Return deg + min / 60 + sec / 3600
                End If

                Return Nothing
            End Function

        '画像のExifデータを取得
        'Exif GPS: http://www.sno.phy.queensu.ca/~phil/exiftool/TagNames/GPS.html
        Dim meta = img.PropertyItems

        ' 0x0002: 緯度を取得 → 地球横線 → Y座標
        Dim rawY = meta.Where(Function(p) p.Id = 2)

        ' 0x0004: 経度を取得 → 地球縦線 → X座標
        Dim rawX = meta.Where(Function(p) p.Id = 4)

        '位置情報が無ければリターン
        If rawY.Count = 0 OrElse rawX.Count = 0 Then
            Return Nothing
        End If

        '緯度・経度を表すバイト配列を10進の小数に変換する
        Dim decY = bytes2XY(rawY.First.Value)
        Dim decX = bytes2XY(rawX.First.Value)

        '緯度・経度のキャッシュを確認する処理

        ' キャッシュ機能を利用して座標を解決します
        Return cache.GetLocation(decX, decY)
    End Function


#Region "IDisposable Support"
    Private disposedValue As Boolean ' 重複する呼び出しを検出するには

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' .NET Framework で管理されたオブジェクトの破棄(マネージ オブジェクト)
                ' 最後のImageを破棄
                If img IsNot Nothing Then
                    img.Dispose()
                End If
            End If

            ' COMオブジェクトなど .NET Framework で管理されておらずOSが直接実行するオブジェクトを破棄します。
            ' (アンマネージ オブジェクトの破棄・開放)　その際は Finalize() をオーバーライドします。
            ' 大きなフィールドを hoge = Nothing とします
        End If
        Me.disposedValue = True
    End Sub

    ' このコードは、破棄可能なパターンを正しく実装できるように Visual Basic によって追加されました。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(disposing As Boolean) に記述します。
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
