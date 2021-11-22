Public Class Taguc

    Private Sub Taguc_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Tag = "Tet"
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Label1.Text = Tag
    End Sub
End Class
