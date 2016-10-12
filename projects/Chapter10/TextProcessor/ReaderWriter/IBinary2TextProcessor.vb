Imports System
Imports System.IO

Public Interface IBinary2TextProcessor
    Sub Process(ByVal input As Stream, ByVal output As TextWriter)
End Interface

