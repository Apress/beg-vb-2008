Imports System
Imports System.Collections.Generic

Namespace AbstractBaseClassSolution
    Friend MustInherit Class IteratorBaseClass
        ' Methods
        Protected Sub New(ByVal collection As IList(Of Integer))
            Me._collection = collection
        End Sub

        Public Function Iterate() As IteratorBaseClass
            Dim element As Integer
            For Each element In Me._collection
                Me.ProcessElement(element)
            Next
            Return Me
        End Function

        Protected MustOverride Sub ProcessElement(ByVal value As Integer)


        ' Fields
        Private _collection As IList(Of Integer)
    End Class
End Namespace

