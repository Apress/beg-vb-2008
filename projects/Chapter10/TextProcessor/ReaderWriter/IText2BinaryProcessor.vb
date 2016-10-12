Imports System
Imports System.IO

Public Interface IText2BinaryProcessor
    Sub Process(ByVal input As TextReader, ByVal output As Stream)
End Interface

