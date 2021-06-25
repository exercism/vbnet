Imports XUnit


Public Class BobTest
    Private teenager = New Bob()
    <Fact>
    Public Sub StatingSomething()
        Assert.Equal(teenager.Hey("Tom-ay-to, tom-aaaah-to."), "Whatever.")
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Shouting()
        Assert.Equal(teenager.Hey("WATCH OUT!"), "Whoa, chill out!")
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AskingAQuestion()
        Assert.Equal(teenager.Hey("Does this cryogenic chamber make me look fat?"), "Sure.")
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AskingANumericQuestion()
        Assert.Equal(teenager.Hey("You are, what, like 15?"), "Sure.")
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub TalkingForcefully()
        Assert.Equal(teenager.Hey("Let's go make out behind the gym!"), "Whatever.")
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub UsingAcronymsInRegularSearch()
        Assert.Equal(teenager.Hey("It's OK if you don't want to go to the DMV."), "Whatever.")
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub ForcefulQuestions()
        Assert.Equal(teenager.Hey("WHAT THE HELL WERE YOU THINKING?"), "Calm down, I know what I'm doing!")
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub ShoutingNumbers()
        Assert.Equal(teenager.Hey("1, 2, 3 GO!"), "Whoa, chill out!")
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub OnlyNumbers()
        Assert.Equal(teenager.Hey("1, 2, 3"), "Whatever.")
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub QuestionWithOnlyNumbers()
        Assert.Equal(teenager.Hey("4?"), "Sure.")
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub ShoutingWithSpecialCharacters()
        Assert.Equal(teenager.Hey("ZOMG THE %^*@#$(*^ ZOMBIES ARE COMING!!11!!1!"), "Whoa, chill out!")
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub ShoutingWithNoExclamationMark()
        Assert.Equal(teenager.Hey("I HATE YOU"), "Whoa, chill out!")
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub StatementContainingQuestionMark()
        Assert.Equal(teenager.Hey("Ending with ? means a question."), "Whatever.")
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub PrattlingOn()
        Assert.Equal(teenager.Hey("Wait! Hang on. Are you going to be OK?"), "Sure.")
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Silence()
        Assert.Equal(teenager.Hey(""), "Fine. Be that way!")
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub ProlongedSilence()
        Assert.Equal(teenager.Hey("    "), "Fine. Be that way!")
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub MultipleLineQuestion()
        Assert.Equal(teenager.Hey("Does this cryogenic chamber make me look fat?" & vbLf & "no"), "Whatever.")
    End Sub
End Class
