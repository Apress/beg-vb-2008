Friend Class MyType
    ' Fields
    Public DataMember As Integer
End Class

Namespace ExceptionsThatCorruptState
    Friend Class Tests
        ' Methods
        Public Sub GeneratesException()
            Me.LocalDataMember = 10
            Dim cls As MyType = Nothing
            cls.DataMember = 10
        End Sub

        Public Sub RunAll()
            Console.WriteLine(("LocalDataMember=" & Me.LocalDataMember))
            Try
                Me.GeneratesException()
            Catch exception1 As Exception
            End Try
            Console.WriteLine(("LocalDataMember=" & Me.LocalDataMember))
        End Sub


        ' Fields
        Public LocalDataMember As Integer
    End Class
End Namespace

