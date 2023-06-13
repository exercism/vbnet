Imports System
Imports Xunit

Public Class ComplexNumbersTests
    <Fact>
    Public Sub Real_part_of_a_purely_real_number()
        Dim sut = New ComplexNumber(1, 0)
        Assert.Equal(1, sut.Real())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Real_part_of_a_purely_imaginary_number()
        Dim sut = New ComplexNumber(0, 1)
        Assert.Equal(0, sut.Real())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Real_part_of_a_number_with_real_and_imaginary_part()
        Dim sut = New ComplexNumber(1, 2)
        Assert.Equal(1, sut.Real())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Imaginary_part_of_a_purely_real_number()
        Dim sut = New ComplexNumber(1, 0)
        Assert.Equal(0, sut.Imaginary())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Imaginary_part_of_a_purely_imaginary_number()
        Dim sut = New ComplexNumber(0, 1)
        Assert.Equal(1, sut.Imaginary())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Imaginary_part_of_a_number_with_real_and_imaginary_part()
        Dim sut = New ComplexNumber(1, 2)
        Assert.Equal(2, sut.Imaginary())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Imaginary_unit()
        Dim sut = New ComplexNumber(0, 1)
        Dim expected = New ComplexNumber(-1, 0)
        Assert.Equal(expected.Real(), sut.Mul(CType(New ComplexNumber(CDbl(0), CDbl(1)), ComplexNumber)).Real(), precision:=7)
        Assert.Equal(expected.Imaginary(), sut.Mul(CType(New ComplexNumber(CDbl(0), CDbl(1)), ComplexNumber)).Imaginary(), precision:=7)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Add_purely_real_numbers()
        Dim sut = New ComplexNumber(1, 0)
        Dim expected = New ComplexNumber(3, 0)
        Assert.Equal(expected.Real(), sut.Add(CType(New ComplexNumber(CDbl(2), CDbl(0)), ComplexNumber)).Real(), precision:=7)
        Assert.Equal(expected.Imaginary(), sut.Add(CType(New ComplexNumber(CDbl(2), CDbl(0)), ComplexNumber)).Imaginary(), precision:=7)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Add_purely_imaginary_numbers()
        Dim sut = New ComplexNumber(0, 1)
        Dim expected = New ComplexNumber(0, 3)
        Assert.Equal(expected.Real(), sut.Add(CType(New ComplexNumber(CDbl(0), CDbl(2)), ComplexNumber)).Real(), precision:=7)
        Assert.Equal(expected.Imaginary(), sut.Add(CType(New ComplexNumber(CDbl(0), CDbl(2)), ComplexNumber)).Imaginary(), precision:=7)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Add_numbers_with_real_and_imaginary_part()
        Dim sut = New ComplexNumber(1, 2)
        Dim expected = New ComplexNumber(4, 6)
        Assert.Equal(expected.Real(), sut.Add(CType(New ComplexNumber(CDbl(3), CDbl(4)), ComplexNumber)).Real(), precision:=7)
        Assert.Equal(expected.Imaginary(), sut.Add(CType(New ComplexNumber(CDbl(3), CDbl(4)), ComplexNumber)).Imaginary(), precision:=7)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Subtract_purely_real_numbers()
        Dim sut = New ComplexNumber(1, 0)
        Dim expected = New ComplexNumber(-1, 0)
        Assert.Equal(expected.Real(), sut.Sub(CType(New ComplexNumber(CDbl(2), CDbl(0)), ComplexNumber)).Real(), precision:=7)
        Assert.Equal(expected.Imaginary(), sut.Sub(CType(New ComplexNumber(CDbl(2), CDbl(0)), ComplexNumber)).Imaginary(), precision:=7)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Subtract_purely_imaginary_numbers()
        Dim sut = New ComplexNumber(0, 1)
        Dim expected = New ComplexNumber(0, -1)
        Assert.Equal(expected.Real(), sut.Sub(CType(New ComplexNumber(CDbl(0), CDbl(2)), ComplexNumber)).Real(), precision:=7)
        Assert.Equal(expected.Imaginary(), sut.Sub(CType(New ComplexNumber(CDbl(0), CDbl(2)), ComplexNumber)).Imaginary(), precision:=7)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Subtract_numbers_with_real_and_imaginary_part()
        Dim sut = New ComplexNumber(1, 2)
        Dim expected = New ComplexNumber(-2, -2)
        Assert.Equal(expected.Real(), sut.Sub(CType(New ComplexNumber(CDbl(3), CDbl(4)), ComplexNumber)).Real(), precision:=7)
        Assert.Equal(expected.Imaginary(), sut.Sub(CType(New ComplexNumber(CDbl(3), CDbl(4)), ComplexNumber)).Imaginary(), precision:=7)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiply_purely_real_numbers()
        Dim sut = New ComplexNumber(1, 0)
        Dim expected = New ComplexNumber(2, 0)
        Assert.Equal(expected.Real(), sut.Mul(CType(New ComplexNumber(CDbl(2), CDbl(0)), ComplexNumber)).Real(), precision:=7)
        Assert.Equal(expected.Imaginary(), sut.Mul(CType(New ComplexNumber(CDbl(2), CDbl(0)), ComplexNumber)).Imaginary(), precision:=7)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiply_purely_imaginary_numbers()
        Dim sut = New ComplexNumber(0, 1)
        Dim expected = New ComplexNumber(-2, 0)
        Assert.Equal(expected.Real(), sut.Mul(CType(New ComplexNumber(CDbl(0), CDbl(2)), ComplexNumber)).Real(), precision:=7)
        Assert.Equal(expected.Imaginary(), sut.Mul(CType(New ComplexNumber(CDbl(0), CDbl(2)), ComplexNumber)).Imaginary(), precision:=7)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiply_numbers_with_real_and_imaginary_part()
        Dim sut = New ComplexNumber(1, 2)
        Dim expected = New ComplexNumber(-5, 10)
        Assert.Equal(expected.Real(), sut.Mul(CType(New ComplexNumber(CDbl(3), CDbl(4)), ComplexNumber)).Real(), precision:=7)
        Assert.Equal(expected.Imaginary(), sut.Mul(CType(New ComplexNumber(CDbl(3), CDbl(4)), ComplexNumber)).Imaginary(), precision:=7)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Divide_purely_real_numbers()
        Dim sut = New ComplexNumber(1, 0)
        Dim expected = New ComplexNumber(0.5, 0)
        Assert.Equal(expected.Real(), sut.Div(CType(New ComplexNumber(CDbl(2), CDbl(0)), ComplexNumber)).Real(), precision:=7)
        Assert.Equal(expected.Imaginary(), sut.Div(CType(New ComplexNumber(CDbl(2), CDbl(0)), ComplexNumber)).Imaginary(), precision:=7)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Divide_purely_imaginary_numbers()
        Dim sut = New ComplexNumber(0, 1)
        Dim expected = New ComplexNumber(0.5, 0)
        Assert.Equal(expected.Real(), sut.Div(CType(New ComplexNumber(CDbl(0), CDbl(2)), ComplexNumber)).Real(), precision:=7)
        Assert.Equal(expected.Imaginary(), sut.Div(CType(New ComplexNumber(CDbl(0), CDbl(2)), ComplexNumber)).Imaginary(), precision:=7)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Divide_numbers_with_real_and_imaginary_part()
        Dim sut = New ComplexNumber(1, 2)
        Dim expected = New ComplexNumber(0.44, 0.08)
        Assert.Equal(expected.Real(), sut.Div(CType(New ComplexNumber(CDbl(3), CDbl(4)), ComplexNumber)).Real(), precision:=7)
        Assert.Equal(expected.Imaginary(), sut.Div(CType(New ComplexNumber(CDbl(3), CDbl(4)), ComplexNumber)).Imaginary(), precision:=7)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Absolute_value_of_a_positive_purely_real_number()
        Dim sut = New ComplexNumber(5, 0)
        Assert.Equal(5, sut.Abs())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Absolute_value_of_a_negative_purely_real_number()
        Dim sut = New ComplexNumber(-5, 0)
        Assert.Equal(5, sut.Abs())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Absolute_value_of_a_purely_imaginary_number_with_positive_imaginary_part()
        Dim sut = New ComplexNumber(0, 5)
        Assert.Equal(5, sut.Abs())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Absolute_value_of_a_purely_imaginary_number_with_negative_imaginary_part()
        Dim sut = New ComplexNumber(0, -5)
        Assert.Equal(5, sut.Abs())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Absolute_value_of_a_number_with_real_and_imaginary_part()
        Dim sut = New ComplexNumber(3, 4)
        Assert.Equal(5, sut.Abs())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Conjugate_a_purely_real_number()
        Dim sut = New ComplexNumber(5, 0)
        Dim expected = New ComplexNumber(5, 0)
        Assert.Equal(expected.Real(), sut.Conjugate().Real(), precision:=7)
        Assert.Equal(expected.Imaginary(), sut.Conjugate().Imaginary(), precision:=7)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Conjugate_a_purely_imaginary_number()
        Dim sut = New ComplexNumber(0, 5)
        Dim expected = New ComplexNumber(0, -5)
        Assert.Equal(expected.Real(), sut.Conjugate().Real(), precision:=7)
        Assert.Equal(expected.Imaginary(), sut.Conjugate().Imaginary(), precision:=7)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Conjugate_a_number_with_real_and_imaginary_part()
        Dim sut = New ComplexNumber(1, 1)
        Dim expected = New ComplexNumber(1, -1)
        Assert.Equal(expected.Real(), sut.Conjugate().Real(), precision:=7)
        Assert.Equal(expected.Imaginary(), sut.Conjugate().Imaginary(), precision:=7)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Eulers_identity_formula()
        Dim sut = New ComplexNumber(0, Math.PI)
        Dim expected = New ComplexNumber(-1, 0)
        Assert.Equal(expected.Real(), sut.Exp().Real(), precision:=7)
        Assert.Equal(expected.Imaginary(), sut.Exp().Imaginary(), precision:=7)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Exponential_of_0()
        Dim sut = New ComplexNumber(0, 0)
        Dim expected = New ComplexNumber(1, 0)
        Assert.Equal(expected.Real(), sut.Exp().Real(), precision:=7)
        Assert.Equal(expected.Imaginary(), sut.Exp().Imaginary(), precision:=7)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Exponential_of_a_purely_real_number()
        Dim sut = New ComplexNumber(1, 0)
        Dim expected = New ComplexNumber(Math.E, 0)
        Assert.Equal(expected.Real(), sut.Exp().Real(), precision:=7)
        Assert.Equal(expected.Imaginary(), sut.Exp().Imaginary(), precision:=7)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Exponential_of_a_number_with_real_and_imaginary_part()
        Dim sut = New ComplexNumber(Math.Log(2.0), Math.PI)
        Dim expected = New ComplexNumber(-2, 0)
        Assert.Equal(expected.Real(), sut.Exp().Real(), precision:=7)
        Assert.Equal(expected.Imaginary(), sut.Exp().Imaginary(), precision:=7)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Exponential_resulting_in_a_number_with_real_and_imaginary_part()
        Dim sut = New ComplexNumber(Math.Log(2.0) / 2, Math.PI / 4)
        Dim expected = New ComplexNumber(1, 1)
        Assert.Equal(expected.Real(), sut.Exp().Real(), precision:=7)
        Assert.Equal(expected.Imaginary(), sut.Exp().Imaginary(), precision:=7)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Add_real_number_to_complex_number()
        Dim sut = New ComplexNumber(1, 2)
        Dim expected = New ComplexNumber(6, 2)
        Assert.Equal(expected.Real(), sut.Add(CType(5, ComplexNumber)).Real(), precision:=7)
        Assert.Equal(expected.Imaginary(), sut.Add(CType(5, ComplexNumber)).Imaginary(), precision:=7)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiply_complex_number_by_real_number()
        Dim sut = New ComplexNumber(2, 5)
        Dim expected = New ComplexNumber(10, 25)
        Assert.Equal(expected.Real(), sut.Mul(CType(5, ComplexNumber)).Real(), precision:=7)
        Assert.Equal(expected.Imaginary(), sut.Mul(CType(5, ComplexNumber)).Imaginary(), precision:=7)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Divide_complex_number_by_real_number()
        Dim sut = New ComplexNumber(10, 100)
        Dim expected = New ComplexNumber(1, 10)
        Assert.Equal(expected.Real(), sut.Div(CType(10, ComplexNumber)).Real(), precision:=7)
        Assert.Equal(expected.Imaginary(), sut.Div(CType(10, ComplexNumber)).Imaginary(), precision:=7)
    End Sub
End Class
