
Public Class Class1

    Private _val As Double

    Public Function DoSomething() As Double
        Dim temp = _val

        temp = temp + 10
        Return temp
    End Function

    Public Property Something() As Integer
        Get
            Return 0
        End Get
        Protected Set(ByVal value As Integer)

        End Set
    End Property
End Class
