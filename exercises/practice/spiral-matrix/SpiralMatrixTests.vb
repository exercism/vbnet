Imports Xunit

Public Class SpiralMatrixTests
    <Fact>
    Public Sub Empty_spiral()
        Assert.Empty(SpiralMatrix.GetMatrix(0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Trivial_spiral()
        Dim expected = {
                     {1}}
        Assert.Equal(expected, SpiralMatrix.GetMatrix(1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Spiral_of_size_2()
        Dim expected = {
             {1, 2},
                     {4, 3}}
        Assert.Equal(expected, SpiralMatrix.GetMatrix(2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Spiral_of_size_3()
        Dim expected = {
             {1, 2, 3},
             {8, 9, 4},
                     {7, 6, 5}}
        Assert.Equal(expected, SpiralMatrix.GetMatrix(3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Spiral_of_size_4()
        Dim expected = {
             {1, 2, 3, 4},
             {12, 13, 14, 5},
             {11, 16, 15, 6},
                     {10, 9, 8, 7}}
        Assert.Equal(expected, SpiralMatrix.GetMatrix(4))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Spiral_of_size_5()
        Dim expected = {
             {1, 2, 3, 4, 5},
             {16, 17, 18, 19, 6},
             {15, 24, 25, 20, 7},
             {14, 23, 22, 21, 8},
                     {13, 12, 11, 10, 9}}
        Assert.Equal(expected, SpiralMatrix.GetMatrix(5))
    End Sub
End Class
