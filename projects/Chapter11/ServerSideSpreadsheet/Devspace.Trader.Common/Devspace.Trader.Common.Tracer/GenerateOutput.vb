Imports System
Imports System.Collections

Namespace Tracer
    Public Class GenerateOutput
        ' Methods
        Public Shared Sub Write(ByVal buffer As String)
            Logging.Debug((buffer & ChrW(10)))
        End Sub

        Public Shared Sub Write(ByVal identifier As String, ByVal var As Boolean())
            Logging.Debug(String.Concat(New Object() {"(int[] ", identifier, ChrW(10) & "  (Length (", var.Length, ") Numbers ("}))
            For counter As Integer = 0 To var.Length - 1
                If var(counter) Then
                    Logging.Debug("(true)")
                Else
                    Logging.Debug("(false)")
                End If
            Next
            Logging.Debug("))" & ChrW(10))
        End Sub

        Public Shared Sub Write(ByVal identifier As String, ByVal var As Double())
            Logging.Debug(String.Concat(New Object() {"(double[] ", identifier, ChrW(10) & "  (Length (", var.Length, ") Numbers ("}))
            Dim value As Double
            For Each value In var
                Logging.Debug(("(" & value & ")"))
            Next
            Logging.Debug("))" & ChrW(10))
        End Sub

        Public Shared Sub Write(ByVal identifier As String, ByVal var As Integer())
            Logging.Debug(String.Concat(New Object() {"(int[] ", identifier, ChrW(10) & "  (Length (", var.Length, ") Numbers ("}))
            Dim value As Integer
            For Each value In var
                Logging.Debug(("(" & value & ")"))
            Next
            Logging.Debug("))" & ChrW(10))
        End Sub

        Public Shared Sub Write(ByVal identifier As String, ByVal list As IEnumerable)
            Logging.Debug(String.Concat(New String() {"(Type", list.GetType.Name, " ", identifier, "(" & ChrW(10)}))
            Dim obj As Object
            For Each obj In list
                Logging.Debug(("(" & obj.ToString & ")"))
            Next
            Logging.Debug("))" & ChrW(10))
        End Sub

        Public Shared Sub Write(ByVal identifier As String, ByVal value As DateTime)
            Dim buffer As String = String.Concat(New Object() {value.Year, "-", value.Month, "-", value.Day, " ", value.Hour, ":", value.Minute, ":", value.Second, " ", value.Millisecond, " ticks(", value.Ticks, ")"})
            Logging.Debug(String.Concat(New String() {"(datetime ", identifier, " (", buffer, "))" & ChrW(10)}))
        End Sub

        Public Shared Sub Write(ByVal identifier As String, ByVal value As Double)
            Logging.Debug(String.Concat(New Object() {"(double ", identifier, " (", value, "))" & ChrW(10)}))
        End Sub

        Public Shared Sub Write(ByVal identifier As String, ByVal value As Integer)
            Logging.Debug(String.Concat(New Object() {"(int ", identifier, " (", value, "))" & ChrW(10)}))
        End Sub

        Public Shared Sub Write(ByVal identifier As String, ByVal obj As Object)
            Logging.Debug(String.Concat(New String() {"(Type", obj.GetType.Name, " ", identifier, "(" & ChrW(10), obj.ToString, "))" & ChrW(10)}))
        End Sub

        Public Shared Sub Write(ByVal identifier As String, ByVal value As String)
            Logging.Debug(String.Concat(New String() {"(String ", identifier, " (", value, "))" & ChrW(10)}))
        End Sub

        Public Shared Sub Write(ByVal identifier As String, ByVal value As UInt64)
            Logging.Debug(String.Concat(New Object() {"(ulong ", identifier, " (", value, "))" & ChrW(10)}))
        End Sub

        Public Shared Sub Write(ByVal identifier As String, ByVal var As Integer()())
            Logging.Debug(String.Concat(New Object() {"(int[][] ", identifier, ChrW(10) & "  (Length (", var.Length, ")" & ChrW(10)}))
            Dim numbers As Integer()
            For Each numbers In var
                Logging.Debug(("    Element (Length " & numbers.Length & ") (Numbers "))
                Dim value As Integer
                For Each value In numbers
                    Logging.Debug(("(" & value & ")"))
                Next
                Logging.Debug("))" & ChrW(10))
            Next
            Logging.Debug("  ))" & ChrW(10))
        End Sub

    End Class
End Namespace

