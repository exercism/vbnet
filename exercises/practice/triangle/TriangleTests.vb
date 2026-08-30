Public Class TriangleTests
    <Fact>
    Public Sub Equilateral_triangle_all_sides_are_equal()
        Assert.True(Triangle.IsEquilateral(2.0, 2.0, 2.0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Equilateral_triangle_any_side_is_unequal()
        Assert.False(Triangle.IsEquilateral(2.0, 3.0, 2.0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Equilateral_triangle_no_sides_are_equal()
        Assert.False(Triangle.IsEquilateral(5.0, 4.0, 6.0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Equilateral_triangle_all_zero_sides_is_not_a_triangle()
        Assert.False(Triangle.IsEquilateral(0.0, 0.0, 0.0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Equilateral_triangle_sides_may_be_floats()
        Assert.True(Triangle.IsEquilateral(0.5, 0.5, 0.5))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Isosceles_triangle_last_two_sides_are_equal()
        Assert.True(Triangle.IsIsosceles(3.0, 4.0, 4.0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Isosceles_triangle_first_two_sides_are_equal()
        Assert.True(Triangle.IsIsosceles(4.0, 4.0, 3.0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Isosceles_triangle_first_and_last_sides_are_equal()
        Assert.True(Triangle.IsIsosceles(4.0, 3.0, 4.0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Isosceles_triangle_equilateral_triangles_are_also_isosceles()
        Assert.True(Triangle.IsIsosceles(4.0, 4.0, 4.0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Isosceles_triangle_no_sides_are_equal()
        Assert.False(Triangle.IsIsosceles(2.0, 3.0, 4.0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Isosceles_triangle_first_triangle_inequality_violation()
        Assert.False(Triangle.IsIsosceles(1.0, 1.0, 3.0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Isosceles_triangle_second_triangle_inequality_violation()
        Assert.False(Triangle.IsIsosceles(1.0, 3.0, 1.0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Isosceles_triangle_third_triangle_inequality_violation()
        Assert.False(Triangle.IsIsosceles(3.0, 1.0, 1.0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Isosceles_triangle_sides_may_be_floats()
        Assert.True(Triangle.IsIsosceles(0.5, 0.4, 0.5))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Scalene_triangle_no_sides_are_equal()
        Assert.True(Triangle.IsScalene(5.0, 4.0, 6.0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Scalene_triangle_all_sides_are_equal()
        Assert.False(Triangle.IsScalene(4.0, 4.0, 4.0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Scalene_triangle_first_and_second_sides_are_equal()
        Assert.False(Triangle.IsScalene(4.0, 4.0, 3.0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Scalene_triangle_first_and_third_sides_are_equal()
        Assert.False(Triangle.IsScalene(3.0, 4.0, 3.0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Scalene_triangle_second_and_third_sides_are_equal()
        Assert.False(Triangle.IsScalene(4.0, 3.0, 3.0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Scalene_triangle_may_not_violate_triangle_inequality()
        Assert.False(Triangle.IsScalene(7.0, 3.0, 2.0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Scalene_triangle_sides_may_be_floats()
        Assert.True(Triangle.IsScalene(0.5, 0.4, 0.6))
    End Sub
End Class
