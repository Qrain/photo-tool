namespace OmronCameraDemo
{
    partial class Sound
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textSSID = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connect camera to WLAN. Please cancel if already connected.\r\n Input WLAN router S" +
    "SID and password.\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = " SSID : ";
            // 
            // textSSID
            // 
            this.textSSID.Location = new System.Drawing.Point(127, 57);
            this.textSSID.Name = "textSSID";
            this.textSSID.Size = new System.Drawing.Size(146, 19);
            this.textSSID.TabIndex = 2;
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(127, 82);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(146, 19);
            this.textPassword.TabIndex = 3;
            this.textPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(343, 36);
            this.label4.TabIndex = 5;
            this.label4.Text = "Press the function switch on the camera side for 3 seconds. \r\nBring camera close " +
    "to PC speaker and press pairing start button. \r\nPlease wait after playing sound." +
    "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(265, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Start pairing";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Sound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 196);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textSSID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Sound";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Camera registration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textSSID;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}