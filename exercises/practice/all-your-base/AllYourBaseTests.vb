Imports System
Imports Xunit
Public Class AllYourBaseTests
    <Fact>
    Public Sub SingleBitOneToDecimal()
        Dim inputBase = 2
        Dim digits = {1}
        Dim outputBase = 10
        Dim expected = {1}
        Assert.Equal(expected, Rebase(inputBase, digits, outputBase))
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub BinaryToSingleDecimal()
        Dim inputBase = 2
        Dim digits = {1, 0, 1}
        Dim outputBase = 10
        Dim expected = {5}
        Assert.Equal(expected, Rebase(inputBase, digits, outputBase))
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub SingleDecimalToBinary()
        Dim inputBase = 10
        Dim digits = {5}
        Dim outputBase = 2
        Dim expected = {1, 0, 1}
        Assert.Equal(expected, Rebase(inputBase, digits, outputBase))
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub BinaryToMultipleDecimal()
        Dim inputBase = 2
        Dim digits = {1, 0, 1, 0, 1, 0}
        Dim outputBase = 10
        Dim expected = {4, 2}
        Assert.Equal(expected, Rebase(inputBase, digits, outputBase))
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub DecimalToBinary()
        Dim inputBase = 10
        Dim digits = {4, 2}
        Dim outputBase = 2
        Dim expected = {1, 0, 1, 0, 1, 0}
        Assert.Equal(expected, Rebase(inputBase, digits, outputBase))
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub TrinaryToHexadecimal()
        Dim inputBase = 3
        Dim digits = {1, 1, 2, 0}
        Dim outputBase = 16
        Dim expected = {2, 10}
        Assert.Equal(expected, Rebase(inputBase, digits, outputBase))
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub HexadecimalToTrinary()
        Dim inputBase = 16
        Dim digits = {2, 10}
        Dim outputBase = 3
        Dim expected = {1, 1, 2, 0}
        Assert.Equal(expected, Rebase(inputBase, digits, outputBase))
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number15BitInteger()
        Dim inputBase = 97
        Dim digits = {3, 46, 60}
        Dim outputBase = 73
        Dim expected = {6, 10, 45}
        Assert.Equal(expected, Rebase(inputBase, digits, outputBase))
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub EmptyList()
        Dim inputBase = 2
        Dim digits = Array.Empty(Of Integer)()
        Dim outputBase = 10
        Dim expected = {0}
        Assert.Equal(expected, Rebase(inputBase, digits, outputBase))
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub SingleZero()
        Dim inputBase = 10
        Dim digits = {0}
        Dim outputBase = 2
        Dim expected = {0}
        Assert.Equal(expected, Rebase(inputBase, digits, outputBase))
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub MultipleZeros()
        Dim inputBase = 10
        Dim digits = {0, 0, 0}
        Dim outputBase = 2
        Dim expected = {0}
        Assert.Equal(expected, Rebase(inputBase, digits, outputBase))
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub LeadingZeros()
        Dim inputBase = 7
        Dim digits = {0, 6, 0}
        Dim outputBase = 10
        Dim expected = {4, 2}
        Assert.Equal(expected, Rebase(inputBase, digits, outputBase))
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub InputBaseIsOne()
        Dim inputBase = 1
        Dim digits = {0}
        Dim outputBase = 10
        Assert.Throws(Of ArgumentException)(Function() Rebase(inputBase, digits, outputBase))
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub InputBaseIsZero()
        Dim inputBase = 0
        Dim digits = Array.Empty(Of Integer)()
        Dim outputBase = 10
        Assert.Throws(Of ArgumentException)(Function() Rebase(inputBase, digits, outputBase))
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub InputBaseIsNegative()
        Dim inputBase = -2
        Dim digits = {1}
        Dim outputBase = 10
        Assert.Throws(Of ArgumentException)(Function() Rebase(inputBase, digits, outputBase))
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub NegativeDigit()
        Dim inputBase = 2
        Dim digits = {1, -1, 1, 0, 1, 0}
        Dim outputBase = 10
        Assert.Throws(Of ArgumentException)(Function() Rebase(inputBase, digits, outputBase))
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub InvalidPositiveDigit()
        Dim inputBase = 2
        Dim digits = {1, 2, 1, 0, 1, 0}
        Dim outputBase = 10
        Assert.Throws(Of ArgumentException)(Function() Rebase(inputBase, digits, outputBase))
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub OutputBaseIsOne()
        Dim inputBase = 2
        Dim digits = {1, 0, 1, 0, 1, 0}
        Dim outputBase = 1
        Assert.Throws(Of ArgumentException)(Function() Rebase(inputBase, digits, outputBase))
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub OutputBaseIsZero()
        Dim inputBase = 10
        Dim digits = {7}
        Dim outputBase = 0
        Assert.Throws(Of ArgumentException)(Function() Rebase(inputBase, digits, outputBase))
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub OutputBaseIsNegative()
        Dim inputBase = 2
        Dim digits = {1}
        Dim outputBase = -7
        Assert.Throws(Of ArgumentException)(Function() Rebase(inputBase, digits, outputBase))
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub BothBasesAreNegative()
        Dim inputBase = -2
        Dim digits = {1}
        Dim outputBase = -7
        Assert.Throws(Of ArgumentException)(Function() Rebase(inputBase, digits, outputBase))
    End Sub
End Class