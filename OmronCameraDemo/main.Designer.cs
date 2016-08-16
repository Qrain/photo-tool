namespace OmronCameraDemo
{
    partial class main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictCamera = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboCameraList = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.groupOkao = new System.Windows.Forms.GroupBox();
            this.checkRecognition = new System.Windows.Forms.CheckBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnParameter = new System.Windows.Forms.Button();
            this.checkExpression = new System.Windows.Forms.CheckBox();
            this.checkBlink = new System.Windows.Forms.CheckBox();
            this.checkGaze = new System.Windows.Forms.CheckBox();
            this.checkGender = new System.Windows.Forms.CheckBox();
            this.checkAge = new System.Windows.Forms.CheckBox();
            this.checkDirection = new System.Windows.Forms.CheckBox();
            this.checkPet = new System.Windows.Forms.CheckBox();
            this.checkFace = new System.Windows.Forms.CheckBox();
            this.checkHand = new System.Windows.Forms.CheckBox();
            this.checkBody = new System.Windows.Forms.CheckBox();
            this.groupRegistration = new System.Windows.Forms.GroupBox();
            this.textRegistration = new System.Windows.Forms.TextBox();
            this.btnRegistration = new System.Windows.Forms.Button();
            this.pictRegistration = new System.Windows.Forms.PictureBox();
            this.radioLive = new System.Windows.Forms.RadioButton();
            this.groupExec = new System.Windows.Forms.GroupBox();
            this.radioOkao = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictCamera)).BeginInit();
            this.groupOkao.SuspendLayout();
            this.groupRegistration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictRegistration)).BeginInit();
            this.groupExec.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictCamera
            // 
            this.pictCamera.Location = new System.Drawing.Point(12, 198);
            this.pictCamera.Name = "pictCamera";
            this.pictCamera.Size = new System.Drawing.Size(640, 360);
            this.pictCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictCamera.TabIndex = 0;
            this.pictCamera.TabStop = false;
            this.pictCamera.Paint += new System.Windows.Forms.PaintEventHandler(this.pictCamera_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Email address : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password : ";
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(101, 6);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(250, 19);
            this.textEmail.TabIndex = 3;
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(101, 29);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(250, 19);
            this.textPassword.TabIndex = 4;
            this.textPassword.UseSystemPasswordChar = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(373, 4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "User regist.";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(373, 27);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Select camera : ";
            // 
            // comboCameraList
            // 
            this.comboCameraList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCameraList.FormattingEnabled = true;
            this.comboCameraList.Location = new System.Drawing.Point(101, 60);
            this.comboCameraList.Name = "comboCameraList";
            this.comboCameraList.Size = new System.Drawing.Size(250, 20);
            this.comboCameraList.TabIndex = 8;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(373, 58);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 9;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // groupOkao
            // 
            this.groupOkao.Controls.Add(this.checkRecognition);
            this.groupOkao.Controls.Add(this.btnExecute);
            this.groupOkao.Controls.Add(this.btnParameter);
            this.groupOkao.Controls.Add(this.checkExpression);
            this.groupOkao.Controls.Add(this.checkBlink);
            this.groupOkao.Controls.Add(this.checkGaze);
            this.groupOkao.Controls.Add(this.checkGender);
            this.groupOkao.Controls.Add(this.checkAge);
            this.groupOkao.Controls.Add(this.checkDirection);
            this.groupOkao.Controls.Add(this.checkPet);
            this.groupOkao.Controls.Add(this.checkFace);
            this.groupOkao.Controls.Add(this.checkHand);
            this.groupOkao.Controls.Add(this.checkBody);
            this.groupOkao.Location = new System.Drawing.Point(195, 87);
            this.groupOkao.Name = "groupOkao";
            this.groupOkao.Size = new System.Drawing.Size(457, 106);
            this.groupOkao.TabIndex = 10;
            this.groupOkao.TabStop = false;
            this.groupOkao.Text = "OKAO function";
            // 
            // checkRecognition
            // 
            this.checkRecognition.AutoSize = true;
            this.checkRecognition.Location = new System.Drawing.Point(95, 84);
            this.checkRecognition.Name = "checkRecognition";
            this.checkRecognition.Size = new System.Drawing.Size(84, 16);
            this.checkRecognition.TabIndex = 10;
            this.checkRecognition.Text = "Recognition";
            this.checkRecognition.UseVisualStyleBackColor = true;
            this.checkRecognition.CheckStateChanged += new System.EventHandler(this.checkRecognition_CheckStateChanged);
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(361, 77);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(90, 23);
            this.btnExecute.TabIndex = 12;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnParameter
            // 
            this.btnParameter.Location = new System.Drawing.Point(361, 48);
            this.btnParameter.Name = "btnParameter";
            this.btnParameter.Size = new System.Drawing.Size(90, 23);
            this.btnParameter.TabIndex = 13;
            this.btnParameter.Text = "Settings";
            this.btnParameter.UseVisualStyleBackColor = true;
            this.btnParameter.Click += new System.EventHandler(this.btnParameter_Click);
            // 
            // checkExpression
            // 
            this.checkExpression.AutoSize = true;
            this.checkExpression.Location = new System.Drawing.Point(259, 62);
            this.checkExpression.Name = "checkExpression";
            this.checkExpression.Size = new System.Drawing.Size(80, 16);
            this.checkExpression.TabIndex = 9;
            this.checkExpression.Text = "Expression";
            this.checkExpression.UseVisualStyleBackColor = true;
            this.checkExpression.CheckStateChanged += new System.EventHandler(this.checkExpression_CheckStateChanged);
            // 
            // checkBlink
            // 
            this.checkBlink.AutoSize = true;
            this.checkBlink.Location = new System.Drawing.Point(182, 62);
            this.checkBlink.Name = "checkBlink";
            this.checkBlink.Size = new System.Drawing.Size(50, 16);
            this.checkBlink.TabIndex = 8;
            this.checkBlink.Text = "Blink";
            this.checkBlink.UseVisualStyleBackColor = true;
            this.checkBlink.CheckStateChanged += new System.EventHandler(this.checkBlink_CheckStateChanged);
            // 
            // checkGaze
            // 
            this.checkGaze.AutoSize = true;
            this.checkGaze.Location = new System.Drawing.Point(95, 62);
            this.checkGaze.Name = "checkGaze";
            this.checkGaze.Size = new System.Drawing.Size(49, 16);
            this.checkGaze.TabIndex = 7;
            this.checkGaze.Text = "Gaze";
            this.checkGaze.UseVisualStyleBackColor = true;
            this.checkGaze.CheckStateChanged += new System.EventHandler(this.checkGaze_CheckStateChanged);
            // 
            // checkGender
            // 
            this.checkGender.AutoSize = true;
            this.checkGender.Location = new System.Drawing.Point(259, 40);
            this.checkGender.Name = "checkGender";
            this.checkGender.Size = new System.Drawing.Size(60, 16);
            this.checkGender.TabIndex = 6;
            this.checkGender.Text = "Gender";
            this.checkGender.UseVisualStyleBackColor = true;
            this.checkGender.CheckStateChanged += new System.EventHandler(this.checkGender_CheckStateChanged);
            // 
            // checkAge
            // 
            this.checkAge.AutoSize = true;
            this.checkAge.Location = new System.Drawing.Point(182, 40);
            this.checkAge.Name = "checkAge";
            this.checkAge.Size = new System.Drawing.Size(44, 16);
            this.checkAge.TabIndex = 5;
            this.checkAge.Text = "Age";
            this.checkAge.UseVisualStyleBackColor = true;
            this.checkAge.CheckStateChanged += new System.EventHandler(this.checkAge_CheckStateChanged);
            // 
            // checkDirection
            // 
            this.checkDirection.AutoSize = true;
            this.checkDirection.Location = new System.Drawing.Point(95, 40);
            this.checkDirection.Name = "checkDirection";
            this.checkDirection.Size = new System.Drawing.Size(70, 16);
            this.checkDirection.TabIndex = 4;
            this.checkDirection.Text = "Direction";
            this.checkDirection.UseVisualStyleBackColor = true;
            this.checkDirection.CheckStateChanged += new System.EventHandler(this.checkDirection_CheckStateChanged);
            // 
            // checkPet
            // 
            this.checkPet.AutoSize = true;
            this.checkPet.Location = new System.Drawing.Point(182, 18);
            this.checkPet.Name = "checkPet";
            this.checkPet.Size = new System.Drawing.Size(41, 16);
            this.checkPet.TabIndex = 3;
            this.checkPet.Text = "Pet";
            this.checkPet.UseVisualStyleBackColor = true;
            this.checkPet.CheckStateChanged += new System.EventHandler(this.checkPet_CheckStateChanged);
            // 
            // checkFace
            // 
            this.checkFace.AutoSize = true;
            this.checkFace.Location = new System.Drawing.Point(18, 40);
            this.checkFace.Name = "checkFace";
            this.checkFace.Size = new System.Drawing.Size(49, 16);
            this.checkFace.TabIndex = 2;
            this.checkFace.Text = "Face";
            this.checkFace.UseVisualStyleBackColor = true;
            this.checkFace.CheckStateChanged += new System.EventHandler(this.checkFace_CheckStateChanged);
            // 
            // checkHand
            // 
            this.checkHand.AutoSize = true;
            this.checkHand.Location = new System.Drawing.Point(95, 18);
            this.checkHand.Name = "checkHand";
            this.checkHand.Size = new System.Drawing.Size(50, 16);
            this.checkHand.TabIndex = 1;
            this.checkHand.Text = "Hand";
            this.checkHand.UseVisualStyleBackColor = true;
            this.checkHand.CheckStateChanged += new System.EventHandler(this.checkHand_CheckStateChanged);
            // 
            // checkBody
            // 
            this.checkBody.AutoSize = true;
            this.checkBody.Location = new System.Drawing.Point(18, 18);
            this.checkBody.Name = "checkBody";
            this.checkBody.Size = new System.Drawing.Size(50, 16);
            this.checkBody.TabIndex = 0;
            this.checkBody.Text = "Body";
            this.checkBody.UseVisualStyleBackColor = true;
            this.checkBody.CheckStateChanged += new System.EventHandler(this.checkBody_CheckStateChanged);
            // 
            // groupRegistration
            // 
            this.groupRegistration.Controls.Add(this.textRegistration);
            this.groupRegistration.Controls.Add(this.btnRegistration);
            this.groupRegistration.Controls.Add(this.pictRegistration);
            this.groupRegistration.Location = new System.Drawing.Point(470, 9);
            this.groupRegistration.Name = "groupRegistration";
            this.groupRegistration.Size = new System.Drawing.Size(182, 72);
            this.groupRegistration.TabIndex = 11;
            this.groupRegistration.TabStop = false;
            this.groupRegistration.Text = "Recognition Registration";
            // 
            // textRegistration
            // 
            this.textRegistration.Location = new System.Drawing.Point(6, 20);
            this.textRegistration.Name = "textRegistration";
            this.textRegistration.Size = new System.Drawing.Size(80, 19);
            this.textRegistration.TabIndex = 2;
            // 
            // btnRegistration
            // 
            this.btnRegistration.Location = new System.Drawing.Point(97, 18);
            this.btnRegistration.Name = "btnRegistration";
            this.btnRegistration.Size = new System.Drawing.Size(75, 23);
            this.btnRegistration.TabIndex = 1;
            this.btnRegistration.Text = "Regist.";
            this.btnRegistration.UseVisualStyleBackColor = true;
            this.btnRegistration.Click += new System.EventHandler(this.btnRegistration_Click);
            // 
            // pictRegistration
            // 
            this.pictRegistration.Enabled = false;
            this.pictRegistration.Location = new System.Drawing.Point(44, 48);
            this.pictRegistration.Name = "pictRegistration";
            this.pictRegistration.Size = new System.Drawing.Size(128, 128);
            this.pictRegistration.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictRegistration.TabIndex = 0;
            this.pictRegistration.TabStop = false;
            this.pictRegistration.Visible = false;
            // 
            // radioLive
            // 
            this.radioLive.AutoSize = true;
            this.radioLive.Location = new System.Drawing.Point(18, 24);
            this.radioLive.Name = "radioLive";
            this.radioLive.Size = new System.Drawing.Size(44, 16);
            this.radioLive.TabIndex = 14;
            this.radioLive.Text = "Live";
            this.radioLive.UseVisualStyleBackColor = true;
            this.radioLive.CheckedChanged += new System.EventHandler(this.radioLive_CheckedChanged);
            // 
            // groupExec
            // 
            this.groupExec.Controls.Add(this.radioOkao);
            this.groupExec.Controls.Add(this.radioLive);
            this.groupExec.Location = new System.Drawing.Point(14, 87);
            this.groupExec.Name = "groupExec";
            this.groupExec.Size = new System.Drawing.Size(175, 56);
            this.groupExec.TabIndex = 15;
            this.groupExec.TabStop = false;
            this.groupExec.Text = "Function selection";
            // 
            // radioOkao
            // 
            this.radioOkao.AutoSize = true;
            this.radioOkao.Checked = true;
            this.radioOkao.Location = new System.Drawing.Point(92, 24);
            this.radioOkao.Name = "radioOkao";
            this.radioOkao.Size = new System.Drawing.Size(49, 16);
            this.radioOkao.TabIndex = 15;
            this.radioOkao.TabStop = true;
            this.radioOkao.Text = "Okao";
            this.radioOkao.UseVisualStyleBackColor = true;
            this.radioOkao.CheckedChanged += new System.EventHandler(this.radioOkao_CheckedChanged);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 567);
            this.Controls.Add(this.groupExec);
            this.Controls.Add(this.groupRegistration);
            this.Controls.Add(this.groupOkao);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.comboCameraList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictCamera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HVCC2W StandardDemo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.main_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictCamera)).EndInit();
            this.groupOkao.ResumeLayout(false);
            this.groupOkao.PerformLayout();
            this.groupRegistration.ResumeLayout(false);
            this.groupRegistration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictRegistration)).EndInit();
            this.groupExec.ResumeLayout(false);
            this.groupExec.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictCamera;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboCameraList;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox groupOkao;
        private System.Windows.Forms.CheckBox checkGaze;
        private System.Windows.Forms.CheckBox checkGender;
        private System.Windows.Forms.CheckBox checkAge;
        private System.Windows.Forms.CheckBox checkDirection;
        private System.Windows.Forms.CheckBox checkPet;
        private System.Windows.Forms.CheckBox checkFace;
        private System.Windows.Forms.CheckBox checkHand;
        private System.Windows.Forms.CheckBox checkBody;
        private System.Windows.Forms.CheckBox checkRecognition;
        private System.Windows.Forms.CheckBox checkExpression;
        private System.Windows.Forms.CheckBox checkBlink;
        private System.Windows.Forms.GroupBox groupRegistration;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.TextBox textRegistration;
        private System.Windows.Forms.Button btnRegistration;
        private System.Windows.Forms.PictureBox pictRegistration;
        private System.Windows.Forms.Button btnParameter;
        private System.Windows.Forms.RadioButton radioLive;
        private System.Windows.Forms.GroupBox groupExec;
        private System.Windows.Forms.RadioButton radioOkao;
    }
}

