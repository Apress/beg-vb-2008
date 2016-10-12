Public Class Node
    Shared Sub New()
        Dim montreal As New Node("Montreal", 0, 0)
        Dim newyork As New Node("New York", 0, -3)
        Dim miami As New Node("Miami", -1, -11)
        Dim toronto As New Node("Toronto", -4, -1)
        Dim houston As New Node("Houston", -10, -9)
        Dim losangeles As New Node("Los Angeles", -17, -6)
        Dim seattle As New Node("Seattle", -16, -1)
        montreal.Connections = New Node() {newyork, toronto, losangeles}
        newyork.Connections = New Node() {montreal, houston, miami}
        miami.Connections = New Node() {toronto, houston, newyork}
        toronto.Connections = New Node() {miami, seattle, montreal}
        houston.Connections = New Node() {miami, seattle, newyork}
        seattle.Connections = New Node() {toronto, houston, losangeles}
        losangeles.Connections = New Node() {montreal, seattle, houston}
        Node.RootNodes = New Node() {montreal, newyork, miami, toronto, houston, losangeles, seattle}
        ReDim montreal.Connections(3)

    End Sub

    Public Sub New(ByVal city As String, ByVal x As Double, ByVal y As Double)
        Me.CityName = city
        Me.X = x
        Me.Y = y
        Me.Connections = Nothing
    End Sub

    Public Shared Function GetMaxPossibleDestinationsArraySize() As Integer
        Return 10
    End Function

    Public CityName As String
    Public Connections As Node()
    Public Shared RootNodes As Node()
    Public X As Double
    Public Y As Double
End Class

