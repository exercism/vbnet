Imports System.Text.RegularExpressions

Public Class PigLatin
    Private Shared ReadOnly Regexes As Regex() = {
        New Regex("^([^aeiou]*qu)(.+)"),
        New Regex("^([^aeiouy]+)(y.+)"),
        New Regex("^()(xr|yt|[aeiou].+)"),
        New Regex("^([^aeiou]+)(.+)")
    }

    Public Shared Function Translate(ByVal word As String) As String
        Return String.Join(" ", word.Split(" "c).Select(Function(x) PigLatin.TranslateWord(x)))
    End Function

    Private Shared Function TranslateWord(ByVal word As String) As String
        For Each regex As Regex In Regexes
            Dim match As Match = regex.Match(word)
            If Not match.Success Then Continue For
            If match.Groups(1).Value = "" Then Exit For
            Return match.Groups(2).Value & match.Groups(1).Value & "ay"
        Next

        Return word & "ay"
    End Function
End Class
