Public Class _frmファイル実体登録編集機能
    Private Sub chkDL済_CheckedChanged(sender As Object, e As EventArgs) Handles chkDL済.CheckedChanged

        If chkDL済.Checked Then
            lblMsg.Text = "※ダウンロードしたファイルを参照して下さい↓"
            btn参照.Enabled = True
        Else

            lblMsg.Text = "※ファイル名をて入力して下さい↓"
            btn参照.Enabled = False
        End If

    End Sub



    Private Sub rbt登録_CheckedChanged(sender As Object, e As EventArgs) Handles rbt登録.CheckedChanged

        grp利用識別情報.Enabled = True
        chkDL済.Checked = True
        chkDL済.Enabled = True
    End Sub
    Private Sub rbt更新_CheckedChanged(sender As Object, e As EventArgs) Handles rbt更新.CheckedChanged
        grp利用識別情報.Enabled = False
        ' チェックを外して無効にする
        chkDL済.Checked = False
        chkDL済.Enabled = False
    End Sub
    Private Sub rbt削除_CheckedChanged(sender As Object, e As EventArgs) Handles rbt削除.CheckedChanged
        grp利用識別情報.Enabled = False
        chkDL済.Checked = False
        chkDL済.Enabled = False

    End Sub
End Class