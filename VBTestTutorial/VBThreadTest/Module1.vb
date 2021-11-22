


Module Module1

    Sub Main()
        Console.WriteLine("start")
        Dim th As New ThreadTest()
        th.ThreadStart()
        System.Threading.Thread.Sleep(1000)

        th.ThreadStart()
        System.Threading.Thread.Sleep(1000)

        th.ThreadStart()
        System.Threading.Thread.Sleep(1000)

        th.ThreadStart()
        System.Threading.Thread.Sleep(1000)

        Console.WriteLine("end")
    End Sub

End Module
