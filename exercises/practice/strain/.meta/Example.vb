Imports System
Imports System.Collections.Generic
Imports System.Runtime.CompilerServices

Public Module Strain
    <Extension()>
    Public Function Keep(Of T)(ByVal coll As IEnumerable(Of T), ByVal pred As Func(Of T, Boolean)) As IEnumerable(Of T)
        Return ApplyPredicate(coll, pred)
    End Function

    <Extension()>
    Public Function Discard(Of T)(ByVal coll As IEnumerable(Of T), ByVal pred As Func(Of T, Boolean)) As IEnumerable(Of T)
        Return ApplyPredicate(coll, Function(x) Not pred(x))
    End Function

    Private Function ApplyPredicate(Of T)(ByVal coll As IEnumerable(Of T), ByVal pred As Func(Of T, Boolean)) As IEnumerable(Of T)
        ' could knock this down to a simple LINQ expression but restriction prevents that
        Dim filtered = New List(Of T)()
        For Each item In coll
            If pred(item) Then filtered.Add(item)
        Next
        Return filtered
    End Function
End Module