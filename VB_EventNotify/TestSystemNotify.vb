Imports System.ComponentModel

Public Class TestSystemNotify
    Implements INotifyPropertyChanged

    Public Name As String
    Public ID As Integer

    Public Sub gotoNext()
        Name = "goto"
        ID = 10
        OnPropertyChanged("n1")
    End Sub
    Public Sub gotoNext2()
        Name = "fff"
        ID = 32
        OnPropertyChanged("n2")
    End Sub

    Public Event PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
    Private Sub OnPropertyChanged(ByVal propName As String)

        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propName))

    End Sub


End Class
