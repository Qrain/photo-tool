﻿Imports System.Text
Imports System.IO
Imports System.Drawing.Imaging
Imports System.Security.Cryptography
Imports System.Xml
Imports System.Data.SQLite


Public Class 整理ツール２

#Region "１．大域変数の定義"

    '整理情報が不明な画像を分類する際のフォルダ名
    Private Const _UnknowImgDirName = "Unknown"

    'フォルダ区切り文字を取得
    Private ReadOnly _Sep As Char = System.IO.Path.DirectorySeparatorChar

    '画像比較クラスを生成
    Dim _ImgCmp As New FileComparator
#End Region

#Region "２．プロパティの定義"

#End Region

#Region "３．コンストラクターの定義"

#End Region

#Region "４．イベントの定義"


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Using ii As New ImageInfo

            Console.WriteLine(ii.IsImage)
            Console.WriteLine(ii.FileName)
            Console.WriteLine(ii.CaptureDate)

            Dim caploc = ii.CaptureLocation

            If caploc IsNot Nothing Then
                Console.WriteLine(caploc.AddressL)
                Console.WriteLine(caploc.AddressM)
                Console.WriteLine(caploc.AddressS)
                Console.WriteLine(caploc.Postal)
            End If
            
            'ファイル名を変換
            ii.FileName = "C:\Users\sawai\Downloads\flashplayer17axau_ra_install.exe"
            Console.WriteLine(ii.IsImage)
            Console.WriteLine(ii.FileName)
            Console.WriteLine(ii.CaptureDate)
        End Using


        Dim ax = New CacheGPS(CacheGPS.CacheType.DB_SQLite)



        'フォルダ選択ダイアログの初期化
        fbd.Description = "任意のフォルダを選択して下さい。"
        'ユーザーが新しいフォルダを作成できるようにする
        fbd.ShowNewFolderButton = True


        'プログレスバーの最小値初期化
        pgb進捗.Minimum = 0


        'テキストボックスにドロップを許可する
        tbx整理対象.AllowDrop = True
        tbx出力先.AllowDrop = True

        'コンボボックス初期化
        cbx整理方法.DropDownStyle = ComboBoxStyle.DropDownList
        cbx整理方法.Items.Add("撮影年ごと")
        cbx整理方法.Items.Add("撮影年月ごと")
        cbx整理方法.Items.Add("撮影年月ごと（階層）")
        cbx整理方法.Items.Add("撮影場所（大）")
        cbx整理方法.Items.Add("撮影場所（中）")
        cbx整理方法.Items.Add("撮影場所（小）")


        '前回の設定を復元処理
        chk重複画像除去.Checked = My.Settings.重複除去
        chk整理する.Checked = My.Settings.整理_する
        chk再帰的.Checked = My.Settings.再帰的処理
        tbx撮影日無し接頭字.Text = My.Settings.不明画像PF
        chkリネームしない.Checked = My.Settings.整理_リネーム
        cbx整理方法.SelectedIndex = My.Settings.整理_タイプ
        chk不明分類.Checked = My.Settings.整理_日時不明
        rbt任意場所.Checked = My.Settings.出力先_任意
        tbx撮影日書式.Text = My.Settings.撮影日書式
        chk日付合成.Checked = My.Settings.日付付与


        'グループボックスの初期化
        grp整理.Enabled = chk整理する.Checked

        'コントロールの表示状態を設定する
        SetVisible処理中(False)
    End Sub

    Private Sub 整理ツール改_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        'VB.NETの場合、 以下の設定内容は自動保存される
        My.Settings.重複除去 = chk重複画像除去.Checked
        My.Settings.再帰的処理 = chk再帰的.Checked
        My.Settings.不明画像PF = tbx撮影日無し接頭字.Text

        My.Settings.整理_する = chk整理する.Checked
        My.Settings.整理_リネーム = chkリネームしない.Checked
        My.Settings.整理_タイプ = cbx整理方法.SelectedIndex
        My.Settings.整理_日時不明 = chk不明分類.Checked

        My.Settings.出力先_任意 = rbt任意場所.Checked
        My.Settings.撮影日書式 = tbx撮影日書式.Text
        My.Settings.日付付与 = chk日付合成.Checked
    End Sub


    Private Sub rbt_CheckedChanged(sender As Object, e As EventArgs) Handles rbt同一フォルダ.CheckedChanged, rbt任意場所.CheckedChanged

        tbx出力先.Enabled = rbt任意場所.Checked
        btn出力先参照.Enabled = rbt任意場所.Checked
        lbl出力先.Enabled = rbt任意場所.Checked

    End Sub

    Private Sub btn整理対象参照_Click(sender As Object, e As EventArgs) Handles btn整理対象参照.Click

        '初期選択するフォルダを設定する
        fbd.SelectedPath = My.Settings.整理対象_パス

        '選択されたフォルダパスを設定
        If fbd.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            tbx整理対象.Text = fbd.SelectedPath
            '選択したフォルダパスを記録
            My.Settings.整理対象_パス = fbd.SelectedPath
        End If
    End Sub

    Private Sub btn出力先参照_Click(sender As Object, e As EventArgs) Handles btn出力先参照.Click

        '初期選択するフォルダを設定する
        fbd.SelectedPath = My.Settings.出力先_パス
        If fbd.ShowDialog() = DialogResult.OK Then
            tbx出力先.Text = fbd.SelectedPath
            My.Settings.出力先_パス = fbd.SelectedPath
        End If

    End Sub
    Private Sub btn終了_Click(sender As Object, e As EventArgs) Handles btn終了.Click
        Me.Close()
    End Sub

    Private Sub chk整理する_CheckedChanged(sender As Object, e As EventArgs) Handles chk整理する.CheckedChanged
        grp整理.Enabled = chk整理する.Checked
    End Sub



    Private Sub btn整理開始_Click(sender As Object, e As EventArgs) Handles btn整理開始.Click

        '入力情報をチェックする
        If Not CheckValue() Then
            Return
        End If


        '整理対象のフォルダパス
        Dim spath = tbx整理対象.Text.Trim

        '整理済みファイルの出力先パス（整理対象パスで初期化）
        Dim dpath = spath

        '任意の出力先の場合は、そのパスと整理対象フォルダ名を結合したパスを候補とする
        If rbt任意場所.Checked Then
            dpath = tbx出力先.Text.Trim & _Sep & spath.Split(_Sep).Last
        End If

        '出力先パスを検証し、既存ならばユニークなパスを新規生成
        dpath = GetUniquePath(dpath, "_")


        'ファイル名一覧を格納する配列
        Dim files() As String

        'ファイルパスリストを取得
        If chk再帰的.Checked Then '再帰的にサブフォルダーのファイルも取得
            files = System.IO.Directory.GetFiles(spath, "*", IO.SearchOption.AllDirectories)
        Else '直下ファイルのみ取得
            files = System.IO.Directory.GetFiles(spath, "*", IO.SearchOption.TopDirectoryOnly)
        End If

        pgb進捗.Maximum = files.Count
        pgb進捗.Value = 0


        '整理結果レポート用の各種カウンター
        ' cntAccErr:    何らかの理由でアクセスできなかったファイル数
        ' cntNotImg:    画像でないと判断されたファイル数
        ' cntHasExif:   整理に必要な情報を持っている画像数
        ' cntNotExif:   整理に必要な情報を持っていない画像数
        ' cntRedunImg:  重複画像と判断された画像数
        Dim cntNotImg, cntHasExif, cntNotExif, cntRedunImg, cntAccErr As Integer

        '処理中用のコントロール状態に設定
        SetVisible処理中(True)

        'ハッシュ記録をクリアする
        _ImgCmp.ClearHash()

        '取得したファイルリストに対して処理を行う
        For Each sfile In files
            Try
                'ファイルが存在しない、またはアクセス権限を持たない場合
                If Not File.Exists(sfile) Then
                    cntAccErr += 1
                    Continue For
                End If

                '対象ファイルが画像ファイルでない場合
                If Not IsImage2(sfile) Then
                    cntNotImg += 1
                    Continue For
                End If

                ' 同一画像の除去処理（コピーをスキップする）
                If chk重複画像除去.Checked AndAlso _ImgCmp.AlreadyPixels(sfile) Then
                    cntRedunImg += 1
                    Continue For
                End If

                'ファイル名部分を取得
                Dim filename = Path.GetFileName(sfile)
                Dim dfile = dpath '出力先のファイルパス
                Dim fPrefix = "" 'ファイル名のプレフィックス

                '写真の撮影日をDateで取得
                Dim 撮影日時 As Date = Nothing
                Dim 撮影場所 As String() = Nothing
                Dim is日付分類 As Boolean

                Select Case cbx整理方法.SelectedIndex
                    Case 0, 1, 2 '撮影日時が必要
                        撮影日時 = Get写真撮影日時(sfile)
                        is日付分類 = True
                    Case 3, 4, 5 '撮影場所が必要
                        撮影場所 = GetCaptureLocation(sfile)
                        is日付分類 = False
                End Select

                '整理に必要な情報を持たない場合
                If is日付分類 AndAlso 撮影日時 = Nothing OrElse
                    Not is日付分類 AndAlso 撮影場所 Is Nothing Then

                    '撮影日時不明画像も整理する設定ならば専用フォルダ作成する
                    If chk整理する.Checked AndAlso chk不明分類.Checked Then
                        dfile &= _Sep & _UnknowImgDirName
                    End If

                    '整理情報を持たない画像はリネームしない

                    'プレフィックス更新
                    'fPrefix = strNonExifPf
                    cntNotExif += 1

                Else '撮影日時情報を持つ画像の場合

                    'フォルダ整理する場合
                    If chk整理する.Checked Then
                        '整理フォルダパスを作成する
                        Select Case cbx整理方法.SelectedIndex
                            Case 0 '撮影年毎にフォルダに分ける
                                dfile &= _Sep & 撮影日時.ToString("yyyy")

                            Case 1 '撮影年月毎にフォルダを分ける
                                dfile &= _Sep & 撮影日時.ToString("yyyy-MM")

                            Case 2 '撮影年月毎、かつ階層的にフォルダを分ける
                                dfile &= _Sep & 撮影日時.ToString("yyyy")
                                '0埋めなしの月表示 M を単独利用するため % 必要
                                dfile &= _Sep & 撮影日時.ToString("%M")

                            Case 3 '撮影場所（大）都道府県
                                dfile &= _Sep & 撮影場所(0)

                            Case 4 '撮影場所（中）市区町村を含む
                                dfile &= _Sep & 撮影場所(0) & _Sep & 撮影場所(1)

                            Case 5 '撮影場所（小）それ以下の情報も含む
                                dfile &= _Sep & 撮影場所(0) & _Sep & 撮影場所(1) & _Sep & 撮影場所(2)
                        End Select
                    End If

                    'ファイル名プレフィックスを撮影日付で更新
                    fPrefix = 撮影日時.ToString(tbx撮影日書式.Text.Trim)

                    cntHasExif += 1
                End If

                '「フォルダ分類しない」または「リネームする」場合は日付を付ける
                If Not chk整理する.Checked OrElse Not chkリネームしない.Checked Then
                    '既に同様のプレフィックスがついてるならリネームしない
                    If fPrefix <> "" AndAlso Not filename.StartsWith(fPrefix) Then
                        filename = fPrefix & filename
                    End If
                End If

                'フォルダパスとファイル名を連結し最終的なファイルパスにする
                dfile &= _Sep & filename

                '再帰的の場合、ファイル名が被ることがあるためユニークなファイルパスを取得
                If chk再帰的.Checked Then
                    ' file.txt が既にあれば file1.txt とする
                    dfile = GetUniquePath(dfile, "")
                End If

                If 撮影日時 <> Nothing AndAlso chk日付合成.Checked Then
                    '撮影日情報があり、なおかつ画像自体に日付を付けたい場合
                    画像に撮影日時を埋め込み保存する(sfile, dfile, 撮影日時)
                Else
                    '画像ファイルを出力先にコピーする
                    My.Computer.FileSystem.CopyFile(sfile, dfile)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "予期せぬエラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '処理中状態を解除
                SetVisible処理中(False)
                Return

            Finally
                pgb進捗.Value += 1
                lbl進捗.Text = files.Count & "件中 " & pgb進捗.Value & "件 処理済"
                Application.DoEvents() 'ユーザ入力や他の処理を行うための処理
            End Try
        Next

        '整理結果レポートを作成し表示する
        DispReports(files.Count, cntHasExif, cntNotExif, cntNotImg, cntRedunImg, cntAccErr, dpath)

        '処理中状態を解除
        SetVisible処理中(False)
    End Sub


    Private Sub TextBox_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tbx整理対象.DragDrop, tbx出力先.DragDrop

        'パス配列（複数選択時など）を単一のパス文字列に変換
        Dim dirPath = CType(e.Data.GetData(DataFormats.FileDrop, False), String()).First

        'フォルダのときのみ設定する
        If Directory.Exists(dirPath) Then

            If sender Is tbx整理対象 Then
                tbx整理対象.Text = dirPath

            ElseIf sender Is tbx出力先 Then
                tbx出力先.Text = dirPath

            End If
        End If

    End Sub

    Private Sub TextBox_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tbx整理対象.DragEnter, tbx出力先.DragEnter
        'ファイル形式の場合のみ、ドラッグを受け付けます。
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

