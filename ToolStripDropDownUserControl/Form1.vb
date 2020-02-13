Public Class Form1
    Private WithEvents MyUserCtrl As New MyUserControl With {.MinimumSize = .Size}
    Private WithEvents ucDropDown As New ToolStripDropDown
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tsmiHost As New ToolStripControlHost(MyUserCtrl) 'you can add a Panel or whatever control you want to the ToolStripControlHost, I am adding a UserControl
        tsmiHost.Margin = New Padding(0)
        ucDropDown.Padding = New Padding(0)
        ucDropDown.Items.Add(tsmiHost)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim pts As Point = Me.PointToScreen(Button1.Location)
        ucDropDown.Show(pts.X, pts.Y + Button1.Height)
    End Sub
End Class
