Imports System

Friend Class Example(Of DataType As {IBase, New, Class})
    Public Sub New()
        _value = New DataType
        _value.Value = 10
    End Sub

    Private _value As DataType
End Class

