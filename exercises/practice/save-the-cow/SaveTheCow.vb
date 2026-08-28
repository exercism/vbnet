Imports System.Collections.Immutable

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
    Public ReadOnly Property StateObservable As IObservable(Of GameState)
    Public ReadOnly Property GuessObserver As IObserver(Of Char)

    Public Sub New(ByVal word As String)
        Throw New NotImplementedException("You need to implement this method.")
    End Sub
End Class
