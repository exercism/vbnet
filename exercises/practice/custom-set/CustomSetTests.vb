Public Class CustomSetTests
    <Fact>
    Public Sub Sets_with_no_elements_are_empty()
        Dim sut = New CustomSet()
        Assert.True(sut.Empty())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sets_with_elements_are_not_empty()
        Dim sut = New CustomSet({1})
        Assert.False(sut.Empty())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Nothing_is_contained_in_an_empty_set()
        Dim sut = New CustomSet()
        Assert.False(sut.Contains(1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_the_element_is_in_the_set()
        Dim sut = New CustomSet({1, 2, 3})
        Assert.True(sut.Contains(1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_the_element_is_not_in_the_set()
        Dim sut = New CustomSet({1, 2, 3})
        Assert.False(sut.Contains(4))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Empty_set_is_a_subset_of_another_empty_set()
        Dim set1 = New CustomSet()
        Dim set2 = New CustomSet()
        Assert.True(set1.Subset(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Empty_set_is_a_subset_of_non_empty_set()
        Dim set1 = New CustomSet()
        Dim set2 = New CustomSet({1})
        Assert.True(set1.Subset(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Non_empty_set_is_not_a_subset_of_empty_set()
        Dim set1 = New CustomSet({1})
        Dim set2 = New CustomSet()
        Assert.False(set1.Subset(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Set_is_a_subset_of_set_with_exact_same_elements()
        Dim set1 = New CustomSet({1, 2, 3})
        Dim set2 = New CustomSet({1, 2, 3})
        Assert.True(set1.Subset(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Set_is_a_subset_of_larger_set_with_same_elements()
        Dim set1 = New CustomSet({1, 2, 3})
        Dim set2 = New CustomSet({4, 1, 2, 3})
        Assert.True(set1.Subset(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Set_is_not_a_subset_of_set_that_does_not_contain_its_elements()
        Dim set1 = New CustomSet({1, 2, 3})
        Dim set2 = New CustomSet({4, 1, 3})
        Assert.False(set1.Subset(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub The_empty_set_is_disjoint_with_itself()
        Dim set1 = New CustomSet()
        Dim set2 = New CustomSet()
        Assert.True(set1.Disjoint(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Empty_set_is_disjoint_with_non_empty_set()
        Dim set1 = New CustomSet()
        Dim set2 = New CustomSet({1})
        Assert.True(set1.Disjoint(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Non_empty_set_is_disjoint_with_empty_set()
        Dim set1 = New CustomSet({1})
        Dim set2 = New CustomSet()
        Assert.True(set1.Disjoint(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sets_are_not_disjoint_if_they_share_an_element()
        Dim set1 = New CustomSet({1, 2})
        Dim set2 = New CustomSet({2, 3})
        Assert.False(set1.Disjoint(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sets_are_disjoint_if_they_share_no_elements()
        Dim set1 = New CustomSet({1, 2})
        Dim set2 = New CustomSet({3, 4})
        Assert.True(set1.Disjoint(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Empty_sets_are_equal()
        Dim set1 = New CustomSet()
        Dim set2 = New CustomSet()
        Assert.Equal(set1, set2)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Empty_set_is_not_equal_to_non_empty_set()
        Dim set1 = New CustomSet()
        Dim set2 = New CustomSet({1, 2, 3})
        Assert.NotEqual(set1, set2)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Non_empty_set_is_not_equal_to_empty_set()
        Dim set1 = New CustomSet({1, 2, 3})
        Dim set2 = New CustomSet()
        Assert.NotEqual(set1, set2)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sets_with_the_same_elements_are_equal()
        Dim set1 = New CustomSet({1, 2})
        Dim set2 = New CustomSet({2, 1})
        Assert.Equal(set1, set2)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sets_with_different_elements_are_not_equal()
        Dim set1 = New CustomSet({1, 2, 3})
        Dim set2 = New CustomSet({1, 2, 4})
        Assert.NotEqual(set1, set2)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Set_is_not_equal_to_larger_set_with_same_elements()
        Dim set1 = New CustomSet({1, 2, 3})
        Dim set2 = New CustomSet({1, 2, 3, 4})
        Assert.NotEqual(set1, set2)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Set_is_equal_to_a_set_constructed_from_an_array_with_duplicates()
        Dim set1 = New CustomSet({1})
        Dim set2 = New CustomSet({1, 1})
        Assert.Equal(set1, set2)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Add_to_empty_set()
        Dim sut = New CustomSet()
        Dim expected = New CustomSet({3})
        Assert.Equal(expected, sut.Add(3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Add_to_non_empty_set()
        Dim sut = New CustomSet({1, 2, 4})
        Dim expected = New CustomSet({1, 2, 3, 4})
        Assert.Equal(expected, sut.Add(3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Adding_an_existing_element_does_not_change_the_set()
        Dim sut = New CustomSet({1, 2, 3})
        Dim expected = New CustomSet({1, 2, 3})
        Assert.Equal(expected, sut.Add(3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Intersection_of_two_empty_sets_is_an_empty_set()
        Dim set1 = New CustomSet()
        Dim set2 = New CustomSet()
        Dim expected = New CustomSet()
        Assert.Equal(expected, set1.Intersection(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Intersection_of_an_empty_set_and_non_empty_set_is_an_empty_set()
        Dim set1 = New CustomSet()
        Dim set2 = New CustomSet({3, 2, 5})
        Dim expected = New CustomSet()
        Assert.Equal(expected, set1.Intersection(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Intersection_of_a_non_empty_set_and_an_empty_set_is_an_empty_set()
        Dim set1 = New CustomSet({1, 2, 3, 4})
        Dim set2 = New CustomSet()
        Dim expected = New CustomSet()
        Assert.Equal(expected, set1.Intersection(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Intersection_of_two_sets_with_no_shared_elements_is_an_empty_set()
        Dim set1 = New CustomSet({1, 2, 3})
        Dim set2 = New CustomSet({4, 5, 6})
        Dim expected = New CustomSet()
        Assert.Equal(expected, set1.Intersection(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Intersection_of_two_sets_with_shared_elements_is_a_set_of_the_shared_elements()
        Dim set1 = New CustomSet({1, 2, 3, 4})
        Dim set2 = New CustomSet({3, 2, 5})
        Dim expected = New CustomSet({2, 3})
        Assert.Equal(expected, set1.Intersection(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Difference_of_two_empty_sets_is_an_empty_set()
        Dim set1 = New CustomSet()
        Dim set2 = New CustomSet()
        Dim expected = New CustomSet()
        Assert.Equal(expected, set1.Difference(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Difference_of_empty_set_and_non_empty_set_is_an_empty_set()
        Dim set1 = New CustomSet()
        Dim set2 = New CustomSet({3, 2, 5})
        Dim expected = New CustomSet()
        Assert.Equal(expected, set1.Difference(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Difference_of_a_non_empty_set_and_an_empty_set_is_the_non_empty_set()
        Dim set1 = New CustomSet({1, 2, 3, 4})
        Dim set2 = New CustomSet()
        Dim expected = New CustomSet({1, 2, 3, 4})
        Assert.Equal(expected, set1.Difference(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Difference_of_two_non_empty_sets_is_a_set_of_elements_that_are_only_in_the_first_set()
        Dim set1 = New CustomSet({3, 2, 1})
        Dim set2 = New CustomSet({2, 4})
        Dim expected = New CustomSet({1, 3})
        Assert.Equal(expected, set1.Difference(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Difference_removes_all_duplicates_in_the_first_set()
        Dim set1 = New CustomSet({1, 1})
        Dim set2 = New CustomSet({1})
        Dim expected = New CustomSet()
        Assert.Equal(expected, set1.Difference(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Union_of_empty_sets_is_an_empty_set()
        Dim set1 = New CustomSet()
        Dim set2 = New CustomSet()
        Dim expected = New CustomSet()
        Assert.Equal(expected, set1.Union(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Union_of_an_empty_set_and_non_empty_set_is_the_non_empty_set()
        Dim set1 = New CustomSet()
        Dim set2 = New CustomSet({2})
        Dim expected = New CustomSet({2})
        Assert.Equal(expected, set1.Union(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Union_of_a_non_empty_set_and_empty_set_is_the_non_empty_set()
        Dim set1 = New CustomSet({1, 3})
        Dim set2 = New CustomSet()
        Dim expected = New CustomSet({1, 3})
        Assert.Equal(expected, set1.Union(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Union_of_non_empty_sets_contains_all_unique_elements()
        Dim set1 = New CustomSet({1, 3})
        Dim set2 = New CustomSet({2, 3})
        Dim expected = New CustomSet({3, 2, 1})
        Assert.Equal(expected, set1.Union(set2))
    End Sub
End Class
