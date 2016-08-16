Imports System.Drawing
Imports System.Windows.Forms

Public Class SharedFunctions



    Private Shared Sub CopyFile(ByVal vstrSrc As String, ByVal vstrDst As String, Optional ByVal isWebSize As Boolean = False)
        ' 区切り文字 "/" をWindows用の "\" に置換する
        vstrSrc = vstrSrc.Replace("/", "\")
        vstrDst = vstrDst.Replace("/", "\")
        '
        If isWebSize Then
            ' Web用画像なので適宜スケーリングなどする
            Dim size横 As New Size(400, 300)
            Dim size縦 As New Size(225, 300)
            '
            Using origin As New Bitmap(vstrSrc)
                ' オリジナル画像のアスペクト比
                Dim originAspe As Double = origin.Width / origin.Height
                ' アスペクト比から横長か縦長画像か判定し規定サイズを定める
                Dim size As Size = If(originAspe > 1, size横, size縦)
                ' 規定サイズのアスペクト比
                Dim aspe As Double = size.Width / size.Height
                ' 
                Using canvas As New Bitmap(size.Width, size.Height), g = Graphics.FromImage(canvas)
                    ' スケーリング品質を設定する http://bit.ly/29OVXlS
                    g.InterpolationMode = Drawing2D.InterpolationMode.High

                    If originAspe = aspe Then
                        ' 同アスペクト比なのでリサイズのみでOK
                        g.DrawImage(origin, 0, 0, size.Width, size.Height)
                    Else
                        ' トリミング後のリサイズが必要
                        '
                        Dim トリミング領域 As Rectangle
                        ' トリミングする領域を計算する
                        If originAspe > aspe Then
                            ' 目的比より大きい（幅広）なら左右カット
                            Dim 正規幅 As Double = origin.Height * aspe
                            トリミング領域 = New Rectangle((origin.Width - 正規幅) / 2, 0, 正規幅, origin.Height)
                        Else
                            ' 目的比以下（幅狭）なら上下カット
                            Dim 正規高 As Double = origin.Width / aspe
                            トリミング領域 = New Rectangle(0, (origin.Height - 正規高) / 2, origin.Width, 正規高)
                        End If
                        '
                        ' アスペクト比を修正してトリミングした画像を規定サイズにする
                        Using resized = origin.Clone(トリミング領域, origin.PixelFormat)
                            g.DrawImage(resized, 0, 0, size.Width, size.Height)
                        End Using
                    End If
                    ' JPEGとして保存
                    canvas.Save(vstrDst, Imaging.ImageFormat.Jpeg)
                End Using
            End Using
        Else
            ' オリジナル画像ならば従来の処理を行う
            ' 上書きコピーを実行する
            My.Computer.FileSystem.CopyFile(vstrSrc, vstrDst, True)
        End If
    End Sub


    Public Function SaveImage(ByVal img As Bitmap, ByVal filename As String) As Boolean
        Try
            ' 区切り文字 "/" をWindows用の "\" に置換する
            filename = filename.Replace("/", "\")
            Dim dir As String = IO.Path.GetDirectoryName(filename)
            ' 対象フォルダが存在しなければ作成する
            If Not IO.Directory.Exists(dir) Then
                IO.Directory.CreateDirectory(dir)
            End If
            ' 新たなBitmapを生成してJPEGとして指定先に保存する
            Using tmp = New Bitmap(img)
                tmp.Save(filename, Imaging.ImageFormat.Jpeg)
            End Using
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 指定したファイルをロックせずにSystem.Drawing.Imageオブジェクトを作成します。
    ''' </summary>
    ''' <param name="filename">作成元の画像ファイルパス</param>
    ''' <returns>Imageオブジェクト</returns>
    Public Function CreateImage(ByVal filename As String) As Image
        Using fs As New IO.FileStream(filename, IO.FileMode.Open, IO.FileAccess.Read)
            Return Image.FromStream(fs)
        End Using
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="origin">画像合成元の画像</param>
    ''' <param name="vstrOverlayPath">上に重ねる画像のパス</param>
    ''' <returns></returns>
    Public Function Get合成画像(ByVal origin As Image, ByVal vstrOverlayPath As String) As Image
        Try
            'origin = origin.Clone
            ' グラフィック用オブジェクトを生成
            Using g = Graphics.FromImage(origin), overlay As New Bitmap(vstrOverlayPath)
                'overlay As Image = CreateImage(vstrOverlayPath)
                ' 高品質な画像合成
                g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                ' 右下に表示するため、X,Y座標はそれぞれ画像の差で求める
                g.DrawImage(overlay, origin.Width - overlay.Width, origin.Height - overlay.Height, overlay.Width, overlay.Height)
                Return origin
            End Using
        Catch ex As Exception
            MessageBox.Show("画像合成処理を行う際に以下のエラーが発生しました。" & vbCrLf & vbCrLf & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 【汎用レベル中】
    ''' 指定されたパスが示す画像を、既定のサイズにリサイズ及びトリミングして返します。
    ''' </summary>
    ''' <param name="vstrSrc"></param>
    ''' <returns></returns>
    Public Function GetWebImage(ByVal vstrSrc As String) As Image
        ' ↓規定サイズ
        Dim size横 As New Size(400, 300)
        Dim size縦 As New Size(225, 300)
        ' Usingブロック後は実ファイルのロックは開放される
        Using origin As New Bitmap(vstrSrc) 'DirectCast(CreateImage(vstrSrc), Bitmap)
            ' オリジナル画像のアスペクト比から横長か縦長画像か判定し規定サイズを定める
            Dim size As Size = If(origin.Width / origin.Height > 1, size横, size縦)
            ' 指定サイズと同一サイズならばスケーリング処理しないで返す
            If origin.Size = size Then
                Return New Bitmap(origin)
            End If
            ' イメージオブジェクトを返す
            Return ScaledAndTrimedImage(origin, size)
        End Using
    End Function

    ''' <summary>
    ''' 渡されたイメージオブジェクトを指定のサイズ内に収めます。
    ''' 短型を指定サイズにフィットするようスケーリングした後にはみ出た部分を適切にトリミングします。
    ''' </summary>
    ''' <param name="origin"></param>
    ''' <param name="size"></param>
    ''' <returns></returns>
    Public Function ScaledAndTrimedImage(ByVal origin As Bitmap, ByVal size As Size) As Image
        ' オリジナル画像のアスペクト比
        Dim originAspe As Double = origin.Width / origin.Height
        ' アスペクト比から横長か縦長画像か判定し規定サイズを定める
        ' 規定サイズのアスペクト比
        Dim aspe As Double = size.Width / size.Height
        Dim canvas As New Bitmap(size.Width, size.Height)
        '
        Using g = Graphics.FromImage(canvas)
            ' スケーリング品質を設定する http://bit.ly/29OVXlS
            g.InterpolationMode = Drawing2D.InterpolationMode.High
            '
            If originAspe = aspe Then
                ' 同アスペクト比なのでリサイズのみでOK
                g.DrawImage(origin, 0, 0, size.Width, size.Height)
            Else
                ' トリミング後のリサイズが必要
                Dim トリミング領域 As Rectangle
                ' トリミングする領域を計算する
                If originAspe > aspe Then
                    ' 目的比より大きい（幅広）なら左右カット
                    Dim 正規幅 As Double = origin.Height * aspe
                    トリミング領域 = New Rectangle((origin.Width - 正規幅) / 2, 0, 正規幅, origin.Height)
                Else
                    ' 目的比以下（幅狭）なら上下カット
                    Dim 正規高 As Double = origin.Width / aspe
                    トリミング領域 = New Rectangle(0, (origin.Height - 正規高) / 2, origin.Width, 正規高)
                End If
                ' アスペクト比を修正してトリミングした画像を規定サイズにする
                Using resized = origin.Clone(トリミング領域, origin.PixelFormat)
                    g.DrawImage(resized, 0, 0, size.Width, size.Height)
                End Using
            End If
            Return canvas
        End Using
    End Function

    Public Function CheckWebImageSize(ByVal filename As String) As Boolean
        ' ※Web用画像の下限サイズ判断を追加
        Using img As New Bitmap(filename)
            ' 横長、縦長によって下限サイズが異なる
            Dim size As Size = If(img.Width / img.Height > 1, New Size(400, 300), New Size(255, 300))
            ' 幅、高さどちらか一方でも下限サイズ未満ならばFalseになる
            Return img.Width >= size.Width AndAlso img.Height >= size.Height
        End Using
    End Function

End Class
