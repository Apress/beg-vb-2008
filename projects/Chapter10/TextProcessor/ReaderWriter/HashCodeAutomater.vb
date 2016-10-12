' Example usage
'
Class HashcodeExample
    Public value As Integer
    Public buffer As String

    Public Sub New(ByVal val As Integer, ByVal buf As String)
        value = val
        buffer = buf
    End Sub
    Public Overrides Function GetHashCode() As Integer
        Return New HashCodeAutomater() _
            .Append(value) _
            .Append(buffer).toHashCode()
    End Function

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        If TypeOf (obj) Is HashcodeExample Then
            If obj.GetHashCode() = Me.GetHashCode Then
                Return True
            End If
        End If
        Return False
    End Function

End Class


Public Class HashCodeAutomater
    ' Methods
    Public Sub New()
        _constant = &H25
        _runningTotal = &H11
    End Sub

    Public Sub New(ByVal initialNonZeroOddNumber As Integer, ByVal multiplierNonZeroOddNumber As Integer)
        If (initialNonZeroOddNumber = 0) Then
            Throw New ArgumentOutOfRangeException("HashCodeBuilder requires a non zero initial value")
        End If
        If ((initialNonZeroOddNumber Mod 2) = 0) Then
            Throw New ArgumentOutOfRangeException("HashCodeBuilder requires an odd initial value")
        End If
        If (multiplierNonZeroOddNumber = 0) Then
            Throw New ArgumentOutOfRangeException("HashCodeBuilder requires a non zero multiplier")
        End If
        If ((multiplierNonZeroOddNumber Mod 2) = 0) Then
            Throw New ArgumentOutOfRangeException("HashCodeBuilder requires an odd multiplier")
        End If
        Me._constant = multiplierNonZeroOddNumber
        Me._runningTotal = initialNonZeroOddNumber
    End Sub

    Public Function Append(ByVal value As Boolean) As HashCodeAutomater
        Me._runningTotal = ((Me._runningTotal * Me._constant) + IIf(value, 0, 1))
        Return Me
    End Function

    Public Function Append(ByVal value As Byte) As HashCodeAutomater
        Me._runningTotal = ((Me._runningTotal * Me._constant) + value)
        Return Me
    End Function

    Public Function Append(ByVal value As Char) As HashCodeAutomater
        Me._runningTotal = ((Me._runningTotal * Me._constant) + Val(value))
        Return Me
    End Function

    Public Function Append(ByVal value As Double) As HashCodeAutomater
        Return Me.Append(BitConverter.DoubleToInt64Bits(value))
    End Function

    Public Function Append(ByVal value As Short) As HashCodeAutomater
        Me._runningTotal = ((Me._runningTotal * Me._constant) + value)
        Return Me
    End Function

    Public Function Append(ByVal value As Integer) As HashCodeAutomater
        Me._runningTotal = ((Me._runningTotal * Me._constant) + value)
        Return Me
    End Function

    Public Function Append(ByVal value As Long) As HashCodeAutomater
        Me._runningTotal = ((Me._runningTotal * Me._constant) + CInt((value Xor (value >> &H20))))
        Return Me
    End Function

    Public Function Append(ByVal obj As Object) As HashCodeAutomater
        If (obj Is Nothing) Then
            Me._runningTotal = (Me._runningTotal * Me._constant)
        ElseIf Not obj.GetType.IsArray Then
            Me._runningTotal = ((Me._runningTotal * Me._constant) + obj.GetHashCode)
        ElseIf TypeOf obj Is Long() Then
            Me.Append(DirectCast(obj, Long()))
        ElseIf TypeOf obj Is Integer() Then
            Me.Append(DirectCast(obj, Integer()))
        ElseIf TypeOf obj Is Short() Then
            Me.Append(DirectCast(obj, Short()))
        ElseIf TypeOf obj Is Char() Then
            Me.Append(DirectCast(obj, Char()))
        ElseIf TypeOf obj Is Byte() Then
            Me.Append(DirectCast(obj, Byte()))
        ElseIf TypeOf obj Is Double() Then
            Me.Append(DirectCast(obj, Double()))
        ElseIf TypeOf obj Is Single() Then
            Me.Append(DirectCast(obj, Single()))
        ElseIf TypeOf obj Is Boolean() Then
            Me.Append(DirectCast(obj, Boolean()))
        Else
            Me.Append(DirectCast(obj, Object()))
        End If
        Return Me
    End Function

    Public Function Append(ByVal value As Single) As HashCodeAutomater
        Me._runningTotal = ((Me._runningTotal * Me._constant) + Convert.ToInt32(value))
        Return Me
    End Function

    Public Function Append(ByVal array As Boolean()) As HashCodeAutomater
        If (array Is Nothing) Then
            Me._runningTotal = (Me._runningTotal * Me._constant)
        Else
            Dim i As Integer
            For i = 0 To array.Length - 1
                Me.Append(array(i))
            Next i
        End If
        Return Me
    End Function

    Public Function Append(ByVal array As Byte()) As HashCodeAutomater
        If (array Is Nothing) Then
            Me._runningTotal = (Me._runningTotal * Me._constant)
        Else
            Dim i As Integer
            For i = 0 To array.Length - 1
                Me.Append(array(i))
            Next i
        End If
        Return Me
    End Function

    Public Function Append(ByVal array As Char()) As HashCodeAutomater
        If (array Is Nothing) Then
            Me._runningTotal = (Me._runningTotal * Me._constant)
        Else
            Dim i As Integer
            For i = 0 To array.Length - 1
                Me.Append(array(i))
            Next i
        End If
        Return Me
    End Function

    Public Function Append(ByVal array As Double()) As HashCodeAutomater
        If (array Is Nothing) Then
            Me._runningTotal = (Me._runningTotal * Me._constant)
        Else
            Dim i As Integer
            For i = 0 To array.Length - 1
                Me.Append(array(i))
            Next i
        End If
        Return Me
    End Function

    Public Function Append(ByVal array As Short()) As HashCodeAutomater
        If (array Is Nothing) Then
            Me._runningTotal = (Me._runningTotal * Me._constant)
        Else
            Dim i As Integer
            For i = 0 To array.Length - 1
                Me.Append(array(i))
            Next i
        End If
        Return Me
    End Function

    Public Function Append(ByVal array As Integer()) As HashCodeAutomater
        If (array Is Nothing) Then
            Me._runningTotal = (Me._runningTotal * Me._constant)
        Else
            Dim i As Integer
            For i = 0 To array.Length - 1
                Me.Append(array(i))
            Next i
        End If
        Return Me
    End Function

    Public Function Append(ByVal array As Long()) As HashCodeAutomater
        If (array Is Nothing) Then
            Me._runningTotal = (Me._runningTotal * Me._constant)
        Else
            Dim i As Integer
            For i = 0 To array.Length - 1
                Me.Append(array(i))
            Next i
        End If
        Return Me
    End Function

    Public Function Append(ByVal array As Object()) As HashCodeAutomater
        If (array Is Nothing) Then
            Me._runningTotal = (Me._runningTotal * Me._constant)
        Else
            Dim i As Integer
            For i = 0 To array.Length - 1
                Me.Append(array(i))
            Next i
        End If
        Return Me
    End Function

    Public Function Append(ByVal array As Single()) As HashCodeAutomater
        If (array Is Nothing) Then
            Me._runningTotal = (Me._runningTotal * Me._constant)
        Else
            Dim i As Integer
            For i = 0 To array.Length - 1
                Me.Append(array(i))
            Next i
        End If
        Return Me
    End Function

    Public Function AppendSuper(ByVal superHashCode As Integer) As HashCodeAutomater
        _runningTotal = ((_runningTotal * _constant) + superHashCode)
        Return Me
    End Function

    Public Function toHashCode() As Integer
        Return Me._runningTotal
    End Function


    ' Fields
    Private ReadOnly _constant As Integer
    Private _runningTotal As Integer
End Class



