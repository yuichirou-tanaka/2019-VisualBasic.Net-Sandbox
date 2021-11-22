<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ULabelNumericUpDownInput
    Inherits System.Windows.Forms.UserControl

    'UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。
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
        Me.LabelName = New System.Windows.Forms.Label()
        Me.NumericUpDownValue = New System.Windows.Forms.NumericUpDown()
        CType(Me.NumericUpDownValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelName
        '
        Me.LabelName.AutoSize = True
        Me.LabelName.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LabelName.Location = New System.Drawing.Point(0, 3)
        Me.LabelName.Margin = New System.Windows.Forms.Padding(0, 4, 0, 0)
        Me.LabelName.Name = "LabelName"
        Me.LabelName.Size = New System.Drawing.Size(65, 20)
        Me.LabelName.TabIndex = 7
        Me.LabelName.Text = "1234567"
        '
        'NumericUpDownValue
        '
        Me.NumericUpDownValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDownValue.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.NumericUpDownValue.Location = New System.Drawing.Point(115, 2)
        Me.NumericUpDownValue.Name = "NumericUpDownValue"
        Me.NumericUpDownValue.Size = New System.Drawing.Size(150, 19)
        Me.NumericUpDownValue.TabIndex = 8
        '
        'uc_LabelNumericUpDownInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.NumericUpDownValue)
        Me.Controls.Add(Me.LabelName)
        Me.Name = "uc_LabelNumericUpDownInput"
        Me.Size = New System.Drawing.Size(268, 25)
        CType(Me.NumericUpDownValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelName As System.Windows.Forms.Label
    Friend WithEvents NumericUpDownValue As System.Windows.Forms.NumericUpDown

End Class
