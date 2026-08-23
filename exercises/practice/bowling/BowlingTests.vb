Public Class BowlingTests
    <Fact>
    Public Sub Should_be_able_to_score_a_game_with_all_zeros()
        Dim sut = New BowlingGame()
        Dim previousRolls = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Equal(0, sut.Score())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Should_be_able_to_score_a_game_with_no_strikes_or_spares()
        Dim sut = New BowlingGame()
        Dim previousRolls = {3, 6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 6}
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Equal(90, sut.Score())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_spare_followed_by_zeros_is_worth_ten_points()
        Dim sut = New BowlingGame()
        Dim previousRolls = {6, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Equal(10, sut.Score())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Points_scored_in_the_roll_after_a_spare_are_counted_twice()
        Dim sut = New BowlingGame()
        Dim previousRolls = {6, 4, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Equal(16, sut.Score())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Consecutive_spares_each_get_a_one_roll_bonus()
        Dim sut = New BowlingGame()
        Dim previousRolls = {5, 5, 3, 7, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Equal(31, sut.Score())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_spare_in_the_last_frame_gets_a_one_roll_bonus_that_is_counted_once()
        Dim sut = New BowlingGame()
        Dim previousRolls = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 3, 7}
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Equal(17, sut.Score())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_strike_earns_ten_points_in_a_frame_with_a_single_roll()
        Dim sut = New BowlingGame()
        Dim previousRolls = {10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Equal(10, sut.Score())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Points_scored_in_the_two_rolls_after_a_strike_are_counted_twice_as_a_bonus()
        Dim sut = New BowlingGame()
        Dim previousRolls = {10, 5, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Equal(26, sut.Score())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Consecutive_strikes_each_get_the_two_roll_bonus()
        Dim sut = New BowlingGame()
        Dim previousRolls = {10, 10, 10, 5, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Equal(81, sut.Score())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_strike_in_the_last_frame_gets_a_two_roll_bonus_that_is_counted_once()
        Dim sut = New BowlingGame()
        Dim previousRolls = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 7, 1}
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Equal(18, sut.Score())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rolling_a_spare_with_the_two_roll_bonus_does_not_get_a_bonus_roll()
        Dim sut = New BowlingGame()
        Dim previousRolls = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 7, 3}
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Equal(20, sut.Score())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Strikes_with_the_two_roll_bonus_do_not_get_bonus_rolls()
        Dim sut = New BowlingGame()
        Dim previousRolls = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 10, 10}
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Equal(30, sut.Score())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_two_strikes_followed_by_only_last_bonus_with_non_strike_points()
        Dim sut = New BowlingGame()
        Dim previousRolls = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 10, 0, 1}
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Equal(31, sut.Score())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_strike_with_the_one_roll_bonus_after_a_spare_in_the_last_frame_does_not_get_a_bonus()
        Dim sut = New BowlingGame()
        Dim previousRolls = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 3, 10}
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Equal(20, sut.Score())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub All_strikes_is_a_perfect_game()
        Dim sut = New BowlingGame()
        Dim previousRolls = {10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10}
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Equal(300, sut.Score())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rolls_cannot_score_negative_points()
        Dim sut = New BowlingGame()
        Dim previousRolls = System.Array.Empty(Of Integer)()
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Throws(Of ArgumentException)(Sub() sut.Roll(-1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_roll_cannot_score_more_than_10_points()
        Dim sut = New BowlingGame()
        Dim previousRolls = System.Array.Empty(Of Integer)()
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Throws(Of ArgumentException)(Sub() sut.Roll(11))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_rolls_in_a_frame_cannot_score_more_than_10_points()
        Dim sut = New BowlingGame()
        Dim previousRolls = {5}
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Throws(Of ArgumentException)(Sub() sut.Roll(6))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Bonus_roll_after_a_strike_in_the_last_frame_cannot_score_more_than_10_points()
        Dim sut = New BowlingGame()
        Dim previousRolls = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10}
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Throws(Of ArgumentException)(Sub() sut.Roll(11))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_bonus_rolls_after_a_strike_in_the_last_frame_cannot_score_more_than_10_points()
        Dim sut = New BowlingGame()
        Dim previousRolls = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 5}
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Throws(Of ArgumentException)(Sub() sut.Roll(6))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_bonus_rolls_after_a_strike_in_the_last_frame_can_score_more_than_10_points_if_one_is_a_strike()
        Dim sut = New BowlingGame()
        Dim previousRolls = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 10, 6}
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Equal(26, sut.Score())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub The_second_bonus_rolls_after_a_strike_in_the_last_frame_cannot_be_a_strike_if_the_first_one_is_not_a_strike()
        Dim sut = New BowlingGame()
        Dim previousRolls = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 6}
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Throws(Of ArgumentException)(Sub() sut.Roll(10))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Second_bonus_roll_after_a_strike_in_the_last_frame_cannot_score_more_than_10_points()
        Dim sut = New BowlingGame()
        Dim previousRolls = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 10}
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Throws(Of ArgumentException)(Sub() sut.Roll(11))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub An_unstarted_game_cannot_be_scored()
        Dim sut = New BowlingGame()
        Dim previousRolls = System.Array.Empty(Of Integer)()
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Throws(Of ArgumentException)(Function() sut.Score())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub An_incomplete_game_cannot_be_scored()
        Dim sut = New BowlingGame()
        Dim previousRolls = {0, 0}
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Throws(Of ArgumentException)(Function() sut.Score())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cannot_roll_if_game_already_has_ten_frames()
        Dim sut = New BowlingGame()
        Dim previousRolls = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Throws(Of ArgumentException)(Sub() sut.Roll(0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Bonus_rolls_for_a_strike_in_the_last_frame_must_be_rolled_before_score_can_be_calculated()
        Dim sut = New BowlingGame()
        Dim previousRolls = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10}
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Throws(Of ArgumentException)(Function() sut.Score())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Both_bonus_rolls_for_a_strike_in_the_last_frame_must_be_rolled_before_score_can_be_calculated()
        Dim sut = New BowlingGame()
        Dim previousRolls = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 10}
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Throws(Of ArgumentException)(Function() sut.Score())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Bonus_roll_for_a_spare_in_the_last_frame_must_be_rolled_before_score_can_be_calculated()
        Dim sut = New BowlingGame()
        Dim previousRolls = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 3}
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Throws(Of ArgumentException)(Function() sut.Score())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cannot_roll_after_bonus_roll_for_spare()
        Dim sut = New BowlingGame()
        Dim previousRolls = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 3, 2}
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Throws(Of ArgumentException)(Sub() sut.Roll(2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cannot_roll_after_bonus_rolls_for_strike()
        Dim sut = New BowlingGame()
        Dim previousRolls = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 3, 2}
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        Assert.Throws(Of ArgumentException)(Sub() sut.Roll(2))
    End Sub
End Class
