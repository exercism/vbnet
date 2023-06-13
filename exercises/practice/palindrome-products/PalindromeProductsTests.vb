Imports System
Imports Xunit

Public Class PalindromeProductsTests
    <Fact>
    Public Sub Find_the_smallest_palindrome_from_single_digit_factors()
        Dim actual = Smallest(1, 9)
        Dim expected = (1, {(1, 1)})
        Assert.Equal(expected.Item1, actual.Item1)
        Assert.Equal(expected.Item2, actual.Item2)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Find_the_largest_palindrome_from_single_digit_factors()
        Dim actual = Largest(1, 9)
        Dim expected = (9, {(1, 9), (3, 3)})
        Assert.Equal(expected.Item1, actual.Item1)
        Assert.Equal(expected.Item2, actual.Item2)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Find_the_smallest_palindrome_from_double_digit_factors()
        Dim actual = Smallest(10, 99)
        Dim expected = (121, {(11, 11)})
        Assert.Equal(expected.Item1, actual.Item1)
        Assert.Equal(expected.Item2, actual.Item2)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Find_the_largest_palindrome_from_double_digit_factors()
        Dim actual = Largest(10, 99)
        Dim expected = (9009, {(91, 99)})
        Assert.Equal(expected.Item1, actual.Item1)
        Assert.Equal(expected.Item2, actual.Item2)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Find_the_smallest_palindrome_from_triple_digit_factors()
        Dim actual = Smallest(100, 999)
        Dim expected = (10201, {(101, 101)})
        Assert.Equal(expected.Item1, actual.Item1)
        Assert.Equal(expected.Item2, actual.Item2)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Find_the_largest_palindrome_from_triple_digit_factors()
        Dim actual = Largest(100, 999)
        Dim expected = (906609, {(913, 993)})
        Assert.Equal(expected.Item1, actual.Item1)
        Assert.Equal(expected.Item2, actual.Item2)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Find_the_smallest_palindrome_from_four_digit_factors()
        Dim actual = Smallest(1000, 9999)
        Dim expected = (1002001, {(1001, 1001)})
        Assert.Equal(expected.Item1, actual.Item1)
        Assert.Equal(expected.Item2, actual.Item2)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Find_the_largest_palindrome_from_four_digit_factors()
        Dim actual = Largest(1000, 9999)
        Dim expected = (99000099, {(9901, 9999)})
        Assert.Equal(expected.Item1, actual.Item1)
        Assert.Equal(expected.Item2, actual.Item2)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Empty_result_for_smallest_if_no_palindrome_in_the_range()
        Assert.Throws(Of ArgumentException)(Function() Smallest(1002, 1003))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Empty_result_for_largest_if_no_palindrome_in_the_range()
        Assert.Throws(Of ArgumentException)(Function() Largest(15, 15))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Error_result_for_smallest_if_min_is_more_than_max()
        Assert.Throws(Of ArgumentException)(Function() Smallest(10000, 1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Error_result_for_largest_if_min_is_more_than_max()
        Assert.Throws(Of ArgumentException)(Function() Largest(2, 1))
    End Sub
End Class
