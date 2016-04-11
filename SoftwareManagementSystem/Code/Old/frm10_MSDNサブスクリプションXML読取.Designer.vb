<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class _frm10_MSDNサブスクリプションXML読取
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
        Me.components = New System.ComponentModel.Container()
        Me.tbxXMLパス = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn参照 = New System.Windows.Forms.Button()
        Me.dgv一覧 = New System.Windows.Forms.DataGridView()
        Me.製品名 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.キータイプ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.キー取得日 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.プロダクトキー = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btn更新 = New System.Windows.Forms.Button()
        Me.grpデータ読込 = New System.Windows.Forms.GroupBox()
        Me.btn読取 = New System.Windows.Forms.Button()
        Me.ofdXML = New System.Windows.Forms.OpenFileDialog()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.editサブスクリプションID = New SPWinFormControls.SPEdit(Me.components)
        Me.cbxメーカー選択 = New System.Windows.Forms.ComboBox()
        Me.cbx利用者選択 = New System.Windows.Forms.ComboBox()
        CType(Me.dgv一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpデータ読込.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbxXMLパス
        '
        Me.tbxXMLパス.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxXMLパス.Location = New System.Drawing.Point(6, 22)
        Me.tbxXMLパス.Name = "tbxXMLパス"
        Me.tbxXMLパス.ReadOnly = True
        Me.tbxXMLパス.Size = New System.Drawing.Size(300, 19)
        Me.tbxXMLパス.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(460, 35)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "MSDN サブスクリプション XML読取"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn参照
        '
        Me.btn参照.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn参照.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn参照.Location = New System.Drawing.Point(312, 20)
        Me.btn参照.Name = "btn参照"
        Me.btn参照.Size = New System.Drawing.Size(65, 23)
        Me.btn参照.TabIndex = 6
        Me.btn参照.Text = "参照"
        Me.btn参照.UseVisualStyleBackColor = True
        '
        'dgv一覧
        '
        Me.dgv一覧.AllowUserToAddRows = False
        Me.dgv一覧.AllowUserToDeleteRows = False
        Me.dgv一覧.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv一覧.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.製品名, Me.キータイプ, Me.キー取得日, Me.プロダクトキー, Me.ID})
        Me.dgv一覧.Location = New System.Drawing.Point(12, 114)
        Me.dgv一覧.MultiSelect = False
        Me.dgv一覧.Name = "dgv一覧"
        Me.dgv一覧.RowTemplate.Height = 21
        Me.dgv一覧.Size = New System.Drawing.Size(460, 304)
        Me.dgv一覧.TabIndex = 8
        '
        '製品名
        '
        Me.製品名.DataPropertyName = "ProductName"
        Me.製品名.HeaderText = "製品名"
        Me.製品名.Name = "製品名"
        '
        'キータイプ
        '
        Me.キータイプ.DataPropertyName = "KeyType"
        Me.キータイプ.HeaderText = "キータイプ"
        Me.キータイプ.Name = "キータイプ"
        '
        'キー取得日
        '
        Me.キー取得日.DataPropertyName = "ClaimedDate"
        Me.キー取得日.HeaderText = "キー取得日"
        Me.キー取得日.Name = "キー取得日"
        '
        'プロダクトキー
        '
        Me.プロダクトキー.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.プロダクトキー.DataPropertyName = "ProductKey"
        Me.プロダクトキー.HeaderText = "プロダクトキー"
        Me.プロダクトキー.Name = "プロダクトキー"
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.Visible = False
        '
        'btn更新
        '
        Me.btn更新.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn更新.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn更新.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn更新.Location = New System.Drawing.Point(392, 424)
        Me.btn更新.Name = "btn更新"
        Me.btn更新.Size = New System.Drawing.Size(80, 30)
        Me.btn更新.TabIndex = 9
        Me.btn更新.Text = "更 新"
        Me.btn更新.UseVisualStyleBackColor = True
        '
        'grpデータ読込
        '
        Me.grpデータ読込.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpデータ読込.Controls.Add(Me.btn読取)
        Me.grpデータ読込.Controls.Add(Me.tbxXMLパス)
        Me.grpデータ読込.Controls.Add(Me.btn参照)
        Me.grpデータ読込.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.grpデータ読込.Location = New System.Drawing.Point(12, 55)
        Me.grpデータ読込.Name = "grpデータ読込"
        Me.grpデータ読込.Size = New System.Drawing.Size(460, 53)
        Me.grpデータ読込.TabIndex = 10
        Me.grpデータ読込.TabStop = False
        Me.grpデータ読込.Text = "XMLファイル参照"
        '
        'btn読取
        '
        Me.btn読取.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn読取.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn読取.Location = New System.Drawing.Point(383, 20)
        Me.btn読取.Name = "btn読取"
        Me.btn読取.Size = New System.Drawing.Size(65, 23)
        Me.btn読取.TabIndex = 7
        Me.btn読取.Text = "読取"
        Me.btn読取.UseVisualStyleBackColor = True
        Me.btn読取.Visible = False
        '
        'ofdXML
        '
        Me.ofdXML.FileName = "OpenFileDialog1"
        Me.ofdXML.Filter = "XML (*.xml)|*.xml|すべて (*.*)|*.*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 435)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 12)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "サブスクリプションID"
        '
        'editサブスクリプションID
        '
        Me.editサブスクリプションID.AllowSpace = SPWinFormControls.AllowSpaceMode.Both
        Me.editサブスクリプションID.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.editサブスクリプションID.Format = "9"
        Me.editサブスクリプションID.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.editサブスクリプションID.Location = New System.Drawing.Point(12, 413)
        Me.editサブスクリプションID.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.editサブスクリプションID.MaxLength = 20
        Me.editサブスクリプションID.Name = "editサブスクリプションID"
        Me.editサブスクリプションID.Size = New System.Drawing.Size(150, 19)
        Me.editサブスクリプションID.TabIndex = 14
        Me.editサブスクリプションID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbxメーカー選択
        '
        Me.cbxメーカー選択.FormattingEnabled = True
        Me.cbxメーカー選択.Location = New System.Drawing.Point(268, 432)
        Me.cbxメーカー選択.Name = "cbxメーカー選択"
        Me.cbxメーカー選択.Size = New System.Drawing.Size(121, 20)
        Me.cbxメーカー選択.TabIndex = 15
        Me.cbxメーカー選択.Text = "Microsoft"
        '
        'cbx利用者選択
        '
        Me.cbx利用者選択.FormattingEnabled = True
        Me.cbx利用者選択.Location = New System.Drawing.Point(141, 432)
        Me.cbx利用者選択.Name = "cbx利用者選択"
        Me.cbx利用者選択.Size = New System.Drawing.Size(121, 20)
        Me.cbx利用者選択.TabIndex = 16
        Me.cbx利用者選択.Text = "利用者氏名"
        '
        'frm10_MSDNサブスクリプションXML読取
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 462)
        Me.Controls.Add(Me.cbx利用者選択)
        Me.Controls.Add(Me.cbxメーカー選択)
        Me.Controls.Add(Me.editサブスクリプションID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.grpデータ読込)
        Me.Controls.Add(Me.btn更新)
        Me.Controls.Add(Me.dgv一覧)
        Me.Controls.Add(Me.Label1)
        Me.MinimumSize = New System.Drawing.Size(500, 300)
        Me.Name = "frm10_MSDNサブスクリプションXML読取"
        Me.Text = "frm01_MSDNサブスクリプションXML読取"
        CType(Me.dgv一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpデータ読込.ResumeLayout(False)
        Me.grpデータ読込.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbxXMLパス As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btn参照 As Button
    Friend WithEvents dgv一覧 As DataGridView
    Friend WithEvents btn更新 As Button
    Friend WithEvents grpデータ読込 As GroupBox
    Friend WithEvents btn読取 As Button
    Friend WithEvents 製品名 As DataGridViewTextBoxColumn
    Friend WithEvents キータイプ As DataGridViewTextBoxColumn
    Friend WithEvents キー取得日 As DataGridViewTextBoxColumn
    Friend WithEvents プロダクトキー As DataGridViewTextBoxColumn
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents ofdXML As OpenFileDialog
    Friend WithEvents Label2 As Label
    Friend WithEvents editサブスクリプションID As SPWinFormControls.SPEdit
    Friend WithEvents cbxメーカー選択 As ComboBox
    Friend WithEvents cbx利用者選択 As ComboBox
End Class
