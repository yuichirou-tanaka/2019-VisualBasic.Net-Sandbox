Imports System.Threading
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Enabled = False ' いったんボタンを無効化
        Dim t As Thread = New Thread(New ThreadStart(Sub()
                                                         LongTask()
                                                     End Sub))
        t.IsBackground = True
        t.Start()
    End Sub

    Private Delegate Sub UpdateProgressBarDelegate(val As Integer)
    Private Sub UpdateProgressBar(val As Integer)
        ProgressBar1.Value = val
        If (val = 100) Then Button1.Enabled = True
    End Sub

    Sub LongTask()
        Dim i As Integer = 0
        For i = 0 To 100 - 1
            System.Threading.Thread.Sleep(100)
            BeginInvoke(New UpdateProgressBarDelegate(AddressOf UpdateProgressBar), i)
        Next
    End Sub
End Class
