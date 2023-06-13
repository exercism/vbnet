Imports System
Imports System.Collections.Generic
Imports System.Collections.Immutable
Imports System.Linq
Imports System.Reactive
Imports System.Reactive.Subjects

Public Class HangmanState
    Public ReadOnly Property MaskedWord() As String
    Public ReadOnly Property GuessedChars() As ImmutableHashSet<char>
    Public ReadOnly Property RemainingGuesses() As Integer

    Public Sub New(ByVal maskedWord As String, ByVal guessedChars As ImmutableHashSet<char>, ByVal remainingGuesses As Integer)
        MaskedWord = maskedWord
        GuessedChars = guessedChars
        RemainingGuesses = remainingGuesses
    End Sub
End Class

Public Class TooManyGuessesException
    Inherits Exception
End Class

Public Class Hangman
    Public ReadOnly Property StateObservable() As IObservable<HangmanState>
    Public ReadOnly Property GuessObserver() As IObserver<char>
    Public Sub New(ByVal word As String)
        Throw New NotImplementedException("You need to implement Me function.")
    End Sub
End Class