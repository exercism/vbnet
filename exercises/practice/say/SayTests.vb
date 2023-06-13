Imports System
Imports Xunit

Public Class SayTests
    <Fact>
    Public Sub Zero()
        Assert.Equal("zero", InEnglish(0L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One()
        Assert.Equal("one", InEnglish(1L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Fourteen()
        Assert.Equal("fourteen", InEnglish(14L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Twenty()
        Assert.Equal("twenty", InEnglish(20L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Twenty_two()
        Assert.Equal("twenty-two", InEnglish(22L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Thirty()
        Assert.Equal("thirty", InEnglish(30L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ninety_nine()
        Assert.Equal("ninety-nine", InEnglish(99L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_hundred()
        Assert.Equal("one hundred", InEnglish(100L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_hundred_twenty_three()
        Assert.Equal("one hundred twenty-three", InEnglish(123L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_hundred()
        Assert.Equal("two hundred", InEnglish(200L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Nine_hundred_ninety_nine()
        Assert.Equal("nine hundred ninety-nine", InEnglish(999L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_thousand()
        Assert.Equal("one thousand", InEnglish(1000L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_thousand_two_hundred_thirty_four()
        Assert.Equal("one thousand two hundred thirty-four", InEnglish(1234L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_million()
        Assert.Equal("one million", InEnglish(1000000L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_million_two_thousand_three_hundred_forty_five()
        Assert.Equal("one million two thousand three hundred forty-five", InEnglish(1002345L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_billion()
        Assert.Equal("one billion", InEnglish(1000000000L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_big_number()
        Assert.Equal("nine hundred eighty-seven billion six hundred fifty-four million three hundred twenty-one thousand one hundred twenty-three", InEnglish(987654321123L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Numbers_below_zero_are_out_of_range()
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() InEnglish(-1L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Numbers_above_999_999_999_999_are_out_of_range()
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() InEnglish(1000000000000L))
    End Sub
End Class
