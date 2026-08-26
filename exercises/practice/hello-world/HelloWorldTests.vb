Public Class HelloWorldTests
    <Fact>
    Public Sub Say_hi()
        Assert.Equal("Hello, World!", HelloWorld.Hello())
    End Sub
End Class
