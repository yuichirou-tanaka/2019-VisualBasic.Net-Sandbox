Module Module1

    Sub Main()
        'Stopwatchオブジェクトを作成する 
        Dim sw As New System.Diagnostics.Stopwatch()
        'ストップウォッチを開始する 
        sw.Start()

        '次のようにStartNewメソッドを使うと、上の2行と同じことが1行でできる 
        'Dim sw As System.Diagnostics.Stopwatch = System.Diagnostics.Stopwatch.StartNew()

        '時間を計測したい処理がここにあるものとする 
        For i As Integer = 0 To 9
            System.Threading.Thread.Sleep(100)
        Next

        'ストップウォッチを止める 
        sw.Stop()

        '結果を表示する 

        Console.WriteLine(sw.ElapsedMilliseconds)
    End Sub

End Module
