Imports System

Public Enum Direction
    North
    East
    South
    West
End Enum

Public Class RobotSimulator
    Public Sub New(ByVal direction As Direction, ByVal x As Integer, ByVal y As Integer)
    End Sub

    Public ReadOnly Property Direction As Direction
        Get
            Throw New NotImplementedException("You need to implement this function.")
        End Get
    End Property

    Public ReadOnly Property X As Integer
        Get
            Throw New NotImplementedException("You need to implement this function.")
        End Get
    End Property

    Public ReadOnly Property Y As Integer
        Get
            Throw New NotImplementedException("You need to implement this function.")
        End Get
    End Property

    Public Sub Move(ByVal instructions As String)
        Throw New NotImplementedException("You need to implement this function.")
    End Sub
End Class
