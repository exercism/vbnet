Imports System.Collections.Generic
Imports System.Linq

Public Module ScrabbleScore
    Private ReadOnly LetterScores As Dictionary(Of Char, Integer) = New Dictionary(Of Char, Integer) From {
    {"a"c, 1},
{"e"c, 1},
{"i"c, 1},
{"o"c, 1},
{"u"c, 1},
{"l"c, 1},
{"n"c, 1},
{"r"c, 1},
{"s"c, 1},
{"t"c, 1},
    {"d"c, 2},
{"g"c, 2},
    {"b"c, 3},
{"c"c, 3},
{"m"c, 3},
{"p"c, 3},
    {"f"c, 4},
{"h"c, 4},
{"v"c, 4},
{"w"c, 4},
{"y"c, 4},
    {"k"c, 5},
    {"j"c, 8},
{"x"c, 8},
    {"q"c, 10},
{"z"c, 10}
}

    Public Function Score(ByVal input As String) As Integer
        If String.IsNullOrWhiteSpace(input) Then Return 0

        Return input.ToLower().Sum(Function(x) LetterScores(x))
    End Function
End Module
