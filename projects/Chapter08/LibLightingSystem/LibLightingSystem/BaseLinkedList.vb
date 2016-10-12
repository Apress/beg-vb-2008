Imports System

Public MustInherit Class BaseLinkedList
    ' Methods
    Protected Sub New()
    End Sub

    Public Sub Insert(ByVal item As BaseLinkedList)
        item._next = Me._next
        item._prev = Me
        If (Not Me._next Is Nothing) Then
            Me._next._prev = item
        End If
        Me._next = item
    End Sub

    Public Sub Remove()
        If (Not Me._next Is Nothing) Then
            Me._next._prev = Me._prev
        End If
        If (Not Me._prev Is Nothing) Then
            Me._prev._next = Me._next
        End If
        Me._next = Nothing
        Me._prev = Nothing
    End Sub


    ' Properties
    Public ReadOnly Property [Next]() As BaseLinkedList
        Get
            Return Me._next
        End Get
    End Property

    Public ReadOnly Property Prev() As BaseLinkedList
        Get
            Return Me._prev
        End Get
    End Property


    ' Fields
    Private _next As BaseLinkedList
    Private _prev As BaseLinkedList
End Class

