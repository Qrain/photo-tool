Imports System.Text

Public Class frm00_メニュー

    Public Sub New()
        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()
        '
        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        gs分割文字 = GetValue(Of String)("SELECT 名称 FROM M01_名称 WHERE 名称区分='分割文字' AND 名称コード='01'")
        gsSID置換文字列 = GetValue(Of String)("SELECT 名称 FROM M01_名称 WHERE 名称区分='SID-NULL置換文字列' AND 名称コード='01'")

        'Dim p1 = New CbxItem(Nothing, Nothing) '("c2", 1001)
        'Dim p2 = New Pair(Of String, Integer)("c1", 1001)
        'Dim p3 = New Pair(Of String, String)("A", Nothing)
        'Console.WriteLine(p1.Equals(p3))
        'Console.WriteLine(p1)
        'Console.WriteLine(p2.GetHashCode)
        'Console.WriteLine(System.Text.RegularExpressions.Regex.IsMatch("あいう", "^[a-zA-Z]"))
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
    Private Sub btnプロダクトキー_Click(sender As Object, e As EventArgs) Handles btnプロダクトキー.Click
        CheckAndOpenForm(New frm26_プロダクトキー登録)
    End Sub
    Private Sub btn情報照会_Click(sender As Object, e As EventArgs) Handles btn情報照会.Click
        CheckAndOpenForm(New frm31_情報照会)
    End Sub

    Private Sub CheckAndOpenForm(ByVal vfrm As Form)
        If IsOpen(Me, vfrm) Then
            MsgBox("フォーム """ & vfrm.Name & """ は既に起動しています。")
        Else
            vfrm.Show(Me)
        End If
    End Sub


End Class
