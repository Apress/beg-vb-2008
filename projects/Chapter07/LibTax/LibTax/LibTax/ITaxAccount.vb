Imports System

Namespace LibTax
    Public Interface ITaxAccount
        ' Methods
        Sub AddDeduction(ByVal deduction As ITaxDeduction)
        Sub AddIncome(ByVal income As ITaxIncome)
        Function GetTaxRate(ByVal income As Double) As Double

        ' Properties
        ReadOnly Property Deductions As ITaxDeduction()
        ReadOnly Property Income() As ITaxIncome()
    End Interface
End Namespace

