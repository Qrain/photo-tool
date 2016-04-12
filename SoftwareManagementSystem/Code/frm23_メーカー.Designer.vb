<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm23_メーカー
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
        Me.dgvメーカー一覧 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbt削除 = New System.Windows.Forms.RadioButton()
        Me.rbt更新 = New System.Windows.Forms.RadioButton()
        Me.rbt登録 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chk削除済表示 = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chk削除済 = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.editメーカーID = New SPWinFormControls.SPEdit(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.editメーカー名称 = New SPWinFormControls.SPEdit(Me.components)
        Me.Label10 = New System.Windows.Forms.Label()
        Me.edit更新日時 = New SPWinFormControls.SPEdit(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.edit作成日時 = New SPWinFormControls.SPEdit(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn更新 = New System.Windows.Forms.Button()
        Me.btn終了 = New System.Windows.Forms.Button()
        CType(Me.dgvメーカー一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvメーカー一覧
        '
        Me.dgvメーカー一覧.AllowUserToAddRows = False
        Me.dgvメーカー一覧.AllowUserToDeleteRows = False
        Me.dgvメーカー一覧.AllowUserToResizeColumns = False
        Me.dgvメーカー一覧.AllowUserToResizeRows = False
        Me.dgvメーカー一覧.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvメーカー一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvメーカー一覧.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        Me.dgvメーカー一覧.Location = New System.Drawing.Point(3, 15)
        Me.dgvメーカー一覧.Name = "dgvメーカー一覧"
        Me.dgvメーカー一覧.RowTemplate.Height = 21
        Me.dgvメーカー一覧.Size = New System.Drawing.Size(324, 460)
        Me.dgvメーカー一覧.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.DataPropertyName = "メーカーID"
        Me.Column1.HeaderText = "メーカーID"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 78
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.DataPropertyName = "メーカー名称"
        Me.Column2.HeaderText = "メーカー名称"
        Me.Column2.Name = "Column2"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(660, 35)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "メーカーマスタ"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.rbt削除)
        Me.GroupBox1.Controls.Add(Me.rbt更新)
        Me.GroupBox1.Controls.Add(Me.rbt登録)
        Me.GroupBox1.Location = New System.Drawing.Point(348, 47)
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
        Me.GroupBox2.Controls.Add(Me.chk削除済表示)
        Me.GroupBox2.Controls.Add(Me.dgvメーカー一覧)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 47)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(330, 503)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "１．メーカー一覧"
        '
        'chk削除済表示
        '
        Me.chk削除済表示.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chk削除済表示.AutoSize = True
        Me.chk削除済表示.Location = New System.Drawing.Point(6, 481)
        Me.chk削除済表示.Name = "chk削除済表示"
        Me.chk削除済表示.Size = New System.Drawing.Size(96, 16)
        Me.chk削除済表示.TabIndex = 84
        Me.chk削除済表示.Text = "削除項目表示"
        Me.chk削除済表示.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.chk削除済)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.editメーカーID)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.editメーカー名称)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.edit更新日時)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.edit作成日時)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(348, 99)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(324, 415)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "３．詳細情報"
        '
        'chk削除済
        '
        Me.chk削除済.AutoSize = True
        Me.chk削除済.Location = New System.Drawing.Point(139, 158)
        Me.chk削除済.Name = "chk削除済"
        Me.chk削除済.Size = New System.Drawing.Size(71, 16)
        Me.chk削除済.TabIndex = 40
        Me.chk削除済.Text = "削除済み"
        Me.chk削除済.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 159)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "削除区分"
        '
        'editメーカーID
        '
        Me.editメーカーID.AllowSpace = SPWinFormControls.AllowSpaceMode.Both
        Me.editメーカーID.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.editメーカーID.Format = ""
        Me.editメーカーID.Location = New System.Drawing.Point(139, 25)
        Me.editメーカーID.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.editメーカーID.Name = "editメーカーID"
        Me.editメーカーID.ReadOnly = True
        Me.editメーカーID.Size = New System.Drawing.Size(73, 19)
        Me.editメーカーID.TabIndex = 36
        Me.editメーカーID.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 127)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 12)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "更新日時"
        '
        'editメーカー名称
        '
        Me.editメーカー名称.AllowSpace = SPWinFormControls.AllowSpaceMode.Both
        Me.editメーカー名称.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.editメーカー名称.Format = ""
        Me.editメーカー名称.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.editメーカー名称.Location = New System.Drawing.Point(139, 57)
        Me.editメーカー名称.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.editメーカー名称.MaxLength = 50
        Me.editメーカー名称.Name = "editメーカー名称"
        Me.editメーカー名称.Size = New System.Drawing.Size(179, 19)
        Me.editメーカー名称.TabIndex = 34
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(18, 60)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 12)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "メーカー名称"
        '
        'edit更新日時
        '
        Me.edit更新日時.AllowSpace = SPWinFormControls.AllowSpaceMode.Both
        Me.edit更新日時.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.edit更新日時.Format = ""
        Me.edit更新日時.Location = New System.Drawing.Point(139, 124)
        Me.edit更新日時.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.edit更新日時.Name = "edit更新日時"
        Me.edit更新日時.ReadOnly = True
        Me.edit更新日時.Size = New System.Drawing.Size(120, 19)
        Me.edit更新日時.TabIndex = 18
        Me.edit更新日時.TabStop = False
        Me.edit更新日時.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 95)
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
        Me.edit作成日時.Location = New System.Drawing.Point(139, 92)
        Me.edit作成日時.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.edit作成日時.Name = "edit作成日時"
        Me.edit作成日時.ReadOnly = True
        Me.edit作成日時.Size = New System.Drawing.Size(120, 19)
        Me.edit作成日時.TabIndex = 14
        Me.edit作成日時.TabStop = False
        Me.edit作成日時.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "メーカーID"
        '
        'btn更新
        '
        Me.btn更新.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn更新.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn更新.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn更新.Location = New System.Drawing.Point(348, 520)
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
        Me.btn終了.Location = New System.Drawing.Point(592, 520)
        Me.btn終了.Name = "btn終了"
        Me.btn終了.Size = New System.Drawing.Size(80, 30)
        Me.btn終了.TabIndex = 11
        Me.btn終了.Text = "終 了"
        Me.btn終了.UseVisualStyleBackColor = True
        '
        'frm23_メーカー
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 562)
        Me.Controls.Add(Me.btn終了)
        Me.Controls.Add(Me.btn更新)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.MinimumSize = New System.Drawing.Size(700, 600)
        Me.Name = "frm23_メーカー"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "メーカーマスタ"
        CType(Me.dgvメーカー一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvメーカー一覧 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btn更新 As Button
    Friend WithEvents btn終了 As Button
    Friend WithEvents rbt削除 As RadioButton
    Friend WithEvents rbt更新 As RadioButton
    Friend WithEvents rbt登録 As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents edit作成日時 As SPWinFormControls.SPEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents edit更新日時 As SPWinFormControls.SPEdit
    Friend WithEvents editメーカー名称 As SPWinFormControls.SPEdit
    Friend WithEvents Label10 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents editメーカーID As SPWinFormControls.SPEdit
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents chk削除済表示 As CheckBox
    Friend WithEvents Label7 As Label
    Friend WithEvents chk削除済 As CheckBox
End Class
