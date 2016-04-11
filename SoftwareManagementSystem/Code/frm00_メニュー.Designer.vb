<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm00_メニュー
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
        Me.grpデータ読込 = New System.Windows.Forms.GroupBox()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnMSDNxml読取 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn社員マスタ = New System.Windows.Forms.Button()
        Me.btnメーカーマスタ = New System.Windows.Forms.Button()
        Me.btnサブスクリプション = New System.Windows.Forms.Button()
        Me.btnソフトウェア = New System.Windows.Forms.Button()
        Me.btnプロダクトキーv3 = New System.Windows.Forms.Button()
        Me.btn名称マスタ = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn情報照会 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpデータ読込.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpデータ読込
        '
        Me.grpデータ読込.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpデータ読込.Controls.Add(Me.FlowLayoutPanel2)
        Me.grpデータ読込.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.grpデータ読込.Location = New System.Drawing.Point(12, 47)
        Me.grpデータ読込.Name = "grpデータ読込"
        Me.grpデータ読込.Size = New System.Drawing.Size(360, 63)
        Me.grpデータ読込.TabIndex = 0
        Me.grpデータ読込.TabStop = False
        Me.grpデータ読込.Text = "データ読込"
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.btnMSDNxml読取)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(3, 15)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(354, 45)
        Me.FlowLayoutPanel2.TabIndex = 6
        '
        'btnMSDNxml読取
        '
        Me.btnMSDNxml読取.AutoSize = True
        Me.btnMSDNxml読取.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnMSDNxml読取.Location = New System.Drawing.Point(3, 3)
        Me.btnMSDNxml読取.Name = "btnMSDNxml読取"
        Me.btnMSDNxml読取.Size = New System.Drawing.Size(168, 22)
        Me.btnMSDNxml読取.TabIndex = 0
        Me.btnMSDNxml読取.Text = "msdn subscriptions XML 読取"
        Me.btnMSDNxml読取.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.FlowLayoutPanel1)
        Me.GroupBox2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 130)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 20, 3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(360, 87)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "マスタ管理"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn社員マスタ)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnメーカーマスタ)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnサブスクリプション)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnソフトウェア)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnプロダクトキーv3)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn名称マスタ)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 15)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(354, 69)
        Me.FlowLayoutPanel1.TabIndex = 6
        '
        'btn社員マスタ
        '
        Me.btn社員マスタ.AutoSize = True
        Me.btn社員マスタ.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn社員マスタ.Location = New System.Drawing.Point(3, 3)
        Me.btn社員マスタ.Name = "btn社員マスタ"
        Me.btn社員マスタ.Size = New System.Drawing.Size(65, 22)
        Me.btn社員マスタ.TabIndex = 4
        Me.btn社員マスタ.Text = "社員マスタ"
        Me.btn社員マスタ.UseVisualStyleBackColor = True
        '
        'btnメーカーマスタ
        '
        Me.btnメーカーマスタ.AutoSize = True
        Me.btnメーカーマスタ.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnメーカーマスタ.Location = New System.Drawing.Point(74, 3)
        Me.btnメーカーマスタ.Name = "btnメーカーマスタ"
        Me.btnメーカーマスタ.Size = New System.Drawing.Size(78, 22)
        Me.btnメーカーマスタ.TabIndex = 0
        Me.btnメーカーマスタ.Text = "メーカーマスタ"
        Me.btnメーカーマスタ.UseVisualStyleBackColor = True
        '
        'btnサブスクリプション
        '
        Me.btnサブスクリプション.AutoSize = True
        Me.btnサブスクリプション.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnサブスクリプション.Location = New System.Drawing.Point(158, 3)
        Me.btnサブスクリプション.Name = "btnサブスクリプション"
        Me.btnサブスクリプション.Size = New System.Drawing.Size(116, 22)
        Me.btnサブスクリプション.TabIndex = 2
        Me.btnサブスクリプション.Text = "サブスクリプション登録"
        Me.btnサブスクリプション.UseVisualStyleBackColor = True
        '
        'btnソフトウェア
        '
        Me.btnソフトウェア.AutoSize = True
        Me.btnソフトウェア.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnソフトウェア.Location = New System.Drawing.Point(3, 31)
        Me.btnソフトウェア.Name = "btnソフトウェア"
        Me.btnソフトウェア.Size = New System.Drawing.Size(91, 22)
        Me.btnソフトウェア.TabIndex = 1
        Me.btnソフトウェア.Text = "ソフトウェアマスタ"
        Me.btnソフトウェア.UseVisualStyleBackColor = True
        '
        'btnプロダクトキーv3
        '
        Me.btnプロダクトキーv3.AutoSize = True
        Me.btnプロダクトキーv3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnプロダクトキーv3.Location = New System.Drawing.Point(100, 31)
        Me.btnプロダクトキーv3.Name = "btnプロダクトキーv3"
        Me.btnプロダクトキーv3.Size = New System.Drawing.Size(78, 22)
        Me.btnプロダクトキーv3.TabIndex = 6
        Me.btnプロダクトキーv3.Text = "プロダクトキー"
        Me.btnプロダクトキーv3.UseVisualStyleBackColor = True
        '
        'btn名称マスタ
        '
        Me.btn名称マスタ.AutoSize = True
        Me.btn名称マスタ.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn名称マスタ.Location = New System.Drawing.Point(184, 31)
        Me.btn名称マスタ.Name = "btn名称マスタ"
        Me.btn名称マスタ.Size = New System.Drawing.Size(65, 22)
        Me.btn名称マスタ.TabIndex = 3
        Me.btn名称マスタ.Text = "名称マスタ"
        Me.btn名称マスタ.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.FlowLayoutPanel3)
        Me.GroupBox1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 237)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 20, 3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(360, 95)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "データ参照"
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.Controls.Add(Me.btn情報照会)
        Me.FlowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(3, 15)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(354, 77)
        Me.FlowLayoutPanel3.TabIndex = 7
        '
        'btn情報照会
        '
        Me.btn情報照会.AutoSize = True
        Me.btn情報照会.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn情報照会.Location = New System.Drawing.Point(3, 3)
        Me.btn情報照会.Name = "btn情報照会"
        Me.btn情報照会.Size = New System.Drawing.Size(113, 22)
        Me.btn情報照会.TabIndex = 2
        Me.btn情報照会.Text = "ソフトウェア情報照会"
        Me.btn情報照会.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(360, 35)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "ソフトウェア管理システム"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frm00_メニュー
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 362)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.grpデータ読込)
        Me.MinimumSize = New System.Drawing.Size(400, 400)
        Me.Name = "frm00_メニュー"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "メニュー"
        Me.grpデータ読込.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.FlowLayoutPanel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grpデータ読込 As GroupBox
    Friend WithEvents btnMSDNxml読取 As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnサブスクリプション As Button
    Friend WithEvents btnソフトウェア As Button
    Friend WithEvents btnメーカーマスタ As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btn情報照会 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btn名称マスタ As Button
    Friend WithEvents btn社員マスタ As Button
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel3 As FlowLayoutPanel
    Friend WithEvents btnプロダクトキーv3 As Button
End Class
