Imports Xunit

Public Class PrimeFactorsTests
    <Fact>
    Public Sub No_factors()
        dim number = 1L
        dim expected = Array.Empty(Of Long)()
        dim result as IEnumerable(of Long) = PrimeFactors.Factors(number)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Prime_number()
        dim number = 2L
        dim expected = {2L}
        dim result as IEnumerable(of Long) = PrimeFactors.Factors(number)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Another_prime_number()
        dim number = 3L
        dim expected = {3L}
        dim result as IEnumerable(of Long) = PrimeFactors.Factors(number)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Square_of_a_prime()
        Dim number = 9L
        Dim expected = {3L, 3L}
        Dim result as IEnumerable(of Long) = PrimeFactors.Factors(number)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Product_of_first_prime()
        Dim number = 4L
        Dim expected = {2L, 2L}
        Dim result as IEnumerable(of Long) = PrimeFactors.Factors(number)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cube_of_a_prime()
        Dim number = 8L
        Dim expected = {2L, 2L, 2L}
        Dim result as IEnumerable(of Long) = PrimeFactors.Factors(number)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Product_of_second_prime()
        Dim number = 27L
        Dim expected = {3L, 3L, 3L}
        Dim result as IEnumerable(of Long) = PrimeFactors.Factors(number)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Product_of_third_prime()
        Dim number = 625L
        Dim expected = {5L, 5L, 5L, 5L}
        Dim result as IEnumerable(of Long) = PrimeFactors.Factors(number)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Product_of_first_and_second_prime()
        Dim number = 6L
        Dim expected = {2L, 3L}
        Dim result as IEnumerable(of Long) = PrimeFactors.Factors(number)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Product_of_primes_and_non_primes()
        Dim number = 12L
        Dim expected = {2L, 2L, 3L}
        Dim result as IEnumerable(of Long) = PrimeFactors.Factors(number)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Product_of_primes()
        Dim number = 901255L
        Dim expected = {5L, 17L, 23L, 461L}
        Dim result as IEnumerable(of Long) = PrimeFactors.Factors(number)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Factors_include_a_large_prime()
        Dim number = 93819012551L
        Dim expected = {11L, 9539L, 894119L}
        Dim result as IEnumerable(of Long) = PrimeFactors.Factors(number)
        Assert.Equal(expected, result)
    End Sub
End Class
