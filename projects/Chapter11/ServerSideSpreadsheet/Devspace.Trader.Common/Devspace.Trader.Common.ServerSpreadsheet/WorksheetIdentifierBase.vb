Imports System

Namespace ServerSpreadsheet
    Public MustInherit Class WorksheetIdentifierBase(Of DerivedType)
        Implements IWorksheetIdentifier
        ' Methods
        Public Overrides Function Equals(ByVal obj As Object) As Boolean
            Return TypeOf obj Is DerivedType
        End Function

        Public Overrides Function GetHashCode() As Integer
            Return MyBase.GetHashCode
        End Function

        Public Overrides Function ToString() As String
            Return GetType(DerivedType).FullName
        End Function


        ' Properties
        Public ReadOnly Property FullnameIdentifier() As String Implements IWorksheetIdentifier.FullnameIdentifier
            Get
                Return GetType(DerivedType).AssemblyQualifiedName
            End Get
        End Property

        Public Property Identifier() As String Implements IWorksheetIdentifier.Identifier
            Get
                Return Me.ToString
            End Get
            Set(ByVal value As String)
            End Set
        End Property

    End Class
End Namespace

