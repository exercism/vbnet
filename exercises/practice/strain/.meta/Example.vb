Imports System.Runtime.CompilerServices

Public Module Strain
    <Extension()>
    Public Function Keep(Of T)(
        ByVal collection As IEnumerable(Of T),
        ByVal predicate As Func(Of T, Boolean)) As IEnumerable(Of T)

        Return Filtered(collection, predicate)
    End Function

    <Extension()>
    Public Function Discard(Of T)(
        ByVal collection As IEnumerable(Of T),
        ByVal predicate As Func(Of T, Boolean)) As IEnumerable(Of T)

        Return Filtered(collection, Function(item) Not predicate(item))
    End Function

    Private Function Filtered(Of T)(
        ByVal collection As IEnumerable(Of T),
        ByVal predicate As Func(Of T, Boolean)) As IEnumerable(Of T)

        Dim matches As New List(Of T)

        For Each item In collection
            If predicate(item) Then
                matches.Add(item)
            End If
        Next

        Return matches
    End Function
End Module
