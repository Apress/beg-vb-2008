Imports System

Namespace LibTax
    Friend NotInheritable Class TaxDeduction
        Implements ITaxDeduction
        ' Methods
        Public Sub New(ByVal amount As Double)
            Me._amount = amount
        End Sub


        ' Properties
        Public ReadOnly Property Amount() As Double Implements ITaxDeduction.Amount
            Get
                Return Me._amount
            End Get
        End Property


        ' Fields
        Private _amount As Double
    End Class
End Namespace

