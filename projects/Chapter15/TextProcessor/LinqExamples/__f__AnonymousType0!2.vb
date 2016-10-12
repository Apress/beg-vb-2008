Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports System.Text

<DebuggerDisplay("\{ identifier = {identifier}, points = {points} }", Type:="<Anonymous Type>"), CompilerGenerated> _
Friend NotInheritable Class <>f__AnonymousType0(Of <identifier>j__TPar, <points>j__TPar)
    ' Methods
    <DebuggerHidden> _
    Public Sub New(ByVal identifier As <identifier>j__TPar, ByVal points As <points>j__TPar)
        Me.<identifier>i__Field = identifier
        Me.<points>i__Field = points
    End Sub

    <DebuggerHidden> _
    Public Overrides Function Equals(ByVal value As Object) As Boolean
        Dim type = TryCast(value,<>f__AnonymousType0(Of <identifier>j__TPar, <points>j__TPar))
        Return (((Not type Is Nothing) AndAlso EqualityComparer(Of <identifier>j__TPar).Default.Equals(Me.<identifier>i__Field, type.<identifier>i__Field)) AndAlso EqualityComparer(Of <points>j__TPar).Default.Equals(Me.<points>i__Field, type.<points>i__Field))
    End Function

    <DebuggerHidden> _
    Public Overrides Function GetHashCode() As Integer
        Dim num As Integer = &H17EF89F2
        num = ((-1521134295 * num) + EqualityComparer(Of <identifier>j__TPar).Default.GetHashCode(Me.<identifier>i__Field))
        Return ((-1521134295 * num) + EqualityComparer(Of <points>j__TPar).Default.GetHashCode(Me.<points>i__Field))
    End Function

    <DebuggerHidden> _
    Public Overrides Function ToString() As String
        Dim builder As New StringBuilder
        builder.Append("{ identifier = ")
        builder.Append(Me.<identifier>i__Field)
        builder.Append(", points = ")
        builder.Append(Me.<points>i__Field)
        builder.Append(" }")
        Return builder.ToString
    End Function


    ' Properties
    Public ReadOnly Property identifier As <identifier>j__TPar
        Get
            Return Me.<identifier>i__Field
        End Get
    End Property

    Public ReadOnly Property points As <points>j__TPar
        Get
            Return Me.<points>i__Field
        End Get
    End Property


    ' Fields
    <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
    Private ReadOnly <identifier>i__Field As <identifier>j__TPar
    <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
    Private ReadOnly <points>i__Field As <points>j__TPar
End Class


