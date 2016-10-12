Partial Class Example
    Partial Private Sub AddNumbers(ByVal value1 As Integer, ByVal value2 As Integer, ByRef response As Integer)
    End Sub

    Public Sub Method()
        Dim response = 0

        AddNumbers(1, 2, response)
        Console.WriteLine("Added numbers (" & response & ")")
    End Sub
End Class

Partial Class Example
    Private Sub AddNumbers(ByVal value1 As Integer, ByVal value2 As Integer, ByRef response As Integer)
        response = value1 + value2
    End Sub
End Class

Module Module1
    Class Example
        Const BaseValue As Integer = 10
        Public Sub AddNumbers(ByVal value1 As Integer, ByVal value2 As Integer, ByRef response As Integer)
            response = BaseValue + value1 + value2
        End Sub
    End Class

    Private Const isTall As Integer = 1
    Private Const wearsHats As Integer = 2
    Private Const runsSlow As Integer = 4

    Sub Addition()
        Dim a As Integer, b As Integer
        a = 10
        b = a = a + 1

        Console.WriteLine("(" & a & ")(" & b & ")")
    End Sub

    Sub Bitwise()
        Dim val = isTall Or wearsHats

        If (val And isTall) <> 0 Then
            Console.WriteLine("Person is tall")
        End If
    End Sub

    Sub ModTest()
        Dim divide As Integer = 10 / 3
        Dim result = 10 Mod 3
        Console.WriteLine("(" & divide & ")(" & result & ")")
    End Sub

    Sub DoIncrement()
        Dim a As Integer = 1

        a += 1
        a *= 10
        Dim value As Object = Nothing
        If value Is Nothing Then
            Console.WriteLine("yes a null value")
        End If
    End Sub

    Structure ExampleStructure
        Public value As Integer
    End Structure

    Sub Main()
        'TestConstraints.RunAll()
        'Addition()
        'Bitwise()
        'ModTest()
        'Dim ex As ExampleStructure = Nothing
        Dim nullableex As ExampleStructure?
        nullableex = Nothing
        nullableex = New ExampleStructure() With {.value = 10}
        Console.WriteLine("(" & nullableex.Value.value & ")")

        DoIncrement()
        Console.ReadKey()

    End Sub

End Module
