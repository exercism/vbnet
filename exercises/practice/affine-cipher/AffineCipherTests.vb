Imports System
Imports Xunit

Public Class AffineCipherTests
    <Fact>
    Public Sub Encode_yes()
        Assert.Equal("xbt", Encode("yes", 5, 7))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Encode_no()
        Assert.Equal("fu", Encode("no", 15, 18))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Encode_omg()
        Assert.Equal("lvz", Encode("OMG", 21, 3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Encode_o_m_g()
        Assert.Equal("hjp", Encode("O M G", 25, 47))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Encode_mindblowingly()
        Assert.Equal("rzcwa gnxzc dgt", Encode("mindblowingly", 11, 15))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Encode_numbers()
        Assert.Equal("jqgjc rw123 jqgjc rw", Encode("Testing,1 2 3, testing.", 3, 4))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Encode_deep_thought()
        Assert.Equal("iynia fdqfb ifje", Encode("Truth is fiction.", 5, 17))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Encode_all_the_letters()
        Assert.Equal("swxtj npvyk lruol iejdc blaxk swxmh qzglf", Encode("The quick brown fox jumps over the lazy dog.", 17, 33))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Encode_with_a_not_coprime_to_m()
        Assert.Throws(Of ArgumentException)(Function() Encode("This is a test.", 6, 17))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Decode_exercism()
        Assert.Equal("exercism", Decode("tytgn fjr", 3, 7))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Decode_a_sentence()
        Assert.Equal("anobstacleisoftenasteppingstone", Decode("qdwju nqcro muwhn odqun oppmd aunwd o", 19, 16))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Decode_numbers()
        Assert.Equal("testing123testing", Decode("odpoz ub123 odpoz ub", 25, 7))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Decode_all_the_letters()
        Assert.Equal("thequickbrownfoxjumpsoverthelazydog", Decode("swxtj npvyk lruol iejdc blaxk swxmh qzglf", 17, 33))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Decode_with_no_spaces_in_input()
        Assert.Equal("thequickbrownfoxjumpsoverthelazydog", Decode("swxtjnpvyklruoliejdcblaxkswxmhqzglf", 17, 33))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Decode_with_too_many_spaces()
        Assert.Equal("jollygreengiant", Decode("vszzm    cly   yd cg    qdp", 15, 16))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Decode_with_a_not_coprime_to_m()
        Assert.Throws(Of ArgumentException)(Function() Decode("Test", 13, 5))
    End Sub
End Class
