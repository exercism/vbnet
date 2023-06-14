Imports Xunit

Public Class ScaleGeneratorTests
    <Fact>
    Public Sub Chromatic_scale_with_sharps()
        Dim expected = {"C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"}
        Assert.Equal(expected, Chromatic("C"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Chromatic_scale_with_flats()
        Dim expected = {"F", "Gb", "G", "Ab", "A", "Bb", "B", "C", "Db", "D", "Eb", "E"}
        Assert.Equal(expected, Chromatic("F"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Simple_major_scale()
        Dim expected = {"C", "D", "E", "F", "G", "A", "B", "C"}
        Assert.Equal(expected, Interval("C", "MMmMMMm"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Major_scale_with_sharps()
        Dim expected = {"G", "A", "B", "C", "D", "E", "F#", "G"}
        Assert.Equal(expected, Interval("G", "MMmMMMm"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Major_scale_with_flats()
        Dim expected = {"F", "G", "A", "Bb", "C", "D", "E", "F"}
        Assert.Equal(expected, Interval("F", "MMmMMMm"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Minor_scale_with_sharps()
        Dim expected = {"F#", "G#", "A", "B", "C#", "D", "E", "F#"}
        Assert.Equal(expected, Interval("f#", "MmMMmMM"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Minor_scale_with_flats()
        Dim expected = {"Bb", "C", "Db", "Eb", "F", "Gb", "Ab", "Bb"}
        Assert.Equal(expected, Interval("bb", "MmMMmMM"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Dorian_mode()
        Dim expected = {"D", "E", "F", "G", "A", "B", "C", "D"}
        Assert.Equal(expected, Interval("d", "MmMMMmM"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Mixolydian_mode()
        Dim expected = {"Eb", "F", "G", "Ab", "Bb", "C", "Db", "Eb"}
        Assert.Equal(expected, Interval("Eb", "MMmMMmM"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Lydian_mode()
        Dim expected = {"A", "B", "C#", "D#", "E", "F#", "G#", "A"}
        Assert.Equal(expected, Interval("a", "MMMmMMm"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Phrygian_mode()
        Dim expected = {"E", "F", "G", "A", "B", "C", "D", "E"}
        Assert.Equal(expected, Interval("e", "mMMMmMM"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Locrian_mode()
        Dim expected = {"G", "Ab", "Bb", "C", "Db", "Eb", "F", "G"}
        Assert.Equal(expected, Interval("g", "mMMmMMM"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Harmonic_minor()
        Dim expected = {"D", "E", "F", "G", "A", "Bb", "Db", "D"}
        Assert.Equal(expected, Interval("d", "MmMMmAm"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Octatonic()
        Dim expected = {"C", "D", "D#", "F", "F#", "G#", "A", "B", "C"}
        Assert.Equal(expected, Interval("C", "MmMmMmMm"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Hexatonic()
        Dim expected = {"Db", "Eb", "F", "G", "A", "B", "Db"}
        Assert.Equal(expected, Interval("Db", "MMMMMM"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Pentatonic()
        Dim expected = {"A", "B", "C#", "E", "F#", "A"}
        Assert.Equal(expected, Interval("A", "MMAMA"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Enigmatic()
        Dim expected = {"G", "G#", "B", "C#", "D#", "F", "F#", "G"}
        Assert.Equal(expected, Interval("G", "mAMMMmm"))
    End Sub
End Class
