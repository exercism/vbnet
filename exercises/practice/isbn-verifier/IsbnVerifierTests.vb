Imports Xunit

Public Class IsbnVerifierTests
    <Fact>
    Public Sub Valid_isbn()
        Assert.True(IsValid("3-598-21508-8"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_isbn_check_digit()
        Assert.False(IsValid("3-598-21508-9"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Valid_isbn_with_a_check_digit_of_10()
        Assert.True(IsValid("3-598-21507-X"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Check_digit_is_a_character_other_than_x()
        Assert.False(IsValid("3-598-21507-A"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_check_digit_in_isbn_is_not_treated_as_zero()
        Assert.False(IsValid("4-598-21507-B"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_character_in_isbn_is_not_treated_as_zero()
        Assert.False(IsValid("3-598-P1581-X"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub X_is_only_valid_as_a_check_digit()
        Assert.False(IsValid("3-598-2X507-9"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Valid_isbn_without_separating_dashes()
        Assert.True(IsValid("3598215088"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Isbn_without_separating_dashes_and_x_as_check_digit()
        Assert.True(IsValid("359821507X"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Isbn_without_check_digit_and_dashes()
        Assert.False(IsValid("359821507"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Too_long_isbn_and_no_dashes()
        Assert.False(IsValid("3598215078X"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Too_short_isbn()
        Assert.False(IsValid("00"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Isbn_without_check_digit()
        Assert.False(IsValid("3-598-21507"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Check_digit_of_x_should_not_be_used_for_0()
        Assert.False(IsValid("3-598-21515-X"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Empty_isbn()
        Assert.False(IsValid(""))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Input_is_9_characters()
        Assert.False(IsValid("134456729"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_characters_are_not_ignored_after_checking_length()
        Assert.False(IsValid("3132P34035"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_characters_are_not_ignored_before_checking_length()
        Assert.False(IsValid("3598P215088"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Input_is_too_long_but_contains_a_valid_isbn()
        Assert.False(IsValid("98245726788"))
    End Sub
End Class
