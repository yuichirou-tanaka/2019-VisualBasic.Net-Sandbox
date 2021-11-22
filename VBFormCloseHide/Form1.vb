Imports System
Imports System.Reflection
Class TetClass
    Public Sub Say()
        Debug.Print("test")
    End Sub
End Class

Public Class Form1
    Private form2 As New Form2
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'CreateInstance("FormCloseTest.TetClass")
    End Sub
    Private Sub CreateInstance(instanceName As String)
        Dim assembly As Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim inst As TetClass = CType(assembly.CreateInstance(instanceName), TetClass)
        inst.Say()
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If IsNothing(form2) Then
            form2 = New Form2
        End If

        form2.Location = New Point(0, 0)
        Me.Panel1.Controls.Add(form2)

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If Not IsNothing(form2) Then
            Me.Panel1.Controls.Remove(form2)
            form2.Dispose()
            form2 = Nothing
        End If
    End Sub
End Class
