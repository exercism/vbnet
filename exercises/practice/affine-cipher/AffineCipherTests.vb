Public Class AffineCipherTests
    <Fact>
    Public Sub Encode_yes()
        Dim actual = Encode("yes", 5, 7)
        Dim expected = "xbt"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Encode_no()
        Dim actual = Encode("no", 15, 18)
        Dim expected = "fu"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Encode_omg()
        Dim actual = Encode("OMG", 21, 3)
        Dim expected = "lvz"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Encode_o_m_g()
        Dim actual = Encode("O M G", 25, 47)
        Dim expected = "hjp"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Encode_mindblowingly()
        Dim actual = Encode("mindblowingly", 11, 15)
        Dim expected = "rzcwa gnxzc dgt"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Encode_numbers()
        Dim actual = Encode("Testing,1 2 3, testing.", 3, 4)
        Dim expected = "jqgjc rw123 jqgjc rw"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Encode_deep_thought()
        Dim actual = Encode("Truth is fiction.", 5, 17)
        Dim expected = "iynia fdqfb ifje"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Encode_all_the_letters()
        Dim actual = Encode("The quick brown fox jumps over the lazy dog.", 17, 33)
        Dim expected = "swxtj npvyk lruol iejdc blaxk swxmh qzglf"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Encode_with_a_not_coprime_to_m()
        Assert.Throws(Of ArgumentException)(Function() Encode("This is a test.", 6, 17))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Decode_exercism()
        Dim actual = Decode("tytgn fjr", 3, 7)
        Dim expected = "exercism"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Decode_a_sentence()
        Dim actual = Decode("qdwju nqcro muwhn odqun oppmd aunwd o", 19, 16)
        Dim expected = "anobstacleisoftenasteppingstone"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Decode_numbers()
        Dim actual = Decode("odpoz ub123 odpoz ub", 25, 7)
        Dim expected = "testing123testing"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Decode_all_the_letters()
        Dim actual = Decode("swxtj npvyk lruol iejdc blaxk swxmh qzglf", 17, 33)
        Dim expected = "thequickbrownfoxjumpsoverthelazydog"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Decode_with_no_spaces_in_input()
        Dim actual = Decode("swxtjnpvyklruoliejdcblaxkswxmhqzglf", 17, 33)
        Dim expected = "thequickbrownfoxjumpsoverthelazydog"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Decode_with_too_many_spaces()
        Dim actual = Decode("vszzm    cly   yd cg    qdp", 15, 16)
        Dim expected = "jollygreengiant"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Decode_with_a_not_coprime_to_m()
        Assert.Throws(Of ArgumentException)(Function() Decode("Test", 13, 5))
    End Sub
End Class
