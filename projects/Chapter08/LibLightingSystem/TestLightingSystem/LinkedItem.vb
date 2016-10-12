Imports LibLightingSystem
Imports System

Namespace TestLightingSystem
    Friend Class LinkedItem
        Inherits BaseLinkedList
        ' Methods
        Public Sub New(ByVal identifier As String)
            Me._identifier = identifier
        End Sub

        Public Overrides Function ToString() As String
            Dim buffer As String = ("this(" & Me._identifier & ")")
            If (Not MyBase.Next Is Nothing) Then
                buffer = (buffer & " next(" & DirectCast(MyBase.Next, LinkedItem).Identifier & ")")
            Else
                buffer = (buffer & " next(null)")
            End If
            If (Not MyBase.Prev Is Nothing) Then
                Return (buffer & " prev(" & DirectCast(MyBase.Prev, LinkedItem).Identifier & ")")
            End If
            Return (buffer & " prev(null)")
        End Function


        ' Properties
        Public ReadOnly Property Identifier As String
            Get
                Return Me._identifier
            End Get
        End Property


        ' Fields
        Private _identifier As String
    End Class
End Namespace

