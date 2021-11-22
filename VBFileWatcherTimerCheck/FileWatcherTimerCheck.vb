Imports System.IO
Imports System.Threading
Imports System.Threading.Tasks
Imports System.ComponentModel

''' <summary>
''' FileSystemWatcher継承クラス
''' </summary>
''' <remarks></remarks>
Public Class FileWatcherTimerCheckCheckWatcher
    Inherits System.IO.FileSystemWatcher
    Implements INotifyPropertyChanged

#Region "変数"
    Private iIntervalTime As Integer                    ' タスクinteveralTime
    Private iTimeOutTime As Integer                     ' タスクタイムアウト時間
    Private WatcherTask As System.Threading.Tasks.Task  ' Task
#End Region

#Region "property"
    Private ReadOnly Property IntevalTime As Integer ' ミリSec
        Get
            Return iIntervalTime * 1000
        End Get
    End Property
#End Region


#Region "constructor"
    Public Sub New(in_iIntervalTime As Integer)
        MyBase.New()
        AddHandler Me.Error, AddressOf watcher_Errored
        iIntervalTime = in_iIntervalTime
    End Sub
    Public Sub New(in_iIntervalTime As Integer, ByVal Path As String)
        MyBase.New(Path)
        AddHandler Me.Error, AddressOf watcher_Errored
        iIntervalTime = in_iIntervalTime
    End Sub
    Public Sub New(in_iIntervalTime As Integer, ByVal Path As String, ByVal Filter As String)
        MyBase.New(Path, Filter)
        AddHandler Me.Error, AddressOf watcher_Errored
        iIntervalTime = in_iIntervalTime
    End Sub
#End Region


    ''' <summary>
    ''' 開始処理、Pathが存在しなければTrueにしない
    ''' TrueになったらwatchStart通知する
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Property EnableRaisingEvents As Boolean
        Get
            Return MyBase.EnableRaisingEvents
        End Get
        Set(ByVal value As Boolean)
            If value = False Then
                MyBase.EnableRaisingEvents = value ' Falseは即設定
            Else
                If String.IsNullOrEmpty(Path) Then
                    Exit Property
                End If
                If Directory.Exists(Path) Then ' パスが存在していればTrueにする
                    OnPropertyChanged("watchstart")
                    MyBase.EnableRaisingEvents = value
                End If

            End If

        End Set
    End Property

    ''' <summary>
    ''' Path設定 存在しないディレクトリはセットしない
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Property Path As String
        Get
            Return MyBase.Path
        End Get
        Set(ByVal value As String)
            If Directory.Exists(value) Then
                MyBase.Path = value
            Else
                TaskStart(value) ' フォルダ作成監視タスクスタート
            End If

        End Set
    End Property

    ''' <summary>
    ''' タスク処理開始
    ''' </summary>
    ''' <param name="inpath">WatchPathを渡す</param>
    ''' <remarks>既に開始している場合は処理無し</remarks>
    Public Sub TaskStart(inpath As String)
        If IsNothing(WatcherTask) Then
            Dim wd As New WorkerData
            wd.checkPath = inpath
            WatcherTask = New System.Threading.Tasks.Task(AddressOf Worker, wd)
        Else
            If (WatcherTask.Status = TaskStatus.RanToCompletion Or WatcherTask.Status = TaskStatus.Canceled Or WatcherTask.Status = TaskStatus.Faulted) Then
                Dim wd As New WorkerData
                wd.checkPath = inpath
                WatcherTask = New System.Threading.Tasks.Task(AddressOf Worker, wd)
            End If
        End If

        If Not IsNothing(WatcherTask) Then
            If (WatcherTask.Status = TaskStatus.Running Or WatcherTask.Status = TaskStatus.WaitingForChildrenToComplete Or WatcherTask.Status = TaskStatus.WaitingForActivation Or WatcherTask.Status = TaskStatus.WaitingToRun) Then
                ' 実行中なのでスタート無し
            Else
                WatcherTask.Start() ' 開始
            End If
        End If

    End Sub



    ''' <summary>
    ''' エラー通知
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub watcher_Errored(ByVal source As System.Object, ByVal e As System.IO.ErrorEventArgs)

        If e.GetException.GetType Is GetType(System.ComponentModel.Win32Exception) Then
            EnableRaisingEvents = False
            OnPropertyChanged("watchError")
            Call TaskStart(Path)
            ' 監視対象フォルダの定期チェックを開始する
            Console.WriteLine(e.GetException.ToString)
        End If
    End Sub

    ''' <summary>
    ''' タスク用データ（タスクごとに作成)
    ''' </summary>
    ''' <remarks></remarks>
    Structure WorkerData
        Public checkPath As String
    End Structure

    ''' <summary>
    ''' Task処理
    ''' </summary>
    ''' <param name="wd"></param>
    ''' <remarks></remarks>
    Sub Worker(wd As WorkerData)
        'Stopwatchオブジェクトを作成する 
        Dim sw As New System.Diagnostics.Stopwatch()
        'ストップウォッチを開始する 
        sw.Start()

        While True
            ':パスの復活定期チェックを開始する。;
            ' フォルダが存在しない?
            If Directory.Exists(wd.checkPath) Then
                Path = wd.checkPath
                EnableRaisingEvents = True
                Exit While
            End If

            System.Threading.Thread.Sleep(IntevalTime) ' interval
        End While
        sw.Stop()
    End Sub



    Public Event PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
    ''' <summary>
    ''' 変更通知
    ''' </summary>
    ''' <param name="propName"></param>
    ''' <remarks></remarks>
    Private Sub OnPropertyChanged(ByVal propName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propName))
    End Sub


