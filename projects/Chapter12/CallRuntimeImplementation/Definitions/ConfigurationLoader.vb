Imports System
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Reflection

Public Class ConfigurationLoader
    Private Sub New()
    End Sub
    Public Shared ReadOnly Property Instance() As ConfigurationLoader
        Get
            Return ConfigurationLoader._instance
        End Get
    End Property

    Private Shared _instance As ConfigurationLoader = New ConfigurationLoader

    Public Function Instantiate(Of RequestedType)(ByVal identifier As String) As RequestedType
        If Not _availableTypes.ContainsKey(identifier) Then
            Throw New ArgumentException(("identifier (" & identifier & ") is not a listed type"))
        End If
        Dim info As ConfigurationInfo = _availableTypes.Item(identifier)
        Dim assemblyName As AssemblyName = assemblyName.GetAssemblyName(info.AssemblyName)
        Console.WriteLine(("assemblyname(" & assemblyName.ToString() & ")"))
        Return DirectCast(Assembly.Load(assemblyName).CreateInstance(info.TypeName), RequestedType)
    End Function

    Public Function InstantiateStrongType(Of RequestedType)(ByVal identifier As String) As RequestedType
        If Not _availableTypes.ContainsKey(identifier) Then
            Throw New ArgumentException(("identifier (" & identifier & ") is not a listed type"))
        End If
        Dim info As ConfigurationInfo = _availableTypes.Item(identifier)
        Dim value As String = ConfigurationManager.AppSettings.Item(identifier)
        Dim assemblyName As New AssemblyName(value)
        Console.WriteLine(("assemblyname(" & assemblyName.ToString() & ")"))
        Return DirectCast(Assembly.Load(assemblyName).CreateInstance(info.TypeName), RequestedType)
    End Function

    Public Sub Load()
        Dim values() As String = ConfigurationManager.AppSettings.Item("assemblies").Split(New Char() {","c})
        Dim c1 As Integer = 0
        Do While (c1 < values.Length)
            Dim configInfo As New ConfigurationInfo
            configInfo.EasyName = values(c1)
            configInfo.TypeName = values((c1 + 1))
            configInfo.AssemblyName = values((c1 + 2))
            _availableTypes.Add(values(c1), configInfo)
            c1 = (c1 + 3)
        Loop
    End Sub

    Public Sub LoadCustomSection()
        Dim loader As LoaderSection = TryCast(ConfigurationManager.GetSection("loader"), LoaderSection)
        If (Not loader Is Nothing) Then
            Dim configInfo As New ConfigurationInfo
            configInfo.EasyName = loader.EasyName
            configInfo.TypeName = loader.TypeName
            configInfo.AssemblyName = loader.AssemblyName
            _availableTypes.Add(loader.EasyName, configInfo)
        End If
    End Sub

    Public Overrides Function ToString() As String
        Dim retval As String = ""
        Dim identifier As String
        For Each identifier In _availableTypes.Keys
            Dim info As ConfigurationInfo = _availableTypes.Item(identifier)
            retval += info.EasyName & "," & info.TypeName & "," & info.AssemblyName
        Next
        Return retval
    End Function


    ' Properties

    Private _availableTypes As Dictionary(Of String, ConfigurationInfo) = New Dictionary(Of String, ConfigurationInfo)

    Private Class ConfigurationInfo
        Public AssemblyName As String
        Public EasyName As String
        Public TypeName As String
    End Class
End Class

