Public Class GrainsTests
    <Fact>
    Public Sub Grains_on_square_1()
        Assert.Equal(1UL, Grains.Square(1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Grains_on_square_2()
        Assert.Equal(2UL, Grains.Square(2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Grains_on_square_3()
        Assert.Equal(4UL, Grains.Square(3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Grains_on_square_4()
        Assert.Equal(8UL, Grains.Square(4))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Grains_on_square_16()
        Assert.Equal(32768UL, Grains.Square(16))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Grains_on_square_32()
        Assert.Equal(2147483648UL, Grains.Square(32))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Grains_on_square_64()
        Assert.Equal(9223372036854775808UL, Grains.Square(64))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Square_0_is_invalid()
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() Grains.Square(0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Negative_square_is_invalid()
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() Grains.Square(-1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Square_greater_than_64_is_invalid()
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() Grains.Square(65))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Returns_the_total_number_of_grains_on_the_board()
        Assert.Equal(18446744073709551615UL, Grains.Total())
    End Sub
End Class
