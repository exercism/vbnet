Imports System.Collections.Generic

Public Class Pangram
    Public Shared Function IsPangram(ByVal input As String) As Boolean
        Dim chars = New HashSet(Of Char)()

        For Each c In input.ToLowerInvariant()
            If c >= "a"c AndAlso c <= "z"c Then
                chars.Add(c)
            End If
        Next

        Return chars.Count = 26
    End Function
End Class
