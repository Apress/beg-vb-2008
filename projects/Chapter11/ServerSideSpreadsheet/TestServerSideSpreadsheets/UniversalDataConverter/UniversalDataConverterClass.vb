Imports System

Namespace UniversalDataConverter
    Friend Class UniversalDataConverterClass
        ' Methods
        Public Function [Convert](Of outType, inType)(ByVal input As inType) As outType
            If (TypeOf input Is String AndAlso GetType(String).IsAssignableFrom(GetType(outType))) Then
                Return DirectCast(DirectCast(input, Object), outType)
            End If
            If (TypeOf input Is String AndAlso GetType(Integer).IsAssignableFrom(GetType(outType))) Then
                Return DirectCast(DirectCast(Integer.Parse(CStr(DirectCast(input, Object))), Object), outType)
            End If
            Return CType(Nothing, outType)
        End Function

    End Class
End Namespace

