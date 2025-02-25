Imports System
Imports System.Linq
Imports Xunit

Public Class SeriesTests
    <Fact>
    Public Sub Slices_of_one_from_one()
        Dim expected = {"1"}
        Dim result As IEnumerable(Of String) = Slices("1", 1)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Slices_of_one_from_two()
        Dim expected = {"1", "2"}
        Dim result As IEnumerable(Of String) = Slices("12", 1)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Slices_of_two()
        Dim expected = {"35"}
        Dim result As IEnumerable(Of String) = Slices("35", 2)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Slices_of_two_overlap()
        Dim expected = {"91", "14", "42"}
        Dim result As IEnumerable(Of String) = Slices("9142", 2)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Slices_can_include_duplicates()
        Dim expected = {"777", "777", "777", "777"}
        Dim result As IEnumerable(Of String) = Slices("777777", 3)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Slices_of_a_long_series()
        Dim expected = {"91849", "18493", "84939", "49390", "93904", "39042", "90424", "04243"}
        Dim result as IEnumerable(Of String) = Slices("918493904243", 5)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Slice_length_is_too_large()
        Assert.Throws(Of ArgumentException)(Function() Slices("12345", 6))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Slice_length_is_way_too_large()
        Assert.Throws(Of ArgumentException)(Function() Slices("12345", 42))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Slice_length_cannot_be_zero()
        Assert.Throws(Of ArgumentException)(Function() Slices("12345", 0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Slice_length_cannot_be_negative()
        Assert.Throws(Of ArgumentException)(Function() Slices("123", -1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Empty_series_is_invalid()
        Assert.Throws(Of ArgumentException)(Function() Slices("", 1))
    End Sub
End Class
