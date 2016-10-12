Imports System

Namespace Tracer
    Public Class ToStringTracer
        ' Methods
        Public Function Base(ByVal value As String) As ToStringTracer
            Me._buffer = (Me._buffer & "{Base " & value & "}")
            Return Me
        End Function

        Public Function Delegated(ByVal delegateTo As ToStringTracerDelegate) As ToStringTracer
            delegateTo(Me)
            Return Me
        End Function

        Public Function Embedded(ByVal value As String) As ToStringTracer
            Me._buffer = (Me._buffer & "{" & value & "}")
            Return Me
        End Function

        Public Function [End]() As String
            Me._buffer = (Me._buffer & "}")
            Return Me._buffer
        End Function

        Public Function EndArray() As ToStringTracer
            Me._buffer = (Me._buffer & "}")
            Return Me
        End Function

        Public Function Start(ByVal obj As Object) As ToStringTracer
            Me.Start(obj.GetType.FullName)
            Return Me
        End Function

        Public Function Start(ByVal name As String) As ToStringTracer
            Me._buffer = (Me._buffer & "{Type: " & name)
            Return Me
        End Function

        Public Function StartArray(ByVal buffer As String) As ToStringTracer
            Me._buffer = (Me._buffer & "{Array " & buffer)
            Return Me
        End Function

        Public Function Variable(ByVal identifier As String, ByVal value As Boolean) As ToStringTracer
            If value Then
                Me._buffer = (Me._buffer & "{Variable: " & identifier & " (true)}")
            Else
                Me._buffer = (Me._buffer & "{Variable: " & identifier & " (false)}")
            End If
            Return Me
        End Function

        Public Function Variable(ByVal identifier As String, ByVal values As Double()) As ToStringTracer
            Me._buffer = (Me._buffer & "{Variable: " & identifier)
            Dim c1 As Integer
            For c1 = 0 To values.Length - 1
                Dim val As Object = Me._buffer
                Me._buffer = String.Concat(New Object() {val, " (Index ", c1, " ", values(c1), ")"})
            Next c1
            Me._buffer = (Me._buffer & "}")
            Return Me
        End Function

        Public Function Variable(ByVal identifier As String, ByVal value As Integer) As ToStringTracer
            Me._buffer = String.Concat(New Object() {_buffer, "{Variable: ", identifier, " (", value, ")}"})
            Return Me
        End Function

        Public Function Variable(ByVal identifier As String, ByVal value As String) As ToStringTracer
            Me._buffer = String.Concat(New String() {_buffer, "{Variable: ", identifier, " (", value, ")}"})
            Return Me
        End Function

        Public Function Variable(ByVal identifier As String, ByVal value As UInt64) As ToStringTracer
            Me._buffer = String.Concat(New Object() {_buffer, "{Variable: ", identifier, " (", value, ")}"})
            Return Me
        End Function


        ' Fields
        Private _buffer As String
    End Class
End Namespace

