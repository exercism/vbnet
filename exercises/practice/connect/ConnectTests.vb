Imports Xunit

Public Class ConnectTests
    <Fact>
    Public Sub An_empty_board_has_no_winner()
        Dim board = {". . . . .", " . . . . .", "  . . . . .", "   . . . . .", "    . . . . ."}
        Dim sut = New Connect(board)
        Assert.Equal(ConnectWinner.None, sut.Result())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub X_can_win_on_a_1x1_board()
        Dim board = {"X"}
        Dim sut = New Connect(board)
        Assert.Equal(ConnectWinner.Black, sut.Result())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub O_can_win_on_a_1x1_board()
        Dim board = {"O"}
        Dim sut = New Connect(board)
        Assert.Equal(ConnectWinner.White, sut.Result())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Only_edges_does_not_make_a_winner()
        Dim board = {"O O O X", " X . . X", "  X . . X", "   X O O O"}
        Dim sut = New Connect(board)
        Assert.Equal(ConnectWinner.None, sut.Result())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Illegal_diagonal_does_not_make_a_winner()
        Dim board = {"X O . .", " O X X X", "  O X O .", "   . O X .", "    X X O O"}
        Dim sut = New Connect(board)
        Assert.Equal(ConnectWinner.None, sut.Result())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Nobody_wins_crossing_adjacent_angles()
        Dim board = {"X . . .", " . X O .", "  O . X O", "   . O . X", "    . . O ."}
        Dim sut = New Connect(board)
        Assert.Equal(ConnectWinner.None, sut.Result())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub X_wins_crossing_from_left_to_right()
        Dim board = {". O . .", " O X X X", "  O X O .", "   X X O X", "    . O X ."}
        Dim sut = New Connect(board)
        Assert.Equal(ConnectWinner.Black, sut.Result())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub O_wins_crossing_from_top_to_bottom()
        Dim board = {". O . .", " O X X X", "  O O O .", "   X X O X", "    . O X ."}
        Dim sut = New Connect(board)
        Assert.Equal(ConnectWinner.White, sut.Result())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub X_wins_using_a_convoluted_path()
        Dim board = {". X X . .", " X . X . X", "  . X . X .", "   . X X . .", "    O O O O O"}
        Dim sut = New Connect(board)
        Assert.Equal(ConnectWinner.Black, sut.Result())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub X_wins_using_a_spiral_path()
        Dim board = {"O X X X X X X X X", " O X O O O O O O O", "  O X O X X X X X O", "   O X O X O O O X O", "    O X O X X X O X O", "     O X O O O X O X O", "      O X X X X X O X O", "       O O O O O O O X O", "        X X X X X X X X O"}
        Dim sut = New Connect(board)
        Assert.Equal(ConnectWinner.Black, sut.Result())
    End Sub
End Class
