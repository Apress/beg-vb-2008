Imports LottoLibrary
Imports ReaderWriter
Imports System
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Text

Namespace Text2Binary
    Friend Class LottoTicketProcessor : Implements IText2BinaryProcessor
        ' Methods
        Public Sub Process(ByVal reader As TextReader, ByVal writer As Stream) _
            Implements IText2BinaryProcessor.Process
            Dim retval = New StringBuilder()
            Do While (reader.Peek <> -1)
                Dim lineOfText As String = reader.ReadLine()
                Dim splitUpText As String() = lineOfText.Split(New Char() {" "c})
                Dim dateSplit As String() = splitUpText(0).Split(New Char() {"."c})

                Dim ticket As LottoLibrary.Ticket = _
                    New LottoLibrary.Ticket( _
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

                Dim formatter = New BinaryFormatter()

                formatter.Serialize(writer, ticket)
            Loop
        End Sub
    End Class
End Namespace

