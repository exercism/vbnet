Public Class ProteinTranslationTests
    <Fact>
    Public Sub Empty_rna_sequence_results_in_no_proteins()
        Dim strand = ""
        Assert.Empty(ProteinTranslation.Proteins(strand))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Methionine_rna_sequence()
        Dim strand = "AUG"
        Dim expected = {"Methionine"}
        Assert.Equal(expected, ProteinTranslation.Proteins(strand))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Phenylalanine_rna_sequence_1()
        Dim strand = "UUU"
        Dim expected = {"Phenylalanine"}
        Assert.Equal(expected, ProteinTranslation.Proteins(strand))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Phenylalanine_rna_sequence_2()
        Dim strand = "UUC"
        Dim expected = {"Phenylalanine"}
        Assert.Equal(expected, ProteinTranslation.Proteins(strand))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Leucine_rna_sequence_1()
        Dim strand = "UUA"
        Dim expected = {"Leucine"}
        Assert.Equal(expected, ProteinTranslation.Proteins(strand))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Leucine_rna_sequence_2()
        Dim strand = "UUG"
        Dim expected = {"Leucine"}
        Assert.Equal(expected, ProteinTranslation.Proteins(strand))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Serine_rna_sequence_1()
        Dim strand = "UCU"
        Dim expected = {"Serine"}
        Assert.Equal(expected, ProteinTranslation.Proteins(strand))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Serine_rna_sequence_2()
        Dim strand = "UCC"
        Dim expected = {"Serine"}
        Assert.Equal(expected, ProteinTranslation.Proteins(strand))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Serine_rna_sequence_3()
        Dim strand = "UCA"
        Dim expected = {"Serine"}
        Assert.Equal(expected, ProteinTranslation.Proteins(strand))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Serine_rna_sequence_4()
        Dim strand = "UCG"
        Dim expected = {"Serine"}
        Assert.Equal(expected, ProteinTranslation.Proteins(strand))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Tyrosine_rna_sequence_1()
        Dim strand = "UAU"
        Dim expected = {"Tyrosine"}
        Assert.Equal(expected, ProteinTranslation.Proteins(strand))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Tyrosine_rna_sequence_2()
        Dim strand = "UAC"
        Dim expected = {"Tyrosine"}
        Assert.Equal(expected, ProteinTranslation.Proteins(strand))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cysteine_rna_sequence_1()
        Dim strand = "UGU"
        Dim expected = {"Cysteine"}
        Assert.Equal(expected, ProteinTranslation.Proteins(strand))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cysteine_rna_sequence_2()
        Dim strand = "UGC"
        Dim expected = {"Cysteine"}
        Assert.Equal(expected, ProteinTranslation.Proteins(strand))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Tryptophan_rna_sequence()
        Dim strand = "UGG"
        Dim expected = {"Tryptophan"}
        Assert.Equal(expected, ProteinTranslation.Proteins(strand))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Stop_codon_rna_sequence_1()
        Dim strand = "UAA"
        Assert.Empty(ProteinTranslation.Proteins(strand))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Stop_codon_rna_sequence_2()
        Dim strand = "UAG"
        Assert.Empty(ProteinTranslation.Proteins(strand))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Stop_codon_rna_sequence_3()
        Dim strand = "UGA"
        Assert.Empty(ProteinTranslation.Proteins(strand))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sequence_of_two_protein_codons_translates_into_proteins()
        Dim strand = "UUUUUU"
        Dim expected = {"Phenylalanine", "Phenylalanine"}
        Assert.Equal(expected, ProteinTranslation.Proteins(strand))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sequence_of_two_different_protein_codons_translates_into_proteins()
        Dim strand = "UUAUUG"
        Dim expected = {"Leucine", "Leucine"}
        Assert.Equal(expected, ProteinTranslation.Proteins(strand))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Translate_rna_strand_into_correct_protein_list()
        Dim strand = "AUGUUUUGG"
        Dim expected = {"Methionine", "Phenylalanine", "Tryptophan"}
        Assert.Equal(expected, ProteinTranslation.Proteins(strand))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Translation_stops_if_stop_codon_at_beginning_of_sequence()
        Dim strand = "UAGUGG"
        Assert.Empty(ProteinTranslation.Proteins(strand))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Translation_stops_if_stop_codon_at_end_of_two_codon_sequence()
        Dim strand = "UGGUAG"
        Dim expected = {"Tryptophan"}
        Assert.Equal(expected, ProteinTranslation.Proteins(strand))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Translation_stops_if_stop_codon_at_end_of_three_codon_sequence()
        Dim strand = "AUGUUUUAA"
        Dim expected = {"Methionine", "Phenylalanine"}
        Assert.Equal(expected, ProteinTranslation.Proteins(strand))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Translation_stops_if_stop_codon_in_middle_of_three_codon_sequence()
        Dim strand = "UGGUAGUGG"
        Dim expected = {"Tryptophan"}
        Assert.Equal(expected, ProteinTranslation.Proteins(strand))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Translation_stops_if_stop_codon_in_middle_of_six_codon_sequence()
        Dim strand = "UGGUGUUAUUAAUGGUUU"
        Dim expected = {"Tryptophan", "Cysteine", "Tyrosine"}
        Assert.Equal(expected, ProteinTranslation.Proteins(strand))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sequence_of_two_non_stop_codons_does_not_translate_to_a_stop_codon()
        Dim strand = "AUGAUG"
        Dim expected = {"Methionine", "Methionine"}
        Assert.Equal(expected, ProteinTranslation.Proteins(strand))
    End Sub
End Class
