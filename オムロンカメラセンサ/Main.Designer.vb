<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class main
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.rbtOkao = New System.Windows.Forms.RadioButton()
        Me.rbtLive = New System.Windows.Forms.RadioButton()
        Me.textRegistration = New System.Windows.Forms.TextBox()
        Me.btnRegistration = New System.Windows.Forms.Button()
        Me.pictRegistration = New System.Windows.Forms.PictureBox()
        Me.groupExec = New System.Windows.Forms.GroupBox()
        Me.groupRegistration = New System.Windows.Forms.GroupBox()
        Me.chkRecognition = New System.Windows.Forms.CheckBox()
        Me.btnExecute = New System.Windows.Forms.Button()
        Me.btnParameter = New System.Windows.Forms.Button()
        Me.chkExpression = New System.Windows.Forms.CheckBox()
        Me.chkBlink = New System.Windows.Forms.CheckBox()
        Me.textEmail = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.pictCamera = New System.Windows.Forms.PictureBox()
        Me.chkGaze = New System.Windows.Forms.CheckBox()
        Me.chkGender = New System.Windows.Forms.CheckBox()
        Me.chkAge = New System.Windows.Forms.CheckBox()
        Me.checkDirection = New System.Windows.Forms.CheckBox()
        Me.checkPet = New System.Windows.Forms.CheckBox()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.textPassword = New System.Windows.Forms.TextBox()
        Me.checkFace = New System.Windows.Forms.CheckBox()
        Me.checkHand = New System.Windows.Forms.CheckBox()
        Me.groupOkao = New System.Windows.Forms.GroupBox()
        Me.checkBody = New System.Windows.Forms.CheckBox()
        Me.comboCameraList = New System.Windows.Forms.ComboBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.btnConnect = New System.Windows.Forms.Button()
        CType(Me.pictRegistration, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupExec.SuspendLayout()
        Me.groupRegistration.SuspendLayout()
        CType(Me.pictCamera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupOkao.SuspendLayout()
        Me.SuspendLayout()
        '
        'radioOkao
        '
        Me.rbtOkao.AutoSize = True
        Me.rbtOkao.Checked = True
        Me.rbtOkao.Location = New System.Drawing.Point(18, 68)
        Me.rbtOkao.Name = "radioOkao"
        Me.rbtOkao.Size = New System.Drawing.Size(49, 16)
        Me.rbtOkao.TabIndex = 15
        Me.rbtOkao.TabStop = True
        Me.rbtOkao.Text = "Okao"
        Me.rbtOkao.UseVisualStyleBackColor = True
        '
        'radioLive
        '
        Me.rbtLive.AutoSize = True
        Me.rbtLive.Location = New System.Drawing.Point(18, 37)
        Me.rbtLive.Name = "radioLive"
        Me.rbtLive.Size = New System.Drawing.Size(44, 16)
        Me.rbtLive.TabIndex = 14
        Me.rbtLive.Text = "Live"
        Me.rbtLive.UseVisualStyleBackColor = True
        '
        'textRegistration
        '
        Me.textRegistration.Location = New System.Drawing.Point(6, 20)
        Me.textRegistration.Name = "textRegistration"
        Me.textRegistration.Size = New System.Drawing.Size(80, 19)
        Me.textRegistration.TabIndex = 2
        '
        'btnRegistration
        '
        Me.btnRegistration.Location = New System.Drawing.Point(97, 18)
        Me.btnRegistration.Name = "btnRegistration"
        Me.btnRegistration.Size = New System.Drawing.Size(75, 23)
        Me.btnRegistration.TabIndex = 1
        Me.btnRegistration.Text = "Regist."
        Me.btnRegistration.UseVisualStyleBackColor = True
        '
        'pictRegistration
        '
        Me.pictRegistration.Enabled = False
        Me.pictRegistration.Location = New System.Drawing.Point(36, 57)
        Me.pictRegistration.Name = "pictRegistration"
        Me.pictRegistration.Size = New System.Drawing.Size(128, 128)
        Me.pictRegistration.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictRegistration.TabIndex = 0
        Me.pictRegistration.TabStop = False
        Me.pictRegistration.Visible = False
        '
        'groupExec
        '
        Me.groupExec.Controls.Add(Me.rbtOkao)
        Me.groupExec.Controls.Add(Me.rbtLive)
        Me.groupExec.Location = New System.Drawing.Point(12, 97)
        Me.groupExec.Name = "groupExec"
        Me.groupExec.Size = New System.Drawing.Size(116, 114)
        Me.groupExec.TabIndex = 28
        Me.groupExec.TabStop = False
        Me.groupExec.Text = "Function selection"
        '
        'groupRegistration
        '
        Me.groupRegistration.Controls.Add(Me.textRegistration)
        Me.groupRegistration.Controls.Add(Me.btnRegistration)
        Me.groupRegistration.Controls.Add(Me.pictRegistration)
        Me.groupRegistration.Location = New System.Drawing.Point(515, 12)
        Me.groupRegistration.Name = "groupRegistration"
        Me.groupRegistration.Size = New System.Drawing.Size(192, 199)
        Me.groupRegistration.TabIndex = 27
        Me.groupRegistration.TabStop = False
        Me.groupRegistration.Text = "Recognition Registration"
        '
        'checkRecognition
        '
        Me.chkRecognition.AutoSize = True
        Me.chkRecognition.Location = New System.Drawing.Point(18, 84)
        Me.chkRecognition.Name = "checkRecognition"
        Me.chkRecognition.Size = New System.Drawing.Size(84, 16)
        Me.chkRecognition.TabIndex = 10
        Me.chkRecognition.Text = "Recognition"
        Me.chkRecognition.UseVisualStyleBackColor = True
        '
        'btnExecute
        '
        Me.btnExecute.Location = New System.Drawing.Point(269, 77)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(90, 23)
        Me.btnExecute.TabIndex = 12
        Me.btnExecute.Text = "Execute"
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'btnParameter
        '
        Me.btnParameter.Location = New System.Drawing.Point(269, 18)
        Me.btnParameter.Name = "btnParameter"
        Me.btnParameter.Size = New System.Drawing.Size(90, 23)
        Me.btnParameter.TabIndex = 13
        Me.btnParameter.Text = "Settings"
        Me.btnParameter.UseVisualStyleBackColor = True
        '
        'checkExpression
        '
        Me.chkExpression.AutoSize = True
        Me.chkExpression.Location = New System.Drawing.Point(111, 84)
        Me.chkExpression.Name = "checkExpression"
        Me.chkExpression.Size = New System.Drawing.Size(80, 16)
        Me.chkExpression.TabIndex = 9
        Me.chkExpression.Text = "Expression"
        Me.chkExpression.UseVisualStyleBackColor = True
        '
        'checkBlink
        '
        Me.chkBlink.AutoSize = True
        Me.chkBlink.Location = New System.Drawing.Point(111, 62)
        Me.chkBlink.Name = "checkBlink"
        Me.chkBlink.Size = New System.Drawing.Size(50, 16)
        Me.chkBlink.TabIndex = 8
        Me.chkBlink.Text = "Blink"
        Me.chkBlink.UseVisualStyleBackColor = True
        '
        'textEmail
        '
        Me.textEmail.Location = New System.Drawing.Point(109, 6)
        Me.textEmail.Name = "textEmail"
        Me.textEmail.Size = New System.Drawing.Size(250, 19)
        Me.textEmail.TabIndex = 19
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(12, 34)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(64, 12)
        Me.label2.TabIndex = 18
        Me.label2.Text = "Password : "
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(87, 12)
        Me.label1.TabIndex = 17
        Me.label1.Text = "Email address : "
        '
        'pictCamera
        '
        Me.pictCamera.Location = New System.Drawing.Point(12, 217)
        Me.pictCamera.Name = "pictCamera"
        Me.pictCamera.Size = New System.Drawing.Size(695, 360)
        Me.pictCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictCamera.TabIndex = 16
        Me.pictCamera.TabStop = False
        '
        'checkGaze
        '
        Me.chkGaze.AutoSize = True
        Me.chkGaze.Location = New System.Drawing.Point(18, 62)
        Me.chkGaze.Name = "checkGaze"
        Me.chkGaze.Size = New System.Drawing.Size(49, 16)
        Me.chkGaze.TabIndex = 7
        Me.chkGaze.Text = "Gaze"
        Me.chkGaze.UseVisualStyleBackColor = True
        '
        'checkGender
        '
        Me.chkGender.AutoSize = True
        Me.chkGender.Location = New System.Drawing.Point(200, 62)
        Me.chkGender.Name = "checkGender"
        Me.chkGender.Size = New System.Drawing.Size(60, 16)
        Me.chkGender.TabIndex = 6
        Me.chkGender.Text = "Gender"
        Me.chkGender.UseVisualStyleBackColor = True
        '
        'checkAge
        '
        Me.chkAge.AutoSize = True
        Me.chkAge.Location = New System.Drawing.Point(200, 40)
        Me.chkAge.Name = "checkAge"
        Me.chkAge.Size = New System.Drawing.Size(44, 16)
        Me.chkAge.TabIndex = 5
        Me.chkAge.Text = "Age"
        Me.chkAge.UseVisualStyleBackColor = True
        '
        'checkDirection
        '
        Me.checkDirection.AutoSize = True
        Me.checkDirection.Location = New System.Drawing.Point(111, 40)
        Me.checkDirection.Name = "checkDirection"
        Me.checkDirection.Size = New System.Drawing.Size(70, 16)
        Me.checkDirection.TabIndex = 4
        Me.checkDirection.Text = "Direction"
        Me.checkDirection.UseVisualStyleBackColor = True
        '
        'checkPet
        '
        Me.checkPet.AutoSize = True
        Me.checkPet.Location = New System.Drawing.Point(200, 18)
        Me.checkPet.Name = "checkPet"
        Me.checkPet.Size = New System.Drawing.Size(41, 16)
        Me.checkPet.TabIndex = 3
        Me.checkPet.Text = "Pet"
        Me.checkPet.UseVisualStyleBackColor = True
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(403, 4)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(90, 23)
        Me.btnGenerate.TabIndex = 21
        Me.btnGenerate.Text = "User regist."
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'textPassword
        '
        Me.textPassword.Location = New System.Drawing.Point(109, 31)
        Me.textPassword.Name = "textPassword"
        Me.textPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.textPassword.Size = New System.Drawing.Size(250, 19)
        Me.textPassword.TabIndex = 20
        Me.textPassword.UseSystemPasswordChar = True
        '
        'checkFace
        '
        Me.checkFace.AutoSize = True
        Me.checkFace.Location = New System.Drawing.Point(18, 40)
        Me.checkFace.Name = "checkFace"
        Me.checkFace.Size = New System.Drawing.Size(49, 16)
        Me.checkFace.TabIndex = 2
        Me.checkFace.Text = "Face"
        Me.checkFace.UseVisualStyleBackColor = True
        '
        'checkHand
        '
        Me.checkHand.AutoSize = True
        Me.checkHand.Location = New System.Drawing.Point(111, 18)
        Me.checkHand.Name = "checkHand"
        Me.checkHand.Size = New System.Drawing.Size(50, 16)
        Me.checkHand.TabIndex = 1
        Me.checkHand.Text = "Hand"
        Me.checkHand.UseVisualStyleBackColor = True
        '
        'groupOkao
        '
        Me.groupOkao.Controls.Add(Me.chkRecognition)
        Me.groupOkao.Controls.Add(Me.btnExecute)
        Me.groupOkao.Controls.Add(Me.btnParameter)
        Me.groupOkao.Controls.Add(Me.chkExpression)
        Me.groupOkao.Controls.Add(Me.chkBlink)
        Me.groupOkao.Controls.Add(Me.chkGaze)
        Me.groupOkao.Controls.Add(Me.chkGender)
        Me.groupOkao.Controls.Add(Me.chkAge)
        Me.groupOkao.Controls.Add(Me.checkDirection)
        Me.groupOkao.Controls.Add(Me.checkPet)
        Me.groupOkao.Controls.Add(Me.checkFace)
        Me.groupOkao.Controls.Add(Me.checkHand)
        Me.groupOkao.Controls.Add(Me.checkBody)
        Me.groupOkao.Location = New System.Drawing.Point(134, 97)
        Me.groupOkao.Name = "groupOkao"
        Me.groupOkao.Size = New System.Drawing.Size(375, 114)
        Me.groupOkao.TabIndex = 26
        Me.groupOkao.TabStop = False
        Me.groupOkao.Text = "OKAO function"
        '
        'checkBody
        '
        Me.checkBody.AutoSize = True
        Me.checkBody.Location = New System.Drawing.Point(18, 18)
        Me.checkBody.Name = "checkBody"
        Me.checkBody.Size = New System.Drawing.Size(50, 16)
        Me.checkBody.TabIndex = 0
        Me.checkBody.Text = "Body"
        Me.checkBody.UseVisualStyleBackColor = True
        '
        'comboCameraList
        '
        Me.comboCameraList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboCameraList.FormattingEnabled = True
        Me.comboCameraList.Location = New System.Drawing.Point(109, 56)
        Me.comboCameraList.Name = "comboCameraList"
        Me.comboCameraList.Size = New System.Drawing.Size(250, 20)
        Me.comboCameraList.TabIndex = 24
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(12, 59)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(88, 12)
        Me.label3.TabIndex = 23
        Me.label3.Text = "Select camera : "
        '
        'btnLogin
        '
        Me.btnLogin.Location = New System.Drawing.Point(403, 29)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(90, 23)
        Me.btnLogin.TabIndex = 22
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(403, 54)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(90, 23)
        Me.btnConnect.TabIndex = 25
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(717, 589)
        Me.Controls.Add(Me.groupExec)
        Me.Controls.Add(Me.groupRegistration)
        Me.Controls.Add(Me.textEmail)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.pictCamera)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.textPassword)
        Me.Controls.Add(Me.groupOkao)
        Me.Controls.Add(Me.comboCameraList)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.btnConnect)
        Me.Name = "main"
        Me.Text = "Form1"
        CType(Me.pictRegistration, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupExec.ResumeLayout(False)
        Me.groupExec.PerformLayout()
        Me.groupRegistration.ResumeLayout(False)
        Me.groupRegistration.PerformLayout()
        CType(Me.pictCamera, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupOkao.ResumeLayout(False)
        Me.groupOkao.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents rbtOkao As System.Windows.Forms.RadioButton
    Private WithEvents rbtLive As System.Windows.Forms.RadioButton
    Private WithEvents textRegistration As System.Windows.Forms.TextBox
    Private WithEvents btnRegistration As System.Windows.Forms.Button
    Private WithEvents pictRegistration As System.Windows.Forms.PictureBox
    Private WithEvents groupExec As System.Windows.Forms.GroupBox
    Private WithEvents groupRegistration As System.Windows.Forms.GroupBox
    Private WithEvents chkRecognition As System.Windows.Forms.CheckBox
    Private WithEvents btnExecute As System.Windows.Forms.Button
    Private WithEvents btnParameter As System.Windows.Forms.Button
    Private WithEvents chkExpression As System.Windows.Forms.CheckBox
    Private WithEvents chkBlink As System.Windows.Forms.CheckBox
    Private WithEvents textEmail As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents pictCamera As System.Windows.Forms.PictureBox
    Private WithEvents chkGaze As System.Windows.Forms.CheckBox
    Private WithEvents chkGender As System.Windows.Forms.CheckBox
    Private WithEvents chkAge As System.Windows.Forms.CheckBox
    Private WithEvents checkDirection As System.Windows.Forms.CheckBox
    Private WithEvents checkPet As System.Windows.Forms.CheckBox
    Private WithEvents btnGenerate As System.Windows.Forms.Button
    Private WithEvents textPassword As System.Windows.Forms.TextBox
    Private WithEvents checkFace As System.Windows.Forms.CheckBox
    Private WithEvents checkHand As System.Windows.Forms.CheckBox
    Private WithEvents groupOkao As System.Windows.Forms.GroupBox
    Private WithEvents checkBody As System.Windows.Forms.CheckBox
    Private WithEvents comboCameraList As System.Windows.Forms.ComboBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents btnLogin As System.Windows.Forms.Button
    Private WithEvents btnConnect As System.Windows.Forms.Button
End Class
