Imports System

Namespace LibTax
    Public MustInherit Class BaseTaxAccount
        Implements ITaxAccount
        ' Methods
        Public Sub AddDeduction(ByVal deduction As ITaxDeduction) Implements ITaxAccount.AddDeduction
            Dim c1 As Integer
            For c1 = 0 To 100 - 1
                If (Me._deductions(c1) Is Nothing) Then
                    Me._deductions(c1) = deduction
                    Exit For
                End If
            Next c1
        End Sub

        Public Sub AddIncome(ByVal income As ITaxIncome) Implements ITaxAccount.AddIncome
            Dim c1 As Integer
            For c1 = 0 To 100 - 1
                If (Me._incomes(c1) Is Nothing) Then
                    Me._incomes(c1) = income
                    Exit For
                End If
            Next c1
        End Sub

        Public MustOverride Function GetTaxRate(ByVal income As Double) As Double Implements ITaxAccount.GetTaxRate


        ' Properties
        Public ReadOnly Property Deductions() As ITaxDeduction() Implements ITaxAccount.Deductions
            Get
                Return Me._deductions
            End Get
        End Property

        Public ReadOnly Property Income() As ITaxIncome() Implements ITaxAccount.Income
            Get
                Return Me._incomes
            End Get
        End Property


        ' Fields
        Private _deductions As ITaxDeduction() = New ITaxDeduction(100  - 1) {}
        Private _incomes As ITaxIncome() = New ITaxIncome(100  - 1) {}
    End Class
End Namespace

