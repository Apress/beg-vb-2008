Imports System
Imports System.Threading

Namespace Threads
    Friend Module TestThreads
        ' Methods
        Sub SimpleThreadTask1()
            Console.WriteLine("hello there")
        End Sub
        Sub SimpleThreadTask2()
            Console.WriteLine("Well then goodbye")
        End Sub
        Private Sub SimpleThread()
            Dim thread1 As New Thread(AddressOf SimpleThreadTask1)
            Dim thread2 As New Thread(AddressOf SimpleThreadTask2)
            thread1.Start()
            thread2.Start()
        End Sub

        Sub SimpleThreadWithStateTask(ByVal buffer As Object)
            Console.WriteLine(("You said (" & Buffer.ToString & ")"))
        End Sub
        Private Sub SimpleThreadWithState()
            Dim thread1 As New Thread(AddressOf SimpleThreadWithStateTask)
            thread1.Start("my text")
        End Sub

        Sub ThreadWaitingTask()
            Console.WriteLine("hello there")
            Thread.Sleep(2000)
        End Sub
        Private Sub ThreadWaiting()
            Dim thread As New Thread(AddressOf ThreadWaitingTask)
            thread.Start()
            thread.Join()
        End Sub

        Private Sub ThreadWithState()
            Dim task As New ThreadedTask("hello")
            Dim thread As New Thread(New ThreadStart(AddressOf task.MethodToRun))
            thread.Start()
        End Sub
        Public Sub RunAll()
            ThreadWaiting()
            SimpleThread()
            ThreadWithState()
        End Sub

    End Module
End Namespace

