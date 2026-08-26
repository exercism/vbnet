Public Class IsogramTests
    <Fact>
    Public Sub Empty_string()
        Assert.True(Isogram.IsIsogram(""))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Isogram_with_only_lower_case_characters()
        Assert.True(Isogram.IsIsogram("isogram"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Word_with_one_duplicated_character()
        Assert.False(Isogram.IsIsogram("eleven"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Word_with_one_duplicated_character_from_the_end_of_the_alphabet()
        Assert.False(Isogram.IsIsogram("zzyzx"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Longest_reported_english_isogram()
        Assert.True(Isogram.IsIsogram("subdermatoglyphic"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Word_with_duplicated_character_in_mixed_case()
        Assert.False(Isogram.IsIsogram("Alphabet"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Word_with_duplicated_character_in_mixed_case_lowercase_first()
        Assert.False(Isogram.IsIsogram("alphAbet"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Hypothetical_isogrammic_word_with_hyphen()
        Assert.True(Isogram.IsIsogram("thumbscrew-japingly"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Hypothetical_word_with_duplicated_character_following_hyphen()
        Assert.False(Isogram.IsIsogram("thumbscrew-jappingly"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Isogram_with_duplicated_hyphen()
        Assert.True(Isogram.IsIsogram("six-year-old"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Made_up_name_that_is_an_isogram()
        Assert.True(Isogram.IsIsogram("Emily Jung Schwartzkopf"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Duplicated_character_in_the_middle()
        Assert.False(Isogram.IsIsogram("accentor"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Same_first_and_last_characters()
        Assert.False(Isogram.IsIsogram("angola"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Word_with_duplicated_character_and_with_two_hyphens()
        Assert.False(Isogram.IsIsogram("up-to-date"))
    End Sub
End Class
