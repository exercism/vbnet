Imports Xunit

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
        Dim element = 1
        Dim sut = New CustomSet()
        Assert.False(sut.Contains(element))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_the_element_is_in_the_set()
        Dim element = 1
        Dim sut = New CustomSet({1, 2, 3})
        Assert.True(sut.Contains(element))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub When_the_element_is_not_in_the_set()
        Dim element = 4
        Dim sut = New CustomSet({1, 2, 3})
        Assert.False(sut.Contains(element))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Empty_set_is_a_subset_of_another_empty_set()
        Dim set2 = New CustomSet()
        Dim sut = New CustomSet()
        Assert.True(sut.Subset(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Empty_set_is_a_subset_of_non_empty_set()
        Dim set2 = New CustomSet({1})
        Dim sut = New CustomSet()
        Assert.True(sut.Subset(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Non_empty_set_is_not_a_subset_of_empty_set()
        Dim set2 = New CustomSet()
        Dim sut = New CustomSet({1})
        Assert.False(sut.Subset(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Set_is_a_subset_of_set_with_exact_same_elements()
        Dim set2 = New CustomSet({1, 2, 3})
        Dim sut = New CustomSet({1, 2, 3})
        Assert.True(sut.Subset(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Set_is_a_subset_of_larger_set_with_same_elements()
        Dim set2 = New CustomSet({4, 1, 2, 3})
        Dim sut = New CustomSet({1, 2, 3})
        Assert.True(sut.Subset(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Set_is_not_a_subset_of_set_that_does_not_contain_its_elements()
        Dim set2 = New CustomSet({4, 1, 3})
        Dim sut = New CustomSet({1, 2, 3})
        Assert.False(sut.Subset(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub The_empty_set_is_disjoint_with_itself()
        Dim set2 = New CustomSet()
        Dim sut = New CustomSet()
        Assert.True(sut.Disjoint(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Empty_set_is_disjoint_with_non_empty_set()
        Dim set2 = New CustomSet({1})
        Dim sut = New CustomSet()
        Assert.True(sut.Disjoint(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Non_empty_set_is_disjoint_with_empty_set()
        Dim set2 = New CustomSet()
        Dim sut = New CustomSet({1})
        Assert.True(sut.Disjoint(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sets_are_not_disjoint_if_they_share_an_element()
        Dim set2 = New CustomSet({2, 3})
        Dim sut = New CustomSet({1, 2})
        Assert.False(sut.Disjoint(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sets_are_disjoint_if_they_share_no_elements()
        Dim set2 = New CustomSet({3, 4})
        Dim sut = New CustomSet({1, 2})
        Assert.True(sut.Disjoint(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Empty_sets_are_equal()
        Dim set2 = New CustomSet()
        Dim sut = New CustomSet()
        Assert.True(sut.Equals(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Empty_set_is_not_equal_to_non_empty_set()
        Dim set2 = New CustomSet({1, 2, 3})
        Dim sut = New CustomSet()
        Assert.False(sut.Equals(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Non_empty_set_is_not_equal_to_empty_set()
        Dim set2 = New CustomSet()
        Dim sut = New CustomSet({1, 2, 3})
        Assert.False(sut.Equals(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sets_with_the_same_elements_are_equal()
        Dim set2 = New CustomSet({2, 1})
        Dim sut = New CustomSet({1, 2})
        Assert.True(sut.Equals(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sets_with_different_elements_are_not_equal()
        Dim set2 = New CustomSet({1, 2, 4})
        Dim sut = New CustomSet({1, 2, 3})
        Assert.False(sut.Equals(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Set_is_not_equal_to_larger_set_with_same_elements()
        Dim set2 = New CustomSet({1, 2, 3, 4})
        Dim sut = New CustomSet({1, 2, 3})
        Assert.False(sut.Equals(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Add_to_empty_set()
        Dim element = 3
        Dim sut = New CustomSet()
        Assert.Equal(New CustomSet({3}), sut.Add(element))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Add_to_non_empty_set()
        Dim element = 3
        Dim sut = New CustomSet({1, 2, 4})
        Assert.Equal(New CustomSet({1, 2, 3, 4}), sut.Add(element))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Adding_an_existing_element_does_not_change_the_set()
        Dim element = 3
        Dim sut = New CustomSet({1, 2, 3})
        Assert.Equal(New CustomSet({1, 2, 3}), sut.Add(element))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Intersection_of_two_empty_sets_is_an_empty_set()
        Dim set2 = New CustomSet()
        Dim sut = New CustomSet()
        Assert.Equal(New CustomSet(), sut.Intersection(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Intersection_of_an_empty_set_and_non_empty_set_is_an_empty_set()
        Dim set2 = New CustomSet({3, 2, 5})
        Dim sut = New CustomSet()
        Assert.Equal(New CustomSet(), sut.Intersection(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Intersection_of_a_non_empty_set_and_an_empty_set_is_an_empty_set()
        Dim set2 = New CustomSet()
        Dim sut = New CustomSet({1, 2, 3, 4})
        Assert.Equal(New CustomSet(), sut.Intersection(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Intersection_of_two_sets_with_no_shared_elements_is_an_empty_set()
        Dim set2 = New CustomSet({4, 5, 6})
        Dim sut = New CustomSet({1, 2, 3})
        Assert.Equal(New CustomSet(), sut.Intersection(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Intersection_of_two_sets_with_shared_elements_is_a_set_of_the_shared_elements()
        Dim set2 = New CustomSet({3, 2, 5})
        Dim sut = New CustomSet({1, 2, 3, 4})
        Assert.Equal(New CustomSet({2, 3}), sut.Intersection(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Difference_of_two_empty_sets_is_an_empty_set()
        Dim set2 = New CustomSet()
        Dim sut = New CustomSet()
        Assert.Equal(New CustomSet(), sut.Difference(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Difference_of_empty_set_and_non_empty_set_is_an_empty_set()
        Dim set2 = New CustomSet({3, 2, 5})
        Dim sut = New CustomSet()
        Assert.Equal(New CustomSet(), sut.Difference(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Difference_of_a_non_empty_set_and_an_empty_set_is_the_non_empty_set()
        Dim set2 = New CustomSet()
        Dim sut = New CustomSet({1, 2, 3, 4})
        Assert.Equal(New CustomSet({1, 2, 3, 4}), sut.Difference(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Difference_of_two_non_empty_sets_is_a_set_of_elements_that_are_only_in_the_first_set()
        Dim set2 = New CustomSet({2, 4})
        Dim sut = New CustomSet({3, 2, 1})
        Assert.Equal(New CustomSet({1, 3}), sut.Difference(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Union_of_empty_sets_is_an_empty_set()
        Dim set2 = New CustomSet()
        Dim sut = New CustomSet()
        Assert.Equal(New CustomSet(), sut.Union(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Union_of_an_empty_set_and_non_empty_set_is_the_non_empty_set()
        Dim set2 = New CustomSet({2})
        Dim sut = New CustomSet()
        Assert.Equal(New CustomSet({2}), sut.Union(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Union_of_a_non_empty_set_and_empty_set_is_the_non_empty_set()
        Dim set2 = New CustomSet()
        Dim sut = New CustomSet({1, 3})
        Assert.Equal(New CustomSet({1, 3}), sut.Union(set2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Union_of_non_empty_sets_contains_all_unique_elements()
        Dim set2 = New CustomSet({2, 3})
        Dim sut = New CustomSet({1, 3})
        Assert.Equal(New CustomSet({3, 2, 1}), sut.Union(set2))
    End Sub
End Class
