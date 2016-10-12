Imports System
Imports System.Runtime.InteropServices

Namespace Automators
    Public Class TraderCommon
        ' Methods
        Public Shared Function CalculateHFactor(ByVal strike As Double, ByVal spot As Double, ByVal volatility As Double, ByVal timeToExpiry As Double) As Double
            If (strike > spot) Then
                Return (Math.Log((strike / spot)) / (volatility * Math.Sqrt(timeToExpiry)))
            End If
            Return (Math.Log((strike / spot)) / (volatility * Math.Sqrt(timeToExpiry)))
        End Function

        Public Shared Function ConvertFromIBDate(ByVal buffer As String) As DateTime
            Dim year As Integer = Integer.Parse(buffer.Substring(0, 4))
            Dim month As Integer = Integer.Parse(buffer.Substring(4, 2))
            Dim day As Integer = Integer.Parse(buffer.Substring(6, 2))
            Dim hour As Integer = Integer.Parse(buffer.Substring(10, 2))
            Dim minute As Integer = Integer.Parse(buffer.Substring(13, 2))
            Return New DateTime(year, month, day, hour, minute, Integer.Parse(buffer.Substring(&H10, 2)), 0)
        End Function

        Public Shared Function ConvertFromOptionTicker(ByVal comboticker As String, <Out()> ByRef ticker As String, <Out()> ByRef strike As Double, <Out()> ByRef expiry As String, <Out()> ByRef action As String) As Boolean
            Dim pieces As String() = comboticker.Split(New Char() {"_"c})
            ticker = ""
            strike = 0
            expiry = ""
            action = ""
            If (pieces.Length <> 4) Then
                Return False
            End If
            ticker = pieces(0)
            strike = (Double.Parse(pieces(1)) / 100)
            expiry = pieces(2)
            action = pieces(3)
            Return True
        End Function

        Public Shared Function ConvertToOptionTicker(ByVal ticker As String, ByVal strike As Double, ByVal expiry As String, ByVal right As String) As String
            Return String.Format("{0}_{1}_{2}_{3}", New Object() {ticker, CInt((strike * 100)), expiry, right})
        End Function

        Public Shared Function GetDaysToExpiry(ByVal expiry As String) As Integer
            Dim expiryDate As DateTime = DateTime.Now
            If (expiry.CompareTo("200705") = 0) Then
                expiryDate = New DateTime(&H7D7, 5, &H12, 0, 0, 0, 0)
            ElseIf (expiry.CompareTo("200708") = 0) Then
                expiryDate = New DateTime(&H7D7, 8, &H11, 0, 0, 0, 0)
            End If
            Return (CInt(expiryDate.Subtract(DateTime.Now).TotalDays) + 1)
        End Function

        Public Shared Function GetUSTradingDayEnd(ByVal dateToMod As DateTime) As DateTime
            Return New DateTime(dateToMod.Year, dateToMod.Month, dateToMod.Day, &H16, 0, 0, 0)
        End Function

        Public Shared Function GetUSTradingDayStart(ByVal dateToMod As DateTime) As DateTime
            Return New DateTime(dateToMod.Year, dateToMod.Month, dateToMod.Day, 15, 30, 0, 0)
        End Function

    End Class
End Namespace

