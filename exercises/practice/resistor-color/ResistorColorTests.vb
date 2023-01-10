Imports Xunit
Public Class ResistorColorTest
    <Fact>
    Public Sub Black()
        Assert.Equal(0, ColorCode("black"))
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub White()
        Assert.Equal(9, ColorCode("white"))
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Orange()
        Assert.Equal(3, ColorCode("orange"))
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Colors()
        Assert.Equal({"black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white"}, ResistorColor.Colors())
    End Sub
End Class