Imports System.Collections.Generic
Imports Xunit

Public Class DndCharacterTests
    <Fact>
    Public Sub Ability_modifier_for_score_3_is_minus_4()
        Assert.Equal(-4, DndCharacter.Modifier(3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ability_modifier_for_score_4_is_minus_3()
        Assert.Equal(-3, DndCharacter.Modifier(4))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ability_modifier_for_score_5_is_minus_3()
        Assert.Equal(-3, DndCharacter.Modifier(5))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ability_modifier_for_score_6_is_minus_2()
        Assert.Equal(-2, DndCharacter.Modifier(6))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ability_modifier_for_score_7_is_minus_2()
        Assert.Equal(-2, DndCharacter.Modifier(7))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ability_modifier_for_score_8_is_minus_1()
        Assert.Equal(-1, DndCharacter.Modifier(8))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ability_modifier_for_score_9_is_minus_1()
        Assert.Equal(-1, DndCharacter.Modifier(9))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ability_modifier_for_score_10_is_0()
        Assert.Equal(0, DndCharacter.Modifier(10))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ability_modifier_for_score_11_is_0()
        Assert.Equal(0, DndCharacter.Modifier(11))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ability_modifier_for_score_12_is_1()
        Assert.Equal(1, DndCharacter.Modifier(12))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ability_modifier_for_score_13_is_1()
        Assert.Equal(1, DndCharacter.Modifier(13))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ability_modifier_for_score_14_is_2()
        Assert.Equal(2, DndCharacter.Modifier(14))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ability_modifier_for_score_15_is_2()
        Assert.Equal(2, DndCharacter.Modifier(15))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ability_modifier_for_score_16_is_3()
        Assert.Equal(3, DndCharacter.Modifier(16))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ability_modifier_for_score_17_is_3()
        Assert.Equal(3, DndCharacter.Modifier(17))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ability_modifier_for_score_18_is_4()
        Assert.Equal(4, DndCharacter.Modifier(18))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Random_ability_is_within_range()
        For i = 0 To 9
            Assert.InRange(DndCharacter.Ability(), 3, 18)
        Next
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Random_character_is_valid()
        For i = 0 To 9
            Dim sut = DndCharacter.Generate()
            Assert.InRange(sut.Strength, 3, 18)
            Assert.InRange(sut.Dexterity, 3, 18)
            Assert.InRange(sut.Constitution, 3, 18)
            Assert.InRange(sut.Intelligence, 3, 18)
            Assert.InRange(sut.Wisdom, 3, 18)
            Assert.InRange(sut.Charisma, 3, 18)
            Assert.Equal(sut.Hitpoints, 10 + DndCharacter.Modifier(sut.Constitution))
        Next
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Each_ability_is_only_calculated_once()
        For i = 0 To 9
            Dim sut = DndCharacter.Generate()
            Assert.Equal(sut.Strength, sut.Strength)
            Assert.Equal(sut.Dexterity, sut.Dexterity)
            Assert.Equal(sut.Constitution, sut.Constitution)
            Assert.Equal(sut.Intelligence, sut.Intelligence)
            Assert.Equal(sut.Wisdom, sut.Wisdom)
            Assert.Equal(sut.Charisma, sut.Charisma)
        Next
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Random_ability_is_distributed_correctly()
        Dim expectedDistribution = New Dictionary(Of Integer, Integer) From {
    {3, 1},
    {4, 4},
    {5, 10},
    {6, 21},
    {7, 38},
    {8, 62},
    {9, 91},
    {10, 122},
    {11, 148},
    {12, 167},
    {13, 172},
    {14, 160},
    {15, 131},
    {16, 94},
    {17, 54},
    {18, 21}
}

        Dim actualDistribution = New Dictionary(Of Integer, Integer)(expectedDistribution)
        For Each key In actualDistribution.Keys
            actualDistribution(key) = 0
        Next

        Const times = 250
        Const possibleCombinationsCount = 6 * 6 * 6 * 6 ' 4d6
        For i = 0 To times * possibleCombinationsCount - 1
            actualDistribution(DndCharacter.Ability()) += 1
        Next

        Const minTimes = times * 0.8
        Const maxTimes = times * 1.2
        For Each k In expectedDistribution.Keys
            Assert.InRange(actualDistribution(k), expectedDistribution(k) * minTimes, expectedDistribution(k) * maxTimes)
        Next
    End Sub
End Class
