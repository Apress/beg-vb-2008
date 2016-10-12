Imports System
Imports System.Collections.Generic

Namespace AnonymousDelegates
    'Friend Class Tests
    '    ' Methods
    '    Private Shared Sub DoRunningTotalAndMaxium()
    '        Dim <>g__initLocal0 As New List(Of Integer)
    '        <>g__initLocal0.Add(1)
    '        <>g__initLocal0.Add(2)
    '        <>g__initLocal0.Add(3)
    '        <>g__initLocal0.Add(4)
    '        Dim lst As List(Of Integer) = <>g__initLocal0
    '        Dim runningTotal As Integer = 0
    '        Dim maxValue As Integer = -2147483648
    '        Dim anonymous As ProcessValue = Function (ByVal value As Integer) 
    '            runningTotal = (runningTotal + value)
    '        End Function
    '        anonymous = DirectCast(Delegate.Combine(anonymous, Function (ByVal value As Integer) 
    '            If (value > maxValue) Then
    '                maxValue = value
    '            End If
    '        End Function), ProcessValue)
    '        lst.Iterate(anonymous)
    '        Console.WriteLine(("Running total is (" & runningTotal & ")"))
    '        Console.WriteLine(("Maximum value is (" & maxValue & ")"))
    '    End Sub

    '    Public Shared Sub RunAll()
    '        Tests.DoRunningTotalAndMaxium
    '    End Sub

    'End Class
End Namespace

