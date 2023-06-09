Imports System
Imports Xunit

Public Class MeetupTests
    <Fact>
    Public Sub When_teenth_monday_is_the_13th_the_first_day_of_the_teenth_week()
        Dim sut = New Meetup(5, 2013)
        Dim expected = New DateTime(2013, 5, 13)
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_monday_is_the_19th_the_last_day_of_the_teenth_week()
        Dim sut = New Meetup(8, 2013)
        Dim expected = New DateTime(2013, 8, 19)
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_monday_is_some_day_in_the_middle_of_the_teenth_week()
        Dim sut = New Meetup(9, 2013)
        Dim expected = New DateTime(2013, 9, 16)
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_tuesday_is_the_19th_the_last_day_of_the_teenth_week()
        Dim sut = New Meetup(3, 2013)
        Dim expected = New DateTime(2013, 3, 19)
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_tuesday_is_some_day_in_the_middle_of_the_teenth_week()
        Dim sut = New Meetup(4, 2013)
        Dim expected = New DateTime(2013, 4, 16)
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_tuesday_is_the_13th_the_first_day_of_the_teenth_week()
        Dim sut = New Meetup(8, 2013)
        Dim expected = New DateTime(2013, 8, 13)
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_wednesday_is_some_day_in_the_middle_of_the_teenth_week()
        Dim sut = New Meetup(1, 2013)
        Dim expected = New DateTime(2013, 1, 16)
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_wednesday_is_the_13th_the_first_day_of_the_teenth_week()
        Dim sut = New Meetup(2, 2013)
        Dim expected = New DateTime(2013, 2, 13)
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_wednesday_is_the_19th_the_last_day_of_the_teenth_week()
        Dim sut = New Meetup(6, 2013)
        Dim expected = New DateTime(2013, 6, 19)
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_thursday_is_some_day_in_the_middle_of_the_teenth_week()
        Dim sut = New Meetup(5, 2013)
        Dim expected = New DateTime(2013, 5, 16)
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_thursday_is_the_13th_the_first_day_of_the_teenth_week()
        Dim sut = New Meetup(6, 2013)
        Dim expected = New DateTime(2013, 6, 13)
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_thursday_is_the_19th_the_last_day_of_the_teenth_week()
        Dim sut = New Meetup(9, 2013)
        Dim expected = New DateTime(2013, 9, 19)
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_friday_is_the_19th_the_last_day_of_the_teenth_week()
        Dim sut = New Meetup(4, 2013)
        Dim expected = New DateTime(2013, 4, 19)
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_friday_is_some_day_in_the_middle_of_the_teenth_week()
        Dim sut = New Meetup(8, 2013)
        Dim expected = New DateTime(2013, 8, 16)
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_friday_is_the_13th_the_first_day_of_the_teenth_week()
        Dim sut = New Meetup(9, 2013)
        Dim expected = New DateTime(2013, 9, 13)
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_saturday_is_some_day_in_the_middle_of_the_teenth_week()
        Dim sut = New Meetup(2, 2013)
        Dim expected = New DateTime(2013, 2, 16)
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_saturday_is_the_13th_the_first_day_of_the_teenth_week()
        Dim sut = New Meetup(4, 2013)
        Dim expected = New DateTime(2013, 4, 13)
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_saturday_is_the_19th_the_last_day_of_the_teenth_week()
        Dim sut = New Meetup(10, 2013)
        Dim expected = New DateTime(2013, 10, 19)
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_sunday_is_the_19th_the_last_day_of_the_teenth_week()
        Dim sut = New Meetup(5, 2013)
        Dim expected = New DateTime(2013, 5, 19)
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_sunday_is_some_day_in_the_middle_of_the_teenth_week()
        Dim sut = New Meetup(6, 2013)
        Dim expected = New DateTime(2013, 6, 16)
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_teenth_sunday_is_the_13th_the_first_day_of_the_teenth_week()
        Dim sut = New Meetup(10, 2013)
        Dim expected = New DateTime(2013, 10, 13)
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Teenth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_first_monday_is_some_day_in_the_middle_of_the_first_week()
        Dim sut = New Meetup(3, 2013)
        Dim expected = New DateTime(2013, 3, 4)
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.First))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_first_monday_is_the_1st_the_first_day_of_the_first_week()
        Dim sut = New Meetup(4, 2013)
        Dim expected = New DateTime(2013, 4, 1)
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.First))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_first_tuesday_is_the_7th_the_last_day_of_the_first_week()
        Dim sut = New Meetup(5, 2013)
        Dim expected = New DateTime(2013, 5, 7)
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.First))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_first_tuesday_is_some_day_in_the_middle_of_the_first_week()
        Dim sut = New Meetup(6, 2013)
        Dim expected = New DateTime(2013, 6, 4)
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.First))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_first_wednesday_is_some_day_in_the_middle_of_the_first_week()
        Dim sut = New Meetup(7, 2013)
        Dim expected = New DateTime(2013, 7, 3)
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.First))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_first_wednesday_is_the_7th_the_last_day_of_the_first_week()
        Dim sut = New Meetup(8, 2013)
        Dim expected = New DateTime(2013, 8, 7)
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.First))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_first_thursday_is_some_day_in_the_middle_of_the_first_week()
        Dim sut = New Meetup(9, 2013)
        Dim expected = New DateTime(2013, 9, 5)
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.First))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_first_thursday_is_another_day_in_the_middle_of_the_first_week()
        Dim sut = New Meetup(10, 2013)
        Dim expected = New DateTime(2013, 10, 3)
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.First))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_first_friday_is_the_1st_the_first_day_of_the_first_week()
        Dim sut = New Meetup(11, 2013)
        Dim expected = New DateTime(2013, 11, 1)
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.First))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_first_friday_is_some_day_in_the_middle_of_the_first_week()
        Dim sut = New Meetup(12, 2013)
        Dim expected = New DateTime(2013, 12, 6)
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.First))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_first_saturday_is_some_day_in_the_middle_of_the_first_week()
        Dim sut = New Meetup(1, 2013)
        Dim expected = New DateTime(2013, 1, 5)
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.First))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_first_saturday_is_another_day_in_the_middle_of_the_first_week()
        Dim sut = New Meetup(2, 2013)
        Dim expected = New DateTime(2013, 2, 2)
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.First))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_first_sunday_is_some_day_in_the_middle_of_the_first_week()
        Dim sut = New Meetup(3, 2013)
        Dim expected = New DateTime(2013, 3, 3)
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.First))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_first_sunday_is_the_7th_the_last_day_of_the_first_week()
        Dim sut = New Meetup(4, 2013)
        Dim expected = New DateTime(2013, 4, 7)
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.First))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_second_monday_is_some_day_in_the_middle_of_the_second_week()
        Dim sut = New Meetup(3, 2013)
        Dim expected = New DateTime(2013, 3, 11)
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Second))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_second_monday_is_the_8th_the_first_day_of_the_second_week()
        Dim sut = New Meetup(4, 2013)
        Dim expected = New DateTime(2013, 4, 8)
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Second))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_second_tuesday_is_the_14th_the_last_day_of_the_second_week()
        Dim sut = New Meetup(5, 2013)
        Dim expected = New DateTime(2013, 5, 14)
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Second))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_second_tuesday_is_some_day_in_the_middle_of_the_second_week()
        Dim sut = New Meetup(6, 2013)
        Dim expected = New DateTime(2013, 6, 11)
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Second))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_second_wednesday_is_some_day_in_the_middle_of_the_second_week()
        Dim sut = New Meetup(7, 2013)
        Dim expected = New DateTime(2013, 7, 10)
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Second))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_second_wednesday_is_the_14th_the_last_day_of_the_second_week()
        Dim sut = New Meetup(8, 2013)
        Dim expected = New DateTime(2013, 8, 14)
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Second))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_second_thursday_is_some_day_in_the_middle_of_the_second_week()
        Dim sut = New Meetup(9, 2013)
        Dim expected = New DateTime(2013, 9, 12)
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Second))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_second_thursday_is_another_day_in_the_middle_of_the_second_week()
        Dim sut = New Meetup(10, 2013)
        Dim expected = New DateTime(2013, 10, 10)
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Second))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_second_friday_is_the_8th_the_first_day_of_the_second_week()
        Dim sut = New Meetup(11, 2013)
        Dim expected = New DateTime(2013, 11, 8)
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Second))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_second_friday_is_some_day_in_the_middle_of_the_second_week()
        Dim sut = New Meetup(12, 2013)
        Dim expected = New DateTime(2013, 12, 13)
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Second))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_second_saturday_is_some_day_in_the_middle_of_the_second_week()
        Dim sut = New Meetup(1, 2013)
        Dim expected = New DateTime(2013, 1, 12)
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Second))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_second_saturday_is_another_day_in_the_middle_of_the_second_week()
        Dim sut = New Meetup(2, 2013)
        Dim expected = New DateTime(2013, 2, 9)
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Second))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_second_sunday_is_some_day_in_the_middle_of_the_second_week()
        Dim sut = New Meetup(3, 2013)
        Dim expected = New DateTime(2013, 3, 10)
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Second))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_second_sunday_is_the_14th_the_last_day_of_the_second_week()
        Dim sut = New Meetup(4, 2013)
        Dim expected = New DateTime(2013, 4, 14)
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Second))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_third_monday_is_some_day_in_the_middle_of_the_third_week()
        Dim sut = New Meetup(3, 2013)
        Dim expected = New DateTime(2013, 3, 18)
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Third))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_third_monday_is_the_15th_the_first_day_of_the_third_week()
        Dim sut = New Meetup(4, 2013)
        Dim expected = New DateTime(2013, 4, 15)
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Third))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_third_tuesday_is_the_21st_the_last_day_of_the_third_week()
        Dim sut = New Meetup(5, 2013)
        Dim expected = New DateTime(2013, 5, 21)
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Third))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_third_tuesday_is_some_day_in_the_middle_of_the_third_week()
        Dim sut = New Meetup(6, 2013)
        Dim expected = New DateTime(2013, 6, 18)
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Third))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_third_wednesday_is_some_day_in_the_middle_of_the_third_week()
        Dim sut = New Meetup(7, 2013)
        Dim expected = New DateTime(2013, 7, 17)
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Third))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_third_wednesday_is_the_21st_the_last_day_of_the_third_week()
        Dim sut = New Meetup(8, 2013)
        Dim expected = New DateTime(2013, 8, 21)
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Third))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_third_thursday_is_some_day_in_the_middle_of_the_third_week()
        Dim sut = New Meetup(9, 2013)
        Dim expected = New DateTime(2013, 9, 19)
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Third))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_third_thursday_is_another_day_in_the_middle_of_the_third_week()
        Dim sut = New Meetup(10, 2013)
        Dim expected = New DateTime(2013, 10, 17)
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Third))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_third_friday_is_the_15th_the_first_day_of_the_third_week()
        Dim sut = New Meetup(11, 2013)
        Dim expected = New DateTime(2013, 11, 15)
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Third))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_third_friday_is_some_day_in_the_middle_of_the_third_week()
        Dim sut = New Meetup(12, 2013)
        Dim expected = New DateTime(2013, 12, 20)
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Third))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_third_saturday_is_some_day_in_the_middle_of_the_third_week()
        Dim sut = New Meetup(1, 2013)
        Dim expected = New DateTime(2013, 1, 19)
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Third))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_third_saturday_is_another_day_in_the_middle_of_the_third_week()
        Dim sut = New Meetup(2, 2013)
        Dim expected = New DateTime(2013, 2, 16)
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Third))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_third_sunday_is_some_day_in_the_middle_of_the_third_week()
        Dim sut = New Meetup(3, 2013)
        Dim expected = New DateTime(2013, 3, 17)
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Third))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_third_sunday_is_the_21st_the_last_day_of_the_third_week()
        Dim sut = New Meetup(4, 2013)
        Dim expected = New DateTime(2013, 4, 21)
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Third))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_fourth_monday_is_some_day_in_the_middle_of_the_fourth_week()
        Dim sut = New Meetup(3, 2013)
        Dim expected = New DateTime(2013, 3, 25)
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Fourth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_fourth_monday_is_the_22nd_the_first_day_of_the_fourth_week()
        Dim sut = New Meetup(4, 2013)
        Dim expected = New DateTime(2013, 4, 22)
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Fourth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_fourth_tuesday_is_the_28th_the_last_day_of_the_fourth_week()
        Dim sut = New Meetup(5, 2013)
        Dim expected = New DateTime(2013, 5, 28)
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Fourth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_fourth_tuesday_is_some_day_in_the_middle_of_the_fourth_week()
        Dim sut = New Meetup(6, 2013)
        Dim expected = New DateTime(2013, 6, 25)
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Fourth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_fourth_wednesday_is_some_day_in_the_middle_of_the_fourth_week()
        Dim sut = New Meetup(7, 2013)
        Dim expected = New DateTime(2013, 7, 24)
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Fourth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_fourth_wednesday_is_the_28th_the_last_day_of_the_fourth_week()
        Dim sut = New Meetup(8, 2013)
        Dim expected = New DateTime(2013, 8, 28)
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Fourth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_fourth_thursday_is_some_day_in_the_middle_of_the_fourth_week()
        Dim sut = New Meetup(9, 2013)
        Dim expected = New DateTime(2013, 9, 26)
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Fourth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_fourth_thursday_is_another_day_in_the_middle_of_the_fourth_week()
        Dim sut = New Meetup(10, 2013)
        Dim expected = New DateTime(2013, 10, 24)
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Fourth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_fourth_friday_is_the_22nd_the_first_day_of_the_fourth_week()
        Dim sut = New Meetup(11, 2013)
        Dim expected = New DateTime(2013, 11, 22)
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Fourth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_fourth_friday_is_some_day_in_the_middle_of_the_fourth_week()
        Dim sut = New Meetup(12, 2013)
        Dim expected = New DateTime(2013, 12, 27)
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Fourth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_fourth_saturday_is_some_day_in_the_middle_of_the_fourth_week()
        Dim sut = New Meetup(1, 2013)
        Dim expected = New DateTime(2013, 1, 26)
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Fourth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_fourth_saturday_is_another_day_in_the_middle_of_the_fourth_week()
        Dim sut = New Meetup(2, 2013)
        Dim expected = New DateTime(2013, 2, 23)
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Fourth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_fourth_sunday_is_some_day_in_the_middle_of_the_fourth_week()
        Dim sut = New Meetup(3, 2013)
        Dim expected = New DateTime(2013, 3, 24)
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Fourth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_fourth_sunday_is_the_28th_the_last_day_of_the_fourth_week()
        Dim sut = New Meetup(4, 2013)
        Dim expected = New DateTime(2013, 4, 28)
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Fourth))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_monday_in_a_month_with_four_mondays()
        Dim sut = New Meetup(3, 2013)
        Dim expected = New DateTime(2013, 3, 25)
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_monday_in_a_month_with_five_mondays()
        Dim sut = New Meetup(4, 2013)
        Dim expected = New DateTime(2013, 4, 29)
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_tuesday_in_a_month_with_four_tuesdays()
        Dim sut = New Meetup(5, 2013)
        Dim expected = New DateTime(2013, 5, 28)
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_tuesday_in_another_month_with_four_tuesdays()
        Dim sut = New Meetup(6, 2013)
        Dim expected = New DateTime(2013, 6, 25)
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_wednesday_in_a_month_with_five_wednesdays()
        Dim sut = New Meetup(7, 2013)
        Dim expected = New DateTime(2013, 7, 31)
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_wednesday_in_a_month_with_four_wednesdays()
        Dim sut = New Meetup(8, 2013)
        Dim expected = New DateTime(2013, 8, 28)
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_thursday_in_a_month_with_four_thursdays()
        Dim sut = New Meetup(9, 2013)
        Dim expected = New DateTime(2013, 9, 26)
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_thursday_in_a_month_with_five_thursdays()
        Dim sut = New Meetup(10, 2013)
        Dim expected = New DateTime(2013, 10, 31)
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_friday_in_a_month_with_five_fridays()
        Dim sut = New Meetup(11, 2013)
        Dim expected = New DateTime(2013, 11, 29)
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_friday_in_a_month_with_four_fridays()
        Dim sut = New Meetup(12, 2013)
        Dim expected = New DateTime(2013, 12, 27)
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_saturday_in_a_month_with_four_saturdays()
        Dim sut = New Meetup(1, 2013)
        Dim expected = New DateTime(2013, 1, 26)
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_saturday_in_another_month_with_four_saturdays()
        Dim sut = New Meetup(2, 2013)
        Dim expected = New DateTime(2013, 2, 23)
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_sunday_in_a_month_with_five_sundays()
        Dim sut = New Meetup(3, 2013)
        Dim expected = New DateTime(2013, 3, 31)
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_sunday_in_a_month_with_four_sundays()
        Dim sut = New Meetup(4, 2013)
        Dim expected = New DateTime(2013, 4, 28)
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_last_wednesday_in_february_in_a_leap_year_is_the_29th()
        Dim sut = New Meetup(2, 2012)
        Dim expected = New DateTime(2012, 2, 29)
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_wednesday_in_december_that_is_also_the_last_day_of_the_year()
        Dim sut = New Meetup(12, 2014)
        Dim expected = New DateTime(2014, 12, 31)
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_last_sunday_in_february_in_a_non_leap_year_is_not_the_29th()
        Dim sut = New Meetup(2, 2015)
        Dim expected = New DateTime(2015, 2, 22)
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Last))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_first_friday_is_the_7th_the_last_day_of_the_first_week()
        Dim sut = New Meetup(12, 2012)
        Dim expected = New DateTime(2012, 12, 7)
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.First))
    End Sub
End Class
