Imports System.Collections.Generic
Imports Xunit

Public Class StrainTests
    <Fact>
    Public Sub Empty_keep()
        Assert.Equal(New LinkedList(Of Integer)(), New LinkedList(Of Integer)().Keep(Function(x) x < 10))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Keep_everything()
        Assert.Equal(New HashSet(Of Integer) From {
            1,
            2,
            3
        }, New HashSet(Of Integer) From {
            1,
            2,
            3
        }.Keep(Function(x) x < 10))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Keep_first_and_last()
        Assert.Equal({1, 3}, {1, 2, 3}.Keep(Function(x) x Mod 2 <> 0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Keep_neither_first_nor_last()
        Assert.Equal(New List(Of Integer) From {
            2,
            4
        }, New List(Of Integer) From {
            1,
            2,
            3,
            4,
            5
        }.Keep(Function(x) x Mod 2 = 0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Keep_strings()
        Dim words = "apple zebra banana zombies cherimoya zelot".Split(" "c)
        Assert.Equal("zebra zombies zelot".Split(" "c), words.Keep(Function(x) x.StartsWith("z")))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Keep_arrays()
        Dim actual = {
                {1, 2, 3},
                {5, 5, 5},
                {5, 1, 2},
                {2, 1, 2},
                {1, 5, 2},
                {2, 2, 1},
                            {1, 2, 5}}
        Dim expected = {
        {5, 5, 5},
        {5, 1, 2},
        {1, 5, 2},
        {1, 2, 5}}
        Assert.Equal(expected, actual.Keep(Function(x) x.Contains(5)))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Empty_discard()
        Assert.Equal(New LinkedList(Of Integer)(), New LinkedList(Of Integer)().Discard(Function(x) x < 10))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Discard_nothing()
        Assert.Equal(New HashSet(Of Integer) From {
            1,
            2,
            3
        }, New HashSet(Of Integer) From {
            1,
            2,
            3
        }.Discard(Function(x) x > 10))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Discard_first_and_last()
        Assert.Equal({2}, {1, 2, 3}.Discard(Function(x) x Mod 2 <> 0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Discard_neither_first_nor_last()
        Assert.Equal(New List(Of Integer) From {
            1,
            3,
            5
        }, New List(Of Integer) From {
            1,
            2,
            3,
            4,
            5
        }.Discard(Function(x) x Mod 2 = 0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Discard_strings()
        Dim words = "apple zebra banana zombies cherimoya zelot".Split(" "c)
        Assert.Equal("apple banana cherimoya".Split(" "c), words.Discard(Function(x) x.StartsWith("z")))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Discard_arrays()
        Dim actual = {
                {1, 2, 3},
                {5, 5, 5},
                {5, 1, 2},
                {2, 1, 2},
                {1, 5, 2},
                {2, 2, 1},
                            {1, 2, 5}}
        Dim expected = {
        {1, 2, 3},
        {2, 1, 2},
        {2, 2, 1}}
        Assert.Equal(expected, actual.Discard(Function(x) x.Contains(5)))
    End Sub
End Class
