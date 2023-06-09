Imports System.Collections.Generic

Public Module Isogram
    Public Function IsIsogram(ByVal word As String) As Boolean
        Dim letters = New HashSet(Of Char)()

        For Each c In word.ToLowerInvariant()
            If Char.IsLetter(c) AndAlso Not letters.Add(c) Then
                Return False
            End If
        Next

        Return True
    End Function
End Module
