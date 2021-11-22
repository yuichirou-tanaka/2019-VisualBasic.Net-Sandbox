Class CTestFinalyze
    Implements IDisposable

    Sub New()
        Console.WriteLine("CTestFinalyze New")
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        Class_Terminate()
        Console.WriteLine("CTestFinalyze Finalize")
    End Sub
    Private disposedValue As Boolean = False        ' 重複する呼び出しの検出用
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
            End If
        End If
        Me.disposedValue = True
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        Me.Finalize()
        GC.SuppressFinalize(Me)
    End Sub
    Private Sub Class_Terminate()

    End Sub

End Class

Module Module1

    Function StringTest(ByRef in_Name() As String, ByRef in_Index() As Long) As Long
        Console.WriteLine(in_Name)
        Console.WriteLine(in_Index)
        Return 0
    End Function

    Sub STestFuncStr()
        Dim lName() As String = {}
        Dim lindex() As Long = {}
        Dim lCount As Long = StringTest(lName, lindex)
    End Sub

    Function TestFuncStr() As String
        TestFuncStr = "kimoi"

        Return TestFuncStr
    End Function
    Sub TestFunc()
        Dim aCTestFinalyze As New CTestFinalyze
        'aCTestFinalyze.Dispose()
    End Sub
    Sub Main()
        'Console.WriteLine("Main s")

        'TestFunc()
        'Console.WriteLine("Main e")
        STestFuncStr()
        'Console.WriteLine(TestFuncStr())
    End Sub

End Module
