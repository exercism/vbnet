Public Class SublistTests
    <Fact>
    Public Sub Empty_lists()
        Dim list1 = New List(Of Integer)()
        Dim list2 = New List(Of Integer)()
        Assert.Equal(SublistType.Equal, Sublist.Classify(list1, list2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Empty_list_within_non_empty_list()
        Dim list1 = New List(Of Integer)()
        Dim list2 = {1, 2, 3}.ToList()
        Assert.Equal(SublistType.Sublist, Sublist.Classify(list1, list2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Non_empty_list_contains_empty_list()
        Dim list1 = {1, 2, 3}.ToList()
        Dim list2 = New List(Of Integer)()
        Assert.Equal(SublistType.Superlist, Sublist.Classify(list1, list2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub List_equals_itself()
        Dim list1 = {1, 2, 3}.ToList()
        Dim list2 = {1, 2, 3}.ToList()
        Assert.Equal(SublistType.Equal, Sublist.Classify(list1, list2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Different_lists()
        Dim list1 = {1, 2, 3}.ToList()
        Dim list2 = {2, 3, 4}.ToList()
        Assert.Equal(SublistType.Unequal, Sublist.Classify(list1, list2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub False_start()
        Dim list1 = {1, 2, 5}.ToList()
        Dim list2 = {0, 1, 2, 3, 1, 2, 5, 6}.ToList()
        Assert.Equal(SublistType.Sublist, Sublist.Classify(list1, list2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Consecutive()
        Dim list1 = {1, 1, 2}.ToList()
        Dim list2 = {0, 1, 1, 1, 2, 1, 2}.ToList()
        Assert.Equal(SublistType.Sublist, Sublist.Classify(list1, list2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sublist_at_start()
        Dim list1 = {0, 1, 2}.ToList()
        Dim list2 = {0, 1, 2, 3, 4, 5}.ToList()
        Assert.Equal(SublistType.Sublist, Sublist.Classify(list1, list2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sublist_in_middle()
        Dim list1 = {2, 3, 4}.ToList()
        Dim list2 = {0, 1, 2, 3, 4, 5}.ToList()
        Assert.Equal(SublistType.Sublist, Sublist.Classify(list1, list2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sublist_at_end()
        Dim list1 = {3, 4, 5}.ToList()
        Dim list2 = {0, 1, 2, 3, 4, 5}.ToList()
        Assert.Equal(SublistType.Sublist, Sublist.Classify(list1, list2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub At_start_of_superlist()
        Dim list1 = {0, 1, 2, 3, 4, 5}.ToList()
        Dim list2 = {0, 1, 2}.ToList()
        Assert.Equal(SublistType.Superlist, Sublist.Classify(list1, list2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub In_middle_of_superlist()
        Dim list1 = {0, 1, 2, 3, 4, 5}.ToList()
        Dim list2 = {2, 3}.ToList()
        Assert.Equal(SublistType.Superlist, Sublist.Classify(list1, list2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub At_end_of_superlist()
        Dim list1 = {0, 1, 2, 3, 4, 5}.ToList()
        Dim list2 = {3, 4, 5}.ToList()
        Assert.Equal(SublistType.Superlist, Sublist.Classify(list1, list2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub First_list_missing_element_from_second_list()
        Dim list1 = {1, 3}.ToList()
        Dim list2 = {1, 2, 3}.ToList()
        Assert.Equal(SublistType.Unequal, Sublist.Classify(list1, list2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Second_list_missing_element_from_first_list()
        Dim list1 = {1, 2, 3}.ToList()
        Dim list2 = {1, 3}.ToList()
        Assert.Equal(SublistType.Unequal, Sublist.Classify(list1, list2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub First_list_missing_additional_digits_from_second_list()
        Dim list1 = {1, 2}.ToList()
        Dim list2 = {1, 22}.ToList()
        Assert.Equal(SublistType.Unequal, Sublist.Classify(list1, list2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Order_matters_to_a_list()
        Dim list1 = {1, 2, 3}.ToList()
        Dim list2 = {3, 2, 1}.ToList()
        Assert.Equal(SublistType.Unequal, Sublist.Classify(list1, list2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Same_digits_but_different_numbers()
        Dim list1 = {1, 0, 1}.ToList()
        Dim list2 = {10, 1}.ToList()
        Assert.Equal(SublistType.Unequal, Sublist.Classify(list1, list2))
    End Sub
End Class
