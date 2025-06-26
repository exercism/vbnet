Imports System
Imports Xunit

Public Class FlowerFieldTests
    <Fact>
    Public Sub No_rows()
        Dim garden = Array.Empty(Of String)()
        Dim expected = Array.Empty(Of String)()
        Dim result as IEnumerable(Of String) = FlowerField.Annotate(garden)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub No_columns()
        Dim garden = {""}
        Dim expected = {""}
        Dim result as IEnumerable(Of String) = FlowerField.Annotate(garden)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub No_flowers()
        Dim garden = {"   ", "   ", "   "}
        Dim expected = {"   ", "   ", "   "}
        Dim result as IEnumerable(Of String) = FlowerField.Annotate(garden)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Garden_full_of_flowers()
        Dim garden = {"***", "***", "***"}
        Dim expected = {"***", "***", "***"}
        Dim result as IEnumerable(Of String) = FlowerField.Annotate(garden)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Flower_surrounded_by_spaces()
        Dim garden = {"   ", " * ", "   "}
        Dim expected = {"111", "1*1", "111"}
        Dim result as IEnumerable(Of String) = FlowerField.Annotate(garden)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Space_surrounded_by_flowers()
        Dim garden = {"***", "* *", "***"}
        Dim expected = {"***", "*8*", "***"}
        Dim result as IEnumerable(Of String) = FlowerField.Annotate(garden)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Horizontal_line()
        Dim garden = {" * * "}
        Dim expected = {"1*2*1"}
        Dim result as IEnumerable(Of String) = FlowerField.Annotate(garden)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Horizontal_line_flowers_at_edges()
        Dim garden = {"*   *"}
        Dim expected = {"*1 1*"}
        Dim result as IEnumerable(Of String) = FlowerField.Annotate(garden)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Vertical_line()
        Dim garden = {" ", "*", " ", "*", " "}
        Dim expected = {"1", "*", "2", "*", "1"}
        Dim result as IEnumerable(Of String) = FlowerField.Annotate(garden)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Vertical_line_flowers_at_edges()
        Dim garden = {"*", " ", " ", " ", "*"}
        Dim expected = {"*", "1", " ", "1", "*"}
        Dim result as IEnumerable(Of String) = FlowerField.Annotate(garden)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cross()
        Dim garden = {"  *  ", "  *  ", "*****", "  *  ", "  *  "}
        Dim expected = {" 2*2 ", "25*52", "*****", "25*52", " 2*2 "}
        Dim result as IEnumerable(Of String) = FlowerField.Annotate(garden)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Large_garden()
        Dim garden = {" *  * ", "  *   ", "    * ", "   * *", " *  * ", "      "}
        Dim expected = {"1*22*1", "12*322", " 123*2", "112*4*", "1*22*2", "111111"}
        Dim result as IEnumerable(Of String) = FlowerField.Annotate(garden)
        Assert.Equal(expected, result)
    End Sub
End Class
