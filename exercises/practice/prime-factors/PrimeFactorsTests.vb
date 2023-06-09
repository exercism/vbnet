Imports Xunit

Public Class PrimeFactorsTests
    <Fact>
    Public Sub No_factors()
        Assert.Empty(PrimeFactors.Factors(1L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Prime_number()
        Assert.Equal({2L}, PrimeFactors.Factors(2L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Another_prime_number()
        Assert.Equal({3L}, PrimeFactors.Factors(3L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Square_of_a_prime()
        Assert.Equal({3L, 3L}, PrimeFactors.Factors(9L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Product_of_first_prime()
        Assert.Equal({2L, 2L}, PrimeFactors.Factors(4L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cube_of_a_prime()
        Assert.Equal({2L, 2L, 2L}, PrimeFactors.Factors(8L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Product_of_second_prime()
        Assert.Equal({3L, 3L, 3L}, PrimeFactors.Factors(27L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Product_of_third_prime()
        Assert.Equal({5L, 5L, 5L, 5L}, PrimeFactors.Factors(625L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Product_of_first_and_second_prime()
        Assert.Equal({2L, 3L}, PrimeFactors.Factors(6L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Product_of_primes_and_non_primes()
        Assert.Equal({2L, 2L, 3L}, PrimeFactors.Factors(12L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Product_of_primes()
        Assert.Equal({5L, 17L, 23L, 461L}, PrimeFactors.Factors(901255L))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Factors_include_a_large_prime()
        Assert.Equal({11L, 9539L, 894119L}, PrimeFactors.Factors(93819012551L))
    End Sub
End Class
