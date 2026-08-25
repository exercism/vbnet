Public Enum State
    Win
    Draw
    Ongoing
End Enum

Public Module StateOfTicTacToe
    Public Function Gamestate(ByVal board As String()) As State
        Dim xCount = CountMoves(board, "X"c)
        Dim oCount = CountMoves(board, "O"c)

        If oCount > xCount Then
            Throw New ArgumentException("Wrong turn order: O started", NameOf(board))
        End If

        If xCount > oCount + 1 Then
            Throw New ArgumentException("Wrong turn order: X went twice", NameOf(board))
        End If

        Dim xWon = HasWon(board, "X"c)
        Dim oWon = HasWon(board, "O"c)

        If (xWon AndAlso xCount <> oCount + 1) OrElse
            (oWon AndAlso xCount <> oCount) Then
            Throw New ArgumentException(
                "Impossible board: game should have ended after the game was won",
                NameOf(board))
        End If

        If xWon OrElse oWon Then
            Return State.Win
        End If

        Return If(xCount + oCount = 9, State.Draw, State.Ongoing)
    End Function

    Private Function CountMoves(ByVal board As String(), ByVal player As Char) As Integer
        Return board.Sum(Function(row) row.Count(Function(cell) cell = player))
    End Function

    Private Function HasWon(ByVal board As String(), ByVal player As Char) As Boolean
        Dim winningRow = New String(player, 3)
        Dim hasWinningRow = board.Any(Function(row) row = winningRow)
        Dim hasWinningColumn = Enumerable.Range(0, 3).
            Any(Function(column) board.All(Function(row) row(column) = player))
        Dim hasFallingDiagonal = Enumerable.Range(0, 3).
            All(Function(index) board(index)(index) = player)
        Dim hasRisingDiagonal = Enumerable.Range(0, 3).
            All(Function(index) board(index)(2 - index) = player)

        Return hasWinningRow OrElse
            hasWinningColumn OrElse
            hasFallingDiagonal OrElse
            hasRisingDiagonal
    End Function
End Module
