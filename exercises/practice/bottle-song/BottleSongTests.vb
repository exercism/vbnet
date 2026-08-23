Public Class BottleSongTests
    <Fact>
    Public Sub First_generic_verse()
        Dim expected = String.Join(vbLf, {
            "Ten green bottles hanging on the wall,",
            "Ten green bottles hanging on the wall,",
            "And if one green bottle should accidentally fall,",
            "There'll be nine green bottles hanging on the wall."
        })
        Assert.Equal(expected, BottleSong.Recite(10, 1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_generic_verse()
        Dim expected = String.Join(vbLf, {
            "Three green bottles hanging on the wall,",
            "Three green bottles hanging on the wall,",
            "And if one green bottle should accidentally fall,",
            "There'll be two green bottles hanging on the wall."
        })
        Assert.Equal(expected, BottleSong.Recite(3, 1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Verse_with_2_bottles()
        Dim expected = String.Join(vbLf, {
            "Two green bottles hanging on the wall,",
            "Two green bottles hanging on the wall,",
            "And if one green bottle should accidentally fall,",
            "There'll be one green bottle hanging on the wall."
        })
        Assert.Equal(expected, BottleSong.Recite(2, 1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Verse_with_1_bottle()
        Dim expected = String.Join(vbLf, {
            "One green bottle hanging on the wall,",
            "One green bottle hanging on the wall,",
            "And if one green bottle should accidentally fall,",
            "There'll be no green bottles hanging on the wall."
        })
        Assert.Equal(expected, BottleSong.Recite(1, 1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub First_two_verses()
        Dim expected = String.Join(vbLf, {
            "Ten green bottles hanging on the wall,",
            "Ten green bottles hanging on the wall,",
            "And if one green bottle should accidentally fall,",
            "There'll be nine green bottles hanging on the wall.",
            "",
            "Nine green bottles hanging on the wall,",
            "Nine green bottles hanging on the wall,",
            "And if one green bottle should accidentally fall,",
            "There'll be eight green bottles hanging on the wall."
        })
        Assert.Equal(expected, BottleSong.Recite(10, 2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Last_three_verses()
        Dim expected = String.Join(vbLf, {
            "Three green bottles hanging on the wall,",
            "Three green bottles hanging on the wall,",
            "And if one green bottle should accidentally fall,",
            "There'll be two green bottles hanging on the wall.",
            "",
            "Two green bottles hanging on the wall,",
            "Two green bottles hanging on the wall,",
            "And if one green bottle should accidentally fall,",
            "There'll be one green bottle hanging on the wall.",
            "",
            "One green bottle hanging on the wall,",
            "One green bottle hanging on the wall,",
            "And if one green bottle should accidentally fall,",
            "There'll be no green bottles hanging on the wall."
        })
        Assert.Equal(expected, BottleSong.Recite(3, 3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub All_verses()
        Dim expected = String.Join(vbLf, {
            "Ten green bottles hanging on the wall,",
            "Ten green bottles hanging on the wall,",
            "And if one green bottle should accidentally fall,",
            "There'll be nine green bottles hanging on the wall.",
            "",
            "Nine green bottles hanging on the wall,",
            "Nine green bottles hanging on the wall,",
            "And if one green bottle should accidentally fall,",
            "There'll be eight green bottles hanging on the wall.",
            "",
            "Eight green bottles hanging on the wall,",
            "Eight green bottles hanging on the wall,",
            "And if one green bottle should accidentally fall,",
            "There'll be seven green bottles hanging on the wall.",
            "",
            "Seven green bottles hanging on the wall,",
            "Seven green bottles hanging on the wall,",
            "And if one green bottle should accidentally fall,",
            "There'll be six green bottles hanging on the wall.",
            "",
            "Six green bottles hanging on the wall,",
            "Six green bottles hanging on the wall,",
            "And if one green bottle should accidentally fall,",
            "There'll be five green bottles hanging on the wall.",
            "",
            "Five green bottles hanging on the wall,",
            "Five green bottles hanging on the wall,",
            "And if one green bottle should accidentally fall,",
            "There'll be four green bottles hanging on the wall.",
            "",
            "Four green bottles hanging on the wall,",
            "Four green bottles hanging on the wall,",
            "And if one green bottle should accidentally fall,",
            "There'll be three green bottles hanging on the wall.",
            "",
            "Three green bottles hanging on the wall,",
            "Three green bottles hanging on the wall,",
            "And if one green bottle should accidentally fall,",
            "There'll be two green bottles hanging on the wall.",
            "",
            "Two green bottles hanging on the wall,",
            "Two green bottles hanging on the wall,",
            "And if one green bottle should accidentally fall,",
            "There'll be one green bottle hanging on the wall.",
            "",
            "One green bottle hanging on the wall,",
            "One green bottle hanging on the wall,",
            "And if one green bottle should accidentally fall,",
            "There'll be no green bottles hanging on the wall."
        })
        Assert.Equal(expected, BottleSong.Recite(10, 10))
    End Sub
End Class
