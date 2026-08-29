Public Class ScrabbleScoreTests
    <Fact>
    Public Sub Lowercase_letter()
        Assert.Equal(1, ScrabbleScore.Score("a"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Uppercase_letter()
        Assert.Equal(1, ScrabbleScore.Score("A"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Valuable_letter()
        Assert.Equal(4, ScrabbleScore.Score("f"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Short_word()
        Assert.Equal(2, ScrabbleScore.Score("at"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Short_valuable_word()
        Assert.Equal(12, ScrabbleScore.Score("zoo"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Medium_word()
        Assert.Equal(6, ScrabbleScore.Score("street"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Medium_valuable_word()
        Assert.Equal(22, ScrabbleScore.Score("quirky"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Long_mixed_case_word()
        Assert.Equal(41, ScrabbleScore.Score("OxyphenButazone"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub English_like_word()
        Assert.Equal(8, ScrabbleScore.Score("pinata"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Empty_input()
        Assert.Equal(0, ScrabbleScore.Score(""))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Entire_alphabet_available()
        Assert.Equal(87, ScrabbleScore.Score("abcdefghijklmnopqrstuvwxyz"))
    End Sub
End Class
