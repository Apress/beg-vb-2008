Imports System

Namespace Scenario2
    Friend Class Test
        ' Methods
        Public Shared Sub Run()
            Dim derivedCls As New Derived
            Dim baseCls As Base = derivedCls
            derivedCls.Method
            baseCls.Method
        End Sub

    End Class
End Namespace

