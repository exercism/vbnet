Public Class NthPrimeTests
    <Fact>
    Public Sub First_prime()
        Assert.Equal(2, NthPrime.Prime(1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Second_prime()
        Assert.Equal(3, NthPrime.Prime(2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sixth_prime()
        Assert.Equal(13, NthPrime.Prime(6))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Big_prime()
        Assert.Equal(104743, NthPrime.Prime(10001))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub There_is_no_zeroth_prime()
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() NthPrime.Prime(0))
    End Sub
End Class
