<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Text_Viewer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.RichTextBox = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'RichTextBox
        '
        Me.RichTextBox.Location = New System.Drawing.Point(12, 12)
        Me.RichTextBox.Name = "RichTextBox"
        Me.RichTextBox.ReadOnly = True
        Me.RichTextBox.Size = New System.Drawing.Size(688, 454)
        Me.RichTextBox.TabIndex = 0
        Me.RichTextBox.Text = ""
        '
        'Text_Viewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(712, 478)
        Me.Controls.Add(Me.RichTextBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Text_Viewer"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".NET Framwork 3.5 Installation Log (\Windows\logs\dism\dism.log)"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RichTextBox As System.Windows.Forms.RichTextBox
End Class
