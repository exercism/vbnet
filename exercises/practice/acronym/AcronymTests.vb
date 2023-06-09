Imports Xunit

Public Class AcronymTests
    <Fact>
    Public Sub Basic()
        Assert.Equal("PNG", Abbreviate("Portable Network Graphics"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Lowercase_words()
        Assert.Equal("ROR", Abbreviate("Ruby on Rails"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Punctuation()
        Assert.Equal("FIFO", Abbreviate("First In, First Out"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub All_caps_word()
        Assert.Equal("GIMP", Abbreviate("GNU Image Manipulation Program"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Punctuation_without_whitespace()
        Assert.Equal("CMOS", Abbreviate("Complementary metal-oxide semiconductor"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Very_long_abbreviation()
        Assert.Equal("ROTFLSHTMDCOALM", Abbreviate("Rolling On The Floor Laughing So Hard That My Dogs Came Over And Licked Me"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Consecutive_delimiters()
        Assert.Equal("SIMUFTA", Abbreviate("Something - I made up from thin air"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Apostrophes()
        Assert.Equal("HC", Abbreviate("Halley's Comet"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Underscore_emphasis()
        Assert.Equal("TRNT", Abbreviate("The Road _Not_ Taken"))
    End Sub
End Class
