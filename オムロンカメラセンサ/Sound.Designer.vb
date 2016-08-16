<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sound
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.button1 = New System.Windows.Forms.Button()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.textPassword = New System.Windows.Forms.TextBox()
        Me.textSSID = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(270, 165)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(85, 23)
        Me.button1.TabIndex = 13
        Me.button1.Text = "Start pairing"
        Me.button1.UseVisualStyleBackColor = True
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(12, 126)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(343, 36)
        Me.label4.TabIndex = 12
        Me.label4.Text = "Press the function switch on the camera side for 3 seconds. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Bring camera close " &
    "to PC speaker and press pairing start button. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Please wait after playing sound." &
    ""
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(12, 88)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(60, 12)
        Me.label3.TabIndex = 11
        Me.label3.Text = "Password :"
        '
        'textPassword
        '
        Me.textPassword.Location = New System.Drawing.Point(86, 85)
        Me.textPassword.Name = "textPassword"
        Me.textPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.textPassword.Size = New System.Drawing.Size(146, 19)
        Me.textPassword.TabIndex = 10
        Me.textPassword.UseSystemPasswordChar = True
        '
        'textSSID
        '
        Me.textSSID.Location = New System.Drawing.Point(86, 50)
        Me.textSSID.Name = "textSSID"
        Me.textSSID.Size = New System.Drawing.Size(146, 19)
        Me.textSSID.TabIndex = 9
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(12, 53)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(44, 12)
        Me.label2.TabIndex = 8
        Me.label2.Text = " SSID : "
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(324, 24)
        Me.label1.TabIndex = 7
        Me.label1.Text = "Connect camera to WLAN. Please cancel if already connected." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Input WLAN router S" &
    "SID and password." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Sound
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 212)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.textPassword)
        Me.Controls.Add(Me.textSSID)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Name = "Sound"
        Me.Text = "Sound Pairing"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub


    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents textPassword As System.Windows.Forms.TextBox
    Private WithEvents textSSID As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
End Class
