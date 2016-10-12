Imports System
Imports Devspace.Trader.Common.ServerSpreadsheet

Namespace ServerSideSpreadsheet
    Public Class Average
        Inherits BaseWorksheet(Of Double)

        Public Sub New(ByVal worksheet As IWorksheet(Of Double))
            MyBase.New(worksheet)
        End Sub

        Function CalculateAverage(ByVal worksheet As IWorksheet(Of Double), ByVal cellRow As Integer, ByVal cellCol As Integer) As String
            Dim runningTotal As Double = 0
            Dim row As Integer
            For row = 0 To cellRow - 1
                runningTotal = (runningTotal + worksheet.GetCellState(row, 0))
            Next row
            Return (runningTotal / CDbl(cellRow))
        End Function

        Public Sub AddItems(ByVal items As Double())
            Dim row As Integer
            MyBase.Dimension((items.Length + 10), 3)
            For row = 0 To items.Length - 1
                MyBase.SetCellState(row, 0, items(row))
            Next row
            MyBase.AssignCellCalculation(items.Length, 0, AddressOf CalculateAverage)
            For row = 0 To items.Length - 1
                MyBase.AssignCellCalculation(row, 1, Function(worksheet As IWorksheet(Of Double), cellRow As Integer, cellCol As Integer) _
                    (worksheet.GetCellState(cellRow, 0) - worksheet.Calculate(items.Length, 0)))
            Next row
        End Sub

    End Class
End Namespace

