Imports LibTax
Imports System

Namespace LibTax.WiggleWiggle
    Friend Class TaxEngine
        Inherits BaseTaxEngine
        ' Methods
        Public Overrides Function CalculateTaxToPay(ByVal account As ITaxAccount) As Double
            Dim taxToPay As Double = MyBase.CalculateTaxToPay(account)
            If (MyBase._calculatedTaxable > 400) Then
                taxToPay = (taxToPay + 10)
            End If
            Return taxToPay
        End Function

        Public Overrides Function CreateTaxAccount() As ITaxAccount
            Throw New Exception("The method or operation is not implemented.")
        End Function

    End Class
End Namespace

