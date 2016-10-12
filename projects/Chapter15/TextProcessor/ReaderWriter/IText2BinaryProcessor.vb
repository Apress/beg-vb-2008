Imports System
Imports System.IO

Namespace ReaderWriter
    Public Interface IText2BinaryProcessor
        ' Methods
        Sub Process(ByVal input As TextReader, ByVal output As Stream)
    End Interface
End Namespace

