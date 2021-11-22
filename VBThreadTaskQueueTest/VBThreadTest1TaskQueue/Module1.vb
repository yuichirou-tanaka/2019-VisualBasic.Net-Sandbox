Imports System.Threading

Class TasksClass
    Friend StrArg As String
    Friend RetVal As Boolean
    Sub SomeTask()
        ' StrArg フィールドを引数として使用します。
        MsgBox("StrArg =" & StrArg & "")
        RetVal = True ' 戻り引数の戻り値を設定します。
    End Sub
    Sub SomeTask1()
        ' StrArg フィールドを引数として使用します。
        MsgBox("SomeTask1 StrArg =" & StrArg & "")
        RetVal = True ' 戻り引数の戻り値を設定します。
    End Sub
    Sub SomeTask2()
        ' StrArg フィールドを引数として使用します。
        MsgBox("SomeTask2 StrArg =" & StrArg & "")
        RetVal = True ' 戻り引数の戻り値を設定します。
    End Sub
End Class

Class TaskPoolFactory
    Sub DoWork()
        Dim Tasks As New TasksClass()
        Dim Thread1 As New System.Threading.Thread(AddressOf Tasks.SomeTask)
        'Thread1.IsBackground = False
        Tasks.StrArg = "Some Arg"
        Thread1.Start()
        Thread1.Join()
        MsgBox("end" & Tasks.RetVal)

    End Sub

    Sub Worker()
    End Sub
    Sub StartWorker(str As String)
        MsgBox("StartWorker s " & str)
        Dim Tasks As New TasksClass()
        Tasks.StrArg = str
        System.Threading.ThreadPool.QueueUserWorkItem(New Threading.WaitCallback(AddressOf Tasks.SomeTask2))
        ' タスクをキューに入れます。
        MsgBox("StartWorker e " & Tasks.RetVal)
    End Sub

    Sub DoWorkThreadPooling()
        MsgBox("DoWorkThreadPooling s ----")
        StartWorker("test1")
        StartWorker("test2")
        MsgBox("DoWorkThreadPooling e ----")
    End Sub



End Class


Module Module1
    Sub Main()
        Dim Tasks As New TaskPoolFactory()
        'Tasks.DoWork()
        Tasks.DoWorkThreadPooling()
    End Sub
    Sub TestMain()
        'Dim t As New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf DoSomething))
        Dim t As New System.Threading.Thread(AddressOf DoSomething)
        't.IsBackground = True
        t.Start()

        Console.WriteLine("EnterKey")
        Console.ReadLine()
    End Sub
    Private Sub DoSomething()
        Dim i As Long
        For i = 0 To 1000000000

        Next
        Console.WriteLine("end")
    End Sub
End Module
