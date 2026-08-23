Public Class BobTests
    <Fact>
    Public Sub Asking_a_question()
        Dim sut = New Bob()
        Dim phrase = "Does this cryogenic chamber make me look fat?"
        Assert.Equal("Sure.", sut.Hey(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Shouting()
        Dim sut = New Bob()
        Dim phrase = "WATCH OUT!"
        Assert.Equal("Whoa, chill out!", sut.Hey(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Forceful_question()
        Dim sut = New Bob()
        Dim phrase = "WHAT'S GOING ON?"
        Assert.Equal("Calm down, I know what I'm doing!", sut.Hey(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Silence()
        Dim sut = New Bob()
        Dim phrase = ""
        Assert.Equal("Fine. Be that way!", sut.Hey(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Stating_something()
        Dim sut = New Bob()
        Dim phrase = "Tom-ay-to, tom-aaaah-to."
        Assert.Equal("Whatever.", sut.Hey(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Asking_a_numeric_question()
        Dim sut = New Bob()
        Dim phrase = "You are, what, like 15?"
        Assert.Equal("Sure.", sut.Hey(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Asking_gibberish()
        Dim sut = New Bob()
        Dim phrase = "fffbbcbeab?"
        Assert.Equal("Sure.", sut.Hey(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Question_with_no_letters()
        Dim sut = New Bob()
        Dim phrase = "4?"
        Assert.Equal("Sure.", sut.Hey(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Non_letters_with_question()
        Dim sut = New Bob()
        Dim phrase = ":) ?"
        Assert.Equal("Sure.", sut.Hey(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Prattling_on()
        Dim sut = New Bob()
        Dim phrase = "Wait! Hang on. Are you going to be OK?"
        Assert.Equal("Sure.", sut.Hey(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ending_with_whitespace()
        Dim sut = New Bob()
        Dim phrase = "Okay if like my  spacebar  quite a bit?   "
        Assert.Equal("Sure.", sut.Hey(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_line_question()
        Dim sut = New Bob()
        Dim phrase = vbLf & "Does this cryogenic chamber make" & vbLf & " me look fat?"
        Assert.Equal("Sure.", sut.Hey(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Shouting_gibberish()
        Dim sut = New Bob()
        Dim phrase = "FCECDFCAAB"
        Assert.Equal("Whoa, chill out!", sut.Hey(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Shouting_a_statement_containing_a_question_mark()
        Dim sut = New Bob()
        Dim phrase = "DO LIONS EAT PEOPLE? AHHHHH."
        Assert.Equal("Whoa, chill out!", sut.Hey(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Shouting_numbers()
        Dim sut = New Bob()
        Dim phrase = "1, 2, 3 GO!"
        Assert.Equal("Whoa, chill out!", sut.Hey(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Shouting_with_special_characters()
        Dim sut = New Bob()
        Dim phrase = "ZOMG THE %^*@#$(*^ ZOMBIES ARE COMING!!11!!1!"
        Assert.Equal("Whoa, chill out!", sut.Hey(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Shouting_with_no_exclamation_mark()
        Dim sut = New Bob()
        Dim phrase = "I HATE THE DENTIST"
        Assert.Equal("Whoa, chill out!", sut.Hey(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Prolonged_silence()
        Dim sut = New Bob()
        Dim phrase = "          "
        Assert.Equal("Fine. Be that way!", sut.Hey(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Alternate_silence()
        Dim sut = New Bob()
        Dim phrase = vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab
        Assert.Equal("Fine. Be that way!", sut.Hey(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Other_whitespace()
        Dim sut = New Bob()
        Dim phrase = vbLf & vbCr & " " & vbTab
        Assert.Equal("Fine. Be that way!", sut.Hey(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Talking_forcefully()
        Dim sut = New Bob()
        Dim phrase = "Hi there!"
        Assert.Equal("Whatever.", sut.Hey(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Using_acronyms_in_regular_speech()
        Dim sut = New Bob()
        Dim phrase = "It's OK if you don't want to go work for NASA."
        Assert.Equal("Whatever.", sut.Hey(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub No_letters()
        Dim sut = New Bob()
        Dim phrase = "1, 2, 3"
        Assert.Equal("Whatever.", sut.Hey(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Statement_containing_question_mark()
        Dim sut = New Bob()
        Dim phrase = "Ending with ? means a question."
        Assert.Equal("Whatever.", sut.Hey(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Starting_with_whitespace()
        Dim sut = New Bob()
        Dim phrase = "         hmmmmmmm..."
        Assert.Equal("Whatever.", sut.Hey(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Non_question_ending_with_whitespace()
        Dim sut = New Bob()
        Dim phrase = "This is a statement ending with whitespace      "
        Assert.Equal("Whatever.", sut.Hey(phrase))
    End Sub
End Class
