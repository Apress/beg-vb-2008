Imports System

Namespace Scenario4
    Friend Class Implementation
        Implements IInterface1, IInterface2
        ' Methods
        Private Sub Method1() Implements IInterface1.Method
            Console.WriteLine("Implementation.IInterface1.Method")
        End Sub

        Private Sub Method() Implements IInterface2.Method
            Console.WriteLine("Implementation.IInterface1.Method")
        End Sub

    End Class
End Namespace

