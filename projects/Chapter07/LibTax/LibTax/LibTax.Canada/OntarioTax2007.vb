Imports System

Namespace LibTax.Canada
    Friend Class OntarioTax2007
        ' Methods
        Public Shared Function TaxRate(ByVal income As Double) As Double
            Dim runningTotal As Double = 0
            If (income > 120887) Then
                runningTotal = (runningTotal + ((income - 120887) * 0.4641))
                income = 120887
            End If
            If (income > 74357) Then
                runningTotal = (runningTotal + ((income - 74357) * 0.4341))
                income = 74357
            End If
            If (income > 73625) Then
                runningTotal = (runningTotal + ((income - 73625) * 0.3941))
                income = 73625
            End If
            If (income > 70976) Then
                runningTotal = (runningTotal + ((income - 70976) * 0.3539))
                income = 70976
            End If
            If (income > 62485) Then
                runningTotal = (runningTotal + ((income - 62485) * 0.3298))
                income = 62485
            End If
            If (income > 37178) Then
                runningTotal = (runningTotal + ((income - 37178) * 0.3115))
                income = 37178
            End If
            If (income > 35448) Then
                runningTotal = (runningTotal + ((income - 35448) * 0.2465))
                income = 35448
            End If
            runningTotal = (runningTotal + (income * 0.155))
            Return (runningTotal / income)
        End Function

    End Class
End Namespace

