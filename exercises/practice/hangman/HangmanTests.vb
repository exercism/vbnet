Imports System
Imports Xunit
Imports Microsoft.Reactive.Testing
Imports System.Collections.Generic
Imports System.Collections.Immutable
Imports System.Reactive.Concurrency

Public Class HangmanTests
    Inherits ReactiveTest

    <Fact>
    Public Sub Initial_state_masks_the_word()
        Dim hangman = New Hangman("foo")
        Dim actual = ""
        hangman.StateObservable.Subscribe(Function(x) CSharpImpl.__Assign(actual, x.MaskedWord), Function(ex)
                                                                                                     Throw New Exception("Should not finish with too many tries")
                                                                                                 End Function, Function()
                                                                                                                   Throw New Exception("Should not win yet")
                                                                                                               End Function)
        Assert.Equal("___", actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Initial_state_has_9_remaining_guesses()
        Dim hangman = New Hangman("foo")
        Dim actual = 9
        hangman.StateObservable.Subscribe(Function(x) CSharpImpl.__Assign(actual, x.RemainingGuesses))
        Assert.Equal(9, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Initial_state_has_no_guessed_chars()
        Dim hangman = New Hangman("foo")
        Dim actual = New HashSet(Of Char) From {
            "x"c
        }.ToImmutableHashSet()
        hangman.StateObservable.Subscribe(Function(x) CSharpImpl.__Assign(actual, x.GuessedChars))
        Assert.Equal(New HashSet(Of Char)().ToImmutableHashSet(), actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Guess_changes_state()
        Dim hangman = New Hangman("foo")
        Dim actual As HangmanState = Nothing
        hangman.StateObservable.Subscribe(Function(x) CSharpImpl.__Assign(actual, x))
        Dim initial = actual
        hangman.GuessObserver.OnNext("x"c)
        Assert.NotEqual(initial, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Wrong_guess_decrements_remaining_guesses()
        Dim hangman = New Hangman("foo")
        Dim actual As HangmanState = Nothing
        hangman.StateObservable.Subscribe(Function(x) CSharpImpl.__Assign(actual, x))
        Dim initial = actual
        hangman.GuessObserver.OnNext("x"c)
        Assert.Equal(initial.RemainingGuesses - 1, actual.RemainingGuesses)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub After_10_incorrect_guesses_the_game_is_over()
        Dim scheduler = New TestScheduler()
                ''' Cannot convert LocalFunctionStatementSyntax, CONVERSION ERROR: Conversion for LocalFunctionStatement not implemented, please report this issue in 'IObservable<HangmanState> C...' at character 2409
'''    at ICSharpCode.CodeConverter.VB.MethodBodyVisitor.DefaultVisit(SyntaxNode node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.VisitLocalFunctionStatement(LocalFunctionStatementSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.Syntax.LocalFunctionStatementSyntax.Accept[TResult](CSharpSyntaxVisitor`1 visitor)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)
''' 
''' Input: 
'''         IObservable<HangmanState> Create()
        {
            var hangman = new Hangman("foo");
            for (var i = 1; i <= 10; i++)
            {
                scheduler.Schedule(TimeSpan.FromTicks(i * 100), () => hangman.GuessObserver.OnNext('x'));
            }

            return hangman.StateObservable;
        }

''' 
        Dim expected = {OnNext(Of HangmanState)(100, Function(hangmanState) hangmanState.RemainingGuesses = 9), OnNext(Of HangmanState)(200, Function(hangmanState) hangmanState.RemainingGuesses = 8), OnNext(Of HangmanState)(300, Function(hangmanState) hangmanState.RemainingGuesses = 7), OnNext(Of HangmanState)(400, Function(hangmanState) hangmanState.RemainingGuesses = 6), OnNext(Of HangmanState)(500, Function(hangmanState) hangmanState.RemainingGuesses = 5), OnNext(Of HangmanState)(600, Function(hangmanState) hangmanState.RemainingGuesses = 4), OnNext(Of HangmanState)(700, Function(hangmanState) hangmanState.RemainingGuesses = 3), OnNext(Of HangmanState)(800, Function(hangmanState) hangmanState.RemainingGuesses = 2), OnNext(Of HangmanState)(900, Function(hangmanState) hangmanState.RemainingGuesses = 1), OnNext(Of HangmanState)(1000, Function(hangmanState) hangmanState.RemainingGuesses = 0), OnError(Of HangmanState)(1100, Function(ex) TypeOf ex Is TooManyGuessesException)}
            Dim testableObserver As ITestableObserver(Of HangmanState) = scheduler.Start(AddressOf Create, 100, 100, 3000)
            ReactiveAssert.AreElementsEqual(expected, testableObserver.Messages)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Correctly_guessing_a_letter_unmasks_it()
        Dim scheduler = New TestScheduler()
                ''' Cannot convert LocalFunctionStatementSyntax, CONVERSION ERROR: Conversion for LocalFunctionStatement not implemented, please report this issue in 'IObservable<HangmanState> C...' at character 4207
'''    at ICSharpCode.CodeConverter.VB.MethodBodyVisitor.DefaultVisit(SyntaxNode node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.VisitLocalFunctionStatement(LocalFunctionStatementSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.Syntax.LocalFunctionStatementSyntax.Accept[TResult](CSharpSyntaxVisitor`1 visitor)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)
''' 
''' Input: 
'''         IObservable<HangmanState> Create()
        {
            var hangman = new Hangman("foobar");
            scheduler.Schedule(TimeSpan.FromTicks(100), () => hangman.GuessObserver.OnNext('b'));
            scheduler.Schedule(TimeSpan.FromTicks(200), () => hangman.GuessObserver.OnNext('o'));
            return hangman.StateObservable;
        }

''' 
        Dim expected = {OnNext(Of HangmanState)(100, Function(hangmanState) hangmanState.RemainingGuesses = 9 AndAlso hangmanState.MaskedWord = "______"), OnNext(Of HangmanState)(200, Function(hangmanState) hangmanState.RemainingGuesses = 9 AndAlso hangmanState.MaskedWord = "___b__"), OnNext(Of HangmanState)(300, Function(hangmanState) hangmanState.RemainingGuesses = 9 AndAlso hangmanState.MaskedWord = "_oob__")}
        Dim testableObserver As ITestableObserver(Of HangmanState) = scheduler.Start(AddressOf Create, 100, 100, 3000)
        ReactiveAssert.AreElementsEqual(expected, testableObserver.Messages)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Guessing_a_correct_letter_twice_counts_as_a_failure()
        Dim scheduler = New TestScheduler()
                ''' Cannot convert LocalFunctionStatementSyntax, CONVERSION ERROR: Conversion for LocalFunctionStatement not implemented, please report this issue in 'IObservable<HangmanState> C...' at character 5411
'''    at ICSharpCode.CodeConverter.VB.MethodBodyVisitor.DefaultVisit(SyntaxNode node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.VisitLocalFunctionStatement(LocalFunctionStatementSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.Syntax.LocalFunctionStatementSyntax.Accept[TResult](CSharpSyntaxVisitor`1 visitor)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)
''' 
''' Input: 
'''         IObservable<HangmanState> Create()
        {
            var hangman = new Hangman("foobar");
            scheduler.Schedule(TimeSpan.FromTicks(100), () => hangman.GuessObserver.OnNext('b'));
            scheduler.Schedule(TimeSpan.FromTicks(200), () => hangman.GuessObserver.OnNext('b'));
            return hangman.StateObservable;
        }

''' 
        Dim expected = {OnNext(Of HangmanState)(100, Function(hangmanState) hangmanState.RemainingGuesses = 9 AndAlso hangmanState.MaskedWord = "______"), OnNext(Of HangmanState)(200, Function(hangmanState) hangmanState.RemainingGuesses = 9 AndAlso hangmanState.MaskedWord = "___b__"), OnNext(Of HangmanState)(300, Function(hangmanState) hangmanState.RemainingGuesses = 8 AndAlso hangmanState.MaskedWord = "___b__")}
        Dim testableObserver As ITestableObserver(Of HangmanState) = scheduler.Start(AddressOf Create, 100, 100, 3000)
        ReactiveAssert.AreElementsEqual(expected, testableObserver.Messages)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Getting_all_the_letters_right_makes_for_a_win()
        Dim scheduler = New TestScheduler()
                ''' Cannot convert LocalFunctionStatementSyntax, CONVERSION ERROR: Conversion for LocalFunctionStatement not implemented, please report this issue in 'IObservable<HangmanState> C...' at character 6609
'''    at ICSharpCode.CodeConverter.VB.MethodBodyVisitor.DefaultVisit(SyntaxNode node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.VisitLocalFunctionStatement(LocalFunctionStatementSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.Syntax.LocalFunctionStatementSyntax.Accept[TResult](CSharpSyntaxVisitor`1 visitor)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)
''' 
''' Input: 
'''         IObservable<HangmanState> Create()
        {
            var hangman = new Hangman("hello");
            scheduler.Schedule(TimeSpan.FromTicks(100), () => hangman.GuessObserver.OnNext('b'));
            scheduler.Schedule(TimeSpan.FromTicks(200), () => hangman.GuessObserver.OnNext('e'));
            scheduler.Schedule(TimeSpan.FromTicks(300), () => hangman.GuessObserver.OnNext('l'));
            scheduler.Schedule(TimeSpan.FromTicks(400), () => hangman.GuessObserver.OnNext('o'));
            scheduler.Schedule(TimeSpan.FromTicks(500), () => hangman.GuessObserver.OnNext('h'));
            return hangman.StateObservable;
        }

''' 
        Dim expected = {OnNext(Of HangmanState)(100, Function(hangmanState) hangmanState.RemainingGuesses = 9 AndAlso hangmanState.MaskedWord = "_____"), OnNext(Of HangmanState)(200, Function(hangmanState) hangmanState.RemainingGuesses = 8 AndAlso hangmanState.MaskedWord = "_____"), OnNext(Of HangmanState)(300, Function(hangmanState) hangmanState.RemainingGuesses = 8 AndAlso hangmanState.MaskedWord = "_e___"), OnNext(Of HangmanState)(400, Function(hangmanState) hangmanState.RemainingGuesses = 8 AndAlso hangmanState.MaskedWord = "_ell_"), OnNext(Of HangmanState)(500, Function(hangmanState) hangmanState.RemainingGuesses = 8 AndAlso hangmanState.MaskedWord = "_ello"), OnCompleted(Of HangmanState)(600)}
        Dim testableObserver As ITestableObserver(Of HangmanState) = scheduler.Start(AddressOf Create, 100, 100, 3000)
        ReactiveAssert.AreElementsEqual(expected, testableObserver.Messages)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Second_player_sees_the_same_game_already_started()
        Dim scheduler = New TestScheduler()
        Dim player2 = scheduler.CreateObserver(Of HangmanState)()
        Dim hangman = New Hangman("hello")
        Dim player1 = hangman.StateObservable
        Ready(player1)
        scheduler.Schedule(TimeSpan.FromTicks(100), Function() hangman.GuessObserver.OnNext("e"c))
        scheduler.Schedule(TimeSpan.FromTicks(200), Function() hangman.GuessObserver.OnNext("l"c))
        scheduler.Schedule(TimeSpan.FromTicks(150), Function() hangman.StateObservable.Subscribe(player2))
        Dim expected = {OnNext(Of HangmanState)(150, Function(hangmanState) hangmanState.RemainingGuesses = 9 AndAlso hangmanState.MaskedWord = "_e___"), OnNext(Of HangmanState)(200, Function(hangmanState) hangmanState.RemainingGuesses = 9 AndAlso hangmanState.MaskedWord = "_ell_")}
        scheduler.Start()
        ReactiveAssert.AreElementsEqual(expected, player2.Messages)
    End Sub

    Private Function Ready(ByVal player As IObservable(Of HangmanState)) As IDisposable
        Return player.Subscribe(Function(x)
                                End Function)
    End Function

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_players_see_the_same_game_already_started()
        Dim scheduler = New TestScheduler()
        Dim player2 = scheduler.CreateObserver(Of HangmanState)()
        Dim player3 = scheduler.CreateObserver(Of HangmanState)()
        Dim hangman = New Hangman("hello")
        Dim player1 = hangman.StateObservable
        Ready(player1)
        scheduler.Schedule(TimeSpan.FromTicks(100), Function() hangman.GuessObserver.OnNext("e"c))
        scheduler.Schedule(TimeSpan.FromTicks(200), Function() hangman.GuessObserver.OnNext("l"c))
        scheduler.Schedule(TimeSpan.FromTicks(150), Function()
                                                        hangman.StateObservable.Subscribe(player2)
                                                        hangman.StateObservable.Subscribe(player3)
                                                    End Function)
        Dim expected = {OnNext(Of HangmanState)(150, Function(hangmanState) hangmanState.RemainingGuesses = 9 AndAlso hangmanState.MaskedWord = "_e___"), OnNext(Of HangmanState)(200, Function(hangmanState) hangmanState.RemainingGuesses = 9 AndAlso hangmanState.MaskedWord = "_ell_")}
        scheduler.Start()
        ReactiveAssert.AreElementsEqual(expected, player2.Messages)
        ReactiveAssert.AreElementsEqual(expected, player3.Messages)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Player_joins_after_other_players_quit()
        Dim scheduler = New TestScheduler()
        Dim player2 = scheduler.CreateObserver(Of HangmanState)()
        Dim hangman = New Hangman("a")
        Dim player1 = hangman.StateObservable
        Dim subscription = Ready(player1)
        scheduler.Schedule(TimeSpan.FromTicks(100), Function() hangman.GuessObserver.OnNext("a"c))
        scheduler.Schedule(TimeSpan.FromTicks(300), Function()
                                                        hangman.StateObservable.Subscribe(player2)
                                                    End Function)
        scheduler.Schedule(TimeSpan.FromTicks(200), Function() subscription.Dispose())
        Dim expected = {OnCompleted(Of HangmanState)(300)}
        scheduler.Start()
        ReactiveAssert.AreElementsEqual(expected, player2.Messages)
    End Sub

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class
End Class
