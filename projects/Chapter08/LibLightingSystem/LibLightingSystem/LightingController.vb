Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Threading

Public Class LightingController
    Private _roomGroupings As BaseLinkedList = New RoomGrouping()

    Public Function AddRoomGrouping(ByVal description As String) As Object
        Dim grouping As RoomGrouping = New RoomGrouping() _
        With { _
              .Description = description, _
              .Rooms = Nothing}
        _roomGroupings.Insert(grouping)
        Return grouping
    End Function
    Public Function FindRoomGrouping(ByVal description As String) As Object
        Dim curr As RoomGrouping = _roomGroupings.Next
        Do While Not curr Is Nothing
            If curr.Description.CompareTo(description) = 0 Then
                Return curr
            End If
            curr = TryCast(curr.Next, RoomGrouping)
        Loop
        Return Nothing
    End Function
    Public ReadOnly Property Item(ByVal description As String) As Object
        Get
            Return FindRoomGrouping(description)
        End Get
    End Property

    Public Function RoomGroupingIterator() As IEnumerable
        Return New LinkedListEnumerable(_roomGroupings.Next)
    End Function

    Public Sub AddRoomToGrouping(ByVal grouping As Object, ByVal room As IRoom)
        Dim roomGrouping As RoomGrouping = TryCast(grouping, RoomGrouping)
        If roomGrouping Is Nothing Then
            Throw New Exception( _
              "Handle grouping is not a valid room grouping instance")
        End If
        Dim oldRooms As Room = TryCast(roomGrouping.Rooms, Room)
        If oldRooms Is Nothing Then
            roomGrouping.Rooms = New Room() With {.ObjRoom = room}
        Else
            roomGrouping.Rooms.Insert(New Room() With {.ObjRoom = room})
        End If
    End Sub

    Public Sub TurnOffLights(ByVal grouping As Object)
        For Each room As IRoom In New LinkedListEnumerable(TryCast(grouping, BaseLinkedList))
            Dim remote As IRemoteControlRoom = TryCast(room, IRemoteControlRoom)
            Dim sensorRoom As ISensorRoom = TryCast(room, ISensorRoom)
            If Not sensorRoom Is Nothing Then
                If Not sensorRoom.IsPersonInRoom Then
                    Continue For
                End If
            ElseIf Not remote Is Nothing Then
                remote.LightSwitch(False)
            End If
        Next
    End Sub

    'public void RemoveRoomFromgrouping(object grouping, IRoom room) {
    '    RoomGrouping roomGrouping = grouping as RoomGrouping;
    '    if (roomGrouping == null) {
    '        throw new Exception("Handle grouping is not a valid room grouping instance");
    '    }
    '    Room curr = roomGrouping.Rooms as Room;
    '    while (curr != null) {
    '        if (curr.ObjRoom == room) {
    '            curr.Remove();
    '        }
    '        curr = curr.Next as Room;
    '    }
    '}
    '#endregion

    'public IEnumerable RoomIterator(string description) {
    '    RoomGrouping grouping = this[description] as RoomGrouping;
    '    if (grouping.Description.CompareTo(description) == 0) {
    '        Room curr = grouping.Rooms as Room;
    '        while (curr != null) {
    '            yield return curr.ObjRoom;
    '            curr = curr.Next as Room;
    '        }
    '    }
    '}
    'public IEnumerable RoomIterator(object handle) {
    '    RoomGrouping grouping = handle as RoomGrouping;
    '    Room curr = grouping.Rooms as Room;
    '    while (curr != null) {
    '        yield return curr.ObjRoom;
    '        curr = curr.Next as Room;
    '    }
    '}
    'public void DimLights(object grouping, double level) {
    '    foreach (IRoom room in RoomIterator(grouping)) {
    '        IRemoteControlRoom remote = room as IRemoteControlRoom;
    '        ISensorRoom sensorRoom = room as ISensorRoom;
    '        if (sensorRoom != null) {
    '            if (!sensorRoom.IsPersonInRoom) {
    '                sensorRoom.DimLight(level);
    '            }
    '        }
    '        else if (remote != null) {
    '            remote.DimLight(level);
    '        }
    '    }
    '}
    'public void TurnOffLights(object grouping) {
    '    foreach (IRoom room in RoomIterator(grouping)) {
    '        IRemoteControlRoom remote = room as IRemoteControlRoom;
    '        ISensorRoom sensorRoom = room as ISensorRoom;
    '        if (sensorRoom != null) {
    '            if (!sensorRoom.IsPersonInRoom) {
    '                continue;
    '            }
    '        }
    '        else if (remote != null) {
    '            remote.LightSwitch(false);
    '        }
    '    }
    '}
    'public void TurnOnLights(object grouping) {
    '    foreach (IRoom room in RoomIterator(grouping)) {
    '        IRemoteControlRoom remote = room as IRemoteControlRoom;
    '        if (remote != null) {
    '            remote.LightSwitch(true);
    '        }
    '    }
    '}

