Imports System
Imports System.Collections.Generic

Public Enum Schedule
    Teenth
    First
    Second
    Third
    Fourth
    Last
End Enum

Public Class Meetup
    Private ReadOnly month As Integer
    Private ReadOnly year As Integer
    Private ReadOnly schedulers As Dictionary(Of Schedule, Scheduler)

    Public Sub New(ByVal month As Integer, ByVal year As Integer)
        Me.month = month
        Me.year = year
        schedulers = New Dictionary(Of Schedule, Scheduler) From {
    {Schedule.Teenth, New TeenthScheduler()},
    {Schedule.First, New WeekNumberScheduler(1)},
    {Schedule.Second, New WeekNumberScheduler(2)},
    {Schedule.Third, New WeekNumberScheduler(3)},
    {Schedule.Fourth, New WeekNumberScheduler(4)},
    {Schedule.Last, New LastScheduler()}
}
    End Sub

    Public Function Day(ByVal dayOfWeek As DayOfWeek, ByVal schedule As Schedule) As Date
        Return schedulers(schedule).Day(year, month, dayOfWeek)
    End Function

    Private MustInherit Class Scheduler
        Public MustOverride Function Day(ByVal year As Integer, ByVal month As Integer, ByVal dayOfWeek As DayOfWeek) As Date

        Protected Shared Function FindFirstDayOfWeek(ByVal dayOfWeek As DayOfWeek, ByVal startingDate As Date, ByVal [step] As Integer) As Date
            Dim [date] = startingDate
            While [date].DayOfWeek <> dayOfWeek
                [date] = [date].AddDays([step])
            End While
            Return [date]
        End Function
    End Class

    Private Class TeenthScheduler
        Inherits Scheduler
        Public Overrides Function Day(ByVal year As Integer, ByVal month As Integer, ByVal dayOfWeek As DayOfWeek) As Date
            Return FindFirstDayOfWeek(dayOfWeek, New DateTime(year, month, 13), 1)
        End Function
    End Class

    Private Class WeekNumberScheduler
        Inherits Scheduler
        Private ReadOnly nthWeek As Integer

        Public Sub New(ByVal nthWeek As Integer)
            Me.nthWeek = nthWeek - 1
        End Sub

        Public Overrides Function Day(ByVal year As Integer, ByVal month As Integer, ByVal dayOfWeek As DayOfWeek) As Date
            Dim [date] = FindFirstDayOfWeek(dayOfWeek, New DateTime(year, month, 1), 1)
            Return [date].AddDays(nthWeek * 7)
        End Function
    End Class

    Private Class LastScheduler
        Inherits Scheduler
        Public Overrides Function Day(ByVal year As Integer, ByVal month As Integer, ByVal dayOfWeek As DayOfWeek) As Date
            Dim startingDate = New DateTime(year, month, Date.DaysInMonth(year, month))
            Return FindFirstDayOfWeek(dayOfWeek, startingDate, -1)
        End Function
    End Class
End Class
