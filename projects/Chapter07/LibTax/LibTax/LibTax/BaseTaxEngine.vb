Imports System

Namespace LibTax
    Public MustInherit Class BaseTaxEngine
        Implements ITaxEngine
        ' Methods
        Public Overridable Function CalculateTaxToPay(ByVal account As ITaxAccount) As Double Implements ITaxEngine.CalculateTaxToPay
            Me._calculatedTaxable = 0
            Dim income As ITaxIncome
            For Each income In account.Income
                If (Not income Is Nothing) Then
                    Me._calculatedTaxable = (Me._calculatedTaxable + income.TaxableAmount)
                End If
            Next
            Dim deduction As ITaxDeduction
            For Each deduction In account.Deductions
                If (Not deduction Is Nothing) Then
                    Me._calculatedTaxable = (Me._calculatedTaxable - deduction.Amount)
                End If
            Next
            Return (account.GetTaxRate(Me._calculatedTaxable) * Me._calculatedTaxable)
        End Function

        Public Overridable Function CreateDeduction(ByVal amount As Double) As ITaxDeduction Implements ITaxEngine.CreateDeduction
            Return New TaxDeduction(amount)
        End Function

        Public Overridable Function CreateIncome(ByVal amount As Double) As ITaxIncome Implements ITaxEngine.CreateIncome
            Return New TaxIncome(amount, 1)
        End Function

        Public MustOverride Function CreateTaxAccount() As ITaxAccount Implements ITaxEngine.CreateTaxAccount


        ' Fields
        Protected _calculatedTaxable As Double
    End Class
End Namespace

