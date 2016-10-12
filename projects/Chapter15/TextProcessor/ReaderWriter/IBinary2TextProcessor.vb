Imports System
Imports System.IO

Namespace ReaderWriter
    Public Interface IBinary2TextProcessor
        ' Methods
        Sub Process(ByVal input As Stream, ByVal output As TextWriter)
    End Interface
End Namespace

