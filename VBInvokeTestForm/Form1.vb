Imports System.Threading
Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    End Sub


    Delegate Sub SetFocusDelegate()

    Sub SetFocus()
        If InvokeRequired Then
            ' 別スレッドから呼び出された場合
            Invoke(New SetFocusDelegate(AddressOf SetFocus))
            Return
        End If
        TextBox1.Focus()
    End Sub

    Sub worker()
        SetFocus()
    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim t As New Thread(New ThreadStart(AddressOf worker))
        t.Start()
    End Sub
End Class
