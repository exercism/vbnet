Public Class SimpleLinkedListTests
    <Fact>
    Public Sub Empty_list_has_length_of_zero()
        Dim list = New SimpleLinkedList(Of Integer)()
        Assert.Equal(0, list.Count)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Singleton_list_has_length_of_one()
        Dim list = New SimpleLinkedList(Of Integer)(1)
        Assert.Equal(1, list.Count)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Non_empty_list_has_correct_length()
        Dim list = New SimpleLinkedList(Of Integer)(1, 2, 3)
        Assert.Equal(3, list.Count)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Pop_from_empty_list_is_an_error()
        Dim list = New SimpleLinkedList(Of Integer)()
        Assert.Throws(Of InvalidOperationException)(Function() list.Pop())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_pop_from_singleton_list()
        Dim list = New SimpleLinkedList(Of Integer)(1)
        Assert.Equal(1, list.Pop())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_pop_from_non_empty_list()
        Dim list = New SimpleLinkedList(Of Integer)(1, 2)
        Assert.Equal(2, list.Pop())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_pop_multiple_items()
        Dim list = New SimpleLinkedList(Of Integer)(1, 2)
        Assert.Equal(2, list.Pop())
        Assert.Equal(1, list.Pop())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Pop_updates_the_count()
        Dim list = New SimpleLinkedList(Of Integer)(1, 2)
        Assert.Equal(2, list.Count)
        Assert.Equal(2, list.Pop())
        Assert.Equal(1, list.Count)
        Assert.Equal(1, list.Pop())
        Assert.Equal(0, list.Count)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_push_to_an_empty_list()
        Dim list = New SimpleLinkedList(Of Integer)()
        list.Push(1)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_push_to_a_non_empty_list()
        Dim list = New SimpleLinkedList(Of Integer)(1, 2)
        list.Push(3)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Push_updates_count()
        Dim list = New SimpleLinkedList(Of Integer)(1, 2)
        list.Push(3)
        Assert.Equal(3, list.Count)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Push_and_pop()
        Dim list = New SimpleLinkedList(Of Integer)()
        list.Push(1)
        list.Push(2)
        Assert.Equal(2, list.Pop())
        list.Push(3)
        Assert.Equal(2, list.Count)
        Assert.Equal(3, list.Pop())
        Assert.Equal(1, list.Pop())
        Assert.Equal(0, list.Count)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Peek_on_empty_list_is_an_error()
        Dim list = New SimpleLinkedList(Of Integer)()
        Assert.Throws(Of InvalidOperationException)(Function() list.Peek())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_peek_on_singleton_list()
        Dim list = New SimpleLinkedList(Of Integer)(1)
        Assert.Equal(1, list.Peek())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_peek_on_non_empty_list()
        Dim list = New SimpleLinkedList(Of Integer)(1, 2)
        Assert.Equal(2, list.Peek())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Peek_does_not_change_the_count()
        Dim list = New SimpleLinkedList(Of Integer)(1, 2)
        Assert.Equal(2, list.Peek())
        Assert.Equal(2, list.Count)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_peek_after_a_pop_and_push()
        Dim list = New SimpleLinkedList(Of Integer)()
        list.Push(1)
        list.Push(2)
        Assert.Equal(2, list.Peek())
        Assert.Equal(2, list.Pop())
        Assert.Equal(1, list.Peek())
        list.Push(3)
        Assert.Equal(3, list.Peek())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Empty_linked_list_to_list_is_empty()
        Dim list = New SimpleLinkedList(Of Integer)()
        Assert.Empty(list.ToList())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub To_list_with_multiple_values()
        Dim list = New SimpleLinkedList(Of Integer)(1, 2, 3)
        Assert.Equal({3, 2, 1}, list.ToList())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub To_list_after_a_pop()
        Dim list = New SimpleLinkedList(Of Integer)()
        list.Push(1)
        list.Push(2)
        list.Push(3)
        Assert.Equal(3, list.Pop())
        list.Push(4)
        Assert.Equal({4, 2, 1}, list.ToList())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reversed_empty_list_has_same_values()
        Dim list = New SimpleLinkedList(Of Integer)()
        list.Reverse()
        Assert.Empty(list.ToList())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reversed_singleton_list_is_same_list()
        Dim list = New SimpleLinkedList(Of Integer)(1)
        list.Reverse()
        Assert.Equal({1}, list.ToList())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reversed_non_empty_list_is_reversed()
        Dim list = New SimpleLinkedList(Of Integer)(1, 2, 3)
        list.Reverse()
        Assert.Equal(3, list.Count)
        Assert.Equal(1, list.Pop())
        Assert.Equal(2, list.Pop())
        Assert.Equal(3, list.Pop())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Double_reverse()
        Dim list = New SimpleLinkedList(Of Integer)(1, 2, 3)
        list.Reverse()
        list.Reverse()
        Assert.Equal(3, list.Pop())
        Assert.Equal(2, list.Pop())
        Assert.Equal(1, list.Pop())
    End Sub
End Class
