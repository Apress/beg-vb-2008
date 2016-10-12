Imports System

Namespace Devspace.Trader.Common.ServerSpreadsheet
    Friend Class ObjectReference
        ' Methods
        Public Sub New(ByVal reference As Object, ByVal identifier As String)
            Me._reference = reference
            Me._identifier = identifier
        End Sub

        Public Overrides Function ToString() As String
            Return ("ObjectReference <" & Me._identifier & ">")
        End Function


        ' Properties
        Public ReadOnly Property Identifier As String
            Get
                Return Me._identifier
            End Get
        End Property

        Public ReadOnly Property Reference As Object
            Get
                Return Me._reference
            End Get
        End Property


        ' Fields
        Private _identifier As String
        Private _reference As Object
    End Class
End Namespace

