Imports System

Friend Class ExampleMgr
    ' Methods
    Public Sub New(ByVal inst As IExample)
        Me._inst = inst
    End Sub

    Public Sub DoSomething()
        Me._inst.Method()
    End Sub


    ' Fields
    Private _inst As IExample
End Class

