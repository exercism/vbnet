Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text.RegularExpressions

Public Module RunLengthEncoding
    Public Function Encode(ByVal input As String) As String
        Return String.Join("", GroupConsecutive(input).[Select](New Func(Of Tuple(Of Char, Integer), String)(AddressOf EncodeConsecutive)))
    End Function

    Private Function EncodeConsecutive(ByVal group As Tuple(Of Char, Integer)) As String
        Return If(group.Item2 > 1, $"{group.Item2}{group.Item1}", group.Item1.ToString())
    End Function

    Private Iterator Function GroupConsecutive(ByVal input As String) As IEnumerable(Of Tuple(Of Char, Integer))
        If input.Length = 0 Then
            Return
        End If

        Dim current = input(0)
        Dim count = 0

        For Each character In input
            If character = current Then
                count += 1
            Else
                Yield Tuple.Create(current, count)
                current = character
                count = 1
            End If
        Next

        Yield Tuple.Create(current, count)
    End Function

    Public Function Decode(ByVal input As String) As String
        Return String.Join("", Regex.Matches(input, "(\d+[^\d]|[^\d])").Cast(Of Match)().[Select](New Func(Of Match, String)(AddressOf Decode)))
    End Function

    Private Function Decode(ByVal match As Match) As String
        If EncodedSingleCharacter(match) Then
            Return match.Value
        End If

        Return DecodeConsecutiveCharacters(match)
    End Function

    Private Function EncodedSingleCharacter(ByVal match As Match) As Boolean
        Return match.Value.Length = 1
    End Function

    Private Function DecodeConsecutiveCharacters(ByVal match As Match) As String
        Dim character = match.Value(match.Value.Length - 1)
        Dim count = Integer.Parse(match.Value.Substring(0, match.Value.Length - 1))
        Return New String(character, count)
    End Function
End Module
