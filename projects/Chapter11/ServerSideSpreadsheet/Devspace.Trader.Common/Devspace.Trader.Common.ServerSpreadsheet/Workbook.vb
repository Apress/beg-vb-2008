Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Reflection

Namespace ServerSpreadsheet
    <DefaultMember("Item")> _
    Friend Class Workbook
        Inherits TraderBaseClass
        Implements IWorkbook, IDebug

        Private _generateRowCounter As Boolean
        Private _identifier As String
        Private _worksheets As IDictionary(Of String, IWorksheetBase) = New Dictionary(Of String, IWorksheetBase)

        Public Sub New(ByVal identifier As String)
            _identifier = identifier
        End Sub

        Public Sub Clear()
            _worksheets.Clear()
        End Sub

        Public Function GetSheet(Of StateType)(ByVal identifier As String) As IWorksheet(Of StateType) _
        Implements IWorkbook.GetSheet
            SyncLock _worksheets
                Dim retval As IWorksheet(Of StateType) = Nothing
                If _worksheets.ContainsKey(identifier) Then
                    retval = TryCast(_worksheets.Item(identifier), IWorksheet(Of StateType))
                Else
                    retval = New Worksheet(Of StateType)(identifier)
                    _worksheets.Add(identifier, retval)
                End If
                Return retval
            End SyncLock
        End Function

        Public Overrides Function ToString() As String
            Dim buffer As String = ""
            Dim identifier As String
            For Each identifier In _worksheets.Keys
                buffer = (buffer & "Workbook (" & identifier & ")")
            Next
            Return buffer
        End Function


        ' Properties
        Public Property GenerateRowCounter() As Boolean
            Get
                Return _generateRowCounter
            End Get
            Set(ByVal value As Boolean)
                _generateRowCounter = value
            End Set
        End Property

        Public ReadOnly Property Identifier() As String Implements IWorkbook.Identifier
            Get
                Return _identifier
            End Get
        End Property

        Default Public Property Item(ByVal identifier As String) As IWorksheetBase Implements IWorkbook.Item
            Get
                Dim retval As IWorksheetBase = Nothing
                SyncLock _worksheets
                    If _worksheets.ContainsKey(identifier) Then
                        retval = _worksheets.Item(identifier)
                    End If
                End SyncLock
                Return retval
            End Get
            Set(ByVal value As IWorksheetBase)
                SyncLock _worksheets
                    If _worksheets.ContainsKey(identifier) Then
                        _worksheets.Remove(identifier)
                    End If
                    _worksheets.Add(identifier, value)
                End SyncLock
            End Set
        End Property
    End Class
End Namespace

