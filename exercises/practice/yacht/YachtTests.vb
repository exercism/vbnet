Imports Xunit

Public Class YachtTests
    <Fact>
    Public Sub Yacht()
        Assert.Equal(50, Score({5, 5, 5, 5, 5}, YachtCategory.Yacht))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Not_yacht()
        Assert.Equal(0, Score({1, 3, 3, 2, 5}, YachtCategory.Yacht))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ones()
        Assert.Equal(3, Score({1, 1, 1, 3, 5}, YachtCategory.Ones))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ones_out_of_order()
        Assert.Equal(3, Score({3, 1, 1, 5, 1}, YachtCategory.Ones))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub No_ones()
        Assert.Equal(0, Score({4, 3, 6, 5, 5}, YachtCategory.Ones))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Twos()
        Assert.Equal(2, Score({2, 3, 4, 5, 6}, YachtCategory.Twos))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Fours()
        Assert.Equal(8, Score({1, 4, 1, 4, 1}, YachtCategory.Fours))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Yacht_counted_as_threes()
        Assert.Equal(15, Score({3, 3, 3, 3, 3}, YachtCategory.Threes))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Yacht_of_3s_counted_as_fives()
        Assert.Equal(0, Score({3, 3, 3, 3, 3}, YachtCategory.Fives))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Fives()
        Assert.Equal(10, Score({1, 5, 3, 5, 3}, YachtCategory.Fives))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sixes()
        Assert.Equal(6, Score({2, 3, 4, 5, 6}, YachtCategory.Sixes))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Full_house_two_small_three_big()
        Assert.Equal(16, Score({2, 2, 4, 4, 4}, YachtCategory.FullHouse))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Full_house_three_small_two_big()
        Assert.Equal(19, Score({5, 3, 3, 5, 3}, YachtCategory.FullHouse))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_pair_is_not_a_full_house()
        Assert.Equal(0, Score({2, 2, 4, 4, 5}, YachtCategory.FullHouse))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Four_of_a_kind_is_not_a_full_house()
        Assert.Equal(0, Score({1, 4, 4, 4, 4}, YachtCategory.FullHouse))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Yacht_is_not_a_full_house()
        Assert.Equal(0, Score({2, 2, 2, 2, 2}, YachtCategory.FullHouse))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Four_of_a_kind()
        Assert.Equal(24, Score({6, 6, 4, 6, 6}, YachtCategory.FourOfAKind))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Yacht_can_be_scored_as_four_of_a_kind()
        Assert.Equal(12, Score({3, 3, 3, 3, 3}, YachtCategory.FourOfAKind))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Full_house_is_not_four_of_a_kind()
        Assert.Equal(0, Score({3, 3, 3, 5, 5}, YachtCategory.FourOfAKind))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Little_straight()
        Assert.Equal(30, Score({3, 5, 4, 1, 2}, YachtCategory.LittleStraight))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Little_straight_as_big_straight()
        Assert.Equal(0, Score({1, 2, 3, 4, 5}, YachtCategory.BigStraight))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Four_in_order_but_not_a_little_straight()
        Assert.Equal(0, Score({1, 1, 2, 3, 4}, YachtCategory.LittleStraight))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub No_pairs_but_not_a_little_straight()
        Assert.Equal(0, Score({1, 2, 3, 4, 6}, YachtCategory.LittleStraight))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Minimum_is_1_maximum_is_5_but_not_a_little_straight()
        Assert.Equal(0, Score({1, 1, 3, 4, 5}, YachtCategory.LittleStraight))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Big_straight()
        Assert.Equal(30, Score({4, 6, 2, 5, 3}, YachtCategory.BigStraight))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Big_straight_as_little_straight()
        Assert.Equal(0, Score({6, 5, 4, 3, 2}, YachtCategory.LittleStraight))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub No_pairs_but_not_a_big_straight()
        Assert.Equal(0, Score({6, 5, 4, 3, 1}, YachtCategory.BigStraight))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Choice()
        Assert.Equal(23, Score({3, 3, 5, 6, 6}, YachtCategory.Choice))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Yacht_as_choice()
        Assert.Equal(10, Score({2, 2, 2, 2, 2}, YachtCategory.Choice))
    End Sub
End Class
