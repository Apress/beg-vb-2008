Imports System

Namespace GenericsContext
    Public Class GenericsContainer(Of ManagedType)
        Private _managed As ManagedType

        Public Sub New(ByVal toManage As ManagedType)
            _managed = toManage
        End Sub

        Public ReadOnly Property Managed() As ManagedType
            Get
                Return Me._managed
            End Get
        End Property
    End Class

    Module Example
        Public Sub ListOfContainers()
            Dim lst As List(Of GenericsContainer(Of Integer)) = New List(Of GenericsContainer(Of Integer))()


        End Sub

    End Module
End Namespace

