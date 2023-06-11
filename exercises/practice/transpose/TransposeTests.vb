Imports Xunit

Public Class TransposeTests
    <Fact>
    Public Sub Empty_string()
        Dim lines = ""
        Dim expected = ""
        Assert.Equal(expected, Transpose.Text(lines))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_characters_in_a_row()
        Dim lines = "A1"
        Dim expected = "A" & vbLf & "1"
        Assert.Equal(expected, Transpose.Text(lines))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_characters_in_a_column()
        Dim lines = "A" & vbLf & "1"
        Dim expected = "A1"
        Assert.Equal(expected, Transpose.Text(lines))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Simple()
        Dim lines = "ABC" & vbLf & "123"
        Dim expected = "A1" & vbLf & "B2" & vbLf & "C3"
        Assert.Equal(expected, Transpose.Text(lines))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Single_line()
        Dim lines = "Single line."
        Dim expected = "S" & vbLf & "i" & vbLf & "n" & vbLf & "g" & vbLf & "l" & vbLf & "e" & vbLf & " " & vbLf & "l" & vbLf & "i" & vbLf & "n" & vbLf & "e" & vbLf & "."
        Assert.Equal(expected, Transpose.Text(lines))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub First_line_longer_than_second_line()
        Dim lines = "The fourth line." & vbLf & "The fifth line."
        Dim expected = "TT" & vbLf & "hh" & vbLf & "ee" & vbLf & "  " & vbLf & "ff" & vbLf & "oi" & vbLf & "uf" & vbLf & "rt" & vbLf & "th" & vbLf & "h " & vbLf & " l" & vbLf & "li" & vbLf & "in" & vbLf & "ne" & vbLf & "e." & vbLf & "."
        Assert.Equal(expected, Transpose.Text(lines))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Second_line_longer_than_first_line()
        Dim lines = "The first line." & vbLf & "The second line."
        Dim expected = "TT" & vbLf & "hh" & vbLf & "ee" & vbLf & "  " & vbLf & "fs" & vbLf & "ie" & vbLf & "rc" & vbLf & "so" & vbLf & "tn" & vbLf & " d" & vbLf & "l " & vbLf & "il" & vbLf & "ni" & vbLf & "en" & vbLf & ".e" & vbLf & " ."
        Assert.Equal(expected, Transpose.Text(lines))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Mixed_line_length()
        Dim lines = "The longest line." & vbLf & "A long line." & vbLf & "A longer line." & vbLf & "A line."
        Dim expected = "TAAA" & vbLf & "h   " & vbLf & "elll" & vbLf & " ooi" & vbLf & "lnnn" & vbLf & "ogge" & vbLf & "n e." & vbLf & "glr" & vbLf & "ei " & vbLf & "snl" & vbLf & "tei" & vbLf & " .n" & vbLf & "l e" & vbLf & "i ." & vbLf & "n" & vbLf & "e" & vbLf & "."
        Assert.Equal(expected, Transpose.Text(lines))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Square()
        Dim lines = "HEART" & vbLf & "EMBER" & vbLf & "ABUSE" & vbLf & "RESIN" & vbLf & "TREND"
        Dim expected = "HEART" & vbLf & "EMBER" & vbLf & "ABUSE" & vbLf & "RESIN" & vbLf & "TREND"
        Assert.Equal(expected, Transpose.Text(lines))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rectangle()
        Dim lines = "FRACTURE" & vbLf & "OUTLINED" & vbLf & "BLOOMING" & vbLf & "SEPTETTE"
        Dim expected = "FOBS" & vbLf & "RULE" & vbLf & "ATOP" & vbLf & "CLOT" & vbLf & "TIME" & vbLf & "UNIT" & vbLf & "RENT" & vbLf & "EDGE"
        Assert.Equal(expected, Transpose.Text(lines))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Triangle()
        Dim lines = "T" & vbLf & "EE" & vbLf & "AAA" & vbLf & "SSSS" & vbLf & "EEEEE" & vbLf & "RRRRRR"
        Dim expected = "TEASER" & vbLf & " EASER" & vbLf & "  ASER" & vbLf & "   SER" & vbLf & "    ER" & vbLf & "     R"
        Assert.Equal(expected, Transpose.Text(lines))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Jagged_triangle()
        Dim lines = "11" & vbLf & "2" & vbLf & "3333" & vbLf & "444" & vbLf & "555555" & vbLf & "66666"
        Dim expected = "123456" & vbLf & "1 3456" & vbLf & "  3456" & vbLf & "  3 56" & vbLf & "    56" & vbLf & "    5"
        Assert.Equal(expected, Transpose.Text(lines))
    End Sub
End Class
