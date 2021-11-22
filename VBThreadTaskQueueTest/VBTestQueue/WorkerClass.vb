' スレッドワーカークラス
Public Class WorkerClass

    Private _status As String = "待機中..."
    Private _progress As Integer = 0

    ' ステータスプロパティ
    Public ReadOnly Property Status() As String
        Get
            Return _status
        End Get
    End Property

    ' ワーカー処理
    Public Sub WorkerProgress(ByVal state As Object)
        Try

            For i As Integer = 0 To 100
                _progress = i
                _status = String.Format("処理中 {0}%", _progress)
                System.Threading.Thread.Sleep(100)
            Next

            _status = "処理完了!"

        Catch ex As Exception
            _status = ex.Message
        End Try
    End Sub

End Class