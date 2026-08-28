Public Class RotationalCipherTests
    <Fact>
    Public Sub Rotate_a_by_0_same_output_as_input()
        Dim text = "a"
        Dim expected = "a"
        Assert.Equal(expected, RotationalCipher.Rotate(text, 0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rotate_a_by_1()
        Dim text = "a"
        Dim expected = "b"
        Assert.Equal(expected, RotationalCipher.Rotate(text, 1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rotate_a_by_26_same_output_as_input()
        Dim text = "a"
        Dim expected = "a"
        Assert.Equal(expected, RotationalCipher.Rotate(text, 26))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rotate_m_by_13()
        Dim text = "m"
        Dim expected = "z"
        Assert.Equal(expected, RotationalCipher.Rotate(text, 13))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rotate_n_by_13_with_wrap_around_alphabet()
        Dim text = "n"
        Dim expected = "a"
        Assert.Equal(expected, RotationalCipher.Rotate(text, 13))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rotate_capital_letters()
        Dim text = "OMG"
        Dim expected = "TRL"
        Assert.Equal(expected, RotationalCipher.Rotate(text, 5))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rotate_spaces()
        Dim text = "O M G"
        Dim expected = "T R L"
        Assert.Equal(expected, RotationalCipher.Rotate(text, 5))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rotate_numbers()
        Dim text = "Testing 1 2 3 testing"
        Dim expected = "Xiwxmrk 1 2 3 xiwxmrk"
        Assert.Equal(expected, RotationalCipher.Rotate(text, 4))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rotate_punctuation()
        Dim text = "Let's eat, Grandma!"
        Dim expected = "Gzo'n zvo, Bmviyhv!"
        Assert.Equal(expected, RotationalCipher.Rotate(text, 21))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rotate_all_letters()
        Dim text = "The quick brown fox jumps over the lazy dog."
        Dim expected = "Gur dhvpx oebja sbk whzcf bire gur ynml qbt."
        Assert.Equal(expected, RotationalCipher.Rotate(text, 13))
    End Sub
End Class
