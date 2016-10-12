Imports System
Imports System.Collections.Generic

Namespace ConsoleApplication2
    'Friend Class TestLambdaexpressions
    '    ' Methods
    '    Private Shared Sub DoAddition()
    '        Dim add As New Action
    '        Dim runningTotal As Integer = 0
    '        Dim <>g__initLocal0 As New List(Of Integer)
    '        <>g__initLocal0.Add(1)
    '        <>g__initLocal0.Add(2)
    '        <>g__initLocal0.Add(3)
    '        <>g__initLocal0.Add(4)
    '        add.AddDelegate(Function (ByVal value As Integer) 
    '            runningTotal = (runningTotal + value)
    '        End Function).IterateAllElements(<>g__initLocal0)
    '        Console.WriteLine(("Running Total is (" & runningTotal & ")"))
    '    End Sub

    '    Private Shared Sub DoLambda()
    '        Dim cls As New ActionLamda
    '        Dim runningTotal As Integer = 0
    '        Dim <>g__initLocal4 As New List(Of Integer)
    '        <>g__initLocal4.Add(1)
    '        <>g__initLocal4.Add(2)
    '        <>g__initLocal4.Add(3)
    '        <>g__initLocal4.Add(4)
    '        cls.AddExpression(Function (ByVal x As Integer) 
    '            runningTotal = (runningTotal + x)
    '            Return False
    '        End Function).IterateAllElements(<>g__initLocal4)
    '    End Sub

    '    Private Shared Sub DoLambdas()
    '        Dim cls As New ActionLamda
    '        cls.AddExpression(Function (ByVal x As Integer) 
    '            Return ((x Mod 2) = 0)
    '        End Function)
    '        Dim <>g__initLocal8 As New List(Of Integer)
    '        <>g__initLocal8.Add(1)
    '        <>g__initLocal8.Add(2)
    '        <>g__initLocal8.Add(3)
    '        <>g__initLocal8.Add(4)
    '        cls.AddExpression(Function (ByVal x As Integer) 
    '            Return ((x Mod 2) = 0)
    '        End Function).IterateAllElements(<>g__initLocal8)
    '    End Sub

    '    Public Shared Sub RunAll()
    '        TestLambdaexpressions.DoAddition
    '        TestLambdaexpressions.DoLambda
    '    End Sub

    'End Class
End Namespace

