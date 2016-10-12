Public Class LinkedListEnumerable
    Implements IEnumerable, IEnumerator
    Private _currNode As BaseLinkedList
    Private _firstNode As BaseLinkedList

    Public Sub New(ByVal linkedList As BaseLinkedList)
        _currNode = linkedList
        _firstNode = linkedList
    End Sub

    Public Function GetEnumerator() As System.Collections.IEnumerator _
    Implements System.Collections.IEnumerable.GetEnumerator
        Return Me
    End Function

    Public ReadOnly Property Current() As Object _
    Implements System.Collections.IEnumerator.Current
        Get
            Return _currNode
        End Get
    End Property

    Public Function MoveNext() As Boolean _
    Implements System.Collections.IEnumerator.MoveNext
        If _currNode Is Nothing Then
            Return False
        End If
        _currNode = _currNode.Next
        If _currNode Is Nothing Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Sub Reset() _
    Implements System.Collections.IEnumerator.Reset
        _currNode = _firstNode
    End Sub
End Class
