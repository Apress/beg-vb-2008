Imports LibLightingSystem
Imports System

Friend Class LivingRoom : Implements ISensorRoom, IRemoteControlRoom, IRoom
    ' Methods
    Public Sub DimLight(ByVal level As Double) Implements IRemoteControlRoom.DimLight
        Me._lightLevel = level
    End Sub

    Public Sub LightSwitch(ByVal lightState As Boolean) Implements IRemoteControlRoom.LightSwitch
        If lightState Then
            Me._lightLevel = 1
        Else
            Me._lightLevel = 0
        End If
    End Sub


    ' Properties
    Public ReadOnly Property IsPersonInRoom() As Boolean Implements ISensorRoom.IsPersonInRoom
        Get
            Return False
        End Get
    End Property

    Public ReadOnly Property LightLevel() As Double Implements ISensorRoom.LightLevel
        Get
            Return Me._lightLevel
        End Get
    End Property


    ' Fields
    Private _lightLevel As Double
End Class

