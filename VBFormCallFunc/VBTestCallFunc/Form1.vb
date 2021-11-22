Imports CVTestCallFunc

Public Class Form1

    Private ccvtest As CVTestCallFunc.TestCallForm1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ccvtest = New CVTestCallFunc.TestCallForm1()
        ccvtest.Button1_Click(sender, e)
    End Sub
End Class
