Imports Xunit

Public Class RotationalCipherTests
    <Fact>
    Public Sub Rotate_a_by_0_same_output_as_input()
        Assert.Equal("a", Rotate("a", 0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rotate_a_by_1()
        Assert.Equal("b", Rotate("a", 1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rotate_a_by_26_same_output_as_input()
        Assert.Equal("a", Rotate("a", 26))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rotate_m_by_13()
        Assert.Equal("z", Rotate("m", 13))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rotate_n_by_13_with_wrap_around_alphabet()
        Assert.Equal("a", Rotate("n", 13))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rotate_capital_letters()
        Assert.Equal("TRL", Rotate("OMG", 5))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rotate_spaces()
        Assert.Equal("T R L", Rotate("O M G", 5))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rotate_numbers()
        Assert.Equal("Xiwxmrk 1 2 3 xiwxmrk", Rotate("Testing 1 2 3 testing", 4))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rotate_punctuation()
        Assert.Equal("Gzo'n zvo, Bmviyhv!", Rotate("Let's eat, Grandma!", 21))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rotate_all_letters()
        Assert.Equal("Gur dhvpx oebja sbk whzcf bire gur ynml qbt.", Rotate("The quick brown fox jumps over the lazy dog.", 13))
    End Sub
End Class
