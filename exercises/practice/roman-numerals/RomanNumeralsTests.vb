Public Class RomanNumeralsTests
    <Fact>
    Public Sub One_is_i()
        Assert.Equal("I", 1.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_is_ii()
        Assert.Equal("II", 2.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Three_is_iii()
        Assert.Equal("III", 3.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Four_is_iv()
        Assert.Equal("IV", 4.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Five_is_v()
        Assert.Equal("V", 5.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Six_is_vi()
        Assert.Equal("VI", 6.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Nine_is_ix()
        Assert.Equal("IX", 9.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sixteen_is_xvi()
        Assert.Equal("XVI", 16.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Twenty_seven_is_xxvii()
        Assert.Equal("XXVII", 27.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Forty_eight_is_xlviii()
        Assert.Equal("XLVIII", 48.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Forty_nine_is_xlix()
        Assert.Equal("XLIX", 49.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Fifty_nine_is_lix()
        Assert.Equal("LIX", 59.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sixty_six_is_lxvi()
        Assert.Equal("LXVI", 66.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ninety_three_is_xciii()
        Assert.Equal("XCIII", 93.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_hundred_and_forty_one_is_cxli()
        Assert.Equal("CXLI", 141.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_hundred_and_sixty_three_is_clxiii()
        Assert.Equal("CLXIII", 163.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_hundred_and_sixty_six_is_clxvi()
        Assert.Equal("CLXVI", 166.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Four_hundred_and_two_is_cdii()
        Assert.Equal("CDII", 402.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Five_hundred_and_seventy_five_is_dlxxv()
        Assert.Equal("DLXXV", 575.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Six_hundred_and_sixty_six_is_dclxvi()
        Assert.Equal("DCLXVI", 666.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Nine_hundred_and_eleven_is_cmxi()
        Assert.Equal("CMXI", 911.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_thousand_and_twenty_four_is_mxxiv()
        Assert.Equal("MXXIV", 1024.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_thousand_six_hundred_and_sixty_six_is_mdclxvi()
        Assert.Equal("MDCLXVI", 1666.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Three_thousand_is_mmm()
        Assert.Equal("MMM", 3000.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Three_thousand_and_one_is_mmmi()
        Assert.Equal("MMMI", 3001.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Three_thousand_eight_hundred_and_eighty_eight_is_mmmdccclxxxviii()
        Assert.Equal("MMMDCCCLXXXVIII", 3888.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Three_thousand_nine_hundred_and_ninety_nine_is_mmmcmxcix()
        Assert.Equal("MMMCMXCIX", 3999.ToRoman())
    End Sub
End Class
