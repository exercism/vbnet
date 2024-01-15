Imports System

Public Class Queen
    Public Sub New(ByVal row As Integer, ByVal column As Integer)
        Me.Row = row
        Me.Column = column
    End Sub

    Public ReadOnly Property Row As Integer
    Public ReadOnly Property Column As Integer
End Class

Public Module QueenAttack
    Public Function CanAttack(ByVal white As Queen, ByVal black As Queen) As Boolean
        If white.Row = black.Row AndAlso white.Column = black.Column Then
            Throw New ArgumentException("The queens cannot be positioned at the same place.")
        End If

        Return black.Row = white.Row OrElse black.Column = white.Column OrElse Math.Abs(black.Row - white.Row) = Math.Abs(black.Column - white.Column)
    End Function

    Public Function Create(ByVal row As Integer, ByVal column As Integer) As Queen
        Const MIN_VALUE = 0
        Const MAX_VALUE = 7

        If row < MIN_VALUE OrElse column < MIN_VALUE OrElse row > MAX_VALUE OrElse column > MAX_VALUE Then
            Throw New ArgumentOutOfRangeException("invalid queen position")
        End If

        Return New Queen(row, column)
    End Function
End Module
