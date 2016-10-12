Imports ReaderWriter
Imports System

Namespace TextProcessor
    Public Class Program
        ' Methods
        Private Shared Sub Main(ByVal args As String())
            Bootstrap.Process(args, New LottoTicketProcessor)
        End Sub

    End Class
End Namespace

