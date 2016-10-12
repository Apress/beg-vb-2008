Imports System

Public Interface IRemoteControlRoom
    Inherits IRoom
    ' Methods
    Sub DimLight(ByVal level As Double)
    Sub LightSwitch(ByVal lightState As Boolean)

    ' Properties
    ReadOnly Property LightLevel() As Double
End Interface

