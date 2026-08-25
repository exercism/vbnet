Public Class StateOfTicTacToeTests
    <Fact>
    Public Sub Finished_game_where_x_won_via_left_column_victory()
        Dim board = {
            "XOO",
            "X  ",
            "X  "
        }
        Assert.Equal(State.Win, StateOfTicTacToe.Gamestate(board))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Finished_game_where_x_won_via_middle_column_victory()
        Dim board = {
            "OXO",
            " X ",
            " X "
        }
        Assert.Equal(State.Win, StateOfTicTacToe.Gamestate(board))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Finished_game_where_x_won_via_right_column_victory()
        Dim board = {
            "OOX",
            "  X",
            "  X"
        }
        Assert.Equal(State.Win, StateOfTicTacToe.Gamestate(board))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Finished_game_where_o_won_via_left_column_victory()
        Dim board = {
            "OXX",
            "OX ",
            "O  "
        }
        Assert.Equal(State.Win, StateOfTicTacToe.Gamestate(board))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Finished_game_where_o_won_via_middle_column_victory()
        Dim board = {
            "XOX",
            " OX",
            " O "
        }
        Assert.Equal(State.Win, StateOfTicTacToe.Gamestate(board))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Finished_game_where_o_won_via_right_column_victory()
        Dim board = {
            "XXO",
            " XO",
            "  O"
        }
        Assert.Equal(State.Win, StateOfTicTacToe.Gamestate(board))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Finished_game_where_x_won_via_top_row_victory()
        Dim board = {
            "XXX",
            "XOO",
            "O  "
        }
        Assert.Equal(State.Win, StateOfTicTacToe.Gamestate(board))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Finished_game_where_x_won_via_middle_row_victory()
        Dim board = {
            "O  ",
            "XXX",
            " O "
        }
        Assert.Equal(State.Win, StateOfTicTacToe.Gamestate(board))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Finished_game_where_x_won_via_bottom_row_victory()
        Dim board = {
            " OO",
            "O X",
            "XXX"
        }
        Assert.Equal(State.Win, StateOfTicTacToe.Gamestate(board))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Finished_game_where_o_won_via_top_row_victory()
        Dim board = {
            "OOO",
            "XXO",
            "XX "
        }
        Assert.Equal(State.Win, StateOfTicTacToe.Gamestate(board))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Finished_game_where_o_won_via_middle_row_victory()
        Dim board = {
            "XX ",
            "OOO",
            "X  "
        }
        Assert.Equal(State.Win, StateOfTicTacToe.Gamestate(board))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Finished_game_where_o_won_via_bottom_row_victory()
        Dim board = {
            "XOX",
            " XX",
            "OOO"
        }
        Assert.Equal(State.Win, StateOfTicTacToe.Gamestate(board))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Finished_game_where_x_won_via_falling_diagonal_victory()
        Dim board = {
            "XOO",
            " X ",
            "  X"
        }
        Assert.Equal(State.Win, StateOfTicTacToe.Gamestate(board))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Finished_game_where_x_won_via_rising_diagonal_victory()
        Dim board = {
            "O X",
            "OX ",
            "X  "
        }
        Assert.Equal(State.Win, StateOfTicTacToe.Gamestate(board))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Finished_game_where_o_won_via_falling_diagonal_victory()
        Dim board = {
            "OXX",
            "OOX",
            "X O"
        }
        Assert.Equal(State.Win, StateOfTicTacToe.Gamestate(board))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Finished_game_where_o_won_via_rising_diagonal_victory()
        Dim board = {
            "  O",
            " OX",
            "OXX"
        }
        Assert.Equal(State.Win, StateOfTicTacToe.Gamestate(board))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Finished_game_where_x_won_via_a_row_and_a_column_victory()
        Dim board = {
            "XXX",
            "XOO",
            "XOO"
        }
        Assert.Equal(State.Win, StateOfTicTacToe.Gamestate(board))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Finished_game_where_x_won_via_two_diagonal_victories()
        Dim board = {
            "XOX",
            "OXO",
            "XOX"
        }
        Assert.Equal(State.Win, StateOfTicTacToe.Gamestate(board))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Draw()
        Dim board = {
            "XOX",
            "XXO",
            "OXO"
        }
        Assert.Equal(State.Draw, StateOfTicTacToe.Gamestate(board))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Another_draw()
        Dim board = {
            "XXO",
            "OXX",
            "XOO"
        }
        Assert.Equal(State.Draw, StateOfTicTacToe.Gamestate(board))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ongoing_game_one_move_in()
        Dim board = {
            "   ",
            "X  ",
            "   "
        }
        Assert.Equal(State.Ongoing, StateOfTicTacToe.Gamestate(board))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ongoing_game_two_moves_in()
        Dim board = {
            "O  ",
            " X ",
            "   "
        }
        Assert.Equal(State.Ongoing, StateOfTicTacToe.Gamestate(board))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ongoing_game_five_moves_in()
        Dim board = {
            "X  ",
            " XO",
            "OX "
        }
        Assert.Equal(State.Ongoing, StateOfTicTacToe.Gamestate(board))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_board_x_went_twice()
        Dim board = {
            "XX ",
            "   ",
            "   "
        }
        Assert.Throws(Of ArgumentException)(Function() StateOfTicTacToe.Gamestate(board))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_board_o_started()
        Dim board = {
            "OOX",
            "   ",
            "   "
        }
        Assert.Throws(Of ArgumentException)(Function() StateOfTicTacToe.Gamestate(board))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_board_x_won_and_o_kept_playing()
        Dim board = {
            "XXX",
            "OOO",
            "   "
        }
        Assert.Throws(Of ArgumentException)(Function() StateOfTicTacToe.Gamestate(board))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_board_players_kept_playing_after_a_win()
        Dim board = {
            "XXX",
            "OOO",
            "XOX"
        }
        Assert.Throws(Of ArgumentException)(Function() StateOfTicTacToe.Gamestate(board))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_board_o_kept_playing_after_x_wins()
        Dim board = {
            "OO ",
            "XXX",
            " O "
        }
        Assert.Throws(Of ArgumentException)(Function() StateOfTicTacToe.Gamestate(board))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_board_x_kept_playing_after_o_wins()
        Dim board = {
            "XX ",
            "OOO",
            " XX"
        }
        Assert.Throws(Of ArgumentException)(Function() StateOfTicTacToe.Gamestate(board))
    End Sub
End Class
