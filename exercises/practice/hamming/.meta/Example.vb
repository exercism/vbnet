Imports System
Imports System.Linq

Public Module Hamming
    Public Function Distance(ByVal firstStrand As String, ByVal secondStrand As String) As Integer
        If firstStrand.Length <> secondStrand.Length Then
            Throw New ArgumentException(message:="Strands not the same length")
        End If
        dim strand2Enu = CType(secondStrand, IEnumerable(Of Char))
        Return Enumerable.Zip(Of Char, Char, Integer)(
            firstStrand, 
            strand2Enu, 
            CType(Function(nucleotide1, nucleotide2) CInt(If(nucleotide1 <> nucleotide2, 1, 0)), Func(Of Char, Char, Integer))).Sum()
    End Function
End Module
