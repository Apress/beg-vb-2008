
Structure MyValueType
    Public value As Integer
End Structure

Class MyReferenceType
    ' Fields
    Public value As Integer
End Class

Class MyReferenceTypeWithValueType
    ' Fields
    Public embeddedValue As MyValueType
    Public value As Integer
End Class

Structure MyValueTypeWithValueType
    Public value As Integer
    Public embeddedValue As MyValueType
End Structure


Structure MyValueTypeWithReferenceType
    Public value As Integer
    Public reference As MyReferenceType
End Structure

Module Module1
    Sub Method(ByRef value As MyValueType, ByVal reference As MyReferenceType)
        value.value = 10
        reference.value = 10
    End Sub

    Sub Caller()
        Dim value As MyValueType
        Dim reference As MyReferenceType = New MyReferenceType()
        Method(value, reference)
        Console.WriteLine("value value=" & value.value & " reference value=" & reference.value)

    End Sub

    Sub ArrayExample()
        Dim items() As Integer

        ReDim items(2)
        items(0) = 10
        items(1) = 10
        items(2) = 30
        ReDim Preserve items(1)
        items(2) = 40

        Dim another() = items

    End Sub
    Sub Example(ByRef inp As Integer)
        inp = 10
        Console.WriteLine("Value (" & inp & ")")
    End Sub
    Sub Main()
        Dim val = 20
        Console.WriteLine("Value (" & val & ")")
        'Example(val)
        'Caller()
        Dim maxDest = SearchSolution.Node.GetMaxPossibleDestinationsArraySize()
        ArrayExample()
        Console.WriteLine("Value (" & val & ")")
        Console.ReadKey()
    End Sub

End Module
