Public Class ResistorColorTests
    <Fact>
    Public Sub Black()
        Assert.Equal(0, ResistorColor.ColorCode("black"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub White()
        Assert.Equal(9, ResistorColor.ColorCode("white"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Orange()
        Assert.Equal(3, ResistorColor.ColorCode("orange"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Colors()
        Dim expected = {
            "black", "brown", "red", "orange", "yellow",
            "green", "blue", "violet", "grey", "white"
        }
        Assert.Equal(expected, ResistorColor.Colors())
    End Sub
End Class
