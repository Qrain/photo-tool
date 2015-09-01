Imports System.Text
Imports System.IO

Public Class 整理ツール

#Region "１．大域変数の定義"

    '整理情報が不明な画像を分類する際のフォルダ名
    Private ReadOnly _UnknowImgDirName = "Unknown"

    'フォルダ区切り文字を取得
    Private ReadOnly _Sep As Char = System.IO.Path.DirectorySeparatorChar

#End Region

#Region "２．プロパティの定義"

#End Region

#Region "３．コンストラクターの定義"

#End Region

#Region "４．イベントの定義"

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        '画像比較クラスを生成
        Using imgCmp As New ImageComparator, imgInfo As New ImageInfo

            For Each sfile In files
                Try
                    'ファイルが存在しない、またはアクセス権限を持たない場合
                    If Not File.Exists(sfile) Then
                        cntAccErr += 1
                        Continue For
                    End If

                    'ImageInfoにファイル名を設定して情報を初期化
                    imgInfo.FileName = sfile

                    If Not imgInfo.IsImage Then
                        cntNotImg += 1
                        Continue For
                    End If

                    ' 同一画像の除去処理（コピーをスキップする）
                    If chk重複画像除去.Checked AndAlso imgCmp.Exist(sfile) Then
                        cntRedunImg += 1
                        Continue For
                    End If

                    'ファイル名部分を取得
                    Dim filename = Path.GetFileName(sfile)
                    Dim dfile = dpath '出力先のファイルパス

                    '必要情報を持っているフラグ
                    Dim hasNeededInfo = True

                    ' この画像に整理情報があるか判断する
                    Select Case cbx整理方法.SelectedIndex
                        Case 0, 1, 2 '撮影日時が必要
                            If imgInfo.CaptureDate = Nothing Then
                                hasNeededInfo = False
                            End If

                        Case 3, 4, 5 '撮影場所が必要
                            If imgInfo.CaptureLocation Is Nothing Then
                                hasNeededInfo = False
                            End If
                    End Select


                    If hasNeededInfo Then
                        '整理に必要な情報を持っている

                        If chk整理する.Checked Then
                            '整理フォルダパスを作成する
                            dfile &= GetDirName(imgInfo)
                        End If

                        cntHasExif += 1
                    Else
                        '撮影日時不明画像も整理する設定ならば専用フォルダ作成する
                        If chk整理する.Checked AndAlso chk不明分類.Checked Then
                            dfile &= _Sep & _UnknowImgDirName
                        End If

                        cntNotExif += 1
                    End If

                    '「フォルダ分類しない」または「リネームする」場合は日付を付ける
                    If Not chk整理する.Checked OrElse Not chkリネームしない.Checked Then
                        Dim prefix = ""

                        'どんな画像でも撮影日時があれば文字列をファイルプレフィックス文字列を取得
                        If imgInfo.CaptureDate <> Nothing Then
                            prefix = imgInfo.CaptureDate.ToString(tbx撮影日書式.Text.Trim)
                        End If

                        '既に同様のプレフィックスがついてるならリネームしない
                        If prefix <> "" AndAlso Not filename.StartsWith(prefix) Then
                            filename = prefix & filename
                        End If
                    End If

                    'フォルダパスとファイル名を連結し最終的なファイルパスにする
                    dfile &= _Sep & filename

                    '再帰的の場合、ファイル名が被ることがあるためユニークなファイルパスを取得
                    If chk再帰的.Checked Then
                        ' file.txt が既にあれば file1.txt とする
                        dfile = GetUniquePath(dfile, "")
                    End If

                    If imgInfo.CaptureDate <> Nothing AndAlso chk日付合成.Checked Then
                        '撮影日情報があり、なおかつ画像自体に日付を付けたい場合
                        画像に撮影日時を埋め込み保存(sfile, dfile, imgInfo.CaptureDate)
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
        End Using

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

    ''' <summary>
    ''' 現在選択されている整理タイプに応じたフォルダ名をImageInfoから取得します。
    ''' </summary>
    ''' <param name="info"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetDirName(ByVal info As ImageInfo) As String

        Dim ret As String = ""

        '整理フォルダパスを作成する
        Select Case cbx整理方法.SelectedIndex
            Case 0 '撮影年毎にフォルダに分ける
                ret &= _Sep & info.CaptureDate.ToString("yyyy")

            Case 1 '撮影年月毎にフォルダを分ける
                ret &= _Sep & info.CaptureDate.ToString("yyyy-MM")

            Case 2 '撮影年月毎、かつ階層的にフォルダを分ける
                ret &= _Sep & info.CaptureDate.ToString("yyyy")
                '0埋めなしの月表示 M を単独利用するため % 必要
                ret &= _Sep & info.CaptureDate.ToString("%M")

            Case 3 '撮影場所（大）都道府県
                ret &= _Sep & info.CaptureLocation.AddressL

            Case 4 '撮影場所（中）市区町村を含む
                ret &= _Sep & info.CaptureLocation.AddressL
                ret &= _Sep & info.CaptureLocation.AddressM

            Case 5 '撮影場所（小）それ以下の情報も含む
                ret &= _Sep & info.CaptureLocation.AddressL
                ret &= _Sep & info.CaptureLocation.AddressM
                ret &= _Sep & info.CaptureLocation.AddressS
        End Select

        Return ret

    End Function

    Private Sub SetVisible処理中(ByVal visible As Boolean)
        lbl進捗.Visible = visible
        pgb進捗.Visible = visible
        btn終了.Enabled = Not visible
        btn整理開始.Enabled = Not visible
    End Sub


    ''' <summary>
    ''' 画像に指定の日付（年月日）を合成して、指定のパスへと出力します。
    ''' </summary>
    ''' <param name="sfile"></param>
    ''' <param name="dfile"></param>
    ''' <param name="capDate"></param>
    ''' <remarks></remarks>
    Private Sub 画像に撮影日時を埋め込み保存(ByVal sfile As String, ByVal dfile As String, ByVal capDate As Date)

        'PrivateFontCollectionオブジェクトを作成
        Using img = Image.FromFile(sfile),
            g = Graphics.FromImage(img),
            pfc As New System.Drawing.Text.PrivateFontCollection(),
            bF As New SolidBrush(Color.FromArgb(200, Color.Orange)),
            bB As New SolidBrush(Color.FromArgb(100, Color.Black))
            'bB = 半透明のブラシを作成（影用）
            'bF = 半透明のブラシを作成（前景用）

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
            report.AppendLine(cntNotExif & "件の画像ファイルに整理情報が見つかりませんでした。")
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

#End Region

End Class