Imports System.Collections.Generic
Imports System.Linq

Public Enum YachtCategory
    Ones = 1
    Twos = 2
    Threes = 3
    Fours = 4
    Fives = 5
    Sixes = 6
    FullHouse = 7
    FourOfAKind = 8
    LittleStraight = 9
    BigStraight = 10
    Choice = 11
    Yacht = 12
End Enum

Module YachtGame
    Function Score(ByVal dice As Integer(), ByVal category As YachtCategory) As Integer
        Select Case category
            Case YachtCategory.Ones
                Return dice.Where(Function(x) x = 1).Sum()
            Case YachtCategory.Twos
                Return dice.Where(Function(x) x = 2).Sum()
            Case YachtCategory.Threes
                Return dice.Where(Function(x) x = 3).Sum()
            Case YachtCategory.Fours
                Return dice.Where(Function(x) x = 4).Sum()
            Case YachtCategory.Fives
                Return dice.Where(Function(x) x = 5).Sum()
            Case YachtCategory.Sixes
                Return dice.Where(Function(x) x = 6).Sum()
            Case YachtCategory.FullHouse
                Dim diceByValue = dice.ToLookup(Function(x) x)
                Return If(diceByValue.Count = 2 AndAlso diceByValue.First().Count() = 2 OrElse diceByValue.First().Count() = 3, dice.Sum(), 0)
            Case YachtCategory.FourOfAKind
                Dim testDict = New Dictionary(Of Integer, Integer)()
                dice.ToList().ForEach(Sub(x)

                                          If Not testDict.ContainsKey(x) Then
                                              testDict.Add(x, 1)
                                          Else
                                              testDict(x) += 1
                                          End If
                                      End Sub)

                If testDict.Count > 2 Then
                    Return 0
                ElseIf testDict.Count = 1 OrElse testDict.ElementAt(0).Value >= 4 Then
                    Return testDict.Keys.ElementAt(0) * 4
                ElseIf testDict.ElementAt(1).Value >= 4 Then
                    Return testDict.Keys.ElementAt(1) * 4
                Else
                    Return 0
                End If

            Case YachtCategory.LittleStraight
                Return If(dice.OrderBy(Function(x) x).SequenceEqual({1, 2, 3, 4, 5}), 30, 0)
            Case YachtCategory.BigStraight
                Return If(dice.OrderBy(Function(x) x).SequenceEqual({2, 3, 4, 5, 6}), 30, 0)
            Case YachtCategory.Choice
                Return dice.Sum()
            Case YachtCategory.Yacht
                Return If(dice.Distinct().Count() = 1, 50, 0)
            Case Else
                Return 0
        End Select
    End Function
End Module
