Imports System.ComponentModel

Public Class Form1
    Private fTestSystemNotify As New TestSystemNotify()

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        fTestSystemNotify.gotoNext()
    End Sub


    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        fTestSystemNotify.gotoNext2()
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        AddHandler fTestSystemNotify.PropertyChanged, AddressOf VmOnPropertyChanged

    End Sub

    Private Sub VmOnPropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
        Dim refProp_Del As New InvVmOnPropertyChanged(AddressOf OnInvVmOnPropertyChanged)
        Invoke(refProp_Del, New Object() {sender, e})
    End Sub
    Private Delegate Sub InvVmOnPropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
    Private Sub OnInvVmOnPropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
        Dim sendTest As TestSystemNotify = CType(sender, TestSystemNotify)
        TestTextLabel1.Text = e.PropertyName & " " & sendTest.ID & " " & sendTest.Name
    End Sub

End Class
