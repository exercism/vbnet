Imports Xunit

Public Class DifferenceOfSquaresTests
    <Fact>
    Public Sub Square_of_sum_1()
        Assert.Equal(1, CalculateSquareOfSum(1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Square_of_sum_5()
        Assert.Equal(225, CalculateSquareOfSum(5))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Square_of_sum_100()
        Assert.Equal(25502500, CalculateSquareOfSum(100))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sum_of_squares_1()
        Assert.Equal(1, CalculateSumOfSquares(1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sum_of_squares_5()
        Assert.Equal(55, CalculateSumOfSquares(5))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sum_of_squares_100()
        Assert.Equal(338350, CalculateSumOfSquares(100))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Difference_of_squares_1()
        Assert.Equal(0, CalculateDifferenceOfSquares(1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Difference_of_squares_5()
        Assert.Equal(170, CalculateDifferenceOfSquares(5))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Difference_of_squares_100()
        Assert.Equal(25164150, CalculateDifferenceOfSquares(100))
    End Sub
End Class
