Public Class MeetupTests
    <Fact>
    Public Sub When_teenth_monday_is_the_13th_the_first_day_of_the_teenth_week()
        Dim sut = New Meetup(5, 2013)
        Dim expected = New Date(2013, 05, 13)
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_monday_is_the_19th_the_last_day_of_the_teenth_week()
        Dim sut = New Meetup(8, 2013)
        Dim expected = New Date(2013, 08, 19)
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_monday_is_some_day_in_the_middle_of_the_teenth_week()
        Dim sut = New Meetup(9, 2013)
        Dim expected = New Date(2013, 09, 16)
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_tuesday_is_the_19th_the_last_day_of_the_teenth_week()
        Dim sut = New Meetup(3, 2013)
        Dim expected = New Date(2013, 03, 19)
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_tuesday_is_some_day_in_the_middle_of_the_teenth_week()
        Dim sut = New Meetup(4, 2013)
        Dim expected = New Date(2013, 04, 16)
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_tuesday_is_the_13th_the_first_day_of_the_teenth_week()
        Dim sut = New Meetup(8, 2013)
        Dim expected = New Date(2013, 08, 13)
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_wednesday_is_some_day_in_the_middle_of_the_teenth_week()
        Dim sut = New Meetup(1, 2013)
        Dim expected = New Date(2013, 01, 16)
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_wednesday_is_the_13th_the_first_day_of_the_teenth_week()
        Dim sut = New Meetup(2, 2013)
        Dim expected = New Date(2013, 02, 13)
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_wednesday_is_the_19th_the_last_day_of_the_teenth_week()
        Dim sut = New Meetup(6, 2013)
        Dim expected = New Date(2013, 06, 19)
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_thursday_is_some_day_in_the_middle_of_the_teenth_week()
        Dim sut = New Meetup(5, 2013)
        Dim expected = New Date(2013, 05, 16)
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_thursday_is_the_13th_the_first_day_of_the_teenth_week()
        Dim sut = New Meetup(6, 2013)
        Dim expected = New Date(2013, 06, 13)
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_thursday_is_the_19th_the_last_day_of_the_teenth_week()
        Dim sut = New Meetup(9, 2013)
        Dim expected = New Date(2013, 09, 19)
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_friday_is_the_19th_the_last_day_of_the_teenth_week()
        Dim sut = New Meetup(4, 2013)
        Dim expected = New Date(2013, 04, 19)
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_friday_is_some_day_in_the_middle_of_the_teenth_week()
        Dim sut = New Meetup(8, 2013)
        Dim expected = New Date(2013, 08, 16)
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_friday_is_the_13th_the_first_day_of_the_teenth_week()
        Dim sut = New Meetup(9, 2013)
        Dim expected = New Date(2013, 09, 13)
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_saturday_is_some_day_in_the_middle_of_the_teenth_week()
        Dim sut = New Meetup(2, 2013)
        Dim expected = New Date(2013, 02, 16)
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_saturday_is_the_13th_the_first_day_of_the_teenth_week()
        Dim sut = New Meetup(4, 2013)
        Dim expected = New Date(2013, 04, 13)
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_saturday_is_the_19th_the_last_day_of_the_teenth_week()
        Dim sut = New Meetup(10, 2013)
        Dim expected = New Date(2013, 10, 19)
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_sunday_is_the_19th_the_last_day_of_the_teenth_week()
        Dim sut = New Meetup(5, 2013)
        Dim expected = New Date(2013, 05, 19)
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_sunday_is_some_day_in_the_middle_of_the_teenth_week()
        Dim sut = New Meetup(6, 2013)
        Dim expected = New Date(2013, 06, 16)
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_sunday_is_the_13th_the_first_day_of_the_teenth_week()
        Dim sut = New Meetup(10, 2013)
        Dim expected = New Date(2013, 10, 13)
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_first_monday_is_some_day_in_the_middle_of_the_first_week()
        Dim sut = New Meetup(3, 2013)
        Dim expected = New Date(2013, 03, 04)
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.First))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_first_monday_is_the_1st_the_first_day_of_the_first_week()
        Dim sut = New Meetup(4, 2013)
        Dim expected = New Date(2013, 04, 01)
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.First))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_first_tuesday_is_the_7th_the_last_day_of_the_first_week()
        Dim sut = New Meetup(5, 2013)
        Dim expected = New Date(2013, 05, 07)
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.First))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_first_tuesday_is_some_day_in_the_middle_of_the_first_week()
        Dim sut = New Meetup(6, 2013)
        Dim expected = New Date(2013, 06, 04)
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.First))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_first_wednesday_is_some_day_in_the_middle_of_the_first_week()
        Dim sut = New Meetup(7, 2013)
        Dim expected = New Date(2013, 07, 03)
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.First))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_first_wednesday_is_the_7th_the_last_day_of_the_first_week()
        Dim sut = New Meetup(8, 2013)
        Dim expected = New Date(2013, 08, 07)
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.First))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_first_thursday_is_some_day_in_the_middle_of_the_first_week()
        Dim sut = New Meetup(9, 2013)
        Dim expected = New Date(2013, 09, 05)
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.First))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_first_thursday_is_another_day_in_the_middle_of_the_first_week()
        Dim sut = New Meetup(10, 2013)
        Dim expected = New Date(2013, 10, 03)
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.First))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_first_friday_is_the_1st_the_first_day_of_the_first_week()
        Dim sut = New Meetup(11, 2013)
        Dim expected = New Date(2013, 11, 01)
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.First))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_first_friday_is_some_day_in_the_middle_of_the_first_week()
        Dim sut = New Meetup(12, 2013)
        Dim expected = New Date(2013, 12, 06)
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.First))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_first_saturday_is_some_day_in_the_middle_of_the_first_week()
        Dim sut = New Meetup(1, 2013)
        Dim expected = New Date(2013, 01, 05)
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.First))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_first_saturday_is_another_day_in_the_middle_of_the_first_week()
        Dim sut = New Meetup(2, 2013)
        Dim expected = New Date(2013, 02, 02)
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.First))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_first_sunday_is_some_day_in_the_middle_of_the_first_week()
        Dim sut = New Meetup(3, 2013)
        Dim expected = New Date(2013, 03, 03)
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.First))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_first_sunday_is_the_7th_the_last_day_of_the_first_week()
        Dim sut = New Meetup(4, 2013)
        Dim expected = New Date(2013, 04, 07)
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.First))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_second_monday_is_some_day_in_the_middle_of_the_second_week()
        Dim sut = New Meetup(3, 2013)
        Dim expected = New Date(2013, 03, 11)
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Second))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_second_monday_is_the_8th_the_first_day_of_the_second_week()
        Dim sut = New Meetup(4, 2013)
        Dim expected = New Date(2013, 04, 08)
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Second))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_second_tuesday_is_the_14th_the_last_day_of_the_second_week()
        Dim sut = New Meetup(5, 2013)
        Dim expected = New Date(2013, 05, 14)
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Second))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_second_tuesday_is_some_day_in_the_middle_of_the_second_week()
        Dim sut = New Meetup(6, 2013)
        Dim expected = New Date(2013, 06, 11)
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Second))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_second_wednesday_is_some_day_in_the_middle_of_the_second_week()
        Dim sut = New Meetup(7, 2013)
        Dim expected = New Date(2013, 07, 10)
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Second))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_second_wednesday_is_the_14th_the_last_day_of_the_second_week()
        Dim sut = New Meetup(8, 2013)
        Dim expected = New Date(2013, 08, 14)
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Second))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_second_thursday_is_some_day_in_the_middle_of_the_second_week()
        Dim sut = New Meetup(9, 2013)
        Dim expected = New Date(2013, 09, 12)
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Second))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_second_thursday_is_another_day_in_the_middle_of_the_second_week()
        Dim sut = New Meetup(10, 2013)
        Dim expected = New Date(2013, 10, 10)
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Second))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_second_friday_is_the_8th_the_first_day_of_the_second_week()
        Dim sut = New Meetup(11, 2013)
        Dim expected = New Date(2013, 11, 08)
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Second))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_second_friday_is_some_day_in_the_middle_of_the_second_week()
        Dim sut = New Meetup(12, 2013)
        Dim expected = New Date(2013, 12, 13)
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Second))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_second_saturday_is_some_day_in_the_middle_of_the_second_week()
        Dim sut = New Meetup(1, 2013)
        Dim expected = New Date(2013, 01, 12)
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Second))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_second_saturday_is_another_day_in_the_middle_of_the_second_week()
        Dim sut = New Meetup(2, 2013)
        Dim expected = New Date(2013, 02, 09)
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Second))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_second_sunday_is_some_day_in_the_middle_of_the_second_week()
        Dim sut = New Meetup(3, 2013)
        Dim expected = New Date(2013, 03, 10)
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Second))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_second_sunday_is_the_14th_the_last_day_of_the_second_week()
        Dim sut = New Meetup(4, 2013)
        Dim expected = New Date(2013, 04, 14)
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Second))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_third_monday_is_some_day_in_the_middle_of_the_third_week()
        Dim sut = New Meetup(3, 2013)
        Dim expected = New Date(2013, 03, 18)
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Third))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_third_monday_is_the_15th_the_first_day_of_the_third_week()
        Dim sut = New Meetup(4, 2013)
        Dim expected = New Date(2013, 04, 15)
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Third))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_third_tuesday_is_the_21st_the_last_day_of_the_third_week()
        Dim sut = New Meetup(5, 2013)
        Dim expected = New Date(2013, 05, 21)
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Third))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_third_tuesday_is_some_day_in_the_middle_of_the_third_week()
        Dim sut = New Meetup(6, 2013)
        Dim expected = New Date(2013, 06, 18)
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Third))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_third_wednesday_is_some_day_in_the_middle_of_the_third_week()
        Dim sut = New Meetup(7, 2013)
        Dim expected = New Date(2013, 07, 17)
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Third))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_third_wednesday_is_the_21st_the_last_day_of_the_third_week()
        Dim sut = New Meetup(8, 2013)
        Dim expected = New Date(2013, 08, 21)
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Third))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_third_thursday_is_some_day_in_the_middle_of_the_third_week()
        Dim sut = New Meetup(9, 2013)
        Dim expected = New Date(2013, 09, 19)
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Third))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_third_thursday_is_another_day_in_the_middle_of_the_third_week()
        Dim sut = New Meetup(10, 2013)
        Dim expected = New Date(2013, 10, 17)
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Third))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_third_friday_is_the_15th_the_first_day_of_the_third_week()
        Dim sut = New Meetup(11, 2013)
        Dim expected = New Date(2013, 11, 15)
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Third))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_third_friday_is_some_day_in_the_middle_of_the_third_week()
        Dim sut = New Meetup(12, 2013)
        Dim expected = New Date(2013, 12, 20)
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Third))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_third_saturday_is_some_day_in_the_middle_of_the_third_week()
        Dim sut = New Meetup(1, 2013)
        Dim expected = New Date(2013, 01, 19)
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Third))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_third_saturday_is_another_day_in_the_middle_of_the_third_week()
        Dim sut = New Meetup(2, 2013)
        Dim expected = New Date(2013, 02, 16)
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Third))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_third_sunday_is_some_day_in_the_middle_of_the_third_week()
        Dim sut = New Meetup(3, 2013)
        Dim expected = New Date(2013, 03, 17)
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Third))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_third_sunday_is_the_21st_the_last_day_of_the_third_week()
        Dim sut = New Meetup(4, 2013)
        Dim expected = New Date(2013, 04, 21)
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Third))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_fourth_monday_is_some_day_in_the_middle_of_the_fourth_week()
        Dim sut = New Meetup(3, 2013)
        Dim expected = New Date(2013, 03, 25)
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Fourth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_fourth_monday_is_the_22nd_the_first_day_of_the_fourth_week()
        Dim sut = New Meetup(4, 2013)
        Dim expected = New Date(2013, 04, 22)
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Fourth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_fourth_tuesday_is_the_28th_the_last_day_of_the_fourth_week()
        Dim sut = New Meetup(5, 2013)
        Dim expected = New Date(2013, 05, 28)
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Fourth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_fourth_tuesday_is_some_day_in_the_middle_of_the_fourth_week()
        Dim sut = New Meetup(6, 2013)
        Dim expected = New Date(2013, 06, 25)
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Fourth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_fourth_wednesday_is_some_day_in_the_middle_of_the_fourth_week()
        Dim sut = New Meetup(7, 2013)
        Dim expected = New Date(2013, 07, 24)
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Fourth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_fourth_wednesday_is_the_28th_the_last_day_of_the_fourth_week()
        Dim sut = New Meetup(8, 2013)
        Dim expected = New Date(2013, 08, 28)
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Fourth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_fourth_thursday_is_some_day_in_the_middle_of_the_fourth_week()
        Dim sut = New Meetup(9, 2013)
        Dim expected = New Date(2013, 09, 26)
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Fourth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_fourth_thursday_is_another_day_in_the_middle_of_the_fourth_week()
        Dim sut = New Meetup(10, 2013)
        Dim expected = New Date(2013, 10, 24)
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Fourth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_fourth_friday_is_the_22nd_the_first_day_of_the_fourth_week()
        Dim sut = New Meetup(11, 2013)
        Dim expected = New Date(2013, 11, 22)
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Fourth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_fourth_friday_is_some_day_in_the_middle_of_the_fourth_week()
        Dim sut = New Meetup(12, 2013)
        Dim expected = New Date(2013, 12, 27)
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Fourth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_fourth_saturday_is_some_day_in_the_middle_of_the_fourth_week()
        Dim sut = New Meetup(1, 2013)
        Dim expected = New Date(2013, 01, 26)
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Fourth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_fourth_saturday_is_another_day_in_the_middle_of_the_fourth_week()
        Dim sut = New Meetup(2, 2013)
        Dim expected = New Date(2013, 02, 23)
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Fourth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_fourth_sunday_is_some_day_in_the_middle_of_the_fourth_week()
        Dim sut = New Meetup(3, 2013)
        Dim expected = New Date(2013, 03, 24)
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Fourth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_fourth_sunday_is_the_28th_the_last_day_of_the_fourth_week()
        Dim sut = New Meetup(4, 2013)
        Dim expected = New Date(2013, 04, 28)
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Fourth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_monday_in_a_month_with_four_mondays()
        Dim sut = New Meetup(3, 2013)
        Dim expected = New Date(2013, 03, 25)
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_monday_in_a_month_with_five_mondays()
        Dim sut = New Meetup(4, 2013)
        Dim expected = New Date(2013, 04, 29)
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_tuesday_in_a_month_with_four_tuesdays()
        Dim sut = New Meetup(5, 2013)
        Dim expected = New Date(2013, 05, 28)
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_tuesday_in_another_month_with_four_tuesdays()
        Dim sut = New Meetup(6, 2013)
        Dim expected = New Date(2013, 06, 25)
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_wednesday_in_a_month_with_five_wednesdays()
        Dim sut = New Meetup(7, 2013)
        Dim expected = New Date(2013, 07, 31)
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_wednesday_in_a_month_with_four_wednesdays()
        Dim sut = New Meetup(8, 2013)
        Dim expected = New Date(2013, 08, 28)
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_thursday_in_a_month_with_four_thursdays()
        Dim sut = New Meetup(9, 2013)
        Dim expected = New Date(2013, 09, 26)
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_thursday_in_a_month_with_five_thursdays()
        Dim sut = New Meetup(10, 2013)
        Dim expected = New Date(2013, 10, 31)
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_friday_in_a_month_with_five_fridays()
        Dim sut = New Meetup(11, 2013)
        Dim expected = New Date(2013, 11, 29)
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_friday_in_a_month_with_four_fridays()
        Dim sut = New Meetup(12, 2013)
        Dim expected = New Date(2013, 12, 27)
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_saturday_in_a_month_with_four_saturdays()
        Dim sut = New Meetup(1, 2013)
        Dim expected = New Date(2013, 01, 26)
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_saturday_in_another_month_with_four_saturdays()
        Dim sut = New Meetup(2, 2013)
        Dim expected = New Date(2013, 02, 23)
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_sunday_in_a_month_with_five_sundays()
        Dim sut = New Meetup(3, 2013)
        Dim expected = New Date(2013, 03, 31)
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_sunday_in_a_month_with_four_sundays()
        Dim sut = New Meetup(4, 2013)
        Dim expected = New Date(2013, 04, 28)
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_last_wednesday_in_february_in_a_leap_year_is_the_29th()
        Dim sut = New Meetup(2, 2012)
        Dim expected = New Date(2012, 02, 29)
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_wednesday_in_december_that_is_also_the_last_day_of_the_year()
        Dim sut = New Meetup(12, 2014)
        Dim expected = New Date(2014, 12, 31)
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_last_sunday_in_february_in_a_non_leap_year_is_not_the_29th()
        Dim sut = New Meetup(2, 2015)
        Dim expected = New Date(2015, 02, 22)
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_first_friday_is_the_7th_the_last_day_of_the_first_week()
        Dim sut = New Meetup(12, 2012)
        Dim expected = New Date(2012, 12, 07)
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.First))
    End Sub
End Class
