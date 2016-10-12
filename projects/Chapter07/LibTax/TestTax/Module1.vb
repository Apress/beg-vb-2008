Class ClassA
    Public Sub SubA()
        Console.WriteLine("Base.SubA")
    End Sub
    Public Sub SubB()
        Console.WriteLine("Base.SubB")
    End Sub
End Class

Class ClassB
    Inherits ClassA
    Public Overloads Sub SubA()
        Console.WriteLine("Derived.SubA")
    End Sub
    Public Shadows Sub SubB()
        Console.WriteLine("Derived.SubB")
    End Sub

End Class
Module Module1

    Sub Main()
        Dim B As New ClassB
        Dim A As ClassA = B

        A.SubA()
        A.SubB()
        Console.WriteLine("----")
        B.SubA()
        B.SubB()

        'Scenario4.Test.Run()
        Console.WriteLine("----")
        Scenario6.Test.Run()
        Console.ReadKey()
    End Sub

End Module
