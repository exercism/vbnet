Imports System
Imports Xunit
Public Class CollatzConjectureTests
    <Fact>
    Public Sub ZeroStepsForOne()
        Assert.Equal(0, Steps(1))
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub DivideIfEven()
        Assert.Equal(4, Steps(16))
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub EvenAndOddSteps()
        Assert.Equal(9, Steps(12))
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub LargeNumberOfEvenAndOddSteps()
        Assert.Equal(152, Steps(1000000))
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub ZeroIsAnError()
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() Steps(0))
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub NegativeValueIsAnError()
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() Steps(-15))
    End Sub
End Class