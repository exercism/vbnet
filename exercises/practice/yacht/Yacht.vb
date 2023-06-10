Imports System

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

Public Module YachtGame
    Public Function Score(ByVal dice As Integer(), ByVal category As YachtCategory) As Integer
        Throw New NotImplementedException("You need to implement this function.")
    End Function
End Module
