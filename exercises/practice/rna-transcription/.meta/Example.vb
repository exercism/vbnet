Imports System
Imports System.Collections.Generic
Imports System.Linq

Public Module RnaTranscription
    Private ReadOnly DnaToRna As Dictionary(Of Char, Char) = New Dictionary(Of Char, Char) From {
    {"G"c, "C"c},
{"C"c, "G"c},
{"T"c, "A"c},
{"A"c, "U"c}
}

    Public Function ToRna(ByVal nucleotide As String) As String
        If nucleotide.Any(Function(x) Not DnaToRna.ContainsKey(x)) Then
            Throw New ArgumentException("invalid nucleotide")
        End If

        Return String.Concat(nucleotide.[Select](Function(x) DnaToRna(x)))
    End Function
End Module
