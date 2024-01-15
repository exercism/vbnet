Imports System.Collections.Generic
Imports System.Linq
Imports Xunit

Public Class ParallelLetterFrequencyTests
    ' Poem by Friedrich Schiller. The corresponding music is the European Anthem.
    Private Const OdeAnDieFreude As String = "Freude schöner Götterfunken" & vbLf & "Tochter aus Elysium," & vbLf & "Wir betreten feuertrunken," & vbLf & "Himmlische, dein Heiligtum!" & vbLf & "Deine Zauber binden wieder" & vbLf & "Was die Mode streng geteilt;" & vbLf & "Alle Menschen werden Brüder," & vbLf & "Wo dein sanfter Flügel weilt."

    ' Dutch national anthem
    Private Const Wilhelmus As String = "Wilhelmus van Nassouwe" & vbLf & "ben ik, van Duitsen bloed," & vbLf & "den vaderland getrouwe" & vbLf & "blijf ik tot in den dood." & vbLf & "Een Prinse van Oranje" & vbLf & "ben ik, vrij, onverveerd," & vbLf & "den Koning van Hispanje" & vbLf & "heb ik altijd geëerd."

    ' American national anthem
    Private Const StarSpangledBanner As String = "O say can you see by the dawn's early light," & vbLf & "What so proudly we hailed at the twilight's last gleaming," & vbLf & "Whose broad stripes and bright stars through the perilous fight," & vbLf & "O'er the ramparts we watched, were so gallantly streaming?" & vbLf & "And the rockets' red glare, the bombs bursting in air," & vbLf & "Gave proof through the night that our flag was still there;" & vbLf & "O say does that star-spangled banner yet wave," & vbLf & "O'er the land of the free and the home of the brave?" & vbLf

    <Fact>
    Public Sub No_texts_mean_no_letters()
        Dim input = Enumerable.Empty(Of String)()
        Dim actual = Calculate(input)
        Dim expected = New Dictionary(Of Char, Integer)()
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_letter()
        Dim input = {"a"}
        Dim actual = Calculate(input)
        Dim expected = New Dictionary(Of Char, Integer) From {
    {"a"c, 1}
}
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Case_insensitivity()
        Dim input = {"aA"}
        Dim actual = Calculate(input)
        Dim expected = New Dictionary(Of Char, Integer) From {
    {"a"c, 2}
}
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Many_empty_texts_still_mean_no_letters()
        Dim input = Enumerable.Repeat("  ", 10000)
        Dim actual = Calculate(input)
        Dim expected = New Dictionary(Of Char, Integer)()
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Many_times_the_same_text_gives_a_predictable_result()
        Dim input = Enumerable.Repeat("abc", 1000)
        Dim actual = Calculate(input)
        Dim expected = New Dictionary(Of Char, Integer) From {
    {"a"c, 1000},
    {"b"c, 1000},
    {"c"c, 1000}
}
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Punctuation_doesnt_count()
        Dim input = {OdeAnDieFreude}
        Dim actual = Calculate(input)
        Assert.False(actual.ContainsKey(","c))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Numbers_dont_count()
        Dim input = {"Testing, 1, 2, 3"}
        Dim actual = Calculate(input)
        Assert.False(actual.ContainsKey("1"c))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub All_three_anthems_together()
        Dim input = {OdeAnDieFreude, Wilhelmus, StarSpangledBanner}
        Dim actual = Calculate(input)
        Assert.Equal(49, actual("a"c))
        Assert.Equal(56, actual("t"c))
        Assert.Equal(2, actual("ü"c))
    End Sub
End Class
