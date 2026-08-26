Public Class DequeTests
    <Fact>
    Public Sub Pop_gets_element_from_the_list()
        Dim deque = New Deque(Of Integer)()
        deque.Push(7)
        Assert.Equal(7, deque.Pop())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Push_pop_respectively_add_remove_at_the_end_of_the_list()
        Dim deque = New Deque(Of Integer)()
        deque.Push(11)
        deque.Push(13)
        Assert.Equal(13, deque.Pop())
        Assert.Equal(11, deque.Pop())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Shift_gets_an_element_from_the_list()
        Dim deque = New Deque(Of Integer)()
        deque.Push(17)
        Assert.Equal(17, deque.Shift())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Shift_gets_first_element_from_the_list()
        Dim deque = New Deque(Of Integer)()
        deque.Push(23)
        deque.Push(5)
        Assert.Equal(23, deque.Shift())
        Assert.Equal(5, deque.Shift())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Unshift_adds_element_at_start_of_the_list()
        Dim deque = New Deque(Of Integer)()
        deque.Unshift(23)
        deque.Unshift(5)
        Assert.Equal(5, deque.Shift())
        Assert.Equal(23, deque.Shift())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Pop_push_shift_and_unshift_can_be_used_in_any_order()
        Dim deque = New Deque(Of Integer)()
        deque.Push(1)
        deque.Push(2)
        Assert.Equal(2, deque.Pop())
        deque.Push(3)
        Assert.Equal(1, deque.Shift())
        deque.Unshift(4)
        deque.Push(5)
        Assert.Equal(4, deque.Shift())
        Assert.Equal(5, deque.Pop())
        Assert.Equal(3, deque.Shift())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Count_an_empty_list()
        Dim deque = New Deque(Of Integer)()
        Assert.Equal(0, deque.Count)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Count_a_list_with_items()
        Dim deque = New Deque(Of Integer)()
        deque.Push(37)
        deque.Push(1)
        Assert.Equal(2, deque.Count)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Count_is_correct_after_mutation()
        Dim deque = New Deque(Of Integer)()
        deque.Push(31)
        Assert.Equal(1, deque.Count)
        deque.Unshift(43)
        Assert.Equal(2, deque.Count)
        deque.Shift()
        Assert.Equal(1, deque.Count)
        deque.Pop()
        Assert.Equal(0, deque.Count)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Popping_to_empty_does_not_break_the_list()
        Dim deque = New Deque(Of Integer)()
        deque.Push(41)
        deque.Push(59)
        deque.Pop()
        deque.Pop()
        deque.Push(47)
        Assert.Equal(1, deque.Count)
        Assert.Equal(47, deque.Pop())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Shifting_to_empty_does_not_break_the_list()
        Dim deque = New Deque(Of Integer)()
        deque.Push(41)
        deque.Push(59)
        deque.Shift()
        deque.Shift()
        deque.Push(47)
        Assert.Equal(1, deque.Count)
        Assert.Equal(47, deque.Shift())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Deletes_the_only_element()
        Dim deque = New Deque(Of Integer)()
        deque.Push(61)
        deque.Delete(61)
        Assert.Equal(0, deque.Count)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Deletes_the_element_with_the_specified_value_from_the_list()
        Dim deque = New Deque(Of Integer)()
        deque.Push(71)
        deque.Push(83)
        deque.Push(79)
        deque.Delete(83)
        Assert.Equal(2, deque.Count)
        Assert.Equal(79, deque.Pop())
        Assert.Equal(71, deque.Shift())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Deletes_the_element_with_the_specified_value_from_the_list_reassigns_tail()
        Dim deque = New Deque(Of Integer)()
        deque.Push(71)
        deque.Push(83)
        deque.Push(79)
        deque.Delete(83)
        Assert.Equal(2, deque.Count)
        Assert.Equal(79, deque.Pop())
        Assert.Equal(71, deque.Pop())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Deletes_the_element_with_the_specified_value_from_the_list_reassigns_head()
        Dim deque = New Deque(Of Integer)()
        deque.Push(71)
        deque.Push(83)
        deque.Push(79)
        deque.Delete(83)
        Assert.Equal(2, deque.Count)
        Assert.Equal(71, deque.Shift())
        Assert.Equal(79, deque.Shift())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Deletes_the_first_of_two_elements()
        Dim deque = New Deque(Of Integer)()
        deque.Push(97)
        deque.Push(101)
        deque.Delete(97)
        Assert.Equal(1, deque.Count)
        Assert.Equal(101, deque.Pop())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Deletes_the_second_of_two_elements()
        Dim deque = New Deque(Of Integer)()
        deque.Push(97)
        deque.Push(101)
        deque.Delete(101)
        Assert.Equal(1, deque.Count)
        Assert.Equal(97, deque.Pop())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Delete_does_not_modify_the_list_if_the_element_is_not_found()
        Dim deque = New Deque(Of Integer)()
        deque.Push(89)
        deque.Delete(103)
        Assert.Equal(1, deque.Count)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Deletes_only_the_first_occurrence()
        Dim deque = New Deque(Of Integer)()
        deque.Push(73)
        deque.Push(9)
        deque.Push(9)
        deque.Push(107)
        deque.Delete(9)
        Assert.Equal(3, deque.Count)
        Assert.Equal(107, deque.Pop())
        Assert.Equal(9, deque.Pop())
        Assert.Equal(73, deque.Pop())
    End Sub
End Class
