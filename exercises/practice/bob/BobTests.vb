Imports XUnit


Public Class BobTest
    Private teenager As Bob


    Public Sub Init()
        teenager = New Bob()
    End Sub

    <Fact>
    Public Sub StatingSomething()
        Assert.That(teenager.Hey("Tom-ay-to, tom-aaaah-to."), [Is].EqualTo("Whatever."))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub Shouting()
        Assert.That(teenager.Hey("WATCH OUT!"), [Is].EqualTo("Whoa, chill out!"))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub AskingAQuestion()
        Assert.That(teenager.Hey("Does this cryogenic chamber make me look fat?"), [Is].EqualTo("Sure."))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub AskingANumericQuestion()
        Assert.That(teenager.Hey("You are, what, like 15?"), [Is].EqualTo("Sure."))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub TalkingForcefully()
        Assert.That(teenager.Hey("Let's go make out behind the gym!"), [Is].EqualTo("Whatever."))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub UsingAcronymsInRegularSearch()
        Assert.That(teenager.Hey("It's OK if you don't want to go to the DMV."), [Is].EqualTo("Whatever."))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub ForcefulQuestions()
        Assert.That(teenager.Hey("WHAT THE HELL WERE YOU THINKING?"), [Is].EqualTo("Whoa, chill out!"))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub ShoutingNumbers()
        Assert.That(teenager.Hey("1, 2, 3 GO!"), [Is].EqualTo("Whoa, chill out!"))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub OnlyNumbers()
        Assert.That(teenager.Hey("1, 2, 3"), [Is].EqualTo("Whatever."))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub QuestionWithOnlyNumbers()
        Assert.That(teenager.Hey("4?"), [Is].EqualTo("Sure."))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub ShoutingWithSpecialCharacters()
        Assert.That(teenager.Hey("ZOMG THE %^*@#$(*^ ZOMBIES ARE COMING!!11!!1!"), [Is].EqualTo("Whoa, chill out!"))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub ShoutingWithNoExclamationMark()
        Assert.That(teenager.Hey("I HATE YOU"), [Is].EqualTo("Whoa, chill out!"))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub StatementContainingQuestionMark()
        Assert.That(teenager.Hey("Ending with ? means a question."), [Is].EqualTo("Whatever."))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub PrattlingOn()
        Assert.That(teenager.Hey("Wait! Hang on. Are you going to be OK?"), [Is].EqualTo("Sure."))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub Silence()
        Assert.That(teenager.Hey(""), [Is].EqualTo("Fine. Be that way!"))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub ProlongedSilence()
        Assert.That(teenager.Hey("    "), [Is].EqualTo("Fine. Be that way!"))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub MultipleLineQuestion()
        Assert.That(teenager.Hey("Does this cryogenic chamber make me look fat?" & vbLf & "no"), [Is].EqualTo("Whatever."))
    End Sub
End Class
