Imports Xunit

Public Class BobTest
    Private teenager = New Bob()

    <Fact>
    Public Sub StatingSomething()
        Assert.Equal("Whatever.",  teenager.Hey("Tom-ay-to, tom-aaaah-to."), false)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Shouting()
        Assert.Equal("Whoa, chill out!", teenager.Hey("WATCH OUT!"), false)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AskingAQuestion()
        Assert.Equal("Sure.", teenager.Hey("Does this cryogenic chamber make me look fat?"), false)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AskingANumericQuestion()
        Assert.Equal("Sure.", teenager.Hey("You are, what, like 15?"), false)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub TalkingForcefully()
        Assert.Equal("Whatever.", teenager.Hey("Let's go make out behind the gym!"), false)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub UsingAcronymsInRegularSearch()
        Assert.Equal("Whatever.", teenager.Hey("It's OK if you don't want to go to the DMV."), false)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub ForcefulQuestions()
        Assert.Equal("Calm down, I know what I'm doing!", teenager.Hey("WHAT THE HELL WERE YOU THINKING?"), false)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub ShoutingNumbers()
        Assert.Equal("Whoa, chill out!", teenager.Hey("1, 2, 3 GO!"), false)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub OnlyNumbers()
        Assert.Equal("Whatever.", teenager.Hey("1, 2, 3"), false)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub QuestionWithOnlyNumbers()
        Assert.Equal("Sure.", teenager.Hey("4?"), false)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub ShoutingWithSpecialCharacters()
        Assert.Equal("Whoa, chill out!", teenager.Hey("ZOMG THE %^*@#$(*^ ZOMBIES ARE COMING!!11!!1!"), false)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub ShoutingWithNoExclamationMark()
        Assert.Equal("Whoa, chill out!", teenager.Hey("I HATE YOU"), false)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub StatementContainingQuestionMark()
        Assert.Equal("Whatever.", teenager.Hey("Ending with ? means a question."), false)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub PrattlingOn()
        Assert.Equal("Sure.", teenager.Hey("Wait! Hang on. Are you going to be OK?"), false)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Silence()
        Assert.Equal("Fine. Be that way!", teenager.Hey(""), false)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub ProlongedSilence()
        Assert.Equal("Fine. Be that way!", teenager.Hey("    "), false)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub MultipleLineQuestion()
        Assert.Equal("Whatever.", teenager.Hey("Does this cryogenic chamber make me look fat?" & vbLf & "no"), false)
    End Sub
End Class
