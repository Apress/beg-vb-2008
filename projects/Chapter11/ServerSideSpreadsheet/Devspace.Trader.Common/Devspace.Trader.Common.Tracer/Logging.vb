Imports System

Namespace Tracer
    Public Class Logging
        ' Methods
        Public Shared Sub Debug(ByVal message As String)
            Console.Write(("Debug - " & message))
        End Sub

        Public Shared Sub [Error](ByVal message As String)
            Console.Write(("Error - " & message))
        End Sub

        Public Shared Sub Fatal(ByVal message As String)
            Console.Write(("Fatal - " & message))
        End Sub

        Public Shared Sub Info(ByVal message As String)
            Console.Write(("Info - " & message))
        End Sub

        Public Shared Sub Warn(ByVal message As String)
            Console.Write(("Warn - " & message))
        End Sub

    End Class
End Namespace

