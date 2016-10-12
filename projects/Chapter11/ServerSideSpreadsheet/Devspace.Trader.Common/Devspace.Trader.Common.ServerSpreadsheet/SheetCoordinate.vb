Imports System
Imports System.Runtime.InteropServices

Namespace ServerSpreadsheet
    Public Structure SheetCoordinate
        Public Row As Integer
        Public Column As Integer
        Public Sub New(ByVal row As Integer, ByVal column As Integer)
            If (row < 0) Then
                Throw New ArgumentOutOfRangeException("Row is below zero")
            End If
            If (column < 0) Then
                Throw New ArgumentOutOfRangeException("Column is below zero")
            End If
            Me.Row = row
            Me.Column = column
        End Sub

        Public ReadOnly Property OneUp() As SheetCoordinate
            Get
                Return New SheetCoordinate((Me.Row - 1), Me.Column)
            End Get
        End Property

        Public ReadOnly Property OneDown() As SheetCoordinate
            Get
                Return New SheetCoordinate((Me.Row + 1), Me.Column)
            End Get
        End Property

        Public ReadOnly Property OneLeft() As SheetCoordinate
            Get
                Return New SheetCoordinate(Me.Row, (Me.Column - 1))
            End Get
        End Property

        Public ReadOnly Property OneRight() As SheetCoordinate
            Get
                Return New SheetCoordinate(Me.Row, (Me.Column + 1))
            End Get
        End Property

    End Structure
End Namespace

