Imports Xunit

Public Class BottleSongTests
    <Fact>
    Public Sub Single_verse_first_generic_verse()
        Dim expected = _
            "Ten green bottles hanging on the wall," & vbLf & _
            "Ten green bottles hanging on the wall," & vbLf & _
            "And if one green bottle should accidentally fall," & vbLf & _
            "There'll be nine green bottles hanging on the wall."
        Assert.Equal(expected, Recite(10, 1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Single_verse_last_generic_verse()
        Dim expected = _
            "Three green bottles hanging on the wall," & vbLf & _
            "Three green bottles hanging on the wall," & vbLf & _
            "And if one green bottle should accidentally fall," & vbLf & _
            "There'll be two green bottles hanging on the wall."
        Assert.Equal(expected, Recite(3, 1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Single_verse_verse_with_2_bottles()
        Dim expected = _
            "Two green bottles hanging on the wall," & vbLf & _
            "Two green bottles hanging on the wall," & vbLf & _
            "And if one green bottle should accidentally fall," & vbLf & _
            "There'll be one green bottle hanging on the wall."
        Assert.Equal(expected, Recite(2, 1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Single_verse_verse_with_1_bottle()
        Dim expected = _
            "One green bottle hanging on the wall," & vbLf & _
            "One green bottle hanging on the wall," & vbLf & _
            "And if one green bottle should accidentally fall," & vbLf & _
            "There'll be no green bottles hanging on the wall."
        Assert.Equal(expected, Recite(1, 1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_verses_first_two_verses()
        Dim expected = _
            "Ten green bottles hanging on the wall," & vbLf & _
            "Ten green bottles hanging on the wall," & vbLf & _
            "And if one green bottle should accidentally fall," & vbLf & _
            "There'll be nine green bottles hanging on the wall." & vbLf & _
            vbLf & _
            "Nine green bottles hanging on the wall," & vbLf & _
            "Nine green bottles hanging on the wall," & vbLf & _
            "And if one green bottle should accidentally fall," & vbLf & _
            "There'll be eight green bottles hanging on the wall."
        Assert.Equal(expected, Recite(10, 2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_verses_last_three_verses()
        Dim expected = _
            "Three green bottles hanging on the wall," & vbLf & _
            "Three green bottles hanging on the wall," & vbLf & _
            "And if one green bottle should accidentally fall," & vbLf & _
            "There'll be two green bottles hanging on the wall." & vbLf & _
            vbLf & _
            "Two green bottles hanging on the wall," & vbLf & _
            "Two green bottles hanging on the wall," & vbLf & _
            "And if one green bottle should accidentally fall," & vbLf & _
            "There'll be one green bottle hanging on the wall." & vbLf & _
            vbLf & _
            "One green bottle hanging on the wall," & vbLf & _
            "One green bottle hanging on the wall," & vbLf & _
            "And if one green bottle should accidentally fall," & vbLf & _
            "There'll be no green bottles hanging on the wall."
        Assert.Equal(expected, Recite(3, 3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_verses_all_verses()
        Dim expected = _
            "Ten green bottles hanging on the wall," & vbLf & _
            "Ten green bottles hanging on the wall," & vbLf & _
            "And if one green bottle should accidentally fall," & vbLf & _
            "There'll be nine green bottles hanging on the wall." & vbLf & _
            vbLf & _
            "Nine green bottles hanging on the wall," & vbLf & _
            "Nine green bottles hanging on the wall," & vbLf & _
            "And if one green bottle should accidentally fall," & vbLf & _
            "There'll be eight green bottles hanging on the wall." & vbLf & _
            vbLf & _
            "Eight green bottles hanging on the wall," & vbLf & _
            "Eight green bottles hanging on the wall," & vbLf & _
            "And if one green bottle should accidentally fall," & vbLf & _
            "There'll be seven green bottles hanging on the wall." & vbLf & _
            vbLf & _
            "Seven green bottles hanging on the wall," & vbLf & _
            "Seven green bottles hanging on the wall," & vbLf & _
            "And if one green bottle should accidentally fall," & vbLf & _
            "There'll be six green bottles hanging on the wall." & vbLf & _
            vbLf & _
            "Six green bottles hanging on the wall," & vbLf & _
            "Six green bottles hanging on the wall," & vbLf & _
            "And if one green bottle should accidentally fall," & vbLf & _
            "There'll be five green bottles hanging on the wall." & vbLf & _
            vbLf & _
            "Five green bottles hanging on the wall," & vbLf & _
            "Five green bottles hanging on the wall," & vbLf & _
            "And if one green bottle should accidentally fall," & vbLf & _
            "There'll be four green bottles hanging on the wall." & vbLf & _
            vbLf & _
            "Four green bottles hanging on the wall," & vbLf & _
            "Four green bottles hanging on the wall," & vbLf & _
            "And if one green bottle should accidentally fall," & vbLf & _
            "There'll be three green bottles hanging on the wall." & vbLf & _
            vbLf & _
            "Three green bottles hanging on the wall," & vbLf & _
            "Three green bottles hanging on the wall," & vbLf & _
            "And if one green bottle should accidentally fall," & vbLf & _
            "There'll be two green bottles hanging on the wall." & vbLf & _
            vbLf & _
            "Two green bottles hanging on the wall," & vbLf & _
            "Two green bottles hanging on the wall," & vbLf & _
            "And if one green bottle should accidentally fall," & vbLf & _
            "There'll be one green bottle hanging on the wall." & vbLf & _
            vbLf & _
            "One green bottle hanging on the wall," & vbLf & _
            "One green bottle hanging on the wall," & vbLf & _
            "And if one green bottle should accidentally fall," & vbLf & _
            "There'll be no green bottles hanging on the wall."
        Assert.Equal(expected, Recite(10, 10))
    End Sub
End Class