Imports System
Imports Xunit

Public Class ChangeTests
    <Fact>
    Public Sub Change_for_1_cent()
        Dim coins = {1, 5, 10, 25}
        Dim target = 1
        Dim expected = {1}
        Assert.Equal(expected, FindFewestCoins(coins, target))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Single_coin_change()
        Dim coins = {1, 5, 10, 25, 100}
        Dim target = 25
        Dim expected = {25}
        Assert.Equal(expected, FindFewestCoins(coins, target))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_coin_change()
        Dim coins = {1, 5, 10, 25, 100}
        Dim target = 15
        Dim expected = {5, 10}
        Assert.Equal(expected, FindFewestCoins(coins, target))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Change_with_lilliputian_coins()
        Dim coins = {1, 4, 15, 20, 50}
        Dim target = 23
        Dim expected = {4, 4, 15}
        Assert.Equal(expected, FindFewestCoins(coins, target))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Change_with_lower_elbonia_coins()
        Dim coins = {1, 5, 10, 21, 25}
        Dim target = 63
        Dim expected = {21, 21, 21}
        Assert.Equal(expected, FindFewestCoins(coins, target))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Large_target_values()
        Dim coins = {1, 2, 5, 10, 20, 50, 100}
        Dim target = 999
        Dim expected = {2, 2, 5, 20, 20, 50, 100, 100, 100, 100, 100, 100, 100, 100, 100}
        Assert.Equal(expected, FindFewestCoins(coins, target))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Possible_change_without_unit_coins_available()
        Dim coins = {2, 5, 10, 20, 50}
        Dim target = 21
        Dim expected = {2, 2, 2, 5, 10}
        Assert.Equal(expected, FindFewestCoins(coins, target))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Another_possible_change_without_unit_coins_available()
        Dim coins = {4, 5}
        Dim target = 27
        Dim expected = {4, 4, 4, 5, 5, 5}
        Assert.Equal(expected, FindFewestCoins(coins, target))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub No_coins_make_0_change()
        Dim coins = {1, 5, 10, 21, 25}
        Dim target = 0
        Assert.Empty(FindFewestCoins(coins, target))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Error_testing_for_change_smaller_than_the_smallest_of_coins()
        Dim coins = {5, 10}
        Dim target = 3
        Assert.Throws(Of ArgumentException)(Function() FindFewestCoins(coins, target))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Error_if_no_combination_can_add_up_to_target()
        Dim coins = {5, 10}
        Dim target = 94
        Assert.Throws(Of ArgumentException)(Function() FindFewestCoins(coins, target))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cannot_find_negative_change_values()
        Dim coins = {1, 2, 5}
        Dim target = -5
        Assert.Throws(Of ArgumentException)(Function() FindFewestCoins(coins, target))
    End Sub
End Class
