Public Class Form1
    Private Sub CenterFlowLayoutPanelNavigationControls()
        'Get the total width of all Buttons in FlowLayoutPanelNavigation
        Dim totalControlWidth As Integer = FlowLayoutPanel1.Controls.OfType(Of Button).Select(Function(btn) btn.Width).Sum

        If totalControlWidth < FlowLayoutPanel1.Width Then
            'If the total width is less than FlowLayoutPanelNavigation then get the difference, divide by 2, and set that as the left-padding
            FlowLayoutPanel1.Padding = New Padding(Convert.ToInt32((FlowLayoutPanel1.Width - totalControlWidth) / 2), 0, 0, 0)
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterFlowLayoutPanelNavigationControls()
    End Sub
End Class
