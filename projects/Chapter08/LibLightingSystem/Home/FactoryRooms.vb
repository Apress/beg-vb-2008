Imports LibLightingSystem
Imports System

Public Class FactoryRooms
    ' Methods
    Public Shared Function CreateBedroom() As IRoom
        Return New Bedroom
    End Function

    Public Shared Function CreateBuilding() As LightingController
        Dim controller As New LightingController
        Dim home As Object = controller.AddRoomGrouping("home")
        controller.AddRoomToGrouping(home, New Bedroom)
        controller.AddRoomToGrouping(home, New Bedroom)
        controller.AddRoomToGrouping(home, New LivingRoom)
        controller.AddRoomToGrouping(home, New Garage)
        Return controller
    End Function

    Public Shared Function CreateGarage() As IRoom
        Return New Garage
    End Function

    Public Shared Function CreateLivingRoom() As IRoom
        Return New LivingRoom
    End Function

End Class

