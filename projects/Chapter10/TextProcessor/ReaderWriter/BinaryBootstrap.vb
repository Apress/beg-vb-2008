Imports System
Imports System.IO

Namespace ReaderWriter
    Public Class BinaryBootstrap
        ' Methods
        Public Shared Sub DisplayHelp()
            Console.WriteLine("You need help? Right now?")
        End Sub

        Public Shared Sub Process(ByVal args As String(), ByVal processor As IBinaryProcessor)
            Dim reader As Stream = Nothing
            Dim writer As Stream = Nothing
            If (args.Length = 0) Then
                reader = Console.OpenStandardInput
                writer = Console.OpenStandardOutput
            ElseIf (args.Length = 1) Then
                If (args(0) = "-help") Then
                    BinaryBootstrap.DisplayHelp
                    Return
                End If
                reader = File.Open(args(0), FileMode.Open)
                writer = Console.OpenStandardOutput
            ElseIf (args.Length = 2) Then
                If (args(0) <> "-out") Then
                    BinaryBootstrap.DisplayHelp
                    Return
                End If
                reader = Console.OpenStandardInput
                writer = File.Open(args(1), FileMode.Create)
            ElseIf (args.Length = 3) Then
                If (args(0) <> "-out") Then
                    BinaryBootstrap.DisplayHelp
                    Return
                End If
                reader = File.Open(args(2), FileMode.Open)
                writer = File.Open(args(1), FileMode.Create)
            Else
                BinaryBootstrap.DisplayHelp
                Return
            End If
            processor.Process(reader, writer)
        End Sub

    End Class
End Namespace

