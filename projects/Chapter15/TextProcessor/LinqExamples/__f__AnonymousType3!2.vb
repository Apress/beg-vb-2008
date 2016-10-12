Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports System.Text

<DebuggerDisplay("\{ ShouldReward = {ShouldReward}, Customers = {Customers} }", Type:="<Anonymous Type>"), CompilerGenerated> _
Friend NotInheritable Class <>f__AnonymousType3(Of <ShouldReward>j__TPar, <Customers>j__TPar)
    ' Methods
    <DebuggerHidden> _
    Public Sub New(ByVal ShouldReward As <ShouldReward>j__TPar, ByVal Customers As <Customers>j__TPar)
        Me.<ShouldReward>i__Field = ShouldReward
        Me.<Customers>i__Field = Customers
    End Sub

    <DebuggerHidden> _
    Public Overrides Function Equals(ByVal value As Object) As Boolean
        Dim type = TryCast(value,<>f__AnonymousType3(Of <ShouldReward>j__TPar, <Customers>j__TPar))
        Return (((Not type Is Nothing) AndAlso EqualityComparer(Of <ShouldReward>j__TPar).Default.Equals(Me.<ShouldReward>i__Field, type.<ShouldReward>i__Field)) AndAlso EqualityComparer(Of <Customers>j__TPar).Default.Equals(Me.<Customers>i__Field, type.<Customers>i__Field))
    End Function

    <DebuggerHidden> _
    Public Overrides Function GetHashCode() As Integer
        Dim num As Integer = -927325381
        num = ((-1521134295 * num) + EqualityComparer(Of <ShouldReward>j__TPar).Default.GetHashCode(Me.<ShouldReward>i__Field))
        Return ((-1521134295 * num) + EqualityComparer(Of <Customers>j__TPar).Default.GetHashCode(Me.<Customers>i__Field))
    End Function

    <DebuggerHidden> _
    Public Overrides Function ToString() As String
        Dim builder As New StringBuilder
        builder.Append("{ ShouldReward = ")
        builder.Append(Me.<ShouldReward>i__Field)
        builder.Append(", Customers = ")
        builder.Append(Me.<Customers>i__Field)
        builder.Append(" }")
        Return builder.ToString
    End Function


    ' Properties
    Public ReadOnly Property Customers As <Customers>j__TPar
        Get
            Return Me.<Customers>i__Field
        End Get
    End Property

    Public ReadOnly Property ShouldReward As <ShouldReward>j__TPar
        Get
            Return Me.<ShouldReward>i__Field
        End Get
    End Property


    ' Fields
    <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
    Private ReadOnly <Customers>i__Field As <Customers>j__TPar
    <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
    Private ReadOnly <ShouldReward>i__Field As <ShouldReward>j__TPar
End Class


