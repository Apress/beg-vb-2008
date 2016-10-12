Imports Devspace.Trader.Common
Imports System

Namespace ServerSpreadsheet
    Public Interface IWorksheet(Of StateType)
        Inherits IWorksheetBase, IDebug

        Sub AssignCellCalculation(ByVal coords As SheetCoordinate, ByVal cb As Func(Of IWorksheet(Of StateType), Integer, Integer, StateType))
        Sub AssignCellCalculation(ByVal row As Integer, ByVal col As Integer, ByVal cb As Func(Of IWorksheet(Of StateType), Integer, Integer, StateType))
        Sub AssignColCalculation(ByVal col As Integer, ByVal cb As Func(Of IWorksheet(Of StateType), Integer, Integer, StateType))
        Sub Calculate()
        Function Calculate(ByVal coords As SheetCoordinate) As StateType
        Function Calculate(ByVal row As Integer, ByVal col As Integer) As StateType
        Sub CalculateCol(ByVal col As Integer)
        Sub CalculateRow(ByVal row As Integer)
        Function GetCellState(ByVal coords As SheetCoordinate) As StateType
        Function GetCellState(ByVal row As Integer, ByVal col As Integer) As StateType
        Sub SetCellState(ByVal coords As SheetCoordinate, ByVal val As StateType)
        Sub SetCellState(ByVal row As Integer, ByVal col As Integer, ByVal val As StateType)
        ReadOnly Property Data() As StateType(,)
    End Interface
End Namespace

