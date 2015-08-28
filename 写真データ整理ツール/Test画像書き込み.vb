Public Class Test画像書き込み



    Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。



        Dim img As Image = Nothing

        AddHandler MyBase.Load,
            Sub(s, e)
                '"C:\Users\sawai\Downloads\kako-GXUYNvQVMM9hgdKG.jpe"
                '"C:\Users\sawai\Downloads\xuEgDLZfVlsEFwp_3Es7T_85.jpeg"
                '"C:\Users\sawai\Downloads\56984.jpg"
                '"C:\Users\sawai\Downloads\11656_00.jpg"
                '"C:\Users\sawai\Downloads\bengal_cat_6_cool_hd.jpg"
                img = Image.FromFile("C:\Users\sawai\Downloads\56984.jpg")

                'PrivateFontCollectionオブジェクトを作成する
                Dim pfc As New System.Drawing.Text.PrivateFontCollection()
                'PrivateFontCollectionにフォントを追加する
                'pfc.AddFontFile("..\..\Fonts\7LED.ttf")
                pfc.AddFontFile("..\..\Fonts\POCKC___.ttf")
                '
                'pfc.AddFontFile("C:\Users\sawai\Desktop\写真データ整理ツール_latest\写真データ整理ツール\Let's go Digital Regular.ttf")

                Me.ClientSize = img.Size

                '読み込んだ画像を設定
                PictureBox1.Image = img

                '画像のグラフィックオブジェクトを取得
                Dim g = Graphics.FromImage(img)
                Dim fSize As Single = img.Height / 14  ' 画像高さの 16分の1位をきじゅんにする　

                '最低20px以上とする
                fSize = If(fSize > 20, fSize, 20)

                'Dim f As New Font("Consolas", fSize, FontStyle.Regular, GraphicsUnit.Pixel)
                Dim f As New Font(pfc.Families.First, fSize, FontStyle.Regular, GraphicsUnit.Pixel)


                '半透明のブラシを作成
                Dim bF As New SolidBrush(Color.FromArgb(200, Color.Orange))
                Dim bB As New SolidBrush(Color.FromArgb(100, Color.Black))

                img.Save("")

                ' 文字列を画像に書き込む
                '影の部分
                Dim xx = img.Width - fSize * 5
                Dim yy = img.Height - fSize * 1.5
                Dim dn = fSize / 15
                Dim str = Today.ToString("yyyy.MM.dd")
                g.DrawString(str, f, bB, xx, yy)
                '前景の部分（フォントサイズの1/10 位ずらす）
                g.DrawString(str, f, bF, xx - dn, yy - dn)

                bB.Dispose()
                bF.Dispose()

                f.Dispose()
                pfc.Dispose()
                g.Dispose()

            End Sub


        AddHandler MyBase.FormClosed,
            Sub(s, e)
                If img IsNot Nothing Then
                    img.Dispose()
                End If
            End Sub
    End Sub




End Class