Imports Xunit

Public Class RunLengthEncodingTests
    <Fact>
    Public Sub Run_length_encode_a_string_empty_string()
        Assert.Equal("", Encode(""))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Run_length_encode_a_string_single_characters_only_are_encoded_without_count()
        Assert.Equal("XYZ", Encode("XYZ"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Run_length_encode_a_string_string_with_no_single_characters()
        Assert.Equal("2A3B4C", Encode("AABBBCCCC"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Run_length_encode_a_string_single_characters_mixed_with_repeated_characters()
        Assert.Equal("12WB12W3B24WB", Encode("WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Run_length_encode_a_string_multiple_whitespace_mixed_in_string()
        Assert.Equal("2 hs2q q2w2 ", Encode("  hsqq qww  "))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Run_length_encode_a_string_lowercase_characters()
        Assert.Equal("2a3b4c", Encode("aabbbcccc"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Run_length_decode_a_string_empty_string()
        Assert.Equal("", Decode(""))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Run_length_decode_a_string_single_characters_only()
        Assert.Equal("XYZ", Decode("XYZ"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Run_length_decode_a_string_string_with_no_single_characters()
        Assert.Equal("AABBBCCCC", Decode("2A3B4C"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Run_length_decode_a_string_single_characters_with_repeated_characters()
        Assert.Equal("WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB", Decode("12WB12W3B24WB"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Run_length_decode_a_string_multiple_whitespace_mixed_in_string()
        Assert.Equal("  hsqq qww  ", Decode("2 hs2q q2w2 "))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Run_length_decode_a_string_lowercase_string()
        Assert.Equal("aabbbcccc", Decode("2a3b4c"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Encode_and_then_decode_encode_followed_by_decode_gives_original_string()
        Assert.Equal("zzz ZZ  zZ", Decode(Encode("zzz ZZ  zZ")))
    End Sub
End Class
