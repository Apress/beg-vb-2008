Imports System
Imports System.Collections.Generic

Namespace AbstractBaseClassSolution
    Friend Class MaximumValue
        Inherits IteratorBaseClass
        ' Methods
        Public Sub New(ByVal collection As IList(Of Integer))
            MyBase.New(collection)
            Me.MaxValue = -2147483648
        End Sub

        Protected Overrides Sub ProcessElement(ByVal value As Integer)
            If (value > Me.MaxValue) Then
                Me.MaxValue = value
            End If
        End Sub


        ' Fields
        Public MaxValue As Integer
    End Class
End Namespace

