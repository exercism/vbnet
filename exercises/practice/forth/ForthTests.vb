Imports System
Imports Xunit

Public Class ForthTests
    <Fact>
    Public Sub Parsing_and_numbers_numbers_just_get_pushed_onto_the_stack()
        Assert.Equal("1 2 3 4 5", Evaluate({"1 2 3 4 5"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Parsing_and_numbers_pushes_negative_numbers_onto_the_stack()
        Assert.Equal("-1 -2 -3 -4 -5", Evaluate({"-1 -2 -3 -4 -5"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Addition_can_add_two_numbers()
        Assert.Equal("3", Evaluate({"1 2 +"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Addition_errors_if_there_is_nothing_on_the_stack()
        Assert.Throws(Of InvalidOperationException)(Function() Evaluate({"+"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Addition_errors_if_there_is_only_one_value_on_the_stack()
        Assert.Throws(Of InvalidOperationException)(Function() Evaluate({"1 +"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Subtraction_can_subtract_two_numbers()
        Assert.Equal("-1", Evaluate({"3 4 -"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Subtraction_errors_if_there_is_nothing_on_the_stack()
        Assert.Throws(Of InvalidOperationException)(Function() Evaluate({"-"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Subtraction_errors_if_there_is_only_one_value_on_the_stack()
        Assert.Throws(Of InvalidOperationException)(Function() Evaluate({"1 -"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiplication_can_multiply_two_numbers()
        Assert.Equal("8", Evaluate({"2 4 *"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiplication_errors_if_there_is_nothing_on_the_stack()
        Assert.Throws(Of InvalidOperationException)(Function() Evaluate({"*"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiplication_errors_if_there_is_only_one_value_on_the_stack()
        Assert.Throws(Of InvalidOperationException)(Function() Evaluate({"1 *"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Division_can_divide_two_numbers()
        Assert.Equal("4", Evaluate({"12 3 /"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Division_performs_integer_division()
        Assert.Equal("2", Evaluate({"8 3 /"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Division_errors_if_dividing_by_zero()
        Assert.Throws(Of DivideByZeroException)(Function() Evaluate({"4 0 /"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Division_errors_if_there_is_nothing_on_the_stack()
        Assert.Throws(Of InvalidOperationException)(Function() Evaluate({"/"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Division_errors_if_there_is_only_one_value_on_the_stack()
        Assert.Throws(Of InvalidOperationException)(Function() Evaluate({"1 /"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Combined_arithmetic_addition_and_subtraction()
        Assert.Equal("-1", Evaluate({"1 2 + 4 -"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Combined_arithmetic_multiplication_and_division()
        Assert.Equal("2", Evaluate({"2 4 * 3 /"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Dup_copies_a_value_on_the_stack()
        Assert.Equal("1 1", Evaluate({"1 dup"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Dup_copies_the_top_value_on_the_stack()
        Assert.Equal("1 2 2", Evaluate({"1 2 dup"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Dup_errors_if_there_is_nothing_on_the_stack()
        Assert.Throws(Of InvalidOperationException)(Function() Evaluate({"dup"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Drop_removes_the_top_value_on_the_stack_if_it_is_the_only_one()
        Assert.Equal("", Evaluate({"1 drop"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Drop_removes_the_top_value_on_the_stack_if_it_is_not_the_only_one()
        Assert.Equal("1", Evaluate({"1 2 drop"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Drop_errors_if_there_is_nothing_on_the_stack()
        Assert.Throws(Of InvalidOperationException)(Function() Evaluate({"drop"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Swap_swaps_the_top_two_values_on_the_stack_if_they_are_the_only_ones()
        Assert.Equal("2 1", Evaluate({"1 2 swap"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Swap_swaps_the_top_two_values_on_the_stack_if_they_are_not_the_only_ones()
        Assert.Equal("1 3 2", Evaluate({"1 2 3 swap"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Swap_errors_if_there_is_nothing_on_the_stack()
        Assert.Throws(Of InvalidOperationException)(Function() Evaluate({"swap"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Swap_errors_if_there_is_only_one_value_on_the_stack()
        Assert.Throws(Of InvalidOperationException)(Function() Evaluate({"1 swap"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Over_copies_the_second_element_if_there_are_only_two()
        Assert.Equal("1 2 1", Evaluate({"1 2 over"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Over_copies_the_second_element_if_there_are_more_than_two()
        Assert.Equal("1 2 3 2", Evaluate({"1 2 3 over"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Over_errors_if_there_is_nothing_on_the_stack()
        Assert.Throws(Of InvalidOperationException)(Function() Evaluate({"over"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Over_errors_if_there_is_only_one_value_on_the_stack()
        Assert.Throws(Of InvalidOperationException)(Function() Evaluate({"1 over"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub User_defined_words_can_consist_of_built_in_words()
        Assert.Equal("1 1 1", Evaluate({": dup-twice dup dup ;", "1 dup-twice"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub User_defined_words_execute_in_the_right_order()
        Assert.Equal("1 2 3", Evaluate({": countup 1 2 3 ;", "countup"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub User_defined_words_can_override_other_user_defined_words()
        Assert.Equal("1 1 1", Evaluate({": foo dup ;", ": foo dup dup ;", "1 foo"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub User_defined_words_can_override_built_in_words()
        Assert.Equal("1 1", Evaluate({": swap dup ;", "1 swap"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub User_defined_words_can_override_built_in_operators()
        Assert.Equal("12", Evaluate({": + * ;", "3 4 +"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub User_defined_words_can_use_different_words_with_the_same_name()
        Assert.Equal("5 6", Evaluate({": foo 5 ;", ": bar foo ;", ": foo 6 ;", "bar foo"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub User_defined_words_can_define_word_that_uses_word_with_the_same_name()
        Assert.Equal("11", Evaluate({": foo 10 ;", ": foo foo 1 + ;", "foo"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub User_defined_words_cannot_redefine_non_negative_numbers()
        Assert.Throws(Of InvalidOperationException)(Function() Evaluate({": 1 2 ;"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub User_defined_words_cannot_redefine_negative_numbers()
        Assert.Throws(Of InvalidOperationException)(Function() Evaluate({": -1 2 ;"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub User_defined_words_errors_if_executing_a_non_existent_word()
        Assert.Throws(Of InvalidOperationException)(Function() Evaluate({"foo"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub User_defined_words_only_defines_locally()
        Assert.Equal("0", Evaluate({": + - ;", "1 1 +"}))
        Assert.Equal("2", Evaluate({"1 1 +"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Case_insensitivity_dup_is_case_insensitive()
        Assert.Equal("1 1 1 1", Evaluate({"1 DUP Dup dup"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Case_insensitivity_drop_is_case_insensitive()
        Assert.Equal("1", Evaluate({"1 2 3 4 DROP Drop drop"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Case_insensitivity_swap_is_case_insensitive()
        Assert.Equal("2 3 4 1", Evaluate({"1 2 SWAP 3 Swap 4 swap"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Case_insensitivity_over_is_case_insensitive()
        Assert.Equal("1 2 1 2 1", Evaluate({"1 2 OVER Over over"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Case_insensitivity_user_defined_words_are_case_insensitive()
        Assert.Equal("1 1 1 1", Evaluate({": foo dup ;", "1 FOO Foo foo"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Case_insensitivity_definitions_are_case_insensitive()
        Assert.Equal("1 1 1 1", Evaluate({": SWAP DUP Dup dup ;", "1 swap"}))
    End Sub
End Class
