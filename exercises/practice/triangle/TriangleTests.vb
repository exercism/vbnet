Imports Xunit

Public Class TriangleTests
    <Fact>
    Public Sub Equilateral_triangle_all_sides_are_equal()
        Assert.True(IsEquilateral(2, 2, 2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Equilateral_triangle_any_side_is_unequal()
        Assert.False(IsEquilateral(2, 3, 2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Equilateral_triangle_no_sides_are_equal()
        Assert.False(IsEquilateral(5, 4, 6))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Equilateral_triangle_all_zero_sides_is_not_a_triangle()
        Assert.False(IsEquilateral(0, 0, 0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Equilateral_triangle_sides_may_be_floats()
        Assert.True(IsEquilateral(0.5, 0.5, 0.5))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Isosceles_triangle_last_two_sides_are_equal()
        Assert.True(IsIsosceles(3, 4, 4))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Isosceles_triangle_first_two_sides_are_equal()
        Assert.True(IsIsosceles(4, 4, 3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Isosceles_triangle_first_and_last_sides_are_equal()
        Assert.True(IsIsosceles(4, 3, 4))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Isosceles_triangle_equilateral_triangles_are_also_isosceles()
        Assert.True(IsIsosceles(4, 4, 4))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Isosceles_triangle_no_sides_are_equal()
        Assert.False(IsIsosceles(2, 3, 4))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Isosceles_triangle_first_triangle_inequality_violation()
        Assert.False(IsIsosceles(1, 1, 3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Isosceles_triangle_second_triangle_inequality_violation()
        Assert.False(IsIsosceles(1, 3, 1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Isosceles_triangle_third_triangle_inequality_violation()
        Assert.False(IsIsosceles(3, 1, 1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Isosceles_triangle_sides_may_be_floats()
        Assert.True(IsIsosceles(0.5, 0.4, 0.5))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Scalene_triangle_no_sides_are_equal()
        Assert.True(IsScalene(5, 4, 6))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Scalene_triangle_all_sides_are_equal()
        Assert.False(IsScalene(4, 4, 4))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Scalene_triangle_first_and_second_sides_are_equal()
        Assert.False(IsScalene(4, 4, 3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Scalene_triangle_first_and_third_sides_are_equal()
        Assert.False(IsScalene(3, 4, 3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Scalene_triangle_second_and_third_sides_are_equal()
        Assert.False(IsScalene(4, 3, 3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Scalene_triangle_may_not_violate_triangle_inequality()
        Assert.False(IsScalene(7, 3, 2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Scalene_triangle_sides_may_be_floats()
        Assert.True(IsScalene(0.5, 0.4, 0.6))
    End Sub
End Class
