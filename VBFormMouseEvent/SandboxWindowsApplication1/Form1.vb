Public Class Form1

    Dim WithEvents test As New EventTester

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AddHandler PictureBox1.MouseDown, AddressOf PictureBox1_MouseDown
        AddHandler PictureBox1.MouseUp, AddressOf PictureBox1_MouseUp
        AddHandler PictureBox1.MouseMove, AddressOf PictureBox1_MouseMove
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        test.DoEvent(0)
        test.DoEvent(1)

        '無名関数findKeyの定義
        Dim findKey As Func(Of String, String(), Integer) = _
            Function(keysearch As String, list As String()) As Integer
                Dim result As Integer = -1
                If list IsNot Nothing AndAlso list.Length > 0 Then
                    For index As Integer = 0 To list.Length - 1
                        If list(index) = keysearch Then
                            result = index
                            Exit For
                        End If
                    Next

                End If
                Return result
            End Function

        '検索用データ
        Dim data() As String = {"abc", "def", "ghi"}

        '無名関数の使用
        Debug.Print(findKey("def", data).ToString()) '"1"が出力される


    End Sub
    Private Sub TestEventAA(ByVal sender As Object, ByVal e As System.EventArgs, ByVal pint As Integer) Handles test.TestEvent
        If pint = 0 Then
            MsgBox("イベント0:成功")
        Else
            MsgBox("イベント0以外:成功")
        End If
    End Sub

    Private Sub PictureBox1_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        'MsgBox("PictureBox1_MouseDown")

    End Sub

    Private Sub PictureBox1_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        'MsgBox("PictureBox1_MouseUp")

    End Sub

    Private Sub PictureBox1_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        'MsgBox("PictureBox1_MouseMove")

    End Sub
End Class
Public Class EventTester
    Public Event TestEvent(ByVal sender As Object, ByVal e As EventArgs, ByVal pint As Integer)
    Public Sub DoEvent(ByVal pInt As Integer)
        RaiseEvent TestEvent(Me, New EventArgs, pInt)
    End Sub
End Class