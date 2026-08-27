Public Class LuhnTests
    <Fact>
    Public Sub Single_digit_strings_can_not_be_valid()
        Dim number = "1"
        Assert.False(Luhn.IsValid(number))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_single_zero_is_invalid()
        Dim number = "0"
        Assert.False(Luhn.IsValid(number))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_simple_valid_sin_that_remains_valid_if_reversed()
        Dim number = "059"
        Assert.True(Luhn.IsValid(number))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_simple_valid_sin_that_becomes_invalid_if_reversed()
        Dim number = "59"
        Assert.True(Luhn.IsValid(number))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_valid_canadian_sin()
        Dim number = "055 444 285"
        Assert.True(Luhn.IsValid(number))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_canadian_sin()
        Dim number = "055 444 286"
        Assert.False(Luhn.IsValid(number))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_credit_card()
        Dim number = "8273 1232 7352 0569"
        Assert.False(Luhn.IsValid(number))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_long_number_with_an_even_remainder()
        Dim number = "1 2345 6789 1234 5678 9012"
        Assert.False(Luhn.IsValid(number))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_long_number_with_a_remainder_divisible_by_5()
        Dim number = "1 2345 6789 1234 5678 9013"
        Assert.False(Luhn.IsValid(number))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Valid_number_with_an_even_number_of_digits()
        Dim number = "095 245 88"
        Assert.True(Luhn.IsValid(number))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Valid_number_with_an_odd_number_of_spaces()
        Dim number = "234 567 891 234"
        Assert.True(Luhn.IsValid(number))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Valid_strings_with_a_non_digit_added_at_the_end_become_invalid()
        Dim number = "059a"
        Assert.False(Luhn.IsValid(number))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Valid_strings_with_punctuation_included_become_invalid()
        Dim number = "055-444-285"
        Assert.False(Luhn.IsValid(number))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Valid_strings_with_symbols_included_become_invalid()
        Dim number = "055# 444$ 285"
        Assert.False(Luhn.IsValid(number))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Single_zero_with_space_is_invalid()
        Dim number = " 0"
        Assert.False(Luhn.IsValid(number))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub More_than_a_single_zero_is_valid()
        Dim number = "0000 0"
        Assert.True(Luhn.IsValid(number))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Input_digit_9_is_correctly_converted_to_output_digit_9()
        Dim number = "091"
        Assert.True(Luhn.IsValid(number))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Very_long_input_is_valid()
        Dim number = "9999999999 9999999999 9999999999 9999999999"
        Assert.True(Luhn.IsValid(number))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Valid_luhn_with_an_odd_number_of_digits_and_non_zero_first_digit()
        Dim number = "109"
        Assert.True(Luhn.IsValid(number))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Using_ascii_value_for_non_doubled_non_digit_isn_t_allowed()
        Dim number = "055b 444 285"
        Assert.False(Luhn.IsValid(number))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Using_ascii_value_for_doubled_non_digit_isn_t_allowed()
        Dim number = ":9"
        Assert.False(Luhn.IsValid(number))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Non_numeric_non_space_char_in_the_middle_with_a_sum_that_s_divisible_by_10_isn_t_allowed()
        Dim number = "59%59"
        Assert.False(Luhn.IsValid(number))
    End Sub
End Class
