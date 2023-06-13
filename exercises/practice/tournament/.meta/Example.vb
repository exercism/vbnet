Imports System.Collections.Generic
Imports System.IO
Imports System.Linq

''' <summary>
''' Tournament tally system.
''' </summary>
Public Class Tournament
    Friend Enum Outcome
        LOSS
        DRAW
        WIN
    End Enum

    Friend Class TeamResult
        Friend Losses As UInteger
        Friend Draws As UInteger
        Friend Wins As UInteger

        Friend ReadOnly Property Played As UInteger
            Get
                Return Losses + Draws + Wins
            End Get
        End Property

        Friend ReadOnly Property Score As UInteger
            Get
                Return Wins * 3 + Draws
            End Get
        End Property

        Friend Sub AddOutcome(ByVal outcome As Tournament.Outcome)
            Select Case outcome
                Case Tournament.Outcome.LOSS
                    Losses += 1
                Case Tournament.Outcome.DRAW
                    Draws += 1
                Case Tournament.Outcome.WIN
                    Wins += 1
            End Select
        End Sub
    End Class

    Private teams As Dictionary(Of String, Tournament.TeamResult)

    Private Sub New()
        teams = New Dictionary(Of String, Tournament.TeamResult)()
    End Sub

    Private Sub AddResult(ByVal team1 As String, ByVal team2 As String, ByVal outcome As Tournament.Outcome)
        ' Invert outcome for the second team.
        Dim outcome2 As Tournament.Outcome = If(outcome = Tournament.Outcome.WIN, Tournament.Outcome.LOSS, If(outcome = Tournament.Outcome.LOSS, Tournament.Outcome.WIN, Tournament.Outcome.DRAW))
        Me.AddTeamOutcome(team1, outcome)
        Me.AddTeamOutcome(team2, outcome2)
    End Sub

    Private Sub AddTeamOutcome(ByVal team As String, ByVal outcome As Tournament.Outcome)
        Dim teamResult As Tournament.TeamResult
        If teams.TryGetValue(team, teamResult) Then
            teamResult.AddOutcome(outcome)
        Else
            teamResult = New Tournament.TeamResult()
            teamResult.AddOutcome(outcome)
            teams.Add(team, teamResult)
        End If
    End Sub

    Private Sub WriteResults(ByVal writer As TextWriter)
        Dim headerSuffix = If(teams.Any(), vbLf, "")
        writer.Write("{0,-30:S} | {1,2:D} | {2,2:D} | {3,2:D} | {4,2:D} | {5,2:D}{6}", "Team", "MP", "W", "D", "L", "P", headerSuffix)

        Dim pairs = teams.OrderByDescending(Function(pair) pair.Value.Score).ThenBy(Function(pair) pair.Key).ToArray()

        For i = 0 To pairs.Length - 1
            Dim pair = pairs(i)
            Dim suffix = If(i = pairs.Length - 1, "", vbLf)
            writer.Write("{0,-30:S} | {1,2:D} | {2,2:D} | {3,2:D} | {4,2:D} | {5,2:D}{6}", pair.Key, pair.Value.Played, pair.Value.Wins, pair.Value.Draws, pair.Value.Losses, pair.Value.Score, suffix)
        Next
        writer.Flush()
    End Sub

    Public Shared Sub Tally(ByVal inStream As Stream, ByVal outStream As Stream)
        Dim tournament = New Tournament()
        Dim encoding = New UTF8Encoding()
        Dim inReader = New StreamReader(inStream, encoding)

        Dim line = inReader.ReadLine()

        While Not Equals(line, Nothing)
            Dim parts = line.Trim().Split(";"c)
            If parts.Length <> 3 Then Continue While
            Dim outcome As Tournament.Outcome
            Select Case parts(2).ToLower()
                Case "loss"
                    outcome = Tournament.Outcome.LOSS
                Case "draw"
                    outcome = Tournament.Outcome.DRAW
                Case "win"
                    outcome = Tournament.Outcome.WIN
                Case Else
                    Continue While
            End Select
            tournament.AddResult(parts(0), parts(1), outcome)
            line = inReader.ReadLine()
        End While

        Dim outWriter = New StreamWriter(outStream, encoding)
        outWriter.NewLine = vbLf
        tournament.WriteResults(outWriter)
    End Sub
End Class
