Imports System
Imports System.Collections.Generic

Namespace ConsoleApplication2
    Friend Class FirstAddition
        ' Methods
        Public Function AddAllElements(ByVal list As IList(Of Integer)) As Integer
            Dim runningTotal As Integer = 0
            Dim value As Integer
            For Each value In list
                runningTotal = (runningTotal + value)
            Next
            Return runningTotal
        End Function

        Public Function SubtractAllElements(ByVal list As IList(Of Integer)) As Integer
            Dim runningTotal As Integer = 0
            Dim value As Integer
            For Each value In list
                runningTotal = (runningTotal - value)
            Next
            Return runningTotal
        End Function

    End Class
End Namespace

