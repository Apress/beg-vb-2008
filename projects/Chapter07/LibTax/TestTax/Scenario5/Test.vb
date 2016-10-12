Imports System

Namespace Scenario5
    Friend Class Test
        ' Methods
        Public Shared Sub Run()
            Dim implementation As New ImplementationDerived
            Dim inst As IInterface = implementation
            implementation.Method
            inst.Method
        End Sub

    End Class
End Namespace

