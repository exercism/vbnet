Imports Xunit

Public Class RomanNumeralsTests
    <Fact>
    Public Sub Number_1_is_i()
        Assert.Equal("I", 1.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number_2_is_ii()
        Assert.Equal("II", 2.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number_3_is_iii()
        Assert.Equal("III", 3.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number_4_is_iv()
        Assert.Equal("IV", 4.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number_5_is_v()
        Assert.Equal("V", 5.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number_6_is_vi()
        Assert.Equal("VI", 6.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number_9_is_ix()
        Assert.Equal("IX", 9.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number_16_is_xvi()
        Assert.Equal("XVI", 16.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number_27_is_xxvii()
        Assert.Equal("XXVII", 27.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number_48_is_xlviii()
        Assert.Equal("XLVIII", 48.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number_49_is_xlix()
        Assert.Equal("XLIX", 49.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number_59_is_lix()
        Assert.Equal("LIX", 59.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number_66_is_lix()
        Assert.Equal("LXVI", 66.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number_93_is_xciii()
        Assert.Equal("XCIII", 93.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number_141_is_cxli()
        Assert.Equal("CXLI", 141.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number_163_is_clxiii()
        Assert.Equal("CLXIII", 163.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number_166_is_clxvi()
        Assert.Equal("CLXVI", 166.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number_402_is_cdii()
        Assert.Equal("CDII", 402.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number_575_is_dlxxv()
        Assert.Equal("DLXXV", 575.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number_666_is_dclxvi()
        Assert.Equal("DCLXVI", 666.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number_911_is_cmxi()
        Assert.Equal("CMXI", 911.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number_1024_is_mxxiv()
        Assert.Equal("MXXIV", 1024.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number_1666_is_mdclxvi()
        Assert.Equal("MDCLXVI", 1666.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number_3000_is_mmm()
        Assert.Equal("MMM", 3000.ToRoman())
    End Sub
    
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number_3001_is_mmmi()
        Assert.Equal("MMMI", 3001.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number_3888_is_mmmdccclxxxviii()
        Assert.Equal("MMMDCCCLXXXVIII", 3888.ToRoman())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number_3999_is_mmmcmxcix()
        Assert.Equal("MMMCMXCIX", 3999.ToRoman())
    End Sub
End Class
