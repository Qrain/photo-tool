<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class _frmファイル実体登録編集機能
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
        Me.lblタイトル = New System.Windows.Forms.Label()
        Me.grpファイル = New System.Windows.Forms.GroupBox()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.chkDL済 = New System.Windows.Forms.CheckBox()
        Me.tbxファイル名 = New System.Windows.Forms.TextBox()
        Me.btn参照 = New System.Windows.Forms.Button()
        Me.rbtHash自動 = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbxメーカーID = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.rbtHash手動 = New System.Windows.Forms.RadioButton()
        Me.grp利用識別情報 = New System.Windows.Forms.GroupBox()
        Me.cbx利用者ID = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbxサブスクライバーID = New System.Windows.Forms.ComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn更新 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbt削除 = New System.Windows.Forms.RadioButton()
        Me.rbt更新 = New System.Windows.Forms.RadioButton()
        Me.rbt登録 = New System.Windows.Forms.RadioButton()
        Me.dgvアクティベーション一覧 = New System.Windows.Forms.DataGridView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btn検索 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.rbt条件B = New System.Windows.Forms.RadioButton()
        Me.rbt条件A = New System.Windows.Forms.RadioButton()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.アクティベーション選択 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.アクティベーションID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.アクティベーションキー名称 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.アクティベーションキー = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rbt条件C = New System.Windows.Forms.RadioButton()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.grpファイル.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grp利用識別情報.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvアクティベーション一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblタイトル
        '
        Me.lblタイトル.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblタイトル.Font = New System.Drawing.Font("MS UI Gothic", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblタイトル.ForeColor = System.Drawing.Color.Blue
        Me.lblタイトル.Location = New System.Drawing.Point(12, 9)
        Me.lblタイトル.Name = "lblタイトル"
        Me.lblタイトル.Size = New System.Drawing.Size(690, 35)
        Me.lblタイトル.TabIndex = 18
        Me.lblタイトル.Text = "ファイル実体登録編集機能"
        Me.lblタイトル.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpファイル
        '
        Me.grpファイル.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpファイル.Controls.Add(Me.Label4)
        Me.grpファイル.Controls.Add(Me.TextBox3)
        Me.grpファイル.Controls.Add(Me.lblMsg)
        Me.grpファイル.Controls.Add(Me.chkDL済)
        Me.grpファイル.Controls.Add(Me.tbxファイル名)
        Me.grpファイル.Controls.Add(Me.btn参照)
        Me.grpファイル.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.grpファイル.Location = New System.Drawing.Point(297, 97)
        Me.grpファイル.Name = "grpファイル"
        Me.grpファイル.Size = New System.Drawing.Size(405, 96)
        Me.grpファイル.TabIndex = 21
        Me.grpファイル.TabStop = False
        Me.grpファイル.Text = "ファイル情報"
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Location = New System.Drawing.Point(114, 50)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(217, 12)
        Me.lblMsg.TabIndex = 8
        Me.lblMsg.Text = "※ダウンロードしたファイルを参照して下さい↓"
        '
        'chkDL済
        '
        Me.chkDL済.AutoSize = True
        Me.chkDL済.Checked = True
        Me.chkDL済.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDL済.Location = New System.Drawing.Point(17, 49)
        Me.chkDL済.Name = "chkDL済"
        Me.chkDL済.Size = New System.Drawing.Size(91, 16)
        Me.chkDL済.TabIndex = 7
        Me.chkDL済.Text = "ダウンロード済"
        Me.chkDL済.UseVisualStyleBackColor = True
        '
        'tbxファイル名
        '
        Me.tbxファイル名.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxファイル名.Location = New System.Drawing.Point(17, 71)
        Me.tbxファイル名.Name = "tbxファイル名"
        Me.tbxファイル名.Size = New System.Drawing.Size(293, 19)
        Me.tbxファイル名.TabIndex = 0
        Me.tbxファイル名.Text = "ファイル参照パス又はファイル名"
        '
        'btn参照
        '
        Me.btn参照.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn参照.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn参照.Location = New System.Drawing.Point(316, 69)
        Me.btn参照.Name = "btn参照"
        Me.btn参照.Size = New System.Drawing.Size(65, 23)
        Me.btn参照.TabIndex = 6
        Me.btn参照.Text = "参照"
        Me.btn参照.UseVisualStyleBackColor = True
        '
        'rbtHash自動
        '
        Me.rbtHash自動.AutoSize = True
        Me.rbtHash自動.Location = New System.Drawing.Point(13, 18)
        Me.rbtHash自動.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.rbtHash自動.Name = "rbtHash自動"
        Me.rbtHash自動.Size = New System.Drawing.Size(130, 16)
        Me.rbtHash自動.TabIndex = 7
        Me.rbtHash自動.TabStop = True
        Me.rbtHash自動.Text = "自動計算（MD5使用）"
        Me.rbtHash自動.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cbxメーカーID)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.rbtHash手動)
        Me.GroupBox1.Controls.Add(Me.rbtHash自動)
        Me.GroupBox1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(297, 199)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(405, 68)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ハッシュ登録方法"
        '
        'cbxメーカーID
        '
        Me.cbxメーカーID.FormattingEnabled = True
        Me.cbxメーカーID.Location = New System.Drawing.Point(116, 39)
        Me.cbxメーカーID.Name = "cbxメーカーID"
        Me.cbxメーカーID.Size = New System.Drawing.Size(100, 20)
        Me.cbxメーカーID.TabIndex = 24
        Me.cbxメーカーID.Text = "01: SHA1"
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Location = New System.Drawing.Point(222, 40)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(177, 19)
        Me.TextBox1.TabIndex = 7
        '
        'rbtHash手動
        '
        Me.rbtHash手動.AutoSize = True
        Me.rbtHash手動.Location = New System.Drawing.Point(13, 40)
        Me.rbtHash手動.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.rbtHash手動.Name = "rbtHash手動"
        Me.rbtHash手動.Size = New System.Drawing.Size(71, 16)
        Me.rbtHash手動.TabIndex = 8
        Me.rbtHash手動.TabStop = True
        Me.rbtHash手動.Text = "手動入力"
        Me.rbtHash手動.UseVisualStyleBackColor = True
        '
        'grp利用識別情報
        '
        Me.grp利用識別情報.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp利用識別情報.Controls.Add(Me.cbx利用者ID)
        Me.grp利用識別情報.Controls.Add(Me.Label3)
        Me.grp利用識別情報.Controls.Add(Me.Label1)
        Me.grp利用識別情報.Controls.Add(Me.cbxサブスクライバーID)
        Me.grp利用識別情報.Controls.Add(Me.ComboBox1)
        Me.grp利用識別情報.Controls.Add(Me.Label2)
        Me.grp利用識別情報.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.grp利用識別情報.Location = New System.Drawing.Point(12, 464)
        Me.grp利用識別情報.Name = "grp利用識別情報"
        Me.grp利用識別情報.Size = New System.Drawing.Size(593, 59)
        Me.grp利用識別情報.TabIndex = 23
        Me.grp利用識別情報.TabStop = False
        Me.grp利用識別情報.Text = "利用識別情報"
        '
        'cbx利用者ID
        '
        Me.cbx利用者ID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbx利用者ID.FormattingEnabled = True
        Me.cbx利用者ID.Location = New System.Drawing.Point(16, 33)
        Me.cbx利用者ID.Name = "cbx利用者ID"
        Me.cbx利用者ID.Size = New System.Drawing.Size(120, 20)
        Me.cbx利用者ID.TabIndex = 21
        Me.cbx利用者ID.Text = "001: 鈴木 太郎"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(266, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 12)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "サブスクライバーID"
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
        Me.Label1.Text = "利用者ID"
        '
        'cbxサブスクライバーID
        '
        Me.cbxサブスクライバーID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbxサブスクライバーID.FormattingEnabled = True
        Me.cbxサブスクライバーID.Location = New System.Drawing.Point(268, 33)
        Me.cbxサブスクライバーID.Name = "cbxサブスクライバーID"
        Me.cbxサブスクライバーID.Size = New System.Drawing.Size(120, 20)
        Me.cbxサブスクライバーID.TabIndex = 25
        Me.cbxサブスクライバーID.Text = "12345abcde"
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(142, 33)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(120, 20)
        Me.ComboBox1.TabIndex = 23
        Me.ComboBox1.Text = "001: Microsoft"
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
        'btn更新
        '
        Me.btn更新.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn更新.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn更新.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn更新.Location = New System.Drawing.Point(622, 493)
        Me.btn更新.Name = "btn更新"
        Me.btn更新.Size = New System.Drawing.Size(80, 30)
        Me.btn更新.TabIndex = 24
        Me.btn更新.Text = "更 新"
        Me.btn更新.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.rbt削除)
        Me.GroupBox3.Controls.Add(Me.rbt更新)
        Me.GroupBox3.Controls.Add(Me.rbt登録)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 97)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(279, 46)
        Me.GroupBox3.TabIndex = 25
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "２．操作モード"
        '
        'rbt削除
        '
        Me.rbt削除.AutoSize = True
        Me.rbt削除.Location = New System.Drawing.Point(137, 20)
        Me.rbt削除.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
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
        Me.rbt更新.Location = New System.Drawing.Point(77, 20)
        Me.rbt更新.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
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
        Me.rbt登録.Location = New System.Drawing.Point(13, 20)
        Me.rbt登録.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.rbt登録.Name = "rbt登録"
        Me.rbt登録.Size = New System.Drawing.Size(47, 16)
        Me.rbt登録.TabIndex = 0
        Me.rbt登録.TabStop = True
        Me.rbt登録.Text = "登録"
        Me.rbt登録.UseVisualStyleBackColor = True
        '
        'dgvアクティベーション一覧
        '
        Me.dgvアクティベーション一覧.AllowUserToAddRows = False
        Me.dgvアクティベーション一覧.AllowUserToDeleteRows = False
        Me.dgvアクティベーション一覧.AllowUserToResizeColumns = False
        Me.dgvアクティベーション一覧.AllowUserToResizeRows = False
        Me.dgvアクティベーション一覧.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvアクティベーション一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvアクティベーション一覧.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.アクティベーション選択, Me.アクティベーションID, Me.アクティベーションキー名称, Me.アクティベーションキー})
        Me.dgvアクティベーション一覧.Location = New System.Drawing.Point(297, 273)
        Me.dgvアクティベーション一覧.Name = "dgvアクティベーション一覧"
        Me.dgvアクティベーション一覧.RowTemplate.Height = 21
        Me.dgvアクティベーション一覧.Size = New System.Drawing.Size(405, 181)
        Me.dgvアクティベーション一覧.TabIndex = 25
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.rbt条件C)
        Me.GroupBox4.Controls.Add(Me.btn検索)
        Me.GroupBox4.Controls.Add(Me.TextBox2)
        Me.GroupBox4.Controls.Add(Me.rbt条件B)
        Me.GroupBox4.Controls.Add(Me.rbt条件A)
        Me.GroupBox4.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(12, 47)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(690, 44)
        Me.GroupBox4.TabIndex = 25
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "検索"
        '
        'btn検索
        '
        Me.btn検索.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn検索.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn検索.Location = New System.Drawing.Point(601, 15)
        Me.btn検索.Name = "btn検索"
        Me.btn検索.Size = New System.Drawing.Size(65, 23)
        Me.btn検索.TabIndex = 9
        Me.btn検索.Text = "検索"
        Me.btn検索.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.Location = New System.Drawing.Point(244, 17)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(351, 19)
        Me.TextBox2.TabIndex = 7
        '
        'rbt条件B
        '
        Me.rbt条件B.AutoSize = True
        Me.rbt条件B.Location = New System.Drawing.Point(81, 18)
        Me.rbt条件B.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.rbt条件B.Name = "rbt条件B"
        Me.rbt条件B.Size = New System.Drawing.Size(55, 16)
        Me.rbt条件B.TabIndex = 8
        Me.rbt条件B.TabStop = True
        Me.rbt条件B.Text = "条件B"
        Me.rbt条件B.UseVisualStyleBackColor = True
        '
        'rbt条件A
        '
        Me.rbt条件A.AutoSize = True
        Me.rbt条件A.Location = New System.Drawing.Point(13, 18)
        Me.rbt条件A.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.rbt条件A.Name = "rbt条件A"
        Me.rbt条件A.Size = New System.Drawing.Size(55, 16)
        Me.rbt条件A.TabIndex = 7
        Me.rbt条件A.TabStop = True
        Me.rbt条件A.Text = "条件A"
        Me.rbt条件A.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 149)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(279, 305)
        Me.DataGridView1.TabIndex = 26
        '
        'アクティベーション選択
        '
        Me.アクティベーション選択.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.アクティベーション選択.HeaderText = ""
        Me.アクティベーション選択.Name = "アクティベーション選択"
        Me.アクティベーション選択.Width = 21
        '
        'アクティベーションID
        '
        Me.アクティベーションID.HeaderText = "ID"
        Me.アクティベーションID.Name = "アクティベーションID"
        '
        'アクティベーションキー名称
        '
        Me.アクティベーションキー名称.HeaderText = "キー名称"
        Me.アクティベーションキー名称.Name = "アクティベーションキー名称"
        '
        'アクティベーションキー
        '
        Me.アクティベーションキー.HeaderText = "キー"
        Me.アクティベーションキー.Name = "アクティベーションキー"
        '
        'rbt条件C
        '
        Me.rbt条件C.AutoSize = True
        Me.rbt条件C.Location = New System.Drawing.Point(149, 18)
        Me.rbt条件C.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.rbt条件C.Name = "rbt条件C"
        Me.rbt条件C.Size = New System.Drawing.Size(55, 16)
        Me.rbt条件C.TabIndex = 10
        Me.rbt条件C.TabStop = True
        Me.rbt条件C.Text = "条件C"
        Me.rbt条件C.UseVisualStyleBackColor = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "ソフトID"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "ソフト名称"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderText = "ハッシュ値"
        Me.Column3.Name = "Column3"
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.Location = New System.Drawing.Point(75, 24)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(306, 19)
        Me.TextBox3.TabIndex = 9
        Me.TextBox3.Text = "ソフトウェアの正式名称"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 12)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "ソフト名称"
        '
        'frmファイル実体登録編集機能
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 531)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.dgvアクティベーション一覧)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btn更新)
        Me.Controls.Add(Me.grp利用識別情報)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpファイル)
        Me.Controls.Add(Me.lblタイトル)
        Me.Name = "frmファイル実体登録編集機能"
        Me.Text = "frmファイル実体登録編集機能"
        Me.grpファイル.ResumeLayout(False)
        Me.grpファイル.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grp利用識別情報.ResumeLayout(False)
        Me.grp利用識別情報.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvアクティベーション一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblタイトル As Label
    Friend WithEvents grpファイル As GroupBox
    Friend WithEvents tbxファイル名 As TextBox
    Friend WithEvents btn参照 As Button
    Friend WithEvents rbtHash自動 As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents rbtHash手動 As RadioButton
    Friend WithEvents cbxメーカーID As ComboBox
    Friend WithEvents lblMsg As Label
    Friend WithEvents chkDL済 As CheckBox
    Friend WithEvents grp利用識別情報 As GroupBox
    Friend WithEvents cbx利用者ID As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cbxサブスクライバーID As ComboBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btn更新 As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents rbt削除 As RadioButton
    Friend WithEvents rbt更新 As RadioButton
    Friend WithEvents rbt登録 As RadioButton
    Friend WithEvents dgvアクティベーション一覧 As DataGridView
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btn検索 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents rbt条件B As RadioButton
    Friend WithEvents rbt条件A As RadioButton
    Friend WithEvents アクティベーション選択 As DataGridViewCheckBoxColumn
    Friend WithEvents アクティベーションID As DataGridViewTextBoxColumn
    Friend WithEvents アクティベーションキー名称 As DataGridViewTextBoxColumn
    Friend WithEvents アクティベーションキー As DataGridViewTextBoxColumn
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents rbt条件C As RadioButton
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox3 As TextBox
End Class
