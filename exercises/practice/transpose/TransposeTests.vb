Public Class TransposeTests
    <Fact>
    Public Sub Empty_string()
        Dim lines = ""
        Dim expected = ""

        Assert.Equal(expected, Transpose.Text(lines))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_characters_in_a_row()
        Dim lines = String.Join(vbLf, {
            "A1"
        })
        Dim expected = String.Join(vbLf, {
            "A",
            "1"
        })

        Assert.Equal(expected, Transpose.Text(lines))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_characters_in_a_column()
        Dim lines = String.Join(vbLf, {
            "A",
            "1"
        })
        Dim expected = String.Join(vbLf, {
            "A1"
        })

        Assert.Equal(expected, Transpose.Text(lines))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Simple()
        Dim lines = String.Join(vbLf, {
            "ABC",
            "123"
        })
        Dim expected = String.Join(vbLf, {
            "A1",
            "B2",
            "C3"
        })

        Assert.Equal(expected, Transpose.Text(lines))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Single_line()
        Dim lines = String.Join(vbLf, {
            "Single line."
        })
        Dim expected = String.Join(vbLf, {
            "S",
            "i",
            "n",
            "g",
            "l",
            "e",
            " ",
            "l",
            "i",
            "n",
            "e",
            "."
        })

        Assert.Equal(expected, Transpose.Text(lines))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub First_line_longer_than_second_line()
        Dim lines = String.Join(vbLf, {
            "The fourth line.",
            "The fifth line."
        })
        Dim expected = String.Join(vbLf, {
            "TT",
            "hh",
            "ee",
            "  ",
            "ff",
            "oi",
            "uf",
            "rt",
            "th",
            "h ",
            " l",
            "li",
            "in",
            "ne",
            "e.",
            "."
        })

        Assert.Equal(expected, Transpose.Text(lines))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Second_line_longer_than_first_line()
        Dim lines = String.Join(vbLf, {
            "The first line.",
            "The second line."
        })
        Dim expected = String.Join(vbLf, {
            "TT",
            "hh",
            "ee",
            "  ",
            "fs",
            "ie",
            "rc",
            "so",
            "tn",
            " d",
            "l ",
            "il",
            "ni",
            "en",
            ".e",
            " ."
        })

        Assert.Equal(expected, Transpose.Text(lines))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Mixed_line_length()
        Dim lines = String.Join(vbLf, {
            "The longest line.",
            "A long line.",
            "A longer line.",
            "A line."
        })
        Dim expected = String.Join(vbLf, {
            "TAAA",
            "h   ",
            "elll",
            " ooi",
            "lnnn",
            "ogge",
            "n e.",
            "glr",
            "ei ",
            "snl",
            "tei",
            " .n",
            "l e",
            "i .",
            "n",
            "e",
            "."
        })

        Assert.Equal(expected, Transpose.Text(lines))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Square()
        Dim lines = String.Join(vbLf, {
            "HEART",
            "EMBER",
            "ABUSE",
            "RESIN",
            "TREND"
        })
        Dim expected = String.Join(vbLf, {
            "HEART",
            "EMBER",
            "ABUSE",
            "RESIN",
            "TREND"
        })

        Assert.Equal(expected, Transpose.Text(lines))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rectangle()
        Dim lines = String.Join(vbLf, {
            "FRACTURE",
            "OUTLINED",
            "BLOOMING",
            "SEPTETTE"
        })
        Dim expected = String.Join(vbLf, {
            "FOBS",
            "RULE",
            "ATOP",
            "CLOT",
            "TIME",
            "UNIT",
            "RENT",
            "EDGE"
        })

        Assert.Equal(expected, Transpose.Text(lines))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Triangle()
        Dim lines = String.Join(vbLf, {
            "T",
            "EE",
            "AAA",
            "SSSS",
            "EEEEE",
            "RRRRRR"
        })
        Dim expected = String.Join(vbLf, {
            "TEASER",
            " EASER",
            "  ASER",
            "   SER",
            "    ER",
            "     R"
        })

        Assert.Equal(expected, Transpose.Text(lines))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Jagged_triangle()
        Dim lines = String.Join(vbLf, {
            "11",
            "2",
            "3333",
            "444",
            "555555",
            "66666"
        })
        Dim expected = String.Join(vbLf, {
            "123456",
            "1 3456",
            "  3456",
            "  3 56",
            "    56",
            "    5"
        })

        Assert.Equal(expected, Transpose.Text(lines))
    End Sub
End Class
