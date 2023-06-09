Imports Xunit

Public Class ProteinTranslationTests
    <Fact>
    Public Sub Empty_rna_sequence_results_in_no_proteins()
        Assert.Empty(Proteins(""))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Methionine_rna_sequence()
        Assert.Equal({"Methionine"}, Proteins("AUG"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Phenylalanine_rna_sequence_1()
        Assert.Equal({"Phenylalanine"}, Proteins("UUU"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Phenylalanine_rna_sequence_2()
        Assert.Equal({"Phenylalanine"}, Proteins("UUC"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Leucine_rna_sequence_1()
        Assert.Equal({"Leucine"}, Proteins("UUA"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Leucine_rna_sequence_2()
        Assert.Equal({"Leucine"}, Proteins("UUG"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Serine_rna_sequence_1()
        Assert.Equal({"Serine"}, Proteins("UCU"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Serine_rna_sequence_2()
        Assert.Equal({"Serine"}, Proteins("UCC"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Serine_rna_sequence_3()
        Assert.Equal({"Serine"}, Proteins("UCA"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Serine_rna_sequence_4()
        Assert.Equal({"Serine"}, Proteins("UCG"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Tyrosine_rna_sequence_1()
        Assert.Equal({"Tyrosine"}, Proteins("UAU"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Tyrosine_rna_sequence_2()
        Assert.Equal({"Tyrosine"}, Proteins("UAC"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cysteine_rna_sequence_1()
        Assert.Equal({"Cysteine"}, Proteins("UGU"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cysteine_rna_sequence_2()
        Assert.Equal({"Cysteine"}, Proteins("UGC"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Tryptophan_rna_sequence()
        Assert.Equal({"Tryptophan"}, Proteins("UGG"))
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
        Assert.Equal({"Phenylalanine", "Phenylalanine"}, Proteins("UUUUUU"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sequence_of_two_different_protein_codons_translates_into_proteins()
        Assert.Equal({"Leucine", "Leucine"}, Proteins("UUAUUG"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Translate_rna_strand_into_correct_protein_list()
        Assert.Equal({"Methionine", "Phenylalanine", "Tryptophan"}, Proteins("AUGUUUUGG"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Translation_stops_if_stop_codon_at_beginning_of_sequence()
        Assert.Empty(Proteins("UAGUGG"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Translation_stops_if_stop_codon_at_end_of_two_codon_sequence()
        Assert.Equal({"Tryptophan"}, Proteins("UGGUAG"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Translation_stops_if_stop_codon_at_end_of_three_codon_sequence()
        Assert.Equal({"Methionine", "Phenylalanine"}, Proteins("AUGUUUUAA"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Translation_stops_if_stop_codon_in_middle_of_three_codon_sequence()
        Assert.Equal({"Tryptophan"}, Proteins("UGGUAGUGG"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Translation_stops_if_stop_codon_in_middle_of_six_codon_sequence()
        Assert.Equal({"Tryptophan", "Cysteine", "Tyrosine"}, Proteins("UGGUGUUAUUAAUGGUUU"))
    End Sub
End Class
