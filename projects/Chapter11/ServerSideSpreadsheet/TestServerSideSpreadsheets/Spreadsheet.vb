Class Spreadsheet
    Public Cells As Func(Of Object)(,)
    Public State As Object(,)

    Public Sub New()
        Cells = New Func(Of Object)(10, 10) {}
        State = New Object(10, 10) {}
    End Sub

    Public Sub Execute()
        For col As Integer = 0 To Cells.GetLength(1)
            For row As Integer = 0 To Cells.GetLength(0)
                If Not Cells(col, row) Is Nothing Then
                    State(col, row) = Cells(col, row)()
                End If
            Next
        Next

    End Sub
End Class
