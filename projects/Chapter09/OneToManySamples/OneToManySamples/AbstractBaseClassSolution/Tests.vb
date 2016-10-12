Imports System
Imports System.Collections.Generic

Namespace AbstractBaseClassSolution
    Friend Class Tests
        ' Methods
        Public Shared Sub RunAll()
            Dim elements As IList(Of Integer) = New List(Of Integer)
            elements.Add(1)
            elements.Add(2)
            elements.Add(3)
            Console.WriteLine(String.Concat(New Object() { "RunningTotal (", TryCast(New RunningTotal(elements).Iterate,RunningTotal).Total, ") Maximum Value (", TryCast(New MaximumValue(elements).Iterate,MaximumValue).MaxValue, ")" }))
        End Sub

    End Class
End Namespace

