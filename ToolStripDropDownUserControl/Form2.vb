Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dt As DataTable = New DataTable
        With dt
            With .Columns
                .Add("SN")
                .Add("External")
                .Add("Table")
            End With
            For i As Integer = 1 To 5
                .Rows.Add({i, $"Person {i}", $"Surname {i * 10}"})
            Next
        End With
        UcTextDrop2.LoadExternalData(dt)

        UcTextDrop2.GridDataSource = dt
    End Sub
End Class