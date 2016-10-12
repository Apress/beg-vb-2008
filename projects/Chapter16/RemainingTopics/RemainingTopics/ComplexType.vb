Imports System

Public NotInheritable Class ComplexType
    Public Sub New(ByVal real As Double, ByVal imaginary As Double)
        _real = real
        _imaginary = imaginary
    End Sub

    Public Shared Operator +(ByVal a As ComplexType, ByVal b As ComplexType) As ComplexType
        Return New ComplexType((a.Real + b.Real), (a.Imaginary + b.Imaginary))
    End Operator

    'Public Shared Function op_Increment(ByVal a As ComplexType) As ComplexType
    '    Return New ComplexType((a.Real + 1), a.Imaginary)
    'End Function

    Public Overrides Function ToString() As String
        Return String.Concat(New Object() {"(", _real, ") (", _imaginary, ")i"})
    End Function

    Public ReadOnly Property Imaginary() As Double
        Get
            Return _imaginary
        End Get
    End Property

    Public Property Real() As Double
        Get
            Return _real
        End Get
        Set(ByVal value As Double)
            _real = value
        End Set
    End Property

    Private ReadOnly _imaginary As Double
    Private _real As Double
End Class

