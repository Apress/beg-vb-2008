Namespace BeforeVisualBasic8
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
            Dim objects As IList = New ArrayList()

            objects.Add(New Example With {.Value = 10})
            objects.Add(New Example With {.Value = 20})
            For Each obj As Example In objects
                Console.WriteLine("Object value (" & obj.Value & ")")
            Next

        End Sub
        Private Sub MixedObjects()
            Dim objects As IList = New ArrayList()

            objects.Add(New Example With {.Value = 10})
            objects.Add(New Example With {.Value = 20})
            objects.Add(New Another())
            For Each obj As Example In objects
                Console.WriteLine("Object value (" & obj.Value & ")")
            Next
        End Sub
        Private Sub MixedObjectsPossible()
            Dim objects As IList = New ArrayList()

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
        Public Sub RunAll()
            'PlainVanillaObjects()
            'MixedObjects()
            MixedObjectsPossible()
        End Sub
    End Module
    ' Methods
    '    Private Shared Sub MixedObjects()
    '        Try
    '            Dim objects As IList = New ArrayList
    '            Dim <>g__initLocal2 As New Example
    '            <>g__initLocal2.Value = 10
    '            objects.Add(<>g__initLocal2)
    '            Dim <>g__initLocal3 As New Example
    '            <>g__initLocal3.Value = 20
    '            objects.Add(<>g__initLocal3)
    '            objects.Add(New Another)
    '            Dim obj As Example
    '            For Each obj In objects
    '                Console.WriteLine(("Object value (" & obj.Value & ")"))
    '            Next
    '        Catch ex As InvalidCastException
    '            Console.WriteLine("Expected exception")
    '        End Try
    '    End Sub

    '    Private Shared Sub PlainVanillaObjects()
    '        Dim objects As IList = New ArrayList
    '        Dim <>g__initLocal0 As New Example
    '        <>g__initLocal0.Value = 10
    '        objects.Add(<>g__initLocal0)
    '        Dim <>g__initLocal1 As New Example
    '        <>g__initLocal1.Value = 20
    '        objects.Add(<>g__initLocal1)
    '        Dim obj As Example
    '        For Each obj In objects
    '            Console.WriteLine(("Object value (" & obj.Value & ")"))
    '        Next
    '    End Sub

    '    Public Shared Sub RunAll()
    '        Tests.PlainVanillaObjects
    '        Tests.MixedObjects
    '        Tests.ValueTypeObjects
    '    End Sub

    '    Private Shared Sub ValueTypeObjects()
    '        Dim objects As IList = New ArrayList
    '        objects.Add(1)
    '        objects.Add(2)
    '        Dim val As Integer
    '        For Each val In objects
    '            Console.WriteLine(("Value (" & val & ")"))
    '        Next
    '    End Sub

    'End Class
End Namespace
