Imports System
Imports System.Runtime.Serialization

Namespace SerializationTweaks
    <Serializable> _
    Friend Class MyObject
        Implements ISerializable
        ' Methods
        Public Sub New()
        End Sub

        Public Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            Me.value = Integer.Parse(CStr(info.GetValue("value", GetType(String))))
        End Sub

        Public Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            info.AddValue("value", Me.value.ToString)
        End Sub


        ' Fields
        Private value As Integer
    End Class
End Namespace

