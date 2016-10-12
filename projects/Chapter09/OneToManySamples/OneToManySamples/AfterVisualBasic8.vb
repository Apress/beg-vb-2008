Namespace AfterVisualBasic8
    Friend Class Another
    End Class

    Class Example
        Public Property Value() As Integer
            Get
                Return _value
            End Get
            Set(ByVal value As Integer)
                _value = value
            End Set
        End Property

        Private _value As Integer
    End Class

    Friend Module Tests
        Private Sub PlainVanillaObjects()
            Dim objects As IList(Of Example) = New List(Of Example)()

            objects.Add(New Example With {.Value = 10})
            objects.Add(New Example With {.Value = 20})
            For Each obj As Example In objects
                Console.WriteLine("Object value (" & obj.Value & ")")
            Next
        End Sub
        Private Sub MixedObjects()
            Dim objects As IList(Of Example) = New List(Of Example)()

            objects.Add(New Example With {.Value = 10})
            objects.Add(New Example With {.Value = 20})
            ' Following will not compile
            'objects.Add(New Another())
            For Each obj As Example In objects
                Console.WriteLine("Object value (" & obj.Value & ")")
            Next
        End Sub
        Private Sub MixedObjectsPossible()
            Dim objects As IList(Of Object) = New List(Of Object)()

            objects.Add(New Example With {.Value = 10})
            objects.Add(New Example With {.Value = 20})
            objects.Add(New Another())
            For Each obj As Object In objects
                If TypeOf (obj) Is Example Then
                    Console.WriteLine("Object value (" & obj.Value & ")")
                ElseIf TypeOf (obj) Is Another Then
                    Console.WriteLine("This is another object")
                End If
            Next
        End Sub
        Private Sub KeyValue()
            Dim worksheet As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()

            Dim stack As Stack(Of Integer)

        End Sub
        Public Sub RunAll()
            PlainVanillaObjects()
            MixedObjects()
            MixedObjectsPossible()
        End Sub
    End Module
End Namespace