Imports System
Imports System.Collections.Generic

Public Module NucleotideCount
    Public Function Count(ByVal sequence As String) As IDictionary(Of Char, Integer)
        Dim nucleotideCounts = New Dictionary(Of Char, Integer) From {
            {"A"c, 0},
            {"T"c, 0},
            {"C"c, 0},
            {"G"c, 0}
        }
        Dim lCount As Integer = Nothing

        For Each s In sequence

            If nucleotideCounts.TryGetValue(s, lCount) Then
                nucleotideCounts(s) = lCount + 1
            Else
                Throw New ArgumentException()
            End If
        Next

        Return nucleotideCounts
    End Function
End Module
