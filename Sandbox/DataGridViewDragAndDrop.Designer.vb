<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataGridViewDragAndDrop
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
        Me.dgvLeft = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        CType(Me.dgvLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvLeft
        '
        Me.dgvLeft.AllowDrop = True
        Me.dgvLeft.AllowUserToAddRows = False
        Me.dgvLeft.AllowUserToResizeColumns = False
        Me.dgvLeft.AllowUserToResizeRows = False
        Me.dgvLeft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLeft.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        Me.dgvLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLeft.Location = New System.Drawing.Point(3, 3)
        Me.dgvLeft.Name = "dgvLeft"
        Me.dgvLeft.ReadOnly = True
        Me.dgvLeft.RowTemplate.Height = 21
        Me.dgvLeft.Size = New System.Drawing.Size(436, 456)
        Me.dgvLeft.TabIndex = 2
        '
        'Column1
        '
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column1.Text = ""
        Me.Column1.Width = 50
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "ファイルパス"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.dgvLeft, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(884, 462)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'ofd
        '
        Me.ofd.FileName = "OpenFileDialog1"
        '
        'DataGridViewDragAndDrop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 462)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "DataGridViewDragAndDrop"
        Me.Text = "DataGridViewDragAndDrop"
        CType(Me.dgvLeft, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvLeft As System.Windows.Forms.DataGridView
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ofd As System.Windows.Forms.OpenFileDialog
End Class
