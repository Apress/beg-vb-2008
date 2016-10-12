Imports System.Runtime.CompilerServices

Namespace DelegateImplementation
    Delegate Sub ProcessValue(ByVal value As Integer)

    Module Extensions
        ' Methods
        <Extension()> _
        Public Sub Iterate(ByVal collection As ICollection(Of Integer), ByVal cb As ProcessValue)
            Dim element As Integer
            For Each element In collection
                cb(element)
            Next
        End Sub

    End Module

    Class DelegateImplementations
        ' Methods
        Public Function InstanceInstantiate() As ProcessValue
            Return New ProcessValue(AddressOf InstanceProcess)
        End Function

        Private Sub InstanceProcess(ByVal value As Integer)
        End Sub

        Public Shared Function SharedInstance() As ProcessValue
            Return New ProcessValue(AddressOf SharedProcess)
        End Function

        Private Shared Sub SharedProcess(ByVal value As Integer)
        End Sub

    End Class

    Module Tests
        ' Fields
        Private _maxValue As Integer
        Private _runningTotal As Integer

        Private Sub ProcessMaximumValue(ByVal value As Integer)
            If (value > Tests._maxValue) Then
                _maxValue = value
            End If
        End Sub

        Private Sub ProcessRunningTotal(ByVal value As Integer)
            _runningTotal = (_runningTotal + value)
        End Sub
        Public Sub RunAll()
            Dim lst As New List(Of Integer)
            lst.Add(1)
            lst.Add(2)
            lst.Add(3)
            lst.Add(4)
            _runningTotal = 0
            lst.Iterate(New ProcessValue(AddressOf Tests.ProcessRunningTotal))
            Console.WriteLine(("Running total is (" & Tests._runningTotal & ")"))
            Tests._maxValue = Integer.MinValue
            lst.Iterate(New ProcessValue(AddressOf Tests.ProcessMaximumValue))
            Console.WriteLine(("Maximum value is (" & Tests._maxValue & ")"))
        End Sub
    End Module
End Namespace