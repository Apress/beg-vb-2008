Public Class TraderBaseClass
    Implements IDebug

    Public Property Debug() As Boolean Implements IDebug.Debug
        Get
            Return _debug
        End Get
        Set(ByVal value As Boolean)
            _debug = value
        End Set
    End Property

    Private _debug As Boolean

End Class
