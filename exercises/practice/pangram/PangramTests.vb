Imports Xunit

Public Class PangramTests
    <Fact>
    Public Sub Empty_sentence()
        Assert.False(Pangram.IsPangram(""))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Perfect_lower_case()
        Assert.True(Pangram.IsPangram("abcdefghijklmnopqrstuvwxyz"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Only_lower_case()
        Assert.True(Pangram.IsPangram("the quick brown fox jumps over the lazy dog"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Missing_the_letter_x()
        Assert.False(Pangram.IsPangram("a quick movement of the enemy will jeopardize five gunboats"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Missing_the_letter_h()
        Assert.False(Pangram.IsPangram("five boxing wizards jump quickly at it"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub With_underscores()
        Assert.True(Pangram.IsPangram("the_quick_brown_fox_jumps_over_the_lazy_dog"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub With_numbers()
        Assert.True(Pangram.IsPangram("the 1 quick brown fox jumps over the 2 lazy dogs"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Missing_letters_replaced_by_numbers()
        Assert.False(Pangram.IsPangram("7h3 qu1ck brown fox jumps ov3r 7h3 lazy dog"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Mixed_case_and_punctuation()
        Assert.True(Pangram.IsPangram("""Five quacking Zephyrs jolt my wax bed."""))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_m_and_a_m_are_26_different_characters_but_not_a_pangram()
        Assert.False(Pangram.IsPangram("abcdefghijklm ABCDEFGHIJKLM"))
    End Sub
End Class
