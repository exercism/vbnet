Imports Xunit

Public Class ProteinTranslationTests
    <Fact>
    Public Sub Empty_rna_sequence_results_in_no_proteins()
        Assert.Empty(Proteins(""))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Methionine_rna_sequence()
        Dim strand = "AUG"
        Dim expected = {"Methionine"}
        Dim result as IEnumerable(Of String) = Proteins(strand)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Phenylalanine_rna_sequence_1()
        Dim strand = "UUU"
        Dim expected = {"Phenylalanine"}
        Dim result as IEnumerable(Of String) = Proteins(strand)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Phenylalanine_rna_sequence_2()
        Dim strand = "UUC"
        Dim expected = {"Phenylalanine"}
        Dim result as IEnumerable(Of String) = Proteins(strand)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Leucine_rna_sequence_1()
        Dim strand = "UUA"
        Dim expected = {"Leucine"}
        Dim result as IEnumerable(Of String) = Proteins(strand)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Leucine_rna_sequence_2()
        Dim strand = "UUG"
        Dim expected = {"Leucine"}
        Dim result as IEnumerable(Of String) = Proteins(strand)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Serine_rna_sequence_1()
        Dim strand = "UCU"
        Dim expected = {"Serine"}
        Dim result as IEnumerable(Of String) = Proteins(strand)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Serine_rna_sequence_2()
        Dim strand = "UCC"
        Dim expected = {"Serine"}
        Dim result as IEnumerable(Of String) = Proteins(strand)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Serine_rna_sequence_3()
        Dim strand = "UCA"
        Dim expected = {"Serine"}
        Dim result as IEnumerable(Of String) = Proteins(strand)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Serine_rna_sequence_4()
        Dim strand = "UCG"
        Dim expected = {"Serine"}
        Dim result as IEnumerable(Of String) = Proteins(strand)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Tyrosine_rna_sequence_1()
        Dim strand = "UAU"
        Dim expected = {"Tyrosine"}
        Dim result as IEnumerable(Of String) = Proteins(strand)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Tyrosine_rna_sequence_2()
        Dim strand = "UAC"
        Dim expected = {"Tyrosine"}
        Dim result as IEnumerable(Of String) = Proteins(strand)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cysteine_rna_sequence_1()
        Dim strand = "UGU"
        Dim expected = {"Cysteine"}
        Dim result as IEnumerable(Of String) = Proteins(strand)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cysteine_rna_sequence_2()
        Dim strand = "UGC"
        Dim expected = {"Cysteine"}
        Dim result as IEnumerable(Of String) = Proteins(strand)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Tryptophan_rna_sequence()
        Dim strand = "UGG"
        Dim expected = {"Tryptophan"}
        Dim result as IEnumerable(Of String) = Proteins(strand)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Stop_codon_rna_sequence_1()
        Assert.Empty(Proteins("UAA"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Stop_codon_rna_sequence_2()
        Assert.Empty(Proteins("UAG"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Stop_codon_rna_sequence_3()
        Assert.Empty(Proteins("UGA"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sequence_of_two_protein_codons_translates_into_proteins()
        Dim strand = "UUUUUU"
        Dim expected = {"Phenylalanine", "Phenylalanine"}
        Dim result as IEnumerable(Of String) = Proteins(strand)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sequence_of_two_different_protein_codons_translates_into_proteins()
        Dim strand = "UUAUUG"
        Dim expected = {"Leucine", "Leucine"}
        Dim result as IEnumerable(Of String) = Proteins(strand)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Translate_rna_strand_into_correct_protein_list()
        Dim strand = "AUGUUUUGG"
        Dim expected = {"Methionine", "Phenylalanine", "Tryptophan"}
        Dim result as IEnumerable(Of String) = Proteins(strand)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Translation_stops_if_stop_codon_at_beginning_of_sequence()
        Assert.Empty(Proteins("UAGUGG"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Translation_stops_if_stop_codon_at_end_of_two_codon_sequence()
        Dim strand = "UGGUAG"
        Dim expected = {"Tryptophan"}
        Dim result as IEnumerable(Of String) = Proteins(strand)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Translation_stops_if_stop_codon_at_end_of_three_codon_sequence()
        Dim strand = "AUGUUUUAA"
        Dim expected = {"Methionine", "Phenylalanine"}
        Dim result as IEnumerable(Of String) = Proteins(strand)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Translation_stops_if_stop_codon_in_middle_of_three_codon_sequence()
        Dim strand = "UGGUAGUGG"
        Dim expected = {"Tryptophan"}
        Dim result as IEnumerable(Of String) = Proteins(strand)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Translation_stops_if_stop_codon_in_middle_of_six_codon_sequence()
        Dim strand = "UGGUGUUAUUAAUGGUUU"
        Dim expected = {"Tryptophan", "Cysteine", "Tyrosine"}
        Dim result as IEnumerable(Of String) = Proteins(strand)
        Assert.Equal(expected, result)
    End Sub
End Class
