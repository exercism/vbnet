Imports System
Imports Xunit

Public Class OcrNumbersTests
    <Fact>
    Public Sub Recognizes_0()
        Dim rows = " _ " & vbLf & "| |" & vbLf & "|_|" & vbLf & "   "
        Dim actual = Convert(rows)
        Assert.Equal("0", actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Recognizes_1()
        Dim rows = "   " & vbLf & "  |" & vbLf & "  |" & vbLf & "   "
        Dim actual = Convert(rows)
        Assert.Equal("1", actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Unreadable_but_correctly_sized_inputs_return_()
        Dim rows = "   " & vbLf & "  _" & vbLf & "  |" & vbLf & "   "
        Dim actual = Convert(rows)
        Assert.Equal("?", actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Input_with_a_number_of_lines_that_is_not_a_multiple_of_four_raises_an_error()
        Dim rows = " _ " & vbLf & "| |" & vbLf & "   "
        Assert.Throws(Of ArgumentException)(Function() Convert(rows))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Input_with_a_number_of_columns_that_is_not_a_multiple_of_three_raises_an_error()
        Dim rows = "    " & vbLf & "   |" & vbLf & "   |" & vbLf & "    "
        Assert.Throws(Of ArgumentException)(Function() Convert(rows))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Recognizes_110101100()
        Dim rows = "       _     _        _  _ " & vbLf & "  |  || |  || |  |  || || |" & vbLf & "  |  ||_|  ||_|  |  ||_||_|" & vbLf & "                           "
        Dim actual = Convert(rows)
        Assert.Equal("110101100", actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Garbled_numbers_in_a_string_are_replaced_with_()
        Dim rows = "       _     _           _ " & vbLf & "  |  || |  || |     || || |" & vbLf & "  |  | _|  ||_|  |  ||_||_|" & vbLf & "                           "
        Dim actual = Convert(rows)
        Assert.Equal("11?10?1?0", actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Recognizes_2()
        Dim rows = " _ " & vbLf & " _|" & vbLf & "|_ " & vbLf & "   "
        Dim actual = Convert(rows)
        Assert.Equal("2", actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Recognizes_3()
        Dim rows = " _ " & vbLf & " _|" & vbLf & " _|" & vbLf & "   "
        Dim actual = Convert(rows)
        Assert.Equal("3", actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Recognizes_4()
        Dim rows = "   " & vbLf & "|_|" & vbLf & "  |" & vbLf & "   "
        Dim actual = Convert(rows)
        Assert.Equal("4", actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Recognizes_5()
        Dim rows = " _ " & vbLf & "|_ " & vbLf & " _|" & vbLf & "   "
        Dim actual = Convert(rows)
        Assert.Equal("5", actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Recognizes_6()
        Dim rows = " _ " & vbLf & "|_ " & vbLf & "|_|" & vbLf & "   "
        Dim actual = Convert(rows)
        Assert.Equal("6", actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Recognizes_7()
        Dim rows = " _ " & vbLf & "  |" & vbLf & "  |" & vbLf & "   "
        Dim actual = Convert(rows)
        Assert.Equal("7", actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Recognizes_8()
        Dim rows = " _ " & vbLf & "|_|" & vbLf & "|_|" & vbLf & "   "
        Dim actual = Convert(rows)
        Assert.Equal("8", actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Recognizes_9()
        Dim rows = " _ " & vbLf & "|_|" & vbLf & " _|" & vbLf & "   "
        Dim actual = Convert(rows)
        Assert.Equal("9", actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Recognizes_string_of_decimal_numbers()
        Dim rows = "    _  _     _  _  _  _  _  _ " & vbLf & "  | _| _||_||_ |_   ||_||_|| |" & vbLf & "  ||_  _|  | _||_|  ||_| _||_|" & vbLf & "                              "
        Dim actual = Convert(rows)
        Assert.Equal("1234567890", actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Numbers_separated_by_empty_lines_are_recognized_lines_are_joined_by_commas_()
        Dim rows = "    _  _ " & vbLf & "  | _| _|" & vbLf & "  ||_  _|" & vbLf & "         " & vbLf & "    _  _ " & vbLf & "|_||_ |_ " & vbLf & "  | _||_|" & vbLf & "         " & vbLf & " _  _  _ " & vbLf & "  ||_||_|" & vbLf & "  ||_| _|" & vbLf & "         "
        Dim actual = Convert(rows)
        Assert.Equal("123,456,789", actual)
    End Sub
End Class
