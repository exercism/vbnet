Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Linq

Public Class Reactor
    Private ReadOnly cells As Dictionary(Of Integer, Cell) = New Dictionary(Of Integer, Cell)()

    Public Function CreateInputCell(ByVal value As Integer) As InputCell
        Dim inputCell = New InputCell(cells.Count, value)
        AddHandler inputCell.Changed, AddressOf CellChanged

        cells(inputCell.Id) = inputCell

        Return inputCell
    End Function

    Public Function CreateComputeCell(ByVal producers As IEnumerable(Of Cell), ByVal compute As Func(Of Integer(), Integer)) As ComputeCell
        Dim computeCell = New ComputeCell(cells.Count, producers, compute)
        cells(computeCell.Id) = computeCell

        Return computeCell
    End Function

    Private Sub CellChanged(ByVal sender As Object, ByVal value As Integer)
        Dim cell = CType(sender, Cell)
        Dim consumers = New BitArray(cells.Count)

        For Each consumer In cell.Consumers
            consumers.Set(consumer.Id, True)
        Next

        For id = cell.Id + 1 To cells.Count - 1
            If Not consumers.Get(id) Then Continue For

            Dim consumer = CType(cells(id), ComputeCell)
            consumer.Recompute()

            For Each transitiveConsumer In consumer.Consumers
                consumers.Set(transitiveConsumer.Id, True)
            Next
        Next
    End Sub
End Class

Public MustInherit Class Cell
    Public Sub New(ByVal id As Integer)
        Me.Id = id
        Consumers = New List(Of Cell)()
    End Sub

    Public ReadOnly Property Id As Integer
    Public ReadOnly Property Consumers As List(Of Cell)

    Public MustOverride Property Value As Integer
    Public MustOverride Event Changed As EventHandler(Of Integer)
End Class

Public Class InputCell
    Inherits Cell
    Private _value As Integer

    Public Sub New(ByVal id As Integer, ByVal value As Integer)
        MyBase.New(id)
        _value = value
    End Sub

    Public Overrides Event Changed As EventHandler(Of Integer)

    Public Overrides Property Value As Integer
        Get
            Return _value
        End Get
        Set(ByVal value As Integer)
            If _value = value Then Return

            _value = value
            RaiseEvent Changed(Me, _value)
        End Set
    End Property
End Class

Public Class ComputeCell
    Inherits Cell
    Private ReadOnly producers As IEnumerable(Of Cell)
    Private ReadOnly compute As Func(Of Integer(), Integer)

    Public Sub New(ByVal id As Integer, ByVal producers As IEnumerable(Of Cell), ByVal compute As Func(Of Integer(), Integer))
        MyBase.New(id)
        Me.producers = producers
        Me.compute = compute

        For Each producer In producers
            producer.Consumers.Add(Me)
        Next

        Recompute()
    End Sub

    Public Overrides Property Value As Integer
    Public Overrides Event Changed As EventHandler(Of Integer)

    Public Sub Recompute()
        Dim updatedValue = compute(producers.[Select](Function(producer) producer.Value).ToArray())

        If updatedValue = Value Then Return

        Value = updatedValue
        RaiseEvent Changed(Me, updatedValue)
    End Sub
End Class
