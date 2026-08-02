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
    Public Function SimulateGame(ByVal playerA As String(), ByVal playerB As String()) As GameResult
        Throw New NotImplementedException("You need to implement this function.")
    End Function
End Module
