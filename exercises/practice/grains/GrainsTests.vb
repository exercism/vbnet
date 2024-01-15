Imports System
Imports Xunit

Public Class GrainsTests
    <Fact>
    Public Sub Grains_on_square_1()
        Assert.Equal(1UL, Square(1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Grains_on_square_2()
        Assert.Equal(2UL, Square(2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Grains_on_square_3()
        Assert.Equal(4UL, Square(3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Grains_on_square_4()
        Assert.Equal(8UL, Square(4))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Grains_on_square_16()
        Assert.Equal(32768UL, Square(16))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Grains_on_square_32()
        Assert.Equal(2147483648UL, Square(32))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Grains_on_square_64()
        Assert.Equal(9223372036854775808UL, Square(64))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Square_0_raises_an_exception()
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() Square(0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Negative_square_raises_an_exception()
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() Square(-1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Square_greater_than_64_raises_an_exception()
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() Square(65))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Returns_the_total_number_of_grains_on_the_board()
        Assert.Equal(18446744073709551615UL, Total())
    End Sub
End Class
