Public Module CellFactories
    Public Function DoAdd(ByVal cell1 As Func(Of Object), ByVal cell2 As Func(Of Object)) As Func(Of Object)
        Return Function() cell1() + cell2()
    End Function
    Public Function DoMultiply(ByVal cell1 As Func(Of Object), ByVal cell2 As Func(Of Object)) As Func(Of Object)
        Return Function() cell1() + cell2()
    End Function
    Public Function FixedValue(ByVal value As Object) As Func(Of Object)
        Return Function() value
    End Function
End Module

