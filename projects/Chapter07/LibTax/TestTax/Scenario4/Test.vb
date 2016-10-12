Imports System

Namespace Scenario4
    Friend Class Test
        ' Methods
        Public Shared Sub Run()
            Dim implementation As New Implementation
            Dim inst1 As IInterface1 = implementation
            Dim inst2 As IInterface1 = implementation
            inst1.Method
            inst2.Method
        End Sub

    End Class
End Namespace

