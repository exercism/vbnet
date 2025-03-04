Imports Xunit

Public Class BobTest
    Private teenager = New Bob()

    <Fact>
    Public Sub StatingSomething()
        Dim expected = "Whatever."
        Dim result as String = teenager.Hey("Tom-ay-to, tom-aaaah-to.")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Shouting()
        Dim expected = "Whoa, chill out!"
        Dim result as String = teenager.Hey("WATCH OUT!")
        Assert.Equal("Whoa, chill out!", teenager.Hey("WATCH OUT!"), false)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AskingAQuestion()
        Dim expected = "Sure."
        Dim result as String = teenager.Hey("Does this cryogenic chamber make me look fat?")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AskingANumericQuestion()
        Dim expected = "Sure."
        Dim result as String = teenager.Hey("You are, what, like 15?")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub TalkingForcefully()
        Dim expected = "Whatever."
        Dim result as String = teenager.Hey("Let's go make out behind the gym!")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub UsingAcronymsInRegularSearch()
        Dim expected = "Whatever."
        Dim result as String = teenager.Hey("It's OK if you don't want to go to the DMV.")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub ForcefulQuestions()
        Dim expected = "Calm down, I know what I'm doing!"
        Dim result as String = teenager.Hey("WHAT THE HELL WERE YOU THINKING?")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub ShoutingNumbers()
        Dim expected = "Whoa, chill out!"
        Dim result as String = teenager.Hey("1, 2, 3 GO!")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub OnlyNumbers()
        Dim expected = "Whatever."
        Dim result as String = teenager.Hey("1, 2, 3")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub QuestionWithOnlyNumbers()
        Dim expected = "Sure."
        Dim result as String = teenager.Hey("4?")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub ShoutingWithSpecialCharacters()
        Dim expected = "Whoa, chill out!"
        Dim result as String = teenager.Hey("ZOMG THE %^*@#$(*^ ZOMBIES ARE COMING!!11!!1!")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub ShoutingWithNoExclamationMark()
        Dim expected = "Whoa, chill out!"
        Dim result as String = teenager.Hey("I HATE YOU")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub StatementContainingQuestionMark()
        Dim expected = "Whatever."
        Dim result as String = teenager.Hey("Ending with ? means a question.")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub PrattlingOn()
        Dim expected = "Sure."
        Dim result as String = teenager.Hey("Wait! Hang on. Are you going to be OK?")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Silence()
        Dim expected = "Fine. Be that way!"
        Dim result as String = teenager.Hey("")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub ProlongedSilence()
        Dim expected = "Fine. Be that way!"
        Dim result as String = teenager.Hey("    ")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub MultipleLineQuestion()
        Dim expected = "Whatever."
        Dim result as String = teenager.Hey("Does this cryogenic chamber make me look fat?" & vbLf & "no")
        Assert.Equal(expected, result)
    End Sub
End Class
