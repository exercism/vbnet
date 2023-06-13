Imports System
Imports System.Collections.Generic
Imports System.Linq

Public Enum Bucket
    One
    Two
End Enum

Public Class TwoBucketResult
    Public Property Moves As Integer
    Public Property GoalBucket As Bucket
    Public Property OtherBucket As Integer
End Class

Public Class TwoBucket
    Private sizes As Integer()
    Private startBucket As Integer
    Public Sub New(ByVal bucketOne As Integer, ByVal bucketTwo As Integer, ByVal startBucket As Bucket)
        sizes = {bucketOne, bucketTwo}
        Me.startBucket = startBucket
    End Sub

    Private Function Empty(ByVal _buckets As Integer(), ByVal i As Integer) As Integer()
        Return If(i = 0, {0, _buckets(1)}, {_buckets(0), 0})
    End Function

    Private Function Fill(ByVal _buckets As Integer(), ByVal i As Integer) As Integer()
        Return If(i = 0, {sizes(0), _buckets(1)}, {_buckets(0), sizes(1)})
    End Function

    Private Function Consolidate(ByVal _buckets As Integer(), ByVal i As Integer) As Integer()
        Dim amount = {_buckets(1 - i), sizes(i) - _buckets(i)}.Min()
        Dim target = _buckets(i) + amount
        Dim src = _buckets(1 - i) - amount
        Return If(i = 0, {target, src}, {src, target})
    End Function

    Public Function Measure(ByVal goal As Integer) As TwoBucketResult
        Dim invalid = {0, 0}
        invalid(1 - startBucket) = sizes(1 - startBucket)
        Dim invalidStr = String.Join(",", invalid)
        Dim buckets = {0, 0}
        buckets(startBucket) = sizes(startBucket)
        Dim toVisit = New Queue(Of (Integer(), Integer))()
        Dim visited = New HashSet(Of String)()
        Dim count = 1
        Dim goalBucket = Array.IndexOf(buckets, goal)
        While goalBucket < 0
            Dim key = String.Join(",", buckets)
            If Not visited.Contains(key) AndAlso Not key.Equals(invalidStr) Then
                visited.Add(key)
                Dim nc = count + 1
                For i = 0 To 1
                    If buckets(i) <> 0 Then toVisit.Enqueue((Empty(buckets, i), nc))
                    If buckets(i) <> sizes(i) Then
                        toVisit.Enqueue((Fill(buckets, i), nc))
                        toVisit.Enqueue((Consolidate(buckets, i), nc))
                    End If
                Next
            End If
            If Not toVisit.Any() Then Throw New ArgumentException("no more moves!")
            (buckets, count) = toVisit.Dequeue()
            goalBucket = Array.IndexOf(buckets, goal)
        End While
        Return New TwoBucketResult With {
    .Moves = count,
    .GoalBucket = goalBucket,
    .OtherBucket = buckets(1 - goalBucket)
}
    End Function
End Class
