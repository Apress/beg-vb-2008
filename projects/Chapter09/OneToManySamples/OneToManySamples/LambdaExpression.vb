Namespace LambdaExpressions
    Delegate Function D() As Integer

    Delegate Function CalculateSalesTax(ByVal amount As Double) As Double

    Delegate Function TestIfApplicable(ByVal amount As Double) As Boolean

    Module Tests


        Function M() As D()
            Dim a(9) As D

            For i As Integer = 0 To 9
                Dim x
                a(i) = Function() x
                End

                x += 1
            Next i

            Return a
        End Function

        Sub RunCounter()
            Dim y() As D = M()

            For i As Integer = 0 To 9
                Console.Write(y(i)() & " ")
            Next i
        End Sub

        Function PrepSalesTax(ByVal salesTax As Double) As CalculateSalesTax
            Return Function(amount As Double) (salesTax * amount) + amount
        End Function
        Sub CalculateTax()
            Dim calculate = Function(tax As Double, amount As Double) (tax * amount) + amount

            Console.WriteLine("Tax (" & calculate(0.1, 100) & ")")
        End Sub
        Sub ContextSalesTax()
            Dim quebecTax = PrepSalesTax(0.15)

            Console.WriteLine("Tax (" & quebecTax(100) & ")")
        End Sub

        Function TwoLevelSalesTax(ByVal minimumSalesTax As Double) As CalculateSalesTax
            Return Function(amount As Double) If(amount > minimumSalesTax, (0.15 * amount) + amount, (0.1 * amount) + amount)
            'Dim val = If( (minimumSalesTax < 10, ss)

        End Function

        Public Sub RunAll()
            'CalculateTax()
            'ContextSalesTax()
            Dim val = 10
            Dim obj As Object
            Console.WriteLine("Is Two greater than ten (" & If(val < 10, "no", "yes") & ")")
            Console.WriteLine("Is Two greater than ten (" & If(obj, "yes") & ")")
        End Sub
    End Module

End Namespace
