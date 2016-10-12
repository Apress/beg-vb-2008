Imports System.Threading

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _thread = New Thread(New ThreadStart(AddressOf PeriodicIncrement))
        _thread.Start()
    End Sub

    Private _counter As Integer
    Private Sub IncrementCounter()
        Me.TextBox1.Text = "Counter (" & _counter & ")"
        _counter += 1
    End Sub

    Delegate Sub DelegateIncrementCounter()

    Private Sub PeriodicIncrement()
        Do While True
            Invoke(New DelegateIncrementCounter(AddressOf IncrementCounter))
            'IncrementCounter()
            Thread.Sleep(1000)
        Loop
    End Sub
    Dim _thread As Thread

End Class
