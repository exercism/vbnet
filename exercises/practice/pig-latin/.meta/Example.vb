Imports System.Linq
Imports System.Text.RegularExpressions

Public Class PigLatin
    Public Shared Function Translate(ByVal word As String) As String
        Return String.Join(" ", word.Split(" "c).Select(Function(x) PigLatin.TranslateWord(x)))
    End Function

    Private Shared Function TranslateWord(ByVal word As String) As String
        If PigLatin.WordStartsWithVowelLike(word) Then Return word & "ay"
        If PigLatin.WordStartsWithPrefixes(word, "thr", "sch") Then Return word.Substring(3) & word.Substring(0, 3) & "ay"
        If PigLatin.WordStartsWithPrefixes(word, "ch", "qu", "th", "rh") Then Return word.Substring(2) & word.Substring(0, 2) & "ay"
        If PigLatin.WordStartsWithConsonantAndQu(word) Then Return word.Substring(3) & word(0).ToString() & "quay"

        Return word.Substring(1) & word(0).ToString() & "ay"
    End Function

    Private Shared Function WordStartsWithVowelLike(ByVal word As String) As Boolean
        Return Regex.IsMatch("[aeiou]", word(0).ToString()) OrElse word.StartsWith("yt") OrElse word.StartsWith("xr")
    End Function

    Private Shared Function WordStartsWithPrefixes(ByVal word As String, ParamArray prefixes As String()) As Boolean
        Return prefixes.Any(New Func(Of String, Boolean)(AddressOf word.StartsWith))
    End Function

    Private Shared Function WordStartsWithConsonantAndQu(ByVal word As String) As Boolean
        Return word.Substring(1).StartsWith("qu")
    End Function
End Class
