Imports System
Imports System.Collections.Generic
Imports System.Linq

Public Enum SublistTypeType
    Equal
    Unequal
    Superlist
    Sublist
End Enum

Public Module Sublist
    Public Function ClassifyMethod(Of T As IComparable)(ByVal list1 As List(Of T), ByVal list2 As List(Of T)) As SublistType
        If list1.Count = list2.Count Then
            Return If(AreEqual(list1, list2), SublistType.Equal, SublistType.Unequal)
        End If

        If list1.Count < list2.Count Then
            Return If(IsSublist(list1, list2), SublistType.Sublist, SublistType.Unequal)
        End If

        Return If(IsSublist(list2, list1), SublistType.Superlist, SublistType.Unequal)
    End Function

    Private Function AreEqual(Of T As IComparable)(ByVal list1 As List(Of T), ByVal list2 As List(Of T)) As Boolean
        Return Not list1.Where(Function(t, i) t.CompareTo(list2(i)) <> 0).Any()
    End Function

    Private Function IsSublist(Of T As IComparable)(ByVal list1 As List(Of T), ByVal list2 As List(Of T)) As Boolean
        If list1.Count > list2.Count Then
            Return False
        End If

        If list1.Count = 0 Then
            Return True
        End If

        Return Enumerable.Range(0, list2.Count - list1.Count + 1).Any(Function(i) AreEqual(list1, list2.GetRange(i, list1.Count)))
    End Function
End Module
