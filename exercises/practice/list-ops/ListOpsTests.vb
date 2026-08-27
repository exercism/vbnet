Public Class ListOpsTests
    <Fact>
    Public Sub Append_entries_to_a_list_and_return_the_new_list_empty_lists()
        Dim list1 = New List(Of Integer)()
        Dim list2 = New List(Of Integer)()
        Assert.Empty(ListOps.Append(list1, list2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Append_entries_to_a_list_and_return_the_new_list_list_to_empty_list()
        Dim list1 = New List(Of Integer)()
        Dim list2 = {1, 2, 3, 4}.ToList()
        Dim expected = {1, 2, 3, 4}.ToList()
        Assert.Equal(expected, ListOps.Append(list1, list2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Append_entries_to_a_list_and_return_the_new_list_empty_list_to_list()
        Dim list1 = {1, 2, 3, 4}.ToList()
        Dim list2 = New List(Of Integer)()
        Dim expected = {1, 2, 3, 4}.ToList()
        Assert.Equal(expected, ListOps.Append(list1, list2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Append_entries_to_a_list_and_return_the_new_list_non_empty_lists()
        Dim list1 = {1, 2}.ToList()
        Dim list2 = {2, 3, 4, 5}.ToList()
        Dim expected = {1, 2, 2, 3, 4, 5}.ToList()
        Assert.Equal(expected, ListOps.Append(list1, list2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Concatenate_a_list_of_lists_empty_list()
        Dim lists = New List(Of List(Of Integer))()
        Assert.Empty(ListOps.Concat(lists))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Concatenate_a_list_of_lists_list_of_lists()
        Dim lists = {
            {1, 2}.ToList(),
            {3}.ToList(),
            New List(Of Integer)(),
            {4, 5, 6}.ToList()
        }.ToList()
        Dim expected = {1, 2, 3, 4, 5, 6}.ToList()
        Assert.Equal(expected, ListOps.Concat(lists))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Concatenate_a_list_of_lists_list_of_nested_lists()
        Dim lists = {
            {
                {1}.ToList(),
                {2}.ToList()
            }.ToList(),
            {
                {3}.ToList()
            }.ToList(),
            {
                New List(Of Integer)()
            }.ToList(),
            {
                {4, 5, 6}.ToList()
            }.ToList()
        }.ToList()
        Dim expected = {
            {1}.ToList(),
            {2}.ToList(),
            {3}.ToList(),
            New List(Of Integer)(),
            {4, 5, 6}.ToList()
        }.ToList()
        Assert.Equal(expected, ListOps.Concat(lists))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Filter_list_returning_only_values_that_satisfy_the_filter_function_empty_list()
        Dim list = New List(Of Integer)()
        Dim [function] = New Func(Of Integer, Boolean)(Function(x) x Mod 2 = 1)
        Assert.Empty(ListOps.Filter(list, [function]))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Filter_list_returning_only_values_that_satisfy_the_filter_function_non_empty_list()
        Dim list = {1, 2, 3, 5}.ToList()
        Dim [function] = New Func(Of Integer, Boolean)(Function(x) x Mod 2 = 1)
        Dim expected = {1, 3, 5}.ToList()
        Assert.Equal(expected, ListOps.Filter(list, [function]))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Returns_the_length_of_a_list_empty_list()
        Dim list = New List(Of Integer)()
        Assert.Equal(0, ListOps.Length(list))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Returns_the_length_of_a_list_non_empty_list()
        Dim list = {1, 2, 3, 4}.ToList()
        Assert.Equal(4, ListOps.Length(list))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Return_a_list_of_elements_whose_values_equal_the_list_value_transformed_by_the_mapping_function_empty_list()
        Dim list = New List(Of Integer)()
        Dim [function] = New Func(Of Integer, Integer)(Function(x) x + 1)
        Assert.Empty(ListOps.Map(list, [function]))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Return_a_list_of_elements_whose_values_equal_the_list_value_transformed_by_the_mapping_function_non_empty_list()
        Dim list = {1, 3, 5, 7}.ToList()
        Dim [function] = New Func(Of Integer, Integer)(Function(x) x + 1)
        Dim expected = {2, 4, 6, 8}.ToList()
        Assert.Equal(expected, ListOps.Map(list, [function]))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Folds_reduces_the_given_list_from_the_left_with_a_function_empty_list()
        Dim list = New List(Of Integer)()
        Dim [function] = New Func(Of Integer, Integer, Integer)(Function(acc, el) el * acc)
        Assert.Equal(2, ListOps.Foldl(list, 2, [function]))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Folds_reduces_the_given_list_from_the_left_with_a_function_direction_independent_function_applied_to_non_empty_list()
        Dim list = {1, 2, 3, 4}.ToList()
        Dim [function] = New Func(Of Integer, Integer, Integer)(Function(acc, el) el + acc)
        Assert.Equal(15, ListOps.Foldl(list, 5, [function]))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Folds_reduces_the_given_list_from_the_right_with_a_function_empty_list()
        Dim list = New List(Of Integer)()
        Dim [function] = New Func(Of Integer, Integer, Integer)(Function(acc, el) el * acc)
        Assert.Equal(2, ListOps.Foldr(list, 2, [function]))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Folds_reduces_the_given_list_from_the_right_with_a_function_direction_independent_function_applied_to_non_empty_list()
        Dim list = {1, 2, 3, 4}.ToList()
        Dim [function] = New Func(Of Integer, Integer, Integer)(Function(acc, el) el + acc)
        Assert.Equal(15, ListOps.Foldr(list, 5, [function]))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reverse_the_elements_of_the_list_empty_list()
        Dim list = New List(Of Integer)()
        Assert.Empty(ListOps.Reverse(list))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reverse_the_elements_of_the_list_non_empty_list()
        Dim list = {1, 3, 5, 7}.ToList()
        Dim expected = {7, 5, 3, 1}.ToList()
        Assert.Equal(expected, ListOps.Reverse(list))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reverse_the_elements_of_the_list_list_of_lists_is_not_flattened()
        Dim list = {
            {1, 2}.ToList(),
            {3}.ToList(),
            New List(Of Integer)(),
            {4, 5, 6}.ToList()
        }.ToList()
        Dim expected = {
            {4, 5, 6}.ToList(),
            New List(Of Integer)(),
            {3}.ToList(),
            {1, 2}.ToList()
        }.ToList()
        Assert.Equal(expected, ListOps.Reverse(list))
    End Sub
End Class
