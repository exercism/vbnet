Imports System.Collections.Generic
Imports System

Public Class BowlingGame
    Private Const NumberOfFrames As Integer = 10
    Private Const MaximumFrameScore As Integer = 10

    Private ReadOnly rolls As List(Of Integer) = New List(Of Integer)()

    Public Sub Roll(ByVal pins As Integer)
        If Not ValidInput(pins) Then Throw New ArgumentException()

        rolls.Add(pins)
    End Sub

    Public Function Score() As Integer?
        Dim lScore = 0
        Dim frameIndex = 0

        If rolls.Count < 12 OrElse rolls.Count > 21 Then Throw New ArgumentException()

        For i = 1 To NumberOfFrames
            If rolls.Count <= frameIndex Then
                Throw New ArgumentException()
            End If

            If IsStrike(frameIndex) Then
                If rolls.Count <= frameIndex + 2 Then
                    Throw New ArgumentException()
                End If

                Dim strikeBonus = Me.StrikeBonus(frameIndex)
                If strikeBonus > MaximumFrameScore AndAlso Not IsStrike(frameIndex + 1) OrElse strikeBonus > 20 Then
                    Throw New ArgumentException()
                End If

                lScore += 10 + strikeBonus
                frameIndex += If(i = NumberOfFrames, 3, 1)
            ElseIf IsSpare(frameIndex) Then
                If rolls.Count <= frameIndex + 2 Then
                    Throw New ArgumentException()
                End If

                lScore += 10 + SpareBonus(frameIndex)
                frameIndex += If(i = NumberOfFrames, 3, 2)
            Else
                Dim frameScore = Me.FrameScore(frameIndex)
                If frameScore < 0 OrElse frameScore > 10 Then
                    Throw New ArgumentException()
                End If

                lScore += frameScore
                frameIndex += 2
            End If
        Next

        Return If(CorrectNumberOfRolls(frameIndex), lScore, CType(Nothing, Integer?))
    End Function

    Private Function CorrectNumberOfRolls(ByVal frameIndex As Integer) As Boolean
        Return frameIndex = rolls.Count
    End Function

    Private Function IsStrike(ByVal frameIndex As Integer) As Boolean
        Return rolls(frameIndex) = MaximumFrameScore
    End Function
    Private Function IsSpare(ByVal frameIndex As Integer) As Boolean
        Return rolls(frameIndex) + rolls(frameIndex + 1) = MaximumFrameScore
    End Function

    Private Function StrikeBonus(ByVal frameIndex As Integer) As Integer
        Return rolls(frameIndex + 1) + rolls(frameIndex + 2)
    End Function
    Private Function SpareBonus(ByVal frameIndex As Integer) As Integer
        Return rolls(frameIndex + 2)
    End Function

    Private Function FrameScore(ByVal frameIndex As Integer) As Integer
        Return rolls(frameIndex) + rolls(frameIndex + 1)
    End Function

    Private Function ValidInput(ByVal pins As Integer) As Boolean
        If rolls.Count >= 21 OrElse pins < 0 OrElse pins > 10 OrElse rolls.Count + 1 Mod 2 = 0 AndAlso rolls(rolls.Count - 1) + pins > 10 Then
            Return False
        End If

        If (rolls.Count + 1) Mod 2 = 0 AndAlso rolls(rolls.Count - 1) <> 10 AndAlso rolls(rolls.Count - 1) + pins > 10 Then
            Return False
        End If

        If rolls.Count = 20 Then
            If rolls(18) <> 10 AndAlso rolls(18) + rolls(19) <> 10 Then Return False

            If pins = 10 AndAlso (rolls(18) <> 10 OrElse rolls(19) <> 10 OrElse rolls(19) + pins > 10 AndAlso rolls(19) + pins <> 20) AndAlso rolls(18) + rolls(19) <> 10 Then Return False

            If pins <> 10 AndAlso rolls(19) + pins > 10 AndAlso rolls(19) <> 10 Then Return False
        End If

        Return True
    End Function
End Class
