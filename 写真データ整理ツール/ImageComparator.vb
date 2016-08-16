Imports System.Security.Cryptography
Imports CommonLibs.Utlis

''' <summary>
''' ハッシュ値を利用してファイルを比較するためのクラスです。
''' </summary>
''' <remarks></remarks>
Public Class FileComparator
    Implements IDisposable

    '処理済のハッシュ値を格納するリスト
    Protected hashs As New List(Of String)
    'ハッシュ関数提供オブジェクトを初期化
    Protected sha256 As SHA256 = System.Security.Cryptography.SHA256Managed.Create()
    Protected md5 As MD5 = System.Security.Cryptography.MD5.Create


    ''' <summary>
    ''' ファイルが持つ全てのデータを対象にハッシュ値を計算します。
    ''' そのため、Exifなどのメタ情報を変更するとハッシュ値も変わります。
    ''' ※ただし、ファイルシステムで管理している「更新日時」「作成日時」などが変わってもハッシュ値は変わりません。
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function Exist(ByVal filename As String) As Boolean

        'ファイル全体でハッシュを計算
        Dim hash As String = GetHashByFile(filename)

        If hashs.Contains(hash) Then
            Return True
        Else
            '含まれていなければ登録する
            hashs.Add(hash)
            Return False
        End If

    End Function


    ''' <summary>
    ''' 保持しているハッシュ値記録をクリアします。
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearHash()
        hashs.Clear()
    End Sub

    ''' <summary>
    ''' ファイルが持つ全てのデータを対象にハッシュ値を計算します。
    ''' そのため、Exifなどのメタ情報を変更するとハッシュ値も変わります。
    ''' ※ただし、ファイルシステムで管理している「更新日時」「作成日時」などが変わってもハッシュ値は変わりません。
    ''' </summary>
    ''' <param name="file"></param>
    ''' <param name="useSHA256"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetHashByFile(ByVal file As String, Optional ByVal useSHA256 As Boolean = False) As String
        'ファイルストリームからハッシュ値を計算
        Using stm = My.Computer.FileSystem.GetFileInfo(file).OpenRead()

            stm.Position = 0

            Dim hashValue() As Byte

            If useSHA256 Then
                ' SHA256 によるハッシュ値を計算します。
                ' MD5のようにハッシュ衝突が起こるようなデータお作成は困難であり、セキュリティ強度が高い
                hashValue = sha256.ComputeHash(stm)
            Else
                ' MD5 によるハッシュ値を計算します
                ' ハッシュ衝突が起きるデータを故意に作る方法が見つかっているため、
                ' パスワードや認証機能などセキュリティ関連に利用することは厳禁です。
                ' ただ、データ比較や検索用のキャッシュなどに利用する分には問題なく、
                ' SHA256と比べて、半分以下の時間でハッシュを計算できます。
                hashValue = md5.ComputeHash(stm)
            End If

            '文字列変換
            Return hashValue.exByte2HexString
        End Using
    End Function


#Region "IDisposable Support"
    Private disposedValue As Boolean ' 重複する呼び出しを検出するには

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                md5.Clear()
                sha256.Clear()
            End If
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


''' <summary>
''' 画像ファイルの重複の有無に特化したクラスです。
''' </summary>
''' <remarks></remarks>
Public Class ImageComparator
    Inherits FileComparator

    ''' <summary>
    ''' 画像のピクセル情報をバイト配列として取得します。この処理は LockBits による高速な方法です。
    ''' </summary>
    ''' <param name="filename">画像ファイルパス</param>
    ''' <returns>
    ''' ピクセル情報を格納したバイト配列、ファイルパスが画像以外のファイルを示した場合、
    ''' または何らかのエラーが発生した場合は Nothing
    ''' </returns>
    ''' <remarks></remarks>
    Private Function GetImagePixels(ByVal filename As String) As Byte()
        Try
            Using bmp = DirectCast(Image.FromFile(filename), Bitmap)

                ' Bitmap.LockBits: https://msdn.microsoft.com/ja-jp/library/5ey6h79d.aspx
                'ビットマップデータをメモリにロックする
                Dim bmpData = bmp.LockBits(New Rectangle(0, 0, bmp.Width, bmp.Height),
                                           Drawing.Imaging.ImageLockMode.ReadOnly,
                                           bmp.PixelFormat)

                ' 最初のピクセルデータのメモリアドレスを取得する
                Dim ptr As IntPtr = bmpData.Scan0

                ' ピクセルデータを格納するバイト配列を用意する
                Dim bytes As Integer = Math.Abs(bmpData.Stride) * bmp.Height
                Dim rgbs(bytes - 1) As Byte

                ' 画像ピクセルデータをバイト配列にコピーする
                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbs, 0, bytes)

                ' メモリロックを解除する
                bmp.UnlockBits(bmpData)

                Return rgbs
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' プログラムが同一と判断した画像ファイルが、既に存在するかどうか判断します。
    ''' この関数に渡すファイル名のファイルは画像のみ有効です。
    ''' 重複の判断は画像のピクセルデータのみを対象に行うので、
    ''' Exifなどのメタ情報を変更しても、ハッシュ値は変わりません。
    ''' </summary>
    ''' <param name="filename">ファイルパス</param>
    ''' <returns>指定ファイルのハッシュ値がハッシュ値リストにある場合はTrue、無ければFalse</returns>
    ''' <remarks></remarks>
    Public Overrides Function Exist(ByVal filename As String) As Boolean

        '画像ファイルのピクセル情報を取得する
        Dim pxs = GetImagePixels(filename)

        If pxs Is Nothing OrElse pxs.Count = 0 Then
            Return False
        End If

        'ピクセルデータからMD5ハッシュを計算し、文字列化する
        Dim hash = md5.ComputeHash(pxs).exByte2HexString

        If hashs.Contains(hash) Then '既存の場合
            Return True

        Else '含まれていなければ基底クラスのハッシュリストに登録して False
            hashs.Add(hash)
            Return False
        End If

    End Function

    'Private Function GetImagePixelData(ByVal path As String) As Byte()
    '    Using img = Image.FromFile(path)
    '        Dim bmp = DirectCast(img, Bitmap)
    '        '以下、正攻法だが遅いやり方
    '        '1ピクセルにはRGBで3バイト必要なため
    '        Dim rgbs(bmp.Width * bmp.Height * 3 - 1) As Byte
    '        For y = 1 To bmp.Height
    '            For x = 1 To bmp.Width
    '                With bmp.GetPixel(x - 1, y - 1)
    '                    'Blue
    '                    rgbs(y * x * 3 - 3) = .B
    '                    'Green
    '                    rgbs(y * x * 3 - 2) = .G
    '                    'Red
    '                    rgbs(y * x * 3 - 1) = .R
    '                End With
    '            Next
    '        Next
    '        Return rgbs
    '    End Using
    'End Function
End Class