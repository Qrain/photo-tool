<CompilerServices.DesignerGenerated()>
Partial Class frm26_プロダクトキー登録
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
        Me.components = New System.ComponentModel.Container()
        Me.dgvプロダクトキー一覧 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbt削除 = New System.Windows.Forms.RadioButton()
        Me.rbt更新 = New System.Windows.Forms.RadioButton()
        Me.rbt登録 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chklsbソフト情報 = New System.Windows.Forms.CheckedListBox()
        Me.group1 = New System.Windows.Forms.GroupBox()
        Me.lblソフト件数 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnAll = New System.Windows.Forms.Button()
        Me.btnA = New System.Windows.Forms.Button()
        Me.btnB = New System.Windows.Forms.Button()
        Me.btnC = New System.Windows.Forms.Button()
        Me.btnD = New System.Windows.Forms.Button()
        Me.btnE = New System.Windows.Forms.Button()
        Me.btnF = New System.Windows.Forms.Button()
        Me.btnG = New System.Windows.Forms.Button()
        Me.btnH = New System.Windows.Forms.Button()
        Me.btnI = New System.Windows.Forms.Button()
        Me.btnJ = New System.Windows.Forms.Button()
        Me.btnK = New System.Windows.Forms.Button()
        Me.btnL = New System.Windows.Forms.Button()
        Me.btnM = New System.Windows.Forms.Button()
        Me.btnN = New System.Windows.Forms.Button()
        Me.btnO = New System.Windows.Forms.Button()
        Me.btnP = New System.Windows.Forms.Button()
        Me.btnQ = New System.Windows.Forms.Button()
        Me.btnR = New System.Windows.Forms.Button()
        Me.btnS = New System.Windows.Forms.Button()
        Me.btnT = New System.Windows.Forms.Button()
        Me.btnU = New System.Windows.Forms.Button()
        Me.btnV = New System.Windows.Forms.Button()
        Me.btnW = New System.Windows.Forms.Button()
        Me.btnX = New System.Windows.Forms.Button()
        Me.btnY = New System.Windows.Forms.Button()
        Me.btnZ = New System.Windows.Forms.Button()
        Me.btnElse = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbx利用者ID = New System.Windows.Forms.ComboBox()
        Me.cbx認証タイプ = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbxサブスクリプションID = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbxメーカーID = New System.Windows.Forms.ComboBox()
        Me.cbx権利者ID = New System.Windows.Forms.ComboBox()
        Me.editプロダクトキー = New SPWinFormControls.SPEdit(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn更新 = New System.Windows.Forms.Button()
        Me.btn終了 = New System.Windows.Forms.Button()
        Me.tbx隠_サブスクリプション連番 = New System.Windows.Forms.TextBox()
        Me.ndtp要求日 = New SoftwareManagementSystem.Windows.Controls.NullableDateTimePicker()
        Me.dgvc権利者 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvcメーカー名称 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvcサブスクリプションID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvプロダクトキー一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.group1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvプロダクトキー一覧
        '
        Me.dgvプロダクトキー一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvプロダクトキー一覧.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvc権利者, Me.dgvcメーカー名称, Me.dgvcサブスクリプションID, Me.Column4})
        Me.dgvプロダクトキー一覧.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvプロダクトキー一覧.Location = New System.Drawing.Point(3, 15)
        Me.dgvプロダクトキー一覧.Name = "dgvプロダクトキー一覧"
        Me.dgvプロダクトキー一覧.RowTemplate.Height = 21
        Me.dgvプロダクトキー一覧.Size = New System.Drawing.Size(424, 535)
        Me.dgvプロダクトキー一覧.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(760, 35)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "プロダクトキー登録"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.rbt削除)
        Me.GroupBox1.Controls.Add(Me.rbt更新)
        Me.GroupBox1.Controls.Add(Me.rbt登録)
        Me.GroupBox1.Location = New System.Drawing.Point(448, 47)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(324, 46)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "２．操作モード"
        '
        'rbt削除
        '
        Me.rbt削除.AutoSize = True
        Me.rbt削除.Location = New System.Drawing.Point(244, 20)
        Me.rbt削除.Name = "rbt削除"
        Me.rbt削除.Size = New System.Drawing.Size(47, 16)
        Me.rbt削除.TabIndex = 2
        Me.rbt削除.Text = "削除"
        Me.rbt削除.UseVisualStyleBackColor = True
        '
        'rbt更新
        '
        Me.rbt更新.AutoSize = True
        Me.rbt更新.Location = New System.Drawing.Point(139, 20)
        Me.rbt更新.Name = "rbt更新"
        Me.rbt更新.Size = New System.Drawing.Size(47, 16)
        Me.rbt更新.TabIndex = 1
        Me.rbt更新.Text = "更新"
        Me.rbt更新.UseVisualStyleBackColor = True
        '
        'rbt登録
        '
        Me.rbt登録.AutoSize = True
        Me.rbt登録.Checked = True
        Me.rbt登録.Location = New System.Drawing.Point(33, 20)
        Me.rbt登録.Name = "rbt登録"
        Me.rbt登録.Size = New System.Drawing.Size(47, 16)
        Me.rbt登録.TabIndex = 0
        Me.rbt登録.TabStop = True
        Me.rbt登録.Text = "登録"
        Me.rbt登録.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.dgvプロダクトキー一覧)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 47)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(430, 553)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "１．プロダクトキー一覧"
        '
        'chklsbソフト情報
        '
        Me.chklsbソフト情報.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chklsbソフト情報.FormattingEnabled = True
        Me.chklsbソフト情報.Location = New System.Drawing.Point(20, 327)
        Me.chklsbソフト情報.Margin = New System.Windows.Forms.Padding(5)
        Me.chklsbソフト情報.Name = "chklsbソフト情報"
        Me.chklsbソフト情報.Size = New System.Drawing.Size(296, 130)
        Me.chklsbソフト情報.TabIndex = 1
        '
        'group1
        '
        Me.group1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.group1.Controls.Add(Me.lblソフト件数)
        Me.group1.Controls.Add(Me.FlowLayoutPanel1)
        Me.group1.Controls.Add(Me.Label4)
        Me.group1.Controls.Add(Me.chklsbソフト情報)
        Me.group1.Controls.Add(Me.Label10)
        Me.group1.Controls.Add(Me.cbx利用者ID)
        Me.group1.Controls.Add(Me.cbx認証タイプ)
        Me.group1.Controls.Add(Me.Label8)
        Me.group1.Controls.Add(Me.cbxサブスクリプションID)
        Me.group1.Controls.Add(Me.ndtp要求日)
        Me.group1.Controls.Add(Me.Label9)
        Me.group1.Controls.Add(Me.Label2)
        Me.group1.Controls.Add(Me.Label7)
        Me.group1.Controls.Add(Me.Label6)
        Me.group1.Controls.Add(Me.cbxメーカーID)
        Me.group1.Controls.Add(Me.cbx権利者ID)
        Me.group1.Controls.Add(Me.editプロダクトキー)
        Me.group1.Controls.Add(Me.Label3)
        Me.group1.Location = New System.Drawing.Point(448, 99)
        Me.group1.Name = "group1"
        Me.group1.Size = New System.Drawing.Size(324, 465)
        Me.group1.TabIndex = 8
        Me.group1.TabStop = False
        Me.group1.Text = "３．詳細情報"
        '
        'lblソフト件数
        '
        Me.lblソフト件数.AutoSize = True
        Me.lblソフト件数.Location = New System.Drawing.Point(103, 310)
        Me.lblソフト件数.Name = "lblソフト件数"
        Me.lblソフト件数.Size = New System.Drawing.Size(35, 12)
        Me.lblソフト件数.TabIndex = 54
        Me.lblソフト件数.Text = "xxx件"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btnAll)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnA)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnB)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnC)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnD)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnE)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnF)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnG)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnH)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnI)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnJ)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnK)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnL)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnM)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnN)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnO)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnP)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnQ)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnR)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnS)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnT)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnU)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnV)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnW)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnX)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnY)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnZ)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnElse)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(20, 256)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(304, 51)
        Me.FlowLayoutPanel1.TabIndex = 53
        '
        'btnAll
        '
        Me.btnAll.BackColor = System.Drawing.SystemColors.Control
        Me.btnAll.Location = New System.Drawing.Point(0, 3)
        Me.btnAll.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.btnAll.Name = "btnAll"
        Me.btnAll.Size = New System.Drawing.Size(40, 20)
        Me.btnAll.TabIndex = 53
        Me.btnAll.Text = "全て"
        Me.btnAll.UseVisualStyleBackColor = False
        '
        'btnA
        '
        Me.btnA.Location = New System.Drawing.Point(40, 3)
        Me.btnA.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.btnA.Name = "btnA"
        Me.btnA.Size = New System.Drawing.Size(20, 20)
        Me.btnA.TabIndex = 40
        Me.btnA.Text = "A"
        Me.btnA.UseVisualStyleBackColor = True
        '
        'btnB
        '
        Me.btnB.Location = New System.Drawing.Point(60, 3)
        Me.btnB.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.btnB.Name = "btnB"
        Me.btnB.Size = New System.Drawing.Size(20, 20)
        Me.btnB.TabIndex = 41
        Me.btnB.Text = "B"
        Me.btnB.UseVisualStyleBackColor = True
        '
        'btnC
        '
        Me.btnC.Location = New System.Drawing.Point(80, 3)
        Me.btnC.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.btnC.Name = "btnC"
        Me.btnC.Size = New System.Drawing.Size(20, 20)
        Me.btnC.TabIndex = 42
        Me.btnC.Text = "C"
        Me.btnC.UseVisualStyleBackColor = True
        '
        'btnD
        '
        Me.btnD.Location = New System.Drawing.Point(100, 3)
        Me.btnD.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.btnD.Name = "btnD"
        Me.btnD.Size = New System.Drawing.Size(20, 20)
        Me.btnD.TabIndex = 44
        Me.btnD.Text = "D"
        Me.btnD.UseVisualStyleBackColor = True
        '
        'btnE
        '
        Me.btnE.Location = New System.Drawing.Point(120, 3)
        Me.btnE.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.btnE.Name = "btnE"
        Me.btnE.Size = New System.Drawing.Size(20, 20)
        Me.btnE.TabIndex = 45
        Me.btnE.Text = "E"
        Me.btnE.UseVisualStyleBackColor = True
        '
        'btnF
        '
        Me.btnF.Location = New System.Drawing.Point(140, 3)
        Me.btnF.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.btnF.Name = "btnF"
        Me.btnF.Size = New System.Drawing.Size(20, 20)
        Me.btnF.TabIndex = 46
        Me.btnF.Text = "F"
        Me.btnF.UseVisualStyleBackColor = True
        '
        'btnG
        '
        Me.btnG.Location = New System.Drawing.Point(160, 3)
        Me.btnG.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.btnG.Name = "btnG"
        Me.btnG.Size = New System.Drawing.Size(20, 20)
        Me.btnG.TabIndex = 47
        Me.btnG.Text = "G"
        Me.btnG.UseVisualStyleBackColor = True
        '
        'btnH
        '
        Me.btnH.Location = New System.Drawing.Point(180, 3)
        Me.btnH.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.btnH.Name = "btnH"
        Me.btnH.Size = New System.Drawing.Size(20, 20)
        Me.btnH.TabIndex = 48
        Me.btnH.Text = "H"
        Me.btnH.UseVisualStyleBackColor = True
        '
        'btnI
        '
        Me.btnI.Location = New System.Drawing.Point(200, 3)
        Me.btnI.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.btnI.Name = "btnI"
        Me.btnI.Size = New System.Drawing.Size(20, 20)
        Me.btnI.TabIndex = 49
        Me.btnI.Text = "I"
        Me.btnI.UseVisualStyleBackColor = True
        '
        'btnJ
        '
        Me.btnJ.Location = New System.Drawing.Point(220, 3)
        Me.btnJ.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.btnJ.Name = "btnJ"
        Me.btnJ.Size = New System.Drawing.Size(20, 20)
        Me.btnJ.TabIndex = 50
        Me.btnJ.Text = "J"
        Me.btnJ.UseVisualStyleBackColor = True
        '
        'btnK
        '
        Me.btnK.Location = New System.Drawing.Point(240, 3)
        Me.btnK.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.btnK.Name = "btnK"
        Me.btnK.Size = New System.Drawing.Size(20, 20)
        Me.btnK.TabIndex = 51
        Me.btnK.Text = "K"
        Me.btnK.UseVisualStyleBackColor = True
        '
        'btnL
        '
        Me.btnL.Location = New System.Drawing.Point(260, 3)
        Me.btnL.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.btnL.Name = "btnL"
        Me.btnL.Size = New System.Drawing.Size(20, 20)
        Me.btnL.TabIndex = 52
        Me.btnL.Text = "L"
        Me.btnL.UseVisualStyleBackColor = True
        '
        'btnM
        '
        Me.btnM.Location = New System.Drawing.Point(280, 3)
        Me.btnM.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.btnM.Name = "btnM"
        Me.btnM.Size = New System.Drawing.Size(20, 20)
        Me.btnM.TabIndex = 54
        Me.btnM.Text = "M"
        Me.btnM.UseVisualStyleBackColor = True
        '
        'btnN
        '
        Me.btnN.Location = New System.Drawing.Point(0, 29)
        Me.btnN.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.btnN.Name = "btnN"
        Me.btnN.Size = New System.Drawing.Size(20, 20)
        Me.btnN.TabIndex = 55
        Me.btnN.Text = "N"
        Me.btnN.UseVisualStyleBackColor = True
        '
        'btnO
        '
        Me.btnO.Location = New System.Drawing.Point(20, 29)
        Me.btnO.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.btnO.Name = "btnO"
        Me.btnO.Size = New System.Drawing.Size(20, 20)
        Me.btnO.TabIndex = 56
        Me.btnO.Text = "O"
        Me.btnO.UseVisualStyleBackColor = True
        '
        'btnP
        '
        Me.btnP.Location = New System.Drawing.Point(40, 29)
        Me.btnP.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.btnP.Name = "btnP"
        Me.btnP.Size = New System.Drawing.Size(20, 20)
        Me.btnP.TabIndex = 57
        Me.btnP.Text = "P"
        Me.btnP.UseVisualStyleBackColor = True
        '
        'btnQ
        '
        Me.btnQ.Location = New System.Drawing.Point(60, 29)
        Me.btnQ.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.btnQ.Name = "btnQ"
        Me.btnQ.Size = New System.Drawing.Size(20, 20)
        Me.btnQ.TabIndex = 58
        Me.btnQ.Text = "Q"
        Me.btnQ.UseVisualStyleBackColor = True
        '
        'btnR
        '
        Me.btnR.Location = New System.Drawing.Point(80, 29)
        Me.btnR.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.btnR.Name = "btnR"
        Me.btnR.Size = New System.Drawing.Size(20, 20)
        Me.btnR.TabIndex = 59
        Me.btnR.Text = "R"
        Me.btnR.UseVisualStyleBackColor = True
        '
        'btnS
        '
        Me.btnS.Location = New System.Drawing.Point(100, 29)
        Me.btnS.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.btnS.Name = "btnS"
        Me.btnS.Size = New System.Drawing.Size(20, 20)
        Me.btnS.TabIndex = 60
        Me.btnS.Text = "S"
        Me.btnS.UseVisualStyleBackColor = True
        '
        'btnT
        '
        Me.btnT.Location = New System.Drawing.Point(120, 29)
        Me.btnT.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.btnT.Name = "btnT"
        Me.btnT.Size = New System.Drawing.Size(20, 20)
        Me.btnT.TabIndex = 61
        Me.btnT.Text = "T"
        Me.btnT.UseVisualStyleBackColor = True
        '
        'btnU
        '
        Me.btnU.Location = New System.Drawing.Point(140, 29)
        Me.btnU.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.btnU.Name = "btnU"
        Me.btnU.Size = New System.Drawing.Size(20, 20)
        Me.btnU.TabIndex = 62
        Me.btnU.Text = "U"
        Me.btnU.UseVisualStyleBackColor = True
        '
        'btnV
        '
        Me.btnV.Location = New System.Drawing.Point(160, 29)
        Me.btnV.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.btnV.Name = "btnV"
        Me.btnV.Size = New System.Drawing.Size(20, 20)
        Me.btnV.TabIndex = 63
        Me.btnV.Text = "V"
        Me.btnV.UseVisualStyleBackColor = True
        '
        'btnW
        '
        Me.btnW.Location = New System.Drawing.Point(180, 29)
        Me.btnW.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.btnW.Name = "btnW"
        Me.btnW.Size = New System.Drawing.Size(20, 20)
        Me.btnW.TabIndex = 64
        Me.btnW.Text = "W"
        Me.btnW.UseVisualStyleBackColor = True
        '
        'btnX
        '
        Me.btnX.Location = New System.Drawing.Point(200, 29)
        Me.btnX.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.btnX.Name = "btnX"
        Me.btnX.Size = New System.Drawing.Size(20, 20)
        Me.btnX.TabIndex = 65
        Me.btnX.Text = "X"
        Me.btnX.UseVisualStyleBackColor = True
        '
        'btnY
        '
        Me.btnY.Location = New System.Drawing.Point(220, 29)
        Me.btnY.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.btnY.Name = "btnY"
        Me.btnY.Size = New System.Drawing.Size(20, 20)
        Me.btnY.TabIndex = 66
        Me.btnY.Text = "Y"
        Me.btnY.UseVisualStyleBackColor = True
        '
        'btnZ
        '
        Me.btnZ.Location = New System.Drawing.Point(240, 29)
        Me.btnZ.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.btnZ.Name = "btnZ"
        Me.btnZ.Size = New System.Drawing.Size(20, 20)
        Me.btnZ.TabIndex = 67
        Me.btnZ.Text = "Z"
        Me.btnZ.UseVisualStyleBackColor = True
        '
        'btnElse
        '
        Me.btnElse.BackColor = System.Drawing.SystemColors.Control
        Me.btnElse.Location = New System.Drawing.Point(260, 29)
        Me.btnElse.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.btnElse.Name = "btnElse"
        Me.btnElse.Size = New System.Drawing.Size(20, 20)
        Me.btnElse.TabIndex = 43
        Me.btnElse.Text = "他"
        Me.btnElse.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 310)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 12)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "ソフトウェア一覧:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(18, 192)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 12)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "利用者ID"
        '
        'cbx利用者ID
        '
        Me.cbx利用者ID.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbx利用者ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx利用者ID.FormattingEnabled = True
        Me.cbx利用者ID.Location = New System.Drawing.Point(139, 189)
        Me.cbx利用者ID.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.cbx利用者ID.Name = "cbx利用者ID"
        Me.cbx利用者ID.Size = New System.Drawing.Size(150, 20)
        Me.cbx利用者ID.TabIndex = 37
        '
        'cbx認証タイプ
        '
        Me.cbx認証タイプ.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbx認証タイプ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx認証タイプ.FormattingEnabled = True
        Me.cbx認証タイプ.Location = New System.Drawing.Point(139, 156)
        Me.cbx認証タイプ.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.cbx認証タイプ.Name = "cbx認証タイプ"
        Me.cbx認証タイプ.Size = New System.Drawing.Size(150, 20)
        Me.cbx認証タイプ.TabIndex = 35
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(18, 159)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 12)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "認証タイプ"
        '
        'cbxサブスクリプションID
        '
        Me.cbxサブスクリプションID.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbxサブスクリプションID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxサブスクリプションID.FormattingEnabled = True
        Me.cbxサブスクリプションID.Location = New System.Drawing.Point(139, 123)
        Me.cbxサブスクリプションID.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.cbxサブスクリプションID.Name = "cbxサブスクリプションID"
        Me.cbxサブスクリプションID.Size = New System.Drawing.Size(150, 20)
        Me.cbxサブスクリプションID.TabIndex = 33
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(18, 227)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 12)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "要求日付"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 12)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "サブスクリプションID"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 93)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "メーカーID"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 12)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "権利者ID"
        '
        'cbxメーカーID
        '
        Me.cbxメーカーID.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbxメーカーID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxメーカーID.FormattingEnabled = True
        Me.cbxメーカーID.Location = New System.Drawing.Point(139, 90)
        Me.cbxメーカーID.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.cbxメーカーID.Name = "cbxメーカーID"
        Me.cbxメーカーID.Size = New System.Drawing.Size(150, 20)
        Me.cbxメーカーID.TabIndex = 13
        '
        'cbx権利者ID
        '
        Me.cbx権利者ID.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbx権利者ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx権利者ID.FormattingEnabled = True
        Me.cbx権利者ID.Location = New System.Drawing.Point(139, 57)
        Me.cbx権利者ID.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.cbx権利者ID.Name = "cbx権利者ID"
        Me.cbx権利者ID.Size = New System.Drawing.Size(150, 20)
        Me.cbx権利者ID.TabIndex = 12
        '
        'editプロダクトキー
        '
        Me.editプロダクトキー.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip
        Me.editプロダクトキー.AllowSpace = SPWinFormControls.AllowSpaceMode.Both
        Me.editプロダクトキー.BackColor = System.Drawing.SystemColors.HighlightText
        Me.editプロダクトキー.Format = ""
        Me.editプロダクトキー.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.editプロダクトキー.Location = New System.Drawing.Point(139, 25)
        Me.editプロダクトキー.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.editプロダクトキー.MaxLength = 50
        Me.editプロダクトキー.Name = "editプロダクトキー"
        Me.editプロダクトキー.Size = New System.Drawing.Size(150, 19)
        Me.editプロダクトキー.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 12)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "プロダクトキー"
        '
        'btn更新
        '
        Me.btn更新.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn更新.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn更新.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn更新.Location = New System.Drawing.Point(448, 570)
        Me.btn更新.Name = "btn更新"
        Me.btn更新.Size = New System.Drawing.Size(80, 30)
        Me.btn更新.TabIndex = 10
        Me.btn更新.Text = "更 新"
        Me.btn更新.UseVisualStyleBackColor = True
        '
        'btn終了
        '
        Me.btn終了.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn終了.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn終了.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn終了.Location = New System.Drawing.Point(692, 570)
        Me.btn終了.Name = "btn終了"
        Me.btn終了.Size = New System.Drawing.Size(80, 30)
        Me.btn終了.TabIndex = 11
        Me.btn終了.Text = "終 了"
        Me.btn終了.UseVisualStyleBackColor = True
        '
        'tbx隠_サブスクリプション連番
        '
        Me.tbx隠_サブスクリプション連番.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tbx隠_サブスクリプション連番.Location = New System.Drawing.Point(742, 9)
        Me.tbx隠_サブスクリプション連番.Name = "tbx隠_サブスクリプション連番"
        Me.tbx隠_サブスクリプション連番.Size = New System.Drawing.Size(30, 19)
        Me.tbx隠_サブスクリプション連番.TabIndex = 12
        Me.tbx隠_サブスクリプション連番.Visible = False
        '
        'ndtp要求日
        '
        Me.ndtp要求日.Location = New System.Drawing.Point(139, 222)
        Me.ndtp要求日.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.ndtp要求日.Name = "ndtp要求日"
        Me.ndtp要求日.NullValue = " <日付を選択>"
        Me.ndtp要求日.Size = New System.Drawing.Size(150, 19)
        Me.ndtp要求日.TabIndex = 16
        Me.ndtp要求日.Value = New Date(CType(0, Long))
        '
        '権利者
        '
        Me.dgvc権利者.DataPropertyName = "権利者"
        Me.dgvc権利者.HeaderText = "権利者"
        Me.dgvc権利者.Name = "権利者"
        Me.dgvc権利者.ReadOnly = True
        Me.dgvc権利者.Width = 61
        '
        'メーカー名称
        '
        Me.dgvcメーカー名称.DataPropertyName = "メーカー名称"
        Me.dgvcメーカー名称.HeaderText = "メーカー"
        Me.dgvcメーカー名称.Name = "メーカー名称"
        Me.dgvcメーカー名称.ReadOnly = True
        Me.dgvcメーカー名称.Width = 53
        '
        'Column3
        '
        Me.dgvcサブスクリプションID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgvcサブスクリプションID.DataPropertyName = "サブスクリプションID"
        Me.dgvcサブスクリプションID.HeaderText = "サブスクリプションID"
        Me.dgvcサブスクリプションID.Name = "Column3"
        Me.dgvcサブスクリプションID.ReadOnly = True
        Me.dgvcサブスクリプションID.Width = 76
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column4.DataPropertyName = "プロダクトキー"
        Me.Column4.HeaderText = "プロダクトキー"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'frm26_プロダクトキー登録
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 612)
        Me.Controls.Add(Me.tbx隠_サブスクリプション連番)
        Me.Controls.Add(Me.btn終了)
        Me.Controls.Add(Me.btn更新)
        Me.Controls.Add(Me.group1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.MinimumSize = New System.Drawing.Size(800, 650)
        Me.Name = "frm26_プロダクトキー登録"
        Me.Text = "プロダクトキー登録"
        CType(Me.dgvプロダクトキー一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.group1.ResumeLayout(False)
        Me.group1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents group1 As GroupBox
    Friend WithEvents btn更新 As Button
    Friend WithEvents btn終了 As Button
    Friend WithEvents rbt削除 As RadioButton
    Friend WithEvents rbt更新 As RadioButton
    Friend WithEvents rbt登録 As RadioButton
    Friend WithEvents editプロダクトキー As SPWinFormControls.SPEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents cbxメーカーID As ComboBox
    Friend WithEvents cbx権利者ID As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents ndtp要求日 As Windows.Controls.NullableDateTimePicker
    Friend WithEvents dgvプロダクトキー一覧 As DataGridView
    Friend WithEvents tbx隠_サブスクリプション連番 As TextBox
    Friend WithEvents cbxサブスクリプションID As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cbx認証タイプ As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cbx利用者ID As ComboBox
    Friend WithEvents chklsbソフト情報 As CheckedListBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnElse As Button
    Friend WithEvents btnC As Button
    Friend WithEvents btnB As Button
    Friend WithEvents btnA As Button
    Friend WithEvents btnF As Button
    Friend WithEvents btnE As Button
    Friend WithEvents btnD As Button
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents btnG As Button
    Friend WithEvents btnL As Button
    Friend WithEvents btnK As Button
    Friend WithEvents btnJ As Button
    Friend WithEvents btnI As Button
    Friend WithEvents btnH As Button
    Friend WithEvents btnAll As Button
    Friend WithEvents btnM As Button
    Friend WithEvents btnN As Button
    Friend WithEvents btnO As Button
    Friend WithEvents btnP As Button
    Friend WithEvents btnQ As Button
    Friend WithEvents btnR As Button
    Friend WithEvents btnS As Button
    Friend WithEvents btnT As Button
    Friend WithEvents btnU As Button
    Friend WithEvents btnV As Button
    Friend WithEvents btnW As Button
    Friend WithEvents btnX As Button
    Friend WithEvents btnY As Button
    Friend WithEvents btnZ As Button
    Friend WithEvents lblソフト件数 As Label
    Friend WithEvents dgvc権利者 As DataGridViewTextBoxColumn
    Friend WithEvents dgvcメーカー名称 As DataGridViewTextBoxColumn
    Friend WithEvents dgvcサブスクリプションID As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
End Class
