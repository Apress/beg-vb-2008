Imports Devspace.Trader.Common
Imports System
Imports System.Reflection

Namespace ServerSpreadsheet
    <DefaultMember("Item")> _
    Public Interface IWorkbook
        Inherits IDebug

        Function GetSheet(Of StateType)(ByVal identifier As String) As IWorksheet(Of StateType)
        ReadOnly Property Identifier() As String
        Default Property Item(ByVal identifier As String) As IWorksheetBase
    End Interface

End Namespace

