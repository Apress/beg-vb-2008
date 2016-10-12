Imports ReaderWriter
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Text

Friend Class LottoTicketProcessor
    Implements IProcessor
    ' Methods
    Public Function Process(ByVal input As String) As String _
    Implements IProcessor.Process
        Dim reader As TextReader = New StringReader(input)
        Dim retval As New StringBuilder
        Do While (reader.Peek <> -1)
            Dim lineOfText As String = reader.ReadLine
            Dim splitUpText As String() = lineOfText.Split(New Char() {" "c, vbTab})
            If (Not Me._dates.Contains(splitUpText(0)) AndAlso (splitUpText(0).Length <> 0)) Then
                If splitUpText(0).Contains("-") Then
                    Dim dateSplit As String() = splitUpText(0).Split(New Char() {"-"c})
                    Dim newDate As String = String.Concat(New String() {dateSplit(0), ".", dateSplit(1), ".", dateSplit(2)})
                    If Me._dates.Contains(newDate) Then
                        Continue Do
                    End If
                    Me._dates.Add(newDate)
                    retval.Append(newDate)
                    Dim c1 As Integer
                    For c1 = 1 To 8 - 1
                        retval.Append((" " & splitUpText(c1)))
                    Next c1
                Else
                    Me._dates.Add(splitUpText(0))
                    retval.Append(lineOfText)
                End If
                retval.Append(vbNewLine)
            End If
        Loop
        Return retval.ToString
    End Function

    Public Function Process01(ByVal input As String) As String
        Dim reader As TextReader = New StringReader(input)
        Dim retval As New StringBuilder
        Do While (reader.Peek <> -1)
            Dim splitUpText As String() = reader.ReadLine.Split(New Char() {" "c, ChrW(9)})
            Dim c1 As Integer
            For c1 = 0 To splitUpText.Length - 1
                retval.Append(("(" & splitUpText(c1) & ")"))
            Next c1
            retval.Append(ChrW(10))
        Loop
        Return retval.ToString
    End Function

    Public Function Process02(ByVal input As String) As String
        Dim reader As TextReader = New StringReader(input)
        Dim retval As New StringBuilder
        Do While (reader.Peek <> -1)
            Dim splitUpText As String() = reader.ReadLine.Split(New Char() {" "c, ChrW(9)})
            If (splitUpText(0).Length <> 0) Then
                Dim c1 As Integer
                For c1 = 0 To splitUpText.Length - 1
                    retval.Append(("(" & splitUpText(c1) & ")"))
                Next c1
                retval.Append(ChrW(10))
            End If
        Loop
        Return retval.ToString
    End Function

    Public Function Process03(ByVal input As String) As String
        Dim reader As TextReader = New StringReader(input)
        Dim retval As New StringBuilder
        Do While (reader.Peek <> -1)
            Dim splitUpText As String() = reader.ReadLine.Split(New Char() {" "c, ChrW(9)})
            If (splitUpText(0).Length <> 0) Then
                If splitUpText(0).Contains("-") Then
                    Dim dateSplit As String() = splitUpText(0).Split(New Char() {"-"c})
                    retval.Append(("(" & String.Concat(New String() {dateSplit(0), ".", dateSplit(1), ".", dateSplit(2)}) & ")"))
                    Dim c1 As Integer
                    For c1 = 1 To splitUpText.Length - 1
                        retval.Append(("(" & splitUpText(c1) & ")"))
                    Next c1
                Else
                    Dim c1 As Integer
                    For c1 = 0 To splitUpText.Length - 1
                        retval.Append(("(" & splitUpText(c1) & ")"))
                    Next c1
                End If
                retval.Append(ChrW(10))
            End If
        Loop
        Return retval.ToString
    End Function

    Public Function Process04(ByVal input As String) As String
        Dim reader As TextReader = New StringReader(input)
        Dim retval As New StringBuilder
        Do While (reader.Peek <> -1)
            Dim splitUpText As String() = reader.ReadLine.Split(New Char() {" "c, ChrW(9)})
            If (splitUpText(0).Length <> 0) Then
                If splitUpText(0).Contains("-") Then
                    Dim dateSplit As String() = splitUpText(0).Split(New Char() {"-"c})
                    retval.Append(("(" & String.Concat(New String() {dateSplit(0), ".", dateSplit(1), ".", dateSplit(2)}) & ")"))
                    Dim c1 As Integer
                    For c1 = 1 To 8 - 1
                        retval.Append(("(" & splitUpText(c1) & ")"))
                    Next c1
                Else
                    Dim c1 As Integer
                    For c1 = 0 To splitUpText.Length - 1
                        retval.Append(("(" & splitUpText(c1) & ")"))
                    Next c1
                End If
                retval.Append(ChrW(10))
            End If
        Loop
        Return retval.ToString
    End Function

    Public Function Process05(ByVal input As String) As String
        Dim reader As TextReader = New StringReader(input)
        Dim retval As New StringBuilder
        Do While (reader.Peek <> -1)
            Dim lineOfText As String = reader.ReadLine
            Dim splitUpText As String() = lineOfText.Split(New Char() {" "c, ChrW(9)})
            If (splitUpText(0).Length <> 0) Then
                If splitUpText(0).Contains("-") Then
                    Dim dateSplit As String() = splitUpText(0).Split(New Char() {"-"c})
                    Dim newDate As String = String.Concat(New String() {dateSplit(0), ".", dateSplit(1), ".", dateSplit(2)})
                    retval.Append(newDate)
                    Dim c1 As Integer
                    For c1 = 1 To 8 - 1
                        retval.Append((" " & splitUpText(c1)))
                    Next c1
                Else
                    retval.Append(lineOfText)
                End If
                retval.Append(ChrW(10))
            End If
        Loop
        Return retval.ToString
    End Function


    ' Fields
    Private _dates As IList(Of String) = New List(Of String)
End Class

