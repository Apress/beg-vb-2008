Imports System
Imports System.IO

Public Class Bootstrap
    Public Shared Sub DisplayHelp()
        Console.WriteLine("You need help? Right now?")
    End Sub

    Public Shared Sub Process(ByVal args As String(), ByVal processor As IProcessor)
        Dim reader As TextReader = Nothing
        Dim writer As TextWriter = Nothing
        If (args.Length = 0) Then
            reader = Console.In
            writer = Console.Out
        ElseIf (args.Length = 1) Then
            If (args(0) = "-help") Then
                Bootstrap.DisplayHelp()
                Return
            End If
            reader = File.OpenText(args(0))
            writer = Console.Out
        ElseIf (args.Length = 2) Then
            If (args(0) <> "-out") Then
                Bootstrap.DisplayHelp()
                Return
            End If
            reader = Console.In
            writer = File.CreateText(args(1))
        ElseIf (args.Length = 3) Then
            If (args(0) <> "-out") Then
                Bootstrap.DisplayHelp()
                Return
            End If
            reader = File.OpenText(args(2))
            writer = File.CreateText(args(1))
        Else
            Bootstrap.DisplayHelp()
            Return
        End If
        If TypeOf processor Is IExtendedProcessor Then
            writer.Write(DirectCast(processor, IExtendedProcessor).Initialize)
        End If
        writer.Write(processor.Process(reader.ReadToEnd))
        If TypeOf processor Is IExtendedProcessor Then
            writer.Write(DirectCast(processor, IExtendedProcessor).Destroy)
        End If
    End Sub

End Class