End Class
' Methods
'Public Function AddRoomGrouping(ByVal description As String) As Object
'            Dim <>g__initLocal0 As New RoomGrouping
'            <>g__initLocal0.Description = description
'            <>g__initLocal0.Rooms = Nothing
'            Dim grouping As RoomGrouping = <>g__initLocal0
'            Me._roomGroupings.Insert(grouping)
'            Return grouping
'        End Function

'        Public Sub AddRoomToGrouping(ByVal grouping As Object, ByVal room As IRoom)
'            Dim roomGrouping As RoomGrouping = TryCast(grouping,RoomGrouping)
'            If (roomGrouping Is Nothing) Then
'                Throw New Exception("Handle grouping is not a valid room grouping instance")
'            End If
'            If (roomGrouping.Rooms Is Nothing) Then
'                Dim <>g__initLocal5 As New Room
'                <>g__initLocal5.ObjRoom = room
'                roomGrouping.Rooms = <>g__initLocal5
'            Else
'                Dim <>g__initLocal6 As New Room
'                <>g__initLocal6.ObjRoom = room
'                roomGrouping.Rooms.Insert(<>g__initLocal6)
'            End If
'        End Sub

'        Public Sub DimLights(ByVal grouping As Object, ByVal level As Double)
'            Dim room As IRoom
'            For Each room In Me.RoomIterator(grouping)
'                Dim remote As IRemoteControlRoom = TryCast(room,IRemoteControlRoom)
'                Dim sensorRoom As ISensorRoom = TryCast(room,ISensorRoom)
'                If (Not sensorRoom Is Nothing) Then
'                    If Not sensorRoom.IsPersonInRoom Then
'                        sensorRoom.DimLight(level)
'                    End If
'                ElseIf (Not remote Is Nothing) Then
'                    remote.DimLight(level)
'                End If
'            Next
'        End Sub

'        Public Function FindRoomGrouping(ByVal description As String) As Object
'            Dim curr As RoomGrouping = TryCast(Me._roomGroupings.Next,RoomGrouping)
'            Do While (Not curr Is Nothing)
'                If (curr.Description.CompareTo(description) = 0) Then
'                    Return curr
'                End If
'                curr = TryCast(curr.Next,RoomGrouping)
'            Loop
'            Return Nothing
'        End Function

'        Public Sub RemoveRoomFromgrouping(ByVal grouping As Object, ByVal room As IRoom)
'            Dim roomGrouping As RoomGrouping = TryCast(grouping,RoomGrouping)
'            If (roomGrouping Is Nothing) Then
'                Throw New Exception("Handle grouping is not a valid room grouping instance")
'            End If
'            Dim curr As Room = roomGrouping.Rooms
'            Do While (Not curr Is Nothing)
'                If (curr.ObjRoom Is room) Then
'                    curr.Remove
'                End If
'                curr = TryCast(curr.Next,Room)
'            Loop
'        End Sub

