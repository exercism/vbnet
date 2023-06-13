Imports Xunit

Public Class BinarySearchTests
    <Fact>
    Public Sub Finds_a_value_in_an_array_with_one_element()
        Dim array = {6}
        Dim value = 6
        Assert.Equal(0, Find(array, value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Finds_a_value_in_the_middle_of_an_array()
        Dim array = {1, 3, 4, 6, 8, 9, 11}
        Dim value = 6
        Assert.Equal(3, Find(array, value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Finds_a_value_at_the_beginning_of_an_array()
        Dim array = {1, 3, 4, 6, 8, 9, 11}
        Dim value = 1
        Assert.Equal(0, Find(array, value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Finds_a_value_at_the_end_of_an_array()
        Dim array = {1, 3, 4, 6, 8, 9, 11}
        Dim value = 11
        Assert.Equal(6, Find(array, value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Finds_a_value_in_an_array_of_odd_length()
        Dim array = {1, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 634}
        Dim value = 144
        Assert.Equal(9, Find(array, value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Finds_a_value_in_an_array_of_even_length()
        Dim array = {1, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377}
        Dim value = 21
        Assert.Equal(5, Find(array, value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Identifies_that_a_value_is_not_included_in_the_array()
        Dim array = {1, 3, 4, 6, 8, 9, 11}
        Dim value = 7
        Assert.Equal(-1, Find(array, value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_value_smaller_than_the_arrays_smallest_value_is_not_found()
        Dim array = {1, 3, 4, 6, 8, 9, 11}
        Dim value = 0
        Assert.Equal(-1, Find(array, value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_value_larger_than_the_arrays_largest_value_is_not_found()
        Dim array = {1, 3, 4, 6, 8, 9, 11}
        Dim value = 13
        Assert.Equal(-1, Find(array, value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Nothing_is_found_in_an_empty_array()
        Dim array = System.Array.Empty(Of Integer)()
        Dim value = 1
        Assert.Equal(-1, Find(array, value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Nothing_is_found_when_the_left_and_right_bounds_cross()
        Dim array = {1, 2}
        Dim value = 0
        Assert.Equal(-1, Find(array, value))
    End Sub
End Class
