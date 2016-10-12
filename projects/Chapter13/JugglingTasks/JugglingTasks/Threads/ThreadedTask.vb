Imports System

Namespace Threads
    Friend Class ThreadedTask
        Private _whatToSay As String

        Public Sub New(ByVal whatotsay As String)
            _whatToSay = whatotsay
        End Sub

        Public Sub MethodToRun()
            Console.WriteLine(("I am babbling (" & _whatToSay & ")"))
        End Sub
    End Class
End Namespace

