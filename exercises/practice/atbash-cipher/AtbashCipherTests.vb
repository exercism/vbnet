Public Class AtbashCipherTests
    <Fact>
    Public Sub Encode_yes()
        Dim actual = AtbashCipher.Encode("yes")
        Dim expected = "bvh"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Encode_no()
        Dim actual = AtbashCipher.Encode("no")
        Dim expected = "ml"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Encode_omg()
        Dim actual = AtbashCipher.Encode("OMG")
        Dim expected = "lnt"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Encode_spaces()
        Dim actual = AtbashCipher.Encode("O M G")
        Dim expected = "lnt"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Encode_mindblowingly()
        Dim actual = AtbashCipher.Encode("mindblowingly")
        Dim expected = "nrmwy oldrm tob"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Encode_numbers()
        Dim actual = AtbashCipher.Encode("Testing,1 2 3, testing.")
        Dim expected = "gvhgr mt123 gvhgr mt"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Encode_deep_thought()
        Dim actual = AtbashCipher.Encode("Truth is fiction.")
        Dim expected = "gifgs rhurx grlm"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Encode_all_the_letters()
        Dim actual = AtbashCipher.Encode("The quick brown fox jumps over the lazy dog.")
        Dim expected = "gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Decode_exercism()
        Dim actual = AtbashCipher.Decode("vcvix rhn")
        Dim expected = "exercism"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Decode_a_sentence()
        Dim actual = AtbashCipher.Decode("zmlyh gzxov rhlug vmzhg vkkrm thglm v")
        Dim expected = "anobstacleisoftenasteppingstone"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Decode_numbers()
        Dim actual = AtbashCipher.Decode("gvhgr mt123 gvhgr mt")
        Dim expected = "testing123testing"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Decode_all_the_letters()
        Dim actual = AtbashCipher.Decode("gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt")
        Dim expected = "thequickbrownfoxjumpsoverthelazydog"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Decode_with_too_many_spaces()
        Dim actual = AtbashCipher.Decode("vc vix    r hn")
        Dim expected = "exercism"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Decode_with_no_spaces()
        Dim actual = AtbashCipher.Decode("zmlyhgzxovrhlugvmzhgvkkrmthglmv")
        Dim expected = "anobstacleisoftenasteppingstone"
        Assert.Equal(expected, actual)
    End Sub
End Class
