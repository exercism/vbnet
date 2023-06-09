Imports System
Imports Xunit

Public Class BookStoreTests
    <Fact>
    Public Sub Only_a_single_book()
        Dim basket = {1}
        Assert.Equal(8D, Total(basket))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_of_the_same_book()
        Dim basket = {2, 2}
        Assert.Equal(16D, Total(basket))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Empty_basket()
        Dim basket = Array.Empty(Of Integer)()
        Assert.Equal(0D, Total(basket))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_different_books()
        Dim basket = {1, 2}
        Assert.Equal(15.2D, Total(basket))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Three_different_books()
        Dim basket = {1, 2, 3}
        Assert.Equal(21.6D, Total(basket))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Four_different_books()
        Dim basket = {1, 2, 3, 4}
        Assert.Equal(25.6D, Total(basket))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Five_different_books()
        Dim basket = {1, 2, 3, 4, 5}
        Assert.Equal(30D, Total(basket))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_groups_of_four_is_cheaper_than_group_of_five_plus_group_of_three()
        Dim basket = {1, 1, 2, 2, 3, 3, 4, 5}
        Assert.Equal(51.2D, Total(basket))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_groups_of_four_is_cheaper_than_groups_of_five_and_three()
        Dim basket = {1, 1, 2, 3, 4, 4, 5, 5}
        Assert.Equal(51.2D, Total(basket))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Group_of_four_plus_group_of_two_is_cheaper_than_two_groups_of_three()
        Dim basket = {1, 1, 2, 2, 3, 4}
        Assert.Equal(40.8D, Total(basket))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_each_of_first_four_books_and_one_copy_each_of_rest()
        Dim basket = {1, 1, 2, 2, 3, 3, 4, 4, 5}
        Assert.Equal(55.6D, Total(basket))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_copies_of_each_book()
        Dim basket = {1, 1, 2, 2, 3, 3, 4, 4, 5, 5}
        Assert.Equal(60D, Total(basket))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Three_copies_of_first_book_and_two_each_of_remaining()
        Dim basket = {1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 1}
        Assert.Equal(68D, Total(basket))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Three_each_of_first_two_books_and_two_each_of_remaining_books()
        Dim basket = {1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 1, 2}
        Assert.Equal(75.2D, Total(basket))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Four_groups_of_four_are_cheaper_than_two_groups_each_of_five_and_three()
        Dim basket = {1, 1, 2, 2, 3, 3, 4, 5, 1, 1, 2, 2, 3, 3, 4, 5}
        Assert.Equal(102.4D, Total(basket))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Check_that_groups_of_four_are_created_properly_even_when_there_are_more_groups_of_three_than_groups_of_five()
        Dim basket = {1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 4, 4, 5, 5}
        Assert.Equal(145.6D, Total(basket))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_group_of_one_and_four_is_cheaper_than_one_group_of_two_and_three()
        Dim basket = {1, 1, 2, 3, 4}
        Assert.Equal(33.6D, Total(basket))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_group_of_one_and_two_plus_three_groups_of_four_is_cheaper_than_one_group_of_each_size()
        Dim basket = {1, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 5}
        Assert.Equal(100D, Total(basket))
    End Sub
End Class
