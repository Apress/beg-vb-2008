Interface IRoom

End Interface

Class MyType
    Private _dataMember As Integer

    Public Property DataMember() As Integer
        Get
            Return _dataMember
        End Get
        Set(ByVal value As Integer)
            _dataMember = value
        End Set
    End Property
End Class

Class EmbeddedMyType
    Private _embedded As MyType

    Public Property MyTypeProperty() As MyType
        Get
            Return _embedded
        End Get
        Set(ByVal value As MyType)
            _embedded = value
        End Set
    End Property
End Class

Class MyRoom
    Implements IRoom
    Public ReadOnly Property Something() As Integer
        Get

        End Get
    End Property
    Public ReadOnly Property Items(ByVal description As String) As Integer
        Get
            If description = "hello" Then
                Return 10
            End If
        End Get
    End Property
    'Public Function RoomGroupingIterator() As IEnumerator Implements IEnumerable.GetEnumerator
    '    Return 0
    '    Return 1
    '    Return 2
    'End Function

End Class

Module Module1

    Sub Main()
        Dim controller As LibLightingSystem.LightingController = New LibLightingSystem.LightingController()
        'controller.AddRoomGrouping(
        For Each description As String In controller.RoomGroupingIterator()
            ' Do something with the description
        Next

        'Dim rooms() = New IRoom() {New MyRoom()}
        Dim rooms2() = New IRoom(10) {}

        'Dim room As IRoom
        For Each room As IRoom In rooms2

        Next
        'If TypeOf (rooms(0)) Is IRoom Then

        'End If
        'Dim var As Func(Of Integer, Integer, Integer)
        'var = Function(a, b) a + b

        'Dim room = New MyRoom()
        'Dim val = room("hello")
        'Console.WriteLine(val)

        Dim cls As EmbeddedMyType = _
            New EmbeddedMyType() With { _
                .MyTypeProperty = _
                    New MyType() With {.DataMember = 10}}

    End Sub

End Module
