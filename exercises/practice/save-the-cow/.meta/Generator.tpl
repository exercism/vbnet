{{ func char_literal
    ret (vb_string_literal $0) + "c"
end }}

{{ func char_array_literal
    literals = $0 | array.each @char_literal
    if (array.size literals) == 0
        ret "Array.Empty(Of Char)()"
    end

    if (array.size literals) <= 6
        ret "{" + (array.join literals ", ") + "}"
    end

    item_indent = indent ($1 + 1)
    separator = ",\n" + item_indent
    ret "{\n" + item_indent + (array.join literals separator) + "\n" + (indent $1) + "}"
end }}

Imports System.Reactive.Linq

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim word = {{ test.input.word | vb_string_literal }}
        Dim guesses = {{ test.input.guesses | char_array_literal 2 }}
        {{- if test.expected.error }}
        Assert.Throws(Of InvalidOperationException)(Sub() Play(word, guesses))
        {{- else }}
        Dim result = Play(word, guesses)
        Assert.Equal({{ test.expected.state | enum "GameStatus" }}, result.Status)
        Assert.Equal({{ test.expected.maskedWord | vb_string_literal }}, result.State.MaskedWord)
        Assert.Equal({{ test.expected.remainingFailures }}, result.State.RemainingGuesses)
        {{- end }}
    End Sub
    {{ end }}
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
