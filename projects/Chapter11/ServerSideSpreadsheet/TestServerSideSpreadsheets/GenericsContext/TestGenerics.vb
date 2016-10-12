Imports System

Namespace GenericsContext
    Public Class TestGenerics
        ' Methods
        Private Shared Sub IllustrateGenericContainer()
            Dim container As New GenericsContainer(Of MyType)(New MyType)
            container.Managed.Method
        End Sub

        Private Shared Sub IllustrateObjectContainer()
            Dim container As New Container(New MyType)
            If TypeOf container.Managed Is MyType Then
                TryCast(container.Managed, MyType).Method()
            End If
        End Sub

        Public Shared Sub RunAll()
            TestGenerics.IllustrateObjectContainer
            TestGenerics.IllustrateGenericContainer
        End Sub

    End Class
End Namespace

