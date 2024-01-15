Imports Xunit

Public Class ResistorColorTrioTests
    <Fact>
    Public Sub Orange_and_orange_and_black()
        Assert.Equal("33 ohms", Label({"orange", "orange", "black"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Blue_and_grey_and_brown()
        Assert.Equal("680 ohms", Label({"blue", "grey", "brown"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Red_and_black_and_red()
        Assert.Equal("2 kiloohms", Label({"red", "black", "red"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Green_and_brown_and_orange()
        Assert.Equal("51 kiloohms", Label({"green", "brown", "orange"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Yellow_and_violet_and_yellow()
        Assert.Equal("470 kiloohms", Label({"yellow", "violet", "yellow"}))
    End Sub
End Class
