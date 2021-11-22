Public Class Form1
    'Private ans As Integer = 0

    Private Sub BackgroundWorker1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        'ans = 0
        Dim percent As Integer = 0
        Dim iloop As Integer = 200
        Dim i As Integer
        For i = 0 To iloop - 1
            percent = CInt((CDbl(i) / CDbl(iloop)) * 100.0F)

            'For j As Integer = 0 To 1000 - 1
            'ans = ans + i + i * j
            'Next

            System.Threading.Thread.Sleep(1)
            BackgroundWorker1.ReportProgress(percent)
        Next

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As System.Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As System.Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

    End Sub
End Class
