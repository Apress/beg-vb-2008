Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports System.Text

<CompilerGenerated, DebuggerDisplay("\{ a = {a}, b = {b}, c = {c} }", Type:="<Anonymous Type>")> _
Friend NotInheritable Class <>f__AnonymousType2(Of <a>j__TPar, <b>j__TPar, <c>j__TPar)
    ' Methods
    <DebuggerHidden> _
    Public Sub New(ByVal a As <a>j__TPar, ByVal b As <b>j__TPar, ByVal c As <c>j__TPar)
        Me.<a>i__Field = a
        Me.<b>i__Field = b
        Me.<c>i__Field = c
    End Sub

    <DebuggerHidden> _
    Public Overrides Function Equals(ByVal value As Object) As Boolean
        Dim type = TryCast(value,<>f__AnonymousType2(Of <a>j__TPar, <b>j__TPar, <c>j__TPar))
        Return ((((Not type Is Nothing) AndAlso EqualityComparer(Of <a>j__TPar).Default.Equals(Me.<a>i__Field, type.<a>i__Field)) AndAlso EqualityComparer(Of <b>j__TPar).Default.Equals(Me.<b>i__Field, type.<b>i__Field)) AndAlso EqualityComparer(Of <c>j__TPar).Default.Equals(Me.<c>i__Field, type.<c>i__Field))
    End Function

    <DebuggerHidden> _
    Public Overrides Function GetHashCode() As Integer
        Dim num As Integer = -842606958
        num = ((-1521134295 * num) + EqualityComparer(Of <a>j__TPar).Default.GetHashCode(Me.<a>i__Field))
        num = ((-1521134295 * num) + EqualityComparer(Of <b>j__TPar).Default.GetHashCode(Me.<b>i__Field))
        Return ((-1521134295 * num) + EqualityComparer(Of <c>j__TPar).Default.GetHashCode(Me.<c>i__Field))
    End Function

    <DebuggerHidden> _
    Public Overrides Function ToString() As String
        Dim builder As New StringBuilder
        builder.Append("{ a = ")
        builder.Append(Me.<a>i__Field)
        builder.Append(", b = ")
        builder.Append(Me.<b>i__Field)
        builder.Append(", c = ")
        builder.Append(Me.<c>i__Field)
        builder.Append(" }")
        Return builder.ToString
    End Function


    ' Properties
    Public ReadOnly Property a As <a>j__TPar
        Get
            Return Me.<a>i__Field
        End Get
    End Property

    Public ReadOnly Property b As <b>j__TPar
        Get
            Return Me.<b>i__Field
        End Get
    End Property

    Public ReadOnly Property c As <c>j__TPar
        Get
            Return Me.<c>i__Field
        End Get
    End Property


    ' Fields
    <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
    Private ReadOnly <a>i__Field As <a>j__TPar
    <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
    Private ReadOnly <b>i__Field As <b>j__TPar
    <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
    Private ReadOnly <c>i__Field As <c>j__TPar
End Class


