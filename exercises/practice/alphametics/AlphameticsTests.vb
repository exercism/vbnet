Imports System
Imports System.Collections.Generic
Imports Xunit

Public Class AlphameticsTests
    <Fact>
    Public Sub Puzzle_with_three_letters()
        Dim actual = Alphametics.Solve("I + BB == ILL")
        Dim expected = New Dictionary(Of Char, Integer) From {
    {"I"c, 1},
    {"B"c, 9},
    {"L"c, 0}
}
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Solution_must_have_unique_value_for_each_letter()
        Assert.Throws(Of ArgumentException)(Function() Alphametics.Solve("A == B"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Leading_zero_solution_is_invalid()
        Assert.Throws(Of ArgumentException)(Function() Alphametics.Solve("ACA + DD == BD"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Puzzle_with_two_digits_final_carry()
        Dim actual = Alphametics.Solve("A + A + A + A + A + A + A + A + A + A + A + B == BCC")
        Dim expected = New Dictionary(Of Char, Integer) From {
    {"A"c, 9},
    {"B"c, 1},
    {"C"c, 0}
}
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Puzzle_with_four_letters()
        Dim actual = Alphametics.Solve("AS + A == MOM")
        Dim expected = New Dictionary(Of Char, Integer) From {
    {"A"c, 9},
    {"S"c, 2},
    {"M"c, 1},
    {"O"c, 0}
}
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Puzzle_with_six_letters()
        Dim actual = Alphametics.Solve("NO + NO + TOO == LATE")
        Dim expected = New Dictionary(Of Char, Integer) From {
    {"N"c, 7},
    {"O"c, 4},
    {"T"c, 9},
    {"L"c, 1},
    {"A"c, 0},
    {"E"c, 2}
}
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Puzzle_with_seven_letters()
        Dim actual = Alphametics.Solve("HE + SEES + THE == LIGHT")
        Dim expected = New Dictionary(Of Char, Integer) From {
    {"E"c, 4},
    {"G"c, 2},
    {"H"c, 5},
    {"I"c, 0},
    {"L"c, 1},
    {"S"c, 9},
    {"T"c, 7}
}
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Puzzle_with_eight_letters()
        Dim actual = Alphametics.Solve("SEND + MORE == MONEY")
        Dim expected = New Dictionary(Of Char, Integer) From {
    {"S"c, 9},
    {"E"c, 5},
    {"N"c, 6},
    {"D"c, 7},
    {"M"c, 1},
    {"O"c, 0},
    {"R"c, 8},
    {"Y"c, 2}
}
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Puzzle_with_ten_letters()
        Dim actual = Alphametics.Solve("AND + A + STRONG + OFFENSE + AS + A + GOOD == DEFENSE")
        Dim expected = New Dictionary(Of Char, Integer) From {
    {"A"c, 5},
    {"D"c, 3},
    {"E"c, 4},
    {"F"c, 7},
    {"G"c, 8},
    {"N"c, 0},
    {"O"c, 2},
    {"R"c, 1},
    {"S"c, 6},
    {"T"c, 9}
}
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Puzzle_with_ten_letters_and_199_addends()
        Dim actual = Alphametics.Solve("THIS + A + FIRE + THEREFORE + FOR + ALL + HISTORIES + I + TELL + A + TALE + THAT + FALSIFIES + ITS + TITLE + TIS + A + LIE + THE + TALE + OF + THE + LAST + FIRE + HORSES + LATE + AFTER + THE + FIRST + FATHERS + FORESEE + THE + HORRORS + THE + LAST + FREE + TROLL + TERRIFIES + THE + HORSES + OF + FIRE + THE + TROLL + RESTS + AT + THE + HOLE + OF + LOSSES + IT + IS + THERE + THAT + SHE + STORES + ROLES + OF + LEATHERS + AFTER + SHE + SATISFIES + HER + HATE + OFF + THOSE + FEARS + A + TASTE + RISES + AS + SHE + HEARS + THE + LEAST + FAR + HORSE + THOSE + FAST + HORSES + THAT + FIRST + HEAR + THE + TROLL + FLEE + OFF + TO + THE + FOREST + THE + HORSES + THAT + ALERTS + RAISE + THE + STARES + OF + THE + OTHERS + AS + THE + TROLL + ASSAILS + AT + THE + TOTAL + SHIFT + HER + TEETH + TEAR + HOOF + OFF + TORSO + AS + THE + LAST + HORSE + FORFEITS + ITS + LIFE + THE + FIRST + FATHERS + HEAR + OF + THE + HORRORS + THEIR + FEARS + THAT + THE + FIRES + FOR + THEIR + FEASTS + ARREST + AS + THE + FIRST + FATHERS + RESETTLE + THE + LAST + OF + THE + FIRE + HORSES + THE + LAST + TROLL + HARASSES + THE + FOREST + HEART + FREE + AT + LAST + OF + THE + LAST + TROLL + ALL + OFFER + THEIR + FIRE + HEAT + TO + THE + ASSISTERS + FAR + OFF + THE + TROLL + FASTS + ITS + LIFE + SHORTER + AS + STARS + RISE + THE + HORSES + REST + SAFE + AFTER + ALL + SHARE + HOT + FISH + AS + THEIR + AFFILIATES + TAILOR + A + ROOFS + FOR + THEIR + SAFE == FORTRESSES")
        Dim expected = New Dictionary(Of Char, Integer) From {
    {"A"c, 1},
    {"E"c, 0},
    {"F"c, 5},
    {"H"c, 8},
    {"I"c, 7},
    {"L"c, 2},
    {"O"c, 6},
    {"R"c, 3},
    {"S"c, 4},
    {"T"c, 9}
}
        Assert.Equal(expected, actual)
    End Sub
End Class
