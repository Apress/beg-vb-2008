Public Class Translator
    Public Shared Function TranslateHello(ByVal input As String) As String
        Dim temp As String = input.ToLower().Trim
        If temp.CompareTo("hello") = 0 Then
            Return "hallo"
        ElseIf temp.CompareTo("allo") = 0 Then
            Return "hallo"
        End If
        Return ""
    End Function
End Class

