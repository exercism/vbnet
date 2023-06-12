Imports System

Public Enum DirectionType
    North
    East
    South
    West
End Enum

Public Class RobotSimulator

    Private _DirectionProp As DirectionType, _XProp As Integer, _YProp As Integer
    Public Sub New(ByVal bearing As DirectionType, ByVal x As Integer, ByVal y As Integer)
        _DirectionProp = bearing
        _XProp = x
        _YProp = y
    End Sub

    Public Property Direction As DirectionType
        Get
            Return _DirectionProp
        End Get
        Private Set(ByVal value As DirectionType)
            _DirectionProp = value
        End Set
    End Property

    Public Property X As Integer
        Get
            Return _XProp
        End Get
        Private Set(ByVal value As Integer)
            _XProp = value
        End Set
    End Property

    Public Property Y As Integer
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
        Select Case _DirectionProp
            Case DirectionType.North
                _DirectionProp = DirectionType.West
            Case DirectionType.East
                _DirectionProp = DirectionType.North
            Case DirectionType.South
                _DirectionProp = DirectionType.East
            Case DirectionType.West
                _DirectionProp = DirectionType.South
            Case Else
                Throw New ArgumentOutOfRangeException()
        End Select
    End Sub

    Private Sub TurnRight()
        Select Case _DirectionProp
            Case DirectionType.North
                _DirectionProp = DirectionType.East
            Case DirectionType.East
                _DirectionProp = DirectionType.South
            Case DirectionType.South
                _DirectionProp = DirectionType.West
            Case DirectionType.West
                _DirectionProp = DirectionType.North
            Case Else
                Throw New ArgumentOutOfRangeException()
        End Select
    End Sub

    Private Sub Advance()
        Select Case _DirectionProp
            Case DirectionType.North
                _YProp += 1
            Case DirectionType.East
                _XProp += 1
            Case DirectionType.South
                _YProp -= 1
            Case DirectionType.West
                _XProp -= 1
            Case Else
                Throw New ArgumentOutOfRangeException()
        End Select
    End Sub
End Class
