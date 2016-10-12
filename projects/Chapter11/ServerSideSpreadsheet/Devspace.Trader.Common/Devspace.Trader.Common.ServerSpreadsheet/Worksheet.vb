Imports Devspace.Trader.Common
Imports System
Imports System.Text

Namespace ServerSpreadsheet
    Friend Class Worksheet(Of StateType)
        Inherits TraderBaseClass
        Implements IWorksheet(Of StateType), IWorksheetBase, IDebug, IWorksheetSerialize

        Private _generateRowCounter As Boolean
        Private _identifier As String
        Private _maxCols As Integer
        Private _maxRows As Integer
        Private CalculationVersion As Integer(,)
        Private Cells As Func(Of IWorksheet(Of StateType), Integer, Integer, StateType)(,)
        Private CellState As StateType(,)
        Private ColCells As Func(Of IWorksheet(Of StateType), Integer, Integer, StateType)()
        Private CurrVersion As Integer

        Public Sub New()
        End Sub

        Public Sub New(ByVal identifier As String)
            _identifier = identifier
        End Sub

        Public Sub AssignCellCalculation(ByVal coords As SheetCoordinate, ByVal cb As Func(Of IWorksheet(Of StateType), Integer, Integer, StateType)) Implements IWorksheet(Of StateType).AssignCellCalculation
            AssignCellCalculation(coords.Row, coords.Column, cb)
        End Sub

        Public Sub AssignCellCalculation(ByVal row As Integer, ByVal col As Integer, ByVal cb As Func(Of IWorksheet(Of StateType), Integer, Integer, StateType)) Implements IWorksheet(Of StateType).AssignCellCalculation
            Cells(row, col) = cb
        End Sub

        Public Sub AssignCellState(Of ValueType)(ByVal row As Integer, ByVal col As Integer, ByVal value As ValueType) Implements IWorksheetSerialize.AssignCellState
            If GetType(StateType).IsAssignableFrom(GetType(ValueType)) Then
                CellState(row, col) = DirectCast(DirectCast(value, Object), StateType)
            ElseIf TypeOf (value) Is String And GetType(Double).IsAssignableFrom(GetType(StateType)) Then
                Dim obj As Object = DirectCast(value, Object)
                Dim dValue As Double = Double.Parse(CStr(obj))
                Dim objDValue As Object = CType(dValue, Object)
                CellState(row, col) = DirectCast(objDValue, StateType)
            Else
                Throw New InvalidCastException("Could not perform conversion")
            End If
        End Sub

        Public Sub AssignCellState(ByVal row As Integer, ByVal col As Integer, ByVal value As Object) Implements IWorksheetSerialize.AssignCellState
            CellState(row, col) = DirectCast(value, StateType)
        End Sub

        Public Sub AssignColCalculation(ByVal col As Integer, ByVal cb As Func(Of IWorksheet(Of StateType), Integer, Integer, StateType)) Implements IWorksheet(Of StateType).AssignColCalculation
            ColCells(col) = cb
        End Sub

        Public Sub Calculate() Implements IWorksheet(Of StateType).Calculate
            CurrVersion += 1
            Dim row As Integer
            For row = 0 To Cells.GetLength(0) - 1
                Dim col As Integer
                For col = 0 To Cells.GetLength(1) - 1
                    If (Not Cells(row, col) Is Nothing) Then
                        Calculate(row, col)
                    End If
                Next col
            Next row
        End Sub

        Public Function Calculate(ByVal coords As SheetCoordinate) As StateType Implements IWorksheet(Of StateType).Calculate
            Return Calculate(coords.Row, coords.Column)
        End Function

        Public Function Calculate(ByVal row As Integer, ByVal col As Integer) As StateType Implements IWorksheet(Of StateType).Calculate
            If (CurrVersion > CalculationVersion(row, col)) Then
                CellState(row, col) = Cells(row, col)(Me, row, col)
                CalculationVersion(row, col) = CurrVersion
            End If
            Return CellState(row, col)
        End Function

        Public Sub CalculateCol(ByVal col As Integer) Implements IWorksheet(Of StateType).CalculateCol
            CurrVersion += 1
            If (Not ColCells(col) Is Nothing) Then
                Dim row As Integer
                For row = 0 To Cells.GetLength(0) - 1
                    CellState(row, col) = ColCells(col)(Me, row, col)
                Next row
            End If
        End Sub

        Public Sub CalculateRow(ByVal row As Integer) Implements IWorksheet(Of StateType).CalculateRow
            CurrVersion += 1
            Dim col As Integer
            For col = 0 To Cells.GetLength(1) - 1
                If (Not Cells(row, col) Is Nothing) Then
                    Calculate(row, col)
                End If
            Next col
        End Sub

        Public Sub Dimension(ByVal rows As Integer, ByVal cols As Integer) Implements IWorksheetBase.Dimension
            CellState = New StateType(rows - 1, cols - 1) {}
            Cells = New Func(Of IWorksheet(Of StateType), Integer, Integer, StateType)(rows - 1, cols - 1) {}
            CalculationVersion = New Integer(rows - 1, cols - 1) {}
            ColCells = New Func(Of IWorksheet(Of StateType), Integer, Integer, StateType)(cols - 1) {}
            CurrVersion = 0
            _maxRows = rows
            _maxCols = cols
        End Sub

        Public Function GetCellState(ByVal coords As SheetCoordinate) As StateType Implements IWorksheet(Of StateType).GetCellState
            Return GetCellState(coords.Row, coords.Column)
        End Function

        Public Function GetCellState(ByVal row As Integer, ByVal col As Integer) As StateType Implements IWorksheet(Of StateType).GetCellState
            Return CellState(row, col)
        End Function

        Public Sub SetCellState(ByVal coords As SheetCoordinate, ByVal val As StateType) Implements IWorksheet(Of StateType).SetCellState
            SetCellState(coords.Row, coords.Column, val)
        End Sub

        Public Sub SetCellState(ByVal row As Integer, ByVal col As Integer, ByVal val As StateType) Implements IWorksheet(Of StateType).SetCellState
            CellState(row, col) = val
            Cells(row, col) = Nothing
        End Sub

        Public Overrides Function ToString() As String
            Dim builder As New StringBuilder
            Dim row As Integer
            For row = 0 To Cells.GetLength(0) - 1
                Dim needComma As Boolean = False
                If _generateRowCounter Then
                    needComma = True
                    builder.Append(row)
                End If
                Dim col As Integer
                For col = 0 To Cells.GetLength(1) - 1
                    If needComma Then
                        builder.Append(",")
                    Else
                        needComma = True
                    End If
                    If (Not CellState(row, col) Is Nothing) Then
                        builder.Append(CellState(row, col).ToString)
                    End If
                Next col
                builder.Append(ChrW(10))
            Next row
            Return builder.ToString
        End Function


        Public ReadOnly Property Data() As StateType(,) Implements IWorksheet(Of StateType).Data
            Get
                Return CellState
            End Get
        End Property

        Public Property GenerateRowCounter() As Boolean
            Get
                Return _generateRowCounter
            End Get
            Set(ByVal value As Boolean)
                _generateRowCounter = value
            End Set
        End Property

        Public ReadOnly Property MaxCols() As Integer Implements IWorksheetBase.MaxCols
            Get
                Return _maxCols
            End Get
        End Property

        Public ReadOnly Property MaxRows() As Integer Implements IWorksheetBase.MaxRows
            Get
                Return _maxRows
            End Get
        End Property
    End Class
End Namespace

