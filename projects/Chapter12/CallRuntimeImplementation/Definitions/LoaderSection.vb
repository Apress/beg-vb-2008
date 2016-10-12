Imports System
Imports System.Configuration

Public Class LoaderSection
    Inherits ConfigurationSection

    Private Shared _propAssemblyName As ConfigurationProperty = New ConfigurationProperty("assemblyname", GetType(String), Nothing, ConfigurationPropertyOptions.IsRequired)
    Private Shared _propEasyName As ConfigurationProperty = New ConfigurationProperty("easyname", GetType(String), Nothing, ConfigurationPropertyOptions.IsRequired)
    Private Shared _properties As ConfigurationPropertyCollection = New ConfigurationPropertyCollection
    Private Shared _propTypeName As ConfigurationProperty = New ConfigurationProperty("typename", GetType(String), Nothing, ConfigurationPropertyOptions.IsRequired)

    Shared Sub New()
        LoaderSection._properties.Add(LoaderSection._propEasyName)
        LoaderSection._properties.Add(LoaderSection._propTypeName)
        LoaderSection._properties.Add(LoaderSection._propAssemblyName)
    End Sub


    <ConfigurationProperty("assemblyname", IsRequired:=True)> _
    Public ReadOnly Property AssemblyName() As String
        Get
            Return CStr(MyBase.Item(LoaderSection._propAssemblyName))
        End Get
    End Property

    <ConfigurationProperty("easyname", IsRequired:=True)> _
    Public ReadOnly Property EasyName() As String
        Get
            Return CStr(MyBase.Item(LoaderSection._propEasyName))
        End Get
    End Property

    <ConfigurationProperty("typename", IsRequired:=True)> _
    Public ReadOnly Property TypeName() As String
        Get
            Return CStr(MyBase.Item(LoaderSection._propTypeName))
        End Get
    End Property
End Class

