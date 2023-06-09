Imports Xunit

Public Class FlattenArrayTests
    <Fact>
    Public Sub Empty()
        Dim array = System.Array.Empty(Of Object)()
        Assert.Empty(Flatten(array))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub No_nesting()
        Dim array = New Object() {0, 1, 2}
        Dim expected = {0, 1, 2}
        Assert.Equal(expected, Flatten(array))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Flattens_a_nested_array()
        Dim array = New Object() {New Object() {System.Array.Empty(Of Object)()}}
        Assert.Empty(Flatten(array))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Flattens_array_with_just_integers_present()
        Dim array = New Object() {1, New Object() {2, 3, 4, 5, 6, 7}, 8}
        Dim expected = {1, 2, 3, 4, 5, 6, 7, 8}
        Assert.Equal(expected, Flatten(array))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number_5_level_nesting()
        Dim array = New Object() {0, 2, New Object() {New Object() {2, 3}, 8, 100, 4, New Object() {New Object() {New Object() {50}}}}, -2}
        Dim expected = {0, 2, 2, 3, 8, 100, 4, 50, -2}
        Assert.Equal(expected, Flatten(array))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number_6_level_nesting()
        Dim array = New Object() {1, New Object() {2, New Object() {New Object() {3}}, New Object() {4, New Object() {New Object() {5}}}, 6, 7}, 8}
        Dim expected = {1, 2, 3, 4, 5, 6, 7, 8}
        Assert.Equal(expected, Flatten(array))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Null_values_are_omitted_from_the_final_result()
        Dim array = New Object() {1, 2, Nothing}
        Dim expected = {1, 2}
        Assert.Equal(expected, Flatten(array))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Consecutive_null_values_at_the_front_of_the_list_are_omitted_from_the_final_result()
        Dim array = New Object() {Nothing, Nothing, 3}
        Dim expected = {3}
        Assert.Equal(expected, Flatten(array))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Consecutive_null_values_in_the_middle_of_the_list_are_omitted_from_the_final_result()
        Dim array = New Object() {1, Nothing, Nothing, 4}
        Dim expected = {1, 4}
        Assert.Equal(expected, Flatten(array))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Number_6_level_nest_list_with_null_values()
        Dim array = New Object() {0, 2, New Object() {New Object() {2, 3}, 8, New Object() {New Object() {100}}, Nothing, New Object() {New Object() {Nothing}}}, -2}
        Dim expected = {0, 2, 2, 3, 8, 100, -2}
        Assert.Equal(expected, Flatten(array))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub All_values_in_nested_list_are_null()
        Dim array = New Object() {Nothing, New Object() {New Object() {New Object() {Nothing}}}, Nothing, Nothing, New Object() {New Object() {Nothing, Nothing}, Nothing}, Nothing}
        Assert.Empty(Flatten(array))
    End Sub
End Class
