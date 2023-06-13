Imports System
Imports Xunit

Public Class TwoBucketTests
    <Fact>
    Public Sub Measure_using_bucket_one_of_size_3_and_bucket_two_of_size_5_start_with_bucket_one()
        Dim sut = New TwoBucket(3, 5, Bucket.One)
        Dim actual = sut.Measure(1)
        Assert.Equal(4, actual.Moves)
        Assert.Equal(5, actual.OtherBucket)
        Assert.Equal(Bucket.One, actual.GoalBucket)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Measure_using_bucket_one_of_size_3_and_bucket_two_of_size_5_start_with_bucket_two()
        Dim sut = New TwoBucket(3, 5, Bucket.Two)
        Dim actual = sut.Measure(1)
        Assert.Equal(8, actual.Moves)
        Assert.Equal(3, actual.OtherBucket)
        Assert.Equal(Bucket.Two, actual.GoalBucket)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Measure_using_bucket_one_of_size_7_and_bucket_two_of_size_11_start_with_bucket_one()
        Dim sut = New TwoBucket(7, 11, Bucket.One)
        Dim actual = sut.Measure(2)
        Assert.Equal(14, actual.Moves)
        Assert.Equal(11, actual.OtherBucket)
        Assert.Equal(Bucket.One, actual.GoalBucket)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Measure_using_bucket_one_of_size_7_and_bucket_two_of_size_11_start_with_bucket_two()
        Dim sut = New TwoBucket(7, 11, Bucket.Two)
        Dim actual = sut.Measure(2)
        Assert.Equal(18, actual.Moves)
        Assert.Equal(7, actual.OtherBucket)
        Assert.Equal(Bucket.Two, actual.GoalBucket)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Measure_one_step_using_bucket_one_of_size_1_and_bucket_two_of_size_3_start_with_bucket_two()
        Dim sut = New TwoBucket(1, 3, Bucket.Two)
        Dim actual = sut.Measure(3)
        Assert.Equal(1, actual.Moves)
        Assert.Equal(0, actual.OtherBucket)
        Assert.Equal(Bucket.Two, actual.GoalBucket)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Measure_using_bucket_one_of_size_2_and_bucket_two_of_size_3_start_with_bucket_one_and_end_with_bucket_two()
        Dim sut = New TwoBucket(2, 3, Bucket.One)
        Dim actual = sut.Measure(3)
        Assert.Equal(2, actual.Moves)
        Assert.Equal(2, actual.OtherBucket)
        Assert.Equal(Bucket.Two, actual.GoalBucket)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Not_possible_to_reach_the_goal()
        Dim sut = New TwoBucket(6, 15, Bucket.One)
        Assert.Throws(Of ArgumentException)(Function() sut.Measure(5))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub With_the_same_buckets_but_a_different_goal_then_it_is_possible()
        Dim sut = New TwoBucket(6, 15, Bucket.One)
        Dim actual = sut.Measure(9)
        Assert.Equal(10, actual.Moves)
        Assert.Equal(0, actual.OtherBucket)
        Assert.Equal(Bucket.Two, actual.GoalBucket)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Goal_larger_than_both_buckets_is_impossible()
        Dim sut = New TwoBucket(5, 7, Bucket.One)
        Assert.Throws(Of ArgumentException)(Function() sut.Measure(8))
    End Sub
End Class
