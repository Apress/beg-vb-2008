Imports System

Namespace Scenario3
    Friend Class Implementation
        Implements IInterface
        ' Methods
        Public Sub Method() Implements IInterface.Method
            Console.WriteLine("Implementation.Method")
        End Sub

    End Class
End Namespace

