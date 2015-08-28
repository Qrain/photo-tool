Imports System.Security.Cryptography

''' <summary>
''' ハッシュ値を利用してファイルを比較するためのクラスです。
''' </summary>
''' <remarks></remarks>
Public Class FileComparator

    '処理済のハッシュ値を格納するリスト
    Private hashs As New List(Of String)
    Private sha256 As SHA256 = SHA256Managed.Create()
    Private md5 As New MD5CryptoServiceProvider

    ''' <summary>
    ''' プログラムが同一と判断した画像ファイルが、既に存在するかどうか判断します。
    ''' この関数に渡すファイル名のファイルは画像のみ有効です。
    ''' </summary>
    ''' <param name="file">ファイルパス</param>
    ''' <returns>指定ファイルのハッシュ値がハッシュ値リストにある場合はTrue、無ければFalse</returns>
    ''' <remarks></remarks>
    Public Function AlreadyPixels(ByVal file As String) As Boolean

        'ピクセルデータでハッシュ計算
        Dim hash = GetHashByPixel(file)

        If hash Is Nothing Then 'ファイルが画像で無い場合などは常に False を返す
            Return False

        ElseIf hashs.Contains(hash) Then '既存の場合
            Return True

        Else '含まれていなければ登録して False
            hashs.Add(hash)
            Return False
        End If
    End Function


    Public Function AlreadyFileData(ByVal filename As String) As Boolean

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
            Dim strHash = ""
            For Each b In hashValue
                strHash &= b.ToString("X2")
            Next

            Return strHash
        End Using
    End Function

    ''' <summary>
    ''' ビットマップ画像のピクセルデータのみを対象としてハッシュ値を計算します。
    ''' そのため、Exifなどのメタ情報を変更しても、ハッシュ値は変わりません。
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <returns>指定された画像のピクセル情報から計算したMD5ハッシュ、
    ''' ファイルが画像で無い場合はNothing</returns>
    ''' <remarks></remarks>
    Private Function GetHashByPixel(ByVal filename As String) As String

        '画像ファイルのピクセル情報を取得する
        Dim pxs = GetImagePixels(filename)

        If pxs Is Nothing Then
            Return Nothing
        End If

        'MD5でハッシュを計算する
        Dim hashValue = md5.ComputeHash(pxs)

        '文字列変換
        Dim strHash = ""
        For Each byt In hashValue
            strHash &= byt.ToString("X2")
        Next

        Return strHash
    End Function


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


