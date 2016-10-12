Public Class GenericsContainer(Of ManagedType)
    Private _managed As ManagedType

    Public Sub New()

    End Sub
    Public Sub New(ByVal toManage As ManagedType)
        _managed = toManage
    End Sub

    Public ReadOnly Property Managed() As ManagedType
        Get
            Return Me._managed
        End Get
    End Property

    Public Sub AssignState(Of ValueType)(ByVal value As ValueType)
        If GetType(ManagedType).IsAssignableFrom(GetType(ValueType)) Then
            _managed = DirectCast(DirectCast(value, Object), ManagedType)
        ElseIf TypeOf (value) Is String And GetType(Double).IsAssignableFrom(GetType(ManagedType)) Then
            Dim obj As Object = DirectCast(value, Object)
            Dim dValue As Double = Double.Parse(CStr(obj))
            Dim objDValue As Object = CType(dValue, Object)
            _managed = DirectCast(objDValue, ManagedType)
        Else
            Throw New InvalidCastException("Could not perform conversion")
        End If
    End Sub
    Public Overrides Function ToString() As String
        Return "(" & _managed.ToString() & ")"
    End Function
End Class



Module Module1

    Sub LambdaProblem()
        Dim animals(1) As Func(Of String)

        Dim animal1 = "cow"
        animals(0) = Function() animal1

        Dim animal2 = "horse"
        animals(1) = Function() animal2

        For Each callAnimal In animals
            Console.WriteLine(callAnimal())
        Next
    End Sub

    Sub LambdaSolution()
        Dim counterFunc(10) As Func(Of Integer)


        For counter As Integer = 0 To 10
            Dim temp = counter
            counterFunc(counter) = Function() temp
        Next

        For counter As Integer = 0 To 10
            Console.WriteLine("(" & counterFunc(counter)() & ")")
        Next

    End Sub
    Sub GenericsContainerExample()
        Dim cls = New GenericsContainer(Of Double)()
        cls.AssignState("2.5")
        Console.WriteLine("Value is (" & cls.ToString() & ")")
    End Sub
    Sub Main()
        'LambdaProblem()
        'LambdaSolution()
        GenericsContainerExample()
        Console.ReadKey()
    End Sub

End Module
