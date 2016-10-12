Imports System
Imports System.Runtime.Serialization

Namespace SerializationTweaks
    <Serializable> _
    Friend Class MyObject
        Implements ISerializable
        Private value As Integer
        Public Sub New()
        End Sub

        Public Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            Me.value = Integer.Parse(CStr(info.GetValue("value", GetType(String))))
        End Sub

        Public Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext) _
        Implements ISerializable.GetObjectData
            info.AddValue("value", Me.value.ToString)
        End Sub
    End Class
End Namespace

