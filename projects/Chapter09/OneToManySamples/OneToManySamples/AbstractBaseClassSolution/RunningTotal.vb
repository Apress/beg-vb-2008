Imports System
Imports System.Collections.Generic

Namespace AbstractBaseClassSolution
    Friend Class RunningTotal
        Inherits IteratorBaseClass
        ' Methods
        Public Sub New(ByVal collection As IList(Of Integer))
            MyBase.New(collection)
            Me.Total = 0
        End Sub

        Protected Overrides Sub ProcessElement(ByVal value As Integer)
            Me.Total = (Me.Total + value)
        End Sub


        ' Fields
        Public Total As Integer
    End Class
End Namespace

