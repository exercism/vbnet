Imports NUnit.Framework

<TestFixture>
Public Class CryptoSquareTest
    <Test>
    Public Sub Strange_characters_are_stripped_during_normalization()
        Dim crypto = New Crypto("s#$%^&plunk")
        Assert.That(crypto.NormalizePlaintext, [Is].EqualTo("splunk"))
    End Sub

    <Ignore>
    <Test>
    Public Sub Letters_are_lowercased_during_normalization()
        Dim crypto = New Crypto("WHOA HEY!")
        Assert.That(crypto.NormalizePlaintext, [Is].EqualTo("whoahey"))
    End Sub

    <Ignore>
    <Test>
    Public Sub Numbers_are_kept_during_normalization()
        Dim crypto = New Crypto("1, 2, 3, GO!")
        Assert.That(crypto.NormalizePlaintext, [Is].EqualTo("123go"))
    End Sub

    <Ignore>
    <Test>
    Public Sub Smallest_square_size_is_2()
        Dim crypto = New Crypto("1234")
        Assert.That(crypto.Size, [Is].EqualTo(2))
    End Sub

    <Ignore>
    <Test>
    Public Sub Size_of_text_whose_length_is_a_perfect_square_is_its_square_root()
        Dim crypto = New Crypto("123456789")
        Assert.That(crypto.Size, [Is].EqualTo(3))
    End Sub

    <Ignore>
    <Test>
    Public Sub Size_of_text_whose_length_is_not_a_perfect_square_is_next_biggest_square_root()
        Dim crypto = New Crypto("123456789abc")
        Assert.That(crypto.Size, [Is].EqualTo(4))
    End Sub

    <Ignore>
    <Test>
    Public Sub Size_is_determined_by_normalized_text()
        Dim crypto = New Crypto("Oh hey, this is nuts!")
        Assert.That(crypto.Size, [Is].EqualTo(4))
    End Sub

    <Ignore>
    <Test>
    Public Sub Segments_are_split_by_square_size()
        Dim crypto = New Crypto("Never vex thine heart with idle woes")
        Assert.That(crypto.PlaintextSegments(), [Is].EqualTo(New String() {"neverv", "exthin", "eheart", "withid", "lewoes"}))
    End Sub

    <Ignore>
    <Test>
    Public Sub Segments_are_split_by_square_size_until_text_runs_out()
        Dim crypto = New Crypto("ZOMG! ZOMBIES!!!")
        Assert.That(crypto.PlaintextSegments(), [Is].EqualTo(New String() {"zomg", "zomb", "ies"}))
    End Sub

    <Ignore>
    <Test>
    Public Sub Ciphertext_combines_text_by_column()
        Dim crypto = New Crypto("First, solve the problem. Then, write the code.")
        Assert.That(crypto.Ciphertext(), [Is].EqualTo("foeewhilpmrervrticseohtottbeedshlnte"))
    End Sub

    <Ignore>
    <Test>
    Public Sub Ciphertext_skips_cells_with_no_text()
        Dim crypto = New Crypto("Time is an illusion. Lunchtime doubly so.")
        Assert.That(crypto.Ciphertext(), [Is].EqualTo("tasneyinicdsmiohooelntuillibsuuml"))
    End Sub

    <Ignore>
    <Test>
    Public Sub Normalized_ciphertext_is_split_by_5()
        Dim crypto = New Crypto("Vampires are people too!")
        Assert.That(crypto.NormalizeCiphertext(), [Is].EqualTo("vrela epems etpao oirpo"))
    End Sub

    <Ignore>
    <Test>
    Public Sub Normalized_ciphertext_not_exactly_divisible_by_5_spills_into_a_smaller_segment()
        Dim crypto = New Crypto("Madness, and then illumination.")
        Assert.That(crypto.NormalizeCiphertext(), [Is].EqualTo("msemo aanin dninn dlaet ltshu i"))
    End Sub
End Class
