Imports System.Collections.Generic
Imports System.Linq
Imports System.Text.RegularExpressions

Public Module Acronym
    Public Function Abbreviate(ByVal phrase As String) As String
        Return Words(phrase).Aggregate("", Function(abbr, word) abbr & Char.ToUpperInvariant(word(0)).ToString())
    End Function

    Private Function Words(ByVal phrase As String) As IEnumerable(Of String)
        Return Regex.Matches(phrase, "[A-Z]+[a-z']*|[a-z']+").Cast(Of Match)().[Select](Function(m) m.Value)
    End Function
End Module