End Class





''' <summary>
''' ファイル監視クラス
''' </summary>
''' <remarks></remarks>
Public Class FileWatcherTimerCheck
#Region "メンバ変数"
    Private watcher As FileWatcherTimerCheckCheckWatcher = Nothing
    Protected ParentForm As System.Windows.Forms.Form = Nothing
    Protected WatchPath As String = ""
#End Region


    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="frm"></param>
    ''' <param name="strPath"></param>
    ''' <param name="in_iIntervalTime"></param>
    ''' <param name="bSubdir"></param>
    ''' <remarks></remarks>
    Public Sub New(ByRef frm As System.Windows.Forms.Form, strPath As String, in_iIntervalTime As Integer, Optional bSubdir As Boolean = False)
        ParentForm = frm
        WatchPath = strPath

        Console.WriteLine("フォルダ監視開始: " & WatchPath)
        watcher = New FileWatcherTimerCheckCheckWatcher(in_iIntervalTime)

        watcher.SynchronizingObject = frm
        watcher.Path = strPath
        watcher.Filter = ""
        watcher.NotifyFilter = NotifyFilters.FileName Or NotifyFilters.CreationTime Or NotifyFilters.LastWrite Or NotifyFilters.DirectoryName
        watcher.IncludeSubdirectories = bSubdir

        AddHandler watcher.Changed, AddressOf watcher_Changed
        AddHandler watcher.Created, AddressOf watcher_Created
        AddHandler watcher.Deleted, AddressOf watcher_Deleted
        AddHandler watcher.Renamed, AddressOf watcher_Renamed

        AddHandler watcher.PropertyChanged, AddressOf propertyChanged

    End Sub

    ''' <summary>
    ''' ファイナライザ
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub Finalize()
        If Not IsNothing(watcher) Then
            DisableWatch()
            watcher.Dispose()
            watcher = Nothing
        End If

        MyBase.Finalize()
    End Sub


    ''' <summary>
    ''' EnableRaisingEvents = Trueにする
    ''' </summary>
    ''' <remarks>Overridable E190704 add </remarks>
    Public Overridable Sub EnableWatch()
        watcher.EnableRaisingEvents = True
    End Sub


    ''' <summary>
    ''' EnableRaisingEvents = Falseにする
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DisableWatch()
        watcher.EnableRaisingEvents = False
    End Sub

    ''' <summary>
    ''' 変更通知
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks>継承先でOverrides実装する</remarks>
    Protected Overridable Sub watcher_Changed(ByVal source As System.Object, ByVal e As System.IO.FileSystemEventArgs)
        If e.ChangeType = WatcherChangeTypes.Changed Then
            Console.WriteLine(("ファイル 「" + e.FullPath + "」が変更されました。"))
        End If
    End Sub

    ''' <summary>
    ''' 作成通知
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks>継承先でOverrides実装する</remarks>
    Protected Overridable Sub watcher_Created(ByVal source As System.Object, ByVal e As System.IO.FileSystemEventArgs)
        If e.ChangeType = WatcherChangeTypes.Created Then
            Console.WriteLine(("ファイル 「" + e.FullPath + "」が作成されました。"))
        End If
    End Sub

    ''' <summary>
    ''' 削除通知
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks>継承先でOverrides実装する</remarks>
    Protected Overridable Sub watcher_Deleted(ByVal source As System.Object, ByVal e As System.IO.FileSystemEventArgs)
        If e.ChangeType = WatcherChangeTypes.Deleted Then
            Console.WriteLine(("ファイル 「" + e.FullPath + "」が削除されました。"))
        End If
    End Sub

    ''' <summary>
    ''' 名前変更通知
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks>継承先でOverrides実装する</remarks>
    Protected Overridable Sub watcher_Renamed(ByVal source As System.Object, ByVal e As System.IO.RenamedEventArgs)
        Console.WriteLine(("ファイル 「" + e.FullPath + "」の名前が変更されました。"))
    End Sub


    ''' <summary>
    ''' 変更処理通知
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>継承先でOverrides実装する</remarks>
    Protected Overridable Sub propertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
        Console.WriteLine(("" & e.PropertyName))
    End Sub


    ''' <summary>
    ''' Property RaisingEvents
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property EnableRaisingEvents() As Boolean
        Get
            Return watcher.EnableRaisingEvents
        End Get
    End Property

End Class


