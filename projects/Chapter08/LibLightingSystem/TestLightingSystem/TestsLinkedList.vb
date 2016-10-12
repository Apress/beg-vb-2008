Imports System

Namespace TestLightingSystem
    Public Class TestsLinkedList
        ' Methods
        Public Shared Sub RunAll()
            TestsLinkedList.TestInsert
            TestsLinkedList.TestRemove1
            TestsLinkedList.TestRemove2
        End Sub

        Public Shared Sub TestInsert()
            Console.WriteLine("**************")
            Console.WriteLine("TestInsert: Start")
            Dim item1 As New LinkedItem("item1")
            Dim item2 As New LinkedItem("item2")
            Dim item3 As New LinkedItem("item3")
            Console.WriteLine(item1.ToString)
            If ((Not item1.Next Is Nothing) OrElse (Not item1.Prev Is Nothing)) Then
                Throw New Exception("TestInsert: Empty structure is incorrect")
            End If
            item1.Insert(item2)
            Console.WriteLine(item1.ToString)
            If ((Not item1.Next Is item2) OrElse (Not item1.Prev Is Nothing)) Then
                Throw New Exception("TestInsert: Item 1->Item2 structure is incorrect")
            End If
            Console.WriteLine(item2.ToString)
            If ((Not item2.Next Is Nothing) OrElse (Not item2.Prev Is item1)) Then
                Throw New Exception("TestInsert: Item 2->Item1 structure is incorrect")
            End If
            item2.Insert(item3)
            Console.WriteLine(item2.ToString)
            If ((Not item2.Prev Is item1) OrElse (Not item2.Next Is item3)) Then
                Throw New Exception("TestInsert: Item2->Item1, Item3 structure is incorrect")
            End If
            Console.WriteLine(item3.ToString)
            If ((Not item3.Prev Is item2) OrElse (Not item3.Next Is Nothing)) Then
                Throw New Exception("TestInsert: Item3->Item2, structure is incorrect")
            End If
            Console.WriteLine(item1.ToString)
            Console.WriteLine(item2.ToString)
            Console.WriteLine(item3.ToString)
            Console.WriteLine("TestInsert: End")
        End Sub

        Public Shared Sub TestRemove1()
            Console.WriteLine("**************")
            Console.WriteLine("TestRemove1: Start")
            Dim item1 As New LinkedItem("item1")
            Dim item2 As New LinkedItem("item2")
            Dim item3 As New LinkedItem("item3")
            item1.Insert(item2)
            item2.Insert(item3)
            item2.Remove
            Console.WriteLine(item1.ToString)
            Console.WriteLine(item2.ToString)
            Console.WriteLine(item3.ToString)
            If ((Not item1.Next Is item3) OrElse (Not item1.Prev Is Nothing)) Then
                Throw New Exception("TestRemove1: Item1 structure incorrect")
            End If
            If ((Not item2.Next Is Nothing) OrElse (Not item2.Prev Is Nothing)) Then
                Throw New Exception("TestRemove1: Item2 structure incorrect")
            End If
            If ((Not item3.Next Is Nothing) OrElse (Not item3.Prev Is item1)) Then
                Throw New Exception("TestRemove1: Item3 structure incorrect")
            End If
            Console.WriteLine("TestRemove1: End")
        End Sub

        Public Shared Sub TestRemove2()
            Console.WriteLine("**************")
            Console.WriteLine("TestRemove2: Start")
            Dim item1 As New LinkedItem("item1")
            Dim item2 As New LinkedItem("item2")
            Dim item3 As New LinkedItem("item3")
            item1.Insert(item2)
            item2.Insert(item3)
            item1.Remove
            Console.WriteLine(item1.ToString)
            Console.WriteLine(item2.ToString)
            Console.WriteLine(item3.ToString)
            If ((Not item1.Next Is Nothing) OrElse (Not item1.Prev Is Nothing)) Then
                Throw New Exception("TestRemove2: Item1 structure incorrect")
            End If
            If ((Not item2.Next Is item3) OrElse (Not item2.Prev Is Nothing)) Then
                Throw New Exception("TestRemove2: Item2 structure incorrect")
            End If
            If ((Not item3.Next Is Nothing) OrElse (Not item3.Prev Is item2)) Then
                Throw New Exception("TestRemove2: Item3 structure incorrect")
            End If
            Console.WriteLine("TestRemove2: End")
        End Sub

    End Class
End Namespace

