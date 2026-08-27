Public Class LargestSeriesProductTests
    <Fact>
    Public Sub Finds_the_largest_product_if_span_equals_length()
        Dim digits = "29"
        Assert.Equal(18, LargestSeriesProduct.GetLargestProduct(digits, 2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_find_the_largest_product_of_2_with_numbers_in_order()
        Dim digits = "0123456789"
        Assert.Equal(72, LargestSeriesProduct.GetLargestProduct(digits, 2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_find_the_largest_product_of_2()
        Dim digits = "576802143"
        Assert.Equal(48, LargestSeriesProduct.GetLargestProduct(digits, 2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_find_the_largest_product_of_3_with_numbers_in_order()
        Dim digits = "0123456789"
        Assert.Equal(504, LargestSeriesProduct.GetLargestProduct(digits, 3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_find_the_largest_product_of_3()
        Dim digits = "1027839564"
        Assert.Equal(270, LargestSeriesProduct.GetLargestProduct(digits, 3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_find_the_largest_product_of_5_with_numbers_in_order()
        Dim digits = "0123456789"
        Assert.Equal(15120, LargestSeriesProduct.GetLargestProduct(digits, 5))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_get_the_largest_product_of_a_big_number()
        Dim digits = "73167176531330624919225119674426574742355349194934"
        Assert.Equal(23520, LargestSeriesProduct.GetLargestProduct(digits, 6))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reports_zero_if_the_only_digits_are_zero()
        Dim digits = "0000"
        Assert.Equal(0, LargestSeriesProduct.GetLargestProduct(digits, 2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reports_zero_if_all_spans_include_zero()
        Dim digits = "99099"
        Assert.Equal(0, LargestSeriesProduct.GetLargestProduct(digits, 3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rejects_span_longer_than_string_length()
        Dim digits = "123"
        Assert.Throws(Of ArgumentException)(Function() LargestSeriesProduct.GetLargestProduct(digits, 4))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rejects_empty_string_and_nonzero_span()
        Dim digits = ""
        Assert.Throws(Of ArgumentException)(Function() LargestSeriesProduct.GetLargestProduct(digits, 1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rejects_invalid_character_in_digits()
        Dim digits = "1234a5"
        Assert.Throws(Of ArgumentException)(Function() LargestSeriesProduct.GetLargestProduct(digits, 2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rejects_negative_span()
        Dim digits = "12345"
        Assert.Throws(Of ArgumentException)(Function() LargestSeriesProduct.GetLargestProduct(digits, -1))
    End Sub
End Class
