Imports System
Imports System.Collections.Generic
Imports System.Collections.Immutable
Imports System.Linq
Imports System.Reactive
Imports System.Reactive.Subjects

Public Class HangmanState
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

Public Class Hangman
    Public ReadOnly Property StateObservable As IObservable(Of HangmanState)
    Public ReadOnly Property GuessObserver As IObserver(Of Char)
    Private Const HidingChar As Char = "_"c
    Private Const MaxGuessCount As Integer = 9

    Public Sub New(ByVal word As String)
        Dim emptySetOfChars As HashSet(Of Char) = New HashSet(Of Char)()
        Dim stateSubject = New BehaviorSubject(Of HangmanState)(New HangmanState(MaskedWord(word, emptySetOfChars), emptySetOfChars.ToImmutableHashSet(), MaxGuessCount))

        StateObservable = stateSubject

        GuessObserver = Observer.Create(Of Char)(Sub(x)
                                                     Dim guessedChars As HashSet(Of Char) = New HashSet(Of Char)(stateSubject.Value.GuessedChars)
                                                     Dim isHit = Not guessedChars.Contains(x) AndAlso word.Contains(x)
                                                     guessedChars.Add(x)
                                                     Dim maskedWord = Me.MaskedWord(word, guessedChars)
                                                     If Equals(maskedWord, word) Then
                                                         stateSubject.OnCompleted()
                                                     ElseIf stateSubject.Value.RemainingGuesses < 1 Then
                                                         stateSubject.OnError(New TooManyGuessesException())
                                                     Else
                                                         stateSubject.OnNext(New HangmanState(maskedWord, guessedChars.ToImmutableHashSet(), If(isHit, stateSubject.Value.RemainingGuesses, stateSubject.Value.RemainingGuesses - 1)))
                                                     End If
                                                 End Sub)
    End Sub

    Private Function MaskedWord(ByVal word As String, ByVal guessedChars As HashSet(Of Char)) As String
        Return String.Concat(word.Select(Function(y) If(guessedChars.Contains(y), y, HidingChar)))
    End Function
End Class
