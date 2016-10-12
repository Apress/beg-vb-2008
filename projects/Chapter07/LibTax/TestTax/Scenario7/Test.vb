Imports System

Namespace Scenario7
    Friend Class Test
        ' Methods
        Public Shared Sub Run()
            Dim derivedCls As New Derived3
            Dim baseCls As Base = derivedCls
            Dim derived2cls As Derived2 = derivedCls
            derivedCls.Method
            baseCls.Method
            derived2cls.Method
        End Sub

    End Class
End Namespace

