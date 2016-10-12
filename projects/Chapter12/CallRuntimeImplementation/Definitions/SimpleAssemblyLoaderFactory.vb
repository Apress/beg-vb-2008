Imports System

Public Class SimpleAssemblyLoaderFactory
    ' Methods
    Public Shared Function Instantiate(ByVal path As String) As IFactory(Of String)
        Return New SimpleAssemblyLoader(path)
    End Function

End Class

