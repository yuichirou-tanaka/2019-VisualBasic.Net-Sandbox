Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Drawing.Design

Public Class UserControl1

    Private _Items As StringCollection = New StringCollection()

    <Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design", GetType(UITypeEditor)), TypeConverter(GetType(CollectionConverter)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
    Public Property Items As StringCollection
        Get
            Return Me._Items
        End Get
        Set(ByVal value As StringCollection)
            Me._Items = value
            ComboBox1.Items.Clear()
            For Each it As String In _Items
                ComboBox1.Items.Add(it)
            Next

        End Set
    End Property

    Private Sub UpdateComboBoxItem()
        ComboBox1.Items.Clear()
        For Each it As String In _Items
            ComboBox1.Items.Add(it)
        Next
    End Sub

    Private Sub UserControl1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        UpdateComboBoxItem()
    End Sub
End Class