#End Region




#Region "５．その他の定義"

    Private Class StopWatchRap

        Private sw As New Stopwatch

        Public Sub _Start()
            sw.Reset()
            sw.Start()
        End Sub

        Private Sub _Stop()
            sw.Stop()
            Console.WriteLine("処理時間: " & sw.ElapsedMilliseconds & "ms")
        End Sub

    End Class



    Private Sub SetVisible処理中(ByVal visible As Boolean)
        lbl進捗.Visible = visible
        pgb進捗.Visible = visible
        btn終了.Enabled = Not visible
        btn整理開始.Enabled = Not visible
    End Sub


    Private Sub 画像に撮影日時を埋め込み保存する(ByVal sfile As String, ByVal dfile As String, ByVal capDate As Date)
        Using img = Image.FromFile(sfile)
            '画像のグラフィックオブジェクトを取得
            Using g = Graphics.FromImage(img)
                'PrivateFontCollectionオブジェクトを作成
                Using pfc As New System.Drawing.Text.PrivateFontCollection()
                    '半透明のブラシを作成（前景用）
                    Using bF As New SolidBrush(Color.FromArgb(200, Color.Orange))
                        '半透明のブラシを作成（影用）
                        Using bB As New SolidBrush(Color.FromArgb(100, Color.Black))

                            ' 画像高さの 1/14を基準にしてフォントサイズを計算する　
                            Dim fSize = img.Height / 14
                            ' ※フォントサイズ下限は 20px とする
                            fSize = If(fSize > 20, fSize, 20)

                            'PrivateFontCollectionにフォントを追加する
                            pfc.AddFontFile("Fonts\POCKC___.ttf") ' "..\..\Fonts\7LED.ttf"
                            'フォントを作成する
                            Dim f As New Font(pfc.Families.First, fSize, FontStyle.Regular, GraphicsUnit.Pixel)
                            Dim xx = img.Width - fSize * 5
                            Dim yy = img.Height - fSize * 1.5
                            Dim dn = fSize / 15
                            Dim str = capDate.ToString("yyyy.MM.dd")

                            ' 文字列を画像に書き込む
                            '背景（影の部分）
                            g.DrawString(str, f, bB, xx, yy)
                            '前景（前景はdnの分だけ左上にずらす）
                            g.DrawString(str, f, bF, xx - dn, yy - dn)

                            '保存先のフォルダが無い場合は作成する
                            If Not Directory.Exists(Path.GetDirectoryName(dfile)) Then
                                Directory.CreateDirectory(Path.GetDirectoryName(dfile))
                            End If

                            '出力先に保存する
                            img.Save(dfile)
                        End Using
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Sub DispReports(ByVal cntTotal As Integer,
                            ByVal cntHasExif As Integer,
                            ByVal cntNotExif As Integer,
                            ByVal cntNotImg As Integer,
                            ByVal cntRedunImg As Integer,
                            ByVal cntAccErr As Integer,
                            ByVal dpath As String)
        '整理結果レポートを作成
        Dim report As New StringBuilder

        report.AppendLine("全" & cntTotal & "件のファイル中、")

        If cntHasExif > 0 Then
            report.AppendLine(cntHasExif & "件の画像ファイルが正常に処理されました。")
        End If
        If cntNotExif > 0 Then
            report.AppendLine(cntNotExif & "件の画像ファイルにExif情報が見つかりませんでした。")
        End If
        If cntNotImg > 0 Then
            report.AppendLine(cntNotImg & "件の非画像ファイルを無視しました。")
        End If
        If cntRedunImg > 0 Then
            report.AppendLine(cntRedunImg & "件の重複画像がありました。")
        End If
        If cntAccErr > 0 Then
            report.AppendLine(cntAccErr & "件のファイルにアクセスできませんでした。")
        End If
        report.AppendLine()
        report.AppendLine("対象フォルダを開きますか？")

        'エクスプローラでフォルダを開く
        If MessageBox.Show(report.ToString, "整理結果", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            System.Diagnostics.Process.Start("EXPLORER.EXE", dpath)
        End If
    End Sub

    Private Function GetExifTagByID(ByVal filename As String, ByVal id As Integer) As PropertyItem

        Dim items = GetExifTags(filename).Where(Function(p) p.Id = id)

        If items.Count = 0 Then
            Return Nothing
        Else
            Return items.First
        End If
    End Function

    Private Function GetExifTags(ByVal filename As String) As IEnumerable(Of PropertyItem)
        Using img = Image.FromFile(filename)
            Return img.PropertyItems
        End Using
    End Function

    Private Function Get写真撮影日時(ByVal filename As String) As Date
        ' Exif情報で「撮影日時」を格納するタグのIDは「0x9003」
        ' EXIF Tags: http://www.sno.phy.queensu.ca/~phil/exiftool/TagNames/EXIF.html
        Dim meta = GetExifTagByID(filename, &H9003)

        '撮影日時情報が無ければ Nothing を返す
        If meta Is Nothing Then
            Return Nothing
        End If

        '撮影日時情報をDateに変換して返す
        Dim rawCapDate = meta.Value ' 生バイトデータ
        Dim strCapDate = System.Text.Encoding.ASCII.GetString(rawCapDate, 0, 19) '末尾のNUL文字除去
        'カルチャーに依存せず不変的な日付を取得するためのカルチャー
        Dim culture = System.Globalization.CultureInfo.InvariantCulture

        Return DateTime.ParseExact(strCapDate, "yyyy:MM:dd HH:mm:ss", culture)
    End Function

    ''' <summary>
    ''' 画像ファイルから位置情報を取得する。
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetCaptureLocation(ByVal filename As String) As String()

        '24バイトのバイト配列から10進数にした緯度及び経度を取得する
        Dim calc10LL =
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
        Dim meta = GetExifTags(filename)

        ' 0x0002: 緯度を取得
        Dim 緯度Row = meta.Where(Function(p) p.Id = 2)

        ' 0x0004: 経度を取得
        Dim 経度Row = meta.Where(Function(p) p.Id = 4)

        If 緯度Row.Count = 0 OrElse 経度Row.Count = 0 Then
            Return Nothing
        End If

        '緯度・経度を表すバイト配列を10進の小数に変換する
        Dim 緯度_Dec = calc10LL(緯度Row.First.Value)
        Dim 経度_Dec = calc10LL(経度Row.First.Value)

        '緯度・経度のキャッシュを確認する処理

        '
        ' Webリクエストはオーバーヘッドが大きいので結果をキャッシュすべき
        ' キャッシュある場合は、URLへアクセスしない
        ' 機能は未実装
        '

        'WebサービスのURLを作成する
        Dim url = String.Format("http://geoapi.heartrails.com/api/xml?method=searchByGeoLocation&x={0}&y={1}", 経度_Dec, 緯度_Dec)

        'URLへのRequestを生成
        Dim req = System.Net.WebRequest.Create(url)

        'Response取得
        Using res = req.GetResponse()
            'Stream取得
            Using stream = res.GetResponseStream
                ' 文字列として扱うためのStreamReader
                Using reader = New StreamReader(stream)

                    Dim xDoc = New XmlDocument

                    '文字列のXMLを XmlDocument に読み込む
                    xDoc.LoadXml(reader.ReadToEnd)

                    'ここのAPIでは緯度・経度による住所検索で、距離が近い順で１０件の住所結果が帰ってくる。
                    'なので、最初の location 要素（最も誤差が少ない）の住所情報を取得する
                    Dim location = xDoc.Item("response").Item("location")

                    If location Is Nothing Then
                        Return Nothing
                    End If

                    ' 位置情報があるなら、住所の大区分・中区分・小区分を配列で返す
                    Return New String() {
                        location.Item("prefecture").InnerText,
                        location.Item("city").InnerText,
                        location.Item("town").InnerText
                    }
                End Using
            End Using
        End Using
    End Function


    ''' <summary>
    ''' 入力値をチェックします。この関数がTrueを返却すれば、処理を開始できる事が保障されます。
    ''' </summary>
    ''' <returns>入力値に問題なければTrue、それ以外はFlase</returns>
    ''' <remarks></remarks>
    Private Function CheckValue()

        'MessageBoxパラメータ
        Dim cap = "入力チェック"
        Dim btn = MessageBoxButtons.OK
        Dim icn = MessageBoxIcon.Warning

        Dim target = tbx整理対象.Text.Trim

        'ファイル名として使用できない文字一覧
        Dim invFileChars = Path.GetInvalidFileNameChars

        If target = "" Then
            MessageBox.Show("整理対象フォルダが選択されていません。", cap, btn, icn)
            btn整理対象参照.Focus()
            Return False

        ElseIf Not System.IO.Directory.Exists(target) Then
            MessageBox.Show("整理対象フォルダ """ & target & """ は存在しません。", cap, btn, icn)
            btn整理対象参照.Focus()
            Return False

        ElseIf rbt任意場所.Checked Then

            Dim dest = tbx出力先.Text.Trim

            If dest = "" Then
                MessageBox.Show("出力先フォルダが選択されていません。", cap, btn, icn)
                btn出力先参照.Focus()
                Return False

            ElseIf Not System.IO.Directory.Exists(dest) Then
                MessageBox.Show("出力先フォルダ """ & dest & """ は存在しません。", cap, btn, icn)
                btn出力先参照.Focus()
                Return False
            End If

        ElseIf tbx撮影日無し接頭字.Text.Trim.IndexOfAny(invFileChars) >= 0 Then
            MessageBox.Show("撮影日不明画像のファイル名プレフィックスに無効な文字が含まれています。", cap, btn, icn)
            tbx撮影日無し接頭字.Focus()
            tbx撮影日無し接頭字.SelectionStart = tbx撮影日無し接頭字.Text.Trim.IndexOfAny(invFileChars)
            tbx撮影日無し接頭字.SelectionLength = 1
            Return False

        ElseIf tbx撮影日書式.Text.Trim = "" Then
            MessageBox.Show("撮影日形式を空に出来ません。", cap, btn, icn)
            tbx撮影日書式.Focus()
            Return False

        ElseIf tbx撮影日書式.Text.Trim.IndexOfAny(invFileChars) >= 0 Then
            MessageBox.Show("撮影日書式に無効な文字が含まれています。", cap, btn, icn)
            '当該項目にフォーカスし、無効文字を1文字選択状態にする
            tbx撮影日書式.Focus()
            tbx撮影日書式.SelectionStart = tbx撮影日書式.Text.Trim.IndexOfAny(invFileChars)
            tbx撮影日書式.SelectionLength = 1
            Return False
        End If

        Return True

    End Function


    ''' <summary>
    ''' 唯一のパスを返します。
    ''' フォルダまたはファイルが存在しない場合に限り、このメソッドは引数パスをそのまま返します。
    ''' そうでない場合は、パスに対して連番を付けた唯一のパスを作成し返します。   
    '''  </summary>
    ''' <param name="path">検証パス</param>
    ''' <param name="pad">「フォルダまたはファイル名」と「連番」の間を埋める文字列</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetUniquePath(ByVal path As String, ByVal pad As String) As String

        Dim sep = System.IO.Path.DirectorySeparatorChar
        Dim newpath = path, i = 1

        If System.IO.File.Exists(path) Then
            '拡張子を取得
            Dim ext = System.IO.Path.GetExtension(path)
            '拡張子を除いたファイル名を取得
            Dim fwe = System.IO.Path.GetFileNameWithoutExtension(path)
            '親ディレクトリをパス取得
            Dim dir = System.IO.Path.GetDirectoryName(path)

            '指定のフォルダが存在する間、新たなファルダ名を作り続ける
            Do
                newpath = dir & sep & fwe & pad & i & ext
                i += 1
            Loop While System.IO.File.Exists(newpath)

        ElseIf System.IO.Directory.Exists(path) Then

            '指定のフォルダが存在する間、新たなファルダ名を作り続ける
            Do
                newpath = path & pad & i
                i += 1
            Loop While System.IO.Directory.Exists(newpath)

        End If

        'ファイル・フォルダどちらとも存在しないパスならばそのまま返すことになる
        Return newpath

    End Function


    '画像ファイル判定関数２（ファイル存在チェックは行わず 引数の文字列だけで判断するため高速）
    Private Function IsImage2(ByVal filename As String) As Boolean
        '拡張子を小文字に変換して取得
        Select Case Path.GetExtension(filename).ToLower
            Case ".jpeg",
                 ".jpg",
                 ".jpe",
                 ".tiff",
                 ".tif",
                 ".hdp",
                 ".wdp",
                 ".jxr",
                 ".bmp",
                 ".gif",
                 ".png",
                 ".ico"
                '.Net の Image.fromFile() がサポートする画像フォーマットの拡張子
                Return True

            Case Else
                '未知の画像拡張子、または画像以外のファイル
                Return False
        End Select
    End Function

#End Region



End Class



''' <summary>
''' 画像ファイルから情報を取得するためのクラスです。
''' このクラスのインスタンスは画像ファイルに対して1つ作成でき、使いまわせません。
''' </summary>
''' <remarks></remarks>
Class ImageInfo
    Implements IDisposable


    '位置情報のクラス
    Class LocationInfo
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

    Private _FileName As String ' ファイル名
    Private _CaptureLocation As LocationInfo '区分毎に分割した住所
    Private _CaptureDate As Date '撮影日時


    '現在のファイル名に対応するビットマップイメージを格納する変数
    Private img As Image = Nothing

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

    Private Function IsImageByAccess(ByVal filename As String) As Boolean
        Try
            Using img = Image.FromFile(filename)

                Return True
            End Using
        Catch e As Exception ' ～ ↓ 以下の例外を含む ↓ ～
            'OutOfMemoryException: 画像ファイルではない場合
            'FileNotFoundException: ファイルが存在しない場合
            'ArgumentException: filename が URI 形式の場合
            Return False
        End Try
    End Function

    '画像ファイル判定関数２（ファイル存在チェックは行わず 引数の文字列だけで判断するため高速）
    Private Function IsImageByExt(ByVal filename As String) As Boolean
        '拡張子を小文字に変換して取得
        Select Case Path.GetExtension(filename).ToLower
            Case ".jpeg", ".jpg", ".jpe", ".tiff", ".tif", ".hdp", ".wdp", ".jxr", ".bmp", ".gif", ".png", ".ico"
                '.Net の Image.fromFile() がサポートする画像フォーマットの拡張子
                Return True
            Case Else
                '未知の画像拡張子、または画像以外のファイル
                Return False
        End Select
    End Function

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
    ''' <returns>位置情報オブジェクト</returns>
    ''' <remarks></remarks>
    Private Function GetCaptureLocation(ByVal img As Image) As LocationInfo

        '24バイトのバイト配列から10進数にした緯度及び経度を取得する
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

        '
        ' Webリクエストはオーバーヘッドが大きいので結果をキャッシュすべき
        ' キャッシュある場合は、URLへアクセスしない
        ' 機能は未実装
        '

        'WebサービスのURLを作成する
        Dim url = String.Format("http://geoapi.heartrails.com/api/xml?method=searchByGeoLocation&x={0}&y={1}", decX, decY)

        'URLへのRequestを生成
        Dim req = System.Net.WebRequest.Create(url)

        'Response取得
        Using res = req.GetResponse()
            'Stream取得
            Using stream = res.GetResponseStream
                ' 文字列として扱うためのStreamReader
                Using reader = New StreamReader(stream)

                    Dim xDoc = New XmlDocument

                    '文字列のXMLを XmlDocument に読み込む
                    xDoc.LoadXml(reader.ReadToEnd)

                    'ここのAPIでは緯度・経度による住所検索で、距離が近い順で１０件の住所結果が帰ってくる。
                    'なので、最初の location 要素（最も誤差が少ない）の住所情報を取得する
                    Dim location = xDoc.Item("response").Item("location")

                    If location Is Nothing Then
                        Return Nothing
                    End If

                    ' 位置情報があるなら、位置情報オブジェクトを返す
                    Return New LocationInfo(decX,
                                            decY,
                                            CDbl(location.Item("distance").InnerText),
                                            location.Item("prefecture").InnerText,
                                            location.Item("city").InnerText,
                                            location.Item("town").InnerText,
                                            "",
                                            location.Item("postal").InnerText)
                End Using
            End Using
        End Using
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
