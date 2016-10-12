Public Enum Something
    Alberta
    BristishColumbia
    Ontario
End Enum

Public Class Class1
    Public ReadOnly Property Something() As Integer()
        Get
            Return New Integer(10) {}
        End Get
    End Property
    Public Sub Method()

    End Sub
End Class