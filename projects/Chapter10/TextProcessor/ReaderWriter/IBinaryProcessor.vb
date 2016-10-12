Imports System
Imports System.IO

Namespace ReaderWriter
    Public Interface IBinaryProcessor
        ' Methods
        Sub Process(ByVal input As Stream, ByVal output As Stream)
    End Interface
End Namespace

