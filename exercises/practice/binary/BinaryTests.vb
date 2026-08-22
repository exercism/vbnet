Public Class BinaryTests
    <Fact>
    Public Sub Binary_0_is_decimal_0()
        Dim sut = New Binary("0")
        Assert.Equal(0, sut.ToDecimal())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Binary_1_is_decimal_1()
        Dim sut = New Binary("1")
        Assert.Equal(1, sut.ToDecimal())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Binary_10_is_decimal_2()
        Dim sut = New Binary("10")
        Assert.Equal(2, sut.ToDecimal())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Binary_11_is_decimal_3()
        Dim sut = New Binary("11")
        Assert.Equal(3, sut.ToDecimal())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Binary_100_is_decimal_4()
        Dim sut = New Binary("100")
        Assert.Equal(4, sut.ToDecimal())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Binary_1001_is_decimal_9()
        Dim sut = New Binary("1001")
        Assert.Equal(9, sut.ToDecimal())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Binary_11010_is_decimal_26()
        Dim sut = New Binary("11010")
        Assert.Equal(26, sut.ToDecimal())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Binary_10001101000_is_decimal_1128()
        Dim sut = New Binary("10001101000")
        Assert.Equal(1128, sut.ToDecimal())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Binary_ignores_leading_zeros()
        Dim sut = New Binary("000011111")
        Assert.Equal(31, sut.ToDecimal())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_is_not_a_valid_binary_digit()
        Dim sut = New Binary("2")
        Assert.Equal(0, sut.ToDecimal())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_number_containing_a_non_binary_digit_is_invalid()
        Dim sut = New Binary("01201")
        Assert.Equal(0, sut.ToDecimal())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_number_with_trailing_non_binary_characters_is_invalid()
        Dim sut = New Binary("10nope")
        Assert.Equal(0, sut.ToDecimal())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_number_with_leading_non_binary_characters_is_invalid()
        Dim sut = New Binary("nope10")
        Assert.Equal(0, sut.ToDecimal())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_number_with_internal_non_binary_characters_is_invalid()
        Dim sut = New Binary("10nope10")
        Assert.Equal(0, sut.ToDecimal())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_number_and_a_word_whitespace_separated_is_invalid()
        Dim sut = New Binary("001 nope")
        Assert.Equal(0, sut.ToDecimal())
    End Sub
End Class
