Imports System

Public Interface ISensorRoom
    Inherits IRemoteControlRoom, IRoom
    ' Properties
    ReadOnly Property IsPersonInRoom() As Boolean
End Interface

