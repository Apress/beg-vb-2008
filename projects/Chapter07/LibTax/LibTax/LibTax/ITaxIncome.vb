Imports System

Namespace LibTax
    Public Interface ITaxIncome
        ' Properties
        ReadOnly Property RealAmount As Double
        ReadOnly Property TaxableAmount() As Double
    End Interface
End Namespace

