Imports System

Public Class Clock
    Private Property Minutes As Integer
    Private Const MINUTES_PER_DAY As Integer = 24 * 60

    Private Sub CalculateMinutes(ByVal mins As Integer)
        Minutes = If(mins >= 0, mins Mod MINUTES_PER_DAY, MINUTES_PER_DAY + mins Mod MINUTES_PER_DAY)
    End Sub

    Public Sub New(ByVal hours As Integer, ByVal minutes As Integer)
        CalculateMinutes(hours * 60 + minutes)
    End Sub

    Public Function Add(ByVal minutesToAdd As Integer) As Clock
        Return New Clock(0, Minutes + minutesToAdd)
    End Function

    Public Function Subtract(ByVal minutesToSubtract As Integer) As Clock
        Return New Clock(0, Minutes - minutesToSubtract)
    End Function

    Public Overrides Function ToString() As String
        Return String.Format("{0:D2}:{1:D2}", Minutes \ 60, Minutes Mod 60)
    End Function

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        If obj Is Nothing Then Return False
        Return Equals(ToString(), CType(obj, Clock).ToString())
    End Function

End Class
