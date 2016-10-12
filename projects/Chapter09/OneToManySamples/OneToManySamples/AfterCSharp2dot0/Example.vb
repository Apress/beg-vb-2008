Imports System

Namespace AfterCSharp2dot0
    Friend Class Example
        ' Properties
        Public Property Value As Integer
            Get
                Return Me._value
            End Get
            Set(ByVal value As Integer)
                Me._value = value
            End Set
        End Property


        ' Fields
        Private _value As Integer
    End Class
End Namespace

