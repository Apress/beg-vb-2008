Imports Definitions
Imports System
Imports System.Reflection

<DefaultMember("Item")> _
    Friend Class Implementation
    Implements IDefinition
    Public Function TranslateWord(ByVal word As String) As String Implements IDefinition.TranslateWord
        Return (word & ",")
    End Function


    ' Properties
    Default Public Property Item(ByVal word As String) As String Implements IDefinition.Item
        Get
            Throw New Exception("The method or operation is not implemented.")
        End Get
        Set(ByVal value As String)
            Throw New Exception("The method or operation is not implemented.")
        End Set
    End Property

End Class

