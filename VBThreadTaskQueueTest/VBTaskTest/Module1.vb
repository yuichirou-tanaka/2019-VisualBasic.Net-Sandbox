Imports System.Threading.Tasks

Module Module1
    Sub Main()
        Main2()
    End Sub
    Sub Main2()
        Dim work As New WorkerFlagTaskManager
        work.StartWorker(New WorkerData("t"))
        work.StartWorker(New WorkerData("a"))
        work.StartWorker(New WorkerData("b"))
        work.StartWorker(New WorkerData("c"))
        work.StartWorker(New WorkerData("d"))

        work.WaitAllTask()
        'While (work.IsTaskCount())

        '    System.Threading.Thread.Sleep(100)
        'End While
    End Sub
    Sub Main1()
        Console.WriteLine("main  s")
        Dim tasks As New System.Threading.Tasks.Task(
        Sub()
            Console.WriteLine("s")
            System.Threading.Thread.Sleep(5000)
            Console.WriteLine("e")
        End Sub
        )
        tasks.Start()
        'tasks.Wait()

        Task.WaitAll(tasks)

        Console.WriteLine("main  e")
    End Sub
End Module
