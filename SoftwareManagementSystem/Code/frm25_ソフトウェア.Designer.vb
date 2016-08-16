<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm25_ソフトウェア
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
        Me.dgvソフトウェア一覧 = New System.Windows.Forms.DataGridView()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbt削除 = New System.Windows.Forms.RadioButton()
        Me.rbt更新 = New System.Windows.Forms.RadioButton()
        Me.rbt登録 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkDL済 = New System.Windows.Forms.CheckBox()
        Me.editソフトウェアID = New SPWinFormControls.SPEdit(Me.components)
        Me.Label9 = New System.Windows.Forms.Label()
        Me.editファイル名 = New SPWinFormControls.SPEdit(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbxメーカーID = New System.Windows.Forms.ComboBox()
        Me.edit更新日時 = New SPWinFormControls.SPEdit(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.edit作成日時 = New SPWinFormControls.SPEdit(Me.components)
        Me.editソフトウェア名称 = New SPWinFormControls.SPEdit(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn更新 = New System.Windows.Forms.Button()
        Me.btn終了 = New System.Windows.Forms.Button()
        CType(Me.dgvソフトウェア一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvソフトウェア一覧
        '
        Me.dgvソフトウェア一覧.AllowUserToAddRows = False
        Me.dgvソフトウェア一覧.AllowUserToDeleteRows = False
        Me.dgvソフトウェア一覧.AllowUserToResizeRows = False
        Me.dgvソフトウェア一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvソフトウェア一覧.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column3})
        Me.dgvソフトウェア一覧.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvソフトウェア一覧.Location = New System.Drawing.Point(3, 15)
        Me.dgvソフトウェア一覧.Name = "dgvソフトウェア一覧"
        Me.dgvソフトウェア一覧.ReadOnly = True
        Me.dgvソフトウェア一覧.RowTemplate.Height = 21
        Me.dgvソフトウェア一覧.Size = New System.Drawing.Size(424, 485)
        Me.dgvソフトウェア一覧.TabIndex = 0
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.DataPropertyName = "メーカー名称"
        Me.Column2.HeaderText = "メーカー"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 53
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column3.DataPropertyName = "ソフトウェア名称"
        Me.Column3.HeaderText = "ソフトウェア名称"
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
        Me.Label1.Text = "ソフトウェア登録"
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
        Me.GroupBox2.Controls.Add(Me.dgvソフトウェア一覧)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 47)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(430, 503)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "１．ソフトウェア一覧"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.chkDL済)
        Me.GroupBox3.Controls.Add(Me.editソフトウェアID)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.editファイル名)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.cbxメーカーID)
        Me.GroupBox3.Controls.Add(Me.edit更新日時)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.edit作成日時)
        Me.GroupBox3.Controls.Add(Me.editソフトウェア名称)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(448, 99)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(324, 415)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "３．詳細情報"
        '
        'chkDL済
        '
        Me.chkDL済.AutoSize = True
        Me.chkDL済.Location = New System.Drawing.Point(139, 89)
        Me.chkDL済.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.chkDL済.Name = "chkDL済"
        Me.chkDL済.Size = New System.Drawing.Size(50, 16)
        Me.chkDL済.TabIndex = 37
        Me.chkDL済.Text = "DL済"
        Me.chkDL済.UseVisualStyleBackColor = True
        '
        'editソフトウェアID
        '
        Me.editソフトウェアID.AllowSpace = SPWinFormControls.AllowSpaceMode.Both
        Me.editソフトウェアID.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.editソフトウェアID.Format = ""
        Me.editソフトウェアID.Location = New System.Drawing.Point(139, 25)
        Me.editソフトウェアID.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.editソフトウェアID.Name = "editソフトウェアID"
        Me.editソフトウェアID.ReadOnly = True
        Me.editソフトウェアID.Size = New System.Drawing.Size(120, 19)
        Me.editソフトウェアID.TabIndex = 36
        Me.editソフトウェアID.TabStop = False
        Me.editソフトウェアID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(18, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 12)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "ソフトウェアID"
        '
        'editファイル名
        '
        Me.editファイル名.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip
        Me.editファイル名.AllowSpace = SPWinFormControls.AllowSpaceMode.Both
        Me.editファイル名.BackColor = System.Drawing.SystemColors.Window
        Me.editファイル名.Format = ""
        Me.editファイル名.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.editファイル名.Location = New System.Drawing.Point(139, 107)
        Me.editファイル名.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.editファイル名.MaxLength = 100
        Me.editファイル名.Name = "editファイル名"
        Me.editファイル名.Size = New System.Drawing.Size(179, 19)
        Me.editファイル名.TabIndex = 34
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 12)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "ファイル名"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 142)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "メーカーID"
        '
        'cbxメーカーID
        '
        Me.cbxメーカーID.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbxメーカーID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxメーカーID.FormattingEnabled = True
        Me.cbxメーカーID.Location = New System.Drawing.Point(139, 139)
        Me.cbxメーカーID.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.cbxメーカーID.Name = "cbxメーカーID"
        Me.cbxメーカーID.Size = New System.Drawing.Size(150, 20)
        Me.cbxメーカーID.TabIndex = 13
        '
        'edit更新日時
        '
        Me.edit更新日時.AllowSpace = SPWinFormControls.AllowSpaceMode.Both
        Me.edit更新日時.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.edit更新日時.Format = ""
        Me.edit更新日時.Location = New System.Drawing.Point(139, 204)
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
        Me.Label5.Location = New System.Drawing.Point(18, 207)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "更新日時"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 175)
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
        Me.edit作成日時.Location = New System.Drawing.Point(139, 172)
        Me.edit作成日時.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.edit作成日時.Name = "edit作成日時"
        Me.edit作成日時.ReadOnly = True
        Me.edit作成日時.Size = New System.Drawing.Size(120, 19)
        Me.edit作成日時.TabIndex = 14
        Me.edit作成日時.TabStop = False
        Me.edit作成日時.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'editソフトウェア名称
        '
        Me.editソフトウェア名称.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip
        Me.editソフトウェア名称.AllowSpace = SPWinFormControls.AllowSpaceMode.Both
        Me.editソフトウェア名称.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.editソフトウェア名称.Format = ""
        Me.editソフトウェア名称.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.editソフトウェア名称.Location = New System.Drawing.Point(139, 57)
        Me.editソフトウェア名称.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.editソフトウェア名称.MaxLength = 50
        Me.editソフトウェア名称.Name = "editソフトウェア名称"
        Me.editソフトウェア名称.Size = New System.Drawing.Size(179, 19)
        Me.editソフトウェア名称.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 12)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "ソフトウェア名称"
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
        'frm25_ソフトウェア
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
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "frm25_ソフトウェア"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ソフトウェア登録"
        CType(Me.dgvソフトウェア一覧, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents editソフトウェア名称 As SPWinFormControls.SPEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents edit更新日時 As SPWinFormControls.SPEdit
    Friend WithEvents cbxメーカーID As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dgvソフトウェア一覧 As DataGridView
    Friend WithEvents editファイル名 As SPWinFormControls.SPEdit
    Friend WithEvents Label6 As Label
    Friend WithEvents editソフトウェアID As SPWinFormControls.SPEdit
    Friend WithEvents Label9 As Label
    Friend WithEvents dgvcメーカー名称 As DataGridViewTextBoxColumn
    Friend WithEvents dgvcソフト名称 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents chkDL済 As CheckBox
End Class
