Imports System
Imports System.Linq

Public Class DndCharacter
    Private Shared ReadOnly Random As Random = New Random()

    Public Sub New(ByVal strength As Integer, ByVal dexterity As Integer, ByVal constitution As Integer, ByVal intelligence As Integer, ByVal wisdom As Integer, ByVal charisma As Integer)
        Me.Strength = strength
        Me.Dexterity = dexterity
        Me.Constitution = constitution
        Me.Intelligence = intelligence
        Me.Wisdom = wisdom
        Me.Charisma = charisma
        Hitpoints = 10 + Modifier(constitution)
    End Sub

    Public ReadOnly Property Strength As Integer
    Public ReadOnly Property Dexterity As Integer
    Public ReadOnly Property Constitution As Integer
    Public ReadOnly Property Intelligence As Integer
    Public ReadOnly Property Wisdom As Integer
    Public ReadOnly Property Charisma As Integer
    Public ReadOnly Property Hitpoints As Integer

    Public Shared Function Modifier(ByVal score As Integer) As Integer
        Return Math.Floor((score - 10) / 2.0)
    End Function

    Public Shared Function Ability() As Integer
        Return Enumerable.Take(Of Integer)(Enumerable.OrderByDescending(Of Integer, Global.System.Int32)(Enumerable.Select(Of Integer, Global.System.Int32)(Enumerable.Range(CInt(0), CInt(4)), CType(Function(__) CInt(RollDie()), Func(Of Integer, Integer))), CType(Function(score) CInt(score), Func(Of Integer, Integer))), CInt(3)).Sum()
    End Function

    Private Shared Function RollDie() As Integer
        Return Random.Next(1, 7)
    End Function

    Public Shared Function Generate() As DndCharacter
        Return New DndCharacter(Ability(), Ability(), Ability(), Ability(), Ability(), Ability())
    End Function
End Class
