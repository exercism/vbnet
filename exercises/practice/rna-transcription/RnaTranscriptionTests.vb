Public Class RnaTranscriptionTests
    <Fact>
    Public Sub Empty_rna_sequence()
        Assert.Equal("", RnaTranscription.ToRna(""))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rna_complement_of_cytosine_is_guanine()
        Assert.Equal("G", RnaTranscription.ToRna("C"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rna_complement_of_guanine_is_cytosine()
        Assert.Equal("C", RnaTranscription.ToRna("G"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rna_complement_of_thymine_is_adenine()
        Assert.Equal("A", RnaTranscription.ToRna("T"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rna_complement_of_adenine_is_uracil()
        Assert.Equal("U", RnaTranscription.ToRna("A"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rna_complement()
        Assert.Equal("UGCACCAGAAUU", RnaTranscription.ToRna("ACGTGGTCTTAA"))
    End Sub
End Class
