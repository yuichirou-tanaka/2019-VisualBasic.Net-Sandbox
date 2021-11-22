Imports System.Threading


Public Class Form1
    Private _workerList As List(Of WorkerClass)

    Public Sub New()

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        ' インスタンス作成
        _workerList = New List(Of WorkerClass)

        ' 同時に実行できるスレッド数を指定
        ThreadPool.SetMaxThreads(2, 256)

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Timer1.Interval = 500
        Me.Timer1.Start()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim wk As WorkerClass = New WorkerClass()
        _workerList.Add(wk)
        ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf wk.WorkerProgress))

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Me.Timer1.Enabled = False

        Try
            ' ちらつき防止!
            Me.ListBox1.BeginUpdate()

            Dim num As Integer = 1

            Me.ListBox1.Items.Clear()
            For Each wk As WorkerClass In _workerList
                ' リストボックス追加
                Me.ListBox1.Items.Add(
                    String.Format("{0:00}:{1}",
                    num, wk.Status))
                num = num + 1
            Next

        Finally
            ' ちらつき防止!
            Me.ListBox1.EndUpdate()
        End Try

        Me.Timer1.Enabled = True

    End Sub
End Class
