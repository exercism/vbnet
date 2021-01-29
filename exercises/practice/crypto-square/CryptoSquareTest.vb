Imports NUnit.Framework

<TestFixture>
Public Class CryptoSquareTest
    <Test>
    Public Sub StrangeCharactersAreStrippedDuringNormalization()
        Dim crypto = New Crypto("s#$%^&plunk")
        Assert.That(crypto.NormalizePlaintext, [Is].EqualTo("splunk"))
    End Sub

    <Ignore>
    <Test>
    Public Sub LettersAreLowercasedDuringNormalization()
        Dim crypto = New Crypto("WHOA HEY!")
        Assert.That(crypto.NormalizePlaintext, [Is].EqualTo("whoahey"))
    End Sub

    <Ignore>
    <Test>
    Public Sub NumbersAreKeptDuringNormalization()
        Dim crypto = New Crypto("1, 2, 3, GO!")
        Assert.That(crypto.NormalizePlaintext, [Is].EqualTo("123go"))
    End Sub

    <Ignore>
    <Test>
    Public Sub SmallestSquareSizeIs2()
        Dim crypto = New Crypto("1234")
        Assert.That(crypto.Size, [Is].EqualTo(2))
    End Sub

    <Ignore>
    <Test>
    Public Sub SizeOfTextWhoseLengthIsAPerfectSquareIsItsSquareRoot()
        Dim crypto = New Crypto("123456789")
        Assert.That(crypto.Size, [Is].EqualTo(3))
    End Sub

    <Ignore>
    <Test>
    Public Sub SizeOfTextWhoseLengthIsNotAPerfectSquareIsNextBiggestSquareRoot()
        Dim crypto = New Crypto("123456789abc")
        Assert.That(crypto.Size, [Is].EqualTo(4))
    End Sub

    <Ignore>
    <Test>
    Public Sub SizeIsDeterminedByNormalizedText()
        Dim crypto = New Crypto("Oh hey, this is nuts!")
        Assert.That(crypto.Size, [Is].EqualTo(4))
    End Sub

    <Ignore>
    <Test>
    Public Sub SegmentsAreSplitBySquareSize()
        Dim crypto = New Crypto("Never vex thine heart with idle woes")
        Assert.That(crypto.PlaintextSegments(), [Is].EqualTo(New String() {"neverv", "exthin", "eheart", "withid", "lewoes"}))
    End Sub

    <Ignore>
    <Test>
    Public Sub SegmentsAreSplitBySquareSizeUntilTextRunsOut()
        Dim crypto = New Crypto("ZOMG! ZOMBIES!!!")
        Assert.That(crypto.PlaintextSegments(), [Is].EqualTo(New String() {"zomg", "zomb", "ies"}))
    End Sub

    <Ignore>
    <Test>
    Public Sub CiphertextCombinesTextByColumn()
        Dim crypto = New Crypto("First, solve the problem. Then, write the code.")
        Assert.That(crypto.Ciphertext(), [Is].EqualTo("foeewhilpmrervrticseohtottbeedshlnte"))
    End Sub

    <Ignore>
    <Test>
    Public Sub CiphertextSkipsCellsWithNoText()
        Dim crypto = New Crypto("Time is an illusion. Lunchtime doubly so.")
        Assert.That(crypto.Ciphertext(), [Is].EqualTo("tasneyinicdsmiohooelntuillibsuuml"))
    End Sub

    <Ignore>
    <Test>
    Public Sub NormalizedCiphertextIsSplitBy5()
        Dim crypto = New Crypto("Vampires are people too!")
        Assert.That(crypto.NormalizeCiphertext(), [Is].EqualTo("vrela epems etpao oirpo"))
    End Sub

    <Ignore>
    <Test>
    Public Sub NormalizedCiphertextNotExactlyDivisibleBy5SpillsIntoASmallerSegment()
        Dim crypto = New Crypto("Madness, and then illumination.")
        Assert.That(crypto.NormalizeCiphertext(), [Is].EqualTo("msemo aanin dninn dlaet ltshu i"))
    End Sub
End Class
