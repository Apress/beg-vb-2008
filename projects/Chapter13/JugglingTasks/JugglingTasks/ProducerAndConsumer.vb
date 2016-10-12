Imports System.Collections.Generic
Imports System.Threading

Namespace ProducerAndConsumer

    Class ThreadPoolProducerConsumer

        Private _queue As Queue(Of Action) = New Queue(Of Action)()

        private Sub QueueProcessor(Byval obj As Object) {
            Monitor.Enter(_queue)
            Do While _queue.Count = 0
                Monitor.Wait(_queue, -1)
            Loop
            Dim action = _queue.Dequeue()
            Monitor.Exit(_queue)
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf QueueProcessor))
            action()
        End Sub

        Public Sub New()
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf QueueProcessor))
        End Sub

        Public Sub Invoke(ByVal toExec As Action)
            Monitor.Enter(_queue)
            _queue.Enqueue(toExec)
            Monitor.Pulse(_queue)
            Monitor.Exit(_queue)
        End Sub
    End Class

End Namespace