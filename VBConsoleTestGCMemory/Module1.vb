
Module Module1

    Sub Main()
        Console.WriteLine(System.GC.GetTotalMemory(False))

        Dim a() As String = New String(1000) {}
        Dim i As Integer
        For i = 0 To 999
            a(i) = New String("A"c, 1000)
        Next
        Console.WriteLine(System.GC.GetTotalMemory(False))

        a = Nothing
        Console.WriteLine(System.GC.GetTotalMemory(False))

        System.GC.Collect()
        Console.WriteLine(System.GC.GetTotalMemory(False))
    End Sub

End Module
