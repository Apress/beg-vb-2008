Imports System

Namespace LibTax
    Friend NotInheritable Class TaxIncome
        Implements ITaxIncome
        ' Methods
        Public Sub New(ByVal amount As Double, ByVal taxableRate As Double)
            Me._amount = amount
            Me._taxableRate = taxableRate
        End Sub


        ' Properties
        Public ReadOnly Property RealAmount() As Double Implements ITaxIncome.RealAmount
            Get
                Return Me._amount
            End Get
        End Property

        Public ReadOnly Property TaxableAmount() As Double Implements ITaxIncome.TaxableAmount
            Get
                Return (Me._amount * Me._taxableRate)
            End Get
        End Property


        ' Fields
        Private _amount As Double
        Private _taxableRate As Double
    End Class
End Namespace

