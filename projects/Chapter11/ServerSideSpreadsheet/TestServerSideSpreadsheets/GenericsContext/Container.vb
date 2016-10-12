Imports System

Namespace GenericsContext
    Public Class Container
        ' Methods
        Public Sub New(ByVal toManage As Object)
            Me._managed = toManage
        End Sub


        ' Properties
        Public ReadOnly Property Managed As Object
            Get
                Return Me._managed
            End Get
        End Property


        ' Fields
        Private _managed As Object
    End Class
End Namespace

