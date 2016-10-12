Namespace Devspace.Trader.Common.ServerSpreadsheet
    Friend Interface IMyType(Of TypeLevelScopeType)
        ' Methods
        Function GetMyValue(Of MethodLevelScopeType)() As MethodLevelScopeType
        Function GetMyValue() As TypeLevelScopeType
    End Interface
End Namespace

