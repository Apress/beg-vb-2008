Imports LibLightingSystem
Imports System

Public Module FactoryRooms
    ' Methods
    Public Function CreateBuilding() As LightingController
        Dim controller As New LightingController
        Dim publicAreas As Object = controller.AddRoomGrouping("public viewing areas")
        Dim privateAreas As Object = controller.AddRoomGrouping("private viewing areas")
        controller.AddRoomToGrouping(publicAreas, New PublicRoom)
        controller.AddRoomToGrouping(privateAreas, New PrivateRoom)
        Return controller
    End Function

    Public Function CreatePrivateRoom() As IRoom
        Return New PrivateRoom
    End Function

    Public Function CreatePublicRoom() As IRoom
        Return New PublicRoom
    End Function

End Module

