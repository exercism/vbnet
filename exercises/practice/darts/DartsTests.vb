Imports Xunit

Public Class DartsTests
    <Fact>
    Public Sub Missed_target()
        Assert.Equal(0, Score(-9, 9))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub On_the_outer_circle()
        Assert.Equal(1, Score(0, 10))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub On_the_middle_circle()
        Assert.Equal(5, Score(-5, 0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub On_the_inner_circle()
        Assert.Equal(10, Score(0, -1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Exactly_on_centre()
        Assert.Equal(10, Score(0, 0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Near_the_centre()
        Assert.Equal(10, Score(-0.1, -0.1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Just_within_the_inner_circle()
        Assert.Equal(10, Score(0.7, 0.7))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Just_outside_the_inner_circle()
        Assert.Equal(5, Score(0.8, -0.8))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Just_within_the_middle_circle()
        Assert.Equal(5, Score(-3.5, 3.5))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Just_outside_the_middle_circle()
        Assert.Equal(1, Score(-3.6, -3.6))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Just_within_the_outer_circle()
        Assert.Equal(1, Score(-7, 7))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Just_outside_the_outer_circle()
        Assert.Equal(0, Score(7.1, -7.1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Asymmetric_position_between_the_inner_and_middle_circles()
        Assert.Equal(5, Score(0.5, -4))
    End Sub
End Class
