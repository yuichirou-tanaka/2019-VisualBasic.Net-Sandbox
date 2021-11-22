Class TestProcess
    Public p As System.Diagnostics.Process
    Public Sub oper_EngModeClicked()
        p = New System.Diagnostics.Process
        p.StartInfo.FileName = "..\..\..\TestProcessForm\bin\Debug\TestProcessForm.exe"
        p.StartInfo.Arguments = " ""-f test "" -t"
        p.StartInfo.RedirectStandardOutput = True
        p.StartInfo.UseShellExecute = False

        'p.SynchronizingObject = Me

        AddHandler p.Exited, New eventhandler(AddressOf p_Exited)
        p.EnableRaisingEvents = True
        p.Start()
        p.WaitForExit()

    End Sub
    Public Sub p_Exited(ByVal sender As Object, ByVal e As EventArgs)

        Console.WriteLine("exit")

    End Sub

End Class




Module Module1

    Sub Main()
        Dim tp As New TestProcess
        tp.oper_EngModeClicked()

    End Sub

End Module
