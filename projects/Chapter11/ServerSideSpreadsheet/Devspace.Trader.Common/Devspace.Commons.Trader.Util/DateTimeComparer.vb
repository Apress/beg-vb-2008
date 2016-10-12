Imports System

Namespace Devspace.Commons.Trader.Util
    Public Class DateTimeComparer
        ' Methods
        Public Shared Function [Compare](ByVal orig As DateTime, ByVal toCompare As DateTime) As Integer
            If (orig.Year < toCompare.Year) Then
                Return -1
            End If
            If (orig.Year > toCompare.Year) Then
                Return 1
            End If
            If (orig.Month < toCompare.Month) Then
                Return -1
            End If
            If (orig.Month > toCompare.Month) Then
                Return 1
            End If
            If (orig.Day < toCompare.Day) Then
                Return -1
            End If
            If (orig.Day > toCompare.Day) Then
                Return 1
            End If
            If (orig.Hour < toCompare.Hour) Then
                Return -1
            End If
            If (orig.Hour > toCompare.Hour) Then
                Return 1
            End If
            If (orig.Minute < toCompare.Minute) Then
                Return -1
            End If
            If (orig.Minute > toCompare.Minute) Then
                Return 1
            End If
            If (orig.Second < toCompare.Second) Then
                Return -1
            End If
            If (orig.Second > toCompare.Second) Then
                Return 1
            End If
            Return 0
        End Function

        Public Shared Function CompareToMinute(ByVal orig As DateTime, ByVal toCompare As DateTime) As Integer
            If (orig.Year < toCompare.Year) Then
                Return -1
            End If
            If (orig.Year > toCompare.Year) Then
                Return 1
            End If
            If (orig.Month < toCompare.Month) Then
                Return -1
            End If
            If (orig.Month > toCompare.Month) Then
                Return 1
            End If
            If (orig.Day < toCompare.Day) Then
                Return -1
            End If
            If (orig.Day > toCompare.Day) Then
                Return 1
            End If
            If (orig.Hour < toCompare.Hour) Then
                Return -1
            End If
            If (orig.Hour > toCompare.Hour) Then
                Return 1
            End If
            If (orig.Minute < toCompare.Minute) Then
                Return -1
            End If
            If (orig.Minute > toCompare.Minute) Then
                Return 1
            End If
            Return 0
        End Function

    End Class
End Namespace

