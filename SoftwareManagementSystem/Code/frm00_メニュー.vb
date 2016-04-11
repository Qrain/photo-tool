Imports System.Text

Public Class frm00_メニュー

    Public Sub New()
        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()
        '
        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        '
        ' 名称マスタ情報をgs名称に読み込みます
        Reload名称マスタ()

    End Sub

    Private Sub btnMSDNxml読取_Click(sender As Object, e As EventArgs) Handles btnMSDNxml読取.Click
        CheckAndOpenForm(New frm11_データインポート)
    End Sub
    Private Sub btn名称マスタ_Click(sender As Object, e As EventArgs) Handles btn名称マスタ.Click
        CheckAndOpenForm(New frm21_名称マスタ保守)
    End Sub
    Private Sub btn社員マスタ_Click(sender As Object, e As EventArgs) Handles btn社員マスタ.Click
        CheckAndOpenForm(New frm22_社員マスタ)
    End Sub
    Private Sub btnメーカーマスタ_Click(sender As Object, e As EventArgs) Handles btnメーカーマスタ.Click
        CheckAndOpenForm(New frm23_メーカー)
    End Sub
    Private Sub btnサブスクリプション_Click(sender As Object, e As EventArgs) Handles btnサブスクリプション.Click
        CheckAndOpenForm(New frm24_サブスクリプション)
    End Sub
    Private Sub btnソフトウェア_Click(sender As Object, e As EventArgs) Handles btnソフトウェア.Click
        CheckAndOpenForm(New frm25_ソフトウェア)
    End Sub
    Private Sub btnプロダクトキーv3_Click(sender As Object, e As EventArgs) Handles btnプロダクトキーv3.Click
        CheckAndOpenForm(New frm26_プロダクトキー登録)
    End Sub
    Private Sub btn情報照会_Click(sender As Object, e As EventArgs) Handles btn情報照会.Click
        CheckAndOpenForm(New frm31_プロダクトキー情報照会)
    End Sub

    Private Sub CheckAndOpenForm(ByVal vfrm As Form)
        If IsOpen(Me, vfrm) Then
            MsgBox("フォーム """ & vfrm.Name & """ は既に起動しています。")
        Else
            vfrm.Show(Me)
        End If
    End Sub


End Class
