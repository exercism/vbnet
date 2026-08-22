Public Class AllYourBaseTests
    <Fact>
    Public Sub Single_bit_one_to_decimal()
        Dim digits As Integer() = {1}
        Dim expected As Integer() = {1}
        Assert.Equal(expected, Rebase(2, digits, 10))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Binary_to_single_decimal()
        Dim digits As Integer() = {1, 0, 1}
        Dim expected As Integer() = {5}
        Assert.Equal(expected, Rebase(2, digits, 10))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Single_decimal_to_binary()
        Dim digits As Integer() = {5}
        Dim expected As Integer() = {1, 0, 1}
        Assert.Equal(expected, Rebase(10, digits, 2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Binary_to_multiple_decimal()
        Dim digits As Integer() = {1, 0, 1, 0, 1, 0}
        Dim expected As Integer() = {4, 2}
        Assert.Equal(expected, Rebase(2, digits, 10))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Decimal_to_binary()
        Dim digits As Integer() = {4, 2}
        Dim expected As Integer() = {1, 0, 1, 0, 1, 0}
        Assert.Equal(expected, Rebase(10, digits, 2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Trinary_to_hexadecimal()
        Dim digits As Integer() = {1, 1, 2, 0}
        Dim expected As Integer() = {2, 10}
        Assert.Equal(expected, Rebase(3, digits, 16))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Hexadecimal_to_trinary()
        Dim digits As Integer() = {2, 10}
        Dim expected As Integer() = {1, 1, 2, 0}
        Assert.Equal(expected, Rebase(16, digits, 3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Fifteen_bit_integer()
        Dim digits As Integer() = {3, 46, 60}
        Dim expected As Integer() = {6, 10, 45}
        Assert.Equal(expected, Rebase(97, digits, 73))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Empty_list()
        Dim digits As Integer() = {}
        Dim expected As Integer() = {0}
        Assert.Equal(expected, Rebase(2, digits, 10))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Single_zero()
        Dim digits As Integer() = {0}
        Dim expected As Integer() = {0}
        Assert.Equal(expected, Rebase(10, digits, 2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_zeros()
        Dim digits As Integer() = {0, 0, 0}
        Dim expected As Integer() = {0}
        Assert.Equal(expected, Rebase(10, digits, 2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Leading_zeros()
        Dim digits As Integer() = {0, 6, 0}
        Dim expected As Integer() = {4, 2}
        Assert.Equal(expected, Rebase(7, digits, 10))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Input_base_is_one()
        Dim digits As Integer() = {0}
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() Rebase(1, digits, 10))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Input_base_is_zero()
        Dim digits As Integer() = {}
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() Rebase(0, digits, 10))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Input_base_is_negative()
        Dim digits As Integer() = {1}
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() Rebase(-2, digits, 10))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Negative_digit()
        Dim digits As Integer() = {1, -1, 1, 0, 1, 0}
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() Rebase(2, digits, 10))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_positive_digit()
        Dim digits As Integer() = {1, 2, 1, 0, 1, 0}
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() Rebase(2, digits, 10))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Output_base_is_one()
        Dim digits As Integer() = {1, 0, 1, 0, 1, 0}
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() Rebase(2, digits, 1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Output_base_is_zero()
        Dim digits As Integer() = {7}
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() Rebase(10, digits, 0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Output_base_is_negative()
        Dim digits As Integer() = {1}
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() Rebase(2, digits, -7))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Both_bases_are_negative()
        Dim digits As Integer() = {1}
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() Rebase(-2, digits, -7))
    End Sub
End Class
