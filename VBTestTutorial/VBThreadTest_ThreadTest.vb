
Public Class ThreadTest

    Private isOnThread As Boolean = False
    Private idcnt As Integer
    Public Sub ThreadStart()

        If isOnThread Then
            Console.WriteLine("別の動作を実行中です")
            Return
        End If

        idcnt = idcnt + 1

        Dim ts As New Threading.ParameterizedThreadStart(AddressOf ThreadStartMethod)
        Dim t As New Threading.Thread(ts)
        t.Start(New Object() {idcnt, "test"})

    End Sub
    Private Sub ThreadStartMethod(ByVal obj() As Object)
        isOnThread = True
        System.Threading.Thread.Sleep(1000)
        Console.WriteLine(obj(0) & ":" & obj(1))
        isOnThread = False
    End Sub


End Class
