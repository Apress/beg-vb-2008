Imports System
Imports System.IO
Imports System.Text

Namespace AsynchronousFile
    Friend Module TestAsynchronousFile
        Dim data As Byte() = New Byte(&H30D40 - 1) {}
        Sub DoAsyncRead(ByVal lambdaAsync As IAsyncResult)
            Dim localFS As FileStream = DirectCast(lambdaAsync.AsyncState, FileStream)
            Dim bytesRead As Integer = localFS.EndRead(lambdaAsync)
            Dim buffer As String = Encoding.ASCII.GetString(Data)
            Console.WriteLine(("Buffer bytes read (" & bytesRead & ")"))
            localFS.Close()
        End Sub
        ' Methods
        Private Sub LoadFileAsynchronously()
            Dim fs As New FileStream(TestAsynchronousFile.filename, FileMode.Open)
            fs.BeginRead(Data, 0, Data.Length, AddressOf DoAsyncRead, fs).AsyncWaitHandle.WaitOne()
        End Sub

        Public Sub RunAll()
            TestAsynchronousFile.LoadFileAsynchronously()
        End Sub


        ' Fields
        Private filename As String = "C:\Documents and Settings\cgross\My Documents\Visual Studio Codename Orcas\Projects\JugglingTasks\JugglingTasks\threads.cs"
    End Module
End Namespace

