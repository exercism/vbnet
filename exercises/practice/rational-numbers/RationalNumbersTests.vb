Imports Xunit

Public Class RationalNumbersTests
    <Fact>
    Public Sub Add_two_positive_rational_numbers()
        Assert.Equal(New RationalNumber(7, 6), New RationalNumber(1, 2) + (New RationalNumber(2, 3)))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Add_a_positive_rational_number_and_a_negative_rational_number()
        Assert.Equal(New RationalNumber(-1, 6), New RationalNumber(1, 2) + (New RationalNumber(-2, 3)))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Add_two_negative_rational_numbers()
        Assert.Equal(New RationalNumber(-7, 6), New RationalNumber(-1, 2) + (New RationalNumber(-2, 3)))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Add_a_rational_number_to_its_additive_inverse()
        Assert.Equal(New RationalNumber(0, 1), New RationalNumber(1, 2) + (New RationalNumber(-1, 2)))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Subtract_two_positive_rational_numbers()
        Assert.Equal(New RationalNumber(-1, 6), New RationalNumber(1, 2) - (New RationalNumber(2, 3)))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Subtract_a_positive_rational_number_and_a_negative_rational_number()
        Assert.Equal(New RationalNumber(7, 6), New RationalNumber(1, 2) - (New RationalNumber(-2, 3)))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Subtract_two_negative_rational_numbers()
        Assert.Equal(New RationalNumber(1, 6), New RationalNumber(-1, 2) - (New RationalNumber(-2, 3)))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Subtract_a_rational_number_from_itself()
        Assert.Equal(New RationalNumber(0, 1), New RationalNumber(1, 2) - (New RationalNumber(1, 2)))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiply_two_positive_rational_numbers()
        Assert.Equal(New RationalNumber(1, 3), New RationalNumber(1, 2) * (New RationalNumber(2, 3)))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiply_a_negative_rational_number_by_a_positive_rational_number()
        Assert.Equal(New RationalNumber(-1, 3), New RationalNumber(-1, 2) * (New RationalNumber(2, 3)))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiply_two_negative_rational_numbers()
        Assert.Equal(New RationalNumber(1, 3), New RationalNumber(-1, 2) * (New RationalNumber(-2, 3)))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiply_a_rational_number_by_its_reciprocal()
        Assert.Equal(New RationalNumber(1, 1), New RationalNumber(1, 2) * (New RationalNumber(2, 1)))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiply_a_rational_number_by_1()
        Assert.Equal(New RationalNumber(1, 2), New RationalNumber(1, 2) * (New RationalNumber(1, 1)))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiply_a_rational_number_by_0()
        Assert.Equal(New RationalNumber(0, 1), New RationalNumber(1, 2) * (New RationalNumber(0, 1)))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Divide_two_positive_rational_numbers()
        Assert.Equal(New RationalNumber(3, 4), New RationalNumber(1, 2) / (New RationalNumber(2, 3)))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Divide_a_positive_rational_number_by_a_negative_rational_number()
        Assert.Equal(New RationalNumber(-3, 4), New RationalNumber(1, 2) / (New RationalNumber(-2, 3)))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Divide_two_negative_rational_numbers()
        Assert.Equal(New RationalNumber(3, 4), New RationalNumber(-1, 2) / (New RationalNumber(-2, 3)))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Divide_a_rational_number_by_1()
        Assert.Equal(New RationalNumber(1, 2), New RationalNumber(1, 2) / (New RationalNumber(1, 1)))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Absolute_value_of_a_positive_rational_number()
        Assert.Equal(New RationalNumber(1, 2), New RationalNumber(1, 2).Abs())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Absolute_value_of_a_positive_rational_number_with_negative_numerator_and_denominator()
        Assert.Equal(New RationalNumber(1, 2), New RationalNumber(-1, -2).Abs())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Absolute_value_of_a_negative_rational_number()
        Assert.Equal(New RationalNumber(1, 2), New RationalNumber(-1, 2).Abs())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Absolute_value_of_a_negative_rational_number_with_negative_denominator()
        Assert.Equal(New RationalNumber(1, 2), New RationalNumber(1, -2).Abs())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Absolute_value_of_zero()
        Assert.Equal(New RationalNumber(0, 1), New RationalNumber(0, 1).Abs())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Absolute_value_of_a_rational_number_is_reduced_to_lowest_terms()
        Assert.Equal(New RationalNumber(1, 2), New RationalNumber(2, 4).Abs())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Raise_a_positive_rational_number_to_a_positive_integer_power()
        Assert.Equal(New RationalNumber(1, 8), New RationalNumber(1, 2).Exprational(3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Raise_a_negative_rational_number_to_a_positive_integer_power()
        Assert.Equal(New RationalNumber(-1, 8), New RationalNumber(-1, 2).Exprational(3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Raise_a_positive_rational_number_to_a_negative_integer_power()
        Assert.Equal(New RationalNumber(25, 9), New RationalNumber(3, 5).Exprational(-2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Raise_a_negative_rational_number_to_an_even_negative_integer_power()
        Assert.Equal(New RationalNumber(25, 9), New RationalNumber(-3, 5).Exprational(-2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Raise_a_negative_rational_number_to_an_odd_negative_integer_power()
        Assert.Equal(New RationalNumber(-125, 27), New RationalNumber(-3, 5).Exprational(-3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Raise_zero_to_an_integer_power()
        Assert.Equal(New RationalNumber(0, 1), New RationalNumber(0, 1).Exprational(5))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Raise_one_to_an_integer_power()
        Assert.Equal(New RationalNumber(1, 1), New RationalNumber(1, 1).Exprational(4))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Raise_a_positive_rational_number_to_the_power_of_zero()
        Assert.Equal(New RationalNumber(1, 1), New RationalNumber(1, 2).Exprational(0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Raise_a_negative_rational_number_to_the_power_of_zero()
        Assert.Equal(New RationalNumber(1, 1), New RationalNumber(-1, 2).Exprational(0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Raise_a_real_number_to_a_positive_rational_number()
        Assert.Equal(16, 8.Expreal(New RationalNumber(4, 3)), precision:=7)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Raise_a_real_number_to_a_negative_rational_number()
        Assert.Equal(0.33333334, 9.Expreal(New RationalNumber(-1, 2)), precision:=7)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Raise_a_real_number_to_a_zero_rational_number()
        Assert.Equal(1, 2.Expreal(New RationalNumber(0, 1)), precision:=7)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reduce_a_positive_rational_number_to_lowest_terms()
        Assert.Equal(New RationalNumber(1, 2), New RationalNumber(2, 4).Reduce())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reduce_places_the_minus_sign_on_the_numerator()
        Assert.Equal(New RationalNumber(-3, 4), New RationalNumber(3, -4).Reduce())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reduce_a_negative_rational_number_to_lowest_terms()
        Assert.Equal(New RationalNumber(-2, 3), New RationalNumber(-4, 6).Reduce())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reduce_a_rational_number_with_a_negative_denominator_to_lowest_terms()
        Assert.Equal(New RationalNumber(-1, 3), New RationalNumber(3, -9).Reduce())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reduce_zero_to_lowest_terms()
        Assert.Equal(New RationalNumber(0, 1), New RationalNumber(0, 6).Reduce())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reduce_an_integer_to_lowest_terms()
        Assert.Equal(New RationalNumber(-2, 1), New RationalNumber(-14, 7).Reduce())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reduce_one_to_lowest_terms()
        Assert.Equal(New RationalNumber(1, 1), New RationalNumber(13, 13).Reduce())
    End Sub
End Class
