Imports System

Namespace ServerSpreadsheet
    Public Interface ISpreadsheetSerializer
        Function Load(ByVal workbook As IWorkbook, ByVal path As String) As Boolean
        Function LoadSheet(Of DataType)(ByVal path As String, ByVal rows As Integer, ByVal cols As Integer) As IWorksheet(Of DataType)
        Sub Save(ByVal workbook As IWorkbook, ByVal path As String)
        Sub Save(ByVal path As String, ByVal worksheetIdentifier As String, ByVal worksheet As IWorksheetBase)
    End Interface
End Namespace

