Namespace Automators
    Public Interface IFactory(Of IdentifierType)
        Function Instantiate(Of Type As Class)(ByVal identifier As IdentifierType) As Type
    End Interface
End Namespace

