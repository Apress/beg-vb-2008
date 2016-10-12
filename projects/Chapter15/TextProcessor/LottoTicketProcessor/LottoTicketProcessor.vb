Imports LottoLibrary
Imports ReaderWriter
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text

Friend Class LottoTicketProcessor
    Implements IExtendedProcessor, IProcessor

    Private _tickets As List(Of Ticket) = New List(Of Ticket)

    Public Function Destroy() As String Implements IExtendedProcessor.Destroy
        Dim builder As New StringBuilder
        Dim c1 As Integer
        For c1 = 1 To &H2E - 1
            builder.Append(("Number (" & c1 & ") Found ("))
            Dim foundCount As Integer = 0
            builder.Append(((foundCount + FrequencyOfANumber(c1)) & ")" & ChrW(10)))
        Next c1
        Return builder.ToString
    End Function

    Private Function FrequencyOfANumber(ByVal numberToSearch As Integer) As Integer
        Dim query = From ticket In _tickets _
                        Where ticket.Numbers(0) = numberToSearch _
                        Or ticket.Numbers(1) = numberToSearch _
                        Or ticket.Numbers(2) = numberToSearch _
                        Or ticket.Numbers(3) = numberToSearch _
                        Or ticket.Numbers(4) = numberToSearch _
                        Or ticket.Numbers(5) = numberToSearch _
                        Select ticket.Numbers
        Return query.Count()
    End Function

    Private Function FrequencyOfANumber2(ByVal numberToSearch As Integer) As Integer
        Dim query = _tickets.Where( _
                                   Function(ticket, index) _
                ticket.Numbers(0) = numberToSearch _
                Or ticket.Numbers(1) = numberToSearch _
                Or ticket.Numbers(2) = numberToSearch _
                Or ticket.Numbers(3) = numberToSearch _
                Or ticket.Numbers(4) = numberToSearch _
                Or ticket.Numbers(5) = numberToSearch)
        Return query.Count()
    End Function

    Public Function Initialize() As String Implements IExtendedProcessor.Initialize
        Return ""
    End Function

    Public Function Process(ByVal input As String) As String Implements IProcessor.Process
        Dim reader As TextReader = New StringReader(input)
        Do While (reader.Peek <> -1)
            Dim splitUpText As String() = reader.ReadLine.Split(New Char() {" "c})
            Dim dateSplit As String() = splitUpText(0).Split(New Char() {"."c})
            Dim ticket As New Ticket( _
                                     New DateTime( _
                                                  Integer.Parse(dateSplit(0)), _
                                                  Integer.Parse(dateSplit(1)), _
                                                  Integer.Parse(dateSplit(2))), _
                                                  New Integer() { _
                                                                 Integer.Parse(splitUpText(1)), _
                                                                 Integer.Parse(splitUpText(2)), _
                                                                 Integer.Parse(splitUpText(3)), _
                                                                 Integer.Parse(splitUpText(4)), _
                                                                 Integer.Parse(splitUpText(5)), _
                                                                 Integer.Parse(splitUpText(6))}, _
                                                                 Integer.Parse(splitUpText(7)))
            _tickets.Add(ticket)
        Loop
        Return ""
    End Function
End Class

