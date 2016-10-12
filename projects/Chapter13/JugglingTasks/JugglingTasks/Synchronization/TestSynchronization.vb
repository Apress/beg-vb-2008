Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Threading

Namespace Synchronization
    Module DeadlockedThread
        Private elements As New List(Of Integer)
        Sub Task1()
            Dim items As Integer()
            Thread.Sleep(1000)
            SyncLock elements
                Do While (elements.Count < 3)
                    Thread.Sleep(1000)
                Loop
                items = elements.ToArray
            End SyncLock
            Dim item As Integer
            For Each item In items
                Console.WriteLine(("Item (" & item & ")"))
                Thread.Sleep(&H3E8)
            Next
        End Sub
        Sub Task2()
            Thread.Sleep(1500)
            SyncLock elements
                elements.Add(30)
            End SyncLock
        End Sub

        Public Sub Run()
            elements.Add(10)
            elements.Add(20)
            Dim thread1 As New Thread(AddressOf Task1)
            Dim thread2 As New Thread(AddressOf Task2)
            thread1.Start()
            thread2.Start()
        End Sub
    End Module

    Module SafeThread
        Dim elements As New List(Of Integer)
        Sub Task1()
            Thread.Sleep(&H3E8)
            Monitor.Enter(elements)
            Do While (elements.Count < 3)
                Monitor.Wait(elements, &H3E8)
            Loop
            Dim items As Integer() = elements.ToArray
            Monitor.Exit(elements)
            Dim item As Integer
            For Each item In items
                Console.WriteLine(("Item (" & item & ")"))
                Thread.Sleep(&H3E8)
            Next
        End Sub
        Sub Task2()
            Thread.Sleep(&H5DC)
            Monitor.Enter(elements)
            elements.Add(30)
            Monitor.Pulse(elements)
            Monitor.Exit(elements)
        End Sub
        Public Sub Run()
            elements.Add(10)
            elements.Add(20)
            Dim thread1 As New Thread(AddressOf Task1)
            Dim thread2 As New Thread(AddressOf Task2)
            thread1.Start()
            thread2.Start()
        End Sub
    End Module

    Module SynchronizedAndEfficientThread
        Private elements As New List(Of Integer)
        Sub Task1()
            Dim items As Integer()
            Thread.Sleep(1000)
            SyncLock elements
                items = elements.ToArray
            End SyncLock
            Dim item As Integer
            For Each item In items
                Console.WriteLine(("Item (" & item & ")"))
                Thread.Sleep(&H3E8)
            Next
        End Sub
        Sub Task2()
            Thread.Sleep(1500)
            SyncLock elements
                elements.Add(30)
            End SyncLock
        End Sub
        Public Sub run()
            elements.Add(10)
            elements.Add(20)
            Dim thread1 As New Thread(AddressOf Task1)
            Dim thread2 As New Thread(AddressOf Task2)
            thread1.Start()
            thread2.Start()
        End Sub
    End Module

    Module SynchronizedThread
        Private elements As New List(Of Integer)
        Sub Task1()
            Thread.Sleep(1000)
            SyncLock elements
                Dim item As Integer
                For Each item In New ReadOnlyCollection(Of Integer)(elements)
                    Console.WriteLine(("Item (" & item & ")"))
                    Thread.Sleep(1000)
                Next
            End SyncLock
        End Sub
        Sub Task2()
            Thread.Sleep(1500)
            SyncLock elements
                elements.Add(30)
            End SyncLock
        End Sub
        Public Sub Run()
            elements.Add(10)
            elements.Add(20)
            Dim thread1 As New Thread(AddressOf Task1)
            Dim thread2 As New Thread(AddressOf Task2)
            thread1.Start()
            thread2.Start()
        End Sub

    End Module

    Module ThreadProblem
        Private elements As New List(Of Integer)
        Sub Task1()
            Thread.Sleep(1000)
            Dim item As Integer
            For Each item In elements
                Console.WriteLine(("Item (" & item & ")"))
                Thread.Sleep(1000)
            Next
        End Sub
        Sub Task2()
            Thread.Sleep(1500)
            elements.Add(30)
        End Sub
        Public Sub Run()
            elements.Add(10)
            elements.Add(20)
            Dim thread1 As New Thread(AddressOf Task1)
            Dim thread2 As New Thread(AddressOf Task2)
            thread1.Start()
            thread2.Start()
        End Sub

    End Module

    Module ThreadProblem2
        Dim elements As New List(Of Integer)
        Sub Task1()
            Thread.Sleep(1000)
            Dim item As Integer
            For Each item In New ReadOnlyCollection(Of Integer)(elements)
                Console.WriteLine(("Item (" & item & ")"))
                Thread.Sleep(1000)
            Next
        End Sub
        Sub Task2()
            Thread.Sleep(1500)
            elements.Add(30)
        End Sub
        Public Sub Run()
            elements.Add(10)
            elements.Add(20)
            Dim thread1 As New Thread(AddressOf Task1)
            Dim thread2 As New Thread(AddressOf Task2)
            thread1.Start()
            thread2.Start()
        End Sub
    End Module

    
End Namespace

