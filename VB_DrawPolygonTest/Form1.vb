Public Class Form1


    Dim Points As New List(Of Point)
    'Dim rects As New List(Of Rectangle)

    'Dim firstPosition As Point
    'Dim lastPosition As Point

    Private Sub PictureBox1_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove

    End Sub

    Private Sub PictureBox1_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseClick
        Points.Add(PictureBox1.PointToClient(Cursor.Position))
        DrawPolygon()
    End Sub

    Private Sub PictureBox1_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        'firstPosition = PictureBox1.PointToClient(Cursor.Position)
    End Sub

    Private Sub PictureBox1_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        'lastPosition = PictureBox1.PointToClient(Cursor.Position)

        'Dim size As New Size()
        'size.Width = lastPosition.X - firstPosition.X
        'size.Height = lastPosition.Y - firstPosition.Y
        'rects.Add(New Rectangle(firstPosition, size))

        'DrawPolygon()
    End Sub


    Private Sub DrawPolygon()
        If Not IsNothing(PictureBox1.Image) Then
            PictureBox1.Image.Dispose()
        End If


        'Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        'Using g As Graphics = Graphics.FromImage(bmp)
        '    g.SmoothingMode = Drawing2D.SmoothingMode.HighSpeed
        '    g.Clear(Color.Transparent)
        '    If Points.Count > 1 Then
        '        Using pen1 As New Pen(Color.Black)
        '            'g.DrawPolygon(pen1, Points.ToArray())
        '        End Using
        '    End If
        'End Using



        'Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        'Using g As Graphics = Graphics.FromImage(bmp)
        '    g.SmoothingMode = Drawing2D.SmoothingMode.HighSpeed
        '    g.Clear(Color.Transparent)
        '    If rects.Count > 0 Then
        '        Using pen1 As New Pen(Color.Black)
        '            Dim brs2 As New SolidBrush(Color.DodgerBlue)
        '            'g.DrawRectangles(pen1, rects.ToArray())
        '            g.FillRectangles(brs2, rects.ToArray())
        '        End Using
        '    End If
        'End Using
        'PictureBox1.Image = bmp



        'line
        Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.SmoothingMode = Drawing2D.SmoothingMode.HighSpeed
            g.Clear(Color.Transparent)
            If Points.Count > 1 Then
                Using pen1 As New Pen(Color.Black)
                    Dim brs2 As New SolidBrush(Color.DodgerBlue)
                    g.DrawLines(pen1, Points.ToArray())
                End Using
            End If
        End Using
        PictureBox1.Image = bmp


    End Sub

End Class

