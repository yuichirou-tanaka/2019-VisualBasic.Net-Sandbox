Imports System.Threading.Tasks
Public Class WorkerData
    Public str As String
    Sub New(s As String)
        str = s
    End Sub
End Class
Class WorkerFlagTask
    Public Sub Worker(workerData As WorkerData)
        Console.WriteLine("worker s " & workerData.str)
        System.Threading.Thread.Sleep(5000)
        Console.WriteLine("worker e " & workerData.str)
    End Sub
End Class

Public Class WorkerFlagTaskManager
    'Dim WorkerFlagTaskList As List(Of WorkerFlagTask)
    Dim tasks As List(Of System.Threading.Tasks.Task)

    Dim bEndMainTask As Boolean
    Dim mainTasks As System.Threading.Tasks.Task
    Sub New()
        'WorkerFlagTaskList = New List(Of WorkerFlagTask)
        bEndMainTask = False
        tasks = New List(Of Threading.Tasks.Task)
        mainTasks = New Task(AddressOf UpdateThread)
        mainTasks.Start()
    End Sub


    Public Sub StartWorker(wdata As WorkerData)
        Dim tWorkerFlagTask As New WorkerFlagTask()
        Dim _tasks As New System.Threading.Tasks.Task(AddressOf tWorkerFlagTask.Worker, wdata)
        '_tasks.Start()
        tasks.Add(_tasks)
    End Sub

    Public Sub SetEndMainTask()
        bEndMainTask = True
    End Sub
    Public Sub UpdateThread()
        While (True)


            System.Threading.Thread.Sleep(100)

            If bEndMainTask Then
                ' 終了OKなので全部終わっているかチェックする
                If Not IsTaskCount() Then
                    Exit While
                End If
            End If

            Dim isRunningExist As Boolean = False

            For Each t In tasks.ToArray()
                If (t.Status = TaskStatus.Running) Then
                    isRunningExist = True
                    Exit For
                End If
            Next
            ' 実行中は待機
            If (isRunningExist) Then
                Continue While
            End If

            CheckEndTaskComplete() ' 完了を取り除く

            ' 開始選択
            For Each t In tasks.ToArray()
                If (t.Status = TaskStatus.Created) Then
                    t.Start()
                    Exit For
                End If
            Next
        End While
    End Sub

    Public Function IsTaskCount() As Boolean
        Return tasks.Count > 0
    End Function
    Public Function GetTaskCount() As Integer
        Return tasks.Count
    End Function
    Public Sub CheckEndTaskComplete()
        For Each t In tasks.ToArray()
            If (t.IsCompleted) Then
                tasks.Remove(t)
            End If
        Next
    End Sub

    Public Function WaitAllTask() As Boolean
        SetEndMainTask()
        Task.WaitAll(tasks.ToArray())
        Return True
    End Function
End Class