'        Public Function RoomGroupingIterator() As IEnumerable
'            Dim d__ As New <RoomGroupingIterator>d__1(-2)
'            d__.<>4__this = Me
'            Return d__
'        End Function

'        Public Function RoomIterator(ByVal handle As Object) As IEnumerable
'            Dim _c As New <RoomIterator>d__c(-2)
'            _c.<>4__this = Me
'            _c.<>3__handle = handle
'            Return _c
'        End Function

'        Public Function RoomIterator(ByVal description As String) As IEnumerable
'            Dim d__ As New <RoomIterator>d__7(-2)
'            d__.<>4__this = Me
'            d__.<>3__description = description
'            Return d__
'        End Function

'        Public Sub TurnOffLights(ByVal grouping As Object)
'            Dim room As IRoom
'            For Each room In Me.RoomIterator(grouping)
'                Dim remote As IRemoteControlRoom = TryCast(room,IRemoteControlRoom)
'                Dim sensorRoom As ISensorRoom = TryCast(room,ISensorRoom)
'                If (Not sensorRoom Is Nothing) Then
'                    If Not sensorRoom.IsPersonInRoom Then
'                        Continue For
'                    End If
'                ElseIf (Not remote Is Nothing) Then
'                    remote.LightSwitch(False)
'                End If
'            Next
'        End Sub

'        Public Sub TurnOnLights(ByVal grouping As Object)
'            Dim room As IRoom
'            For Each room In Me.RoomIterator(grouping)
'                Dim remote As IRemoteControlRoom = TryCast(room,IRemoteControlRoom)
'                If (Not remote Is Nothing) Then
'                    remote.LightSwitch(True)
'                End If
'            Next
'        End Sub


'        ' Properties
'        Public ReadOnly Default Property Item(ByVal description As String) As Object
'            Get
'                Return Me.FindRoomGrouping(description)
'            End Get
'        End Property


'        ' Fields
'        Private _roomGroupings As BaseLinkedList = New RoomGrouping

'        ' Nested Types
'        <CompilerGenerated> _
'        Private NotInheritable Class <RoomGroupingIterator>d__1
'            Implements IEnumerable(Of Object), IEnumerable, IEnumerator(Of Object), IEnumerator, IDisposable
'            ' Methods
'            <DebuggerHidden> _
'            Public Sub New(ByVal <>1__state As Integer)
'                Me.<>1__state = <>1__state
'                Me.<>l__initialThreadId = Thread.CurrentThread.ManagedThreadId
'            End Sub

'            Private Function MoveNext() As Boolean Implements IEnumerator.MoveNext
'                Select Case Me.<>1__state
'                    Case 0
'                        Me.<>1__state = -1
'                        Me.<curr>5__2 = TryCast(Me.<>4__this._roomGroupings.Next,RoomGrouping)
'                        Do While (Not Me.<curr>5__2 Is Nothing)
'                            Me.<>2__current = Me.<curr>5__2.Description
'                            Me.<>1__state = 1
'                            Return True
'                        Label_005F:
'                            Me.<>1__state = -1
'                            Me.<curr>5__2 = TryCast(Me.<curr>5__2.Next,RoomGrouping)
'                        Loop
'                        Exit Select
'                    Case 1
'                        goto Label_005F
'                End Select
'                Return False
'            End Function

'            <DebuggerHidden> _
'            Private Function System.Collections.Generic.IEnumerable<System.Object>.GetEnumerator() As IEnumerator(Of Object) Implements IEnumerable(Of Object).GetEnumerator
'                If ((Thread.CurrentThread.ManagedThreadId = Me.<>l__initialThreadId) AndAlso (Me.<>1__state = -2)) Then
'                    Me.<>1__state = 0
'                    Return Me
'                End If
'                Dim d__ As New <RoomGroupingIterator>d__1(0)
'                d__.<>4__this = Me.<>4__this
'                Return d__
'            End Function

