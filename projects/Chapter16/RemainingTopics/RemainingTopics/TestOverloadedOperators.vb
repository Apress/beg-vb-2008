Imports System

Friend Class TestOverloadedOperators
    ' Methods
    Private Shared Sub CallMethod(ByVal val As ComplexType)
        'val = ComplexType.op_Increment(val)
        Console.WriteLine(("--- " & val.ToString))
    End Sub

    Private Shared Sub ComplexAdd()
        Dim a As New ComplexType(1, 10)
        Dim b As New ComplexType(2, 20)
        Dim c As ComplexType = (a + b)
JUMP_ACROSS:
    End Sub

    Private Shared Sub ComplexIncrement()
        Dim a As New ComplexType(1, 10)
        'a = ComplexType.op_Increment(a)
JUMP_ACROSS:
        Console.WriteLine(a.ToString)
        TestOverloadedOperators.CallMethod(a)
        Console.WriteLine(a.ToString)
        GoTo JUMP_ACROSS

    End Sub

    Public Shared Sub RunAll()
        TestOverloadedOperators.ComplexIncrement()
    End Sub

End Class

