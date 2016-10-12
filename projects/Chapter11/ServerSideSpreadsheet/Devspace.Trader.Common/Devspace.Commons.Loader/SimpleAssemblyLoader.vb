Imports Devspace.Trader.Common.Automators
Imports System
Imports System.Reflection

Namespace Loader
    Public Class SimpleAssemblyLoader
        Implements IFactory(Of String)
        ' Methods
        Public Sub New(ByVal path As String)
            Me._assembly = Assembly.Load(AssemblyName.GetAssemblyName(path))
        End Sub

        Public Function Instantiate(Of type As Class)(ByVal typeidentifier As String) As type Implements IFactory(Of String).Instantiate
            Return TryCast(Me._assembly.CreateInstance(typeidentifier), type)
        End Function


        ' Fields
        Private _assembly As Assembly
    End Class
End Namespace

