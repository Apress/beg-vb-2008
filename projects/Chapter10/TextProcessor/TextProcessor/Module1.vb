#Const DEBUG_OUPUT = True

Module Module1
    'TODO Something
    Public Sub Main(ByVal args() As String)
#If DEBUG_OUPUT Then
        Console.WriteLine("arg count (" & args.Length & ")")
#End If

        Console.ReadKey()
    End Sub


End Module
