Public Class YachtTests
    <Fact>
    Public Sub Yacht()
        Dim result = YachtGame.Score(
            {5, 5, 5, 5, 5},
            YachtCategory.Yacht)

        Assert.Equal(50, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Not_yacht()
        Dim result = YachtGame.Score(
            {1, 3, 3, 2, 5},
            YachtCategory.Yacht)

        Assert.Equal(0, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ones()
        Dim result = YachtGame.Score(
            {1, 1, 1, 3, 5},
            YachtCategory.Ones)

        Assert.Equal(3, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ones_out_of_order()
        Dim result = YachtGame.Score(
            {3, 1, 1, 5, 1},
            YachtCategory.Ones)

        Assert.Equal(3, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub No_ones()
        Dim result = YachtGame.Score(
            {4, 3, 6, 5, 5},
            YachtCategory.Ones)

        Assert.Equal(0, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Twos()
        Dim result = YachtGame.Score(
            {2, 3, 4, 5, 6},
            YachtCategory.Twos)

        Assert.Equal(2, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Fours()
        Dim result = YachtGame.Score(
            {1, 4, 1, 4, 1},
            YachtCategory.Fours)

        Assert.Equal(8, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Yacht_counted_as_threes()
        Dim result = YachtGame.Score(
            {3, 3, 3, 3, 3},
            YachtCategory.Threes)

        Assert.Equal(15, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Yacht_of_3s_counted_as_fives()
        Dim result = YachtGame.Score(
            {3, 3, 3, 3, 3},
            YachtCategory.Fives)

        Assert.Equal(0, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Fives()
        Dim result = YachtGame.Score(
            {1, 5, 3, 5, 3},
            YachtCategory.Fives)

        Assert.Equal(10, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sixes()
        Dim result = YachtGame.Score(
            {2, 3, 4, 5, 6},
            YachtCategory.Sixes)

        Assert.Equal(6, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Full_house_two_small_three_big()
        Dim result = YachtGame.Score(
            {2, 2, 4, 4, 4},
            YachtCategory.FullHouse)

        Assert.Equal(16, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Full_house_three_small_two_big()
        Dim result = YachtGame.Score(
            {5, 3, 3, 5, 3},
            YachtCategory.FullHouse)

        Assert.Equal(19, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_pair_is_not_a_full_house()
        Dim result = YachtGame.Score(
            {2, 2, 4, 4, 5},
            YachtCategory.FullHouse)

        Assert.Equal(0, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Four_of_a_kind_is_not_a_full_house()
        Dim result = YachtGame.Score(
            {1, 4, 4, 4, 4},
            YachtCategory.FullHouse)

        Assert.Equal(0, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Yacht_is_not_a_full_house()
        Dim result = YachtGame.Score(
            {2, 2, 2, 2, 2},
            YachtCategory.FullHouse)

        Assert.Equal(0, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Four_of_a_kind()
        Dim result = YachtGame.Score(
            {6, 6, 4, 6, 6},
            YachtCategory.FourOfAKind)

        Assert.Equal(24, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Yacht_can_be_scored_as_four_of_a_kind()
        Dim result = YachtGame.Score(
            {3, 3, 3, 3, 3},
            YachtCategory.FourOfAKind)

        Assert.Equal(12, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Full_house_is_not_four_of_a_kind()
        Dim result = YachtGame.Score(
            {3, 3, 3, 5, 5},
            YachtCategory.FourOfAKind)

        Assert.Equal(0, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Little_straight()
        Dim result = YachtGame.Score(
            {3, 5, 4, 1, 2},
            YachtCategory.LittleStraight)

        Assert.Equal(30, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Little_straight_as_big_straight()
        Dim result = YachtGame.Score(
            {1, 2, 3, 4, 5},
            YachtCategory.BigStraight)

        Assert.Equal(0, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Four_in_order_but_not_a_little_straight()
        Dim result = YachtGame.Score(
            {1, 1, 2, 3, 4},
            YachtCategory.LittleStraight)

        Assert.Equal(0, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub No_pairs_but_not_a_little_straight()
        Dim result = YachtGame.Score(
            {1, 2, 3, 4, 6},
            YachtCategory.LittleStraight)

        Assert.Equal(0, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Minimum_is_1_maximum_is_5_but_not_a_little_straight()
        Dim result = YachtGame.Score(
            {1, 1, 3, 4, 5},
            YachtCategory.LittleStraight)

        Assert.Equal(0, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Big_straight()
        Dim result = YachtGame.Score(
            {4, 6, 2, 5, 3},
            YachtCategory.BigStraight)

        Assert.Equal(30, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Big_straight_as_little_straight()
        Dim result = YachtGame.Score(
            {6, 5, 4, 3, 2},
            YachtCategory.LittleStraight)

        Assert.Equal(0, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub No_pairs_but_not_a_big_straight()
        Dim result = YachtGame.Score(
            {6, 5, 4, 3, 1},
            YachtCategory.BigStraight)

        Assert.Equal(0, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Choice()
        Dim result = YachtGame.Score(
            {3, 3, 5, 6, 6},
            YachtCategory.Choice)

        Assert.Equal(23, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Yacht_as_choice()
        Dim result = YachtGame.Score(
            {2, 2, 2, 2, 2},
            YachtCategory.Choice)

        Assert.Equal(10, result)
    End Sub
End Class
