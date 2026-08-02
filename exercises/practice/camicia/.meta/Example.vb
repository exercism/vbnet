Public Enum GameStatus
    Finished
    [Loop]
End Enum

Public Structure GameResult
    Public Sub New(ByVal status As GameStatus, ByVal tricks As Integer, ByVal cards As Integer)
        Me.Status = status
        Me.Tricks = tricks
        Me.Cards = cards
    End Sub

    Public ReadOnly Property Status As GameStatus
    Public ReadOnly Property Tricks As Integer
    Public ReadOnly Property Cards As Integer
End Structure

Public Module Camicia
    Private Enum Player
        A
        B
    End Enum

    Public Function SimulateGame(ByVal playerA As String(), ByVal playerB As String()) As GameResult
        Dim handA As New Queue(Of Integer)(playerA.Select(AddressOf CardValue))
        Dim handB As New Queue(Of Integer)(playerB.Select(AddressOf CardValue))
        Dim pile As New List(Of Integer)
        Dim seen As New HashSet(Of String)
        Dim activePlayer = Player.A
        Dim tricks = 0
        Dim cards = 0
        Dim debt = 0

        While True
            If IsRepeatedPosition(pile, handA, handB, activePlayer, seen) Then
                Return New GameResult(GameStatus.[Loop], tricks, cards)
            End If

            Dim activeHand = HandFor(activePlayer, handA, handB)
            Dim otherHand = HandFor(OtherPlayer(activePlayer), handA, handB)

            If activeHand.Count = 0 Then
                Return FinishedGame(tricks, cards, pile)
            End If

            Dim card = activeHand.Dequeue()
            pile.Add(card)
            cards += 1

            If card > 0 Then
                debt = card
                activePlayer = OtherPlayer(activePlayer)
            ElseIf debt > 1 Then
                debt -= 1
            ElseIf debt = 1 Then
                AwardPile(pile, otherHand)
                tricks += 1
                debt = 0

                If handA.Count = 0 OrElse handB.Count = 0 Then
                    Return New GameResult(GameStatus.Finished, tricks, cards)
                End If

                activePlayer = OtherPlayer(activePlayer)
            Else
                activePlayer = OtherPlayer(activePlayer)
            End If
        End While

        Throw New InvalidOperationException("unreachable")
    End Function

    Private Function IsRepeatedPosition(
        ByVal pile As List(Of Integer),
        ByVal handA As Queue(Of Integer),
        ByVal handB As Queue(Of Integer),
        ByVal activePlayer As Player,
        ByVal seen As HashSet(Of String)) As Boolean

        If pile.Count > 0 Then
            Return False
        End If

        Dim position = PositionKey(handA, handB, activePlayer)
        Return Not seen.Add(position)
    End Function

    Private Function FinishedGame(
        ByVal tricks As Integer,
        ByVal cards As Integer,
        ByVal pile As List(Of Integer)) As GameResult

        Dim extraTrick = If(pile.Count = 0, 0, 1)
        Return New GameResult(GameStatus.Finished, tricks + extraTrick, cards)
    End Function

    Private Function HandFor(
        ByVal player As Player,
        ByVal handA As Queue(Of Integer),
        ByVal handB As Queue(Of Integer)) As Queue(Of Integer)

        If player = Player.A Then
            Return handA
        End If

        Return handB
    End Function

    Private Sub AwardPile(ByVal pile As List(Of Integer), ByVal winner As Queue(Of Integer))
        For Each card In pile
            winner.Enqueue(card)
        Next

        pile.Clear()
    End Sub

    Private Function OtherPlayer(ByVal player As Player) As Player
        If player = Player.A Then
            Return Player.B
        End If

        Return Player.A
    End Function

    Private Function CardValue(ByVal card As String) As Integer
        Select Case card
            Case "J"
                Return 1
            Case "Q"
                Return 2
            Case "K"
                Return 3
            Case "A"
                Return 4
            Case Else
                Return 0
        End Select
    End Function

    Private Function PositionKey(
        ByVal handA As Queue(Of Integer),
        ByVal handB As Queue(Of Integer),
        ByVal activePlayer As Player) As String

        Return $"{String.Join(",", handA)}|{String.Join(",", handB)}|{activePlayer}"
    End Function
End Module
