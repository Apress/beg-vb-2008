Imports System

Namespace ServerSpreadsheet
    Public Interface IWorksheetIdentifier
        ReadOnly Property FullnameIdentifier() As String
        Property Identifier() As String
    End Interface
End Namespace

