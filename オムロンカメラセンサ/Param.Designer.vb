Imports System

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Params
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
        Me.numericRecogThresh = New System.Windows.Forms.NumericUpDown()
        Me.labelRecog = New System.Windows.Forms.Label()
        Me.numericPdMin = New System.Windows.Forms.NumericUpDown()
        Me.numericPdMax = New System.Windows.Forms.NumericUpDown()
        Me.numericPdThresh = New System.Windows.Forms.NumericUpDown()
        Me.labelPet = New System.Windows.Forms.Label()
        Me.numericHdMin = New System.Windows.Forms.NumericUpDown()
        Me.numericHdMax = New System.Windows.Forms.NumericUpDown()
        Me.numericHdThresh = New System.Windows.Forms.NumericUpDown()
        Me.labelMinSize = New System.Windows.Forms.Label()
        Me.numericDtMin = New System.Windows.Forms.NumericUpDown()
        Me.labelThresh = New System.Windows.Forms.Label()
        Me.numericDtMax = New System.Windows.Forms.NumericUpDown()
        Me.numericBdThresh = New System.Windows.Forms.NumericUpDown()
        Me.numericDtThresh = New System.Windows.Forms.NumericUpDown()
        Me.numericBdMax = New System.Windows.Forms.NumericUpDown()
        Me.labelHand = New System.Windows.Forms.Label()
        Me.labelMaxSize = New System.Windows.Forms.Label()
        Me.labelFace = New System.Windows.Forms.Label()
        Me.numericBdMin = New System.Windows.Forms.NumericUpDown()
        Me.labelBody = New System.Windows.Forms.Label()
        CType(Me.numericRecogThresh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericPdMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericPdMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericPdThresh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericHdMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericHdMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericHdThresh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericDtMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericDtMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericBdThresh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericDtThresh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericBdMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericBdMin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(201, 157)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(75, 23)
        Me.button1.TabIndex = 48
        Me.button1.Text = "Settings"
        Me.button1.UseVisualStyleBackColor = True
        '
        'numericRecogThresh
        '
        Me.numericRecogThresh.Location = New System.Drawing.Point(216, 126)
        Me.numericRecogThresh.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numericRecogThresh.Name = "numericRecogThresh"
        Me.numericRecogThresh.Size = New System.Drawing.Size(60, 19)
        Me.numericRecogThresh.TabIndex = 47
        Me.numericRecogThresh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numericRecogThresh.Value = New Decimal(New Integer() {500, 0, 0, 0})
        '
        'labelRecog
        '
        Me.labelRecog.AutoSize = True
        Me.labelRecog.Location = New System.Drawing.Point(11, 128)
        Me.labelRecog.Name = "labelRecog"
        Me.labelRecog.Size = New System.Drawing.Size(37, 12)
        Me.labelRecog.TabIndex = 46
        Me.labelRecog.Text = "Recog"
        '
        'numericPdMin
        '
        Me.numericPdMin.Location = New System.Drawing.Point(59, 76)
        Me.numericPdMin.Maximum = New Decimal(New Integer() {8192, 0, 0, 0})
        Me.numericPdMin.Minimum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.numericPdMin.Name = "numericPdMin"
        Me.numericPdMin.Size = New System.Drawing.Size(60, 19)
        Me.numericPdMin.TabIndex = 44
        Me.numericPdMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numericPdMin.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'numericPdMax
        '
        Me.numericPdMax.Location = New System.Drawing.Point(139, 76)
        Me.numericPdMax.Maximum = New Decimal(New Integer() {8192, 0, 0, 0})
        Me.numericPdMax.Minimum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.numericPdMax.Name = "numericPdMax"
        Me.numericPdMax.Size = New System.Drawing.Size(60, 19)
        Me.numericPdMax.TabIndex = 43
        Me.numericPdMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numericPdMax.Value = New Decimal(New Integer() {1200, 0, 0, 0})
        '
        'numericPdThresh
        '
        Me.numericPdThresh.Location = New System.Drawing.Point(216, 76)
        Me.numericPdThresh.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numericPdThresh.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numericPdThresh.Name = "numericPdThresh"
        Me.numericPdThresh.Size = New System.Drawing.Size(60, 19)
        Me.numericPdThresh.TabIndex = 45
        Me.numericPdThresh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numericPdThresh.Value = New Decimal(New Integer() {500, 0, 0, 0})
        '
        'labelPet
        '
        Me.labelPet.AutoSize = True
        Me.labelPet.Location = New System.Drawing.Point(12, 78)
        Me.labelPet.Name = "labelPet"
        Me.labelPet.Size = New System.Drawing.Size(22, 12)
        Me.labelPet.TabIndex = 42
        Me.labelPet.Text = "Pet"
        '
        'numericHdMin
        '
        Me.numericHdMin.Location = New System.Drawing.Point(59, 51)
        Me.numericHdMin.Maximum = New Decimal(New Integer() {8192, 0, 0, 0})
        Me.numericHdMin.Minimum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.numericHdMin.Name = "numericHdMin"
        Me.numericHdMin.Size = New System.Drawing.Size(60, 19)
        Me.numericHdMin.TabIndex = 40
        Me.numericHdMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numericHdMin.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'numericHdMax
        '
        Me.numericHdMax.Location = New System.Drawing.Point(139, 51)
        Me.numericHdMax.Maximum = New Decimal(New Integer() {8192, 0, 0, 0})
        Me.numericHdMax.Minimum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.numericHdMax.Name = "numericHdMax"
        Me.numericHdMax.Size = New System.Drawing.Size(60, 19)
        Me.numericHdMax.TabIndex = 39
        Me.numericHdMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numericHdMax.Value = New Decimal(New Integer() {1200, 0, 0, 0})
        '
        'numericHdThresh
        '
        Me.numericHdThresh.Location = New System.Drawing.Point(216, 51)
        Me.numericHdThresh.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numericHdThresh.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numericHdThresh.Name = "numericHdThresh"
        Me.numericHdThresh.Size = New System.Drawing.Size(60, 19)
        Me.numericHdThresh.TabIndex = 41
        Me.numericHdThresh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numericHdThresh.Value = New Decimal(New Integer() {500, 0, 0, 0})
        '
        'labelMinSize
        '
        Me.labelMinSize.AutoSize = True
        Me.labelMinSize.Location = New System.Drawing.Point(57, 9)
        Me.labelMinSize.Name = "labelMinSize"
        Me.labelMinSize.Size = New System.Drawing.Size(50, 12)
        Me.labelMinSize.TabIndex = 29
        Me.labelMinSize.Text = "MinSize："
        '
        'numericDtMin
        '
        Me.numericDtMin.Location = New System.Drawing.Point(59, 101)
        Me.numericDtMin.Maximum = New Decimal(New Integer() {8192, 0, 0, 0})
        Me.numericDtMin.Minimum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.numericDtMin.Name = "numericDtMin"
        Me.numericDtMin.Size = New System.Drawing.Size(60, 19)
        Me.numericDtMin.TabIndex = 37
        Me.numericDtMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numericDtMin.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'labelThresh
        '
        Me.labelThresh.AutoSize = True
        Me.labelThresh.Location = New System.Drawing.Point(214, 9)
        Me.labelThresh.Name = "labelThresh"
        Me.labelThresh.Size = New System.Drawing.Size(46, 12)
        Me.labelThresh.TabIndex = 30
        Me.labelThresh.Text = "Thresh："
        '
        'numericDtMax
        '
        Me.numericDtMax.Location = New System.Drawing.Point(139, 101)
        Me.numericDtMax.Maximum = New Decimal(New Integer() {8192, 0, 0, 0})
        Me.numericDtMax.Minimum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.numericDtMax.Name = "numericDtMax"
        Me.numericDtMax.Size = New System.Drawing.Size(60, 19)
        Me.numericDtMax.TabIndex = 36
        Me.numericDtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numericDtMax.Value = New Decimal(New Integer() {1200, 0, 0, 0})
        '
        'numericBdThresh
        '
        Me.numericBdThresh.Location = New System.Drawing.Point(216, 26)
        Me.numericBdThresh.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numericBdThresh.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numericBdThresh.Name = "numericBdThresh"
        Me.numericBdThresh.Size = New System.Drawing.Size(60, 19)
        Me.numericBdThresh.TabIndex = 32
        Me.numericBdThresh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numericBdThresh.Value = New Decimal(New Integer() {500, 0, 0, 0})
        '
        'numericDtThresh
        '
        Me.numericDtThresh.Location = New System.Drawing.Point(216, 101)
        Me.numericDtThresh.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numericDtThresh.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numericDtThresh.Name = "numericDtThresh"
        Me.numericDtThresh.Size = New System.Drawing.Size(60, 19)
        Me.numericDtThresh.TabIndex = 38
        Me.numericDtThresh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numericDtThresh.Value = New Decimal(New Integer() {500, 0, 0, 0})
        '
        'numericBdMax
        '
        Me.numericBdMax.Location = New System.Drawing.Point(139, 26)
        Me.numericBdMax.Maximum = New Decimal(New Integer() {8192, 0, 0, 0})
        Me.numericBdMax.Minimum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.numericBdMax.Name = "numericBdMax"
        Me.numericBdMax.Size = New System.Drawing.Size(60, 19)
        Me.numericBdMax.TabIndex = 28
        Me.numericBdMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numericBdMax.Value = New Decimal(New Integer() {1200, 0, 0, 0})
        '
        'labelHand
        '
        Me.labelHand.AutoSize = True
        Me.labelHand.Location = New System.Drawing.Point(12, 53)
        Me.labelHand.Name = "labelHand"
        Me.labelHand.Size = New System.Drawing.Size(31, 12)
        Me.labelHand.TabIndex = 35
        Me.labelHand.Text = "Hand"
        '
        'labelMaxSize
        '
        Me.labelMaxSize.AutoSize = True
        Me.labelMaxSize.Location = New System.Drawing.Point(137, 9)
        Me.labelMaxSize.Name = "labelMaxSize"
        Me.labelMaxSize.Size = New System.Drawing.Size(53, 12)
        Me.labelMaxSize.TabIndex = 27
        Me.labelMaxSize.Text = "MaxSize："
        '
        'labelFace
        '
        Me.labelFace.AutoSize = True
        Me.labelFace.Location = New System.Drawing.Point(12, 103)
        Me.labelFace.Name = "labelFace"
        Me.labelFace.Size = New System.Drawing.Size(30, 12)
        Me.labelFace.TabIndex = 34
        Me.labelFace.Text = "Face"
        '
        'numericBdMin
        '
        Me.numericBdMin.Location = New System.Drawing.Point(59, 26)
        Me.numericBdMin.Maximum = New Decimal(New Integer() {8192, 0, 0, 0})
        Me.numericBdMin.Minimum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.numericBdMin.Name = "numericBdMin"
        Me.numericBdMin.Size = New System.Drawing.Size(60, 19)
        Me.numericBdMin.TabIndex = 31
        Me.numericBdMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numericBdMin.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'labelBody
        '
        Me.labelBody.AutoSize = True
        Me.labelBody.Location = New System.Drawing.Point(11, 28)
        Me.labelBody.Name = "labelBody"
        Me.labelBody.Size = New System.Drawing.Size(31, 12)
        Me.labelBody.TabIndex = 33
        Me.labelBody.Text = "Body"
        '
        'Param
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(294, 192)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.numericRecogThresh)
        Me.Controls.Add(Me.labelRecog)
        Me.Controls.Add(Me.numericPdMin)
        Me.Controls.Add(Me.numericPdMax)
        Me.Controls.Add(Me.numericPdThresh)
        Me.Controls.Add(Me.labelPet)
        Me.Controls.Add(Me.numericHdMin)
        Me.Controls.Add(Me.numericHdMax)
        Me.Controls.Add(Me.numericHdThresh)
        Me.Controls.Add(Me.labelMinSize)
        Me.Controls.Add(Me.numericDtMin)
        Me.Controls.Add(Me.labelThresh)
        Me.Controls.Add(Me.numericDtMax)
        Me.Controls.Add(Me.numericBdThresh)
        Me.Controls.Add(Me.numericDtThresh)
        Me.Controls.Add(Me.numericBdMax)
        Me.Controls.Add(Me.labelHand)
        Me.Controls.Add(Me.labelMaxSize)
        Me.Controls.Add(Me.labelFace)
        Me.Controls.Add(Me.numericBdMin)
        Me.Controls.Add(Me.labelBody)
        Me.Name = "Param"
        Me.Text = "Param"
        CType(Me.numericRecogThresh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericPdMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericPdMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericPdThresh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericHdMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericHdMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericHdThresh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericDtMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericDtMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericBdThresh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericDtThresh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericBdMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericBdMin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents button1 As System.Windows.Forms.Button
    Public WithEvents numericRecogThresh As System.Windows.Forms.NumericUpDown
    Private WithEvents labelRecog As System.Windows.Forms.Label
    Private WithEvents numericPdMin As System.Windows.Forms.NumericUpDown
    Private WithEvents numericPdMax As System.Windows.Forms.NumericUpDown
    Public WithEvents numericPdThresh As System.Windows.Forms.NumericUpDown
    Private WithEvents labelPet As System.Windows.Forms.Label
    Private WithEvents numericHdMin As System.Windows.Forms.NumericUpDown
    Private WithEvents numericHdMax As System.Windows.Forms.NumericUpDown
    Public WithEvents numericHdThresh As System.Windows.Forms.NumericUpDown
    Private WithEvents labelMinSize As System.Windows.Forms.Label
    Private WithEvents numericDtMin As System.Windows.Forms.NumericUpDown
    Private WithEvents labelThresh As System.Windows.Forms.Label
    Private WithEvents numericDtMax As System.Windows.Forms.NumericUpDown
    Public WithEvents numericBdThresh As System.Windows.Forms.NumericUpDown
    Public WithEvents numericDtThresh As System.Windows.Forms.NumericUpDown
    Private WithEvents numericBdMax As System.Windows.Forms.NumericUpDown
    Private WithEvents labelHand As System.Windows.Forms.Label
    Private WithEvents labelMaxSize As System.Windows.Forms.Label
    Private WithEvents labelFace As System.Windows.Forms.Label
    Private WithEvents numericBdMin As System.Windows.Forms.NumericUpDown
    Private WithEvents labelBody As System.Windows.Forms.Label
End Class
