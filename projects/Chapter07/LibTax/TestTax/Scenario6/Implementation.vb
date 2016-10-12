Imports System

Namespace Scenario6
    Friend Class Implementation
        Implements IInterface
        ' Methods
        Public Overridable Sub Method() Implements IInterface.Method
            Console.WriteLine("Implementation.Method")
        End Sub

    End Class
End Namespace

