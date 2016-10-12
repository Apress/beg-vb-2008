Imports System

Public Interface IExtendedProcessor
    Inherits IProcessor
    Function Destroy() As String
    Function Initialize() As String
End Interface

