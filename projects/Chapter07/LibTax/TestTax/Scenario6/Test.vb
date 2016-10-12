Imports System

Namespace Scenario6
    Module Test
        ' Methods
        Public Sub Run()
            Dim implementation As New ImplementationDerived
            Dim inst As IInterface = implementation
            implementation.Method()
            inst.Method()
        End Sub

    End Module
End Namespace

