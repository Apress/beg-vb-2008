Imports System.Collections
Imports System.Collections.Generic
Imports System.Linq

Module Module1
    Private Function CreateList() As Customer()
        Return New Customer() { _
            New Customer() With {.Identifier = "Person 1", .Points = 0}, _
            New Customer() With {.Identifier = "Person 2", .Points = 10}}
    End Function

    Function Increment(ByVal pCustomer As Customer, ByVal index As Integer)
        pCustomer.Points = (pCustomer.Points + 5)
        Return pCustomer
    End Function
    Sub Example01()
        Dim points = (From customer In CreateList() _
                      Where customer.Points > 5 _
                      Select customer).Select(AddressOf Increment)
        Console.WriteLine("Count is (" & points.Count() & ")")
    End Sub

    Sub DuckTyping(ByVal foundObj)
        Console.WriteLine("Found object (" & foundObj.identifier & ")")
    End Sub
    Function Increment2(ByVal pCustomer As Customer, ByVal index As Integer)
        pCustomer.Points = (pCustomer.Points + 5)
        Return New With {.identifier = pCustomer.Identifier, .points = pCustomer.Points}
    End Function

    Sub Example02()
        Dim points = (From customer In CreateList() _
                      Where customer.Points > 5 _
                      Select customer).Select(AddressOf Increment)
        Console.WriteLine("Count is (" & points.Count() & ")")
        For Each obj In points
            DuckTyping(obj)
        Next
    End Sub


    Private Sub Example03()
        Dim set1 As Integer() = New Integer() {1, 2, 3, 4, 5}
        Dim set2 As Integer() = New Integer() {1, 2, 3, 4, 5}
        Dim set3 As Integer() = New Integer() {1, 2, 3, 4, 5}
        Dim triples = _
            From a In set1 _
            From b In set2 _
            From c In set3 _
            Select New With {a, b, c}
    End Sub

    Private Sub Example04()
        Dim words() As String = {"cherry", "apple", "blueberry"}

        Dim sortedWords = _
            From w In words _
            Order By w _
            Select w
    End Sub

    Sub Example05()
        Dim customers1 = New Customer() { _
            New Customer() With {.Identifier = "Person 1", .Points = 0}, _
            New Customer() With {.Identifier = "Person 2", .Points = 10}}
        Dim customers2 = New Customer() { _
            New Customer() With {.Identifier = "Person 3", .Points = 0}, _
            New Customer() With {.Identifier = "Person 2", .Points = 10}}

        Dim uniqueCustomers = customers1.Union(customers2)
        For Each customer In uniqueCustomers
            Console.WriteLine("(" & customer.Identifier & ")")
        Next
    End Sub
    'Private Shared Sub Example06()
    '    Dim <>g__initLocal1b As New List(Of Customer)
    '    Dim <>g__initLocal1c As New Customer
    '    <>g__initLocal1c.Identifier = "Person 1"
    '    <>g__initLocal1c.Points = 0
    '    <>g__initLocal1b.Add(<>g__initLocal1c)
    '    Dim <>g__initLocal1d As New Customer
    '    <>g__initLocal1d.Identifier = "Person 2"
    '    <>g__initLocal1d.Points = 10
    '    <>g__initLocal1b.Add(<>g__initLocal1d)
    '    Dim customers1 As List(Of Customer) = <>g__initLocal1b
    '    Dim <>g__initLocal1e As New List(Of Customer)
    '    Dim <>g__initLocal1f As New Customer
    '    <>g__initLocal1f.Identifier = "Person 3"
    '    <>g__initLocal1f.Points = 20
    '    <>g__initLocal1e.Add(<>g__initLocal1f)
    '    Dim <>g__initLocal20 As New Customer
    '    <>g__initLocal20.Identifier = "Person 2"
    '    <>g__initLocal20.Points = 10
    '    <>g__initLocal1e.Add(<>g__initLocal20)
    '    Dim customers2 As List(Of Customer) = <>g__initLocal1e
    '    Dim uniqueCustomers As IEnumerable(Of Customer) = customers1.Union(Of Customer)(customers2)
    'End Sub

    'Private Shared Sub Main(ByVal args As String())
    '    Program.Example01
    '    Program.Example02
    '    Program.Example03
    '    Program.Example04
    '    Program.Example05
    '    Program.Example06
    'End Sub


    Sub Main()
        'Example01()
        'Example02()
        Example05()
        Console.ReadKey()
    End Sub

End Module
