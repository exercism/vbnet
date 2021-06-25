Imports System.Linq

Public Class Bob
    Private Function IsShouted(s As String) As Boolean
        Return s.Any(AddressOf Char.IsUpper) AndAlso Not s.Any(AddressOf Char.IsLower)
    End Function

    Private Function IsQuestion(s As String) As Boolean
        Return s.TrimEnd().EndsWith("?")
    End Function

    Private Function IsSilence(s As String) As Boolean
        Return String.IsNullOrWhiteSpace(s)
    End Function

    Public Function Hey(statement As String) As String
        If IsShouted(statement) AndAlso IsQuestion(statement) Then
            Return "Calm down, I know what I'm doing!"
        End If
        If IsShouted(statement) Then
            Return "Whoa, chill out!"
        End If
        If IsQuestion(statement) Then
            Return "Sure."
        End If
        If IsSilence(statement) Then
            Return "Fine. Be that way!"
        End If
        Return "Whatever."
    End Function
End Class