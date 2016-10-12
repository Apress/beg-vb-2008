Imports System

Namespace ServerSpreadsheet
    Public MustInherit Class BaseWorksheet(Of StateType)
        Inherits TraderBaseClass
        ' Methods
        Public Sub New(ByVal worksheet As IWorksheet(Of StateType))
            Me._worksheet = worksheet
        End Sub

        Public Sub AssignCellCalculation(ByVal coords As SheetCoordinate, ByVal cb As Func(Of IWorksheet(Of StateType), Integer, Integer, StateType))
            Me._worksheet.AssignCellCalculation(coords.Row, coords.Column, cb)
        End Sub

        Public Sub AssignCellCalculation(ByVal row As Integer, ByVal col As Integer, ByVal cb As Func(Of IWorksheet(Of StateType), Integer, Integer, StateType))
            Me._worksheet.AssignCellCalculation(row, col, cb)
        End Sub

        Public Sub AssignColCalculation(ByVal col As Integer, ByVal cb As Func(Of IWorksheet(Of StateType), Integer, Integer, StateType))
            Me._worksheet.AssignColCalculation(col, cb)
        End Sub

        Public Overridable Sub Calculate()
            Me._worksheet.Calculate()
        End Sub

        Public Sub Dimension(ByVal rows As Integer, ByVal cols As Integer)
            Me._worksheet.Dimension(rows, cols)
        End Sub

        Public Function GetCellState(ByVal coords As SheetCoordinate) As StateType
            Return Me._worksheet.GetCellState(coords.Row, coords.Column)
        End Function

        Public Function GetCellState(ByVal row As Integer, ByVal col As Integer) As StateType
            Return Me._worksheet.GetCellState(row, col)
        End Function

        Public Sub SetCellState(ByVal coords As SheetCoordinate, ByVal val As StateType)
            Me._worksheet.SetCellState(coords.Row, coords.Column, val)
        End Sub

        Public Sub SetCellState(ByVal row As Integer, ByVal col As Integer, ByVal val As StateType)
            Me._worksheet.SetCellState(row, col, val)
        End Sub

        Public Overrides Function ToString() As String
            Return Me._worksheet.ToString
        End Function


        ' Properties
        Public ReadOnly Property Worksheet() As IWorksheet(Of StateType)
            Get
                Return Me._worksheet
            End Get
        End Property


        ' Fields
        Protected _worksheet As IWorksheet(Of StateType)
    End Class
End Namespace

