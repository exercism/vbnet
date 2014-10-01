Public Class Anagram
    Private baseWord As String

    Public Sub New(baseWord As String)
        Me.baseWord = baseWord
    End Sub

    Public Function Match(potentialMatches As String()) As String()
        Dim matches As New List(Of String)()

        For Each word As String In potentialMatches
            If IsWordAnagramOfBaseWord(word) Then
                matches.Add(word)
            End If
        Next

        Return matches.OrderBy(Function(word) word).ToArray()
    End Function

    Private Function IsWordAnagramOfBaseWord(word As String) As Boolean
        Return (IsNotTheSameWordAsBaseWord(word) AndAlso HasSameLettersAsBaseWord(word))
    End Function

    Private Function IsNotTheSameWordAsBaseWord(word As String) As Boolean
        Return Not baseWord.Equals(word, StringComparison.OrdinalIgnoreCase)
    End Function

    Private Function HasSameLettersAsBaseWord(word As String) As Boolean
        Return SortedCharArrayForString(baseWord).Equals(SortedCharArrayForString(word))
    End Function

    Private Function SortedCharArrayForString(word As String) As String
        Return String.Concat(word.ToLower().OrderBy(Function(letter) letter))
    End Function
End Class
