Imports System
Imports System.IO

Public Module Text2BinaryBootstrap
    Public Sub DisplayHelp()
        Console.WriteLine("You need help? Right now?")
    End Sub

    Public Sub Process(ByVal args As String(), ByVal processor As IText2BinaryProcessor)
        Dim reader As TextReader = Nothing
        Dim writer As Stream = Nothing
        If (args.Length = 0) Then
            reader = Console.In
            writer = Console.OpenStandardOutput
        ElseIf (args.Length = 1) Then
            If (args(0) = "-help") Then
                Text2BinaryBootstrap.DisplayHelp()
                Return
            End If
            reader = File.OpenText(args(0))
            writer = Console.OpenStandardOutput
        ElseIf (args.Length = 2) Then
            If (args(0) <> "-out") Then
                Text2BinaryBootstrap.DisplayHelp()
                Return
            End If
            reader = Console.In
            writer = File.Open(args(1), FileMode.Create)
        ElseIf (args.Length = 3) Then
            If (args(0) <> "-out") Then
                Text2BinaryBootstrap.DisplayHelp()
                Return
            End If
            reader = File.OpenText(args(2))
            writer = File.Open(args(1), FileMode.Create)
        Else
            Text2BinaryBootstrap.DisplayHelp()
            Return
        End If
        processor.Process(reader, writer)
        writer.Close()
    End Sub

End Module

