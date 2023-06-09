Imports Xunit

Public Class DequeTests
    <Fact>
    Public Sub Push_and_pop_are_first_in_last_out_order()
        Dim deque = New Deque(Of Integer)()
        deque.Push(10)
        deque.Push(20)
        Assert.Equal(20, deque.Pop())
        Assert.Equal(10, deque.Pop())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Push_and_shift_are_first_in_first_out_order()
        Dim deque = New Deque(Of Integer)()
        deque.Push(10)
        deque.Push(20)
        Assert.Equal(10, deque.Shift())
        Assert.Equal(20, deque.Shift())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Unshift_and_shift_are_last_in_first_out_order()
        Dim deque = New Deque(Of Integer)()
        deque.Unshift(10)
        deque.Unshift(20)
        Assert.Equal(20, deque.Shift())
        Assert.Equal(10, deque.Shift())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Unshift_and_pop_are_last_in_last_out_order()
        Dim deque = New Deque(Of Integer)()
        deque.Unshift(10)
        deque.Unshift(20)
        Assert.Equal(10, deque.Pop())
        Assert.Equal(20, deque.Pop())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Push_and_pop_can_handle_multiple_values()
        Dim deque = New Deque(Of Integer)()
        deque.Push(10)
        deque.Push(20)
        deque.Push(30)
        Assert.Equal(30, deque.Pop())
        Assert.Equal(20, deque.Pop())
        Assert.Equal(10, deque.Pop())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Unshift_and_shift_can_handle_multiple_values()
        Dim deque = New Deque(Of Integer)()
        deque.Unshift(10)
        deque.Unshift(20)
        deque.Unshift(30)
        Assert.Equal(30, deque.Shift())
        Assert.Equal(20, deque.Shift())
        Assert.Equal(10, deque.Shift())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub All_methods_of_manipulating_the_deque_can_be_used_together()
        Dim deque = New Deque(Of Integer)()
        deque.Push(10)
        deque.Push(20)
        Assert.Equal(20, deque.Pop())

        deque.Push(30)
        Assert.Equal(10, deque.Shift())

        deque.Unshift(40)
        deque.Push(50)
        Assert.Equal(40, deque.Shift())
        Assert.Equal(50, deque.Pop())
        Assert.Equal(30, deque.Shift())
    End Sub
End Class
