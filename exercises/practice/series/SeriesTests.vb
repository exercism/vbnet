Imports System
Imports System.Linq
Imports Xunit

Public Class SeriesTests
    <Fact>
    Public Sub Slices_of_one_from_one()
        Dim expected = {"1"}
        Assert.Equal(expected, Slices("1", 1).ToArray())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Slices_of_one_from_two()
        Dim expected = {"1", "2"}
        Assert.Equal(expected, Slices("12", 1).ToArray())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Slices_of_two()
        Dim expected = {"35"}
        Assert.Equal(expected, Slices("35", 2).ToArray())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Slices_of_two_overlap()
        Dim expected = {"91", "14", "42"}
        Assert.Equal(expected, Slices("9142", 2).ToArray())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Slices_can_include_duplicates()
        Dim expected = {"777", "777", "777", "777"}
        Assert.Equal(expected, Slices("777777", 3).ToArray())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Slices_of_a_long_series()
        Dim expected = {"91849", "18493", "84939", "49390", "93904", "39042", "90424", "04243"}
        Assert.Equal(expected, Slices("918493904243", 5).ToArray())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Slice_length_is_too_large()
        Assert.Throws(Of ArgumentException)(Function() Slices("12345", 6).ToArray())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Slice_length_is_way_too_large()
        Assert.Throws(Of ArgumentException)(Function() Slices("12345", 42).ToArray())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Slice_length_cannot_be_zero()
        Assert.Throws(Of ArgumentException)(Function() Slices("12345", 0).ToArray())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Slice_length_cannot_be_negative()
        Assert.Throws(Of ArgumentException)(Function() Slices("123", -1).ToArray())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Empty_series_is_invalid()
        Assert.Throws(Of ArgumentException)(Function() Slices("", 1).ToArray())
    End Sub
End Class
