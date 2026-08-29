Public Class RunLengthEncodingTests
    <Fact>
    Public Sub Run_length_encode_a_string_empty_string()
        Dim input = ""
        Dim expected = ""
        Assert.Equal(expected, RunLengthEncoding.Encode(input))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Run_length_encode_a_string_single_characters_only_are_encoded_without_count()
        Dim input = "XYZ"
        Dim expected = "XYZ"
        Assert.Equal(expected, RunLengthEncoding.Encode(input))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Run_length_encode_a_string_string_with_no_single_characters()
        Dim input = "AABBBCCCC"
        Dim expected = "2A3B4C"
        Assert.Equal(expected, RunLengthEncoding.Encode(input))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Run_length_encode_a_string_single_characters_mixed_with_repeated_characters()
        Dim input = "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB"
        Dim expected = "12WB12W3B24WB"
        Assert.Equal(expected, RunLengthEncoding.Encode(input))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Run_length_encode_a_string_multiple_whitespace_mixed_in_string()
        Dim input = "  hsqq qww  "
        Dim expected = "2 hs2q q2w2 "
        Assert.Equal(expected, RunLengthEncoding.Encode(input))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Run_length_encode_a_string_lowercase_characters()
        Dim input = "aabbbcccc"
        Dim expected = "2a3b4c"
        Assert.Equal(expected, RunLengthEncoding.Encode(input))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Run_length_decode_a_string_empty_string()
        Dim input = ""
        Dim expected = ""
        Assert.Equal(expected, RunLengthEncoding.Decode(input))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Run_length_decode_a_string_single_characters_only()
        Dim input = "XYZ"
        Dim expected = "XYZ"
        Assert.Equal(expected, RunLengthEncoding.Decode(input))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Run_length_decode_a_string_string_with_no_single_characters()
        Dim input = "2A3B4C"
        Dim expected = "AABBBCCCC"
        Assert.Equal(expected, RunLengthEncoding.Decode(input))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Run_length_decode_a_string_single_characters_with_repeated_characters()
        Dim input = "12WB12W3B24WB"
        Dim expected = "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB"
        Assert.Equal(expected, RunLengthEncoding.Decode(input))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Run_length_decode_a_string_multiple_whitespace_mixed_in_string()
        Dim input = "2 hs2q q2w2 "
        Dim expected = "  hsqq qww  "
        Assert.Equal(expected, RunLengthEncoding.Decode(input))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Run_length_decode_a_string_lowercase_string()
        Dim input = "2a3b4c"
        Dim expected = "aabbbcccc"
        Assert.Equal(expected, RunLengthEncoding.Decode(input))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Encode_and_then_decode_encode_followed_by_decode_gives_original_string()
        Dim input = "zzz ZZ  zZ"
        Dim expected = "zzz ZZ  zZ"
        Assert.Equal(expected, RunLengthEncoding.Decode(RunLengthEncoding.Encode(input)))
    End Sub
End Class
