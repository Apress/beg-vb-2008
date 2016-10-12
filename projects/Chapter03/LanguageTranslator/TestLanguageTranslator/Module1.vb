Option Strict Off
Option Explicit Off
Imports System.Globalization
Imports System.Threading

Imports LanguageTranslator

Module Module1
    Public Function FindString(ByVal buffer As String) As String
        Dim characters As Char() = buffer.ToCharArray
        Dim c1 As Integer
        For c1 = 0 To characters.Length - 1
            If ((((characters(c1) = "a"c) AndAlso (characters((c1 + 1)) = "l"c)) AndAlso (characters((c1 + 2)) = "l"c)) AndAlso (characters((c1 + 3)) = "o"c)) Then
                Return Translator.TranslateHello("allo")
            End If
        Next c1
        Return ""
    End Function

    Public Function FindSubstring(ByVal buffer As String) As String

        If (buffer.IndexOf("allo") <> -1) Then
            Return Translator.TranslateHello("allo")
        End If
        Return ""
    End Function

    Private Sub TestTranslateHello()
        If (Translator.TranslateHello("hello").CompareTo("hallo") <> 0) Then
            Console.WriteLine("Test failed of hello to hallo")
        End If
        If (Translator.TranslateHello("allo").CompareTo("hallo") <> 0) Then
            Console.WriteLine("Test failed of allo to hallo")
        End If
        If (Translator.TranslateHello("allosss").CompareTo("") <> 0) Then
            Console.WriteLine("Test to verify non-translated word failed")
        End If
        If (Translator.TranslateHello("  allo").CompareTo("hallo") <> 0) Then
            Console.WriteLine("Test failed of extra white spaces allo to hallo")
        End If
    End Sub

    Private Sub TestTranslateHello2()
        If (Translator.TranslateHello("hello").CompareTo("hallo") <> 0) Then
            Console.WriteLine("Test failed of hello to hallo")
        End If
        If (Translator.TranslateHello("allo").CompareTo("hallo") <> 0) Then
            Console.WriteLine("Test failed of allo to hallo")
        End If
        If (Translator.TranslateHello("allosss").CompareTo("") <> 0) Then
            Console.WriteLine("Test to verify non-translated word failed")
        End If
        If (Translator.TranslateHello("  allo").CompareTo("hallo") <> 0) Then
            Console.WriteLine("Test failed of extra white spaces allo to hallo")
        End If
        If (Translator.TranslateHello("  Allo").CompareTo("hallo") <> 0) Then
            Console.WriteLine("Test failed of extra white spaces allo to hallo")
        End If
    End Sub

    Public Function TrimingWhitespace(ByVal buffer As String) As String
        Return Translator.TranslateHello(buffer.Trim)
    End Function

    Public Function callme(ByRef obj As Object) As Integer
        If obj.Value = 10 Then
            Return 1
        End If
        Dim i As Integer

        Integer.TryParse("1", i)

    End Function
    Public Function Something() As Integer
        Dim i = 10

        If i.Equals(2) Then

        End If
        Dim aa = 10
        If aa.GetType().IsValueType = True Then

        End If

        Dim aString As String = aa.ToString()
    End Function
    Sub Main()
        'TestTranslateHello()

        Dim ivalue As Integer
        Dim result = Integer.TryParse("10", ivalue)
        ivalue = Integer.Parse("10", _
                               NumberStyles.AllowCurrencySymbol and NumberStyles.Number)

        Dim info = System.Threading.Thread.CurrentThread.CurrentCulture
        Console.Write(info.EnglishName)

        Thread.CurrentThread.CurrentCulture = New CultureInfo("en-CA")

        Dim datetime = Date.Parse("May 10, 2005")
        If 5 = datetime.Month Then
            Console.WriteLine("huh")
        End If

        Dim a = 10
        Dim buffer = a.ToString()

        Console.WriteLine("Value (" & result & ") (" & ivalue & ")")
        Console.ReadKey()
    End Sub

End Module
