Imports System

Public Class DynamicFactory
    ' Methods
    Public Sub New(ByVal loader As IFactory(Of String))
        Me._loader = loader
        Me._factory = Me._loader.Instantiate(Of IFactory(Of String))("Devspace.Factory")
    End Sub

    Public Function Instantiate(Of type As Class)(ByVal typeidentifier As String) As type
        Return Me._factory.Instantiate(Of type)(typeidentifier)
    End Function


    ' Fields
    Private _factory As IFactory(Of String)
    Private _loader As IFactory(Of String)
End Class

