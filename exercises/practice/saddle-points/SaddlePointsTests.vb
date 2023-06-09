Imports Xunit

Public Class SaddlePointsTests
    <Fact>
    Public Sub Can_identify_single_saddle_point()
        Dim matrix = {
             {9, 8, 7},
             {5, 3, 2},
                     {6, 6, 7}}
        Dim actual = SaddlePoints.Calculate(matrix)
        Dim expected = {(2, 1)}
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_identify_that_empty_matrix_has_no_saddle_points()
        Dim matrix = New Integer(,) {}
        Dim actual = SaddlePoints.Calculate(matrix)
        Assert.Empty(actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_identify_lack_of_saddle_points_when_there_are_none()
        Dim matrix = {
             {1, 2, 3},
             {3, 1, 2},
                     {2, 3, 1}}
        Dim actual = SaddlePoints.Calculate(matrix)
        Assert.Empty(actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_identify_multiple_saddle_points_in_a_column()
        Dim matrix = {
             {4, 5, 4},
             {3, 5, 5},
                     {1, 5, 4}}
        Dim actual = SaddlePoints.Calculate(matrix)
        Dim expected = {(1, 2), (2, 2), (3, 2)}
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_identify_multiple_saddle_points_in_a_row()
        Dim matrix = {
             {6, 7, 8},
             {5, 5, 5},
                     {7, 5, 6}}
        Dim actual = SaddlePoints.Calculate(matrix)
        Dim expected = {(2, 1), (2, 2), (2, 3)}
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_identify_saddle_point_in_bottom_right_corner()
        Dim matrix = {
             {8, 7, 9},
             {6, 7, 6},
                     {3, 2, 5}}
        Dim actual = SaddlePoints.Calculate(matrix)
        Dim expected = {(3, 3)}
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_identify_saddle_points_in_a_non_square_matrix()
        Dim matrix = {
             {3, 1, 3},
                     {3, 2, 4}}
        Dim actual = SaddlePoints.Calculate(matrix)
        Dim expected = {(1, 1), (1, 3)}
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_identify_that_saddle_points_in_a_single_column_matrix_are_those_with_the_minimum_value()
        Dim matrix = {
             {2},
             {1},
             {4},
                     {1}}
        Dim actual = SaddlePoints.Calculate(matrix)
        Dim expected = {(2, 1), (4, 1)}
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_identify_that_saddle_points_in_a_single_row_matrix_are_those_with_the_maximum_value()
        Dim matrix = {
                     {2, 5, 3, 5}}
        Dim actual = SaddlePoints.Calculate(matrix)
        Dim expected = {(1, 2), (1, 4)}
        Assert.Equal(expected, actual)
    End Sub
End Class
