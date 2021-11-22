Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim timing() As String = {100, 200, 300}

        For i As Integer = 0 To UBound(timing)
            Dim dtime As Double = CDbl(timing(i))
            ListView1.Items.Add(New ListViewItem({i + 1, dtime.ToString("0.000")}))
        Next
    End Sub
End Class
