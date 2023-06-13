Imports System
Imports System.Linq

Public Module Diamond
    Public Function Make(ByVal target As Char) As String
        Dim letters = GetLetters(target)
        Dim diamondLetters = letters.Concat(letters.Reverse().Skip(1)).ToArray()

        Return String.Join(vbLf, diamondLetters.[Select](Function(diamondLetter) MakeLine(letters.Length, diamondLetter)))
    End Function

    Private Function GetLetters(ByVal target As Char) As Tuple(Of Char, Integer)()
        Return Enumerable.Range(Asc("A"), Asc(target) - Asc("A") + 1).[Select](Function(c, i) Tuple.Create(Microsoft.VisualBasic.ChrW(c), i)).ToArray()
    End Function

    Private Function MakeLine(ByVal letterCount As Integer, ByVal rowLetter As Tuple(Of Char, Integer)) As String
        Dim letter = rowLetter.Item1
        Dim row = rowLetter.Item2
        Dim outerSpaces = "".PadRight(letterCount - row - 1)
        Dim innerSpaces = "".PadRight(If(row = 0, 0, row * 2 - 1))

        Return If(letter = "A"c, $"{outerSpaces}{letter}{outerSpaces}", $"{outerSpaces}{letter}{innerSpaces}{letter}{outerSpaces}")
    End Function
End Module
