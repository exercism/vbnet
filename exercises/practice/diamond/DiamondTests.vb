Imports Xunit

Public Class DiamondTest
    <Fact>
    Public Sub Degenerate_case_with_a_single_A_row()
        Dim expected = "A"
        Assert.Equal(expected, Rows("A"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Degenerate_case_with_no_row_containing_three_distinct_groups_of_spaces()
        Dim expected = Join(New String() { _
            " A ", _
            "B B", _
            " A " _
        }, vbCrLf)
        Assert.Equal(expected, Rows("B"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Smallest_non_degenerate_case_with_odd_diamond_side_length()
        Dim expected = Join(New String() { _
            "  A  ", _
            " B B ", _
            "C   C", _
            " B B ", _
            "  A  " _
        }, vbCrLf)
        Assert.Equal(expected, Rows("C"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Smallest_non_degenerate_case_with_even_diamond_side_length()
        Dim expected = Join(New String() { _
            "   A   ", _
            "  B B  ", _
            " C   C ", _
            "D     D", _
            " C   C ", _
            "  B B  ", _
            "   A   " _
        }, vbCrLf)
        Assert.Equal(expected, Rows("D"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Largest_possible_diamond()
        Dim expected = Join(New String() { _
        "                         A                         ", _
        "                        B B                        ", _
        "                       C   C                       ", _
        "                      D     D                      ", _
        "                     E       E                     ", _
        "                    F         F                    ", _
        "                   G           G                   ", _
        "                  H             H                  ", _
        "                 I               I                 ", _
        "                J                 J                ", _
        "               K                   K               ", _
        "              L                     L              ", _
        "             M                       M             ", _
        "            N                         N            ", _
        "           O                           O           ", _
        "          P                             P          ", _
        "         Q                               Q         ", _
        "        R                                 R        ", _
        "       S                                   S       ", _
        "      T                                     T      ", _
        "     U                                       U     ", _
        "    V                                         V    ", _
        "   W                                           W   ", _
        "  X                                             X  ", _
        " Y                                               Y ", _
        "Z                                                 Z", _
        " Y                                               Y ", _
        "  X                                             X  ", _
        "   W                                           W   ", _
        "    V                                         V    ", _
        "     U                                       U     ", _
        "      T                                     T      ", _
        "       S                                   S       ", _
        "        R                                 R        ", _
        "         Q                               Q         ", _
        "          P                             P          ", _
        "           O                           O           ", _
        "            N                         N            ", _
        "             M                       M             ", _
        "              L                     L              ", _
        "               K                   K               ", _
        "                J                 J                ", _
        "                 I               I                 ", _
        "                  H             H                  ", _
        "                   G           G                   ", _
        "                    F         F                    ", _
        "                     E       E                     ", _
        "                      D     D                      ", _
        "                       C   C                       ", _
        "                        B B                        ", _
        "                         A                         " _
        }, vbCrLf)
        Assert.Equal(expected, Rows("Z"))
    End Sub
End Class
