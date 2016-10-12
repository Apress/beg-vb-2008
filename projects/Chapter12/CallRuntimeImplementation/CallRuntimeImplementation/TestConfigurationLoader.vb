Imports Definitions
Imports System

Friend Module TestConfigurationLoader
    Public Sub TestCrossReference()
        ConfigurationLoader.Instance.Load()
        Console.WriteLine(ConfigurationLoader.Instance.ToString)
        Console.WriteLine(ConfigurationLoader.Instance.Instantiate(Of IDefinition)("Impl1").TranslateWord("hello"))
        Console.WriteLine(ConfigurationLoader.Instance.InstantiateStrongType(Of IDefinition)("Impl2").TranslateWord("hello"))
    End Sub

    Public Sub TestCustomLoader()
        ConfigurationLoader.Instance.LoadCustomSection()
        Console.WriteLine(ConfigurationLoader.Instance.ToString)
        Console.WriteLine(ConfigurationLoader.Instance.Instantiate(Of IDefinition)("Impl1").TranslateWord("hello"))
    End Sub

    Public Sub RunAll()
        'TestConfigurationLoader.TestCustomLoader()
        TestCrossReference()
    End Sub

End Module

