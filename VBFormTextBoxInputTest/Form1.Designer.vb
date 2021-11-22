<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ULabelTextBoxInput1 = New VBFormTextBoxInput.ULabelTextBoxInput()
        Me.ULabelNumericUpDownInput1 = New VBFormTextBoxInput.ULabelNumericUpDownInput()
        Me.SuspendLayout()
        '
        'ULabelTextBoxInput1
        '
        Me.ULabelTextBoxInput1.LabelNameText = "1234567"
        Me.ULabelTextBoxInput1.Location = New System.Drawing.Point(13, 45)
        Me.ULabelTextBoxInput1.MaxValue = New Decimal(New Integer() {100, 0, 0, 0})
        Me.ULabelTextBoxInput1.MinValue = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.ULabelTextBoxInput1.Name = "ULabelTextBoxInput1"
        Me.ULabelTextBoxInput1.Size = New System.Drawing.Size(220, 25)
        Me.ULabelTextBoxInput1.TabIndex = 1
        '
        'ULabelNumericUpDownInput1
        '
        Me.ULabelNumericUpDownInput1.DecimalPlace = 0
        Me.ULabelNumericUpDownInput1.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.ULabelNumericUpDownInput1.InputType = VBFormTextBoxInput.ULabelNumericUpDownInput.eInputType.Number
        Me.ULabelNumericUpDownInput1.LabelNameText = "1234567"
        Me.ULabelNumericUpDownInput1.LabelUnitPositionLeft = 0
        Me.ULabelNumericUpDownInput1.Location = New System.Drawing.Point(13, 13)
        Me.ULabelNumericUpDownInput1.MaxValue = New Decimal(New Integer() {100, 0, 0, 0})
        Me.ULabelNumericUpDownInput1.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ULabelNumericUpDownInput1.Name = "ULabelNumericUpDownInput1"
        Me.ULabelNumericUpDownInput1.NumValue = 0.0R
        Me.ULabelNumericUpDownInput1.Size = New System.Drawing.Size(268, 25)
        Me.ULabelNumericUpDownInput1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.ULabelTextBoxInput1)
        Me.Controls.Add(Me.ULabelNumericUpDownInput1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ULabelNumericUpDownInput1 As VBFormTextBoxInput.ULabelNumericUpDownInput
    Friend WithEvents ULabelTextBoxInput1 As VBFormTextBoxInput.ULabelTextBoxInput

End Class
