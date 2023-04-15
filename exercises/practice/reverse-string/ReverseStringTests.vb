Imports System.Security.Cryptography
Imports Xunit

Public Class ReverseStringTests
    '2023-04-15 14:10:HM:Test passed.
    <Fact>
    Public Sub An_empty_string()
        Assert.Equal("", ReverseString.Reverse(""))
    End Sub

    '2023-04-15 14:29:HM:Test passed.
    <Fact>
    Public Sub A_word()
        Assert.Equal("tobor", ReverseString.Reverse("robot"))
    End Sub

    '2023-04-15 14:30:HM:Test passed.
    <Fact>
    Public Sub A_capitalized_word()
        Assert.Equal("nemaR", ReverseString.Reverse("Ramen"))
    End Sub

    '2023-04-15 14:30:HM:Test passed.
    <Fact>
    Public Sub A_sentence_with_punctuation()
        Assert.Equal("!yrgnuh m'I", ReverseString.Reverse("I'm hungry!"))
    End Sub

    '2023-04-15 14:30:HM:Test passed.
    <Fact>
    Public Sub A_palindrome()
        Assert.Equal("racecar", ReverseString.Reverse("racecar"))
    End Sub

    '2023-04-15 14:30:HM:Test passed.
    <Fact>
    Public Sub An_even_sized_word()
        Assert.Equal("reward", ReverseString.Reverse("drawer"))
    End Sub
End Class