Imports System

Friend Class Customer
    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        If TypeOf obj Is Customer Then
            Dim otherObj As Customer = TryCast(obj, Customer)
            If otherObj.Identifier.CompareTo(Identifier) = 0 Then
                Return True
            End If
        End If
        Return False
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return Me.Identifier.GetHashCode()
    End Function

    Public Overrides Function ToString() As String
        Return String.Concat(New Object() {"Identifier (", Me.Identifier, ") Points (", Me.Points, ")"})
    End Function


    Public Identifier As String
    Public Points As Integer
End Class

