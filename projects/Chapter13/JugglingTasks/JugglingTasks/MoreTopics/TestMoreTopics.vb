Imports System
Imports System.Collections.Generic
Imports System.Threading

Namespace MoreTopics
    Friend Module TestMoreTopics
        Private rwlock As New ReaderWriterLock()
        Private elements As New List(Of Integer)

        Sub Task1()
            Thread.Sleep(1000)
            Console.WriteLine("Thread 1 waiting read lock")
            rwlock.AcquireReaderLock(-1)
            Console.WriteLine("Thread 1 have read lock")
            Dim item As Integer
            For Each item In elements
                Console.WriteLine(("Thread 1 Item (" & item & ")"))
                Thread.Sleep(&H3E8)
            Next
            Console.WriteLine("Thread 1 releasing read lock")
            rwlock.ReleaseLock()
        End Sub
        Sub Task2()
            Thread.Sleep(1250)
            Console.WriteLine("Thread 2 waiting read lock")
            rwlock.AcquireReaderLock(-1)
            Console.WriteLine("Thread 2 have read lock")
            Dim item As Integer
            For Each item In elements
                Console.WriteLine(("Thread 2 Item (" & item & ")"))
                Thread.Sleep(&H3E8)
            Next
            Console.WriteLine("Thread 2 releasing read lock")
            rwlock.ReleaseLock()
        End Sub
        Sub Task3()
            Thread.Sleep(1750)
            Console.WriteLine("Thread 3 waiting read lock")
            rwlock.AcquireReaderLock(-1)
            Console.WriteLine("Thread 3 have read lock")
            Dim item As Integer
            For Each item In elements
                Console.WriteLine(("Thread 3 Item (" & item & ")"))
                Thread.Sleep(&H3E8)
            Next
            Console.WriteLine("Thread 3 releasing read lock")
            rwlock.ReleaseLock()
        End Sub
        Sub Task4()
            Thread.Sleep(1500)
            Console.WriteLine("Thread 4 waiting write lock")
            rwlock.AcquireWriterLock(-1)
            Console.WriteLine("Thread 4 have write Lock")
            elements.Add(30)
            Console.WriteLine("Thread 4 releasing write lock")
            rwlock.ReleaseLock()
        End Sub
        Private Sub ReaderWriter()
            elements.Add(10)
            elements.Add(20)
            Dim thread1 As New Thread(AddressOf Task1)
            Dim thread2 As New Thread(AddressOf Task2)
            Dim thread3 As New Thread(AddressOf Task3)
            Dim thread4 As New Thread(AddressOf Task4)
            thread1.Start()
            thread2.Start()
            thread3.Start()
            thread4.Start()
        End Sub

        Public Sub RunAll()
            TestMoreTopics.ReaderWriter()
        End Sub

    End Module
End Namespace

