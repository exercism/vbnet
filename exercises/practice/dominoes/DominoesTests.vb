Imports System
Imports Xunit

Public Class DominoesTests
    <Fact>
    Public Sub Empty_input_empty_output()
        Dim dominoes = Array.Empty(Of (Integer, Integer))()
        Assert.True(Dominoes.CanChain(dominoes))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Singleton_input_singleton_output()
        Dim dominoes = {(1, 1)}
        Assert.True(Dominoes.CanChain(dominoes))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Singleton_that_cant_be_chained()
        Dim dominoes = {(1, 2)}
        Assert.False(Dominoes.CanChain(dominoes))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Three_elements()
        Dim dominoes = {(1, 2), (3, 1), (2, 3)}
        Assert.True(Dominoes.CanChain(dominoes))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_reverse_dominoes()
        Dim dominoes = {(1, 2), (1, 3), (2, 3)}
        Assert.True(Dominoes.CanChain(dominoes))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cant_be_chained()
        Dim dominoes = {(1, 2), (4, 1), (2, 3)}
        Assert.False(Dominoes.CanChain(dominoes))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Disconnected_simple()
        Dim dominoes = {(1, 1), (2, 2)}
        Assert.False(Dominoes.CanChain(dominoes))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Disconnected_double_loop()
        Dim dominoes = {(1, 2), (2, 1), (3, 4), (4, 3)}
        Assert.False(Dominoes.CanChain(dominoes))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Disconnected_single_isolated()
        Dim dominoes = {(1, 2), (2, 3), (3, 1), (4, 4)}
        Assert.False(Dominoes.CanChain(dominoes))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Need_backtrack()
        Dim dominoes = {(1, 2), (2, 3), (3, 1), (2, 4), (2, 4)}
        Assert.True(Dominoes.CanChain(dominoes))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Separate_loops()
        Dim dominoes = {(1, 2), (2, 3), (3, 1), (1, 1), (2, 2), (3, 3)}
        Assert.True(Dominoes.CanChain(dominoes))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Nine_elements()
        Dim dominoes = {(1, 2), (5, 3), (3, 1), (1, 2), (2, 4), (1, 6), (2, 3), (3, 4), (5, 6)}
        Assert.True(Dominoes.CanChain(dominoes))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Separate_three_domino_loops()
        Dim dominoes = {(1, 2), (2, 3), (3, 1), (4, 5), (5, 6), (6, 4)}
        Assert.False(Dominoes.CanChain(dominoes))
    End Sub
End Class
