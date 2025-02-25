Imports Xunit
Public Class TwoFerTests
    <Fact>
    Public Sub NoNameGiven()
        Dim expected = "One for you, one for me."
        Dim result as String = TwoFer.Speak()
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub ANameGiven()
        Dim expected = "One for Alice, one for me."
        Dim result as String = TwoFer.Speak("Alice")
        Assert.Equal(expected, result)
    End Sub
  
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AnotherNameGiven()
        Dim expected = "One for Bob, one for me."
        Dim result as String = TwoFer.Speak("Bob")
        Asset.Equal(expected, result)
    End Sub
End Class
