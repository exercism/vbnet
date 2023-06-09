Imports System
Imports Xunit

Public Class CircularBufferTests
    <Fact>
    Public Sub Reading_empty_buffer_should_fail()
        Dim buffer = New CircularBuffer(Of Integer)(capacity:=1)
        Assert.Throws(Of InvalidOperationException)(Function() buffer.Read())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_read_an_item_just_written()
        Dim buffer = New CircularBuffer(Of Integer)(capacity:=1)
        buffer.Write(1)
        Assert.Equal(1, buffer.Read())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Each_item_may_only_be_read_once()
        Dim buffer = New CircularBuffer(Of Integer)(capacity:=1)
        buffer.Write(1)
        Assert.Equal(1, buffer.Read())
        Assert.Throws(Of InvalidOperationException)(Function() buffer.Read())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Items_are_read_in_the_order_they_are_written()
        Dim buffer = New CircularBuffer(Of Integer)(capacity:=2)
        buffer.Write(1)
        buffer.Write(2)
        Assert.Equal(1, buffer.Read())
        Assert.Equal(2, buffer.Read())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Full_buffer_cant_be_written_to()
        Dim buffer = New CircularBuffer(Of Integer)(capacity:=1)
        buffer.Write(1)
        Assert.Throws(Of InvalidOperationException)(Sub() buffer.Write(2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_read_frees_up_capacity_for_another_write()
        Dim buffer = New CircularBuffer(Of Integer)(capacity:=1)
        buffer.Write(1)
        Assert.Equal(1, buffer.Read())
        buffer.Write(2)
        Assert.Equal(2, buffer.Read())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Read_position_is_maintained_even_across_multiple_writes()
        Dim buffer = New CircularBuffer(Of Integer)(capacity:=3)
        buffer.Write(1)
        buffer.Write(2)
        Assert.Equal(1, buffer.Read())
        buffer.Write(3)
        Assert.Equal(2, buffer.Read())
        Assert.Equal(3, buffer.Read())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Items_cleared_out_of_buffer_cant_be_read()
        Dim buffer = New CircularBuffer(Of Integer)(capacity:=3)
        buffer.Write(1)
        buffer.Write(2)
        buffer.Clear()
        Assert.Throws(Of InvalidOperationException)(Function() buffer.Read())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Clear_frees_up_capacity_for_another_write()
        Dim buffer = New CircularBuffer(Of Integer)(capacity:=1)
        buffer.Write(1)
        buffer.Clear()
        buffer.Write(2)
        Assert.Equal(2, buffer.Read())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Clear_does_nothing_on_empty_buffer()
        Dim buffer = New CircularBuffer(Of Integer)(capacity:=1)
        buffer.Clear()
        buffer.Write(1)
        Assert.Equal(1, buffer.Read())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Overwrite_acts_like_write_on_non_full_buffer()
        Dim buffer = New CircularBuffer(Of Integer)(capacity:=2)
        buffer.Write(1)
        buffer.Overwrite(2)
        Assert.Equal(1, buffer.Read())
        Assert.Equal(2, buffer.Read())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Overwrite_replaces_the_oldest_item_on_full_buffer()
        Dim buffer = New CircularBuffer(Of Integer)(capacity:=2)
        buffer.Write(1)
        buffer.Write(2)
        buffer.Overwrite(3)
        Assert.Equal(2, buffer.Read())
        Assert.Equal(3, buffer.Read())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Overwrite_replaces_the_oldest_item_remaining_in_buffer_following_a_read()
        Dim buffer = New CircularBuffer(Of Integer)(capacity:=3)
        buffer.Write(1)
        buffer.Write(2)
        buffer.Write(3)
        Assert.Equal(1, buffer.Read())
        buffer.Write(4)
        buffer.Overwrite(5)
        Assert.Equal(3, buffer.Read())
        Assert.Equal(4, buffer.Read())
        Assert.Equal(5, buffer.Read())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Initial_clear_does_not_affect_wrapping_around()
        Dim buffer = New CircularBuffer(Of Integer)(capacity:=2)
        buffer.Clear()
        buffer.Write(1)
        buffer.Write(2)
        buffer.Overwrite(3)
        buffer.Overwrite(4)
        Assert.Equal(3, buffer.Read())
        Assert.Equal(4, buffer.Read())
        Assert.Throws(Of InvalidOperationException)(Function() buffer.Read())
    End Sub
End Class
