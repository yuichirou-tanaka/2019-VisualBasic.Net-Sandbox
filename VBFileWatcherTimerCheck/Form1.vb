Public Class Form1
    Private fw As FileWatcherTimerCheck
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim appPath As String = My.Application.Info.DirectoryPath
        fw = New FileWatcherTimerCheck(Me, appPath & "/fwtarget/", 30, True)
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        fw.EnableWatch()

    End Sub
End Class
