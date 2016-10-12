Imports LibTax
Imports System

Namespace LibTax.Canada
    Friend Class TaxEngine
        Inherits BaseTaxEngine
        Implements ICanadaTaxEngine
        ' Methods
        Public Function CreateCapitalGain(ByVal amount As Double) As ITaxIncome Implements ICanadaTaxEngine.CreateCapitalGain
            Return New TaxIncome(amount, 0.5)
        End Function

        Public Overrides Function CreateTaxAccount() As ITaxAccount
            Return New TaxAccount(Province.Ontario, &H7D7)
        End Function

        Public Overloads Function CreateTaxAccount(ByVal province As Province, ByVal year As Integer) As ITaxAccount _
        Implements ICanadaTaxEngine.CreateTaxAccount
            Return New TaxAccount(province, year)
        End Function

    End Class
End Namespace

