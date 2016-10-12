Imports Devspace.Trader.Common
Imports Devspace.Trader.Common.Tracer
Imports Devspace.Trader.Common.Automators
Imports System
Imports System.Collections.Generic

Namespace Loader
    Public Class MultipleLoaderHandler
        Implements IDebug
        ' Methods
        Public Sub AddFactory(ByVal factory As IFactory(Of String))
            Me._factoryList.Add(factory)
        End Sub

        Public Sub AddToCache(ByVal identifier As String, ByVal obj As Object)
            If Not Me._cachedObjects.ContainsKey(identifier) Then
                If Me.Debug Then
                    GenerateOutput.Write("MultipleLoaderHandler.AddToCache", ("Added (" & identifier & ") to cache"))
                End If
                Me._cachedObjects.Add(identifier, obj)
            End If
        End Sub

        Public Function InstantiateType(Of Type As Class)(ByVal identifier As String, ByVal useCache As Boolean) As Type
            If Me.Debug Then
                GenerateOutput.Write("MultipleLoaderHandler.InstantiateType", ("identifier (" & identifier & ")"))
            End If
            If Me._cachedObjects.ContainsKey(identifier) Then
                If Me.Debug Then
                    GenerateOutput.Write("MultipleLoaderHandler.InstantiateType", "Is in cache")
                End If
                Return TryCast(Me._cachedObjects.Item(identifier), Type)
            End If
            Dim factory As IFactory(Of String)
            For Each factory In Me._factoryList
                Dim obj As Type = factory.Instantiate(Of Type)(identifier)
                If (Not obj Is Nothing) Then
                    If useCache Then
                        If Me.Debug Then
                            GenerateOutput.Write("MultipleLoaderHandler.InstantiateType", "Instantiated and added to cache")
                        End If
                        Me._cachedObjects.Add(identifier, obj)
                        Return obj
                    End If
                    If Me.Debug Then
                        GenerateOutput.Write("MultipleLoaderHandler.InstantiateType", "Instantiated not added to cache")
                    End If
                    Return obj
                End If
            Next
            Throw New NotSupportedException(("Identifier (" & identifier & ") could not be instantiated in the loaded assemblies"))
        End Function


        ' Properties
        Public Property Debug() As Boolean Implements IDebug.Debug
            Get
                Return Me._debug
            End Get
            Set(ByVal value As Boolean)
                Me._debug = value
            End Set
        End Property


        ' Fields
        Private _cachedObjects As IDictionary(Of String, Object) = New SortedDictionary(Of String, Object)
        Private _debug As Boolean
        Private _factoryList As List(Of IFactory(Of String)) = New List(Of IFactory(Of String))
    End Class
End Namespace

