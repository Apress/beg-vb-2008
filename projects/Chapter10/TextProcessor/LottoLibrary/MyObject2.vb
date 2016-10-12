Imports System

Namespace SerializationTweaks
    <Serializable()> _
    Friend Class MyObject2
        ' Fields
        <NonSerialized()> _
        Private _networkIdentifier As Integer
    End Class
End Namespace

