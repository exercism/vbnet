Imports System
Imports Xunit

Public Class MinesweeperTests
    <Fact>
    Public Sub No_rows()
        Dim minefield = Array.Empty(Of String)()
        Dim expected = Array.Empty(Of String)()
        Assert.Equal(expected, Minesweeper.Annotate(minefield))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub No_columns()
        Dim minefield = {""}
        Dim expected = {""}
        Assert.Equal(expected, Minesweeper.Annotate(minefield))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub No_mines()
        Dim minefield = {"   ", "   ", "   "}
        Dim expected = {"   ", "   ", "   "}
        Assert.Equal(expected, Minesweeper.Annotate(minefield))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Minefield_with_only_mines()
        Dim minefield = {"***", "***", "***"}
        Dim expected = {"***", "***", "***"}
        Assert.Equal(expected, Minesweeper.Annotate(minefield))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Mine_surrounded_by_spaces()
        Dim minefield = {"   ", " * ", "   "}
        Dim expected = {"111", "1*1", "111"}
        Assert.Equal(expected, Minesweeper.Annotate(minefield))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Space_surrounded_by_mines()
        Dim minefield = {"***", "* *", "***"}
        Dim expected = {"***", "*8*", "***"}
        Assert.Equal(expected, Minesweeper.Annotate(minefield))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Horizontal_line()
        Dim minefield = {" * * "}
        Dim expected = {"1*2*1"}
        Assert.Equal(expected, Minesweeper.Annotate(minefield))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Horizontal_line_mines_at_edges()
        Dim minefield = {"*   *"}
        Dim expected = {"*1 1*"}
        Assert.Equal(expected, Minesweeper.Annotate(minefield))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Vertical_line()
        Dim minefield = {" ", "*", " ", "*", " "}
        Dim expected = {"1", "*", "2", "*", "1"}
        Assert.Equal(expected, Minesweeper.Annotate(minefield))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Vertical_line_mines_at_edges()
        Dim minefield = {"*", " ", " ", " ", "*"}
        Dim expected = {"*", "1", " ", "1", "*"}
        Assert.Equal(expected, Minesweeper.Annotate(minefield))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cross()
        Dim minefield = {"  *  ", "  *  ", "*****", "  *  ", "  *  "}
        Dim expected = {" 2*2 ", "25*52", "*****", "25*52", " 2*2 "}
        Assert.Equal(expected, Minesweeper.Annotate(minefield))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Large_minefield()
        Dim minefield = {" *  * ", "  *   ", "    * ", "   * *", " *  * ", "      "}
        Dim expected = {"1*22*1", "12*322", " 123*2", "112*4*", "1*22*2", "111111"}
        Assert.Equal(expected, Minesweeper.Annotate(minefield))
    End Sub
End Class
