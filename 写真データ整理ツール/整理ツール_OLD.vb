Imports System.Text
Imports System.IO
Imports System.Drawing.Imaging
Imports System.Security.Cryptography

Public Class 整理ツール１

    Private _SW As New Stopwatch

    Private Sub SwStart()
        _SW.Reset()
        _SW.Start()
    End Sub

    Private Sub SwStop()
        _SW.Stop()
        Console.WriteLine("処理時間: " & _SW.ElapsedMilliseconds & "ms")
    End Sub



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Dim file1 = "C:\Users\sawai\Pictures\整理対象フォルダ（階層）\none_Tulips.jpg"
        'Dim file2 = "C:\Users\sawai\Pictures\整理対象フォルダ（階層）\none_Tulips - コピー.jpg"
        'Dim imgCmp As New FileComparator

        'Dim d = GetImageSerialNumber(file1)

        'SwStart()
        'Dim px1 = imgCmp.GetImagePixelDataLate("C:\Users\sawai\Pictures\整理対象フォルダ\exif_019.JPG")
        'SwStop()

        'SwStart()
        'Dim px2 = imgCmp.GetImagePixelDataFirst("C:\Users\sawai\Pictures\整理対象フォルダ\exif_019.JPG")
        'SwStop()
        'Console.WriteLine(px1.SequenceEqual(px2))


        fbd対象フォルダ.Description = "整理する写真データのあるフォルダを選択してください。"

        'デフォルトフォルダをマイピクチャに設定
        fbd対象フォルダ.RootFolder = Environment.SpecialFolder.UserProfile
        '最初に選択するフォルダを指定する
        'RootFolder以下にあるフォルダである必要がある
        fbd対象フォルダ.SelectedPath = Environment.SpecialFolder.MyPictures
        'ユーザーが新しいフォルダを作成できるようにする
        'デフォルトでTrue
        fbd対象フォルダ.ShowNewFolderButton = True


        'プログレスバーの最小値初期化
        pgb進捗.Minimum = 0
        pgb進捗.Visible = False

        'デフォルトで複製するにチェック
        chk複製する.Checked = True

        'デフォルトで同一整理対象フォルダと同じ場所に複製
        rbt同一フォルダ.Checked = True

        cbx整理方法.DropDownStyle = ComboBoxStyle.DropDownList
        cbx整理方法.Items.Add("撮影日（年ごと）")
        cbx整理方法.Items.Add("撮影日（年月ごと）")
        'cbx整理方法.Items.Add("撮影場所（大）")
        cbx整理方法.SelectedIndex = 0

        'デフォルトで再帰的に検索しない
        chk再帰的.Checked = False

        grp整理.Enabled = chk整理する.Checked

        tbx撮影日不明Prefix.Text = "none"

        chk重複画像除去.Checked = True
        rbt重複判定高速.Checked = True

    End Sub

    Private Sub btn終了_Click(sender As Object, e As EventArgs) Handles btn終了.Click

        Me.Close()

    End Sub

    Private Sub btn整理開始_Click(sender As Object, e As EventArgs) Handles btn整理開始.Click

        If Not CheckValue() Then
            Return
        End If


        btn終了.Enabled = False
        btn整理開始.Enabled = False




        'フォルダ区切り文字を取得
        Dim sep = System.IO.Path.DirectorySeparatorChar

        '整理対象フォルダパス
        Dim target = tbx整理対象.Text.Trim

        '複製設定になっていればフォルダを複製し、対象フォルダを変更する
        If chk複製する.Checked Then
            '複製先フォルダパス
            Dim dest = ""

            If rbt同一フォルダ.Checked Then
                dest = System.IO.Directory.GetParent(target).FullName
            Else
                dest = tbx複製先.Text.Trim
            End If

            '整理対象のフォルダ名
            Dim srcDirName = target.Split(sep).Last

            '複製先パスと整理対象フォルダ名から唯一無二なフォルダ名を取得する
            Dim destDirName = GetUniqueDirName(dest, srcDirName)

            dest = dest & sep & destDirName


            Try
                My.Computer.FileSystem.CreateDirectory(dest)

            Catch ex As IOException
                '親フォルダの属性が読み取り専用のときに発生
                MessageBox.Show(ex.Message, "IOエラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            Catch ex As UnauthorizedAccessException
                'フォルダ作成権限が無い場合に発生
                MessageBox.Show(ex.Message, "権限エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try

            'フォルダをコピー
            My.Computer.FileSystem.CopyDirectory(target, dest)

            '整理対象を複製先に変更
            target = dest

        Else
            Dim warn As New StringBuilder
            warn.AppendLine("整理対象フォルダを複製しない場合、元々のファイル名やフォルダ階層が直接変更されます。")
            warn.AppendLine("また「画像の重複を除去する」を選択している場合、同一と判断された画像は削除されます。")
            warn.AppendLine("この操作を元に戻す事はできません。")
            warn.AppendLine()
            warn.AppendLine("続行しますか？")

            If MessageBox.Show(warn.ToString, "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                Return
            End If
        End If

        '画像比較クラスを生成
        Dim imgCmp As New ImageComparator
        Dim fileCmp As New FileComparator

        '指定ディレクトリ直下のファイルだけを対象にパス配列を取得
        Dim imgfiles() As String


        'サブディレクトリなどに関する判断
        If chk再帰的.Checked Then
            '再帰的に取得
            imgfiles = System.IO.Directory.GetFiles(target, "*", IO.SearchOption.AllDirectories)
        Else
            '直下のファイルのみ取得
            imgfiles = System.IO.Directory.GetFiles(target, "*", IO.SearchOption.TopDirectoryOnly)

        End If

        Dim cntNotImg, cntHasExif, cntHasntExif, cntRmImg As Integer

        'プログレスバーの最大値を更新
        pgb進捗.Maximum = imgfiles.Count
        pgb進捗.Value = 0
        pgb進捗.Visible = True


        'ファイルの3分類
        ' １．撮影日情報のある画像（Exif対応画像、jpeg, tiff）
        '       ・フォルダ整理しない場合は、リネームのみ
        '       ・フォルダ整理する場合は、設定に応じたフォルダ内に移動
        ' ２．撮影日情報のない画像（Exif非対応画像、bmp, png, gifなど）
        '       ・フォルダ整理しない場合は、固定リネームのみ
        '       ・フォルダ整理する且つ整理対象に含める場合は、固定フォルダへ移動
        ' ３．画像でないファイル
        '       ・フォルダ複製しない場合は、ノータッチ
        '       ・フォルダ複製する場合は、後から削除する（コピーに含めない）
        For Each file In imgfiles
            Try
                'リネーム後のファイルパス
                Dim newFile As String
                'ファイル名部分を取得
                Dim filename = file.Split(sep).Last
                'リネーム後のファイル名
                Dim renamed = ""

                Dim capDate = GetImageCaptureDate(file)


                ' 同一画像の除去処理
                If chk重複画像除去.Checked Then
                    '
                    If (rbt重複判定高速.Checked AndAlso fileCmp.Exist(file)) OrElse
                       (rbt重複判定低速.Checked AndAlso imgCmp.Exist(file)) Then
                        cntRmImg += 1
                        My.Computer.FileSystem.DeleteFile(file)
                        Continue For
                    End If
                End If


                If capDate = Nothing Then
                    '撮影日時情報を持たない画像
                    cntHasntExif += 1

                    renamed = tbx撮影日不明Prefix.Text.Trim & "_" & filename

                    If chk整理する.Checked AndAlso chk不明分類.Checked Then
                        '撮影日時不明画像も整理する設定ならばフォルダ作成する
                        Dim created = target & sep & tbx撮影日不明Prefix.Text.Trim
                        System.IO.Directory.CreateDirectory(created)
                        newFile = created & sep & renamed
                    Else
                        'フォルダ作成しない場合
                        newFile = target & sep & renamed
                    End If

                Else
                    '撮影日時情報を持つ画像
                    cntHasExif += 1

                    'フォルダ整理する場合
                    If chk整理する.Checked Then
                        Dim created = ""

                        '整理フォルダパスを作成する
                        Select Case cbx整理方法.SelectedIndex
                            Case 0
                                '撮影年毎にフォルダに分ける
                                created = target & sep & capDate.ToString("yyyy")

                            Case 1
                                '撮影年月毎にフォルダを分ける
                                created = target & sep & capDate.ToString("yyyy-MM")

                            Case 2
                                '撮影年月日毎にフォルダを分ける
                                created = target & sep & capDate.ToString("yyyy-MM-dd")
                            Case Else
                                created = target
                        End Select

                        newFile = created & sep & capDate.ToString("yyyyMMdd") & "_" & filename

                    Else
                        newFile = target & sep & capDate.ToString("yyyyMMdd") & "_" & filename

                    End If

                End If

                'リネームしない設定ならば元のファイル名に戻す
                If chk整理する.Checked AndAlso chkリネームしない.Checked Then
                    'ファイル名部分を元のものに戻す
                    newFile = Path.GetDirectoryName(newFile) & sep & filename
                End If

                '直下処理のみ場合は、被ることが無いので関係ない
                If chk再帰的.Checked Then
                    '指定ファイルパスが既存の場合はユニークなパスを取得
                    newFile = GetUniquePath(newFile, "")
                End If


                'ファイル移動（リネーム）を実行
                If file <> newFile Then
                    My.Computer.FileSystem.MoveFile(file, newFile)
                End If

            Catch ex As OutOfMemoryException
                'ファイルが画像ファイルでは無い場合
                If chk複製する.Checked Then
                    '複製設定になっているときは、画像でないファイルは削除する
                    My.Computer.FileSystem.DeleteFile(file)
                Else
                    'オリジナルをそのまま変更するときは、カウントアップのみ行う
                    cntNotImg += 1
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "予期せぬエラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                pgb進捗.Visible = False
                btn終了.Enabled = True
                btn整理開始.Enabled = True
                Return

            Finally

                pgb進捗.Value += 1
                Application.DoEvents() 'ユーザ入力や他の処理を行うための処理

            End Try

        Next


        '※複製する時のみ、フォルダ整理のため削除する
        If chk複製する.Checked Then
            If chk再帰的.Checked Then
                For Each dirpath In System.IO.Directory.GetDirectories(target)
                    Dim files = System.IO.Directory.GetFiles(dirpath)
                    'フォルダ内のファイル数が０ならば削除
                    If files.Count = 0 Then
                        System.IO.Directory.Delete(dirpath, True)
                    End If
                Next
            Else
                'フォルダ整理する設定の場合でも、削除されてしまうので、整理フォルダを除外する必要アリ↓
                'フォルダ直下のみ処理の場合、複製先の全サブフォルダは削除
                'For Each dirpath In System.IO.Directory.GetDirectories(target)
                '    System.IO.Directory.Delete(dirpath, True)
                'Next
            End If
        End If


        Dim report As New StringBuilder
        report.AppendLine(cntHasExif & "件の画像ファイルが正常に処理されました")
        report.AppendLine(cntHasntExif & "件の画像ファイルにExif情報が見つかりませんでした")
        report.AppendLine(cntNotImg & "件の非画像ファイルがスキップされました")
        If chk重複画像除去.Checked Then
            report.AppendLine(cntRmImg & "件の重複画像が削除されました")
        End If
        report.AppendLine()
        report.AppendLine("対象フォルダを開きますか？")

        If MessageBox.Show(report.ToString, "整理結果", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            '開く処理
            'エクスプローラでフォルダを開く
            System.Diagnostics.Process.Start("EXPLORER.EXE", target)
        End If

        pgb進捗.Visible = False
        btn終了.Enabled = True
        btn整理開始.Enabled = True


    End Sub

    Private Sub btn参照_Click(sender As Object, e As EventArgs) Handles btn整理対象参照.Click

        '選択されたフォルダパスを設定
        If fbd対象フォルダ.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            tbx整理対象.Text = fbd対象フォルダ.SelectedPath
        End If

    End Sub

    Private Function GetImageMetaData(ByVal path As String) As IEnumerable(Of PropertyItem)
        Using img = Image.FromFile(path)
            Return img.PropertyItems
        End Using
    End Function





    Private Function GetImageCaptureDate(ByVal filename As String) As DateTime

        Dim meta = GetImageMetaData(filename)

        ' Exif情報で「撮影日時」を格納するタグのIDは「0x9003」なので
        ' 画像のメタ情報からID が 0x9003 のものを抽出 
        ' EXIF Tags: http://www.sno.phy.queensu.ca/~phil/exiftool/TagNames/EXIF.html
        Dim filtered = meta.Where(Function(p) p.Id = &H9003)

        If filtered.Count = 0 Then
            '撮影日時情報が無ければ Nothing を返す
            Return Nothing

        Else
            Dim rawCapDate = filtered.First.Value ' 生バイトデータ
            Dim strCapDate = System.Text.Encoding.ASCII.GetString(rawCapDate, 0, 19) '末尾のNUL文字除去

            'カルチャーに依存せず不変的な日付を取得するためのカルチャー
            Dim cult = System.Globalization.CultureInfo.InvariantCulture
            Return DateTime.ParseExact(strCapDate, "yyyy:MM:dd HH:mm:ss", cult)
        End If
    End Function

    Private Function GetImageSerialNumber(ByVal filename As String) As String

        'シリアルナンバーの取得を試みる
        Dim filtered = GetImageMetaData(filename).Where(Function(p) p.Id = &HA431)

        If filtered.Count = 0 Then
            Return Nothing
        Else
            Dim rawSerial = filtered.First.Value ' 生バイトデータ
            Dim strSerial = System.Text.Encoding.ASCII.GetString(rawSerial)
            Return strSerial
        End If

    End Function


    Private Sub chk複製する_CheckedChanged(sender As Object, e As EventArgs) Handles chk複製する.CheckedChanged

        grp複製設定.Enabled = chk複製する.Checked
        'tbx複製先.Enabled = chk複製する.Checked
        'btn参照.Enabled = chk複製する.Checked
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn複製先参照.Click
        If fbd対象フォルダ.ShowDialog() = DialogResult.OK Then
            tbx複製先.Text = fbd対象フォルダ.SelectedPath
        End If
    End Sub


    Private Sub rbt_CheckedChanged(sender As Object, e As EventArgs) Handles rbt同一フォルダ.CheckedChanged, rbt任意場所.CheckedChanged

        tbx複製先.Enabled = rbt任意場所.Checked
        btn複製先参照.Enabled = rbt任意場所.Checked
        lbl複製先.Enabled = rbt任意場所.Checked

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

        If target = "" Then
            MessageBox.Show("整理対象フォルダが選択されていません。", cap, btn, icn)
            btn整理対象参照.Focus()
            Return False

        ElseIf Not System.IO.Directory.Exists(target) Then
            MessageBox.Show("整理対象フォルダ """ & target & """ は存在しません。", cap, btn, icn)
            btn整理対象参照.Focus()
            Return False

        ElseIf tbx撮影日不明Prefix.Text.Trim = "" Then
            MessageBox.Show("撮影日不明画像のファイル名に付けるプレフィックスを空に出来ません。", cap, btn, icn)
            tbx撮影日不明Prefix.Focus()
            Return False

        ElseIf chk複製する.Checked AndAlso rbt任意場所.Checked Then

            Dim dest = tbx複製先.Text.Trim

            If dest = "" Then
                MessageBox.Show("複製先フォルダが選択されていません。", cap, btn, icn)
                btn複製先参照.Focus()
                Return False

            ElseIf Not System.IO.Directory.Exists(dest) Then
                MessageBox.Show("複製先フォルダ """ & dest & """ は存在しません。", cap, btn, icn)
                btn複製先参照.Focus()
                Return False

            End If
        End If

        Return True
    End Function


    Function ChageFileName(ByVal filePath As String, ByVal newFileName As String) As String

        'ファイル名部分を新しいファイル名に変更する
        Dim newFilePath = System.Text.RegularExpressions.Regex.Replace(filePath, "[^\\]+$", newFileName)

        Return newFilePath

    End Function

    Function GetUniquePath(ByVal path As String, ByVal pad As String) As String

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

    ''' <summary>
    ''' 検査対象のパスから指定のフォルダ名が存在するか確認し、唯一のフォルダ名を取得します。
    ''' そのフォルダ名が存在しない場合に限り、このメソッドは引数フォルダ名を返します。
    ''' そのフォルダ名が既存の場合は、フォルダ名に類似した唯一のフォルダ名を返します。
    ''' </summary>
    ''' <param name="path"></param>
    ''' <param name="dir"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetUniqueDirName(ByVal path As String, ByVal dir As String) As String

        Dim dirsep = System.IO.Path.DirectorySeparatorChar

        '指定のフォルダが存在する場合、ユニークなフォルダ名を作成する
        If System.IO.Directory.Exists(path & dirsep & dir) Then

            Dim i = 1, newdir = ""

            '指定のフォルダが存在する間、新たなファルダ名を作り続ける
            Do
                newdir = dir & "_Copy" & i
                i += 1
            Loop While System.IO.Directory.Exists(path & dirsep & newdir)

            Return newdir

        End If

        'フォルダ名をそのまま返す
        Return dir

    End Function


    Private Sub chk整理する_CheckedChanged(sender As Object, e As EventArgs) Handles chk整理する.CheckedChanged
        grp整理.Enabled = chk整理する.Checked
    End Sub

    Private Sub chk重複画像除去_CheckedChanged(sender As Object, e As EventArgs) Handles chk重複画像除去.CheckedChanged
        grp重複除去設定.Enabled = chk重複画像除去.Checked
    End Sub
End Class
