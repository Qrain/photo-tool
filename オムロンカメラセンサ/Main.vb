Imports System.Drawing
Imports System.Windows.Forms
Imports System.Threading
Imports System.Drawing.Imaging
Imports HVCW.CameraControl
Imports HVCW.Auth
'Imports M

''' <summary >
''' HVCW Windows sample code
''' </summary >
Public Class main

    ' 現在実行しているスレッド (Live Or OKAO)
    Private threadExecute As Thread = Nothing
    ' 接続フラグ
    Private bConnect As Boolean = False

    ' Step１．カメラセンサ制御用DLLラッパー＋接続等のメソッド
    Private clsHvcw As New ClassHvcw()

    ' Step2. WebAPIとかAPIキーなどの認証準備？
    Private clsWebAPI As New ClassWebAPI()

    ' 初期認証に必要な情報
    Private Const API_KEY = "PWnsDS8Z7HS9HMui2QDbU4iiUgLfQgn7bsTTM4UH"
    Private Const APP_ID As Integer = 26801


    ' Step1. ユーザーコード部分
    Public Sub New()
        InitializeComponent()
        ' Set all OKAO function flags OFF 

        ' OKAO（顔とかの検出技術）の各フラグをOFFで初期化
        clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Body) = 0
        clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Hand) = 0
        clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Pet) = 0
        clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Face) = 0
        clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Direction) = 0
        clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Age) = 0
        clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Gender) = 0
        clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Gaze) = 0
        clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Blink) = 0
        clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Expression) = 0
        clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Recognition) = 0

        ' Measures against button malfunction, etc. 
        groupExec.Enabled = False
        groupOkao.Enabled = False
        groupRegistration.Enabled = False
        btnConnect.Enabled = False
    End Sub

    ' ***** End process (disconnect camera and logout) *****
    Private Sub main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.Closing
        ' Disconnect camera 
        clsHvcw.Disconnect()
        If clsWebAPI.accessToken <> "" Then
            ' Logout 
            clsWebAPI.logout()
        End If
    End Sub

    ' ***** New registration *****
    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        If clsWebAPI.signup(API_KEY, textEmail.Text) = True Then
            MessageBox.Show("User registration complete. " & vbLf & "Check email and input password for login.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' ***** Login *****
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If clsWebAPI.accessToken <> "" Then

            ' 既に誰かログイン中ならばログアウト処理を行う

            ' ***** Logout process *****
            If threadExecute IsNot Nothing Then
                threadExecute.Abort()
                threadExecute = Nothing
                btnExecute.Text = "Execute"
            End If

            ' Disconnect camera 
            clsHvcw.Disconnect()
            bConnect = False
            btnConnect.Text = "Connect"

            groupExec.Enabled = False
            groupOkao.Enabled = False
            groupRegistration.Enabled = False

            ' Logout 
            clsWebAPI.logout()
            btnLogin.Text = "Login"

            btnConnect.Enabled = False
        Else
            ' 誰もログインしてなければログイン処理を行う。

            ' ***** Login process *****
            If clsWebAPI.login(API_KEY, textEmail.Text, textPassword.Text) = True Then
                btnLogin.Text = "Logout"

                MessageBox.Show("Login complete. " & vbLf & "Select a camera from the list and connect it.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                ' アクセストークを使ってカメラリスト取得要求を行いコンボボックスに結果を設定する
                clsWebAPI.getCameraList()
                comboCameraList.Items.Clear()
                If clsWebAPI.cameraList Is Nothing OrElse clsWebAPI.cameraList.Count <= 0 Then
                    Dim sSnd As New Sound()
                    sSnd.SetDialog(Me, clsHvcw, clsWebAPI.ssid, clsWebAPI.accessToken)
                    clsWebAPI.getCameraList()
                End If
                If clsWebAPI.cameraList IsNot Nothing Then
                    For i As Integer = 0 To clsWebAPI.cameraList.Count - 1
                        Dim cam As String = clsWebAPI.cameraList(i).cameraName + "(" + clsWebAPI.cameraList(i).cameraId + ")"
                        comboCameraList.Items.Add(cam)
                    Next
                    btnConnect.Enabled = True
                End If
            Else
                btnLogin.Text = "Login"
            End If
        End If
    End Sub

    ' ***** Connect camera *****
    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        If bConnect Then
            ' 既にカメラに接続済みならば一度切断する

            ' ***** Disconnect camera process *****
            If threadExecute IsNot Nothing Then
                threadExecute.Abort()
                threadExecute = Nothing
                btnExecute.Text = "Execute"
            End If

            ' Disconnect camera 
            clsHvcw.Disconnect()
            bConnect = False
            btnConnect.Text = "Connect"

            groupExec.Enabled = False
            groupOkao.Enabled = False
            groupRegistration.Enabled = False
        Else
            ' ***** Connect camera process *****
            Dim cam As String = ""
            Dim nIndex As Integer = comboCameraList.SelectedIndex
            If nIndex < 0 Then
                cam = comboCameraList.Text
            Else
                cam = clsWebAPI.cameraList(nIndex).cameraId
            End If

            ' Connect camera 
            If clsHvcw.Connect(APP_ID, cam, clsWebAPI.accessToken) = True Then
                bConnect = True
                btnConnect.Text = "Disconnect"
                MessageBox.Show("Camera connection complete. " & vbLf & "Select a function and run it.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                groupExec.Enabled = True
                groupOkao.Enabled = True
                groupRegistration.Enabled = True
            Else
                bConnect = False
                btnConnect.Text = "Connect"
                MessageBox.Show("Camera connection failed. " & vbLf & "Check network.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End If
        End If
    End Sub

    ''' <summary>
    ''' ライブストリーミングモードに変更する。
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub rbtLive_CheckedChanged(sender As Object, e As EventArgs) Handles rbtLive.CheckedChanged
        If threadExecute IsNot Nothing Then
            threadExecute.Abort()
            threadExecute = Nothing
            btnExecute.Text = "Execute"
        End If

        groupOkao.Enabled = False
        groupRegistration.Enabled = False
        clsHvcw.StartLive()

        ' Run thread
        threadExecute = New Thread(New ThreadStart(AddressOf Me.ExecuteThead))
        threadExecute.Start()
    End Sub

    ''' <summary>
    ''' ストリーミングを中止しOKAOモードに変更します。
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub rbtOkao_CheckedChanged(sender As Object, e As EventArgs) Handles rbtOkao.CheckedChanged
        If threadExecute IsNot Nothing Then
            threadExecute.Abort()
            threadExecute = Nothing
            btnExecute.Text = "Execute"
        End If

        clsHvcw.StopLive()
        groupOkao.Enabled = True
        groupRegistration.Enabled = True

        btnParameter.Enabled = True
        btnRegistration.Enabled = True
    End Sub

    ' Delegate for thread
    Private Delegate Sub ExecuteDelegate()

    ' ***** Thread main loop *****
    Public Sub ExecuteThead()
        While threadExecute IsNot Nothing
            Invoke(New ExecuteDelegate(AddressOf ExecuteProcess))
            Application.DoEvents()
        End While
    End Sub

    ' ***** Run function process *****
    ' 別スレッドとして、取得したフレームを常にPicutureBoxに描画する【結果映像になる）
    Private Sub ExecuteProcess()
        ' OKAOモード
        If rbtOkao.Checked Then
            ' ***** Execute OKAO function *****
            If clsHvcw.Execute() <> ClassHvcw.HVCW_SUCCESS Then
                threadExecute = Nothing
                btnExecute.Text = "Execute"
            End If
        End If
        ' ライブ映像表示モード
        If rbtLive.Checked Then
            ' ***** Run Live *****
            Dim nWidth As Integer() = New Integer(0) {}
            Dim nHeight As Integer() = New Integer(0) {}
            If clsHvcw.GetLive(nWidth, nHeight) = ClassHvcw.HVCW_SUCCESS Then
                Dim rect As New Rectangle(0, 0, nWidth(0), nHeight(0))
                Dim bitmap As New Bitmap(nWidth(0), nHeight(0), PixelFormat.Format24bppRgb)
                Dim bmpData As BitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb)
                Marshal.Copy(clsHvcw.liveBuffer, 0, bmpData.Scan0, nWidth(0) * nHeight(0) * 3)
                bitmap.UnlockBits(bmpData)
                pictCamera.Image = bitmap
            End If
        End If
        pictCamera.Refresh()
    End Sub

    ' ***** Execute OKAO function *****
    Private Sub btnExecute_Click(sender As Object, e As EventArgs) Handles btnExecute.Click
        If threadExecute IsNot Nothing Then
            threadExecute.Abort()
            threadExecute = Nothing
            btnExecute.Text = "Execute"

            btnParameter.Enabled = True
            btnRegistration.Enabled = True
            Return
        End If

        ' Set image area
        Dim bitmap As New Bitmap(pictCamera.Width, pictCamera.Height)

        Dim g As Graphics = Graphics.FromImage(bitmap)
        g.FillRectangle(Brushes.DarkGray, 0, 0, pictCamera.Width, pictCamera.Height)
        g.DrawRectangle(SystemPens.ControlDark, 0, 0, pictCamera.Width, pictCamera.Height)
        g.Dispose()

        pictCamera.Image = bitmap

        ' Run thread
        threadExecute = New Thread(New ThreadStart(AddressOf Me.ExecuteThead))
        threadExecute.Start()
        btnExecute.Text = "Stop"

        btnParameter.Enabled = False
        btnRegistration.Enabled = False

        ' ユーザー名を取得する、ユーザーIDは0固定
        clsHvcw.GetUserName(textRegistration.Text, 0)
    End Sub

    ' ***** Registration (recognition) *****
    Private Sub btnRegistration_Click(sender As Object, e As EventArgs) Handles btnRegistration.Click
        If clsHvcw.Register(pictRegistration) = ClassHvcw.HVCW_SUCCESS Then
            clsHvcw.SetUserName(textRegistration.Text)
            MessageBox.Show("Registration successful", "OK", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            MessageBox.Show("Registration failed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End If
    End Sub

    ' ***** Set parameters *****
    Private Sub btnParameter_Click(sender As Object, e As EventArgs) Handles btnParameter.Click
        Dim sPrm As New Params()
        sPrm.SetDialog(Me, clsHvcw)
    End Sub

    ' ***** Screen process *****

    ' ***** Compute face direction display point coordinates *****
    Private Sub GetFlemingPos(inLength As Integer, inYawAngle As Integer, inPitchAngle As Integer, inRollAngle As Integer, ByRef outYawPos As Point, ByRef outPitchPos As Point,
            ByRef outRollPos As Point)
        Dim pitchRadian As Double = inPitchAngle / 180.0 * Math.PI
        Dim yawRadian As Double = inYawAngle / 180.0 * Math.PI

        ' Compute pitch axis point coordinates when roll is 0 to correct roll
        Dim xPos As Double = Math.Cos(yawRadian)
        Dim yPos As Double = -Math.Sin(pitchRadian) * Math.Sin(yawRadian)
        Dim slope As Double = Math.Atan2(yPos, xPos) * 180.0 / Math.PI
        Dim roll As Integer = inRollAngle + slope
        Dim rollRadian As Double = roll / 180.0 * Math.PI

        ' Compute axes point coordinates
        outYawPos.X = CInt(Math.Cos(pitchRadian) * Math.Sin(rollRadian) * inLength + 0.5)
        outYawPos.Y = CInt(Math.Cos(pitchRadian) * Math.Cos(rollRadian) * inLength + 0.5)
        outPitchPos.X = CInt((Math.Cos(rollRadian) * Math.Cos(yawRadian) - Math.Sin(rollRadian) * Math.Sin(pitchRadian) * Math.Sin(yawRadian)) * inLength + 0.5)
        outPitchPos.Y = CInt((-Math.Sin(rollRadian) * Math.Cos(yawRadian) - Math.Cos(rollRadian) * Math.Sin(pitchRadian) * Math.Sin(yawRadian)) * inLength + 0.5)
        outRollPos.X = CInt((Math.Sin(yawRadian) * Math.Cos(rollRadian) + Math.Sin(pitchRadian) * Math.Cos(yawRadian) * Math.Sin(rollRadian)) * inLength + 0.5)
        outRollPos.Y = CInt((-Math.Sin(yawRadian) * Math.Sin(rollRadian) + Math.Sin(pitchRadian) * Math.Cos(yawRadian) * Math.Cos(rollRadian)) * inLength + 0.5)
    End Sub
    ' ***** Face direction (3 axes) display *****
    Private Sub paintDrawFleming(g As Graphics, center As Point, length As Integer, nYaw As Integer, nPitch As Integer, nRoll As Integer)
        Dim ratio As Single = g.ClipBounds.Width / 1920
        If ratio > g.ClipBounds.Height / 1080 Then
            ratio = g.ClipBounds.Height / 1080
        End If
        length = CInt(length * ratio) / 2
        center.X = CInt(center.X * ratio)
        center.Y = CInt(center.Y * ratio)

        Dim detectPen As Pen
        Dim po As Point() = New Point(1) {}

        Dim yawPos As New Point()
        Dim pitchPos As New Point()
        Dim rollPos As New Point()
        GetFlemingPos(length, nYaw, nPitch, nRoll, yawPos, pitchPos,
                rollPos)

        ' Compute axes point coordinates
        yawPos.X = center.X + yawPos.X
        yawPos.Y = center.Y - yawPos.Y
        pitchPos.X = center.X + pitchPos.X
        pitchPos.Y = center.Y - pitchPos.Y
        rollPos.X = center.X + rollPos.X
        rollPos.Y = center.Y - rollPos.Y

        ' Display
        detectPen = New Pen(Color.FromArgb(&HFF, &HFF, &H0), 2)
        po(0) = center
        po(1) = pitchPos
        g.DrawLines(detectPen, po)
        detectPen = New Pen(Color.FromArgb(&H0, &HFF, &HFF), 2)
        po(0) = center
        po(1) = yawPos
        g.DrawLines(detectPen, po)
        detectPen = New Pen(Color.FromArgb(&HFF, &H0, &HFF), 2)
        po(0) = center
        po(1) = rollPos
        g.DrawLines(detectPen, po)
    End Sub

    ' ***** Detection result frame display *****
    Private Sub paintDetectRect(g As Graphics, detectPen As Pen, size As Integer, posX As Integer, posY As Integer)
        Dim ratio As Single = g.ClipBounds.Width / 1920
        If ratio > g.ClipBounds.Height / 1080 Then
            ratio = g.ClipBounds.Height / 1080
        End If
        size = CInt(size * ratio) / 2
        Dim centerX As Integer = CSng(posX) * ratio
        Dim centerY As Integer = CSng(posY) * ratio

        ' Compute frame coordinates
        Dim lx As Integer = 0 + centerX - size
        If lx < 0 Then
            lx = 0
        End If
        Dim rx As Integer = 0 + centerX + size
        If rx > CInt(g.ClipBounds.Width) Then
            rx = CInt(g.ClipBounds.Width) - 1
        End If
        Dim ty As Integer = 0 + centerY - size
        If ty < 0 Then
            ty = 0
        End If
        Dim by As Integer = 0 + centerY + size
        If by > CInt(g.ClipBounds.Height) Then
            by = CInt(g.ClipBounds.Height) - 1
        End If

        ' Display
        Dim po As Point() = {New Point(lx, ty), New Point(rx, ty), New Point(rx, by), New Point(lx, by), New Point(lx, ty)}
        g.DrawLines(detectPen, po)
    End Sub

    ' ***** Detection result text display *****
    Private Sub paintDrawString(g As Graphics, str1 As String, str2 As String, str3 As String, size As Integer, posX As Integer,
            posY As Integer)
        Dim ratio As Single = g.ClipBounds.Width / 1920
        If ratio > g.ClipBounds.Height / 1080 Then
            ratio = g.ClipBounds.Height / 1080
        End If
        size = CInt(size * ratio) / 2
        Dim centerX As Integer = CSng(posX) * ratio
        Dim centerY As Integer = CSng(posY) * ratio
        Dim lx As Integer = 0 + centerX - size
        If lx < 0 Then
            lx = 0
        End If
        Dim ty As Integer = 0 + centerY - size
        If ty < 0 Then
            ty = 0
        End If

        Dim fnt As New Font("MS UI Gothic", 16, FontStyle.Bold)
        If str1.Trim().Length > 0 Then
            ' Age, gender and expression display
            ty -= 20
            g.DrawString(str1.Trim(), fnt, Brushes.Orange, lx - 2, ty)
        End If
        If str2.Trim().Length > 0 Then
            ' Gaze and blink display
            ty -= 20
            g.DrawString(str2.Trim(), fnt, Brushes.LightPink, lx - 2, ty)
        End If
        ' Recognition result display
        g.DrawString(str3.Trim(), fnt, Brushes.White, centerX - str3.Trim().Length * 8 + 16, centerY + size - 20)
    End Sub

    ' ***** Display event *****
    Private Sub pictCamera_Paint(sender As Object, e As PaintEventArgs)
        If Not rbtOkao.Checked Then
            Return
        End If

        Dim detectPen As Pen
        Dim g As Graphics = e.Graphics

        ' Body detection display
        detectPen = New Pen(Color.Blue, 2)
        For i As Integer = 0 To clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_BODYS_nCount) - 1
            paintDetectRect(g, detectPen, clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_BODYS_DETECTION_nSize + i * ClassHvcw.HVCW_OKAO_RESULT_BODYS_DETECTION_SIZE), clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_BODYS_DETECTION_POINT_nX + i * ClassHvcw.HVCW_OKAO_RESULT_BODYS_DETECTION_SIZE), clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_BODYS_DETECTION_POINT_nY + i * ClassHvcw.HVCW_OKAO_RESULT_BODYS_DETECTION_SIZE))
        Next

        ' 手認識の場合に枠線表示する？
        ' Hand detection display
        detectPen = New Pen(Color.Cyan, 2)
        For i As Integer = 0 To clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_HANDS_nCount) - 1
            paintDetectRect(g, detectPen, clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_HANDS_DETECTION_nSize + i * ClassHvcw.HVCW_OKAO_RESULT_HANDS_DETECTION_SIZE), clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_HANDS_DETECTION_POINT_nX + i * ClassHvcw.HVCW_OKAO_RESULT_HANDS_DETECTION_SIZE), clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_HANDS_DETECTION_POINT_nY + i * ClassHvcw.HVCW_OKAO_RESULT_HANDS_DETECTION_SIZE))
        Next

        ' 顔認識の場合に枠線表示する？
        ' Face detection result display
        detectPen = New Pen(Color.Green, 2)
        For i As Integer = 0 To clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_FACES_nCount) - 1
            paintDetectRect(g, detectPen, clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_nSize + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE), clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_POINT_nX + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE), clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_POINT_nY + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE))

            If checkDirection.CheckState = CheckState.Checked Then
                ' Face direction display
                Dim center As New Point()
                center.X = clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_POINT_nX + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE)
                center.Y = clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_POINT_nY + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE)
                Dim length As Integer = clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_nSize + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE)
                paintDrawFleming(g, center, length, clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_DIRECTION_nLR + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE), clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_DIRECTION_nUD + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE), clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_DIRECTION_nRoll + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE))
            End If

            Dim strAge As String = ""
            If chkAge.CheckState = CheckState.Checked Then
                ' Age display
                Dim nAge As Integer = clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_AEG_nAge + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE)
                If nAge >= 0 Then
                    strAge = String.Format("Age {0}", nAge)
                End If
            End If

            Dim strGender As String = ""
            If chkGender.CheckState = CheckState.Checked Then
                ' Gender display
                Dim nGender As Integer = clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_GENDER_nGender + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE)
                If nGender >= 0 Then
                    strGender = (If(nGender = ClassHvcw.HVCW_GENDER_MALE, "Male", "Female"))
                End If
            End If

            Dim strGaze As String = ""
            If chkGaze.CheckState = CheckState.Checked Then
                ' Gaze display
                Dim nLR As Integer = clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_GAZE_nLR + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE)
                Dim nUD As Integer = clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_GAZE_nUD + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE)
                strGaze = String.Format("Gaze({0},{1})", nLR, nUD)
            End If

            Dim strBlink As String = ""
            If chkBlink.CheckState = CheckState.Checked Then
                ' Blink display
                Dim nLeftEye As Integer = clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_BLINK_nLeftEye + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE)
                Dim nRightEye As Integer = clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_BLINK_nRightEye + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE)
                strBlink = String.Format("Closed({0},{1})", nLeftEye, nRightEye)
            End If

            Dim strExpression As String = ""
            If chkExpression.CheckState = CheckState.Checked Then
                ' Expression display
                Dim topScore As Integer = -1
                Dim topExpression As Integer = 0
                For j As Integer = 0 To 4
                    Dim score As Integer = clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_EXPRESSION_Neutral + j + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE)
                    If topScore < score Then
                        topScore = score
                        topExpression = j + 1
                    End If
                Next
                Dim ExStr As String() = {"?", "Neutral", "Happiness", "Surprise", "Anger", "Sadness"}
                strExpression = ExStr(topExpression)
            End If

            Dim strRecognition As String = ""
            If chkRecognition.CheckState = CheckState.Checked Then
                ' Recognition result display
                Dim uid As Integer = clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_RECOGNITION_nUID + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE)
                If uid = 0 Then
                    strRecognition = textRegistration.Text
                End If
            End If


            paintDrawString(g, Convert.ToString((Convert.ToString(strAge & Convert.ToString(" ")) & strGender) + " ") & strExpression, Convert.ToString(strGaze & Convert.ToString(" ")) & strBlink, strRecognition, clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_nSize + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE), clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_POINT_nX + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE),
                    clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_POINT_nY + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE))
        Next
        ' ペット認識の場合は枠線表示する？
        ' Pet detection result display
        detectPen = New Pen(Color.Yellow, 2)
        For i As Integer = 0 To clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_PETS_nCount) - 1
            paintDetectRect(g, detectPen, clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_PETS_DETECTION_nSize + i * ClassHvcw.HVCW_OKAO_RESULT_PETS_DETECTION_SIZE), clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_PETS_DETECTION_POINT_nX + i * ClassHvcw.HVCW_OKAO_RESULT_PETS_DETECTION_SIZE), clsHvcw.resultData(ClassHvcw.HVCW_OKAO_RESULT_PETS_DETECTION_POINT_nY + i * ClassHvcw.HVCW_OKAO_RESULT_PETS_DETECTION_SIZE))
        Next
        detectPen.Dispose()
    End Sub

    ' ***** OKAO function checkbox *****

    Private Sub checkBody_CheckStateChanged(sender As Object, e As EventArgs)
        If checkBody.CheckState = CheckState.Checked Then
            clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Body) = 1
        Else
            clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Body) = 0
        End If
    End Sub

    Private Sub checkHand_CheckStateChanged(sender As Object, e As EventArgs)
        If checkHand.CheckState = CheckState.Checked Then
            clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Hand) = 1
        Else
            clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Hand) = 0
        End If
    End Sub

    Private Sub checkPet_CheckStateChanged(sender As Object, e As EventArgs)
        If checkPet.CheckState = CheckState.Checked Then
            clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Pet) = 1
        Else
            clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Pet) = 0
        End If
    End Sub

    Private Sub checkFace_CheckStateChanged(sender As Object, e As EventArgs)
        If checkFace.CheckState = CheckState.Checked Then
            clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Face) = 1
        Else
            clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Face) = 0
        End If
    End Sub

    Private Sub checkDirection_CheckStateChanged(sender As Object, e As EventArgs)
        If checkDirection.CheckState = CheckState.Checked Then
            clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Direction) = 1
        Else
            clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Direction) = 0
        End If
    End Sub

    Private Sub checkAge_CheckStateChanged(sender As Object, e As EventArgs) Handles chkAge.CheckStateChanged
        If chkAge.CheckState = CheckState.Checked Then
            clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Age) = 1
        Else
            clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Age) = 0
        End If
    End Sub

    Private Sub checkGender_CheckStateChanged(sender As Object, e As EventArgs) Handles chkGender.CheckStateChanged
        If chkGender.CheckState = CheckState.Checked Then
            clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Gender) = 1
        Else
            clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Gender) = 0
        End If
    End Sub

    Private Sub checkGaze_CheckStateChanged(sender As Object, e As EventArgs) Handles chkGaze.CheckStateChanged
        If chkGaze.CheckState = CheckState.Checked Then
            clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Gaze) = 1
        Else
            clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Gaze) = 0
        End If
    End Sub

    Private Sub chkBlink_CheckStateChanged(sender As Object, e As EventArgs) Handles chkBlink.CheckStateChanged
        If chkBlink.CheckState = CheckState.Checked Then
            clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Blink) = 1
        Else
            clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Blink) = 0
        End If
    End Sub

    Private Sub chkExpression_CheckStateChanged(sender As Object, e As EventArgs) Handles chkExpression.CheckStateChanged
        If chkExpression.CheckState = CheckState.Checked Then
            clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Expression) = 1
        Else
            clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Expression) = 0
        End If
    End Sub

    Private Sub chkRecognition_CheckStateChanged(sender As Object, e As EventArgs) Handles chkRecognition.CheckStateChanged
        If chkRecognition.CheckState = CheckState.Checked Then
            clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Recognition) = 1
        Else
            clsHvcw.execFlag(HVCW_OkaoFunction.HVCW_OkaoFunction_Recognition) = 0
        End If
    End Sub

End Class

