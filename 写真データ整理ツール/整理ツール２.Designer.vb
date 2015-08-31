<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 整理ツール２
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
        Me.fbd = New System.Windows.Forms.FolderBrowserDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chk日付合成 = New System.Windows.Forms.CheckBox()
        Me.tbx撮影日書式 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl進捗 = New System.Windows.Forms.Label()
        Me.chk重複画像除去 = New System.Windows.Forms.CheckBox()
        Me.tbx撮影日無し接頭字 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn整理開始 = New System.Windows.Forms.Button()
        Me.btn終了 = New System.Windows.Forms.Button()
        Me.chk再帰的 = New System.Windows.Forms.CheckBox()
        Me.btn整理対象参照 = New System.Windows.Forms.Button()
        Me.grp複製設定 = New System.Windows.Forms.GroupBox()
        Me.rbt任意場所 = New System.Windows.Forms.RadioButton()
        Me.rbt同一フォルダ = New System.Windows.Forms.RadioButton()
        Me.lbl出力先 = New System.Windows.Forms.Label()
        Me.btn出力先参照 = New System.Windows.Forms.Button()
        Me.tbx出力先 = New System.Windows.Forms.TextBox()
        Me.tbx整理対象 = New System.Windows.Forms.TextBox()
        Me.grp整理 = New System.Windows.Forms.GroupBox()
        Me.chk不明分類 = New System.Windows.Forms.CheckBox()
        Me.chkリネームしない = New System.Windows.Forms.CheckBox()
        Me.cbx整理方法 = New System.Windows.Forms.ComboBox()
        Me.chk整理する = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pgb進捗 = New System.Windows.Forms.ProgressBar()
        Me.Panel1.SuspendLayout()
        Me.grp複製設定.SuspendLayout()
        Me.grp整理.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.chk日付合成)
        Me.Panel1.Controls.Add(Me.tbx撮影日書式)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lbl進捗)
        Me.Panel1.Controls.Add(Me.chk重複画像除去)
        Me.Panel1.Controls.Add(Me.tbx撮影日無し接頭字)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.btn整理開始)
        Me.Panel1.Controls.Add(Me.btn終了)
        Me.Panel1.Controls.Add(Me.chk再帰的)
        Me.Panel1.Controls.Add(Me.btn整理対象参照)
        Me.Panel1.Controls.Add(Me.grp複製設定)
        Me.Panel1.Controls.Add(Me.tbx整理対象)
        Me.Panel1.Controls.Add(Me.grp整理)
        Me.Panel1.Controls.Add(Me.chk整理する)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.pgb進捗)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(584, 442)
        Me.Panel1.TabIndex = 20
        '
        'chk日付合成
        '
        Me.chk日付合成.AutoSize = True
        Me.chk日付合成.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chk日付合成.Location = New System.Drawing.Point(38, 328)
        Me.chk日付合成.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.chk日付合成.Name = "chk日付合成"
        Me.chk日付合成.Size = New System.Drawing.Size(160, 19)
        Me.chk日付合成.TabIndex = 24
        Me.chk日付合成.Text = "撮影日時を画像に埋め込む"
        Me.chk日付合成.UseVisualStyleBackColor = True
        '
        'tbx撮影日書式
        '
        Me.tbx撮影日書式.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tbx撮影日書式.Location = New System.Drawing.Point(335, 294)
        Me.tbx撮影日書式.Name = "tbx撮影日書式"
        Me.tbx撮影日書式.Size = New System.Drawing.Size(182, 23)
        Me.tbx撮影日書式.TabIndex = 22
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(332, 277)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(145, 14)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "ファイル名リネーム時の日付形式"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl進捗
        '
        Me.lbl進捗.AutoSize = True
        Me.lbl進捗.BackColor = System.Drawing.SystemColors.Control
        Me.lbl進捗.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl進捗.Location = New System.Drawing.Point(212, 367)
        Me.lbl進捗.Name = "lbl進捗"
        Me.lbl進捗.Size = New System.Drawing.Size(45, 15)
        Me.lbl進捗.TabIndex = 21
        Me.lbl進捗.Text = "Label3"
        Me.lbl進捗.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chk重複画像除去
        '
        Me.chk重複画像除去.AutoSize = True
        Me.chk重複画像除去.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chk重複画像除去.Location = New System.Drawing.Point(38, 265)
        Me.chk重複画像除去.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.chk重複画像除去.Name = "chk重複画像除去"
        Me.chk重複画像除去.Size = New System.Drawing.Size(126, 18)
        Me.chk重複画像除去.TabIndex = 18
        Me.chk重複画像除去.Text = "画像の重複を除去する"
        Me.chk重複画像除去.UseVisualStyleBackColor = True
        '
        'tbx撮影日無し接頭字
        '
        Me.tbx撮影日無し接頭字.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tbx撮影日無し接頭字.Location = New System.Drawing.Point(335, 339)
        Me.tbx撮影日無し接頭字.Name = "tbx撮影日無し接頭字"
        Me.tbx撮影日無し接頭字.Size = New System.Drawing.Size(182, 23)
        Me.tbx撮影日無し接頭字.TabIndex = 8
        Me.tbx撮影日無し接頭字.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(332, 322)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(193, 14)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "整理情報無し画像のファイル名プレフィックス"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label2.Visible = False
        '
        'btn整理開始
        '
        Me.btn整理開始.AutoSize = True
        Me.btn整理開始.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn整理開始.Font = New System.Drawing.Font("Meiryo UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btn整理開始.Location = New System.Drawing.Point(413, 385)
        Me.btn整理開始.Name = "btn整理開始"
        Me.btn整理開始.Size = New System.Drawing.Size(49, 29)
        Me.btn整理開始.TabIndex = 3
        Me.btn整理開始.Text = "開始"
        Me.btn整理開始.UseVisualStyleBackColor = True
        '
        'btn終了
        '
        Me.btn終了.AutoSize = True
        Me.btn終了.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn終了.Font = New System.Drawing.Font("Meiryo UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btn終了.Location = New System.Drawing.Point(468, 385)
        Me.btn終了.Name = "btn終了"
        Me.btn終了.Size = New System.Drawing.Size(49, 29)
        Me.btn終了.TabIndex = 5
        Me.btn終了.Text = "終了"
        Me.btn終了.UseVisualStyleBackColor = True
        '
        'chk再帰的
        '
        Me.chk再帰的.AutoSize = True
        Me.chk再帰的.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chk再帰的.Location = New System.Drawing.Point(38, 296)
        Me.chk再帰的.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.chk再帰的.Name = "chk再帰的"
        Me.chk再帰的.Size = New System.Drawing.Size(177, 19)
        Me.chk再帰的.TabIndex = 14
        Me.chk再帰的.Text = "サブフォルダも整理対象に含める"
        Me.chk再帰的.UseVisualStyleBackColor = True
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
        'grp複製設定
        '
        Me.grp複製設定.Controls.Add(Me.rbt任意場所)
        Me.grp複製設定.Controls.Add(Me.rbt同一フォルダ)
        Me.grp複製設定.Controls.Add(Me.lbl出力先)
        Me.grp複製設定.Controls.Add(Me.btn出力先参照)
        Me.grp複製設定.Controls.Add(Me.tbx出力先)
        Me.grp複製設定.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.grp複製設定.Location = New System.Drawing.Point(67, 62)
        Me.grp複製設定.Name = "grp複製設定"
        Me.grp複製設定.Size = New System.Drawing.Size(450, 96)
        Me.grp複製設定.TabIndex = 8
        Me.grp複製設定.TabStop = False
        Me.grp複製設定.Text = "整理済み画像の出力先設定"
        '
        'rbt任意場所
        '
        Me.rbt任意場所.AutoSize = True
        Me.rbt任意場所.Location = New System.Drawing.Point(10, 40)
        Me.rbt任意場所.Name = "rbt任意場所"
        Me.rbt任意場所.Size = New System.Drawing.Size(83, 19)
        Me.rbt任意場所.TabIndex = 7
        Me.rbt任意場所.Text = "任意の場所"
        Me.rbt任意場所.UseVisualStyleBackColor = True
        '
        'rbt同一フォルダ
        '
        Me.rbt同一フォルダ.AutoSize = True
        Me.rbt同一フォルダ.Checked = True
        Me.rbt同一フォルダ.Location = New System.Drawing.Point(10, 22)
        Me.rbt同一フォルダ.Name = "rbt同一フォルダ"
        Me.rbt同一フォルダ.Size = New System.Drawing.Size(126, 19)
        Me.rbt同一フォルダ.TabIndex = 6
        Me.rbt同一フォルダ.TabStop = True
        Me.rbt同一フォルダ.Text = "整理対象と同じ場所"
        Me.rbt同一フォルダ.UseVisualStyleBackColor = True
        '
        'lbl出力先
        '
        Me.lbl出力先.AutoSize = True
        Me.lbl出力先.Location = New System.Drawing.Point(41, 70)
        Me.lbl出力先.Name = "lbl出力先"
        Me.lbl出力先.Size = New System.Drawing.Size(43, 15)
        Me.lbl出力先.TabIndex = 3
        Me.lbl出力先.Text = "出力先"
        '
        'btn出力先参照
        '
        Me.btn出力先参照.AutoSize = True
        Me.btn出力先参照.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn出力先参照.Location = New System.Drawing.Point(396, 65)
        Me.btn出力先参照.Name = "btn出力先参照"
        Me.btn出力先参照.Size = New System.Drawing.Size(41, 25)
        Me.btn出力先参照.TabIndex = 2
        Me.btn出力先参照.Text = "参照"
        Me.btn出力先参照.UseVisualStyleBackColor = True
        '
        'tbx出力先
        '
        Me.tbx出力先.Location = New System.Drawing.Point(90, 67)
        Me.tbx出力先.Name = "tbx出力先"
        Me.tbx出力先.Size = New System.Drawing.Size(300, 23)
        Me.tbx出力先.TabIndex = 1
        '
        'tbx整理対象
        '
        Me.tbx整理対象.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tbx整理対象.Location = New System.Drawing.Point(157, 22)
        Me.tbx整理対象.Name = "tbx整理対象"
        Me.tbx整理対象.Size = New System.Drawing.Size(300, 23)
        Me.tbx整理対象.TabIndex = 0
        '
        'grp整理
        '
        Me.grp整理.Controls.Add(Me.chk不明分類)
        Me.grp整理.Controls.Add(Me.chkリネームしない)
        Me.grp整理.Controls.Add(Me.cbx整理方法)
        Me.grp整理.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.grp整理.Location = New System.Drawing.Point(67, 196)
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
        Me.chk不明分類.Size = New System.Drawing.Size(148, 18)
        Me.chk不明分類.TabIndex = 16
        Me.chk不明分類.Text = "整理情報不明でも整理する"
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
        Me.chk整理する.Location = New System.Drawing.Point(38, 171)
        Me.chk整理する.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.chk整理する.Name = "chk整理する"
        Me.chk整理する.Size = New System.Drawing.Size(113, 19)
        Me.chk整理する.TabIndex = 11
        Me.chk整理する.Text = "フォルダを整理する"
        Me.chk整理する.UseVisualStyleBackColor = True
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
        'pgb進捗
        '
        Me.pgb進捗.Location = New System.Drawing.Point(67, 388)
        Me.pgb進捗.Margin = New System.Windows.Forms.Padding(8)
        Me.pgb進捗.Name = "pgb進捗"
        Me.pgb進捗.Size = New System.Drawing.Size(335, 23)
        Me.pgb進捗.Step = 1
        Me.pgb進捗.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pgb進捗.TabIndex = 4
        '
        '整理ツール２
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 442)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "整理ツール２"
        Me.Text = "写真整理ツール v2"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grp複製設定.ResumeLayout(False)
        Me.grp複製設定.PerformLayout()
        Me.grp整理.ResumeLayout(False)
        Me.grp整理.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fbd As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents chk重複画像除去 As System.Windows.Forms.CheckBox
    Friend WithEvents tbx撮影日無し接頭字 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn整理開始 As System.Windows.Forms.Button
    Friend WithEvents btn終了 As System.Windows.Forms.Button
    Friend WithEvents chk再帰的 As System.Windows.Forms.CheckBox
    Friend WithEvents btn整理対象参照 As System.Windows.Forms.Button
    Friend WithEvents grp複製設定 As System.Windows.Forms.GroupBox
    Friend WithEvents rbt任意場所 As System.Windows.Forms.RadioButton
    Friend WithEvents rbt同一フォルダ As System.Windows.Forms.RadioButton
    Friend WithEvents lbl出力先 As System.Windows.Forms.Label
    Friend WithEvents btn出力先参照 As System.Windows.Forms.Button
    Friend WithEvents tbx出力先 As System.Windows.Forms.TextBox
    Friend WithEvents tbx整理対象 As System.Windows.Forms.TextBox
    Friend WithEvents grp整理 As System.Windows.Forms.GroupBox
    Friend WithEvents chk不明分類 As System.Windows.Forms.CheckBox
    Friend WithEvents chkリネームしない As System.Windows.Forms.CheckBox
    Friend WithEvents cbx整理方法 As System.Windows.Forms.ComboBox
    Friend WithEvents chk整理する As System.Windows.Forms.CheckBox
    Friend WithEvents pgb進捗 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl進捗 As System.Windows.Forms.Label
    Friend WithEvents tbx撮影日書式 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chk日付合成 As System.Windows.Forms.CheckBox
End Class
