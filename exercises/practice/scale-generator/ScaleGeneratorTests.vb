Imports Xunit

Public Class ScaleGeneratorTests
    <Fact>
    Public Sub Chromatic_scale_with_sharps()
        Dim expected = {"C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"}
        Dim result As IEnumerable(Of String) = Chromatic("C")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Chromatic_scale_with_flats()
        Dim expected = {"F", "Gb", "G", "Ab", "A", "Bb", "B", "C", "Db", "D", "Eb", "E"}
        Dim result As IEnumerable(Of String) = Chromatic("F")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Simple_major_scale()
        Dim expected = {"C", "D", "E", "F", "G", "A", "B", "C"}
        Dim result As IEnumerable(Of String) = Interval("C", "MMmMMMm")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Major_scale_with_sharps()
        Dim expected = {"G", "A", "B", "C", "D", "E", "F#", "G"}
        Dim result As IEnumerable(Of String) = Interval("G", "MMmMMMm")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Major_scale_with_flats()
        Dim expected = {"F", "G", "A", "Bb", "C", "D", "E", "F"}
        Dim result As IEnumerable(Of String) = Interval("F", "MMmMMMm")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Minor_scale_with_sharps()
        Dim expected = {"F#", "G#", "A", "B", "C#", "D", "E", "F#"}
        Dim result As IEnumerable(Of String) = Interval("f#", "MmMMmMM")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Minor_scale_with_flats()
        Dim expected = {"Bb", "C", "Db", "Eb", "F", "Gb", "Ab", "Bb"}
        Dim result As IEnumerable(Of String) = Interval("bb", "MmMMmMM")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Dorian_mode()
        Dim expected = {"D", "E", "F", "G", "A", "B", "C", "D"}
        Dim result As IEnumerable(Of String) = Interval("d", "MmMMMmM")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Mixolydian_mode()
        Dim expected = {"Eb", "F", "G", "Ab", "Bb", "C", "Db", "Eb"}
        Dim result As IEnumerable(Of String) = Interval("Eb", "MMmMMmM")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Lydian_mode()
        Dim expected = {"A", "B", "C#", "D#", "E", "F#", "G#", "A"}
        Dim result As IEnumerable(Of String) = Interval("A", "MMMmMMm")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Phrygian_mode()
        Dim expected = {"E", "F", "G", "A", "B", "C", "D", "E"}
        Dim result As IEnumerable(Of String) = Interval("e", "mMMMmMM")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Locrian_mode()
        Dim expected = {"G", "Ab", "Bb", "C", "Db", "Eb", "F", "G"}
        Dim result As IEnumerable(Of String) = Interval("g", "mMMmMMM")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Harmonic_minor()
        Dim expected = {"D", "E", "F", "G", "A", "Bb", "Db", "D"}
        Dim result As IEnumerable(Of String) = Interval("d", "MmMMmAm")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Octatonic()
        Dim expected = {"C", "D", "D#", "F", "F#", "G#", "A", "B", "C"}
        Dim result As IEnumerable(Of String) = Interval("C", "MmMmMmMm")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Hexatonic()
        Dim expected = {"Db", "Eb", "F", "G", "A", "B", "Db"}
        Dim result As IEnumerable(Of String) = Interval("Db", "MMMMMM")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Pentatonic()
        Dim expected = {"A", "B", "C#", "E", "F#", "A"}
        Dim result As IEnumerable(Of String) = Interval("A", "MMAMA")
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Enigmatic()
        Dim expected = {"G", "G#", "B", "C#", "D#", "F", "F#", "G"}
        Dim result As IEnumerable(Of String) = Interval("G", "mAMMMmm")
        Assert.Equal(expected, result)
    End Sub
End Class
