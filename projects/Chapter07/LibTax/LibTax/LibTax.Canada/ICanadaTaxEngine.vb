Imports LibTax
Imports System

Namespace LibTax.Canada
    Public Interface ICanadaTaxEngine
        ' Methods
        Function CreateCapitalGain(ByVal amount As Double) As ITaxIncome
        Function CreateTaxAccount(ByVal province As Province, ByVal year As Integer) As ITaxAccount
    End Interface
End Namespace

