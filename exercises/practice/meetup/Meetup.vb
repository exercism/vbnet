Imports System

Public Enum ScheduleType
    Teenth
    First
    Second
    Third
    Fourth
    Last
End Enum

Public Class Meetup
    Public Sub New(ByVal month As Integer, ByVal year As Integer)
    End Sub

    Public Function Day(ByVal dayOfWeek As DayOfWeek, ByVal schedule As Schedule) As Date
        Throw New NotImplementedException("You need to implement this function.")
    End Function
End Class
