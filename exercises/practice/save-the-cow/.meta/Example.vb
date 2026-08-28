Imports System.Collections.Immutable
Imports System.Reactive
Imports System.Reactive.Subjects

Public Class GameState
    Public ReadOnly Property MaskedWord As String
    Public ReadOnly Property GuessedChars As ImmutableHashSet(Of Char)
    Public ReadOnly Property RemainingGuesses As Integer

    Public Sub New(ByVal maskedWord As String, ByVal guessedChars As ImmutableHashSet(Of Char), ByVal remainingGuesses As Integer)
        Me.MaskedWord = maskedWord
        Me.GuessedChars = guessedChars
        Me.RemainingGuesses = remainingGuesses
    End Sub
End Class

Public Class TooManyGuessesException
    Inherits Exception
End Class

Public Class SaveTheCow
    Private Const HidingChar = "_"c
    Private Const MaxGuessCount = 9

    Public ReadOnly Property StateObservable As IObservable(Of GameState)
    Public ReadOnly Property GuessObserver As IObserver(Of Char)

    Public Sub New(ByVal word As String)
        Dim initialGuesses = ImmutableHashSet(Of Char).Empty
        Dim stateSubject = New BehaviorSubject(Of GameState)(
            New GameState(MaskWord(word, initialGuesses), initialGuesses, MaxGuessCount))
        Dim gameOver = False

        StateObservable = stateSubject
        GuessObserver = Observer.Create(Of Char)(
            Sub(guess)
                If gameOver Then
                    Throw New InvalidOperationException("Cannot guess after the game is over.")
                End If

                gameOver = ApplyGuess(word, guess, stateSubject)
            End Sub)
    End Sub

    Private Shared Function ApplyGuess(ByVal word As String, ByVal guess As Char, ByVal state As BehaviorSubject(Of GameState)) As Boolean
        Dim current = state.Value
        Dim isHit = Not current.GuessedChars.Contains(guess) AndAlso word.Contains(guess)
        Dim guesses = current.GuessedChars.Add(guess)
        Dim maskedWord = MaskWord(word, guesses)

        If maskedWord = word Then
            state.OnNext(New GameState(maskedWord, guesses, current.RemainingGuesses))
            state.OnCompleted()
            Return True
        End If

        If Not isHit AndAlso current.RemainingGuesses < 1 Then
            state.OnError(New TooManyGuessesException())
            Return True
        End If

        Dim remainingGuesses = If(isHit, current.RemainingGuesses, current.RemainingGuesses - 1)
        state.OnNext(New GameState(maskedWord, guesses, remainingGuesses))
        Return False
    End Function

    Private Shared Function MaskWord(ByVal word As String, ByVal guesses As ImmutableHashSet(Of Char)) As String
        Return String.Concat(word.Select(Function(letter) If(guesses.Contains(letter), letter, HidingChar)))
    End Function
End Class
