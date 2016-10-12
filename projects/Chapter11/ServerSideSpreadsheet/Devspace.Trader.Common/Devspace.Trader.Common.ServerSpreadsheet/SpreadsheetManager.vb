Imports System

Namespace ServerSpreadsheet
    Public Module WorksheetIdentifiers
        Public Const Configuration = "configuration"
    End Module

    Public Class SpreadsheetManager
        ' Methods
        Public Shared Function CreateEmptyWorkbook(ByVal identifier As String) As IWorkbook
            Return New Workbook(identifier)
        End Function

        Public Shared Function CreateEmpytWorksheet(Of DataType)(ByVal identifier As String) As IWorksheet(Of DataType)
            Return New Worksheet(Of DataType)(identifier)
        End Function

    End Class
End Namespace

