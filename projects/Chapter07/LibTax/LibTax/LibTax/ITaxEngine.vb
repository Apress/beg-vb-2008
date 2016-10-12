Imports System

Namespace LibTax
    Public Interface ITaxEngine
        ' Methods
        Function CalculateTaxToPay(ByVal account As ITaxAccount) As Double
        Function CreateDeduction(ByVal value As Double) As ITaxDeduction
        Function CreateIncome(ByVal value As Double) As ITaxIncome
        Function CreateTaxAccount() As ITaxAccount
    End Interface
End Namespace

