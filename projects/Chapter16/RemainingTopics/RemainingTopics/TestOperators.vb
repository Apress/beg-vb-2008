Imports System

Namespace RemainingTopics
    Friend Class TestOperators
        ' Methods
        Private Shared Sub RunAll()
            Dim person As Integer = 5
            If ((person And 1) <> 0) Then
                Console.WriteLine("Person is tall")
            Else
                Console.WriteLine("Person is not tall")
            End If
            person = Not person
            If ((person And 1) <> 0) Then
                Console.WriteLine("Person is tall")
            Else
                Console.WriteLine("Person is not tall")
            End If
            Dim shifted As Integer = 8
            Dim shiftedLeft As Integer = (shifted << 2)
            Dim shiftedRight As Integer = (shifted >> 2)
            Console.WriteLine(String.Concat(New Object() { "Shifted Left (", shiftedLeft, ") Right (", shiftedRight, ")" }))
            Console.WriteLine(("Output (" & -9 & ")"))
            Console.ReadKey
        End Sub


        ' Fields
        Const isTall As Integer = 1
        Const wearsHats As Integer = 2
        Const runsSlow As Integer = 4
    End Class
End Namespace

