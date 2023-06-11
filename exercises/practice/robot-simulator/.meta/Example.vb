Imports System

Public Enum DirectionType
    North
    East
    South
    West
End Enum

Public Class RobotSimulator

    Private _DirectionProp As Direction, _XProp As Integer, _YProp As Integer
    Public Sub New(ByVal bearing As Direction, ByVal x As Integer, ByVal y As Integer)
        Direction = bearing
        X = x
        Y = y
    End Sub

    Public Property DirectionProp As Direction
        Get
            Return _DirectionProp
        End Get
        Private Set(ByVal value As Direction)
            _DirectionProp = value
        End Set
    End Property

    Public Property XProp As Integer
        Get
            Return _XProp
        End Get
        Private Set(ByVal value As Integer)
            _XProp = value
        End Set
    End Property

    Public Property YProp As Integer
        Get
            Return _YProp
        End Get
        Private Set(ByVal value As Integer)
            _YProp = value
        End Set
    End Property

    Public Sub MoveMethod(ByVal instructions As String)
        For Each instruction In instructions
            Move(instruction)
        Next
    End Sub

    Private Sub Move(ByVal code As Char)
        Select Case code
            Case "L"c
                TurnLeft()
            Case "R"c
                TurnRight()
            Case "A"c
                Advance()
            Case Else
                Throw New ArgumentOutOfRangeException("Invalid instruction")
        End Select
    End Sub

    Private Sub TurnLeft()
        Select Case Direction
            Case Me.Direction.North
                Direction = Me.Direction.West
            Case Me.Direction.East
                Direction = Me.Direction.North
            Case Me.Direction.South
                Direction = Me.Direction.East
            Case Me.Direction.West
                Direction = Me.Direction.South
            Case Else
                Throw New ArgumentOutOfRangeException()
        End Select
    End Sub

    Private Sub TurnRight()
        Select Case Direction
            Case Me.Direction.North
                Direction = Me.Direction.East
            Case Me.Direction.East
                Direction = Me.Direction.South
            Case Me.Direction.South
                Direction = Me.Direction.West
            Case Me.Direction.West
                Direction = Me.Direction.North
            Case Else
                Throw New ArgumentOutOfRangeException()
        End Select
    End Sub

    Private Sub Advance()
        Select Case Direction
            Case Me.Direction.North
                Y += 1
            Case Me.Direction.East
                X += 1
            Case Me.Direction.South
                Y -= 1
            Case Me.Direction.West
                X -= 1
            Case Else
                Throw New ArgumentOutOfRangeException()
        End Select
    End Sub
End Class
