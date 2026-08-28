Public Class ResistorColorDuoTests
    <Fact>
    Public Sub Brown_and_black()
        Assert.Equal(10, ResistorColorDuo.Value({"brown", "black"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Blue_and_grey()
        Assert.Equal(68, ResistorColorDuo.Value({"blue", "grey"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Yellow_and_violet()
        Assert.Equal(47, ResistorColorDuo.Value({"yellow", "violet"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub White_and_red()
        Assert.Equal(92, ResistorColorDuo.Value({"white", "red"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Orange_and_orange()
        Assert.Equal(33, ResistorColorDuo.Value({"orange", "orange"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ignore_additional_colors()
        Assert.Equal(51, ResistorColorDuo.Value({"green", "brown", "orange"}))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Black_and_brown_one_digit()
        Assert.Equal(1, ResistorColorDuo.Value({"black", "brown"}))
    End Sub
End Class
