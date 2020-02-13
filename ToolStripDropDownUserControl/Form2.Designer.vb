<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.UcTextDrop21 = New ToolStripDropDownUserControl.ucTextDrop2()
        Me.UcTextDrop1 = New ToolStripDropDownUserControl.ucTextDrop()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'UcTextDrop21
        '
        Me.UcTextDrop21.Location = New System.Drawing.Point(310, 36)
        Me.UcTextDrop21.Name = "UcTextDrop21"
        Me.UcTextDrop21.Size = New System.Drawing.Size(192, 20)
        Me.UcTextDrop21.TabIndex = 1
        '
        'UcTextDrop1
        '
        Me.UcTextDrop1.Location = New System.Drawing.Point(44, 31)
        Me.UcTextDrop1.Name = "UcTextDrop1"
        Me.UcTextDrop1.Size = New System.Drawing.Size(217, 26)
        Me.UcTextDrop1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(196, 80)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 100)
        Me.Panel1.TabIndex = 2
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 235)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.UcTextDrop21)
        Me.Controls.Add(Me.UcTextDrop1)
        Me.DoubleBuffered = True
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form2"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UcTextDrop1 As ucTextDrop
    Friend WithEvents UcTextDrop21 As ucTextDrop2
    Friend WithEvents Panel1 As Panel
End Class
