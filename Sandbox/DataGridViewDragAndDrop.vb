Imports System.Windows.Forms

Public Class DataGridViewDragAndDrop

    Private Sub DataGridViewDragAndDrop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 初期設定
        dgvLeft.Rows.Add("参照", "\\192.168.88.211\_Project\KEN_Corp\madoriai\110519\aaa.xps")
        dgvLeft.Rows.Add("参照", "")
    End Sub

    Private Sub dgvLeft_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLeft.CellClick
        ' ボタン列
        If e.ColumnIndex = 0 Then
            If ofd.ShowDialog() = DialogResult.OK Then
                ' 選択したファイルをグリッドのファイルパス列に設定
                dgvLeft(1, e.RowIndex).Value = ofd.FileName
                dgvLeft.Rows.Add("参照", "")
            End If
        End If
    End Sub

    Private Sub dgvLeft_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvLeft.CellMouseDown
        ' ファイル名列のセルがクリックされたとき
        If e.Button = MouseButtons.Left AndAlso e.ColumnIndex = 1 Then
            ' 複数選択において有効なファイルパスを抽出
            Dim files =
                From c In dgvLeft.SelectedCells.Cast(Of DataGridViewCell)
                Where IO.File.Exists(c.Value)
                Select CStr(c.Value)
            '有効なファイルパスがなければリターン
            If files.Count = 0 Then
                Return
            End If
            ' DataObjectを生成
            Dim data As New DataObject(DataFormats.FileDrop, files.ToArray)
            ' ドラッグ＆ドロップ準備 → 開始
            dgvLeft.DoDragDrop(data, DragDropEffects.Copy)
        End If
    End Sub

End Class