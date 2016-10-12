Imports System

Namespace Scenario3
    Friend Class Test
        ' Methods
        Public Shared Sub Run()
            Dim implementation As New Implementation
            Dim inst As IInterface = implementation
            implementation.Method
            inst.Method
        End Sub

    End Class
End Namespace

