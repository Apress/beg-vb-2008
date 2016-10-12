Imports ServerSideSpreadsheet.ServerSideSpreadsheet
Imports Devspace.Trader.Common.ServerSpreadsheet
Imports System

Namespace TestServerSideSpreadsheets
    Friend Module TestAverage

        Private Sub TestConversion()
            Dim sheetBase As IWorksheetBase = SpreadsheetManager.CreateEmpytWorksheet(Of Double)("")
            sheetBase.Dimension(10, 10)
            Dim sheet As IWorksheetSerialize = TryCast(sheetBase, IWorksheetSerialize)
            sheet.AssignCellState(Of String)(0, 0, "10.0")
            Console.WriteLine(sheet.ToString)
        End Sub

        Private Sub TestWorkbook()
            Dim workbook As IWorkbook = SpreadsheetManager.CreateEmptyWorkbook("example")
            Dim average As New Average(workbook.GetSheet(Of Double)("average"))
            average.AddItems(New Double() {1, 2, 3})
            Console.WriteLine(average.ToString)
            average.Calculate()
            Console.WriteLine(average.ToString)
            Console.WriteLine(("Workbook contents (" & workbook.ToString & ")"))
        End Sub

        Function Average(ByVal worksheet As IWorksheet(Of Double), ByVal cellRow As Integer, ByVal cellCol As Integer)
            Dim runningTotal As Double = 0
            Dim row As Integer
            For row = 0 To cellRow - 1
                runningTotal = (runningTotal + worksheet.GetCellState(row, 0))
            Next row
            Return (runningTotal / CDbl(cellRow))
        End Function

        Private Sub TestWorkbookRaw()
            Dim row As Integer
            Dim sheetAverage As IWorksheet(Of Double) = SpreadsheetManager.CreateEmpytWorksheet(Of Double)("")
            Dim items As Double() = New Double() {1, 2, 3}
            sheetAverage.Dimension((items.Length + 10), 3)
            For row = 0 To items.Length - 1
                sheetAverage.SetCellState(row, 0, items(row))
            Next row
            sheetAverage.AssignCellCalculation(items.Length, 0, AddressOf Average)
            For row = 0 To items.Length - 1
                sheetAverage.AssignCellCalculation(row, 1, Function(worksheet As IWorksheet(Of Double), cellRow As Integer, cellCol As Integer) _
                 (worksheet.GetCellState(cellRow, 0) - worksheet.Calculate(items.Length, 0)))
            Next row
            sheetAverage.Calculate()
            Console.WriteLine(sheetAverage.ToString)
        End Sub

        Private Sub TestWorksheet()
            Dim average As New Average(SpreadsheetManager.CreateEmpytWorksheet(Of Double)("average"))
            average.AddItems(New Double() {1, 2, 3})
            Console.WriteLine(average.ToString)
            average.Calculate()
            Console.WriteLine(average.ToString)
        End Sub
        Public Sub RunAll()
            TestAverage.TestWorkbookRaw()
        End Sub

    End Module

End Namespace

