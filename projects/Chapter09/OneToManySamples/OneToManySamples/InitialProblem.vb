Namespace InitialProblem
    MustInherit Class IteratorBaseClass
        Protected Sub New(ByVal collection As IList(Of Integer))
            _collection = collection
        End Sub

        Public Function Iterate() As IteratorBaseClass
            Dim element As Integer
            For Each element In Me._collection
                ProcessElement(element)
            Next
            Return Me
        End Function

        Protected MustOverride Sub ProcessElement(ByVal value As Integer)

        Private _collection As IList(Of Integer)
    End Class

    Class RunningTotal
        Inherits IteratorBaseClass
        Public Sub New(ByVal collection As IList(Of Integer))
            MyBase.New(collection)
            Total = 0
        End Sub

        Protected Overrides Sub ProcessElement(ByVal value As Integer)
            Total = (Total + value)
        End Sub

        Public Total As Integer
    End Class
    Class MaximumValue
        Inherits IteratorBaseClass
        Public Sub New(ByVal collection As IList(Of Integer))
            MyBase.New(collection)
            MaxValue = Integer.MinValue
        End Sub

        Protected Overrides Sub ProcessElement(ByVal value As Integer)
            If (value > MaxValue) Then
                MaxValue = value
            End If
        End Sub

        Public MaxValue As Integer
    End Class

    Friend Module Tests
        Private Sub ExampleRunningTotal()
            Dim elements As IList(Of Integer) = New List(Of Integer)
            elements.Add(1)
            elements.Add(2)
            elements.Add(3)
            Dim runningTotal As Integer = 0
            Dim value As Integer
            For Each value In elements
                runningTotal = (runningTotal + value)
            Next
            Console.WriteLine(("RunningTotal (" & runningTotal & ")"))
        End Sub
        Private Sub ExampleMaximumValue()
            Dim elements As IList(Of Integer) = New List(Of Integer)
            elements.Add(1)
            elements.Add(2)
            elements.Add(3)
            Dim maxValue As Integer = Integer.MinValue
            For Each value In elements
                If (value > maxValue) Then
                    maxValue = value
                End If
            Next
            Console.WriteLine(("Maximum value is (" & maxValue & ")"))
        End Sub
        Private Sub ExampleWithClasses()
            Dim elements As IList(Of Integer) = New List(Of Integer)
            elements.Add(1)
            elements.Add(2)
            elements.Add(3)
            Console.WriteLine( _
                              "RunningTotal (" & TryCast(New RunningTotal(elements).Iterate, RunningTotal).Total & _
                               ") Maximum Value (" & TryCast(New MaximumValue(elements).Iterate, MaximumValue).MaxValue & ")")

        End Sub

        Public Sub RunAll()
            ExampleRunningTotal()
        End Sub
    End Module
End Namespace