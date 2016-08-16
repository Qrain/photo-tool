<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm21_名称マスタ保守
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
        Me.dgv名称一覧 = New System.Windows.Forms.DataGridView()
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.edit備考 = New SPWinFormControls.SPEdit(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.edit名称コード = New SPWinFormControls.SPEdit(Me.components)
        Me.edit名称 = New SPWinFormControls.SPEdit(Me.components)
        Me.edit更新日時 = New SPWinFormControls.SPEdit(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.edit作成日時 = New SPWinFormControls.SPEdit(Me.components)
        Me.edit名称区分 = New SPWinFormControls.SPEdit(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn更新 = New System.Windows.Forms.Button()
        Me.btn終了 = New System.Windows.Forms.Button()
        CType(Me.dgv名称一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv名称一覧
        '
        Me.dgv名称一覧.AllowUserToAddRows = False
        Me.dgv名称一覧.AllowUserToDeleteRows = False
        Me.dgv名称一覧.AllowUserToResizeRows = False
        Me.dgv名称一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv名称一覧.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.dgv名称一覧.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv名称一覧.Location = New System.Drawing.Point(3, 15)
        Me.dgv名称一覧.Name = "dgv名称一覧"
        Me.dgv名称一覧.ReadOnly = True
        Me.dgv名称一覧.RowTemplate.Height = 21
        Me.dgv名称一覧.Size = New System.Drawing.Size(324, 385)
        Me.dgv名称一覧.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.DataPropertyName = "名称区分"
        Me.Column1.HeaderText = "名称区分"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 78
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.DataPropertyName = "名称コード"
        Me.Column2.HeaderText = "コード"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 57
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column3.DataPropertyName = "名称"
        Me.Column3.HeaderText = "名称"
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
        Me.Label1.Size = New System.Drawing.Size(660, 35)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "名称マスタ保守"
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
        Me.rbt削除.TabStop = True
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
        Me.rbt更新.TabStop = True
        Me.rbt更新.Text = "更新"
        Me.rbt更新.UseVisualStyleBackColor = True
        '
        'rbt登録
        '
        Me.rbt登録.AutoSize = True
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
        Me.GroupBox2.Controls.Add(Me.dgv名称一覧)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 47)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(330, 403)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "１．名称一覧"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.edit備考)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.edit名称コード)
        Me.GroupBox3.Controls.Add(Me.edit名称)
        Me.GroupBox3.Controls.Add(Me.edit更新日時)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.edit作成日時)
        Me.GroupBox3.Controls.Add(Me.edit名称区分)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Location = New System.Drawing.Point(348, 99)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(324, 315)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "３．詳細情報"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 137)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 12)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "備　考"
        '
        'edit備考
        '
        Me.edit備考.AllowSpace = SPWinFormControls.AllowSpaceMode.Both
        Me.edit備考.BackColor = System.Drawing.SystemColors.Window
        Me.edit備考.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.edit備考.Format = ""
        Me.edit備考.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.edit備考.Location = New System.Drawing.Point(110, 133)
        Me.edit備考.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.edit備考.MaxLength = 100
        Me.edit備考.Multiline = True
        Me.edit備考.Name = "edit備考"
        Me.edit備考.Size = New System.Drawing.Size(198, 80)
        Me.edit備考.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 104)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 12)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "名　称"
        '
        'edit名称コード
        '
        Me.edit名称コード.AllowSpace = SPWinFormControls.AllowSpaceMode.Both
        Me.edit名称コード.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.edit名称コード.Format = ""
        Me.edit名称コード.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.edit名称コード.Location = New System.Drawing.Point(110, 69)
        Me.edit名称コード.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.edit名称コード.MaxLength = 10
        Me.edit名称コード.Name = "edit名称コード"
        Me.edit名称コード.Size = New System.Drawing.Size(80, 19)
        Me.edit名称コード.TabIndex = 12
        '
        'edit名称
        '
        Me.edit名称.AllowSpace = SPWinFormControls.AllowSpaceMode.Both
        Me.edit名称.BackColor = System.Drawing.SystemColors.Window
        Me.edit名称.Format = ""
        Me.edit名称.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.edit名称.Location = New System.Drawing.Point(110, 101)
        Me.edit名称.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.edit名称.MaxLength = 50
        Me.edit名称.Name = "edit名称"
        Me.edit名称.Size = New System.Drawing.Size(198, 19)
        Me.edit名称.TabIndex = 13
        '
        'edit更新日時
        '
        Me.edit更新日時.AllowSpace = SPWinFormControls.AllowSpaceMode.Both
        Me.edit更新日時.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.edit更新日時.Format = ""
        Me.edit更新日時.Location = New System.Drawing.Point(110, 258)
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
        Me.Label5.Location = New System.Drawing.Point(18, 261)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "更新日時"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 229)
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
        Me.edit作成日時.Location = New System.Drawing.Point(110, 226)
        Me.edit作成日時.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.edit作成日時.Name = "edit作成日時"
        Me.edit作成日時.ReadOnly = True
        Me.edit作成日時.Size = New System.Drawing.Size(120, 19)
        Me.edit作成日時.TabIndex = 14
        Me.edit作成日時.TabStop = False
        Me.edit作成日時.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'edit名称区分
        '
        Me.edit名称区分.AllowSpace = SPWinFormControls.AllowSpaceMode.Both
        Me.edit名称区分.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.edit名称区分.Format = ""
        Me.edit名称区分.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.edit名称区分.Location = New System.Drawing.Point(110, 37)
        Me.edit名称区分.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.edit名称区分.MaxLength = 20
        Me.edit名称区分.Name = "edit名称区分"
        Me.edit名称区分.Size = New System.Drawing.Size(198, 19)
        Me.edit名称区分.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 12)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "名称コード"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "名称区分"
        '
        'btn更新
        '
        Me.btn更新.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn更新.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn更新.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn更新.Location = New System.Drawing.Point(348, 420)
        Me.btn更新.Name = "btn更新"
        Me.btn更新.Size = New System.Drawing.Size(80, 30)
        Me.btn更新.TabIndex = 81
        Me.btn更新.Text = "更 新"
        Me.btn更新.UseVisualStyleBackColor = True
        '
        'btn終了
        '
        Me.btn終了.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn終了.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn終了.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn終了.Location = New System.Drawing.Point(592, 420)
        Me.btn終了.Name = "btn終了"
        Me.btn終了.Size = New System.Drawing.Size(80, 30)
        Me.btn終了.TabIndex = 82
        Me.btn終了.Text = "終 了"
        Me.btn終了.UseVisualStyleBackColor = True
        '
        'frm21_名称マスタ保守
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 462)
        Me.Controls.Add(Me.btn終了)
        Me.Controls.Add(Me.btn更新)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.MinimumSize = New System.Drawing.Size(700, 500)
        Me.Name = "frm21_名称マスタ保守"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "名称マスタ保守"
        CType(Me.dgv名称一覧, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents edit名称区分 As SPWinFormControls.SPEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents edit更新日時 As SPWinFormControls.SPEdit
    Friend WithEvents Label6 As Label
    Friend WithEvents edit名称コード As SPWinFormControls.SPEdit
    Friend WithEvents edit名称 As SPWinFormControls.SPEdit
    Friend WithEvents Label7 As Label
    Friend WithEvents edit備考 As SPWinFormControls.SPEdit
    Friend WithEvents dgv名称一覧 As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
End Class
