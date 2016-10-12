Imports System

Namespace Spreadsheets
    'Friend Class Spreadsheet
    '    ' Methods
    '    Public Sub Display()
    '        Dim col As Integer
    '        For col = 0 To Me.Cells.GetLength(1) - 1
    '            Dim row As Integer
    '            For row = 0 To Me.Cells.GetLength(0) - 1
    '                If (Not Me.Cells(col, row) Is Nothing) Then
    '                    Console.WriteLine(String.Concat(New Object() { "Row (", row, ") Col (", col, ") Value (", Me.State(col, row).ToString, ")" }))
    '                End If
    '            Next row
    '        Next col
    '    End Sub

    '    Public Sub Execute()
    '        Console.WriteLine(String.Concat(New Object() { "Rows (", Me.Cells.GetLength(0), ") Cols (", Me.Cells.GetLength(1), ")" }))
    '        Dim col As Integer
    '        For col = 0 To Me.Cells.GetLength(1) - 1
    '            Dim row As Integer
    '            For row = 0 To Me.Cells.GetLength(0) - 1
    '                If (Not Me.Cells(col, row) Is Nothing) Then
    '                    Me.State(col, row) = RaiseEvent Me.Cells(col, row)()
    '                End If
    '            Next row
    '        Next col
    '    End Sub


    '    ' Fields
    '    Public Cells As Func(Of Object)(0 To .,0 To .) = New Func(Of Object)(10  - 1, 10  - 1) {}
    '    Public State As Object(0 To .,0 To .) = New Object(10  - 1, 10  - 1) {}
    'End Class
End Namespace

