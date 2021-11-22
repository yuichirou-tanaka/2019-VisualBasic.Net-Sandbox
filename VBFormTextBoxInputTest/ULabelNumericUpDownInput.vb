Public Class ULabelNumericUpDownInput
    Public Enum eInputType
        Number
    End Enum

    Public Property DecimalPlace As Integer
        Get
            Return NumericUpDownValue.DecimalPlaces
        End Get
        Set(value As Integer)
            NumericUpDownValue.DecimalPlaces = value
        End Set
    End Property


    Public Property InputType As eInputType
    Public Property Increment As Decimal
        Get
            Return NumericUpDownValue.Increment
        End Get
        Set(value As Decimal)
            NumericUpDownValue.Increment = value
        End Set
    End Property


    Public Property MinValue As Decimal
        Get
            Return NumericUpDownValue.Minimum
        End Get
        Set(value As Decimal)
            NumericUpDownValue.Minimum = value
        End Set
    End Property
    Public Property MaxValue As Decimal
        Get
            Return NumericUpDownValue.Maximum
        End Get
        Set(value As Decimal)
            NumericUpDownValue.Maximum = value
        End Set
    End Property

    Public Property LabelNameText As String
        Get
            Return LabelName.Text
        End Get
        Set(value As String)
            LabelName.Text = value
        End Set
    End Property

    Private _LabelUnitPositionLeft As Integer = 0
    Public Property LabelUnitPositionLeft As Integer
        Get
            Return _LabelUnitPositionLeft
        End Get
        Set(value As Integer)
            _LabelUnitPositionLeft = value
        End Set
    End Property


    ''' <summary>
    ''' Value値 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NumValue As Double
        Get
            Return CDbl(NumericUpDownValue.Value)
        End Get
        Set(value As Double)
            NumericUpDownValue.Value = CDec(value)
        End Set
    End Property

    Private Sub TextBoxValue_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        Select Case InputType
            Case eInputType.Number
                If (e.KeyChar < "0"c OrElse "9"c < e.KeyChar) AndAlso e.KeyChar <> ControlChars.Back Then
                    '押されたキーが 0～9でない場合は、イベントをキャンセルする
                    e.Handled = True
                End If
        End Select
    End Sub

    Private Sub ULabelNumericUpDownInputt_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    End Sub


End Class
