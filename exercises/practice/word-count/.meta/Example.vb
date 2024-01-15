Imports System
Imports System.Text.RegularExpressions
Imports System.Collections.Generic

Public Module WordCount
    Public Function CountWords(ByVal phrase As String) As IDictionary(Of String, Integer)
        If Equals(phrase, Nothing) Then Throw New ArgumentNullException("phrase")

        Dim counts = New Dictionary(Of String, Integer)()
        Dim match As Match = Regex.Match(phrase.ToLower(), "\w+'\w+|\w+")
        While match.Success
            Dim word = match.Value
            If Not counts.ContainsKey(word) Then
                counts(word) = 0
            End If
            counts(word) += 1
            match = match.NextMatch()
        End While
        Return counts
    End Function
End Module
