Imports Xunit

Public Class SimpleCipherTests
    <Fact>
    Public Sub Random_key_cipher_can_encode()
        Dim sut = New SimpleCipher()
        Assert.Equal(sut.Key.Substring(0, 10), sut.Encode("aaaaaaaaaa"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Random_key_cipher_can_decode()
        Dim sut = New SimpleCipher()
        Assert.Equal("aaaaaaaaaa", sut.Decode(sut.Key.Substring(0, 10)))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Random_key_cipher_is_reversible_i_e_if_you_apply_decode_in_a_encoded_result_you_must_see_the_same_plaintext_encode_parameter_as_a_result_of_the_decode_method()
        Dim sut = New SimpleCipher()
        Assert.Equal("abcdefghij", sut.Decode(sut.Encode("abcdefghij")))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Random_key_cipher_key_is_made_only_of_lowercase_letters()
        Dim sut = New SimpleCipher()
        Assert.Matches("^[a-z]+$", sut.Key)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Substitution_cipher_can_encode()
        Dim sut = New SimpleCipher("abcdefghij")
        Assert.Equal("abcdefghij", sut.Encode("aaaaaaaaaa"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Substitution_cipher_can_decode()
        Dim sut = New SimpleCipher("abcdefghij")
        Assert.Equal("aaaaaaaaaa", sut.Decode("abcdefghij"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Substitution_cipher_is_reversible_i_e_if_you_apply_decode_in_a_encoded_result_you_must_see_the_same_plaintext_encode_parameter_as_a_result_of_the_decode_method()
        Dim sut = New SimpleCipher("abcdefghij")
        Assert.Equal("abcdefghij", sut.Decode(sut.Encode("abcdefghij")))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Substitution_cipher_can_double_shift_encode()
        Dim sut = New SimpleCipher("iamapandabear")
        Assert.Equal("qayaeaagaciai", sut.Encode("iamapandabear"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Substitution_cipher_can_wrap_on_encode()
        Dim sut = New SimpleCipher("abcdefghij")
        Assert.Equal("zabcdefghi", sut.Encode("zzzzzzzzzz"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Substitution_cipher_can_wrap_on_decode()
        Dim sut = New SimpleCipher("abcdefghij")
        Assert.Equal("zzzzzzzzzz", sut.Decode("zabcdefghi"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Substitution_cipher_can_encode_messages_longer_than_the_key()
        Dim sut = New SimpleCipher("abc")
        Assert.Equal("iboaqcnecbfcr", sut.Encode("iamapandabear"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Substitution_cipher_can_decode_messages_longer_than_the_key()
        Dim sut = New SimpleCipher("abc")
        Assert.Equal("iamapandabear", sut.Decode("iboaqcnecbfcr"))
    End Sub
End Class
