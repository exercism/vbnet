Public Class ReverseStringTests
    <Fact>
    Public Sub An_empty_string()
        Assert.Equal("", ReverseString.Reverse(""))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
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

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Wide_characters()
        Assert.Equal("猫子", ReverseString.Reverse("子猫"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Grapheme_cluster_with_pre_combined_form()
        Assert.Equal("dnatsnehctsrüW", ReverseString.Reverse("Würstchenstand"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Grapheme_clusters()
        Assert.Equal("มรกแรปโนยขีเผู้", ReverseString.Reverse("ผู้เขียนโปรแกรม"))
    End Sub
End Class
