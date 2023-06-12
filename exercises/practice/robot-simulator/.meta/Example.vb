Imports System

Public Enum DirectionType
    North
    East
    South
    West
End Enum

Public Class RobotSimulator
    Public Sub New(ByVal bearing As DirectionType, ByVal x As Integer, ByVal y As Integer)
        Direction = bearing
        X = x
        Y = y
    End Sub

    Public Property Direction As DirectionType
    Public Property X As Integer
    Public Property Y As Integer

    Public Sub Move(ByVal instructions As String)
        For Each instruction In instructions
            Move(instruction)
        Next
    End Sub

    Public Sub Move(ByVal code As Char)
        Select Case code
            Case "L"c
                TurnLeft()
            Case "R"c
                TurnRight()
            Case "A"c
                Advance()
            Case Else
                Throw New ArgumentOutOfRangeException(code)
        End Select
    End Sub

    Private Sub TurnLeft()
        Select Case Direction
            Case DirectionType.North
                Direction = DirectionType.West
            Case DirectionType.East
                Direction = DirectionType.North
            Case DirectionType.South
                Direction = DirectionType.East
            Case DirectionType.West
                Direction = DirectionType.South
            Case Else
                Throw New ArgumentOutOfRangeException()
        End Select
    End Sub

    Private Sub TurnRight()
        Select Case Direction
            Case DirectionType.North
                Direction = DirectionType.East
            Case DirectionType.East
                Direction = DirectionType.South
            Case DirectionType.South
                Direction = DirectionType.West
            Case DirectionType.West
                Direction = DirectionType.North
            Case Else
                Throw New ArgumentOutOfRangeException()
        End Select
    End Sub

    Private Sub Advance()
        Select Case Direction
            Case DirectionType.North
                Y += 1
            Case DirectionType.East
                X += 1
            Case DirectionType.South
                Y -= 1
            Case DirectionType.West
                X -= 1
            Case Else
                Throw New ArgumentOutOfRangeException()
        End Select
    End Sub
End Class
