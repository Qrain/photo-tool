<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm31_プロダクトキー情報照会
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
        Me.dgv一覧 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rbtソフト名称 = New System.Windows.Forms.RadioButton()
        Me.rbtサブスクリプションID = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbx権利者 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbx利用者 = New System.Windows.Forms.ComboBox()
        Me.cbxメーカーID = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbtプロダクトキー = New System.Windows.Forms.RadioButton()
        Me.btn検索 = New System.Windows.Forms.Button()
        Me.txt検索 = New System.Windows.Forms.TextBox()
        Me.dgvcメーカー = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvcソフトウェア = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvcプロダクトキー = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvc権利者 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvcサブスクリプションID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvc利用者 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgv一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv一覧
        '
        Me.dgv一覧.AllowUserToAddRows = False
        Me.dgv一覧.AllowUserToDeleteRows = False
        Me.dgv一覧.AllowUserToResizeColumns = False
        Me.dgv一覧.AllowUserToResizeRows = False
        Me.dgv一覧.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvcメーカー, Me.dgvcソフトウェア, Me.dgvcプロダクトキー, Me.dgvc権利者, Me.dgvcサブスクリプションID, Me.dgvc利用者})
        Me.dgv一覧.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv一覧.Location = New System.Drawing.Point(3, 15)
        Me.dgv一覧.Name = "dgv一覧"
        Me.dgv一覧.ReadOnly = True
        Me.dgv一覧.RowHeadersWidth = 25
        Me.dgv一覧.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgv一覧.RowTemplate.Height = 21
        Me.dgv一覧.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv一覧.Size = New System.Drawing.Size(854, 551)
        Me.dgv一覧.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(860, 35)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "プロダクトキー情報照会"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.dgv一覧)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 121)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(860, 569)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "プロダクトキー情報"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.rbtソフト名称)
        Me.GroupBox4.Controls.Add(Me.rbtサブスクリプションID)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.cbx権利者)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.cbx利用者)
        Me.GroupBox4.Controls.Add(Me.cbxメーカーID)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.rbtプロダクトキー)
        Me.GroupBox4.Controls.Add(Me.btn検索)
        Me.GroupBox4.Controls.Add(Me.txt検索)
        Me.GroupBox4.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(12, 47)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(860, 68)
        Me.GroupBox4.TabIndex = 26
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "検索"
        '
        'rbtソフト名称
        '
        Me.rbtソフト名称.AutoSize = True
        Me.rbtソフト名称.Checked = True
        Me.rbtソフト名称.Location = New System.Drawing.Point(15, 43)
        Me.rbtソフト名称.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.rbtソフト名称.Name = "rbtソフト名称"
        Me.rbtソフト名称.Size = New System.Drawing.Size(72, 16)
        Me.rbtソフト名称.TabIndex = 19
        Me.rbtソフト名称.TabStop = True
        Me.rbtソフト名称.Text = "ソフト名称"
        Me.rbtソフト名称.UseVisualStyleBackColor = True
        '
        'rbtサブスクリプションID
        '
        Me.rbtサブスクリプションID.AutoSize = True
        Me.rbtサブスクリプションID.Location = New System.Drawing.Point(100, 43)
        Me.rbtサブスクリプションID.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.rbtサブスクリプションID.Name = "rbtサブスクリプションID"
        Me.rbtサブスクリプションID.Size = New System.Drawing.Size(111, 16)
        Me.rbtサブスクリプションID.TabIndex = 18
        Me.rbtサブスクリプションID.TabStop = True
        Me.rbtサブスクリプションID.Text = "サブスクリプションID"
        Me.rbtサブスクリプションID.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 20)
        Me.Label4.Margin = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "権利者"
        '
        'cbx権利者
        '
        Me.cbx権利者.BackColor = System.Drawing.SystemColors.Window
        Me.cbx権利者.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx権利者.FormattingEnabled = True
        Me.cbx権利者.Location = New System.Drawing.Point(60, 17)
        Me.cbx権利者.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.cbx権利者.Name = "cbx権利者"
        Me.cbx権利者.Size = New System.Drawing.Size(100, 20)
        Me.cbx権利者.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(384, 20)
        Me.Label3.Margin = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "利用者"
        '
        'cbx利用者
        '
        Me.cbx利用者.BackColor = System.Drawing.SystemColors.Window
        Me.cbx利用者.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx利用者.FormattingEnabled = True
        Me.cbx利用者.Location = New System.Drawing.Point(431, 17)
        Me.cbx利用者.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.cbx利用者.Name = "cbx利用者"
        Me.cbx利用者.Size = New System.Drawing.Size(100, 20)
        Me.cbx利用者.TabIndex = 14
        '
        'cbxメーカーID
        '
        Me.cbxメーカーID.BackColor = System.Drawing.SystemColors.Window
        Me.cbxメーカーID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxメーカーID.FormattingEnabled = True
        Me.cbxメーカーID.Location = New System.Drawing.Point(221, 17)
        Me.cbxメーカーID.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.cbxメーカーID.Name = "cbxメーカーID"
        Me.cbxメーカーID.Size = New System.Drawing.Size(150, 20)
        Me.cbxメーカーID.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(173, 20)
        Me.Label2.Margin = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 12)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "メーカー"
        '
        'rbtプロダクトキー
        '
        Me.rbtプロダクトキー.AutoSize = True
        Me.rbtプロダクトキー.Location = New System.Drawing.Point(221, 43)
        Me.rbtプロダクトキー.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.rbtプロダクトキー.Name = "rbtプロダクトキー"
        Me.rbtプロダクトキー.Size = New System.Drawing.Size(86, 16)
        Me.rbtプロダクトキー.TabIndex = 10
        Me.rbtプロダクトキー.TabStop = True
        Me.rbtプロダクトキー.Text = "プロダクトキー"
        Me.rbtプロダクトキー.UseVisualStyleBackColor = True
        '
        'btn検索
        '
        Me.btn検索.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn検索.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn検索.Location = New System.Drawing.Point(758, 40)
        Me.btn検索.Name = "btn検索"
        Me.btn検索.Size = New System.Drawing.Size(65, 23)
        Me.btn検索.TabIndex = 9
        Me.btn検索.Text = "検索"
        Me.btn検索.UseVisualStyleBackColor = True
        '
        'txt検索
        '
        Me.txt検索.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt検索.Location = New System.Drawing.Point(313, 42)
        Me.txt検索.Name = "txt検索"
        Me.txt検索.Size = New System.Drawing.Size(439, 19)
        Me.txt検索.TabIndex = 7
        '
        'dgvcメーカー
        '
        Me.dgvcメーカー.DataPropertyName = "メーカー名称"
        Me.dgvcメーカー.HeaderText = "メーカー"
        Me.dgvcメーカー.Name = "dgvcメーカー"
        Me.dgvcメーカー.ReadOnly = True
        Me.dgvcメーカー.Width = 70
        '
        'dgvcソフトウェア
        '
        Me.dgvcソフトウェア.DataPropertyName = "ソフトウェア名称"
        Me.dgvcソフトウェア.HeaderText = "ソフトウェア"
        Me.dgvcソフトウェア.Name = "dgvcソフトウェア"
        Me.dgvcソフトウェア.ReadOnly = True
        Me.dgvcソフトウェア.Width = 300
        '
        'dgvcプロダクトキー
        '
        Me.dgvcプロダクトキー.DataPropertyName = "プロダクトキー"
        Me.dgvcプロダクトキー.HeaderText = "プロダクトキー"
        Me.dgvcプロダクトキー.Name = "dgvcプロダクトキー"
        Me.dgvcプロダクトキー.ReadOnly = True
        Me.dgvcプロダクトキー.Width = 230
        '
        'dgvc権利者
        '
        Me.dgvc権利者.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgvc権利者.DataPropertyName = "権利者"
        Me.dgvc権利者.HeaderText = "権利者"
        Me.dgvc権利者.Name = "dgvc権利者"
        Me.dgvc権利者.ReadOnly = True
        Me.dgvc権利者.Width = 66
        '
        'dgvcサブスクリプションID
        '
        Me.dgvcサブスクリプションID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgvcサブスクリプションID.DataPropertyName = "サブスクリプションID"
        Me.dgvcサブスクリプションID.HeaderText = "サブスクリプションID"
        Me.dgvcサブスクリプションID.Name = "dgvcサブスクリプションID"
        Me.dgvcサブスクリプションID.ReadOnly = True
        Me.dgvcサブスクリプションID.Width = 118
        '
        'dgvc利用者
        '
        Me.dgvc利用者.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvc利用者.DataPropertyName = "利用者"
        Me.dgvc利用者.HeaderText = "利用者"
        Me.dgvc利用者.Name = "dgvc利用者"
        Me.dgvc利用者.ReadOnly = True
        '
        'frm31_情報照会
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 702)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label1)
        Me.MinimumSize = New System.Drawing.Size(900, 740)
        Me.Name = "frm31_情報照会"
        Me.Text = "プロダクトキー情報照会"
        CType(Me.dgv一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dgv一覧 As DataGridView
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents rbtプロダクトキー As RadioButton
    Friend WithEvents btn検索 As Button
    Friend WithEvents txt検索 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbxメーカーID As ComboBox
    Friend WithEvents cbx利用者 As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cbx権利者 As ComboBox
    Friend WithEvents rbtサブスクリプションID As RadioButton
    Friend WithEvents rbtソフト名称 As RadioButton
    Friend WithEvents dgvcメーカー As DataGridViewTextBoxColumn
    Friend WithEvents dgvcソフトウェア As DataGridViewTextBoxColumn
    Friend WithEvents dgvcプロダクトキー As DataGridViewTextBoxColumn
    Friend WithEvents dgvc権利者 As DataGridViewTextBoxColumn
    Friend WithEvents dgvcサブスクリプションID As DataGridViewTextBoxColumn
    Friend WithEvents dgvc利用者 As DataGridViewTextBoxColumn
End Class
