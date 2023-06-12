Imports System
Imports System.Collections.Generic
Imports System.Linq

Public Class TreeBuildingRecord
    Public Property ParentId As Integer
    Public Property RecordId As Integer
End Class

Public Class Tree
    Public Property Id As Integer
    Public Property ParentId As Integer

    Public Property Children As List(Of Tree)

    Public ReadOnly Property IsLeaf As Boolean
        Get
            Return Children.Count = 0
        End Get
    End Property
End Class

Public Module TreeBuilder
    Public Function BuildTree(ByVal records As IEnumerable(Of TreeBuildingRecord)) As Tree
        Dim ordered = New SortedList(Of Integer, TreeBuildingRecord)()

        For Each record In records
            ordered.Add(record.RecordId, record)
        Next

        records = ordered.Values

        Dim trees = New List(Of Tree)()
        Dim previousRecordId = -1

        For Each record In records
            Dim t = New Tree With {
                .Children = New List(Of Tree)(),
                .Id = record.RecordId,
                .ParentId = record.ParentId
            }
            trees.Add(t)

            If t.Id = 0 AndAlso t.ParentId <> 0 OrElse t.Id <> 0 AndAlso t.ParentId >= t.Id OrElse t.Id <> 0 AndAlso t.Id <> previousRecordId + 1 Then
                Throw New ArgumentException()
            End If

            Threading.Interlocked.Increment(previousRecordId)
        Next

        If trees.Count = 0 Then
            Throw New ArgumentException()
        End If

        For i = 1 To trees.Count - 1
            Dim t = trees.First(Function(x) x.Id = i)
            Dim parent = trees.First(Function(x) x.Id = t.ParentId)
            parent.Children.Add(t)
        Next

        Dim r = trees.First(Function(t) t.Id = 0)
        Return r
    End Function
End Module
