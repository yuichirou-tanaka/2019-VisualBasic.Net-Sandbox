
Class structTestc2
    Public Sub GetTd(ByVal flag As Boolean, ByRef td As structTestc.testData)
        If flag Then
            td.ids = New List(Of Integer)
            td.ids.Add(1)
        Else
            td.ids = Nothing
        End If
    End Sub
End Class



Class structTestc
    Structure testData
        Public ids As List(Of Integer)
    End Structure
    Public td As New testData
    Private tcs2 As New structTestc2
    Public Sub GetTd()
        tcs2.GetTd(False, td)
        'tcs2.GetTd(True, td)
    End Sub
End Class
Module Module1

    Sub Main()
        Dim stc As New structTestc
        stc.GetTd()
        'Dim itds As Integer() = IIf(IsNothing(stc.td.ids), Nothing, stc.td.ids.ToArray()) ' error'両方評価される
        Dim itds As Integer() = Nothing
        If stc.td.ids Is Nothing Then
            itds = Nothing
        Else
            itds = stc.td.ids.ToArray()
        End If


        'Console.WriteLine(Join(itds, ","))

    End Sub

End Module
