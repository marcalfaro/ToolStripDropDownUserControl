Imports System
Imports System.Drawing
Imports System.Windows.Forms

Class SizeablePictureBox
    Inherits PictureBox

    Public Sub New()
        Me.ResizeRedraw = True
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim rc = New Rectangle(Me.ClientSize.Width - grab, Me.ClientSize.Height - grab, grab, grab)
        ControlPaint.DrawSizeGrip(e.Graphics, Me.BackColor, rc)
    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)
        MyBase.WndProc(m)

        If m.Msg = &H84 Then
            Dim pos = Me.PointToClient(New Point(m.LParam.ToInt32()))
            If pos.X >= Me.ClientSize.Width - grab AndAlso pos.Y >= Me.ClientSize.Height - grab Then m.Result = New IntPtr(17)
        End If
    End Sub

    Private Const grab As Integer = 16
End Class
