Imports Xunit

Public Class RnaTranscriptionTests
    <Fact>
    Public Sub Empty_rna_sequence()
        Assert.Equal("", ToRna(""))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rna_complement_of_cytosine_is_guanine()
        Assert.Equal("G", ToRna("C"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rna_complement_of_guanine_is_cytosine()
        Assert.Equal("C", ToRna("G"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rna_complement_of_thymine_is_adenine()
        Assert.Equal("A", ToRna("T"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rna_complement_of_adenine_is_uracil()
        Assert.Equal("U", ToRna("A"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rna_complement()
        Assert.Equal("UGCACCAGAAUU", ToRna("ACGTGGTCTTAA"))
    End Sub
End Class
