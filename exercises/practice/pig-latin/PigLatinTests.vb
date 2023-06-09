Imports Xunit

Public Class PigLatinTests
    <Fact>
    Public Sub Word_beginning_with_a()
        Assert.Equal("appleay", PigLatin.Translate("apple"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Word_beginning_with_e()
        Assert.Equal("earay", PigLatin.Translate("ear"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Word_beginning_with_i()
        Assert.Equal("iglooay", PigLatin.Translate("igloo"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Word_beginning_with_o()
        Assert.Equal("objectay", PigLatin.Translate("object"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Word_beginning_with_u()
        Assert.Equal("underay", PigLatin.Translate("under"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Word_beginning_with_a_vowel_and_followed_by_a_qu()
        Assert.Equal("equalay", PigLatin.Translate("equal"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Word_beginning_with_p()
        Assert.Equal("igpay", PigLatin.Translate("pig"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Word_beginning_with_k()
        Assert.Equal("oalakay", PigLatin.Translate("koala"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Word_beginning_with_x()
        Assert.Equal("enonxay", PigLatin.Translate("xenon"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Word_beginning_with_q_without_a_following_u()
        Assert.Equal("atqay", PigLatin.Translate("qat"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Word_beginning_with_ch()
        Assert.Equal("airchay", PigLatin.Translate("chair"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Word_beginning_with_qu()
        Assert.Equal("eenquay", PigLatin.Translate("queen"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Word_beginning_with_qu_and_a_preceding_consonant()
        Assert.Equal("aresquay", PigLatin.Translate("square"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Word_beginning_with_th()
        Assert.Equal("erapythay", PigLatin.Translate("therapy"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Word_beginning_with_thr()
        Assert.Equal("ushthray", PigLatin.Translate("thrush"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Word_beginning_with_sch()
        Assert.Equal("oolschay", PigLatin.Translate("school"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Word_beginning_with_yt()
        Assert.Equal("yttriaay", PigLatin.Translate("yttria"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Word_beginning_with_xr()
        Assert.Equal("xrayay", PigLatin.Translate("xray"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Y_is_treated_like_a_consonant_at_the_beginning_of_a_word()
        Assert.Equal("ellowyay", PigLatin.Translate("yellow"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Y_is_treated_like_a_vowel_at_the_end_of_a_consonant_cluster()
        Assert.Equal("ythmrhay", PigLatin.Translate("rhythm"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Y_as_second_letter_in_two_letter_word()
        Assert.Equal("ymay", PigLatin.Translate("my"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_whole_phrase()
        Assert.Equal("ickquay astfay unray", PigLatin.Translate("quick fast run"))
    End Sub
End Class
