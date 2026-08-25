Public Class EliudsEggsTests
    <Fact>
    Public Sub Zero_eggs()
        Assert.Equal(0, EliudsEggs.EggCount(0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_egg()
        Assert.Equal(1, EliudsEggs.EggCount(16))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Four_eggs()
        Assert.Equal(4, EliudsEggs.EggCount(89))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Thirteen_eggs()
        Assert.Equal(13, EliudsEggs.EggCount(2000000000))
    End Sub
End Class
