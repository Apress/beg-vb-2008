Imports System
Imports System.Text

Namespace Tracer
    Public Class FormatToSpaces
        Implements IToStringFormat
        ' Methods
        Public Function FormatBuffer(ByVal inputBuffer As String) As String Implements IToStringFormat.FormatBuffer
            Me._inputBuffer = inputBuffer
            Me._needSpaces = False
            Dim character As Char
            For Each character In Me._inputBuffer
                Select Case character
                    Case "{"c
                        Me._spaceCounter += 1
                        Me._needSpaces = True
                        Exit Select
                    Case "}"c
                        Me._spaceCounter -= 1
                        Me._needSpaces = True
                        Exit Select
                    Case Else
                        If Me._needSpaces Then
                            Me._builder.Append(ChrW(10))
                            Me.GenerateSpaces()
                            Me._needSpaces = False
                        End If
                        Me._builder.Append(character)
                        Exit Select
                End Select
            Next
            Return Me._builder.ToString
        End Function

        Private Sub GenerateSpaces()
            Dim c1 As Integer
            For c1 = 0 To Me._spaceCounter - 1
                Me._builder.Append("   ")
            Next c1
        End Sub


        ' Fields
        Private _builder As StringBuilder = New StringBuilder
        Private _inputBuffer As String
        Private _needSpaces As Boolean
        Private _spaceCounter As Integer
    End Class
End Namespace

