Public Interface IFactory(Of IdentifierType)
    ' Methods
    Function Instantiate(Of Type As Class)(ByVal identifier As IdentifierType) As Type
End Interface

