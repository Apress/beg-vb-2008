Imports System
Imports System.Collections.Generic

Namespace Delegates
    'Friend Class Tests
    '    ' Methods
    '    Private Shared Sub DoRunningTotalAndMaxium()
    '        Dim <>g__initLocal0 As New List(Of Integer)
    '        <>g__initLocal0.Add(1)
    '        <>g__initLocal0.Add(2)
    '        <>g__initLocal0.Add(3)
    '        <>g__initLocal0.Add(4)
    '        Dim lst As List(Of Integer) = <>g__initLocal0
    '        Tests._runningTotal = 0
    '        lst.Iterate(New ProcessValue(AddressOf Tests.ProcessRunningTotal))
    '        Console.WriteLine(("Running total is (" & Tests._runningTotal & ")"))
    '        Tests._maxValue = -2147483648
    '        lst.Iterate(New ProcessValue(AddressOf Tests.ProcessMaximumValue))
    '        Console.WriteLine(("Maximum value is (" & Tests._maxValue & ")"))
    '    End Sub

    '    Private Shared Sub ProcessMaximumValue(ByVal value As Integer)
    '        If (value > Tests._maxValue) Then
    '            Tests._maxValue = value
    '        End If
    '    End Sub

    '    Private Shared Sub ProcessRunningTotal(ByVal value As Integer)
    '        Tests._runningTotal = (Tests._runningTotal + value)
    '    End Sub

    '    Public Shared Sub RunAll()
    '        Tests.DoRunningTotalAndMaxium
    '    End Sub


    '    ' Fields
    '    Private Shared _maxValue As Integer
    '    Private Shared _runningTotal As Integer
    'End Class
End Namespace

