Imports System
Imports Xunit

Public Class LargestSeriesProductTests
    <Fact>
    Public Sub Finds_the_largest_product_if_span_equals_length()
        Assert.Equal(18, GetLargestProduct("29", 2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_find_the_largest_product_of_2_with_numbers_in_order()
        Assert.Equal(72, GetLargestProduct("0123456789", 2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_find_the_largest_product_of_2()
        Assert.Equal(48, GetLargestProduct("576802143", 2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_find_the_largest_product_of_3_with_numbers_in_order()
        Assert.Equal(504, GetLargestProduct("0123456789", 3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_find_the_largest_product_of_3()
        Assert.Equal(270, GetLargestProduct("1027839564", 3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_find_the_largest_product_of_5_with_numbers_in_order()
        Assert.Equal(15120, GetLargestProduct("0123456789", 5))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_get_the_largest_product_of_a_big_number()
        Assert.Equal(23520, GetLargestProduct("73167176531330624919225119674426574742355349194934", 6))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reports_zero_if_the_only_digits_are_zero()
        Assert.Equal(0, GetLargestProduct("0000", 2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reports_zero_if_all_spans_include_zero()
        Assert.Equal(0, GetLargestProduct("99099", 3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rejects_span_longer_than_string_length()
        Assert.Throws(Of ArgumentException)(Function() GetLargestProduct("123", 4))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rejects_empty_string_and_nonzero_span()
        Assert.Throws(Of ArgumentException)(Function() GetLargestProduct("", 1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rejects_invalid_character_in_digits()
        Assert.Throws(Of ArgumentException)(Function() GetLargestProduct("1234a5", 2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rejects_negative_span()
        Assert.Throws(Of ArgumentException)(Function() GetLargestProduct("12345", -1))
    End Sub
End Class
