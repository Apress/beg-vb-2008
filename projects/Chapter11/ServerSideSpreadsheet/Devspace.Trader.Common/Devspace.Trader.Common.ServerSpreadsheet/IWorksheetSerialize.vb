Imports System

Namespace ServerSpreadsheet
    Public Interface IWorksheetSerialize
        Sub AssignCellState(ByVal row As Integer, ByVal col As Integer, ByVal value As Object)
        Sub AssignCellState(Of ValueType)(ByVal row As Integer, ByVal col As Integer, ByVal value As ValueType)
    End Interface
End Namespace

