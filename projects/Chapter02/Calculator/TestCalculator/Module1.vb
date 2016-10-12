Imports Calculator
Imports System

Module Module1
    Public Sub AddFractionalNumbers()
        Dim value As Single = 10000.0 + 0.000001
        Console.WriteLine(String.Format("Value ({0})", value))
    End Sub

    Public Sub AddFractionalNumbersToWhole()
        Dim total As Integer = CType(1.2, Integer) + CType(1.5, Integer)
        If (total <> 3) Then
            Console.WriteLine("oops something went wrong")
        End If
    End Sub

    Public Sub TestReallyBigNumbers()
        Dim total As Integer = Operations.Add(&H77359400, &H77359400)
        If (total <> &HEE6B2800) Then
            Console.WriteLine(("Error found(" & total & ") should have been (4000000000)"))
        End If
    End Sub
    Public Sub TestReallyBigNumbers2()
        Dim total As Integer = Operations.Add(2000000000, 2000000000)
        If (total <> 4000000000) Then
            Console.WriteLine(("Error found(" & total & ") should have been (4000000000)"))
        End If
    End Sub

    Public Sub TestSimpleAddition()
        Dim result As Integer = Operations.Add(1, 2)

        If (result <> 3) Then
            Console.WriteLine("Ooops 1 and 2 does not equal 3")
        End If
    End Sub

    Sub Main()
        'TestSimpleAddition()
        AddFractionalNumbers()
        'TestReallyBigNumbers2()
        'AddFractionalNumbersToWhole()
        Console.ReadKey()
    End Sub

End Module

