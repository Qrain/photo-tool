<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 整理ツール１
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
        Me.btn整理対象参照 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chk再帰的 = New System.Windows.Forms.CheckBox()
        Me.tbx撮影日不明Prefix = New System.Windows.Forms.TextBox()
        Me.chk複製する = New System.Windows.Forms.CheckBox()
        Me.grp整理 = New System.Windows.Forms.GroupBox()
        Me.chk不明分類 = New System.Windows.Forms.CheckBox()
        Me.chkリネームしない = New System.Windows.Forms.CheckBox()
        Me.cbx整理方法 = New System.Windows.Forms.ComboBox()
        Me.chk整理する = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pgb進捗 = New System.Windows.Forms.ProgressBar()
        Me.btn終了 = New System.Windows.Forms.Button()
        Me.btn整理開始 = New System.Windows.Forms.Button()
        Me.grp複製設定 = New System.Windows.Forms.GroupBox()
        Me.rbt任意場所 = New System.Windows.Forms.RadioButton()
        Me.rbt同一フォルダ = New System.Windows.Forms.RadioButton()
        Me.lbl複製先 = New System.Windows.Forms.Label()
        Me.btn複製先参照 = New System.Windows.Forms.Button()
        Me.tbx複製先 = New System.Windows.Forms.TextBox()
        Me.fbd対象フォルダ = New System.Windows.Forms.FolderBrowserDialog()
        Me.tbx整理対象 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grp重複除去設定 = New System.Windows.Forms.GroupBox()
        Me.rbt重複判定低速 = New System.Windows.Forms.RadioButton()
        Me.rbt重複判定高速 = New System.Windows.Forms.RadioButton()
        Me.chk重複画像除去 = New System.Windows.Forms.CheckBox()
        Me.grp整理.SuspendLayout()
        Me.grp複製設定.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grp重複除去設定.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn整理対象参照
        '
        Me.btn整理対象参照.AutoSize = True
        Me.btn整理対象参照.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn整理対象参照.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn整理対象参照.Location = New System.Drawing.Point(463, 20)
        Me.btn整理対象参照.Name = "btn整理対象参照"
        Me.btn整理対象参照.Size = New System.Drawing.Size(41, 25)
        Me.btn整理対象参照.TabIndex = 2
        Me.btn整理対象参照.Text = "参照"
        Me.btn整理対象参照.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(91, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "整理対象"
        '
        'chk再帰的
        '
        Me.chk再帰的.AutoSize = True
        Me.chk再帰的.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chk再帰的.Location = New System.Drawing.Point(38, 62)
        Me.chk再帰的.Name = "chk再帰的"
        Me.chk再帰的.Size = New System.Drawing.Size(120, 19)
        Me.chk再帰的.TabIndex = 14
        Me.chk再帰的.Text = "サブフォルダも含める"
        Me.chk再帰的.UseVisualStyleBackColor = True
        '
        'tbx撮影日不明Prefix
        '
        Me.tbx撮影日不明Prefix.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tbx撮影日不明Prefix.Location = New System.Drawing.Point(322, 79)
        Me.tbx撮影日不明Prefix.Name = "tbx撮影日不明Prefix"
        Me.tbx撮影日不明Prefix.Size = New System.Drawing.Size(182, 23)
        Me.tbx撮影日不明Prefix.TabIndex = 8
        '
        'chk複製する
        '
        Me.chk複製する.AutoSize = True
        Me.chk複製する.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chk複製する.Location = New System.Drawing.Point(38, 280)
        Me.chk複製する.Name = "chk複製する"
        Me.chk複製する.Size = New System.Drawing.Size(113, 19)
        Me.chk複製する.TabIndex = 10
        Me.chk複製する.Text = "フォルダを複製する"
        Me.chk複製する.UseVisualStyleBackColor = True
        '
        'grp整理
        '
        Me.grp整理.Controls.Add(Me.chk不明分類)
        Me.grp整理.Controls.Add(Me.chkリネームしない)
        Me.grp整理.Controls.Add(Me.cbx整理方法)
        Me.grp整理.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.grp整理.Location = New System.Drawing.Point(67, 218)
        Me.grp整理.Name = "grp整理"
        Me.grp整理.Size = New System.Drawing.Size(450, 56)
        Me.grp整理.TabIndex = 18
        Me.grp整理.TabStop = False
        Me.grp整理.Text = "フォルダ整理設定"
        '
        'chk不明分類
        '
        Me.chk不明分類.AutoSize = True
        Me.chk不明分類.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chk不明分類.Location = New System.Drawing.Point(265, 24)
        Me.chk不明分類.Name = "chk不明分類"
        Me.chk不明分類.Size = New System.Drawing.Size(179, 18)
        Me.chk不明分類.TabIndex = 16
        Me.chk不明分類.Text = "撮影日不明画像もフォルダ分けする"
        Me.chk不明分類.UseVisualStyleBackColor = True
        '
        'chkリネームしない
        '
        Me.chkリネームしない.AutoSize = True
        Me.chkリネームしない.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkリネームしない.Location = New System.Drawing.Point(174, 24)
        Me.chkリネームしない.Name = "chkリネームしない"
        Me.chkリネームしない.Size = New System.Drawing.Size(85, 18)
        Me.chkリネームしない.TabIndex = 17
        Me.chkリネームしない.Text = "リネームしない"
        Me.chkリネームしない.UseVisualStyleBackColor = True
        '
        'cbx整理方法
        '
        Me.cbx整理方法.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cbx整理方法.FormattingEnabled = True
        Me.cbx整理方法.Location = New System.Drawing.Point(10, 22)
        Me.cbx整理方法.Name = "cbx整理方法"
        Me.cbx整理方法.Size = New System.Drawing.Size(158, 23)
        Me.cbx整理方法.TabIndex = 13
        '
        'chk整理する
        '
        Me.chk整理する.AutoSize = True
        Me.chk整理する.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chk整理する.Location = New System.Drawing.Point(38, 193)
        Me.chk整理する.Name = "chk整理する"
        Me.chk整理する.Size = New System.Drawing.Size(113, 19)
        Me.chk整理する.TabIndex = 11
        Me.chk整理する.Text = "フォルダを整理する"
        Me.chk整理する.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(319, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(185, 14)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "撮影日不明画像のファイル名プレフィックス"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pgb進捗
        '
        Me.pgb進捗.Location = New System.Drawing.Point(67, 415)
        Me.pgb進捗.Margin = New System.Windows.Forms.Padding(8)
        Me.pgb進捗.Name = "pgb進捗"
        Me.pgb進捗.Size = New System.Drawing.Size(335, 23)
        Me.pgb進捗.Step = 1
        Me.pgb進捗.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pgb進捗.TabIndex = 4
        '
        'btn終了
        '
        Me.btn終了.AutoSize = True
        Me.btn終了.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn終了.Font = New System.Drawing.Font("Meiryo UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btn終了.Location = New System.Drawing.Point(468, 412)
        Me.btn終了.Name = "btn終了"
        Me.btn終了.Size = New System.Drawing.Size(49, 29)
        Me.btn終了.TabIndex = 5
        Me.btn終了.Text = "終了"
        Me.btn終了.UseVisualStyleBackColor = True
        '
        'btn整理開始
        '
        Me.btn整理開始.AutoSize = True
        Me.btn整理開始.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn整理開始.Font = New System.Drawing.Font("Meiryo UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btn整理開始.Location = New System.Drawing.Point(413, 412)
        Me.btn整理開始.Name = "btn整理開始"
        Me.btn整理開始.Size = New System.Drawing.Size(49, 29)
        Me.btn整理開始.TabIndex = 3
        Me.btn整理開始.Text = "開始"
        Me.btn整理開始.UseVisualStyleBackColor = True
        '
        'grp複製設定
        '
        Me.grp複製設定.Controls.Add(Me.rbt任意場所)
        Me.grp複製設定.Controls.Add(Me.rbt同一フォルダ)
        Me.grp複製設定.Controls.Add(Me.lbl複製先)
        Me.grp複製設定.Controls.Add(Me.btn複製先参照)
        Me.grp複製設定.Controls.Add(Me.tbx複製先)
        Me.grp複製設定.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.grp複製設定.Location = New System.Drawing.Point(67, 305)
        Me.grp複製設定.Name = "grp複製設定"
        Me.grp複製設定.Size = New System.Drawing.Size(450, 96)
        Me.grp複製設定.TabIndex = 8
        Me.grp複製設定.TabStop = False
        Me.grp複製設定.Text = "複製設定"
        '
        'rbt任意場所
        '
        Me.rbt任意場所.AutoSize = True
        Me.rbt任意場所.Location = New System.Drawing.Point(10, 40)
        Me.rbt任意場所.Name = "rbt任意場所"
        Me.rbt任意場所.Size = New System.Drawing.Size(116, 19)
        Me.rbt任意場所.TabIndex = 7
        Me.rbt任意場所.TabStop = True
        Me.rbt任意場所.Text = "任意の場所に複製"
        Me.rbt任意場所.UseVisualStyleBackColor = True
        '
        'rbt同一フォルダ
        '
        Me.rbt同一フォルダ.AutoSize = True
        Me.rbt同一フォルダ.Location = New System.Drawing.Point(10, 22)
        Me.rbt同一フォルダ.Name = "rbt同一フォルダ"
        Me.rbt同一フォルダ.Size = New System.Drawing.Size(194, 19)
        Me.rbt同一フォルダ.TabIndex = 6
        Me.rbt同一フォルダ.TabStop = True
        Me.rbt同一フォルダ.Text = "整理対象フォルダと同じ場所に複製"
        Me.rbt同一フォルダ.UseVisualStyleBackColor = True
        '
        'lbl複製先
        '
        Me.lbl複製先.AutoSize = True
        Me.lbl複製先.Location = New System.Drawing.Point(22, 70)
        Me.lbl複製先.Name = "lbl複製先"
        Me.lbl複製先.Size = New System.Drawing.Size(62, 15)
        Me.lbl複製先.TabIndex = 3
        Me.lbl複製先.Text = "複製先パス"
        '
        'btn複製先参照
        '
        Me.btn複製先参照.AutoSize = True
        Me.btn複製先参照.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn複製先参照.Location = New System.Drawing.Point(396, 65)
        Me.btn複製先参照.Name = "btn複製先参照"
        Me.btn複製先参照.Size = New System.Drawing.Size(41, 25)
        Me.btn複製先参照.TabIndex = 2
        Me.btn複製先参照.Text = "参照"
        Me.btn複製先参照.UseVisualStyleBackColor = True
        '
        'tbx複製先
        '
        Me.tbx複製先.Location = New System.Drawing.Point(90, 67)
        Me.tbx複製先.Name = "tbx複製先"
        Me.tbx複製先.Size = New System.Drawing.Size(300, 23)
        Me.tbx複製先.TabIndex = 1
        '
        'tbx整理対象
        '
        Me.tbx整理対象.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tbx整理対象.Location = New System.Drawing.Point(157, 22)
        Me.tbx整理対象.Name = "tbx整理対象"
        Me.tbx整理対象.Size = New System.Drawing.Size(300, 23)
        Me.tbx整理対象.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grp重複除去設定)
        Me.Panel1.Controls.Add(Me.chk重複画像除去)
        Me.Panel1.Controls.Add(Me.tbx撮影日不明Prefix)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.btn整理開始)
        Me.Panel1.Controls.Add(Me.btn終了)
        Me.Panel1.Controls.Add(Me.chk再帰的)
        Me.Panel1.Controls.Add(Me.btn整理対象参照)
        Me.Panel1.Controls.Add(Me.grp複製設定)
        Me.Panel1.Controls.Add(Me.tbx整理対象)
        Me.Panel1.Controls.Add(Me.grp整理)
        Me.Panel1.Controls.Add(Me.chk整理する)
        Me.Panel1.Controls.Add(Me.chk複製する)
        Me.Panel1.Controls.Add(Me.pgb進捗)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(584, 462)
        Me.Panel1.TabIndex = 19
        '
        'grp重複除去設定
        '
        Me.grp重複除去設定.Controls.Add(Me.rbt重複判定低速)
        Me.grp重複除去設定.Controls.Add(Me.rbt重複判定高速)
        Me.grp重複除去設定.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.grp重複除去設定.Location = New System.Drawing.Point(67, 140)
        Me.grp重複除去設定.Name = "grp重複除去設定"
        Me.grp重複除去設定.Size = New System.Drawing.Size(450, 47)
        Me.grp重複除去設定.TabIndex = 19
        Me.grp重複除去設定.TabStop = False
        Me.grp重複除去設定.Text = "重複除去設定"
        '
        'rbt重複判定低速
        '
        Me.rbt重複判定低速.AutoSize = True
        Me.rbt重複判定低速.Location = New System.Drawing.Point(198, 22)
        Me.rbt重複判定低速.Name = "rbt重複判定低速"
        Me.rbt重複判定低速.Size = New System.Drawing.Size(189, 19)
        Me.rbt重複判定低速.TabIndex = 19
        Me.rbt重複判定低速.TabStop = True
        Me.rbt重複判定低速.Text = "ピクセルデータによる判定（低速）"
        Me.rbt重複判定低速.UseVisualStyleBackColor = True
        '
        'rbt重複判定高速
        '
        Me.rbt重複判定高速.AutoSize = True
        Me.rbt重複判定高速.Location = New System.Drawing.Point(10, 22)
        Me.rbt重複判定高速.Name = "rbt重複判定高速"
        Me.rbt重複判定高速.Size = New System.Drawing.Size(182, 19)
        Me.rbt重複判定高速.TabIndex = 18
        Me.rbt重複判定高速.TabStop = True
        Me.rbt重複判定高速.Text = "画像ファイルによる判定（高速）"
        Me.rbt重複判定高速.UseVisualStyleBackColor = True
        '
        'chk重複画像除去
        '
        Me.chk重複画像除去.AutoSize = True
        Me.chk重複画像除去.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chk重複画像除去.Location = New System.Drawing.Point(38, 116)
        Me.chk重複画像除去.Name = "chk重複画像除去"
        Me.chk重複画像除去.Size = New System.Drawing.Size(126, 18)
        Me.chk重複画像除去.TabIndex = 18
        Me.chk重複画像除去.Text = "画像の重複を除去する"
        Me.chk重複画像除去.UseVisualStyleBackColor = True
        '
        '整理ツール１
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 462)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "整理ツール１"
        Me.Text = "写真整理ツール v1"
        Me.grp整理.ResumeLayout(False)
        Me.grp整理.PerformLayout()
        Me.grp複製設定.ResumeLayout(False)
        Me.grp複製設定.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grp重複除去設定.ResumeLayout(False)
        Me.grp重複除去設定.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn整理対象参照 As System.Windows.Forms.Button
    Friend WithEvents btn整理開始 As System.Windows.Forms.Button
    Friend WithEvents pgb進捗 As System.Windows.Forms.ProgressBar
    Friend WithEvents btn終了 As System.Windows.Forms.Button
    Friend WithEvents fbd対象フォルダ As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents grp複製設定 As System.Windows.Forms.GroupBox
    Friend WithEvents rbt任意場所 As System.Windows.Forms.RadioButton
    Friend WithEvents rbt同一フォルダ As System.Windows.Forms.RadioButton
    Friend WithEvents lbl複製先 As System.Windows.Forms.Label
    Friend WithEvents btn複製先参照 As System.Windows.Forms.Button
    Friend WithEvents tbx複製先 As System.Windows.Forms.TextBox
    Friend WithEvents chk複製する As System.Windows.Forms.CheckBox
    Friend WithEvents chk整理する As System.Windows.Forms.CheckBox
    Friend WithEvents cbx整理方法 As System.Windows.Forms.ComboBox
    Friend WithEvents chk再帰的 As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbx撮影日不明Prefix As System.Windows.Forms.TextBox
    Friend WithEvents chk不明分類 As System.Windows.Forms.CheckBox
    Friend WithEvents chkリネームしない As System.Windows.Forms.CheckBox
    Friend WithEvents grp整理 As System.Windows.Forms.GroupBox
    Friend WithEvents tbx整理対象 As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents chk重複画像除去 As System.Windows.Forms.CheckBox
    Friend WithEvents grp重複除去設定 As System.Windows.Forms.GroupBox
    Friend WithEvents rbt重複判定低速 As System.Windows.Forms.RadioButton
    Friend WithEvents rbt重複判定高速 As System.Windows.Forms.RadioButton

End Class
