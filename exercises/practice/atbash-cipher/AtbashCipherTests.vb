Imports Xunit

Public Class AtbashCipherTests
    <Fact>
    Public Sub EncodeYes()
        Assert.Equal("bvh", AtbashCipher.Encode("yes"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub EncodeNo()
        Assert.Equal("ml", AtbashCipher.Encode("no"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub EncodeOMG()
        Assert.Equal("lnt", AtbashCipher.Encode("OMG"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub EncodeSpaces()
        Assert.Equal("lnt", AtbashCipher.Encode("O M G"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub EncodeMindblowingly()
        Assert.Equal("nrmwy oldrm tob", AtbashCipher.Encode("mindblowingly"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub EncodeNumbers()
        Assert.Equal("gvhgr mt123 gvhgr mt", AtbashCipher.Encode("Testing,1 2 3, testing."))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub EncodeDeepThought()
        Assert.Equal("gifgs rhurx grlm", AtbashCipher.Encode("Truth is fiction."))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub EncodeAllTheLetters()
        Assert.Equal("gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt", AtbashCipher.Encode("The quick brown fox jumps over the lazy dog."))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub DecodeExercism()
        Assert.Equal("exercism", AtbashCipher.Decode("vcvix rhn"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub DecodeASentence()
        Assert.Equal("anobstacleisoftenasteppingstone", AtbashCipher.Decode("zmlyh gzxov rhlug vmzhg vkkrm thglm v"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub DecodeNumbers()
        Assert.Equal("testing123testing", AtbashCipher.Decode("gvhgr mt123 gvhgr mt"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub DecodeAllTheLetters()
        Assert.Equal("thequickbrownfoxjumpsoverthelazydog", AtbashCipher.Decode("gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub DecodeWithTooManySpaces()
        Assert.Equal("exercism", AtbashCipher.Decode("vc vix    r hn"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub DecodeWithNoSpaces()
        Assert.Equal("anobstacleisoftenasteppingstone", AtbashCipher.Decode("zmlyhgzxovrhlugvmzhgvkkrmthglmv"))
    End Sub
End Class