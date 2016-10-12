Imports System

Namespace UniversalDataConverter
    Friend Class TestDataConverter
        ' Methods
        Public Shared Sub RunAll()
            Dim converter As New UniversalDataConverterClass
            Dim buffer As String = converter.Convert(Of String, String)("buffer")
            Dim value As Integer = converter.Convert(Of Integer, String)("123")
            If (buffer <> "buffer") Then
                Console.WriteLine("Conversion did not work")
            End If
            If (value <> &H7B) Then
                Console.WriteLine("Conversion to number did not work")
            End If
        End Sub

    End Class
End Namespace

