Imports System
Imports System.Collections.Generic

Public Module ProteinTranslation
    Public Function Proteins(ByVal strand As String) As String()
        Dim results = New List(Of String)()

        For i As Integer = 0 To strand.Length / 3 - 1
            Dim protein = ConvertToProtein(strand.Substring(3 * i, 3))

            If Equals(protein, "STOP") Then
                Exit For
            End If

            results.Add(protein)
        Next

        Return results.ToArray()
    End Function

    Private Function ConvertToProtein(ByVal input As String) As String
        Select Case input
            Case "AUG"
                Return "Methionine"
            Case "UUU", "UUC"
                Return "Phenylalanine"
            Case "UUA", "UUG"
                Return "Leucine"
            Case "UCU", "UCC", "UCA", "UCG"
                Return "Serine"
            Case "UAU", "UAC"
                Return "Tyrosine"
            Case "UGU", "UGC"
                Return "Cysteine"
            Case "UGG"
                Return "Tryptophan"
            Case "UAA", "UAG", "UGA"
                Return "STOP"
            Case Else
                Throw New Exception("Invalid sequence")
        End Select
    End Function
End Module
