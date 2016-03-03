<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class アンインストールツール
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
        Me.lst一覧 = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnUninstall = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.dgv値一覧 = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnModify = New System.Windows.Forms.Button()
        Me.lbl情報 = New System.Windows.Forms.Label()
        Me.dgvcKey = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvcValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgv値一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lst一覧
        '
        Me.lst一覧.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lst一覧.FormattingEnabled = True
        Me.lst一覧.ItemHeight = 12
        Me.lst一覧.Location = New System.Drawing.Point(3, 3)
        Me.lst一覧.Name = "lst一覧"
        Me.lst一覧.Size = New System.Drawing.Size(336, 416)
        Me.lst一覧.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(288, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(234, 314)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Label1"
        Me.Label1.Visible = False
        '
        'btnUninstall
        '
        Me.btnUninstall.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUninstall.AutoSize = True
        Me.btnUninstall.Location = New System.Drawing.Point(163, 3)
        Me.btnUninstall.Name = "btnUninstall"
        Me.btnUninstall.Size = New System.Drawing.Size(89, 23)
        Me.btnUninstall.TabIndex = 2
        Me.btnUninstall.Text = "アンインストール"
        Me.btnUninstall.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.btnUpdate.AutoSize = True
        Me.btnUpdate.Location = New System.Drawing.Point(258, 3)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 4
        Me.btnUpdate.Text = "情報更新"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'dgv値一覧
        '
        Me.dgv値一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv値一覧.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvcKey, Me.dgvcValue})
        Me.dgv値一覧.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv値一覧.Location = New System.Drawing.Point(345, 3)
        Me.dgv値一覧.Name = "dgv値一覧"
        Me.dgv値一覧.RowTemplate.Height = 21
        Me.dgv値一覧.Size = New System.Drawing.Size(336, 416)
        Me.dgv値一覧.TabIndex = 5
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lst一覧, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dgv値一覧, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl情報, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(684, 462)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btnUpdate)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnUninstall)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnModify)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(345, 425)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(336, 34)
        Me.FlowLayoutPanel1.TabIndex = 6
        '
        'btnModify
        '
        Me.btnModify.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnModify.AutoSize = True
        Me.btnModify.Location = New System.Drawing.Point(54, 3)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(103, 23)
        Me.btnModify.TabIndex = 5
        Me.btnModify.Text = "修正"
        Me.btnModify.UseVisualStyleBackColor = True
        '
        'lbl情報
        '
        Me.lbl情報.AutoSize = True
        Me.lbl情報.Location = New System.Drawing.Point(3, 422)
        Me.lbl情報.Name = "lbl情報"
        Me.lbl情報.Size = New System.Drawing.Size(38, 12)
        Me.lbl情報.TabIndex = 7
        Me.lbl情報.Text = "Label2"
        '
        'dgvcKey
        '
        Me.dgvcKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgvcKey.DataPropertyName = "Name"
        Me.dgvcKey.HeaderText = "Reg項目名"
        Me.dgvcKey.Name = "dgvcKey"
        Me.dgvcKey.Width = 86
        '
        'dgvcValue
        '
        Me.dgvcValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvcValue.DataPropertyName = "Value"
        Me.dgvcValue.HeaderText = "Reg値"
        Me.dgvcValue.Name = "dgvcValue"
        '
        'アンインストールツール
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 462)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "アンインストールツール"
        Me.Text = "アンストールツール"
        CType(Me.dgv値一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lst一覧 As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnUninstall As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents dgv値一覧 As DataGridView
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents btnModify As Button
    Friend WithEvents lbl情報 As Label
    Friend WithEvents dgvcKey As DataGridViewTextBoxColumn
    Friend WithEvents dgvcValue As DataGridViewTextBoxColumn
End Class
