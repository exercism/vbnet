Imports System
Imports System.Collections.Generic
Imports System.Linq

Public Module OcrNumbers
    Private Const CharacterWidth As Integer = 3
    Private Const CharacterHeight As Integer = 4

    Public Function Convert(ByVal input As String) As String
        Dim lines = input.Split(ChrW(10))

        If lines.Length > CharacterHeight Then lines = GetTransformedInput(lines)

        Return Positions(lines).Aggregate("", Function(str, pos) str & ConvertCharacter(lines, pos.Item1, pos.Item2).ToString())
    End Function

    ''' <summary>
    ''' Transform multilines input into one line digits separate by comma
    ''' </summary>
    ''' <paramname="lines"></param>
    ''' <returns></returns>
    Private Function GetTransformedInput(ByVal lines As String()) As String()
        Dim transformedLines = New String(3) {}

        Dim x = 0, characterRow = 0

        While x < lines.Length
            If characterRow > 3 Then characterRow = 0

            For y = 0 To lines(x).Length - 1
                transformedLines(characterRow) += lines(x)(y)
            Next

            'for empty & last line add comma
            If String.IsNullOrWhiteSpace(lines(x)) AndAlso lines.Length - 1 <> x Then
                For i = 0 To CharacterHeight - 1
                    transformedLines(i) += If(i = CharacterWidth - 1, "  ,", "   ")
                Next
            End If

            x += 1
            characterRow += 1
        End While

        Return transformedLines
    End Function

    Private Function Positions(ByVal lines As String()) As IEnumerable(Of Tuple(Of Integer, Integer))
        Return From x In Enumerable.Range(0, Rows(lines)) From y In Enumerable.Range(0, Cols(lines)) Select Tuple.Create(x, y)
    End Function

    Private Function Cols(ByVal lines As String()) As Integer
        Return If(lines(0).Length Mod CharacterWidth = 0, lines(0).Length / CharacterWidth, CSharpImpl.__Throw(Of Integer)(New ArgumentException()))
    End Function

    Private Function Rows(ByVal lines As String()) As Integer
        Return If(lines.Length Mod CharacterHeight = 0, lines.Length / CharacterHeight, CSharpImpl.__Throw(Of Integer)(New ArgumentException()))
    End Function

    Private Function IsEmptyLine(ByVal line As String) As Boolean
        Return String.IsNullOrWhiteSpace(line)
    End Function

    Private Function ConvertCharacter(ByVal input As String(), ByVal row As Integer, ByVal col As Integer) As Char
        Return MatchCharacter(Character(input, row, col))
    End Function

    Private Function Character(ByVal input As String(), ByVal row As Integer, ByVal col As Integer) As String
        Return Enumerable.Range(row, CharacterHeight).Aggregate("", Function(str, offset) str & input(row * CharacterHeight + offset).Substring(col * CharacterWidth, CharacterWidth))
    End Function

    Private Function MatchCharacter(ByVal character As String) As Char
        Return If(CharactersMap.ContainsKey(character), CharactersMap(character), "?"c)
    End Function

    Private ReadOnly CharactersMap As IReadOnlyDictionary(Of String, Char) = New Dictionary(Of String, Char) From {
                                                                        {" _ " & "| |" & "|_|" & "   ", "0"c},
                                                                        {"   " & "  |" & "  |" & "   ", "1"c},
                                                                        {" _ " & " _|" & "|_ " & "   ", "2"c},
                                                                        {" _ " & " _|" & " _|" & "   ", "3"c},
                                                                        {"   " & "|_|" & "  |" & "   ", "4"c},
                                                                        {" _ " & "|_ " & " _|" & "   ", "5"c},
                                                                        {" _ " & "|_ " & "|_|" & "   ", "6"c},
                                                                        {" _ " & "  |" & "  |" & "   ", "7"c},
                                                                        {" _ " & "|_|" & "|_|" & "   ", "8"c},
                                                                        {" _ " & "|_|" & " _|" & "   ", "9"c},
                                                                        {"   " & "   " & "  ," & "   ", ","c}
}

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal throw statements")>
        Shared Function __Throw(Of T)(ByVal e As Exception) As T
            Throw e
        End Function
    End Class
End Module
