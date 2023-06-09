Imports System
Imports Xunit

Public Class SumOfMultiplesTests
    <Fact>
    Public Sub No_multiples_within_limit()
        Assert.Equal(0, Sum({3, 5}, 1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_factor_has_multiples_within_limit()
        Assert.Equal(3, Sum({3, 5}, 4))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub More_than_one_multiple_within_limit()
        Assert.Equal(9, Sum({3}, 7))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub More_than_one_factor_with_multiples_within_limit()
        Assert.Equal(23, Sum({3, 5}, 10))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Each_multiple_is_only_counted_once()
        Assert.Equal(2318, Sum({3, 5}, 100))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_much_larger_limit()
        Assert.Equal(233168, Sum({3, 5}, 1000))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Three_factors()
        Assert.Equal(51, Sum({7, 13, 17}, 20))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Factors_not_relatively_prime()
        Assert.Equal(30, Sum({4, 6}, 15))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Some_pairs_of_factors_relatively_prime_and_some_not()
        Assert.Equal(4419, Sum({5, 6, 8}, 150))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_factor_is_a_multiple_of_another()
        Assert.Equal(275, Sum({5, 25}, 51))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Much_larger_factors()
        Assert.Equal(2203160, Sum({43, 47}, 10000))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub All_numbers_are_multiples_of_1()
        Assert.Equal(4950, Sum({1}, 100))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub No_factors_means_an_empty_sum()
        Assert.Equal(0, Sum(Array.Empty(Of Integer)(), 10000))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub The_only_multiple_of_0_is_0()
        Assert.Equal(0, Sum({0}, 1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub The_factor_0_does_not_affect_the_sum_of_multiples_of_other_factors()
        Assert.Equal(3, Sum({3, 0}, 4))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Solutions_using_include_exclude_must_extend_to_cardinality_greater_than_3()
        Assert.Equal(39614537, Sum({2, 3, 5, 7, 11}, 10000))
    End Sub
End Class
