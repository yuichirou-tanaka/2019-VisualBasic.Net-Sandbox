Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' 列ヘッダの背景色の変更
        'dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Green
        'dgv.RowHeadersDefaultCellStyle.BackColor = Color.Green
        
        ' Visualスタイルを使用しない
        'dgv.EnableHeadersVisualStyles = False

        dgv.Rows.Add("test")
        dgv.Rows.Add("test2")
    End Sub
End Class
