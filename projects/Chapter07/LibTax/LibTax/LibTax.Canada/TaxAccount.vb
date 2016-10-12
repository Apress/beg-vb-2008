Imports LibTax
Imports System

Namespace LibTax.Canada
    Friend Class TaxAccount
        Inherits BaseTaxAccount
        ' Methods
        Public Sub New(ByVal province As Province, ByVal year As Integer)
            Me._province = province
            Me._year = year
        End Sub

        Public Overrides Function GetTaxRate(ByVal income As Double) As Double
            If ((Me._year <> &H7D7) OrElse (Me._province <> Province.Ontario)) Then
                Throw New NotSupportedException(String.Concat(New Object() {"Year ", Me._year, " Province ", Me._province, " not supported"}))
            End If
            Return OntarioTax2007.TaxRate(income)
        End Function


        ' Fields
        Private _province As Province
        Private _year As Integer
    End Class
End Namespace

