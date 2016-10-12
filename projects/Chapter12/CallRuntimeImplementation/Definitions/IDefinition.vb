Imports System
Imports System.Reflection

<DefaultMember("Item")> _
    Public Interface IDefinition
    Function TranslateWord(ByVal word As String) As String

    Default Property Item(ByVal word As String) As String
End Interface

