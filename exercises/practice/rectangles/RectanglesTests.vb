Imports System
Imports Xunit

Public Class RectanglesTests
    <Fact>
    Public Sub No_rows()
        Dim strings = Array.Empty(Of String)()
        Assert.Equal(0, Count(strings))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub No_columns()
        Dim strings = {""}
        Assert.Equal(0, Count(strings))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub No_rectangles()
        Dim strings = {" "}
        Assert.Equal(0, Count(strings))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_rectangle()
        Dim strings = {"+-+", "| |", "+-+"}
        Assert.Equal(1, Count(strings))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_rectangles_without_shared_parts()
        Dim strings = {"  +-+", "  | |", "+-+-+", "| |  ", "+-+  "}
        Assert.Equal(2, Count(strings))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Five_rectangles_with_shared_parts()
        Dim strings = {"  +-+", "  | |", "+-+-+", "| | |", "+-+-+"}
        Assert.Equal(5, Count(strings))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rectangle_of_height_1_is_counted()
        Dim strings = {"+--+", "+--+"}
        Assert.Equal(1, Count(strings))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rectangle_of_width_1_is_counted()
        Dim strings = {"++", "||", "++"}
        Assert.Equal(1, Count(strings))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number_1x1_square_is_counted()
        Dim strings = {"++", "++"}
        Assert.Equal(1, Count(strings))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Only_complete_rectangles_are_counted()
        Dim strings = {"  +-+", "    |", "+-+-+", "| | -", "+-+-+"}
        Assert.Equal(1, Count(strings))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rectangles_can_be_of_different_sizes()
        Dim strings = {"+------+----+", "|      |    |", "+---+--+    |", "|   |       |", "+---+-------+"}
        Assert.Equal(3, Count(strings))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Corner_is_required_for_a_rectangle_to_be_complete()
        Dim strings = {"+------+----+", "|      |    |", "+------+    |", "|   |       |", "+---+-------+"}
        Assert.Equal(2, Count(strings))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Large_input_with_many_rectangles()
        Dim strings = {"+---+--+----+", "|   +--+----+", "+---+--+    |", "|   +--+----+", "+---+--+--+-+", "+---+--+--+-+", "+------+  | |", "          +-+"}
        Assert.Equal(60, Count(strings))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rectangles_must_have_four_sides()
        Dim strings = {"+-+ +-+", "| | | |", "+-+-+-+", "  | |  ", "+-+-+-+", "| | | |", "+-+ +-+"}
        Assert.Equal(5, Count(strings))
    End Sub
End Class
