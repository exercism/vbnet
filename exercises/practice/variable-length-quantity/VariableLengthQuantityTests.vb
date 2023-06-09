Imports System
Imports Xunit

Public Class VariableLengthQuantityTests
    <Fact>
    Public Sub Zero()
        Dim integers = {&H0UI}
        Dim expected = {&H0UI}
        Assert.Equal(expected, Encode(integers))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Arbitrary_single_byte()
        Dim integers = {&H40UI}
        Dim expected = {&H40UI}
        Assert.Equal(expected, Encode(integers))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Largest_single_byte()
        Dim integers = {&H7FUI}
        Dim expected = {&H7FUI}
        Assert.Equal(expected, Encode(integers))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Smallest_double_byte()
        Dim integers = {&H80UI}
        Dim expected = {&H81UI, &H0UI}
        Assert.Equal(expected, Encode(integers))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Arbitrary_double_byte()
        Dim integers = {&H2000UI}
        Dim expected = {&HC0UI, &H0UI}
        Assert.Equal(expected, Encode(integers))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Largest_double_byte()
        Dim integers = {&H3FFFUI}
        Dim expected = {&HFFUI, &H7FUI}
        Assert.Equal(expected, Encode(integers))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Smallest_triple_byte()
        Dim integers = {&H4000UI}
        Dim expected = {&H81UI, &H80UI, &H0UI}
        Assert.Equal(expected, Encode(integers))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Arbitrary_triple_byte()
        Dim integers = {&H100000UI}
        Dim expected = {&HC0UI, &H80UI, &H0UI}
        Assert.Equal(expected, Encode(integers))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Largest_triple_byte()
        Dim integers = {&H1FFFFFUI}
        Dim expected = {&HFFUI, &HFFUI, &H7FUI}
        Assert.Equal(expected, Encode(integers))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Smallest_quadruple_byte()
        Dim integers = {&H200000UI}
        Dim expected = {&H81UI, &H80UI, &H80UI, &H0UI}
        Assert.Equal(expected, Encode(integers))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Arbitrary_quadruple_byte()
        Dim integers = {&H8000000UI}
        Dim expected = {&HC0UI, &H80UI, &H80UI, &H0UI}
        Assert.Equal(expected, Encode(integers))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Largest_quadruple_byte()
        Dim integers = {&HFFFFFFFUI}
        Dim expected = {&HFFUI, &HFFUI, &HFFUI, &H7FUI}
        Assert.Equal(expected, Encode(integers))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Smallest_quintuple_byte()
        Dim integers = {&H10000000UI}
        Dim expected = {&H81UI, &H80UI, &H80UI, &H80UI, &H0UI}
        Assert.Equal(expected, Encode(integers))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Arbitrary_quintuple_byte()
        Dim integers = {&HFF000000UI}
        Dim expected = {&H8FUI, &HF8UI, &H80UI, &H80UI, &H0UI}
        Assert.Equal(expected, Encode(integers))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Maximum_32_bit_integer_input()
        Dim integers = {&HFFFFFFFFUI}
        Dim expected = {&H8FUI, &HFFUI, &HFFUI, &HFFUI, &H7FUI}
        Assert.Equal(expected, Encode(integers))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_single_byte_values()
        Dim integers = {&H40UI, &H7FUI}
        Dim expected = {&H40UI, &H7FUI}
        Assert.Equal(expected, Encode(integers))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_multi_byte_values()
        Dim integers = {&H4000UI, &H123456UI}
        Dim expected = {&H81UI, &H80UI, &H0UI, &HC8UI, &HE8UI, &H56UI}
        Assert.Equal(expected, Encode(integers))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Many_multi_byte_values()
        Dim integers = {&H2000UI, &H123456UI, &HFFFFFFFUI, &H0UI, &H3FFFUI, &H4000UI}
        Dim expected = {&HC0UI, &H0UI, &HC8UI, &HE8UI, &H56UI, &HFFUI, &HFFUI, &HFFUI, &H7FUI, &H0UI, &HFFUI, &H7FUI, &H81UI, &H80UI, &H0UI}
        Assert.Equal(expected, Encode(integers))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_byte()
        Dim integers = {&H7FUI}
        Dim expected = {&H7FUI}
        Assert.Equal(expected, Decode(integers))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_bytes()
        Dim integers = {&HC0UI, &H0UI}
        Dim expected = {&H2000UI}
        Assert.Equal(expected, Decode(integers))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Three_bytes()
        Dim integers = {&HFFUI, &HFFUI, &H7FUI}
        Dim expected = {&H1FFFFFUI}
        Assert.Equal(expected, Decode(integers))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Four_bytes()
        Dim integers = {&H81UI, &H80UI, &H80UI, &H0UI}
        Dim expected = {&H200000UI}
        Assert.Equal(expected, Decode(integers))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Maximum_32_bit_integer()
        Dim integers = {&H8FUI, &HFFUI, &HFFUI, &HFFUI, &H7FUI}
        Dim expected = {&HFFFFFFFFUI}
        Assert.Equal(expected, Decode(integers))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Incomplete_sequence_causes_error()
        Dim integers = {&HFFUI}
        Assert.Throws(Of InvalidOperationException)(Function() Decode(integers))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Incomplete_sequence_causes_error_even_if_value_is_zero()
        Dim integers = {&H80UI}
        Assert.Throws(Of InvalidOperationException)(Function() Decode(integers))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_values()
        Dim integers = {&HC0UI, &H0UI, &HC8UI, &HE8UI, &H56UI, &HFFUI, &HFFUI, &HFFUI, &H7FUI, &H0UI, &HFFUI, &H7FUI, &H81UI, &H80UI, &H0UI}
        Dim expected = {&H2000UI, &H123456UI, &HFFFFFFFUI, &H0UI, &H3FFFUI, &H4000UI}
        Assert.Equal(expected, Decode(integers))
    End Sub
End Class
