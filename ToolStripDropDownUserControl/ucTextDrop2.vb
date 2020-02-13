Option Explicit On

Public Class ucTextDrop2

    Private WithEvents sPanel As New Panel
    Private WithEvents tbSearch As New TextBox

    Private WithEvents dgv As New DataGridView
    Private WithEvents tsDropDown As New ToolStripDropDown

    Public DropDownOpen As Boolean = False

    Public GridDataSource As DataTable = Nothing

    Private Sub TextDrop_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        Build_SearchControls()

    End Sub

    Private Sub Build_SearchControls()

        sPanel.SuspendLayout()
        CType(dgv, ComponentModel.ISupportInitialize).BeginInit()

        With sPanel
            .BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            .Controls.Add(dgv)
            .Controls.Add(tbSearch)
            .Name = "sPanel"
            .Size = New System.Drawing.Size(342, 161)
        End With

        With tbSearch
            .Location = New System.Drawing.Point(3, 3)
            .Name = "sTB"
            .Size = New System.Drawing.Size(334, 20)
            .TabIndex = 0
            .Text = "Search here"
        End With

        With dgv
            .ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            .Location = New System.Drawing.Point(3, 29)
            .Name = "sDGV"
            .Size = New System.Drawing.Size(334, 127)
        End With

        sPanel.ResumeLayout(False)
        sPanel.PerformLayout()
        CType(dgv, System.ComponentModel.ISupportInitialize).EndInit()

        Dim tsmiHost As New ToolStripControlHost(sPanel)
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
        'e.Cancel = Not (e.CloseReason = ToolStripDropDownCloseReason.CloseCalled OrElse e.CloseReason = ToolStripDropDownCloseReason.AppFocusChange)
        'TextBox1.Text = If(e.Cancel, "Close Options", "Open Options")
    End Sub

    Private Sub tsDropDown_Opened(sender As Object, e As EventArgs) Handles tsDropDown.Opened
        DropDownOpen = True
        Debug.Print("tsDropDown_Opened")
    End Sub

    Private Sub tsDropDown_Closed(sender As Object, e As ToolStripDropDownClosedEventArgs) Handles tsDropDown.Closed
        DropDownOpen = False
        tb.Text = tbSearch.Text
        tb.SelectionStart = tb.Text.Length
    End Sub

    Private Sub tb_TextChanged(sender As Object, e As EventArgs) Handles tb.TextChanged
        If Not DropDownOpen Then
            tbSearch.Text = tb.Text
            Dim pts As Point = PointToScreen(tb.Location)
            'tsDropDown.Show(pts.X, pts.Y + tb.Height)
            tsDropDown.Show(pts.X, pts.Y)
            tbSearch.Focus()
            tbSearch.SelectionStart = tbSearch.Text.Length
        End If

    End Sub

    Public Class ResizeableControl

        Private WithEvents mControl As Control
        Private mMouseDown As Boolean = False
        Private mEdge As EdgeEnum = EdgeEnum.None
        Private mWidth As Integer = 4
        Private mOutlineDrawn As Boolean = False

        Private Enum EdgeEnum
            None
            Right
            Left
            Top
            Bottom
            TopLeft
        End Enum

        Public Sub New(ByVal Control As Control)
            mControl = Control
        End Sub

        Private Sub mControl_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mControl.MouseDown
            If e.Button = Windows.Forms.MouseButtons.Left Then
                mMouseDown = True
            End If
        End Sub

        Private Sub mControl_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mControl.MouseUp
            mMouseDown = False
        End Sub

        Private Sub mControl_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mControl.MouseMove
            Dim c As Control = CType(sender, Control)
            Dim g As Graphics = c.CreateGraphics

            Select Case mEdge
                Case EdgeEnum.TopLeft
                    g.FillRectangle(Brushes.Fuchsia, 0, 0, mWidth * 4, mWidth * 4)
                    mOutlineDrawn = True
                Case EdgeEnum.Left
                    g.FillRectangle(Brushes.Fuchsia, 0, 0, mWidth, c.Height)
                    mOutlineDrawn = True
                Case EdgeEnum.Right
                    g.FillRectangle(Brushes.Fuchsia, c.Width - mWidth, 0, c.Width, c.Height)
                    mOutlineDrawn = True
                Case EdgeEnum.Top
                    g.FillRectangle(Brushes.Fuchsia, 0, 0, c.Width, mWidth)
                    mOutlineDrawn = True
                Case EdgeEnum.Bottom
                    g.FillRectangle(Brushes.Fuchsia, 0, c.Height - mWidth, c.Width, mWidth)
                    mOutlineDrawn = True
                Case EdgeEnum.None
                    If mOutlineDrawn Then
                        c.Refresh()
                        mOutlineDrawn = False
                    End If
            End Select

            If mMouseDown And mEdge <> EdgeEnum.None Then
                c.SuspendLayout()
                Select Case mEdge
                    Case EdgeEnum.TopLeft
                        c.SetBounds(c.Left + e.X, c.Top + e.Y, c.Width, c.Height)
                    Case EdgeEnum.Left
                        c.SetBounds(c.Left + e.X, c.Top, c.Width - e.X, c.Height)
                    Case EdgeEnum.Right
                        c.SetBounds(c.Left, c.Top, c.Width - (c.Width - e.X), c.Height)
                    Case EdgeEnum.Top
                        c.SetBounds(c.Left, c.Top + e.Y, c.Width, c.Height - e.Y)
                    Case EdgeEnum.Bottom
                        c.SetBounds(c.Left, c.Top, c.Width, c.Height - (c.Height - e.Y))
                End Select
                c.ResumeLayout()
            Else
                Select Case True
                    Case e.X <= (mWidth * 4) And e.Y <= (mWidth * 4) 'top left corner
                        c.Cursor = Cursors.SizeAll
                        mEdge = EdgeEnum.TopLeft
                    Case e.X <= mWidth 'left edge
                        c.Cursor = Cursors.VSplit
                        mEdge = EdgeEnum.Left
                    Case e.X > c.Width - (mWidth + 1) 'right edge
                        c.Cursor = Cursors.VSplit
                        mEdge = EdgeEnum.Right
                    Case e.Y <= mWidth 'top edge
                        c.Cursor = Cursors.HSplit
                        mEdge = EdgeEnum.Top
                    Case e.Y > c.Height - (mWidth + 1) 'bottom edge
                        c.Cursor = Cursors.HSplit
                        mEdge = EdgeEnum.Bottom
                    Case Else 'no edge
                        c.Cursor = Cursors.Default
                        mEdge = EdgeEnum.None
                End Select
            End If
        End Sub

        Private Sub mControl_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles mControl.MouseLeave
            Dim c As Control = CType(sender, Control)
            mEdge = EdgeEnum.None
            c.Refresh()
        End Sub

    End Class

End Class
