Imports System
Imports System.Collections.Generic
Imports System.Linq

Public Module ScaleGenerator
    Private ReadOnly ChromaticScale As String() = {"C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"}
    Private ReadOnly FlatChromaticScale As String() = {"C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab", "A", "Bb", "B"}
    Private ReadOnly FlatKeys As String() = {"F", "Bb", "Eb", "Ab", "Db", "Gb", "d", "g", "c", "f", "bb", "eb"}
    Private ReadOnly Intervals As New Dictionary(Of Char, Integer) From {{"m"c, 1}, {"M"c, 2}, {"A"c, 3}}

    Private Function Scale(ByVal tonic As String) As String()
        Return If(FlatKeys.Contains(tonic), FlatChromaticScale, ChromaticScale)
    End Function
    Private Function SkipInterval(ByVal interval As Char, ByVal scale As String()) As String()
        Return scale.Skip(ScaleGenerator.Intervals(interval)).ToArray()
    End Function
    Private Function Shift(ByVal index As Integer, ByVal scale As String()) As String()
        Return scale.Skip(index).Concat(scale.Take(index)).ToArray()
    End Function

    Public Function Chromatic(ByVal tonic As String) As String()
        Return Interval(tonic, "mmmmmmmmmmmm").SkipLast(1).ToArray()
    End Function

    Public Function Interval(ByVal tonic As String, ByVal pattern As String) As String()
        Dim scale = ScaleGenerator.Scale(tonic)
        Dim index = Array.FindIndex(scale, Function(pitch) String.Equals(pitch, tonic, StringComparison.OrdinalIgnoreCase))
        Dim shiftedScale = Shift(index, scale)
        Dim shiftedScaleTonic = shiftedScale(0)

        Dim pitches = New List(Of String)()

        For Each lInterval In pattern
            pitches.Add(shiftedScale(0))
            shiftedScale = SkipInterval(lInterval, shiftedScale)
        Next

        pitches.Add(shiftedScaleTonic)

        Return pitches.ToArray()
    End Function
End Module
