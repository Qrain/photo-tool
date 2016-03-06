<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class プログラム選択
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
        Me.dgvList = New System.Windows.Forms.DataGridView()
        Me.btn選択 = New System.Windows.Forms.Button()
        Me.btnキャンセル = New System.Windows.Forms.Button()
        Me.プログラム名 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.バージョン = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.サイズ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.キー名 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.隠_アンインストーラー = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvList
        '
        Me.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.プログラム名, Me.バージョン, Me.サイズ, Me.キー名, Me.隠_アンインストーラー})
        Me.dgvList.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvList.Location = New System.Drawing.Point(0, 0)
        Me.dgvList.Name = "dgvList"
        Me.dgvList.RowTemplate.Height = 21
        Me.dgvList.Size = New System.Drawing.Size(484, 224)
        Me.dgvList.TabIndex = 0
        '
        'btn選択
        '
        Me.btn選択.Location = New System.Drawing.Point(316, 230)
        Me.btn選択.Name = "btn選択"
        Me.btn選択.Size = New System.Drawing.Size(75, 23)
        Me.btn選択.TabIndex = 1
        Me.btn選択.Text = "選択"
        Me.btn選択.UseVisualStyleBackColor = True
        '
        'btnキャンセル
        '
        Me.btnキャンセル.Location = New System.Drawing.Point(397, 230)
        Me.btnキャンセル.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.btnキャンセル.Name = "btnキャンセル"
        Me.btnキャンセル.Size = New System.Drawing.Size(75, 23)
        Me.btnキャンセル.TabIndex = 2
        Me.btnキャンセル.Text = "キャンセル"
        Me.btnキャンセル.UseVisualStyleBackColor = True
        '
        'プログラム名
        '
        Me.プログラム名.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.プログラム名.DataPropertyName = "Name"
        Me.プログラム名.HeaderText = "プログラム名"
        Me.プログラム名.Name = "プログラム名"
        Me.プログラム名.Width = 200
        '
        'バージョン
        '
        Me.バージョン.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.バージョン.DataPropertyName = "Version"
        Me.バージョン.HeaderText = "バージョン"
        Me.バージョン.Name = "バージョン"
        Me.バージョン.Width = 75
        '
        'サイズ
        '
        Me.サイズ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.サイズ.DataPropertyName = "Size"
        Me.サイズ.HeaderText = "サイズ"
        Me.サイズ.Name = "サイズ"
        Me.サイズ.Width = 59
        '
        'キー名
        '
        Me.キー名.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.キー名.DataPropertyName = "KeyName"
        Me.キー名.HeaderText = "キー名"
        Me.キー名.Name = "キー名"
        '
        '隠_アンインストーラー
        '
        Me.隠_アンインストーラー.DataPropertyName = "UninstallString"
        Me.隠_アンインストーラー.HeaderText = "隠_アンインストーラー"
        Me.隠_アンインストーラー.Name = "隠_アンインストーラー"
        Me.隠_アンインストーラー.Visible = False
        '
        'プログラム選択
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 262)
        Me.Controls.Add(Me.btnキャンセル)
        Me.Controls.Add(Me.btn選択)
        Me.Controls.Add(Me.dgvList)
        Me.Name = "プログラム選択"
        Me.Text = "Form1"
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvList As DataGridView
    Friend WithEvents btn選択 As Button
    Friend WithEvents btnキャンセル As Button
    Friend WithEvents プログラム名 As DataGridViewTextBoxColumn
    Friend WithEvents バージョン As DataGridViewTextBoxColumn
    Friend WithEvents サイズ As DataGridViewTextBoxColumn
    Friend WithEvents キー名 As DataGridViewTextBoxColumn
    Friend WithEvents 隠_アンインストーラー As DataGridViewTextBoxColumn
End Class
