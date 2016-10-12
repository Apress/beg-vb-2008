Imports LibLightingSystem
Imports System

Friend Class PublicRoom : Implements ISensorRoom
    Public ReadOnly Property IsPersonInRoom() As Boolean _
        Implements ISensorRoom.IsPersonInRoom
        Get
            Return False
        End Get
    End Property

    Private _lightLevel As Double

    Public ReadOnly Property LightLevel() As Double _
        Implements ISensorRoom.LightLevel
        Get
            Return _lightLevel
        End Get
    End Property

    Public Sub LightSwitch(ByVal lightState As Boolean) _
        Implements IRemoteControlRoom.LightSwitch
        If lightState Then
            _lightLevel = 1
        Else
            _lightLevel = 0
        End If
    End Sub

    Public Sub DimLight(ByVal level As Double) _
        Implements IRemoteControlRoom.DimLight
        _lightLevel = level
    End Sub
End Class
