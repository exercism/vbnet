Public Class LinkedListTests
    <Fact>
    Public Sub Pop_gets_element_from_the_list()
        Dim sut = New Deque(Of Integer)()
        sut.Push(7)
        Assert.Equal(7, sut.Pop())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Push_pop_respectively_add_remove_at_the_end_of_the_list()
        Dim sut = New Deque(Of Integer)()
        sut.Push(11)
        sut.Push(13)
        Assert.Equal(13, sut.Pop())
        Assert.Equal(11, sut.Pop())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Shift_gets_an_element_from_the_list()
        Dim sut = New Deque(Of Integer)()
        sut.Push(17)
        Assert.Equal(17, sut.Shift())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Shift_gets_first_element_from_the_list()
        Dim sut = New Deque(Of Integer)()
        sut.Push(23)
        sut.Push(5)
        Assert.Equal(23, sut.Shift())
        Assert.Equal(5, sut.Shift())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Unshift_adds_element_at_start_of_the_list()
        Dim sut = New Deque(Of Integer)()
        sut.Unshift(23)
        sut.Unshift(5)
        Assert.Equal(5, sut.Shift())
        Assert.Equal(23, sut.Shift())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Pop_push_shift_and_unshift_can_be_used_in_any_order()
        Dim sut = New Deque(Of Integer)()
        sut.Push(1)
        sut.Push(2)
        Assert.Equal(2, sut.Pop())
        sut.Push(3)
        Assert.Equal(1, sut.Shift())
        sut.Unshift(4)
        sut.Push(5)
        Assert.Equal(4, sut.Shift())
        Assert.Equal(5, sut.Pop())
        Assert.Equal(3, sut.Shift())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Count_an_empty_list()
        Dim sut = New Deque(Of Integer)()
        Assert.Equal(0, sut.Count)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Count_a_list_with_items()
        Dim sut = New Deque(Of Integer)()
        sut.Push(37)
        sut.Push(1)
        Assert.Equal(2, sut.Count)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Count_is_correct_after_mutation()
        Dim sut = New Deque(Of Integer)()
        sut.Push(31)
        Assert.Equal(1, sut.Count)
        sut.Unshift(43)
        Assert.Equal(2, sut.Count)
        sut.Shift()
        Assert.Equal(1, sut.Count)
        sut.Pop()
        Assert.Equal(0, sut.Count)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Popping_to_empty_doesn_t_break_the_list()
        Dim sut = New Deque(Of Integer)()
        sut.Push(41)
        sut.Push(59)
        sut.Pop()
        sut.Pop()
        sut.Push(47)
        Assert.Equal(1, sut.Count)
        Assert.Equal(47, sut.Pop())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Shifting_to_empty_doesn_t_break_the_list()
        Dim sut = New Deque(Of Integer)()
        sut.Push(41)
        sut.Push(59)
        sut.Shift()
        sut.Shift()
        sut.Push(47)
        Assert.Equal(1, sut.Count)
        Assert.Equal(47, sut.Shift())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Deletes_the_only_element()
        Dim sut = New Deque(Of Integer)()
        sut.Push(61)
        sut.Delete(61)
        Assert.Equal(0, sut.Count)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Deletes_the_element_with_the_specified_value_from_the_list()
        Dim sut = New Deque(Of Integer)()
        sut.Push(71)
        sut.Push(83)
        sut.Push(79)
        sut.Delete(83)
        Assert.Equal(2, sut.Count)
        Assert.Equal(79, sut.Pop())
        Assert.Equal(71, sut.Shift())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Deletes_the_element_with_the_specified_value_from_the_list_re_assigns_tail()
        Dim sut = New Deque(Of Integer)()
        sut.Push(71)
        sut.Push(83)
        sut.Push(79)
        sut.Delete(83)
        Assert.Equal(2, sut.Count)
        Assert.Equal(79, sut.Pop())
        Assert.Equal(71, sut.Pop())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Deletes_the_element_with_the_specified_value_from_the_list_re_assigns_head()
        Dim sut = New Deque(Of Integer)()
        sut.Push(71)
        sut.Push(83)
        sut.Push(79)
        sut.Delete(83)
        Assert.Equal(2, sut.Count)
        Assert.Equal(71, sut.Shift())
        Assert.Equal(79, sut.Shift())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Deletes_the_first_of_two_elements()
        Dim sut = New Deque(Of Integer)()
        sut.Push(97)
        sut.Push(101)
        sut.Delete(97)
        Assert.Equal(1, sut.Count)
        Assert.Equal(101, sut.Pop())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Deletes_the_second_of_two_elements()
        Dim sut = New Deque(Of Integer)()
        sut.Push(97)
        sut.Push(101)
        sut.Delete(101)
        Assert.Equal(1, sut.Count)
        Assert.Equal(97, sut.Pop())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Delete_does_not_modify_the_list_if_the_element_is_not_found()
        Dim sut = New Deque(Of Integer)()
        sut.Push(89)
        sut.Delete(103)
        Assert.Equal(1, sut.Count)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Deletes_only_the_first_occurrence()
        Dim sut = New Deque(Of Integer)()
        sut.Push(73)
        sut.Push(9)
        sut.Push(9)
        sut.Push(107)
        sut.Delete(9)
        Assert.Equal(3, sut.Count)
        Assert.Equal(107, sut.Pop())
        Assert.Equal(9, sut.Pop())
        Assert.Equal(73, sut.Pop())
    End Sub
End Class
