Imports System
Imports System.Runtime.CompilerServices

Namespace ServerSpreadsheet
    Public Delegate Function CellCalculation(Of StateType)(ByVal worksheet As IWorksheet(Of StateType), ByVal row As Integer, ByVal col As Integer) As StateType
End Namespace

