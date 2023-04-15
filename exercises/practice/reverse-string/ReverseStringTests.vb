Imports System.Security.Cryptography
Imports Xunit

Public Class ReverseStringTests
    <Fact>
    Public Sub An_empty_string()
        '2023-04-15 14:10:HM:Test passed.
        Assert.Equal("", ReverseString.Reverse(""))
    End Sub

    <Fact>
    Public Sub A_word()
        Assert.Equal("tobor", ReverseString.Reverse("robot"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_capitalized_word()
        Assert.Equal("nemaR", ReverseString.Reverse("Ramen"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_sentence_with_punctuation()
        Assert.Equal("!yrgnuh m'I", ReverseString.Reverse("I'm hungry!"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_palindrome()
        Assert.Equal("racecar", ReverseString.Reverse("racecar"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub An_even_sized_word()
        Assert.Equal("reward", ReverseString.Reverse("drawer"))
    End Sub
End Class