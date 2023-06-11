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
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Function Create(ByVal row As Integer, ByVal column As Integer) As Queen
        Throw New NotImplementedException("You need to implement this function.")
    End Function
End Module
