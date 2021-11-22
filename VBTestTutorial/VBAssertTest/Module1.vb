Module Module1

    Sub Main()
        Dim Ary(4) As Integer
        'Debug.Print(UBound(Ary))
        'Debug.Print(LBound(Ary))
        Dim i As Integer
        'For i = -10 To 10
        For i = 0 To 4
            'Trace.Assert(LBound(Ary) <= i And i <= UBound(Ary), "i <> 0", "除算のため変数iはゼロでなければなりません")
            Debug.Assert(LBound(Ary) <= i And i <= UBound(Ary), "配列indexオーバー")
            Debug.Print(Ary(i))
            'j = j + 100 / i
        Next
        Debug.Print(i)
    End Sub

End Module
