Public Class OcrNumbersTests
    <Fact>
    Public Sub Recognizes_0()
        Dim rows = String.Join(vbLf, {
            " _ ",
            "| |",
            "|_|",
            "   "
        })
        Assert.Equal("0", OcrNumbers.Convert(rows))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Recognizes_1()
        Dim rows = String.Join(vbLf, {
            "   ",
            "  |",
            "  |",
            "   "
        })
        Assert.Equal("1", OcrNumbers.Convert(rows))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Unreadable_but_correctly_sized_inputs_return()
        Dim rows = String.Join(vbLf, {
            "   ",
            "  _",
            "  |",
            "   "
        })
        Assert.Equal("?", OcrNumbers.Convert(rows))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Input_with_a_number_of_lines_that_is_not_a_multiple_of_four_raises_an_error()
        Dim rows = String.Join(vbLf, {
            " _ ",
            "| |",
            "   "
        })
        Assert.Throws(Of ArgumentException)(Function() OcrNumbers.Convert(rows))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Input_with_a_number_of_columns_that_is_not_a_multiple_of_three_raises_an_error()
        Dim rows = String.Join(vbLf, {
            "    ",
            "   |",
            "   |",
            "    "
        })
        Assert.Throws(Of ArgumentException)(Function() OcrNumbers.Convert(rows))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Recognizes_110101100()
        Dim rows = String.Join(vbLf, {
            "       _     _        _  _ ",
            "  |  || |  || |  |  || || |",
            "  |  ||_|  ||_|  |  ||_||_|",
            "                           "
        })
        Assert.Equal("110101100", OcrNumbers.Convert(rows))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Garbled_numbers_in_a_string_are_replaced_with()
        Dim rows = String.Join(vbLf, {
            "       _     _           _ ",
            "  |  || |  || |     || || |",
            "  |  | _|  ||_|  |  ||_||_|",
            "                           "
        })
        Assert.Equal("11?10?1?0", OcrNumbers.Convert(rows))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Recognizes_2()
        Dim rows = String.Join(vbLf, {
            " _ ",
            " _|",
            "|_ ",
            "   "
        })
        Assert.Equal("2", OcrNumbers.Convert(rows))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Recognizes_3()
        Dim rows = String.Join(vbLf, {
            " _ ",
            " _|",
            " _|",
            "   "
        })
        Assert.Equal("3", OcrNumbers.Convert(rows))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Recognizes_4()
        Dim rows = String.Join(vbLf, {
            "   ",
            "|_|",
            "  |",
            "   "
        })
        Assert.Equal("4", OcrNumbers.Convert(rows))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Recognizes_5()
        Dim rows = String.Join(vbLf, {
            " _ ",
            "|_ ",
            " _|",
            "   "
        })
        Assert.Equal("5", OcrNumbers.Convert(rows))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Recognizes_6()
        Dim rows = String.Join(vbLf, {
            " _ ",
            "|_ ",
            "|_|",
            "   "
        })
        Assert.Equal("6", OcrNumbers.Convert(rows))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Recognizes_7()
        Dim rows = String.Join(vbLf, {
            " _ ",
            "  |",
            "  |",
            "   "
        })
        Assert.Equal("7", OcrNumbers.Convert(rows))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Recognizes_8()
        Dim rows = String.Join(vbLf, {
            " _ ",
            "|_|",
            "|_|",
            "   "
        })
        Assert.Equal("8", OcrNumbers.Convert(rows))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Recognizes_9()
        Dim rows = String.Join(vbLf, {
            " _ ",
            "|_|",
            " _|",
            "   "
        })
        Assert.Equal("9", OcrNumbers.Convert(rows))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Recognizes_string_of_decimal_numbers()
        Dim rows = String.Join(vbLf, {
            "    _  _     _  _  _  _  _  _ ",
            "  | _| _||_||_ |_   ||_||_|| |",
            "  ||_  _|  | _||_|  ||_| _||_|",
            "                              "
        })
        Assert.Equal("1234567890", OcrNumbers.Convert(rows))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Numbers_separated_by_empty_lines_are_recognized_lines_are_joined_by_commas()
        Dim rows = String.Join(vbLf, {
            "    _  _ ",
            "  | _| _|",
            "  ||_  _|",
            "         ",
            "    _  _ ",
            "|_||_ |_ ",
            "  | _||_|",
            "         ",
            " _  _  _ ",
            "  ||_||_|",
            "  ||_| _|",
            "         "
        })
        Assert.Equal("123,456,789", OcrNumbers.Convert(rows))
    End Sub
End Class