'            <DebuggerHidden> _
'            Private Function System.Collections.IEnumerable.GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
'                Return Me.System.Collections.Generic.IEnumerable<System.Object>.GetEnumerator
'            End Function

'            <DebuggerHidden> _
'            Private Sub System.Collections.IEnumerator.Reset() Implements IEnumerator.Reset
'                Throw New NotSupportedException
'            End Sub

'            Private Sub System.IDisposable.Dispose() Implements IDisposable.Dispose
'            End Sub


'            ' Properties
'            Private ReadOnly Property System.Collections.Generic.IEnumerator<System.Object>.Current As Object
'                Get
'                    Return Me.<>2__current
'                End Get
'            End Property

'            Private ReadOnly Property System.Collections.IEnumerator.Current As Object
'                Get
'                    Return Me.<>2__current
'                End Get
'            End Property


'            ' Fields
'            Private <>1__state As Integer
'            Private <>2__current As Object
'            Public <>4__this As LightingController
'            Private <>l__initialThreadId As Integer
'            Public <curr>5__2 As RoomGrouping
'        End Class

'        <CompilerGenerated> _
'        Private NotInheritable Class <RoomIterator>d__7
'            Implements IEnumerable(Of Object), IEnumerable, IEnumerator(Of Object), IEnumerator, IDisposable
'            ' Methods
'            <DebuggerHidden> _
'            Public Sub New(ByVal <>1__state As Integer)
'                Me.<>1__state = <>1__state
'                Me.<>l__initialThreadId = Thread.CurrentThread.ManagedThreadId
'            End Sub

'            Private Function MoveNext() As Boolean Implements IEnumerator.MoveNext
'                Select Case Me.<>1__state
'                    Case 0
'                        Me.<>1__state = -1
'                        Me.<grouping>5__8 = TryCast(Me.<>4__this.Item(Me.description),RoomGrouping)
'                        If (Me.<grouping>5__8.Description.CompareTo(Me.description) = 0) Then
'                            Me.<curr>5__9 = Me.<grouping>5__8.Rooms
'                            Do While (Not Me.<curr>5__9 Is Nothing)
'                                Me.<>2__current = Me.<curr>5__9.ObjRoom
'                                Me.<>1__state = 1
'                                Return True
'                            Label_0095:
'                                Me.<>1__state = -1
'                                Me.<curr>5__9 = TryCast(Me.<curr>5__9.Next,Room)
'                            Loop
'                        End If
'                        Exit Select
'                    Case 1
'                        goto Label_0095
'                End Select
'                Return False
'            End Function

'            <DebuggerHidden> _
'            Private Function System.Collections.Generic.IEnumerable<System.Object>.GetEnumerator() As IEnumerator(Of Object) Implements IEnumerable(Of Object).GetEnumerator
'                Dim d__ As <RoomIterator>d__7
'                If ((Thread.CurrentThread.ManagedThreadId = Me.<>l__initialThreadId) AndAlso (Me.<>1__state = -2)) Then
'                    Me.<>1__state = 0
'                    d__ = Me
'                Else
'                    d__ = New <RoomIterator>d__7(0)
'                    d__.<>4__this = Me.<>4__this
'                End If
'                d__.description = Me.<>3__description
'                Return d__
'            End Function

'            <DebuggerHidden> _
'            Private Function System.Collections.IEnumerable.GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
'                Return Me.System.Collections.Generic.IEnumerable<System.Object>.GetEnumerator
'            End Function

'            <DebuggerHidden> _
'            Private Sub System.Collections.IEnumerator.Reset() Implements IEnumerator.Reset
'                Throw New NotSupportedException
'            End Sub

'            Private Sub System.IDisposable.Dispose() Implements IDisposable.Dispose
'            End Sub


