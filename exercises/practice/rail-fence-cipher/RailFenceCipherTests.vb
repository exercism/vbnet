Imports Xunit

Public Class RailFenceCipherTests
    <Fact>
    Public Sub Encode_with_two_rails()
        Dim msg = "XOXOXOXOXOXOXOXOXO"
        Dim sut = New RailFenceCipher(2)
        Dim expected = "XXXXXXXXXOOOOOOOOO"
        Assert.Equal(expected, sut.Encode(msg))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Encode_with_three_rails()
        Dim msg = "WEAREDISCOVEREDFLEEATONCE"
        Dim sut = New RailFenceCipher(3)
        Dim expected = "WECRLTEERDSOEEFEAOCAIVDEN"
        Assert.Equal(expected, sut.Encode(msg))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Encode_with_ending_in_the_middle()
        Dim msg = "EXERCISES"
        Dim sut = New RailFenceCipher(4)
        Dim expected = "ESXIEECSR"
        Assert.Equal(expected, sut.Encode(msg))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Decode_with_three_rails()
        Dim msg = "TEITELHDVLSNHDTISEIIEA"
        Dim sut = New RailFenceCipher(3)
        Dim expected = "THEDEVILISINTHEDETAILS"
        Assert.Equal(expected, sut.Decode(msg))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Decode_with_five_rails()
        Dim msg = "EIEXMSMESAORIWSCE"
        Dim sut = New RailFenceCipher(5)
        Dim expected = "EXERCISMISAWESOME"
        Assert.Equal(expected, sut.Decode(msg))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Decode_with_six_rails()
        Dim msg = "133714114238148966225439541018335470986172518171757571896261"
        Dim sut = New RailFenceCipher(6)
        Dim expected = "112358132134558914423337761098715972584418167651094617711286"
        Assert.Equal(expected, sut.Decode(msg))
    End Sub
End Class
