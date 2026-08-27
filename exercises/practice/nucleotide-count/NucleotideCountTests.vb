Public Class NucleotideCountTests
    <Fact>
    Public Sub Empty_strand()
        Dim strand = ""
        Dim expected = New Dictionary(Of Char, Integer) From {
            {"A"c, 0},
            {"C"c, 0},
            {"G"c, 0},
            {"T"c, 0}
        }
        Assert.Equal(expected, NucleotideCount.Count(strand))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_count_one_nucleotide_in_single_character_input()
        Dim strand = "G"
        Dim expected = New Dictionary(Of Char, Integer) From {
            {"A"c, 0},
            {"C"c, 0},
            {"G"c, 1},
            {"T"c, 0}
        }
        Assert.Equal(expected, NucleotideCount.Count(strand))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Strand_with_repeated_nucleotide()
        Dim strand = "GGGGGGG"
        Dim expected = New Dictionary(Of Char, Integer) From {
            {"A"c, 0},
            {"C"c, 0},
            {"G"c, 7},
            {"T"c, 0}
        }
        Assert.Equal(expected, NucleotideCount.Count(strand))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Strand_with_multiple_nucleotides()
        Dim strand = "AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC"
        Dim expected = New Dictionary(Of Char, Integer) From {
            {"A"c, 20},
            {"C"c, 12},
            {"G"c, 17},
            {"T"c, 21}
        }
        Assert.Equal(expected, NucleotideCount.Count(strand))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Strand_with_invalid_nucleotides()
        Dim strand = "AGXXACT"
        Assert.Throws(Of ArgumentException)(Function() NucleotideCount.Count(strand))
    End Sub
End Class
