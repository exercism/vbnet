Imports FakeItEasy
Imports System
Imports Xunit

Public Class ReactTests
    <Fact>
    Public Sub Input_cells_have_a_value()
        Dim sut = New Reactor()
        Dim input = sut.CreateInputCell(10)
        Assert.Equal(10, input.Value)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub An_input_cells_value_can_be_set()
        Dim sut = New Reactor()
        Dim input = sut.CreateInputCell(4)
        input.Value = 20
        Assert.Equal(20, input.Value)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Compute_cells_calculate_initial_value()
        Dim sut = New Reactor()
        Dim input = sut.CreateInputCell(1)
        Dim output = sut.CreateComputeCell({input}, Function(inputs) inputs(0) + 1)
        Assert.Equal(2, output.Value)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Compute_cells_take_inputs_in_the_right_order()
        Dim sut = New Reactor()
        Dim one = sut.CreateInputCell(1)
        Dim two = sut.CreateInputCell(2)
        Dim output = sut.CreateComputeCell({one, two}, Function(inputs) inputs(0) + inputs(1) * 10)
        Assert.Equal(21, output.Value)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Compute_cells_update_value_when_dependencies_are_changed()
        Dim sut = New Reactor()
        Dim input = sut.CreateInputCell(1)
        Dim output = sut.CreateComputeCell({input}, Function(inputs) inputs(0) + 1)
        input.Value = 3
        Assert.Equal(4, output.Value)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Compute_cells_can_depend_on_other_compute_cells()
        Dim sut = New Reactor()
        Dim input = sut.CreateInputCell(1)
        Dim timesTwo = sut.CreateComputeCell({input}, Function(inputs) inputs(0) * 2)
        Dim timesThirty = sut.CreateComputeCell({input}, Function(inputs) inputs(0) * 30)
        Dim output = sut.CreateComputeCell({timesTwo, timesThirty}, Function(inputs) inputs(0) + inputs(1))
        Assert.Equal(32, output.Value)
        input.Value = 3
        Assert.Equal(96, output.Value)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Compute_cells_fire_callbacks()
        Dim sut = New Reactor()
        Dim input = sut.CreateInputCell(1)
        Dim output = sut.CreateComputeCell({input}, Function(inputs) inputs(0) + 1)
        Dim callback1 = A.Fake(Of EventHandler(Of Integer))()
        AddHandler output.Changed, callback1
        input.Value = 3
        A.CallTo(CType(Sub() callback1.Invoke(CObj(A(Of Object).__), CInt(4)), Expressions.Expression(Of Action))).MustHaveHappenedOnceExactly()
        Fake.ClearRecordedCalls(callback1)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Callback_cells_only_fire_on_change()
        Dim sut = New Reactor()
        Dim input = sut.CreateInputCell(1)
        Dim output = sut.CreateComputeCell({input}, Function(inputs) If(inputs(0) < 3, 111, 222))
        Dim callback1 = A.Fake(Of EventHandler(Of Integer))()
        AddHandler output.Changed, callback1
        input.Value = 2
        A.CallTo(CType(Sub() callback1.Invoke(CObj(A(Of Object).__), CInt(A(Of Integer).__)), Expressions.Expression(Of Action))).MustNotHaveHappened()
        input.Value = 4
        A.CallTo(CType(Sub() callback1.Invoke(CObj(A(Of Object).__), CInt(222)), Expressions.Expression(Of Action))).MustHaveHappenedOnceExactly()
        Fake.ClearRecordedCalls(callback1)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Callbacks_do_not_report_already_reported_values()
        Dim sut = New Reactor()
        Dim input = sut.CreateInputCell(1)
        Dim output = sut.CreateComputeCell({input}, Function(inputs) inputs(0) + 1)
        Dim callback1 = A.Fake(Of EventHandler(Of Integer))()
        AddHandler output.Changed, callback1
        input.Value = 2
        A.CallTo(CType(Sub() callback1.Invoke(CObj(A(Of Object).__), CInt(3)), Expressions.Expression(Of Action))).MustHaveHappenedOnceExactly()
        Fake.ClearRecordedCalls(callback1)
        input.Value = 3
        A.CallTo(CType(Sub() callback1.Invoke(CObj(A(Of Object).__), CInt(4)), Expressions.Expression(Of Action))).MustHaveHappenedOnceExactly()
        Fake.ClearRecordedCalls(callback1)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Callbacks_can_fire_from_multiple_cells()
        Dim sut = New Reactor()
        Dim input = sut.CreateInputCell(1)
        Dim plusOne = sut.CreateComputeCell({input}, Function(inputs) inputs(0) + 1)
        Dim minusOne = sut.CreateComputeCell({input}, Function(inputs) inputs(0) - 1)
        Dim callback1 = A.Fake(Of EventHandler(Of Integer))()
        AddHandler plusOne.Changed, callback1
        Dim callback2 = A.Fake(Of EventHandler(Of Integer))()
        AddHandler minusOne.Changed, callback2
        input.Value = 10
        A.CallTo(CType(Sub() callback1.Invoke(CObj(A(Of Object).__), CInt(11)), Expressions.Expression(Of Action))).MustHaveHappenedOnceExactly()
        Fake.ClearRecordedCalls(callback1)
        A.CallTo(CType(Sub() callback2.Invoke(CObj(A(Of Object).__), CInt(9)), Expressions.Expression(Of Action))).MustHaveHappenedOnceExactly()
        Fake.ClearRecordedCalls(callback2)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Callbacks_can_be_added_and_removed()
        Dim sut = New Reactor()
        Dim input = sut.CreateInputCell(11)
        Dim output = sut.CreateComputeCell({input}, Function(inputs) inputs(0) + 1)
        Dim callback1 = A.Fake(Of EventHandler(Of Integer))()
        AddHandler output.Changed, callback1
        Dim callback2 = A.Fake(Of EventHandler(Of Integer))()
        AddHandler output.Changed, callback2
        input.Value = 31
        A.CallTo(CType(Sub() callback1.Invoke(CObj(A(Of Object).__), CInt(32)), Expressions.Expression(Of Action))).MustHaveHappenedOnceExactly()
        Fake.ClearRecordedCalls(callback1)
        A.CallTo(CType(Sub() callback2.Invoke(CObj(A(Of Object).__), CInt(32)), Expressions.Expression(Of Action))).MustHaveHappenedOnceExactly()
        Fake.ClearRecordedCalls(callback2)
        RemoveHandler output.Changed, callback1
        Dim callback3 = A.Fake(Of EventHandler(Of Integer))()
        AddHandler output.Changed, callback3
        input.Value = 41
        A.CallTo(CType(Sub() callback1.Invoke(CObj(A(Of Object).__), CInt(A(Of Integer).__)), Expressions.Expression(Of Action))).MustNotHaveHappened()
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Removing_a_callback_multiple_times_doesnt_interfere_with_other_callbacks()
        Dim sut = New Reactor()
        Dim input = sut.CreateInputCell(1)
        Dim output = sut.CreateComputeCell({input}, Function(inputs) inputs(0) + 1)
        Dim callback1 = A.Fake(Of EventHandler(Of Integer))()
        AddHandler output.Changed, callback1
        Dim callback2 = A.Fake(Of EventHandler(Of Integer))()
        AddHandler output.Changed, callback2
        RemoveHandler output.Changed, callback1
        RemoveHandler output.Changed, callback1
        RemoveHandler output.Changed, callback1
        input.Value = 2
        A.CallTo(CType(Sub() callback1.Invoke(CObj(A(Of Object).__), CInt(A(Of Integer).__)), Expressions.Expression(Of Action))).MustNotHaveHappened()
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Callbacks_should_only_be_called_once_even_if_multiple_dependencies_change()
        Dim sut = New Reactor()
        Dim input = sut.CreateInputCell(1)
        Dim plusOne = sut.CreateComputeCell({input}, Function(inputs) inputs(0) + 1)
        Dim minusOne1 = sut.CreateComputeCell({input}, Function(inputs) inputs(0) - 1)
        Dim minusOne2 = sut.CreateComputeCell({minusOne1}, Function(inputs) inputs(0) - 1)
        Dim output = sut.CreateComputeCell({plusOne, minusOne2}, Function(inputs) inputs(0) * inputs(1))
        Dim callback1 = A.Fake(Of EventHandler(Of Integer))()
        AddHandler output.Changed, callback1
        input.Value = 4
        A.CallTo(CType(Sub() callback1.Invoke(CObj(A(Of Object).__), CInt(10)), Expressions.Expression(Of Action))).MustHaveHappenedOnceExactly()
        Fake.ClearRecordedCalls(callback1)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Callbacks_should_not_be_called_if_dependencies_change_but_output_value_doesnt_change()
        Dim sut = New Reactor()
        Dim input = sut.CreateInputCell(1)
        Dim plusOne = sut.CreateComputeCell({input}, Function(inputs) inputs(0) + 1)
        Dim minusOne = sut.CreateComputeCell({input}, Function(inputs) inputs(0) - 1)
        Dim alwaysTwo = sut.CreateComputeCell({plusOne, minusOne}, Function(inputs) inputs(0) - inputs(1))
        Dim callback1 = A.Fake(Of EventHandler(Of Integer))()
        AddHandler alwaysTwo.Changed, callback1
        input.Value = 2
        A.CallTo(CType(Sub() callback1.Invoke(CObj(A(Of Object).__), CInt(A(Of Integer).__)), Expressions.Expression(Of Action))).MustNotHaveHappened()
        input.Value = 3
        A.CallTo(CType(Sub() callback1.Invoke(CObj(A(Of Object).__), CInt(A(Of Integer).__)), Expressions.Expression(Of Action))).MustNotHaveHappened()
        input.Value = 4
        A.CallTo(CType(Sub() callback1.Invoke(CObj(A(Of Object).__), CInt(A(Of Integer).__)), Expressions.Expression(Of Action))).MustNotHaveHappened()
        input.Value = 5
        A.CallTo(CType(Sub() callback1.Invoke(CObj(A(Of Object).__), CInt(A(Of Integer).__)), Expressions.Expression(Of Action))).MustNotHaveHappened()
    End Sub
End Class
