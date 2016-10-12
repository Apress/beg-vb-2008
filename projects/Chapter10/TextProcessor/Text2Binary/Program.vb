Imports ReaderWriter
Imports System

Namespace Text2Binary
    Friend Class Program
        ' Methods
        Private Shared Sub Main(ByVal args As String())
            Text2BinaryBootstrap.Process(args, New LottoTicketProcessor)
        End Sub

    End Class
End Namespace

