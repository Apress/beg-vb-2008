Imports System

Friend Class ExampleMgr(Of DataType As IExample)
    ' Methods
    Public Sub New(ByVal inst As DataType)
        Me._inst = inst
    End Sub

    Public Sub DoSomething()
        Me._inst.Method()
    End Sub


    ' Properties
    Public ReadOnly Property Inst() As DataType
        Get
            Return Me._inst
        End Get
    End Property


    ' Fields
    Private _inst As DataType
End Class

