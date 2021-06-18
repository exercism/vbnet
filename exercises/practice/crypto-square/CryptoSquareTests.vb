Imports XUnit

Public Class CryptoSquareTest
    <Fact>
    Public Sub StrangeCharactersAreStrippedDuringNormalization()
        Dim crypto = New Crypto("s#$%^&plunk")
        Assert.That(crypto.NormalizePlaintext, [Is].EqualTo("splunk"))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub LettersAreLowercasedDuringNormalization()
        Dim crypto = New Crypto("WHOA HEY!")
        Assert.That(crypto.NormalizePlaintext, [Is].EqualTo("whoahey"))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub NumbersAreKeptDuringNormalization()
        Dim crypto = New Crypto("1, 2, 3, GO!")
        Assert.That(crypto.NormalizePlaintext, [Is].EqualTo("123go"))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub SmallestSquareSizeIs2()
        Dim crypto = New Crypto("1234")
        Assert.That(crypto.Size, [Is].EqualTo(2))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub SizeOfTextWhoseLengthIsAPerfectSquareIsItsSquareRoot()
        Dim crypto = New Crypto("123456789")
        Assert.That(crypto.Size, [Is].EqualTo(3))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub SizeOfTextWhoseLengthIsNotAPerfectSquareIsNextBiggestSquareRoot()
        Dim crypto = New Crypto("123456789abc")
        Assert.That(crypto.Size, [Is].EqualTo(4))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub SizeIsDeterminedByNormalizedText()
        Dim crypto = New Crypto("Oh hey, this is nuts!")
        Assert.That(crypto.Size, [Is].EqualTo(4))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub SegmentsAreSplitBySquareSize()
        Dim crypto = New Crypto("Never vex thine heart with idle woes")
        Assert.That(crypto.PlaintextSegments(), [Is].EqualTo(New String() {"neverv", "exthin", "eheart", "withid", "lewoes"}))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub SegmentsAreSplitBySquareSizeUntilTextRunsOut()
        Dim crypto = New Crypto("ZOMG! ZOMBIES!!!")
        Assert.That(crypto.PlaintextSegments(), [Is].EqualTo(New String() {"zomg", "zomb", "ies"}))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub CiphertextCombinesTextByColumn()
        Dim crypto = New Crypto("First, solve the problem. Then, write the code.")
        Assert.That(crypto.Ciphertext(), [Is].EqualTo("foeewhilpmrervrticseohtottbeedshlnte"))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub CiphertextSkipsCellsWithNoText()
        Dim crypto = New Crypto("Time is an illusion. Lunchtime doubly so.")
        Assert.That(crypto.Ciphertext(), [Is].EqualTo("tasneyinicdsmiohooelntuillibsuuml"))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub NormalizedCiphertextIsSplitBy5()
        Dim crypto = New Crypto("Vampires are people too!")
        Assert.That(crypto.NormalizeCiphertext(), [Is].EqualTo("vrela epems etpao oirpo"))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub NormalizedCiphertextNotExactlyDivisibleBy5SpillsIntoASmallerSegment()
        Dim crypto = New Crypto("Madness, and then illumination.")
        Assert.That(crypto.NormalizeCiphertext(), [Is].EqualTo("msemo aanin dninn dlaet ltshu i"))
    End Sub
End Class
