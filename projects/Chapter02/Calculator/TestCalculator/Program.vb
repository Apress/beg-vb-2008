Imports Calculator
Imports System

Namespace TestCalculator
    Friend Class Program
        ' Methods
        Public Shared Sub AddFractionalNumbers()
            Dim value As Single = 10000!
            Console.WriteLine(String.Format("Value ({0})", value))
        End Sub

        Public Shared Sub AddFractionalNumbersToWhole()
            Dim total As Integer = 2
            If (total <> 2) Then
                Console.WriteLine("oops something went wrong")
            End If
        End Sub

        Private Shared Sub Main(ByVal args As String())
            Program.TestSimpleAddition
            Program.AddFractionalNumbers
            Console.ReadKey
        End Sub

        Public Shared Sub TestReallyBigNumbers()
            Dim total As Integer = Operations.Add(&H77359400, &H77359400)
            If (total <> &HEE6B2800) Then
                Console.WriteLine(("Error found(" & total & ") should have been (4000000000)"))
            End If
        End Sub

        Public Shared Sub TestSimpleAddition()
            If (Operations.Add(1, 2) <> 3) Then
                Console.WriteLine("Ooops 1 and 2 does not equal 3")
            End If
        End Sub

    End Class
End Namespace

