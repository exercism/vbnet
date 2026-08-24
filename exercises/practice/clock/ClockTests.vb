Public Class ClockTests
    <Fact>
    Public Sub On_the_hour()
        Dim sut = New Clock(8, 0)
        Assert.Equal("08:00", sut.ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Past_the_hour()
        Dim sut = New Clock(11, 9)
        Assert.Equal("11:09", sut.ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Midnight_is_zero_hours()
        Dim sut = New Clock(24, 0)
        Assert.Equal("00:00", sut.ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Hour_rolls_over()
        Dim sut = New Clock(25, 0)
        Assert.Equal("01:00", sut.ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Hour_rolls_over_continuously()
        Dim sut = New Clock(100, 0)
        Assert.Equal("04:00", sut.ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sixty_minutes_is_next_hour()
        Dim sut = New Clock(1, 60)
        Assert.Equal("02:00", sut.ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Minutes_roll_over()
        Dim sut = New Clock(0, 160)
        Assert.Equal("02:40", sut.ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Minutes_roll_over_continuously()
        Dim sut = New Clock(0, 1723)
        Assert.Equal("04:43", sut.ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Hour_and_minutes_roll_over()
        Dim sut = New Clock(25, 160)
        Assert.Equal("03:40", sut.ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Hour_and_minutes_roll_over_continuously()
        Dim sut = New Clock(201, 3001)
        Assert.Equal("11:01", sut.ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Hour_and_minutes_roll_over_to_exactly_midnight()
        Dim sut = New Clock(72, 8640)
        Assert.Equal("00:00", sut.ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Negative_hour()
        Dim sut = New Clock(-1, 15)
        Assert.Equal("23:15", sut.ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Negative_hour_rolls_over()
        Dim sut = New Clock(-25, 0)
        Assert.Equal("23:00", sut.ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Negative_hour_rolls_over_continuously()
        Dim sut = New Clock(-91, 0)
        Assert.Equal("05:00", sut.ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Negative_minutes()
        Dim sut = New Clock(1, -40)
        Assert.Equal("00:20", sut.ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Negative_minutes_roll_over()
        Dim sut = New Clock(1, -160)
        Assert.Equal("22:20", sut.ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Negative_minutes_roll_over_continuously()
        Dim sut = New Clock(1, -4820)
        Assert.Equal("16:40", sut.ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Negative_sixty_minutes_is_previous_hour()
        Dim sut = New Clock(2, -60)
        Assert.Equal("01:00", sut.ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Negative_hour_and_minutes_both_roll_over()
        Dim sut = New Clock(-25, -160)
        Assert.Equal("20:20", sut.ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Negative_hour_and_minutes_both_roll_over_continuously()
        Dim sut = New Clock(-121, -5810)
        Assert.Equal("22:10", sut.ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Add_minutes()
        Dim sut = New Clock(10, 0)
        Assert.Equal("10:03", sut.Add(3).ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Add_no_minutes()
        Dim sut = New Clock(6, 41)
        Assert.Equal("06:41", sut.Add(0).ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Add_to_next_hour()
        Dim sut = New Clock(0, 45)
        Assert.Equal("01:25", sut.Add(40).ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Add_more_than_one_hour()
        Dim sut = New Clock(10, 0)
        Assert.Equal("11:01", sut.Add(61).ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Add_more_than_two_hours_with_carry()
        Dim sut = New Clock(0, 45)
        Assert.Equal("03:25", sut.Add(160).ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Add_across_midnight()
        Dim sut = New Clock(23, 59)
        Assert.Equal("00:01", sut.Add(2).ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Add_more_than_one_day_1500_min_25_hrs()
        Dim sut = New Clock(5, 32)
        Assert.Equal("06:32", sut.Add(1500).ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Add_more_than_two_days()
        Dim sut = New Clock(1, 1)
        Assert.Equal("11:21", sut.Add(3500).ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Subtract_minutes()
        Dim sut = New Clock(10, 3)
        Assert.Equal("10:00", sut.Subtract(3).ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Subtract_to_previous_hour()
        Dim sut = New Clock(10, 3)
        Assert.Equal("09:33", sut.Subtract(30).ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Subtract_more_than_an_hour()
        Dim sut = New Clock(10, 3)
        Assert.Equal("08:53", sut.Subtract(70).ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Subtract_across_midnight()
        Dim sut = New Clock(0, 3)
        Assert.Equal("23:59", sut.Subtract(4).ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Subtract_more_than_two_hours()
        Dim sut = New Clock(0, 0)
        Assert.Equal("21:20", sut.Subtract(160).ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Subtract_more_than_two_hours_with_borrow()
        Dim sut = New Clock(6, 15)
        Assert.Equal("03:35", sut.Subtract(160).ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Subtract_more_than_one_day_1500_min_25_hrs()
        Dim sut = New Clock(5, 32)
        Assert.Equal("04:32", sut.Subtract(1500).ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Subtract_more_than_two_days()
        Dim sut = New Clock(2, 20)
        Assert.Equal("00:20", sut.Subtract(3000).ToString())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Clocks_with_same_time()
        Assert.Equal(New Clock(15, 37), New Clock(15, 37))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Clocks_a_minute_apart()
        Assert.NotEqual(New Clock(15, 36), New Clock(15, 37))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Clocks_an_hour_apart()
        Assert.NotEqual(New Clock(14, 37), New Clock(15, 37))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Clocks_with_hour_overflow()
        Assert.Equal(New Clock(10, 37), New Clock(34, 37))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Clocks_with_hour_overflow_by_several_days()
        Assert.Equal(New Clock(3, 11), New Clock(99, 11))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Clocks_with_negative_hour()
        Assert.Equal(New Clock(22, 40), New Clock(-2, 40))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Clocks_with_negative_hour_that_wraps()
        Assert.Equal(New Clock(17, 3), New Clock(-31, 3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Clocks_with_negative_hour_that_wraps_multiple_times()
        Assert.Equal(New Clock(13, 49), New Clock(-83, 49))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Clocks_with_minute_overflow()
        Assert.Equal(New Clock(0, 1), New Clock(0, 1441))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Clocks_with_minute_overflow_by_several_days()
        Assert.Equal(New Clock(2, 2), New Clock(2, 4322))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Clocks_with_negative_minute()
        Assert.Equal(New Clock(2, 40), New Clock(3, -20))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Clocks_with_negative_minute_that_wraps()
        Assert.Equal(New Clock(4, 10), New Clock(5, -1490))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Clocks_with_negative_minute_that_wraps_multiple_times()
        Assert.Equal(New Clock(6, 15), New Clock(6, -4305))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Clocks_with_negative_hours_and_minutes()
        Assert.Equal(New Clock(7, 32), New Clock(-12, -268))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Clocks_with_negative_hours_and_minutes_that_wrap()
        Assert.Equal(New Clock(18, 7), New Clock(-54, -11513))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Full_clock_and_zeroed_clock()
        Assert.Equal(New Clock(24, 0), New Clock(0, 0))
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Clocks_are_immutable()
        Dim sut = New Clock(0, 0)
        Dim sutPlus1 = sut.Add(1)
        Assert.NotEqual(sutPlus1, sut)
    End Sub
End Class
