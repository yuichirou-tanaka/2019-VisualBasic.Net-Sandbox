Public Class Form1

    Private DeleteRowIndex As Integer = -1
    Private Sub SakujoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SakujoToolStripMenuItem.Click
        If DeleteRowIndex = -1 Then Return
        If DataGridView1.RowCount <= 1 Then Return
        If DataGridView1.RowCount - 1 = DeleteRowIndex Then Return

        DataGridView1.Rows.RemoveAt(DeleteRowIndex)
        DeleteRowIndex = -1
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        If (e.RowIndex < 0) Then Return
        If (e.ColumnIndex < 0) Then Return

        ' 右ボタンクリック判定
        If e.Button = MouseButtons.Right Then
            DataGridView1.ClearSelection()
            Dim cell As DataGridViewCell = DataGridView1(e.ColumnIndex, e.RowIndex)
            DeleteRowIndex = e.RowIndex
            cell.Selected = True
            Dim p As System.Drawing.Point = System.Windows.Forms.Cursor.Position
            Me.ContextMenuStrip1.Show(p)
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim sw As New System.IO.StreamWriter(".\test.txt", False, System.Text.Encoding.GetEncoding("shift_jis"))
        sw.Write("taest")
        sw.Close()
    End Sub
End Class