'            ' Properties
'            Private ReadOnly Property System.Collections.Generic.IEnumerator<System.Object>.Current As Object
'                Get
'                    Return Me.<>2__current
'                End Get
'            End Property

'            Private ReadOnly Property System.Collections.IEnumerator.Current As Object
'                Get
'                    Return Me.<>2__current
'                End Get
'            End Property


'            ' Fields
'            Private <>1__state As Integer
'            Private <>2__current As Object
'            Public <>3__description As String
'            Public <>4__this As LightingController
'            Private <>l__initialThreadId As Integer
'            Public <curr>5__9 As Room
'            Public <grouping>5__8 As RoomGrouping
'            Public description As String
'        End Class

'        <CompilerGenerated> _
'        Private NotInheritable Class <RoomIterator>d__c
'            Implements IEnumerable(Of Object), IEnumerable, IEnumerator(Of Object), IEnumerator, IDisposable
'            ' Methods
'            <DebuggerHidden> _
'            Public Sub New(ByVal <>1__state As Integer)
'                Me.<>1__state = <>1__state
'                Me.<>l__initialThreadId = Thread.CurrentThread.ManagedThreadId
'            End Sub

'            Private Function MoveNext() As Boolean Implements IEnumerator.MoveNext
'                Select Case Me.<>1__state
'                    Case 0
'                        Me.<>1__state = -1
'                        Me.<grouping>5__d = TryCast(Me.handle,RoomGrouping)
'                        Me.<curr>5__e = Me.<grouping>5__d.Rooms
'                        Do While (Not Me.<curr>5__e Is Nothing)
'                            Me.<>2__current = Me.<curr>5__e.ObjRoom
'                            Me.<>1__state = 1
'                            Return True
'                        Label_0066:
'                            Me.<>1__state = -1
'                            Me.<curr>5__e = TryCast(Me.<curr>5__e.Next,Room)
'                        Loop
'                        Exit Select
'                    Case 1
'                        goto Label_0066
'                End Select
'                Return False
'            End Function

'            <DebuggerHidden> _
'            Private Function System.Collections.Generic.IEnumerable<System.Object>.GetEnumerator() As IEnumerator(Of Object) Implements IEnumerable(Of Object).GetEnumerator
'                Dim _c As <RoomIterator>d__c
'                If ((Thread.CurrentThread.ManagedThreadId = Me.<>l__initialThreadId) AndAlso (Me.<>1__state = -2)) Then
'                    Me.<>1__state = 0
'                    _c = Me
'                Else
'                    _c = New <RoomIterator>d__c(0)
'                    _c.<>4__this = Me.<>4__this
'                End If
'                _c.handle = Me.<>3__handle
'                Return _c
'            End Function

'            <DebuggerHidden> _
'            Private Function System.Collections.IEnumerable.GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
'                Return Me.System.Collections.Generic.IEnumerable<System.Object>.GetEnumerator
'            End Function

'            <DebuggerHidden> _
'            Private Sub System.Collections.IEnumerator.Reset() Implements IEnumerator.Reset
'                Throw New NotSupportedException
'            End Sub

'            Private Sub System.IDisposable.Dispose() Implements IDisposable.Dispose
'            End Sub


'            ' Properties
'            Private ReadOnly Property System.Collections.Generic.IEnumerator<System.Object>.Current As Object
'                Get
'                    Return Me.<>2__current
'                End Get
'            End Property

'            Private ReadOnly Property System.Collections.IEnumerator.Current As Object
'                Get
'                    Return Me.<>2__current
'                End Get
'            End Property


'            ' Fields
'            Private <>1__state As Integer
'            Private <>2__current As Object
'            Public <>3__handle As Object
'            Public <>4__this As LightingController
'            Private <>l__initialThreadId As Integer
'            Public <curr>5__e As Room
'            Public <grouping>5__d As RoomGrouping
'            Public handle As Object
'        End Class
'    End Class
'End Namespace

