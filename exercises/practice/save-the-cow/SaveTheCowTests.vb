Imports System.Reactive.Linq

Public Class SaveTheCowTests
    <Fact>
    Public Sub Initially_9_failures_are_allowed_and_no_letters_are_guessed()
        Dim word = "loot"
        Dim guesses = Array.Empty(Of Char)()
        Dim result = Play(word, guesses)
        Assert.Equal(GameStatus.Ongoing, result.Status)
        Assert.Equal("____", result.State.MaskedWord)
        Assert.Equal(9, result.State.RemainingGuesses)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub After_10_failures_the_game_is_over()
        Dim word = "loot"
        Dim guesses = {
            "a"c,
            "b"c,
            "c"c,
            "d"c,
            "e"c,
            "f"c,
            "g"c,
            "h"c,
            "i"c,
            "j"c
        }
        Dim result = Play(word, guesses)
        Assert.Equal(GameStatus.Lose, result.Status)
        Assert.Equal("____", result.State.MaskedWord)
        Assert.Equal(0, result.State.RemainingGuesses)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Losing_with_several_correct_guesses()
        Dim word = "loot"
        Dim guesses = {
            "t"c,
            "o"c,
            "a"c,
            "b"c,
            "c"c,
            "d"c,
            "e"c,
            "f"c,
            "g"c,
            "h"c,
            "i"c,
            "j"c
        }
        Dim result = Play(word, guesses)
        Assert.Equal(GameStatus.Lose, result.Status)
        Assert.Equal("_oot", result.State.MaskedWord)
        Assert.Equal(0, result.State.RemainingGuesses)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Feeding_a_correct_letter_removes_underscores()
        Dim word = "loot"
        Dim guesses = {"t"c}
        Dim result = Play(word, guesses)
        Assert.Equal(GameStatus.Ongoing, result.Status)
        Assert.Equal("___t", result.State.MaskedWord)
        Assert.Equal(9, result.State.RemainingGuesses)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Feeding_a_correct_letter_twice_counts_as_a_failure()
        Dim word = "loot"
        Dim guesses = {"t"c, "t"c}
        Dim result = Play(word, guesses)
        Assert.Equal(GameStatus.Ongoing, result.Status)
        Assert.Equal("___t", result.State.MaskedWord)
        Assert.Equal(8, result.State.RemainingGuesses)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Guessing_a_repeated_letter_reveals_all_instances()
        Dim word = "loot"
        Dim guesses = {"t"c, "t"c, "o"c}
        Dim result = Play(word, guesses)
        Assert.Equal(GameStatus.Ongoing, result.Status)
        Assert.Equal("_oot", result.State.MaskedWord)
        Assert.Equal(8, result.State.RemainingGuesses)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Getting_all_the_letters_right_makes_for_a_win()
        Dim word = "loot"
        Dim guesses = {"t"c, "t"c, "o"c, "l"c}
        Dim result = Play(word, guesses)
        Assert.Equal(GameStatus.Win, result.Status)
        Assert.Equal("loot", result.State.MaskedWord)
        Assert.Equal(8, result.State.RemainingGuesses)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Winning_on_the_last_guess_is_still_a_win()
        Dim word = "loot"
        Dim guesses = {
            "a"c,
            "b"c,
            "c"c,
            "d"c,
            "e"c,
            "f"c,
            "g"c,
            "h"c,
            "i"c,
            "t"c,
            "o"c,
            "l"c
        }
        Dim result = Play(word, guesses)
        Assert.Equal(GameStatus.Win, result.Status)
        Assert.Equal("loot", result.State.MaskedWord)
        Assert.Equal(0, result.State.RemainingGuesses)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Guessing_after_a_lose_is_error()
        Dim word = "loot"
        Dim guesses = {
            "a"c,
            "b"c,
            "c"c,
            "d"c,
            "e"c,
            "f"c,
            "g"c,
            "h"c,
            "i"c,
            "j"c,
            "k"c
        }
        Assert.Throws(Of InvalidOperationException)(Sub() Play(word, guesses))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Guessing_after_a_win_is_error()
        Dim word = "loot"
        Dim guesses = {"t"c, "o"c, "l"c, "l"c}
        Assert.Throws(Of InvalidOperationException)(Sub() Play(word, guesses))
    End Sub

    Private Shared Function Play(
        ByVal word As String,
        ByVal guesses As IEnumerable(Of Char)) As (State As GameState, Status As GameStatus)
        Dim game = New SaveTheCow(word)
        Dim state As GameState = Nothing
        Dim status = GameStatus.Ongoing

        game.StateObservable.Subscribe(
            Sub(value) state = value,
            Sub(exception)
                Assert.IsType(Of TooManyGuessesException)(exception)
                status = GameStatus.Lose
            End Sub,
            Sub() status = GameStatus.Win)

        For Each guess In guesses
            game.GuessObserver.OnNext(guess)
        Next

        Return (state, status)
    End Function

    Private Enum GameStatus
        Ongoing
        Win
        Lose
    End Enum
End Class
