Imports System
Imports Xunit

Public Class QueenAttackTests
    <Fact>
    Public Sub Queen_with_a_valid_position()
        Dim actual = Create(2, 2)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Queen_must_have_positive_row()
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() Create(-2, 2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Queen_must_have_row_on_board()
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() Create(8, 4))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Queen_must_have_positive_column()
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() Create(2, -2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Queen_must_have_column_on_board()
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() Create(4, 8))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cannot_attack()
        Dim whiteQueen = Create(2, 4)
        Dim blackQueen = Create(6, 6)
        Assert.False(CanAttack(whiteQueen, blackQueen))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_attack_on_same_row()
        Dim whiteQueen = Create(2, 4)
        Dim blackQueen = Create(2, 6)
        Assert.True(CanAttack(whiteQueen, blackQueen))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_attack_on_same_column()
        Dim whiteQueen = Create(4, 5)
        Dim blackQueen = Create(2, 5)
        Assert.True(CanAttack(whiteQueen, blackQueen))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_attack_on_first_diagonal()
        Dim whiteQueen = Create(2, 2)
        Dim blackQueen = Create(0, 4)
        Assert.True(CanAttack(whiteQueen, blackQueen))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_attack_on_second_diagonal()
        Dim whiteQueen = Create(2, 2)
        Dim blackQueen = Create(3, 1)
        Assert.True(CanAttack(whiteQueen, blackQueen))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_attack_on_third_diagonal()
        Dim whiteQueen = Create(2, 2)
        Dim blackQueen = Create(1, 1)
        Assert.True(CanAttack(whiteQueen, blackQueen))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_attack_on_fourth_diagonal()
        Dim whiteQueen = Create(1, 7)
        Dim blackQueen = Create(0, 6)
        Assert.True(CanAttack(whiteQueen, blackQueen))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cannot_attack_if_falling_diagonals_are_only_the_same_when_reflected_across_the_longest_falling_diagonal()
        Dim whiteQueen = Create(4, 1)
        Dim blackQueen = Create(2, 5)
        Assert.False(CanAttack(whiteQueen, blackQueen))
    End Sub
End Class
