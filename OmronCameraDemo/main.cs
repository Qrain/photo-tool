using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Imaging;

namespace OmronCameraDemo
{
    /// <summary >
    /// HVCW Windows sample code
    /// </summary >
    public partial class main : Form
    {
        // Process thread (Live or OKAO)
        Thread threadExecute = null;

        bool bConnect = false;

        // Step１．カメラセンサ制御用DLLラッパー＋接続等のメソッド
        ClassHvcw clsHvcw = new ClassHvcw();

        // Step2. WebAPIとかAPIキーなどの認証準備？
        ClassWebAPI clsWebAPI = new ClassWebAPI();

        // Step1. ユーザーコード部分
        public main()
        {
            InitializeComponent();

            /* Set all OKAO function flags OFF */
            // OKAO（顔とかの検出技術）の各フラグをOFFで初期化
            clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Body] = 0;
            clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Hand] = 0;
            clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Pet] = 0;
            clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Face] = 0;
            clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Direction] = 0;
            clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Age] = 0;
            clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Gender] = 0;
            clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Gaze] = 0;
            clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Blink] = 0;
            clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Expression] = 0;
            clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Recognition] = 0;

            /* Measures against button malfunction, etc. */
            groupExec.Enabled = false;
            groupOkao.Enabled = false;
            groupRegistration.Enabled = false;
            btnConnect.Enabled = false;
        }

        // ***** End process (disconnect camera and logout) *****
        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            /* Disconnect camera */
            clsHvcw.Disconnect();
            if (clsWebAPI.accessToken != "")
            {
                /* Logout */
                clsWebAPI.logout();
            }
        }

        // ***** New registration *****
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (clsWebAPI.signup(textEmail.Text) == true)
            {
                MessageBox.Show("User registration complete. \nCheck email and input password for login.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ***** Login *****
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (clsWebAPI.accessToken != "")
            {
                // 既に誰かログイン中ならばログアウト処理を行う

                // ***** Logout process *****
                if (threadExecute != null)
                {
                    threadExecute.Abort();
                    threadExecute = null;
                    btnExecute.Text = "Execute";
                }

                /* Disconnect camera */
                clsHvcw.Disconnect();
                bConnect = false;
                btnConnect.Text = "Connect";

                groupExec.Enabled = false;
                groupOkao.Enabled = false;
                groupRegistration.Enabled = false;

                /* Logout */
                clsWebAPI.logout();
                btnLogin.Text = "Login";

                btnConnect.Enabled = false;
            }
            else
            {
                // 誰もログインしてなければログイン処理を行う。

                // ***** Login process *****
                if (clsWebAPI.login(textEmail.Text, textPassword.Text) == true)
                {
                    btnLogin.Text = "Logout";

                    MessageBox.Show("Login complete. \nSelect a camera from the list and connect it.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // アクセストークを使ってカメラリスト取得要求を行いコンボボックスに結果を設定する
                    clsWebAPI.getCameraList();
                    comboCameraList.Items.Clear();
                    if (clsWebAPI.cameraList == null || clsWebAPI.cameraList.Count <= 0)
                    {
                        Sound sSnd = new Sound();
                        sSnd.SetDialog(this, clsHvcw, clsWebAPI.ssid, clsWebAPI.accessToken);
                        clsWebAPI.getCameraList();
                    }
                    if (clsWebAPI.cameraList != null)
                    {
                        for (int i = 0; i < clsWebAPI.cameraList.Count; i++)
                        {
                            string cam = clsWebAPI.cameraList[i].cameraName + "(" + clsWebAPI.cameraList[i].cameraId + ")";
                            comboCameraList.Items.Add(cam);
                        }
                        btnConnect.Enabled = true;
                    }
                }
                else
                {
                    btnLogin.Text = "Login";
                }
            }
        }

        // ***** Connect camera *****
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (bConnect)
            {
                // ***** Disconnect camera process *****
                if (threadExecute != null)
                {
                    threadExecute.Abort();
                    threadExecute = null;
                    btnExecute.Text = "Execute";
                }

                /* Disconnect camera */
                clsHvcw.Disconnect();
                bConnect = false;
                btnConnect.Text = "Connect";

                groupExec.Enabled = false;
                groupOkao.Enabled = false;
                groupRegistration.Enabled = false;
            }
            else
            {
                // ***** Connect camera process *****
                string cam = "";
                int nIndex = comboCameraList.SelectedIndex;
                if (nIndex < 0)
                {
                    cam = comboCameraList.Text;
                }
                else
                {
                    cam = clsWebAPI.cameraList[nIndex].cameraId;
                }

                /* Connect camera */
                if (clsHvcw.Connect(cam, clsWebAPI.accessToken) == true)
                {
                    bConnect = true;
                    btnConnect.Text = "Disconnect";
                    MessageBox.Show("Camera connection complete. \nSelect a function and run it.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    groupExec.Enabled = true;
                    groupOkao.Enabled = true;
                    groupRegistration.Enabled = true;
                }
                else
                {
                    bConnect = false;
                    btnConnect.Text = "Connect";
                    MessageBox.Show("Camera connection failed. \nCheck network.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ***** Run Live *****
        private void radioLive_CheckedChanged(object sender, EventArgs e)
        {
            if (threadExecute != null)
            {
                threadExecute.Abort();
                threadExecute = null;
                btnExecute.Text = "Execute";
            }

            groupOkao.Enabled = false;
            groupRegistration.Enabled = false;
            clsHvcw.StartLive();

            // Run thread
            threadExecute = new Thread(new ThreadStart(this.ExecuteThead));
            threadExecute.Start();
        }

        // ***** Stop Live and Execute OKAO mode *****
        private void radioOkao_CheckedChanged(object sender, EventArgs e)
        {
            if (threadExecute != null)
            {
                threadExecute.Abort();
                threadExecute = null;
                btnExecute.Text = "Execute";
            }

            clsHvcw.StopLive();
            groupOkao.Enabled = true;
            groupRegistration.Enabled = true;

            btnParameter.Enabled = true;
            btnRegistration.Enabled = true;
        }

        // Delegate for thread
        delegate void ExecuteDelegate();

        // ***** Thread main loop *****
        public void ExecuteThead()
        {
            while (threadExecute != null)
            {
                Invoke(new ExecuteDelegate(ExecuteProcess));
                Application.DoEvents();
            }
        }

        // ***** Run function process *****
        // 別スレッドとして、取得したフレームを常にPicutureBoxに描画する【結果映像になる）
        unsafe private void ExecuteProcess()
        {
            // OKAOモード
            if (radioOkao.Checked)
            {
                // ***** Execute OKAO function *****
                if (clsHvcw.Execute() != ClassHvcw.HVCW_SUCCESS)
                {
                    threadExecute = null;
                    btnExecute.Text = "Execute";
                }
            }

            // ライブ映像表示モード
            if (radioLive.Checked)
            {
                // ***** Run Live *****
                int[] nWidth = new int[1];
                int[] nHeight = new int[1];
                if (clsHvcw.GetLive(nWidth, nHeight) == ClassHvcw.HVCW_SUCCESS)
                {
                    Rectangle rect = new Rectangle(0, 0, nWidth[0], nHeight[0]);
                    Bitmap bitmap = new Bitmap(nWidth[0], nHeight[0], PixelFormat.Format24bppRgb);
                    BitmapData bmpData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                    System.Runtime.InteropServices.Marshal.Copy(clsHvcw.liveBuffer, 0, bmpData.Scan0, nWidth[0] * nHeight[0] * 3);
                    bitmap.UnlockBits(bmpData);
                    pictCamera.Image = bitmap;
                }
            }
            pictCamera.Refresh();
        }
        // ***** Execute OKAO function *****
        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (threadExecute != null)
            {
                threadExecute.Abort();
                threadExecute = null;
                btnExecute.Text = "Execute";

                btnParameter.Enabled = true;
                btnRegistration.Enabled = true;
                return;
            }

            // Set image area
            Bitmap bitmap = new Bitmap(pictCamera.Width, pictCamera.Height);

            Graphics g = Graphics.FromImage(bitmap);
            g.FillRectangle(Brushes.DarkGray, 0, 0, pictCamera.Width, pictCamera.Height);
            g.DrawRectangle(SystemPens.ControlDark, 0, 0, pictCamera.Width, pictCamera.Height);
            g.Dispose();

            pictCamera.Image = bitmap;

            // Run thread
            threadExecute = new Thread(new ThreadStart(this.ExecuteThead));
            threadExecute.Start();
            btnExecute.Text = "Stop";

            btnParameter.Enabled = false;
            btnRegistration.Enabled = false;

            clsHvcw.GetUserName(textRegistration.Text);
        }

        // ***** Registration (recognition) *****
        private void btnRegistration_Click(object sender, EventArgs e)
        {
            if (clsHvcw.Register(pictRegistration) == ClassHvcw.HVCW_SUCCESS)
            {
                clsHvcw.SetUserName(textRegistration.Text);
                MessageBox.Show("Registration successful", "OK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Registration failed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ***** Set parameters *****
        private void btnParameter_Click(object sender, EventArgs e)
        {
            Params sPrm = new Params();
            sPrm.SetDialog(this, clsHvcw);
        }

        // ***** Screen process *****

        // ***** Compute face direction display point coordinates *****
        private void GetFlemingPos(int inLength, int inYawAngle, int inPitchAngle, int inRollAngle,
                                   ref Point outYawPos, ref Point outPitchPos, ref Point outRollPos)
        {
            double pitchRadian = (double)inPitchAngle / 180.0 * Math.PI;
            double yawRadian = (double)inYawAngle / 180.0 * Math.PI;

            // Compute pitch axis point coordinates when roll is 0 to correct roll
            double xPos = Math.Cos(yawRadian);
            double yPos = -Math.Sin(pitchRadian) * Math.Sin(yawRadian);
            double slope = Math.Atan2(yPos, xPos) * 180.0 / Math.PI;
            int roll = (int)(inRollAngle + slope);
            double rollRadian = (double)roll / 180.0 * Math.PI;

            // Compute axes point coordinates
            outYawPos.X = (int)(Math.Cos(pitchRadian) * Math.Sin(rollRadian) * (double)inLength + 0.5);
            outYawPos.Y = (int)(Math.Cos(pitchRadian) * Math.Cos(rollRadian) * (double)inLength + 0.5);
            outPitchPos.X = (int)((Math.Cos(rollRadian) * Math.Cos(yawRadian) - Math.Sin(rollRadian) * Math.Sin(pitchRadian) * Math.Sin(yawRadian)) * (double)inLength + 0.5);
            outPitchPos.Y = (int)((-Math.Sin(rollRadian) * Math.Cos(yawRadian) - Math.Cos(rollRadian) * Math.Sin(pitchRadian) * Math.Sin(yawRadian)) * (double)inLength + 0.5);
            outRollPos.X = (int)((Math.Sin(yawRadian) * Math.Cos(rollRadian) + Math.Sin(pitchRadian) * Math.Cos(yawRadian) * Math.Sin(rollRadian)) * (double)inLength + 0.5);
            outRollPos.Y = (int)((-Math.Sin(yawRadian) * Math.Sin(rollRadian) + Math.Sin(pitchRadian) * Math.Cos(yawRadian) * Math.Cos(rollRadian)) * (double)inLength + 0.5);
        }
        // ***** Face direction (3 axes) display *****
        private void paintDrawFleming(Graphics g, Point center, int length, int nYaw, int nPitch, int nRoll)
        {
            float ratio = g.ClipBounds.Width / 1920;
            if (ratio > (float)g.ClipBounds.Height / 1080)
            {
                ratio = (float)g.ClipBounds.Height / 1080;
            }
            length = (int)((float)length * ratio) / 2;
            center.X = (int)((float)center.X * ratio);
            center.Y = (int)((float)center.Y * ratio);

            Pen detectPen;
            Point[] po = new Point[2];

            Point yawPos = new Point();
            Point pitchPos = new Point();
            Point rollPos = new Point();
            GetFlemingPos(length, nYaw, nPitch, nRoll, ref yawPos, ref pitchPos, ref rollPos);

            // Compute axes point coordinates
            yawPos.X = center.X + yawPos.X;
            yawPos.Y = center.Y - yawPos.Y;
            pitchPos.X = center.X + pitchPos.X;
            pitchPos.Y = center.Y - pitchPos.Y;
            rollPos.X = center.X + rollPos.X;
            rollPos.Y = center.Y - rollPos.Y;

            // Display
            detectPen = new Pen(Color.FromArgb(0xff, 0xff, 0x00), 2);
            po[0] = center;
            po[1] = pitchPos;
            g.DrawLines(detectPen, po);
            detectPen = new Pen(Color.FromArgb(0x00, 0xff, 0xff), 2);
            po[0] = center;
            po[1] = yawPos;
            g.DrawLines(detectPen, po);
            detectPen = new Pen(Color.FromArgb(0xff, 0x00, 0xff), 2);
            po[0] = center;
            po[1] = rollPos;
            g.DrawLines(detectPen, po);
        }

        // ***** Detection result frame display *****
        private void paintDetectRect(Graphics g, Pen detectPen, int size, int posX, int posY)
        {
            float ratio = g.ClipBounds.Width / 1920;
            if (ratio > (float)g.ClipBounds.Height / 1080)
            {
                ratio = (float)g.ClipBounds.Height / 1080;
            }
            size = (int)((float)size * ratio) / 2;
            int centerX = (int)((float)posX * ratio);
            int centerY = (int)((float)posY * ratio);

            // Compute frame coordinates
            int lx = 0 + centerX - size;
            if (lx < 0) lx = 0;
            int rx = 0 + centerX + size;
            if (rx > (int)g.ClipBounds.Width) rx = (int)g.ClipBounds.Width - 1;
            int ty = 0 + centerY - size;
            if (ty < 0) ty = 0;
            int by = 0 + centerY + size;
            if (by > (int)g.ClipBounds.Height) by = (int)g.ClipBounds.Height - 1;

            // Display
            Point[] po = { new Point(lx, ty), new Point(rx, ty), new Point(rx, by), new Point(lx, by), new Point(lx, ty) };
            g.DrawLines(detectPen, po);
        }

        // ***** Detection result text display *****
        private void paintDrawString(Graphics g, string str1, string str2, string str3, int size, int posX, int posY)
        {
            float ratio = g.ClipBounds.Width / 1920;
            if (ratio > (float)g.ClipBounds.Height / 1080)
            {
                ratio = (float)g.ClipBounds.Height / 1080;
            }
            size = (int)((float)size * ratio) / 2;
            int centerX = (int)((float)posX * ratio);
            int centerY = (int)((float)posY * ratio);
            int lx = 0 + centerX - size;
            if (lx < 0) lx = 0;
            int ty = 0 + centerY - size;
            if (ty < 0) ty = 0;

            Font fnt = new Font("MS UI Gothic", 16, FontStyle.Bold);
            if (str1.Trim().Length > 0)
            {
                // Age, gender and expression display
                ty -= 20;
                g.DrawString(str1.Trim(), fnt, Brushes.Orange, lx - 2, ty);
            }
            if (str2.Trim().Length > 0)
            {
                // Gaze and blink display
                ty -= 20;
                g.DrawString(str2.Trim(), fnt, Brushes.LightPink, lx - 2, ty);
            }
            // Recognition result display
            g.DrawString(str3.Trim(), fnt, Brushes.White, centerX - str3.Trim().Length * 8 + 16, centerY + size - 20);
        }

        // ***** Display event *****
        private void pictCamera_Paint(object sender, PaintEventArgs e)
        {
            if (!radioOkao.Checked)
            {
                return;
            }

            Pen detectPen;
            Graphics g = e.Graphics;

            // Body detection display
            detectPen = new Pen(Color.Blue, 2);
            for (int i = 0; i < clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_BODYS_nCount]; i++)
            {
                paintDetectRect(g, detectPen, clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_BODYS_DETECTION_nSize + i * ClassHvcw.HVCW_OKAO_RESULT_BODYS_DETECTION_SIZE],
                                              clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_BODYS_DETECTION_POINT_nX + i * ClassHvcw.HVCW_OKAO_RESULT_BODYS_DETECTION_SIZE],
                                              clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_BODYS_DETECTION_POINT_nY + i * ClassHvcw.HVCW_OKAO_RESULT_BODYS_DETECTION_SIZE]);
            }

            // 手認識の場合に枠線表示する？
            // Hand detection display
            detectPen = new Pen(Color.Cyan, 2);
            for (int i = 0; i < clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_HANDS_nCount]; i++)
            {
                paintDetectRect(g, detectPen, clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_HANDS_DETECTION_nSize + i * ClassHvcw.HVCW_OKAO_RESULT_HANDS_DETECTION_SIZE],
                                              clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_HANDS_DETECTION_POINT_nX + i * ClassHvcw.HVCW_OKAO_RESULT_HANDS_DETECTION_SIZE],
                                              clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_HANDS_DETECTION_POINT_nY + i * ClassHvcw.HVCW_OKAO_RESULT_HANDS_DETECTION_SIZE]);
            }

            // 顔認識の場合に枠線表示する？
            // Face detection result display
            detectPen = new Pen(Color.Green, 2);
            for (int i = 0; i < clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_FACES_nCount]; i++)
            {
                paintDetectRect(g, detectPen, clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_nSize + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE],
                                              clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_POINT_nX + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE],
                                              clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_POINT_nY + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE]);

                if (checkDirection.CheckState == CheckState.Checked)
                {
                    // Face direction display
                    Point center = new Point();
                    center.X = clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_POINT_nX + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE];
                    center.Y = clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_POINT_nY + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE];
                    int length = clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_nSize + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE];
                    paintDrawFleming(g, center, length, clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_DIRECTION_nLR + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE],
                                                   clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_DIRECTION_nUD + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE],
                                                   clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_DIRECTION_nRoll + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE]);
                }

                string strAge = "";
                if (checkAge.CheckState == CheckState.Checked)
                {
                    // Age display
                    int nAge = clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_AEG_nAge + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE];
                    if (nAge >= 0)
                    {
                        strAge = string.Format("Age {0}", nAge);
                    }
                }

                string strGender = "";
                if (checkGender.CheckState == CheckState.Checked)
                {
                    // Gender display
                    int nGender = clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_GENDER_nGender + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE];
                    if (nGender >= 0)
                    {
                        strGender = (nGender == ClassHvcw.HVCW_GENDER_MALE ? "Male" : "Female");
                    }
                }

                string strGaze = "";
                if (checkGaze.CheckState == CheckState.Checked)
                {
                    // Gaze display
                    int nLR = clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_GAZE_nLR + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE];
                    int nUD = clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_GAZE_nUD + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE];
                    strGaze = string.Format("Gaze({0},{1})", nLR, nUD);
                }

                string strBlink = "";
                if (checkBlink.CheckState == CheckState.Checked)
                {
                    // Blink display
                    int nLeftEye = clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_BLINK_nLeftEye + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE];
                    int nRightEye = clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_BLINK_nRightEye + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE];
                    strBlink = string.Format("Closed({0},{1})", nLeftEye, nRightEye);
                }

                string strExpression = "";
                if (checkExpression.CheckState == CheckState.Checked)
                {
                    // Expression display
                    int topScore = -1;
                    int topExpression = 0;
                    for (int j = 0; j < 5; j++)
                    {
                        int score = clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_EXPRESSION_Neutral + j + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE];
                        if (topScore < score)
                        {
                            topScore = score;
                            topExpression = j + 1;
                        }
                    }
                    string[] ExStr = { "?", "Neutral", "Happiness", "Surprise", "Anger", "Sadness" };
                    strExpression = ExStr[topExpression];
                }

                string strRecognition = "";
                if (checkRecognition.CheckState == CheckState.Checked)
                {
                    // Recognition result display
                    int uid = clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_RECOGNITION_nUID + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE];
                    if (uid == 0)
                    {
                        strRecognition = textRegistration.Text;
                    }
                }

                paintDrawString(g, strAge + " " + strGender + " " + strExpression, strGaze + " " + strBlink, strRecognition,
                                clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_nSize + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE],
                                clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_POINT_nX + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE],
                                clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_POINT_nY + i * ClassHvcw.HVCW_OKAO_RESULT_FACES_DETECTION_SIZE]);

            }
            // ペット認識の場合は枠線表示する？
            // Pet detection result display
            detectPen = new Pen(Color.Yellow, 2);
            for (int i = 0; i < clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_PETS_nCount]; i++)
            {
                paintDetectRect(g, detectPen, clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_PETS_DETECTION_nSize + i * ClassHvcw.HVCW_OKAO_RESULT_PETS_DETECTION_SIZE],
                                              clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_PETS_DETECTION_POINT_nX + i * ClassHvcw.HVCW_OKAO_RESULT_PETS_DETECTION_SIZE],
                                              clsHvcw.resultData[ClassHvcw.HVCW_OKAO_RESULT_PETS_DETECTION_POINT_nY + i * ClassHvcw.HVCW_OKAO_RESULT_PETS_DETECTION_SIZE]);
            }
            detectPen.Dispose();
        }

        // ***** OKAO function checkbox *****

        private void checkBody_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBody.CheckState == CheckState.Checked)
            {
                clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Body] = 1;
            }
            else
            {
                clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Body] = 0;
            }
        }

        private void checkHand_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkHand.CheckState == CheckState.Checked)
            {
                clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Hand] = 1;
            }
            else
            {
                clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Hand] = 0;
            }
        }

        private void checkPet_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkPet.CheckState == CheckState.Checked)
            {
                clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Pet] = 1;
            }
            else
            {
                clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Pet] = 0;
            }
        }

        private void checkFace_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkFace.CheckState == CheckState.Checked)
            {
                clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Face] = 1;
            }
            else
            {
                clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Face] = 0;
            }
        }

        private void checkDirection_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkDirection.CheckState == CheckState.Checked)
            {
                clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Direction] = 1;
            }
            else
            {
                clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Direction] = 0;
            }
        }

        private void checkAge_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkAge.CheckState == CheckState.Checked)
            {
                clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Age] = 1;
            }
            else
            {
                clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Age] = 0;
            }
        }

        private void checkGender_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkGender.CheckState == CheckState.Checked)
            {
                clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Gender] = 1;
            }
            else
            {
                clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Gender] = 0;
            }
        }

        private void checkGaze_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkGaze.CheckState == CheckState.Checked)
            {
                clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Gaze] = 1;
            }
            else
            {
                clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Gaze] = 0;
            }
        }

        private void checkBlink_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBlink.CheckState == CheckState.Checked)
            {
                clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Blink] = 1;
            }
            else
            {
                clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Blink] = 0;
            }
        }

        private void checkExpression_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkExpression.CheckState == CheckState.Checked)
            {
                clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Expression] = 1;
            }
            else
            {
                clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Expression] = 0;
            }
        }

        private void checkRecognition_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkRecognition.CheckState == CheckState.Checked)
            {
                clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Recognition] = 1;
            }
            else
            {
                clsHvcw.execFlag[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Recognition] = 0;
            }
        }
    }
}
