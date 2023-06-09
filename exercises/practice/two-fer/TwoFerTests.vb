Imports Xunit
Public Class TwoFerTests
    <Fact>
    Public Sub NoNameGiven()
        Assert.Equal("One for you, one for me.", TwoFer.Speak())
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub ANameGiven()
        Assert.Equal("One for Alice, one for me.", TwoFer.Speak("Alice"))
    End Sub
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AnotherNameGiven()
        Assert.Equal("One for Bob, one for me.", TwoFer.Speak("Bob"))
    End Sub
End Class
