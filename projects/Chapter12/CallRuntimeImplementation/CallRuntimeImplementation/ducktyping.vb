Class AType

End Class

Class Duck
    Public Sub Walk()
        Console.WriteLine("Duck is walking")
    End Sub
End Class

Class Dog
    Public Sub Walk()
        Console.WriteLine("Dog is walking")
    End Sub
End Class
Module DuckTyping
    Public Sub InferTypes()
        Dim val = 10
        'val = New AType()

    End Sub

    Public Sub DoWalk(ByVal aType As Object)
        aType.Walk()
    End Sub

    Public Sub DoDuckTyping()
        Dim duck = New Duck()
        Dim dog = New Dog()

        DoWalk(duck)
        DoWalk(dog)
    End Sub
    Public Sub RunAll()
        DoDuckTyping()
    End Sub
End Module