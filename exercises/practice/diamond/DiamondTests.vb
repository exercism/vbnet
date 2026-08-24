Public Class DiamondTests
    <Fact>
    Public Sub Degenerate_case_with_a_single_a_row()
        Dim expected = "A"
        Assert.Equal(expected, Diamond.Rows("A"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Degenerate_case_with_no_row_containing_3_distinct_groups_of_spaces()
        Dim expected = String.Join(vbCrLf, {
            " A ",
            "B B",
            " A "
        })
        Assert.Equal(expected, Diamond.Rows("B"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Smallest_non_degenerate_case_with_odd_diamond_side_length()
        Dim expected = String.Join(vbCrLf, {
            "  A  ",
            " B B ",
            "C   C",
            " B B ",
            "  A  "
        })
        Assert.Equal(expected, Diamond.Rows("C"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Smallest_non_degenerate_case_with_even_diamond_side_length()
        Dim expected = String.Join(vbCrLf, {
            "   A   ",
            "  B B  ",
            " C   C ",
            "D     D",
            " C   C ",
            "  B B  ",
            "   A   "
        })
        Assert.Equal(expected, Diamond.Rows("D"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Largest_possible_diamond()
        Dim expected = String.Join(vbCrLf, {
            "                         A                         ",
            "                        B B                        ",
            "                       C   C                       ",
            "                      D     D                      ",
            "                     E       E                     ",
            "                    F         F                    ",
            "                   G           G                   ",
            "                  H             H                  ",
            "                 I               I                 ",
            "                J                 J                ",
            "               K                   K               ",
            "              L                     L              ",
            "             M                       M             ",
            "            N                         N            ",
            "           O                           O           ",
            "          P                             P          ",
            "         Q                               Q         ",
            "        R                                 R        ",
            "       S                                   S       ",
            "      T                                     T      ",
            "     U                                       U     ",
            "    V                                         V    ",
            "   W                                           W   ",
            "  X                                             X  ",
            " Y                                               Y ",
            "Z                                                 Z",
            " Y                                               Y ",
            "  X                                             X  ",
            "   W                                           W   ",
            "    V                                         V    ",
            "     U                                       U     ",
            "      T                                     T      ",
            "       S                                   S       ",
            "        R                                 R        ",
            "         Q                               Q         ",
            "          P                             P          ",
            "           O                           O           ",
            "            N                         N            ",
            "             M                       M             ",
            "              L                     L              ",
            "               K                   K               ",
            "                J                 J                ",
            "                 I               I                 ",
            "                  H             H                  ",
            "                   G           G                   ",
            "                    F         F                    ",
            "                     E       E                     ",
            "                      D     D                      ",
            "                       C   C                       ",
            "                        B B                        ",
            "                         A                         "
        })
        Assert.Equal(expected, Diamond.Rows("Z"))
    End Sub
End Class
