Imports System.Threading.Tasks

Module Module1
    Sub ThreadQue()
        Const MAX_QUE As Integer = 3 ' キューに保持する最大個数
        Dim que = New Queue(Of Integer)(MAX_QUE)
        Dim runningFlag As Boolean = True ' falseにした後、キューが空になるとConsumerが止まる

        ' Producerを定義して実行開始
        Dim produceTask = Task.Factory.StartNew(
          Sub()
              ' 1から5まで順にデータを投入していく
              For i As Integer = 1 To 5
                  ' データ投入が間に合わない場合をシミュレート
                  If (i = 5) Then
                      Console.WriteLine("stop enqueue")
                      System.Threading.Thread.Sleep(1000)
                      Console.WriteLine("restart enqueue")
                  End If

                  ' 投入データを作成する処理をシミュレート
                  System.Threading.Thread.Sleep(10)

                  ' キューへデータを投入する
                  SyncLock que ' 排他ロックを取得
                      While (que.Count >= MAX_QUE)
                          ' MAX_QUEを超えないように投入を待機する
                          Console.WriteLine("wait enqueue")
                          System.Threading.Monitor.Wait(que) ' 待機する（他でMonitor.PulseAllされると再開）
                      End While

                      que.Enqueue(i)
                      Console.WriteLine("Enqueue({" & i & "}), count={" & que.Count & "}")
                      System.Threading.Monitor.PulseAll(que) ' 待機中のスレッドがあったら、再開させる
                  End SyncLock '排他ロックを解放
              Next
              runningFlag = False ' データ投入完了を通知
              Console.WriteLine("end enqueue")
          End Sub)

        ' Consumerを定義
        Dim consume As Action(Of String) =
          Sub(header)
              While (True)
                  Dim data As Integer? = Nothing
                  SyncLock que '排他ロックを取得
                      While (que.Count = 0 AndAlso runningFlag)
                          ' キューが空の間は待機
                          Console.WriteLine("{" & header & "} wait dequeue")
                          System.Threading.Monitor.Wait(que) ' 待機する（他でMonitor.PulseAllされると再開）
                      End While

                      ' キューからデータを取り出す
                      If (que.Count > 0) Then
                          data = que.Dequeue()
                          Console.WriteLine("{" & header & "} Dequeue({" & data.Value & "}), count={" & que.Count & "}")
                          System.Threading.Monitor.PulseAll(que) ' 待機中のスレッドがあったら、再開させる
                      Else ' キューが空で、runningFlag==falseのとき
                          Exit While ' 無限ループを抜ける
                      End If
                  End SyncLock ' 排他ロックを解放
                  ' データの処理はロックを外してから行う
                  If (data.HasValue) Then
                      ' キューから取り出したデータを使う処理をシミュレート
                      Console.WriteLine("{" & header & "} start process({" & data.Value & "})")
                      System.Threading.Thread.Sleep(300)
                      Console.WriteLine("{" & header & "} end process({" & data.Value & "})")
                  End If
              End While
              Console.WriteLine("{" & header & "} EXIT")
          End Sub

        System.Threading.Thread.Sleep(100)

        ' Consumerの実行を開始（2スレッド）
        Dim consumeTask1 = Task.Factory.StartNew(Sub() consume("  [1]"))
        Dim consumeTask2 = Task.Factory.StartNew(Sub() consume("    [2]"))

        ' 実行終了を待機
        Task.WaitAll(produceTask, consumeTask1, consumeTask2)
        Console.WriteLine("COMPLETED")
    End Sub
    Sub Main()
        ThreadQue()
    End Sub

End Module
