Imports System

Namespace Tracer
    Public Class ToStringFormatState
        ' Methods
        Public Shared Sub ToggleToDefault()
            ToStringFormatState._defaultState = ToStringFormatState._defaultFormat
        End Sub

        Public Shared Sub ToggleToSpaces()
            ToStringFormatState._defaultState = ToStringFormatState._spacesFormat
        End Sub


        ' Properties
        Public Shared ReadOnly Property DefaultFormat() As IToStringFormat
            Get
                Return ToStringFormatState._defaultState
            End Get
        End Property


        ' Fields
        Private Shared _defaultFormat As IToStringFormat = New DefaultFormatter
        Private Shared _defaultState As IToStringFormat = ToStringFormatState._defaultFormat
        Private Shared _spacesFormat As IToStringFormat = New FormatToSpaces

        ' Nested Types
        Private Class DefaultFormatter
            Implements IToStringFormat
            ' Methods
            Public Function FormatBuffer(ByVal input As String) As String Implements IToStringFormat.FormatBuffer
                Return input
            End Function

        End Class
    End Class
End Namespace

