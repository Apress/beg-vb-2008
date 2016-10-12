Imports Devspace.Trader.Common
Imports System

Namespace ServerSpreadsheet
    Public Interface IWorksheetBase
        Inherits IDebug

        Sub Dimension(ByVal rows As Integer, ByVal cols As Integer)
        ReadOnly Property MaxCols() As Integer
        ReadOnly Property MaxRows() As Integer
    End Interface
End Namespace

