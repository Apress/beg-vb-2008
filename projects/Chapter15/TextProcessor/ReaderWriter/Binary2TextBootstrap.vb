Imports System
Imports System.IO

Namespace ReaderWriter
    Public Class Binary2TextBootstrap
        ' Methods
        Public Shared Sub DisplayHelp()
            Console.WriteLine("You need help? Right now?")
        End Sub

        Public Shared Sub Process(ByVal args As String(), ByVal processor As IBinary2TextProcessor)
            Dim reader As Stream = Nothing
            Dim writer As TextWriter = Nothing
            If (args.Length = 0) Then
                reader = Console.OpenStandardInput
                writer = Console.Out
            ElseIf (args.Length = 1) Then
                If (args(0) = "-help") Then
                    Binary2TextBootstrap.DisplayHelp
                    Return
                End If
                reader = New FileStream(args(0), FileMode.Open)
                writer = Console.Out
            ElseIf (args.Length = 2) Then
                If (args(0) <> "-out") Then
                    Binary2TextBootstrap.DisplayHelp
                    Return
                End If
                reader = Console.OpenStandardInput
                writer = File.CreateText(args(1))
            ElseIf (args.Length = 3) Then
                If (args(0) <> "-out") Then
                    Binary2TextBootstrap.DisplayHelp
                    Return
                End If
                reader = File.Open(args(2), FileMode.Open)
                writer = File.CreateText(args(1))
            Else
                Binary2TextBootstrap.DisplayHelp
                Return
            End If
            processor.Process(reader, writer)
            writer.Close
        End Sub

    End Class
End Namespace

