Imports System

<Serializable()> _
    Public Class Ticket
    ' Methods
    Public Sub New()
    End Sub

    Public Sub New(ByVal drawDate As DateTime, ByVal numbers As Integer(), ByVal bonus As Integer)
        Me._drawDate = drawDate
        Me._numbers = numbers
        Me._bonus = bonus
    End Sub


    ' Properties
    Public Property Bonus() As Integer
        Get
            Return Me._bonus
        End Get
        Set(ByVal value As Integer)
            Me._bonus = value
        End Set
    End Property

    Public Property DrawDate() As DateTime
        Get
            Return Me._drawDate
        End Get
        Set(ByVal value As DateTime)
            Me._drawDate = value
        End Set
    End Property

    Public Property Numbers() As Integer()
        Get
            Return Me._numbers
        End Get
        Set(ByVal value As Integer())
            Me._numbers = value
        End Set
    End Property


    ' Fields
    Private _bonus As Integer
    Private _drawDate As DateTime
    Private _numbers As Integer()
End Class

