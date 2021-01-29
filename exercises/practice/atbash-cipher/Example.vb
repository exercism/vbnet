Public Class Atbash
    Private Const PLAIN As String = "abcdefghijklmnopqrstuvwxyz"
    Private Const CIPHER As String = "zyxwvutsrqponmlkjihgfedcba"

    Public Shared Function Encode(value As String) As String
        Dim encoded = String.Concat(StripInvalidCharacters(value).ToLower().Select(AddressOf ApplyCipher))
        Return SplitIntoFiveLetterWords(encoded)
    End Function

    Private Shared Function StripInvalidCharacters(value As String) As String
        Return String.Concat(value.Where(AddressOf Char.IsLetterOrDigit))
    End Function

    Private Shared Function ApplyCipher(value As Char) As Char
        Dim idx = PLAIN.IndexOf(value)
        Return If(idx >= 0, CIPHER(idx), value)
    End Function

    Private Shared Function SplitIntoFiveLetterWords(value As String) As String
        Dim words = New List(Of String)()

        For i As Integer = 0 To value.Length - 1 Step 5
            words.Add(If(i + 5 <= value.Length, value.Substring(i, 5), value.Substring(i)))
        Next

        Return String.Join(" ", words)
    End Function
End Class
