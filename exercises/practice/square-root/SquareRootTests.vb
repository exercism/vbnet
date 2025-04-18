Imports Xunit

Public Class SquareRootTests
    <Fact>
    Public Sub Root_of_1()
        Assert.Equal(1, SquareRoot.SquareRoot(1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Root_of_4()
        Assert.Equal(2, SquareRoot.SquareRoot(4))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Root_of_25()
        Assert.Equal(5, SquareRoot.SquareRoot(25))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Root_of_81()
        Assert.Equal(9, SquareRoot.SquareRoot(81))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Root_of_196()
        Assert.Equal(14, SquareRoot.SquareRoot(196))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Root_of_65025()
        Assert.Equal(255, SquareRoot.SquareRoot(65025))
    End Sub
End Class
