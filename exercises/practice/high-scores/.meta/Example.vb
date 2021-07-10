Imports System
Imports System.Collections.Generic
Imports System.Linq

Public Class HighScores
    Private scoresField = New List(Of Integer)

    Public Sub New(ByVal list As List(Of Integer))
        scoresField = list
    End Sub

    Public Function Scores() As List(Of Integer)
        Return scoresField
    End Function

    Public Function Latest() As Integer
        Return Enumerable.Last(scoresField)
    End Function

    Public Function PersonalBest() As Integer
        Return Enumerable.Max(scoresField)
    End Function

    Public Function PersonalTopThree() As List(Of Integer)
        Return (From score 
                In scores 
                Order By -score 
                Select score).Take(3).ToList()
    End Function
End Class
