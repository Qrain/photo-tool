<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm11_データインポート
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cbx権利者ID = New System.Windows.Forms.ComboBox()
        Me.grpデータ読込 = New System.Windows.Forms.GroupBox()
        Me.btn読込 = New System.Windows.Forms.Button()
        Me.tbxXMLパス = New System.Windows.Forms.TextBox()
        Me.btn参照 = New System.Windows.Forms.Button()
        Me.btn更新 = New System.Windows.Forms.Button()
        Me.dgv一覧 = New System.Windows.Forms.DataGridView()
        Me.lblタイトル = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbxメーカーID = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbxサブスクリプションID = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ofdXML = New System.Windows.Forms.OpenFileDialog()
        Me.lbl件数 = New System.Windows.Forms.Label()
        Me.dgvcKeyName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvcKeyType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvcClaimedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvcProductKey = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvc更新対象 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpデータ読込.SuspendLayout()
        CType(Me.dgv一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbx権利者ID
        '
        Me.cbx権利者ID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbx権利者ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx権利者ID.FormattingEnabled = True
        Me.cbx権利者ID.Location = New System.Drawing.Point(16, 33)
        Me.cbx権利者ID.Name = "cbx権利者ID"
        Me.cbx権利者ID.Size = New System.Drawing.Size(120, 20)
        Me.cbx権利者ID.TabIndex = 21
        '
        'grpデータ読込
        '
        Me.grpデータ読込.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpデータ読込.Controls.Add(Me.btn読込)
        Me.grpデータ読込.Controls.Add(Me.tbxXMLパス)
        Me.grpデータ読込.Controls.Add(Me.btn参照)
        Me.grpデータ読込.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.grpデータ読込.Location = New System.Drawing.Point(12, 47)
        Me.grpデータ読込.Name = "grpデータ読込"
        Me.grpデータ読込.Size = New System.Drawing.Size(860, 53)
        Me.grpデータ読込.TabIndex = 20
        Me.grpデータ読込.TabStop = False
        Me.grpデータ読込.Text = "XML参照"
        '
        'btn読込
        '
        Me.btn読込.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn読込.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn読込.Location = New System.Drawing.Point(780, 20)
        Me.btn読込.Name = "btn読込"
        Me.btn読込.Size = New System.Drawing.Size(65, 23)
        Me.btn読込.TabIndex = 7
        Me.btn読込.Text = "読 込"
        Me.btn読込.UseVisualStyleBackColor = True
        '
        'tbxXMLパス
        '
        Me.tbxXMLパス.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxXMLパス.Location = New System.Drawing.Point(13, 22)
        Me.tbxXMLパス.Margin = New System.Windows.Forms.Padding(10, 3, 10, 3)
        Me.tbxXMLパス.Name = "tbxXMLパス"
        Me.tbxXMLパス.Size = New System.Drawing.Size(680, 19)
        Me.tbxXMLパス.TabIndex = 0
        '
        'btn参照
        '
        Me.btn参照.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn参照.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn参照.Location = New System.Drawing.Point(706, 20)
        Me.btn参照.Name = "btn参照"
        Me.btn参照.Size = New System.Drawing.Size(65, 23)
        Me.btn参照.TabIndex = 6
        Me.btn参照.Text = "参 照"
        Me.btn参照.UseVisualStyleBackColor = True
        '
        'btn更新
        '
        Me.btn更新.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn更新.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn更新.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn更新.Location = New System.Drawing.Point(792, 619)
        Me.btn更新.Name = "btn更新"
        Me.btn更新.Size = New System.Drawing.Size(80, 30)
        Me.btn更新.TabIndex = 19
        Me.btn更新.Text = "更 新"
        Me.btn更新.UseVisualStyleBackColor = True
        '
        'dgv一覧
        '
        Me.dgv一覧.AllowUserToAddRows = False
        Me.dgv一覧.AllowUserToDeleteRows = False
        Me.dgv一覧.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv一覧.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvcKeyName, Me.dgvcKeyType, Me.dgvcClaimedDate, Me.dgvcProductKey, Me.dgvc更新対象})
        Me.dgv一覧.Location = New System.Drawing.Point(12, 106)
        Me.dgv一覧.MultiSelect = False
        Me.dgv一覧.Name = "dgv一覧"
        Me.dgv一覧.RowTemplate.Height = 21
        Me.dgv一覧.Size = New System.Drawing.Size(860, 460)
        Me.dgv一覧.TabIndex = 18
        '
        'lblタイトル
        '
        Me.lblタイトル.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblタイトル.Font = New System.Drawing.Font("MS UI Gothic", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblタイトル.ForeColor = System.Drawing.Color.Blue
        Me.lblタイトル.Location = New System.Drawing.Point(12, 9)
        Me.lblタイトル.Name = "lblタイトル"
        Me.lblタイトル.Size = New System.Drawing.Size(860, 35)
        Me.lblタイトル.TabIndex = 17
        Me.lblタイトル.Text = "msdn XMLインポート"
        Me.lblタイトル.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 12)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "権利者ID"
        '
        'cbxメーカーID
        '
        Me.cbxメーカーID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbxメーカーID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxメーカーID.FormattingEnabled = True
        Me.cbxメーカーID.Location = New System.Drawing.Point(142, 33)
        Me.cbxメーカーID.Name = "cbxメーカーID"
        Me.cbxメーカーID.Size = New System.Drawing.Size(120, 20)
        Me.cbxメーカーID.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(140, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "メーカーID"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(266, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 12)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "サブスクリプションID"
        '
        'cbxサブスクリプションID
        '
        Me.cbxサブスクリプションID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbxサブスクリプションID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxサブスクリプションID.FormattingEnabled = True
        Me.cbxサブスクリプションID.Location = New System.Drawing.Point(268, 33)
        Me.cbxサブスクリプションID.Name = "cbxサブスクリプションID"
        Me.cbxサブスクリプションID.Size = New System.Drawing.Size(120, 20)
        Me.cbxサブスクリプションID.TabIndex = 25
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cbx権利者ID)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbxサブスクリプションID)
        Me.GroupBox1.Controls.Add(Me.cbxメーカーID)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 594)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(765, 59)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "サブスクリプション情報"
        '
        'ofdXML
        '
        Me.ofdXML.FileName = "ofdXML"
        Me.ofdXML.Filter = "XML (*.xml)|*.xml|すべて (*.*)|*.*"
        '
        'lbl件数
        '
        Me.lbl件数.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl件数.AutoSize = True
        Me.lbl件数.Location = New System.Drawing.Point(14, 574)
        Me.lbl件数.Margin = New System.Windows.Forms.Padding(5)
        Me.lbl件数.Name = "lbl件数"
        Me.lbl件数.Size = New System.Drawing.Size(165, 12)
        Me.lbl件数.TabIndex = 22
        Me.lbl件数.Text = "全○件中　有効○件　無効○件"
        '
        'dgvcKeyName
        '
        Me.dgvcKeyName.DataPropertyName = "KeyName"
        Me.dgvcKeyName.HeaderText = "キー名"
        Me.dgvcKeyName.Name = "dgvcKeyName"
        Me.dgvcKeyName.Width = 200
        '
        'dgvcKeyType
        '
        Me.dgvcKeyType.DataPropertyName = "KeyType"
        Me.dgvcKeyType.HeaderText = "キー種類"
        Me.dgvcKeyType.Name = "dgvcKeyType"
        '
        'dgvcClaimedDate
        '
        Me.dgvcClaimedDate.DataPropertyName = "ClaimedDate"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.NullValue = Nothing
        Me.dgvcClaimedDate.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvcClaimedDate.HeaderText = "要求日"
        Me.dgvcClaimedDate.Name = "dgvcClaimedDate"
        Me.dgvcClaimedDate.Width = 75
        '
        'dgvcProductKey
        '
        Me.dgvcProductKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvcProductKey.DataPropertyName = "ProductKey"
        Me.dgvcProductKey.HeaderText = "プロダクトキー"
        Me.dgvcProductKey.Name = "dgvcProductKey"
        '
        'dgvc更新対象
        '
        Me.dgvc更新対象.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgvc更新対象.DataPropertyName = "Validity"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dgvc更新対象.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvc更新対象.HeaderText = "更新対象"
        Me.dgvc更新対象.Name = "dgvc更新対象"
        Me.dgvc更新対象.Width = 78
        '
        'frm11_データインポート
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 662)
        Me.Controls.Add(Me.lbl件数)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpデータ読込)
        Me.Controls.Add(Me.btn更新)
        Me.Controls.Add(Me.dgv一覧)
        Me.Controls.Add(Me.lblタイトル)
        Me.MinimumSize = New System.Drawing.Size(600, 500)
        Me.Name = "frm11_データインポート"
        Me.Text = "msdn XML インポート"
        Me.grpデータ読込.ResumeLayout(False)
        Me.grpデータ読込.PerformLayout()
        CType(Me.dgv一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbx権利者ID As ComboBox
    Friend WithEvents grpデータ読込 As GroupBox
    Friend WithEvents tbxXMLパス As TextBox
    Friend WithEvents btn参照 As Button
    Friend WithEvents btn更新 As Button
    Friend WithEvents dgv一覧 As DataGridView
    Friend WithEvents lblタイトル As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cbxメーカーID As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cbxサブスクリプションID As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btn読込 As Button
    Friend WithEvents ofdXML As OpenFileDialog
    Friend WithEvents lbl件数 As Label
    Friend WithEvents dgvcKeyName As DataGridViewTextBoxColumn
    Friend WithEvents dgvcKeyType As DataGridViewTextBoxColumn
    Friend WithEvents dgvcClaimedDate As DataGridViewTextBoxColumn
    Friend WithEvents dgvcProductKey As DataGridViewTextBoxColumn
    Friend WithEvents dgvc更新対象 As DataGridViewTextBoxColumn
End Class
