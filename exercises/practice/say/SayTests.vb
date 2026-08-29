Public Class SayTests
    <Fact>
    Public Sub Zero()
        Dim expected = "zero"
        Assert.Equal(expected, Say.InEnglish(0L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One()
        Dim expected = "one"
        Assert.Equal(expected, Say.InEnglish(1L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Fourteen()
        Dim expected = "fourteen"
        Assert.Equal(expected, Say.InEnglish(14L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Twenty()
        Dim expected = "twenty"
        Assert.Equal(expected, Say.InEnglish(20L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Twenty_two()
        Dim expected = "twenty-two"
        Assert.Equal(expected, Say.InEnglish(22L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Thirty()
        Dim expected = "thirty"
        Assert.Equal(expected, Say.InEnglish(30L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ninety_nine()
        Dim expected = "ninety-nine"
        Assert.Equal(expected, Say.InEnglish(99L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_hundred()
        Dim expected = "one hundred"
        Assert.Equal(expected, Say.InEnglish(100L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_hundred_twenty_three()
        Dim expected = "one hundred twenty-three"
        Assert.Equal(expected, Say.InEnglish(123L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_hundred()
        Dim expected = "two hundred"
        Assert.Equal(expected, Say.InEnglish(200L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Nine_hundred_ninety_nine()
        Dim expected = "nine hundred ninety-nine"
        Assert.Equal(expected, Say.InEnglish(999L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_thousand()
        Dim expected = "one thousand"
        Assert.Equal(expected, Say.InEnglish(1000L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_thousand_two_hundred_thirty_four()
        Dim expected = "one thousand two hundred thirty-four"
        Assert.Equal(expected, Say.InEnglish(1234L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_million()
        Dim expected = "one million"
        Assert.Equal(expected, Say.InEnglish(1000000L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_million_two_thousand_three_hundred_forty_five()
        Dim expected = "one million two thousand three hundred forty-five"
        Assert.Equal(expected, Say.InEnglish(1002345L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_billion()
        Dim expected = "one billion"
        Assert.Equal(expected, Say.InEnglish(1000000000L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_big_number()
        Dim expected = "nine hundred eighty-seven billion six hundred fifty-four million three hundred twenty-one thousand one hundred twenty-three"
        Assert.Equal(expected, Say.InEnglish(987654321123L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Numbers_below_zero_are_out_of_range()
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() Say.InEnglish(-1L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Numbers_above_999_999_999_999_are_out_of_range()
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() Say.InEnglish(1000000000000L))
    End Sub
End Class
