Imports System
Imports System.Collections.Generic
Imports Xunit

Public Class GoCountingTests
    <Fact>
    Public Sub Black_corner_territory_on_5x5_board()
        Dim coordinate = (0, 1)
        Dim board = "  B  " & vbLf & " B B " & vbLf & "B W B" & vbLf & " W W " & vbLf & "  W  "
        Dim sut = New GoCounting(board)
        Dim actual = sut.Territory(coordinate)
        Dim expected = (Owner.Black, New HashSet(Of (Integer, Integer)) From {
            (0, 0),
            (0, 1),
            (1, 0)
        })
        Assert.Equal(expected.Item1, actual.Item1)
        Assert.Equal(expected.Item2, actual.Item2)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub White_center_territory_on_5x5_board()
        Dim coordinate = (2, 3)
        Dim board = "  B  " & vbLf & " B B " & vbLf & "B W B" & vbLf & " W W " & vbLf & "  W  "
        Dim sut = New GoCounting(board)
        Dim actual = sut.Territory(coordinate)
        Dim expected = (Owner.White, New HashSet(Of (Integer, Integer)) From {
            (2, 3)
        })
        Assert.Equal(expected.Item1, actual.Item1)
        Assert.Equal(expected.Item2, actual.Item2)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Open_corner_territory_on_5x5_board()
        Dim coordinate = (1, 4)
        Dim board = "  B  " & vbLf & " B B " & vbLf & "B W B" & vbLf & " W W " & vbLf & "  W  "
        Dim sut = New GoCounting(board)
        Dim actual = sut.Territory(coordinate)
        Dim expected = (Owner.None, New HashSet(Of (Integer, Integer)) From {
            (0, 3),
            (0, 4),
            (1, 4)
        })
        Assert.Equal(expected.Item1, actual.Item1)
        Assert.Equal(expected.Item2, actual.Item2)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_stone_and_not_a_territory_on_5x5_board()
        Dim coordinate = (1, 1)
        Dim board = "  B  " & vbLf & " B B " & vbLf & "B W B" & vbLf & " W W " & vbLf & "  W  "
        Dim sut = New GoCounting(board)
        Dim actual = sut.Territory(coordinate)
        Dim expected = (Owner.None, New HashSet(Of (Integer, Integer))())
        Assert.Equal(expected.Item1, actual.Item1)
        Assert.Equal(expected.Item2, actual.Item2)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_because_x_is_too_low_for_5x5_board()
        Dim coordinate = (-1, 1)
        Dim board = "  B  " & vbLf & " B B " & vbLf & "B W B" & vbLf & " W W " & vbLf & "  W  "
        Dim sut = New GoCounting(board)
        Assert.Throws(Of ArgumentException)(Function() sut.Territory(coordinate))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_because_x_is_too_high_for_5x5_board()
        Dim coordinate = (5, 1)
        Dim board = "  B  " & vbLf & " B B " & vbLf & "B W B" & vbLf & " W W " & vbLf & "  W  "
        Dim sut = New GoCounting(board)
        Assert.Throws(Of ArgumentException)(Function() sut.Territory(coordinate))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_because_y_is_too_low_for_5x5_board()
        Dim coordinate = (1, -1)
        Dim board = "  B  " & vbLf & " B B " & vbLf & "B W B" & vbLf & " W W " & vbLf & "  W  "
        Dim sut = New GoCounting(board)
        Assert.Throws(Of ArgumentException)(Function() sut.Territory(coordinate))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_because_y_is_too_high_for_5x5_board()
        Dim coordinate = (1, 5)
        Dim board = "  B  " & vbLf & " B B " & vbLf & "B W B" & vbLf & " W W " & vbLf & "  W  "
        Dim sut = New GoCounting(board)
        Assert.Throws(Of ArgumentException)(Function() sut.Territory(coordinate))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_territory_is_the_whole_board()
        Dim board = " "
        Dim sut = New GoCounting(board)
        Dim actual = sut.Territories()
        Dim expected = New Dictionary(Of Owner, HashSet(Of (Integer, Integer))) From {
    {Owner.Black, New HashSet(Of (Integer, Integer))()},
    {Owner.White, New HashSet(Of (Integer, Integer))()},
    {Owner.None, New HashSet(Of (Integer, Integer)) From {
        (0, 0)
    }}
}
        Assert.Equal(expected(Owner.Black), actual(Owner.Black))
        Assert.Equal(expected(Owner.White), actual(Owner.White))
        Assert.Equal(expected(Owner.None), actual(Owner.None))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_territory_rectangular_board()
        Dim board = " BW " & vbLf & " BW "
        Dim sut = New GoCounting(board)
        Dim actual = sut.Territories()
        Dim expected = New Dictionary(Of Owner, HashSet(Of (Integer, Integer))) From {
    {Owner.Black, New HashSet(Of (Integer, Integer)) From {
        (0, 0),
        (0, 1)
    }},
    {Owner.White, New HashSet(Of (Integer, Integer)) From {
        (3, 0),
        (3, 1)
    }},
    {Owner.None, New HashSet(Of (Integer, Integer))()}
}
        Assert.Equal(expected(Owner.Black), actual(Owner.Black))
        Assert.Equal(expected(Owner.White), actual(Owner.White))
        Assert.Equal(expected(Owner.None), actual(Owner.None))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_region_rectangular_board()
        Dim board = " B "
        Dim sut = New GoCounting(board)
        Dim actual = sut.Territories()
        Dim expected = New Dictionary(Of Owner, HashSet(Of (Integer, Integer))) From {
    {Owner.Black, New HashSet(Of (Integer, Integer)) From {
        (0, 0),
        (2, 0)
    }},
    {Owner.White, New HashSet(Of (Integer, Integer))()},
    {Owner.None, New HashSet(Of (Integer, Integer))()}
}
        Assert.Equal(expected(Owner.Black), actual(Owner.Black))
        Assert.Equal(expected(Owner.White), actual(Owner.White))
        Assert.Equal(expected(Owner.None), actual(Owner.None))
    End Sub
End Class
