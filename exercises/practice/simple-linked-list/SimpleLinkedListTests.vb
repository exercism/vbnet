Imports System
Imports System.Linq
Imports System.Collections.Generic
Imports Xunit

Public Class SimpleLinkedListTests
    <Fact>
    Public Sub Empty_list_has_no_elements()
        Dim list = New SimpleLinkedList(Of Integer)()
        Assert.Equal(0, list.Count)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Count_cannot_be_changed_from_the_outside()
        Dim count = GetType(SimpleLinkedList(Of)).GetProperty("Count")
        Assert.True(count?.GetGetMethod().IsPublic)
        Assert.False(count?.GetSetMethod(True).IsPublic)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Pushing_elements_to_the_list_increases_the_count()
        Dim list = New SimpleLinkedList(Of Integer)()
        list.Push(0)
        Assert.Equal(1, list.Count)
        list.Push(0)
        Assert.Equal(2, list.Count)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Popping_elements_from_the_list_decreases_the_count()
        Dim list = New SimpleLinkedList(Of Integer)()
        list.Push(0)
        list.Push(0)
        Assert.Equal(2, list.Count)
        list.Pop()
        Assert.Equal(1, list.Count)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Elements_pop_back_in_lifo_order()
        Dim list = New SimpleLinkedList(Of Integer)()
        list.Push(3)
        list.Push(5)
        Assert.Equal(5, list.Pop())
        list.Push(7)
        Assert.Equal(7, list.Pop())
        Assert.Equal(3, list.Pop())
    End Sub

    Private Shared Function CreateSimpleLinkedList(ByVal value As Integer) As SimpleLinkedList(Of Integer)
        Dim type = GetType(SimpleLinkedList(Of)).MakeGenericType(GetType(Integer))
        Dim constructor = type.GetConstructor(New Type() {GetType(Integer)})
        Return If(CType(constructor?.Invoke(New Object() {value}), SimpleLinkedList(Of Integer)), CreateSimpleLinkedList(New Integer() {value}))
    End Function

    Private Shared Function CreateSimpleLinkedList(ParamArray values As Integer()) As SimpleLinkedList(Of Integer)
        Dim type = GetType(SimpleLinkedList(Of)).MakeGenericType(GetType(Integer))
        Dim constructor = type.GetConstructor(New Type() {GetType(Integer())})
        Return CType(constructor.Invoke(New Object() {values}), SimpleLinkedList(Of Integer))
    End Function

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Single_value_initialisation()
        Dim list = CreateSimpleLinkedList(7)
        Assert.Equal(1, list.Count)
        Assert.Equal(7, list.Pop())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multi_value_initialisation()
        Dim list = CreateSimpleLinkedList(2, 1, 3)
        Assert.Equal(3, list.Pop())
        Assert.Equal(1, list.Pop())
        Assert.Equal(2, list.Pop())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub From_enumerable()
        Dim list = CreateSimpleLinkedList({11, 7, 5, 3, 2})
        Assert.Equal(2, list.Pop())
        Assert.Equal(3, list.Pop())
        Assert.Equal(5, list.Pop())
        Assert.Equal(7, list.Pop())
        Assert.Equal(11, list.Pop())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reverse_enumerable()
        Dim values = Linq.Enumerable.Range(1, 5).ToArray()
        Dim list = CreateSimpleLinkedList(values)
        Dim enumerable = Assert.IsAssignableFrom(Of IEnumerable(Of Integer))(list)
        Dim reversed = enumerable.Reverse()
        Assert.Equal(values, reversed)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Roundtrip()
        Dim values = Linq.Enumerable.Range(1, 7)
        Dim list = CreateSimpleLinkedList(values.ToArray())
        Dim enumerable = Assert.IsAssignableFrom(Of IEnumerable(Of Integer))(list)
        Assert.Equal(values.Reverse(), enumerable)
    End Sub
End Class
