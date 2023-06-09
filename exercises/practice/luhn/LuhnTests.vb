Imports Xunit

Public Class LuhnTests
    <Fact>
    Public Sub Single_digit_strings_can_not_be_valid()
        Assert.False(IsValid("1"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_single_zero_is_invalid()
        Assert.False(IsValid("0"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_simple_valid_sin_that_remains_valid_if_reversed()
        Assert.True(IsValid("059"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_simple_valid_sin_that_becomes_invalid_if_reversed()
        Assert.True(IsValid("59"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_valid_canadian_sin()
        Assert.True(IsValid("055 444 285"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_canadian_sin()
        Assert.False(IsValid("055 444 286"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_credit_card()
        Assert.False(IsValid("8273 1232 7352 0569"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_long_number_with_an_even_remainder()
        Assert.False(IsValid("1 2345 6789 1234 5678 9012"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_long_number_with_a_remainder_divisible_by_5()
        Assert.False(IsValid("1 2345 6789 1234 5678 9013"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Valid_number_with_an_even_number_of_digits()
        Assert.True(IsValid("095 245 88"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Valid_number_with_an_odd_number_of_spaces()
        Assert.True(IsValid("234 567 891 234"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Valid_strings_with_a_non_digit_added_at_the_end_become_invalid()
        Assert.False(IsValid("059a"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Valid_strings_with_punctuation_included_become_invalid()
        Assert.False(IsValid("055-444-285"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Valid_strings_with_symbols_included_become_invalid()
        Assert.False(IsValid("055# 444$ 285"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Single_zero_with_space_is_invalid()
        Assert.False(IsValid(" 0"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub More_than_a_single_zero_is_valid()
        Assert.True(IsValid("0000 0"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Input_digit_9_is_correctly_converted_to_output_digit_9()
        Assert.True(IsValid("091"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Very_long_input_is_valid()
        Assert.True(IsValid("9999999999 9999999999 9999999999 9999999999"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Valid_luhn_with_an_odd_number_of_digits_and_non_zero_first_digit()
        Assert.True(IsValid("109"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Using_ascii_value_for_non_doubled_non_digit_isnt_allowed()
        Assert.False(IsValid("055b 444 285"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Using_ascii_value_for_doubled_non_digit_isnt_allowed()
        Assert.False(IsValid(":9"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Non_numeric_non_space_char_in_the_middle_with_a_sum_thats_divisible_by_10_isnt_allowed()
        Assert.False(IsValid("59%59"))
    End Sub
End Class
