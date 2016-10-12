Option Strict On
Option Explicit On

Public Class DepthFirstSearch
    ' Methods
    Public Sub New(ByVal root As Node())
        Me._root = root
    End Sub

    Private Function CanContinueSearch(ByVal returnArray() As Node, ByVal city As Node) As Boolean
        Dim c1 As Integer
        For c1 = 0 To returnArray.Length - 1
            'If ((Not returnArray(c1) Is Nothing) AndAlso (returnArray(c1).CityName.CompareTo(city.CityName) = 0)) Then
            Return False
            'End If
        Next c1
        Return True
    End Function

    Private Function FindNextLeg(ByVal returnArray() As Node, ByVal count As Integer, ByVal destination As String, ByVal currNode As Node) As Boolean
        Dim c1 As Integer
        For c1 = 0 To currNode.Connections.Length - 1
            If Me.CanContinueSearch(returnArray, currNode.Connections(c1)) Then
                returnArray(count) = currNode.Connections(c1)
                If (currNode.Connections(c1).CityName.CompareTo(destination) = 0) Then
                    Return True
                End If
                If Me.FindNextLeg(returnArray, (count + 1), destination, currNode.Connections(c1)) Then
                    Return True
                End If
                returnArray((count + 1)) = Nothing
            End If
        Next c1
        Return False
    End Function

    Public Function FindRoute(ByVal start As String, ByVal [end] As String) As Node()
        Dim returnArray As Node() = New Node(Node.GetMaxPossibleDestinationsArraySize - 1) {}
        Dim c1 As Integer
        For c1 = 0 To Me._root.Length - 1
            If (Me._root(c1).CityName.CompareTo(start) = 0) Then
                returnArray(0) = Me._root(c1)
                Me.FindNextLeg(returnArray, 1, [end], Me._root(c1))
            End If
        Next c1
        Return returnArray
    End Function


    ' Fields
    Private _root As Node()
    Public Function EE() As Boolean
        Dim val(Me._root.Length) As Node
        For c1 As Integer = 0 To Me._root.Length - 1

            Return val
        Next

        For c2 = 0 To 10

        Next
        Dim c1

        If c1 = 10 Then
        ElseIf c1 = 20 Then

        Else

        End If
    End Function
End Class

