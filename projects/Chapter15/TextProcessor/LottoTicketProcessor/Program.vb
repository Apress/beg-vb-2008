Imports ReaderWriter
Imports System

Friend Class Program
    ' Methods
    Private Shared Sub Main(ByVal args As String())
        Bootstrap.Process(args, New LottoTicketProcessor)
    End Sub

End Class

