Option Explicit On
Public Class ucTextDrop

    Private WithEvents dgv As New DataGridView
    Private WithEvents tsDropDown As New ToolStripDropDown
    Public DropDownOpen As Boolean = False

    Public GridDataSource As DataTable = Nothing

    Private Sub TextDrop_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dgv As New DataGridView
        With dgv
            .Columns.Add("sn", "sn")
            .Columns.Add("sName", "Name")
            .Columns.Add("sAge", "Age")
            .Rows.Add()
            .Size = New Size(360, 200)
            '.DataSource = Nothing
            '.DataSource = GridDataSource

            '.Dock = DockStyle.Fill
        End With


        Dim tsmiHost As New ToolStripControlHost(dgv) 'you can add a Panel or whatever control you want to the ToolStripControlHost, I am adding a UserControl
        tsmiHost.Margin = New Padding(0)
        tsDropDown.Padding = New Padding(0)
        tsDropDown.Items.Add(tsmiHost)

    End Sub

    Private Sub tb_GotFocus(sender As Object, e As EventArgs) Handles tb.GotFocus
        Debug.Print("tb_GotFocus")
    End Sub

    'Private Sub tbSearch_TextChanged(sender As Object, e As EventArgs) Handles tbSearch.TextChanged
    '    'Dim kword As String = tbSearch.Text
    '    'If GridDataSource IsNot Nothing Then
    '    '    Dim F As DataRow() = GridDataSource.Select($"Person LIKE '%{kword}%'")
    '    '    If F IsNot Nothing AndAlso F.Count > 0 Then
    '    '        Grid.DataSource = Nothing
    '    '        Grid.DataSource = F.CopyToDataTable
    '    '    End If
    '    'End If
    'End Sub

    Private Sub tsDropDown_Closing(sender As Object, e As ToolStripDropDownClosingEventArgs) Handles tsDropDown.Closing
        ' e.Cancel = Not (e.CloseReason = ToolStripDropDownCloseReason.CloseCalled OrElse e.CloseReason = ToolStripDropDownCloseReason.AppFocusChange)
        'TextBox1.Text = If(e.Cancel, "Close Options", "Open Options")
    End Sub

    Private Sub tsDropDown_Opened(sender As Object, e As EventArgs) Handles tsDropDown.Opened
        DropDownOpen = True
        Debug.Print("tsDropDown_Opened")
    End Sub

    Private Sub tsDropDown_Closed(sender As Object, e As ToolStripDropDownClosedEventArgs) Handles tsDropDown.Closed
        DropDownOpen = False
        Debug.Print("tsDropDown_Closed")
    End Sub

    Private Sub tb_TextChanged(sender As Object, e As EventArgs) Handles tb.TextChanged
        If Not DropDownOpen Then
            Dim pts As Point = Me.PointToScreen(tb.Location)
            tsDropDown.Show(pts.X, pts.Y + tb.Height)
            Debug.Print("shown")
            tb.Focus()
        End If

    End Sub

End Class
