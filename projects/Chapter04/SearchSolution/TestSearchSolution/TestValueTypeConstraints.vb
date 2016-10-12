Module TestValueTypeConstraints
    Private Sub Constraint1()
        Dim var As New MyValueType
        Dim copiedVar As MyValueType = var
        Console.WriteLine("var value=" & var.value & " copiedVar value=" & copiedVar.value)
        var.value = 10
        Console.WriteLine("var value=" & var.value & " copiedVar value=" & copiedVar.value)
        Dim val As New MyReferenceType
        Dim copiedVal As MyReferenceType = val
        Console.WriteLine("val value=" & val.value & " copiedVal value=" & copiedVal.value)
        val.value = 10
        Console.WriteLine("val value=" & val.value & " copiedVal value=" & copiedVal.value)
    End Sub

    Private Sub Constraint2()
        Dim var As New MyValueTypeWithReferenceType
        var.reference = New MyReferenceType
        Dim copiedVar As MyValueTypeWithReferenceType = var
        Console.WriteLine("var value=" & var.reference.value & " copiedVar value=" & copiedVar.reference.value)
        var.reference.value = 10
        Console.WriteLine("var value=" & var.reference.value & " copiedVar value=" & copiedVar.reference.value)
    End Sub

    Private Sub Constraint3()
        Dim value As New MyValueType
        Dim reference As New MyReferenceType
        TestValueTypeConstraints.Method(value, reference)
        Console.WriteLine("value value=" & value.value & " reference value=" & reference.value)
    End Sub

    Private Sub Method(ByVal value As MyValueType, ByVal reference As MyReferenceType)
        value.value = 10
        reference.value = 10
    End Sub

    Public Sub Run()
        TestValueTypeConstraints.Constraint3()
    End Sub

    Private Sub TruthTable()
        Dim var As New MyValueTypeWithValueType
        Dim copiedVar As MyValueTypeWithValueType = var
        Console.WriteLine(String.Concat(New Object() {"var value=", var.embeddedValue.value, " copiedVar value=", copiedVar.embeddedValue.value}))
        var.embeddedValue.value = 10
        Console.WriteLine(String.Concat(New Object() {"var value=", var.embeddedValue.value, " copiedVar value=", copiedVar.embeddedValue.value}))
    End Sub


End Module