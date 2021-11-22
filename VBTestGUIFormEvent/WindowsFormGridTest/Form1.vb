Imports System.Drawing
Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Dim num As Integer = 1


        'DataGridView1.AllowUserToAddRows = False
        'DataGridView1.ReadOnly = True
        'DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.ColumnHeadersVisible = False
        DataGridView1.RowHeadersVisible = False



        Dim cellText(,) As String = {
             {"店舗", "店舗", "売上"},
             {"店舗名", "担当エリア", "売上"},
             {"北支店", "駅北", "10000"},
             {"北支店", "駅南", "9000"},
             {"西支店", "商店街", "12000"},
             {"東支店", "住宅区", "8000"},
             {"南支店", "商業区", "11000"}
         }
        Dim rowAdd As DataGridViewRow
        For i = 0 To 6
            rowAdd = New DataGridViewRow
            rowAdd.CreateCells(DataGridView1)
            For j = 0 To rowAdd.Cells.Count - 1
                rowAdd.Cells(j).Value = cellText(i, j)
            Next
            DataGridView1.Rows.Add(rowAdd)
        Next

        'For i As Integer = 0 To 10
        '    DataGridView1.Rows.Add(num + 0, num + 1, num + 2, num + 3)
        '    num += 4
        'Next



    End Sub

    Private Sub DataGridView1_CellPainting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting
        '結合したいセルをここに書く
        MergeCell(e, New Point(0, 0), New Point(1, 0))

        'If e.RowIndex = -1 AndAlso e.ColumnIndex = -1 Then
        '    e.Paint(e.CellBounds, DataGridViewPaintParts.None)
        '    e.Handled = True
        '    Dim rect = DataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
        '    rect.Width -= 1
        '    rect.Height -= 1

        '    Dim separatedHeight = rect.Height * 2
        '    Dim writeRect = New Rectangle(rect.X, rect.Y, rect.Width, separatedHeight)
        '    e.Graphics.FillRectangle(New SolidBrush(SystemColors.Control), writeRect)
        '    e.Graphics.DrawRectangle(New Pen(SystemColors.ControlDark), writeRect)

        '    Dim headerTexts = "ID"
        '    TextRenderer.DrawText(e.Graphics, headerTexts, DataGridView1.ColumnHeadersDefaultCellStyle.Font, writeRect, SystemColors.ControlText, TextFormatFlags.VerticalCenter Or TextFormatFlags.HorizontalCenter Or TextFormatFlags.EndEllipsis)

        'End If
        'If e.RowIndex = 0 AndAlso e.ColumnIndex = 0 Then
        '    e.Paint(e.CellBounds, DataGridViewPaintParts.None)
        '    e.Handled = True
        '    Dim rect = DataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
        '    rect.Width -= 1
        '    rect.Height -= 1

        '    Dim separatedHeight = rect.Height * 2
        '    Dim writeRect = New Rectangle(rect.X, rect.Y, rect.Width, separatedHeight)
        '    e.Graphics.FillRectangle(New SolidBrush(SystemColors.Control), writeRect)
        '    e.Graphics.DrawRectangle(New Pen(SystemColors.ControlDark), writeRect)

        '    Dim headerTexts = "ID"
        '    TextRenderer.DrawText(e.Graphics, headerTexts, DataGridView1.ColumnHeadersDefaultCellStyle.Font, writeRect, SystemColors.ControlText, TextFormatFlags.VerticalCenter Or TextFormatFlags.HorizontalCenter Or TextFormatFlags.EndEllipsis)

        'End If
        'If e.RowIndex = 1 AndAlso e.ColumnIndex = 0 Then
        '    e.Paint(e.CellBounds, DataGridViewPaintParts.None)
        '    e.Handled = True
        '    Dim rect = DataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
        '    rect.Width -= 1
        '    rect.Height -= 1

        '    Dim separatedHeight = rect.Height * 2
        '    Dim writeRect = New Rectangle(rect.X, rect.Y, rect.Width, separatedHeight)
        '    e.Graphics.FillRectangle(New SolidBrush(SystemColors.Control), writeRect)
        '    e.Graphics.DrawRectangle(New Pen(SystemColors.ControlDark), writeRect)

        '    Dim headerTexts = "ID"
        '    TextRenderer.DrawText(e.Graphics, headerTexts, DataGridView1.ColumnHeadersDefaultCellStyle.Font, writeRect, SystemColors.ControlText, TextFormatFlags.VerticalCenter Or TextFormatFlags.HorizontalCenter Or TextFormatFlags.EndEllipsis)

        'End If


        'If e.RowIndex = -1 AndAlso e.ColumnIndex = 2 Then
        '    e.Paint(e.CellBounds, DataGridViewPaintParts.None)
        '    e.Handled = True
        '    Dim rect = DataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
        '    rect.Width -= 1
        '    rect.Height -= 1
        '    e.Graphics.FillRectangle(New SolidBrush(SystemColors.Control), rect)
        '    e.Graphics.DrawRectangle(New Pen(SystemColors.ControlDark), rect)
        '    Dim separatedHeight = rect.Height / 3
        '    Dim headerTexts = New String() {"D", "E", "F"}
        '    For i = 0 To 3 - 1
        '        e.Graphics.DrawLine(New Pen(SystemColors.ControlDark), CInt(rect.Left), CInt(rect.Top + separatedHeight * i), CInt(rect.Right), CInt(rect.Top + separatedHeight * i))
        '        Dim separatedRect = New Rectangle(rect.X, rect.Y + separatedHeight * i, rect.Width, separatedHeight)
        '        TextRenderer.DrawText(e.Graphics, headerTexts(i), DataGridView1.ColumnHeadersDefaultCellStyle.Font, separatedRect, SystemColors.ControlText, TextFormatFlags.VerticalCenter Or TextFormatFlags.HorizontalCenter Or TextFormatFlags.EndEllipsis)
        '    Next
        'End If



    End Sub
    Private Sub MergeCell(ByRef e As System.Windows.Forms.DataGridViewCellPaintingEventArgs, Cell1 As Point, Cell2 As Point)
        If (e.RowIndex >= Cell1.Y AndAlso e.RowIndex <= Cell2.Y) AndAlso (e.ColumnIndex >= Cell1.X AndAlso e.ColumnIndex <= Cell2.X) Then
            Dim rect As New Rectangle With {.X = 0, .Y = 0, .Width = 0, .Height = 0}
            Dim i As Integer
            For i = Cell1.Y + 1 To DataGridView1.FirstDisplayedScrollingRowIndex
                rect.Y -= DataGridView1(Cell1.X, i - 1).Size.Height
            Next
            For i = DataGridView1.FirstDisplayedScrollingRowIndex + 1 To Cell1.Y
                rect.Y += DataGridView1(Cell1.X, i - 1).Size.Height
            Next
            '結合セルが画面外にあるときの位置を考慮
            For i = Cell1.X + 1 To DataGridView1.FirstDisplayedScrollingColumnIndex
                rect.X -= DataGridView1(i - 1, Cell1.Y).Size.Width
            Next
            For i = DataGridView1.FirstDisplayedScrollingColumnIndex + 1 To Cell1.X
                rect.X += DataGridView1(i - 1, Cell1.Y).Size.Width
            Next

            '終了セルの幅
            For i = Cell1.Y To Cell2.Y
                rect.Height += DataGridView1(Cell2.X, i).Size.Height
            Next
            For i = Cell1.X To Cell2.X
                rect.Width += DataGridView1(i, Cell2.Y).Size.Width
            Next

            'セル位置の補正
            rect.X += 1
            rect.Y += 1

            '通常の塗りつぶし
            e.Graphics.DrawRectangle(New Pen(DataGridView1.GridColor), rect)

            Dim labelfont = New Font("Arial", 12)

            Dim headerText As String = DataGridView1(e.ColumnIndex, e.RowIndex).Value
            TextRenderer.DrawText(e.Graphics, headerText, labelfont, rect, e.CellStyle.ForeColor, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)

            e.Handled = True

        End If
    End Sub

End Class

