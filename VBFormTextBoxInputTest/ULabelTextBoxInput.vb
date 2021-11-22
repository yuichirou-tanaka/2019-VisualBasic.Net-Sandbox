Imports System.Text.RegularExpressions

Public Class ULabelTextBoxInput

    Public Property MinValue As Decimal
    Public Property MaxValue As Decimal

    Private defFontColor As Color ' default Color

    Public Property LabelNameText As String
        Get
            Return LabelName.Text
        End Get
        Set(value As String)
            LabelName.Text = value
        End Set
    End Property


    Private Sub ULabelTextBoxInputt_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        defFontColor = TextBoxValue.ForeColor
    End Sub

    Private Sub TextBoxValue_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxValue.KeyPress
        If (e.KeyChar < "0"c OrElse "9"c < e.KeyChar) AndAlso e.KeyChar <> ControlChars.Back AndAlso e.KeyChar <> "-" AndAlso e.KeyChar <> "e" AndAlso e.KeyChar <> "." Then
            '押されたキーが 0～9でない場合は、イベントをキャンセルする
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBoxValue.TextChanged
        If String.IsNullOrEmpty(TextBoxValue.Text) Then Return
        Dim dval As Double = 0
        If CheckValidityDouble(TextBoxValue.Text, MinValue, MaxValue, dval) Then
            TextBoxValue.ForeColor = defFontColor
        Else
            TextBoxValue.ForeColor = Color.Red ' 値範囲外、またはエラーは赤文字
        End If

    End Sub

    ''' <summary>
    ''' MinMax 判定
    ''' </summary>
    ''' <param name="min"></param>
    ''' <param name="max"></param>
    ''' <param name="inval"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckMinMax(ByVal min As Double, ByVal max As Double, ByVal inval As Double) As Boolean
        If Double.IsNaN(min) Then
            If inval <= max Then Return True
        ElseIf Double.IsNaN(max) Then
            If min <= inval Then Return True
        Else
            If min <= inval And inval <= max Then Return True
        End If
        Return False
    End Function

    ''' <summary>
    ''' 文字列からDoubleの値取得と範囲内判定
    ''' </summary>
    ''' <param name="str"></param>
    ''' <param name="min"></param>
    ''' <param name="max"></param>
    ''' <param name="outval"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckValidityDouble(ByVal str As String, ByVal min As Double, ByVal max As Double, ByRef outval As Double) As Boolean
        If Not Double.TryParse(str, outval) Then Return False
        Return CheckMinMax(min, max, outval)
    End Function

End Class
