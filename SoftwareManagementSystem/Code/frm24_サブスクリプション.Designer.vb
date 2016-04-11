<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm24_サブスクリプション
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
        Me.dgvサブスクリプション一覧 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbt削除 = New System.Windows.Forms.RadioButton()
        Me.rbt更新 = New System.Windows.Forms.RadioButton()
        Me.rbt登録 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbxサブスクリプション連番 = New System.Windows.Forms.TextBox()
        Me.chkサブスクリプション不要 = New System.Windows.Forms.CheckBox()
        Me.ndtp購入日 = New SoftwareManagementSystem.Windows.Controls.NullableDateTimePicker()
        Me.ndtp終了日 = New SoftwareManagementSystem.Windows.Controls.NullableDateTimePicker()
        Me.ndtp開始日 = New SoftwareManagementSystem.Windows.Controls.NullableDateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbxメーカーID = New System.Windows.Forms.ComboBox()
        Me.cbx権利者ID = New System.Windows.Forms.ComboBox()
        Me.edit更新日時 = New SPWinFormControls.SPEdit(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.edit作成日時 = New SPWinFormControls.SPEdit(Me.components)
        Me.editサブスクリプションID = New SPWinFormControls.SPEdit(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn更新 = New System.Windows.Forms.Button()
        Me.btn終了 = New System.Windows.Forms.Button()
        Me.tbxサブスクリプションオーバーレイ = New System.Windows.Forms.TextBox()
        CType(Me.dgvサブスクリプション一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvサブスクリプション一覧
        '
        Me.dgvサブスクリプション一覧.AllowUserToAddRows = False
        Me.dgvサブスクリプション一覧.AllowUserToDeleteRows = False
        Me.dgvサブスクリプション一覧.AllowUserToResizeColumns = False
        Me.dgvサブスクリプション一覧.AllowUserToResizeRows = False
        Me.dgvサブスクリプション一覧.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.dgvサブスクリプション一覧.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvサブスクリプション一覧.Location = New System.Drawing.Point(3, 15)
        Me.dgvサブスクリプション一覧.Name = "dgvサブスクリプション一覧"
        Me.dgvサブスクリプション一覧.ReadOnly = True
        Me.dgvサブスクリプション一覧.RowHeadersWidth = 25
        Me.dgvサブスクリプション一覧.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvサブスクリプション一覧.RowTemplate.Height = 21
        Me.dgvサブスクリプション一覧.Size = New System.Drawing.Size(424, 485)
        Me.dgvサブスクリプション一覧.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.DataPropertyName = "権利者"
        Me.Column1.HeaderText = "権利者"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 66
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.DataPropertyName = "メーカー"
        Me.Column2.HeaderText = "メーカー"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 67
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column3.DataPropertyName = "サブスクリプションID"
        Me.Column3.HeaderText = "サブスクリプションID"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
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
        Me.Label1.Text = "サブスクリプション登録"
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
        Me.GroupBox2.Controls.Add(Me.dgvサブスクリプション一覧)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 47)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(430, 503)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "１．サブスクリプション一覧"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.tbxサブスクリプションオーバーレイ)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.tbxサブスクリプション連番)
        Me.GroupBox3.Controls.Add(Me.chkサブスクリプション不要)
        Me.GroupBox3.Controls.Add(Me.ndtp購入日)
        Me.GroupBox3.Controls.Add(Me.ndtp終了日)
        Me.GroupBox3.Controls.Add(Me.ndtp開始日)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.cbxメーカーID)
        Me.GroupBox3.Controls.Add(Me.cbx権利者ID)
        Me.GroupBox3.Controls.Add(Me.edit更新日時)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.edit作成日時)
        Me.GroupBox3.Controls.Add(Me.editサブスクリプションID)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(448, 99)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(324, 415)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "３．詳細情報"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(18, 43)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(106, 12)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "サブスクリプション連番"
        '
        'tbxサブスクリプション連番
        '
        Me.tbxサブスクリプション連番.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tbxサブスクリプション連番.Location = New System.Drawing.Point(139, 40)
        Me.tbxサブスクリプション連番.Name = "tbxサブスクリプション連番"
        Me.tbxサブスクリプション連番.ReadOnly = True
        Me.tbxサブスクリプション連番.Size = New System.Drawing.Size(30, 19)
        Me.tbxサブスクリプション連番.TabIndex = 12
        Me.tbxサブスクリプション連番.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkサブスクリプション不要
        '
        Me.chkサブスクリプション不要.AutoSize = True
        Me.chkサブスクリプション不要.Location = New System.Drawing.Point(139, 72)
        Me.chkサブスクリプション不要.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.chkサブスクリプション不要.Name = "chkサブスクリプション不要"
        Me.chkサブスクリプション不要.Size = New System.Drawing.Size(125, 16)
        Me.chkサブスクリプション不要.TabIndex = 1
        Me.chkサブスクリプション不要.Text = "サブスクリプション不要"
        Me.chkサブスクリプション不要.UseVisualStyleBackColor = True
        '
        'ndtp購入日
        '
        Me.ndtp購入日.Location = New System.Drawing.Point(139, 254)
        Me.ndtp購入日.Name = "ndtp購入日"
        Me.ndtp購入日.NullValue = " <日付を選択>"
        Me.ndtp購入日.Size = New System.Drawing.Size(150, 19)
        Me.ndtp購入日.TabIndex = 16
        Me.ndtp購入日.Value = New Date(CType(0, Long))
        '
        'ndtp終了日
        '
        Me.ndtp終了日.Location = New System.Drawing.Point(139, 222)
        Me.ndtp終了日.Name = "ndtp終了日"
        Me.ndtp終了日.NullValue = " <日付を選択>"
        Me.ndtp終了日.Size = New System.Drawing.Size(150, 19)
        Me.ndtp終了日.TabIndex = 15
        Me.ndtp終了日.Value = New Date(CType(0, Long))
        '
        'ndtp開始日
        '
        Me.ndtp開始日.Location = New System.Drawing.Point(139, 190)
        Me.ndtp開始日.Name = "ndtp開始日"
        Me.ndtp開始日.NullValue = " <日付を選択>"
        Me.ndtp開始日.Size = New System.Drawing.Size(150, 19)
        Me.ndtp開始日.TabIndex = 14
        Me.ndtp開始日.Value = New Date(CType(0, Long))
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(18, 259)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 12)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "購入日付"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(18, 227)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 12)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "有効期間終了日"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 195)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 12)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "有効期間開始日"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 160)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "メーカーID"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 127)
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
        Me.cbxメーカーID.Location = New System.Drawing.Point(139, 157)
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
        Me.cbx権利者ID.Location = New System.Drawing.Point(139, 124)
        Me.cbx権利者ID.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.cbx権利者ID.Name = "cbx権利者ID"
        Me.cbx権利者ID.Size = New System.Drawing.Size(150, 20)
        Me.cbx権利者ID.TabIndex = 12
        '
        'edit更新日時
        '
        Me.edit更新日時.AllowSpace = SPWinFormControls.AllowSpaceMode.Both
        Me.edit更新日時.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.edit更新日時.Format = ""
        Me.edit更新日時.Location = New System.Drawing.Point(139, 318)
        Me.edit更新日時.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.edit更新日時.Name = "edit更新日時"
        Me.edit更新日時.ReadOnly = True
        Me.edit更新日時.Size = New System.Drawing.Size(120, 19)
        Me.edit更新日時.TabIndex = 18
        Me.edit更新日時.TabStop = False
        Me.edit更新日時.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 321)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "更新日時"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 289)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "作成日時"
        '
        'edit作成日時
        '
        Me.edit作成日時.AllowSpace = SPWinFormControls.AllowSpaceMode.Both
        Me.edit作成日時.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.edit作成日時.Format = ""
        Me.edit作成日時.Location = New System.Drawing.Point(139, 286)
        Me.edit作成日時.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.edit作成日時.Name = "edit作成日時"
        Me.edit作成日時.ReadOnly = True
        Me.edit作成日時.Size = New System.Drawing.Size(120, 19)
        Me.edit作成日時.TabIndex = 14
        Me.edit作成日時.TabStop = False
        Me.edit作成日時.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'editサブスクリプションID
        '
        Me.editサブスクリプションID.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip
        Me.editサブスクリプションID.AllowSpace = SPWinFormControls.AllowSpaceMode.Both
        Me.editサブスクリプションID.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.editサブスクリプションID.Format = ""
        Me.editサブスクリプションID.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.editサブスクリプションID.Location = New System.Drawing.Point(139, 92)
        Me.editサブスクリプションID.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.editサブスクリプションID.MaxLength = 50
        Me.editサブスクリプションID.Name = "editサブスクリプションID"
        Me.editサブスクリプションID.Size = New System.Drawing.Size(150, 19)
        Me.editサブスクリプションID.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 12)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "サブスクリプションID"
        '
        'btn更新
        '
        Me.btn更新.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn更新.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn更新.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn更新.Location = New System.Drawing.Point(448, 520)
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
        Me.btn終了.Location = New System.Drawing.Point(692, 520)
        Me.btn終了.Name = "btn終了"
        Me.btn終了.Size = New System.Drawing.Size(80, 30)
        Me.btn終了.TabIndex = 11
        Me.btn終了.Text = "終 了"
        Me.btn終了.UseVisualStyleBackColor = True
        '
        'tbxサブスクリプション不要
        '
        Me.tbxサブスクリプションオーバーレイ.Enabled = False
        Me.tbxサブスクリプションオーバーレイ.Location = New System.Drawing.Point(139, 92)
        Me.tbxサブスクリプションオーバーレイ.Name = "tbxサブスクリプション不要"
        Me.tbxサブスクリプションオーバーレイ.Size = New System.Drawing.Size(150, 19)
        Me.tbxサブスクリプションオーバーレイ.TabIndex = 34
        Me.tbxサブスクリプションオーバーレイ.Visible = False
        '
        'frm24_サブスクリプション
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.btn終了)
        Me.Controls.Add(Me.btn更新)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.MinimumSize = New System.Drawing.Size(800, 500)
        Me.Name = "frm24_サブスクリプション"
        Me.Text = "サブスクリプション登録"
        CType(Me.dgvサブスクリプション一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btn更新 As Button
    Friend WithEvents btn終了 As Button
    Friend WithEvents rbt削除 As RadioButton
    Friend WithEvents rbt更新 As RadioButton
    Friend WithEvents rbt登録 As RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents edit作成日時 As SPWinFormControls.SPEdit
    Friend WithEvents editサブスクリプションID As SPWinFormControls.SPEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents edit更新日時 As SPWinFormControls.SPEdit
    Friend WithEvents cbxメーカーID As ComboBox
    Friend WithEvents cbx権利者ID As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents ndtp開始日 As Windows.Controls.NullableDateTimePicker
    Friend WithEvents ndtp終了日 As Windows.Controls.NullableDateTimePicker
    Friend WithEvents ndtp購入日 As Windows.Controls.NullableDateTimePicker
    Friend WithEvents chkサブスクリプション不要 As CheckBox
    Friend WithEvents dgvサブスクリプション一覧 As DataGridView
    Friend WithEvents tbxサブスクリプション連番 As TextBox
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Label10 As Label
    Friend WithEvents tbxサブスクリプションオーバーレイ As TextBox
End Class
