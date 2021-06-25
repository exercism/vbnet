Imports XUnit

Public Class CryptoSquareTest
    <Fact>
    Public Sub StrangeCharactersAreStrippedDuringNormalization()
        Dim crypto = New Crypto("s#$%^&plunk")
        Assert.Equal(crypto.NormalizePlaintext, "splunk")
    End Sub

	<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub LettersAreLowercasedDuringNormalization()
        Dim crypto = New Crypto("WHOA HEY!")
        Assert.Equal(crypto.NormalizePlaintext, "whoahey")
    End Sub

	<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub NumbersAreKeptDuringNormalization()
        Dim crypto = New Crypto("1, 2, 3, GO!")
        Assert.Equal(crypto.NormalizePlaintext, "123go")
    End Sub

	<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub SmallestSquareSizeIs2()
        Dim crypto = New Crypto("1234")
        Assert.Equal(crypto.Size, 2)
    End Sub

	<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub SizeOfTextWhoseLengthIsAPerfectSquareIsItsSquareRoot()
        Dim crypto = New Crypto("123456789")
        Assert.Equal(crypto.Size, 3)
    End Sub

	<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub SizeOfTextWhoseLengthIsNotAPerfectSquareIsNextBiggestSquareRoot()
        Dim crypto = New Crypto("123456789abc")
        Assert.Equal(crypto.Size, 4)
    End Sub

	<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub SizeIsDeterminedByNormalizedText()
        Dim crypto = New Crypto("Oh hey, this is nuts!")
        Assert.Equal(crypto.Size, 4)
    End Sub

	<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub SegmentsAreSplitBySquareSize()
        Dim crypto = New Crypto("Never vex thine heart with idle woes")
        Assert.Equal(crypto.PlaintextSegments(), New String() {"neverv", "exthin", "eheart", "withid", "lewoes"})
    End Sub

	<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub SegmentsAreSplitBySquareSizeUntilTextRunsOut()
        Dim crypto = New Crypto("ZOMG! ZOMBIES!!!")
        Assert.Equal(crypto.PlaintextSegments(), New String() {"zomg", "zomb", "ies"})
    End Sub

	<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub CiphertextCombinesTextByColumn()
        Dim crypto = New Crypto("First, solve the problem. Then, write the code.")
        Assert.Equal(crypto.Ciphertext(), "foeewhilpmrervrticseohtottbeedshlnte")
    End Sub

	<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub CiphertextSkipsCellsWithNoText()
        Dim crypto = New Crypto("Time is an illusion. Lunchtime doubly so.")
        Assert.Equal(crypto.Ciphertext(), "tasneyinicdsmiohooelntuillibsuuml")
    End Sub

	<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub NormalizedCiphertextIsSplitBy5()
        Dim crypto = New Crypto("Vampires are people too!")
        Assert.Equal(crypto.NormalizeCiphertext(), "vrela epems etpao oirpo")
    End Sub

	<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub NormalizedCiphertextNotExactlyDivisibleBy5SpillsIntoASmallerSegment()
        Dim crypto = New Crypto("Madness, and then illumination.")
        Assert.Equal(crypto.NormalizeCiphertext(), "msemo aanin dninn dlaet ltshu i")
    End Sub
End Class
