Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms
Public Class ProgressDialog

    Private indexImageId As Integer = 0
    Private bLoaded As Boolean = False ' Load関数呼ばれたかどうか

    ''' <summary>
    ''' Loaded呼ばれたかどうか
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Loaded As Boolean
        Get
            Return bLoaded
        End Get
    End Property

    Private Sub ProgressDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.BackgroundImage = Me.ImageList1.Images(indexImageId)
        bLoaded = True ' 強制待機用
    End Sub

    Private Sub NextImagePicture()
        indexImageId += 1
        If ImageList1.Images.Count <= indexImageId Then
            indexImageId = 0
        End If
        PictureBox1.BackgroundImage = ImageList1.Images(indexImageId)
    End Sub

    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        NextImagePicture()
        Refresh()
    End Sub
End Class


Public Class ProgressDialogShowTask
    Implements IDisposable

    Private tProgressDialog As ProgressDialog
    Private ftask As System.Threading.Tasks.Task

    Private paretnControl As Control
    Sub New(in_paretnControl As Control)
        paretnControl = in_paretnControl
        tProgressDialog = New ProgressDialog
        If ftask Is Nothing Then
            ftask = New System.Threading.Tasks.Task(AddressOf Me.ShowProgressForm)
        Else
            If ftask.Status = TaskStatus.Canceled Or ftask.Status = TaskStatus.RanToCompletion Or ftask.Status = TaskStatus.Faulted Then
                ftask.Dispose()
                ftask = New System.Threading.Tasks.Task(AddressOf ShowProgressForm)
            End If
        End If

        If ftask.Status = TaskStatus.Created Then
            ftask.Start()
        End If
        ShowDialogEndCheck()
    End Sub

    Private Sub DiposeTask() ' 
        If Not (ftask Is Nothing) Then
            If ftask.Status = TaskStatus.Canceled Or ftask.Status = TaskStatus.RanToCompletion Or ftask.Status = TaskStatus.Faulted Then
                ftask.Dispose()
                ftask = Nothing
            End If
        End If
    End Sub
    Private Sub DiposeDialog() ' 
        Try
            If Not (tProgressDialog Is Nothing) Then

                tProgressDialog.Dispose()
                tProgressDialog = Nothing
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)

        End Try
    End Sub
    ' 別スレッドで動作させるメソッド
    Private Sub ShowProgressForm() ' 
        tProgressDialog = New ProgressDialog
        tProgressDialog.ShowDialog()
    End Sub

    ''' <summary>
    ''' Loadedされたかどうかチェック
    ''' </summary>
    Public Sub ShowDialogEndCheck()
        While (Not (tProgressDialog Is Nothing) And Not tProgressDialog.Loaded)
            'Console.WriteLine("tt")
            System.Threading.Thread.Sleep(1)
        End While
    End Sub

    Public Sub InvokeDisposeDialog(con As Control)
        con.Invoke(New CloseFunc(AddressOf DiposeDialog))
    End Sub

    Public Delegate Sub CloseFunc()

#Region "IDisposable Support"
    Private disposedValue As Boolean ' 重複する呼び出しを検出するには

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: マネージ状態を破棄します (マネージ オブジェクト)。
            End If

            ' TODO: アンマネージ リソース (アンマネージ オブジェクト) を解放し、下の Finalize() をオーバーライドします。
            ' TODO: 大きなフィールドを null に設定します。

            DiposeDialog()
            DiposeTask()
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: 上の Dispose(ByVal disposing As Boolean) にアンマネージ リソースを解放するコードがある場合にのみ、Finalize() をオーバーライドします。
    'Protected Overrides Sub Finalize()
    '    ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(ByVal disposing As Boolean) に記述します。
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' このコードは、破棄可能なパターンを正しく実装できるように Visual Basic によって追加されました。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(ByVal disposing As Boolean) に記述します。
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class