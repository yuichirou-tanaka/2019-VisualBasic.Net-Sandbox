Imports System.Threading.Tasks

Public Class Form1
    Private prd As ProgressDialog
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        prd = New ProgressDialog()
        prd.Show()

        System.Threading.Thread.Sleep(1000)
        prd.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Using pst As New ProgressDialogShowTask(Me)
            System.Threading.Thread.Sleep(5000)
            pst.InvokeDisposeDialog(Me)
        End Using

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        For i = 1 To 100
            '0.1秒待機
            System.Threading.Thread.Sleep(100)

            '進捗状況の報告
            BackgroundWorker1.ReportProgress(i)
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ProgressBar1.Minimum = 0
        Me.ProgressBar1.Maximum = 100

        '進捗状況を報告できるようにする
        BackgroundWorker1.WorkerReportsProgress = True

        'バックグラウンド操作の実行を開始する
        'BackgroundWorker1.RunWorkerAsync()
        'BackgroundWorker1.Run()
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        '進捗状況をプログレスバーに表示
        Me.ProgressBar1.Value = e.ProgressPercentage
    End Sub
End Class
