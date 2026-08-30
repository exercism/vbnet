Public Class TwoFerTests
    <Fact>
    Public Sub No_name_given()
        Dim actual As String = TwoFer.Speak()

        Assert.Equal("One for you, one for me.", actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_name_given()
        Dim actual As String = TwoFer.Speak("Alice")

        Assert.Equal("One for Alice, one for me.", actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Another_name_given()
        Dim actual As String = TwoFer.Speak("Bob")

        Assert.Equal("One for Bob, one for me.", actual)
    End Sub
End Class
