Imports System
Imports System.Collections.Generic
Imports System.Linq

Public Class BinTree
    Implements IEquatable(Of BinTree)
    Public Sub New(ByVal value As Integer, ByVal left As BinTree, ByVal right As BinTree)
        Me.Value = value
        Me.Left = left
        Me.Right = right
    End Sub

    Public Sub New(ByVal tree As BinTree)
        Me.New(tree.Value, tree.Left, tree.Right)
    End Sub

    Public ReadOnly Property Value As Integer
    Public ReadOnly Property Left As BinTree
    Public ReadOnly Property Right As BinTree

    Public Function Equals(ByVal other As BinTree) As Boolean Implements IEquatable(Of BinTree).Equals
        If other Is Nothing OrElse Not Object.Equals(Value, other.Value) Then Return False

        If Not ReferenceEquals(Left, other.Left) AndAlso If(Not Left?.Equals(other.Left), False) Then Return False

        If Not ReferenceEquals(Right, other.Right) AndAlso If(Not Right?.Equals(other.Right), False) Then Return False

        Return True
    End Function
End Class

Public MustInherit Class BinTreeCrumb
    Public Sub New(ByVal value As Integer, ByVal tree As BinTree)
        Me.Value = value
        Me.Tree = tree
    End Sub

    Public ReadOnly Property Value As Integer
    Public ReadOnly Property Tree As BinTree
End Class

Public Class BinTreeLeftCrumb
    Inherits BinTreeCrumb
    Public Sub New(ByVal value As Integer, ByVal tree As BinTree)
        MyBase.New(value, tree)
    End Sub
End Class

Public Class BinTreeRightCrumb
    Inherits BinTreeCrumb
    Public Sub New(ByVal value As Integer, ByVal tree As BinTree)
        MyBase.New(value, tree)
    End Sub
End Class

Public Class Zipper
    Implements IEquatable(Of Zipper)
    Private ReadOnly valueField As Integer
    Private ReadOnly leftField As BinTree
    Private ReadOnly rightField As BinTree
    Private ReadOnly crumbs As List(Of BinTreeCrumb)

    Public Sub New(ByVal value As Integer, ByVal left As BinTree, ByVal right As BinTree, ByVal crumbs As List(Of BinTreeCrumb))
        valueField = value
        leftField = left
        rightField = right
        Me.crumbs = crumbs
    End Sub

    Public Function Value() As Integer
        Return valueField
    End Function

    Public Function SetValue(ByVal newValue As Integer) As Zipper
        Return New Zipper(newValue, leftField, rightField, crumbs)
    End Function

    Public Function SetLeft(ByVal binTree As BinTree) As Zipper
        Return New Zipper(valueField, binTree, rightField, crumbs)
    End Function

    Public Function SetRight(ByVal binTree As BinTree) As Zipper
        Return New Zipper(valueField, leftField, binTree, crumbs)
    End Function

    Public Function Left() As Zipper
        If leftField Is Nothing Then Return Nothing

        Dim newCrumbs = {New BinTreeLeftCrumb(valueField, rightField)}.Concat(crumbs).ToList()
        Return New Zipper(leftField.Value, leftField.Left, leftField.Right, newCrumbs)
    End Function

    Public Function Right() As Zipper
        If rightField Is Nothing Then Return Nothing

        Dim newCrumbs = {New BinTreeRightCrumb(valueField, leftField)}.Concat(crumbs).ToList()
        Return New Zipper(rightField.Value, rightField.Left, rightField.Right, newCrumbs)
    End Function

    Public Function Up() As Zipper
        If crumbs.Count = 0 Then Return Nothing

        Dim firstCrumb = crumbs(0)
        Dim remainingCrumbs = crumbs.Skip(1).ToList()

        If TypeOf firstCrumb Is BinTreeLeftCrumb Then Return New Zipper(firstCrumb.Value, New BinTree(valueField, leftField, rightField), firstCrumb.Tree, remainingCrumbs)

        If TypeOf firstCrumb Is BinTreeRightCrumb Then Return New Zipper(firstCrumb.Value, firstCrumb.Tree, New BinTree(valueField, leftField, rightField), remainingCrumbs)

        Return Nothing
    End Function

    Public Function ToTree() As BinTree
        Dim tree = New BinTree(valueField, leftField, rightField)

        For Each crumb In crumbs
            If TypeOf crumb Is BinTreeLeftCrumb Then tree = New BinTree(crumb.Value, New BinTree(tree), crumb.Tree)
            If TypeOf crumb Is BinTreeRightCrumb Then tree = New BinTree(crumb.Value, crumb.Tree, New BinTree(tree))
        Next

        Return tree
    End Function

    Public Function Equals(ByVal other As Zipper) As Boolean Implements IEquatable(Of Zipper).Equals
        If other Is Nothing Then Return False

        Return ToTree().Equals(other.ToTree())
    End Function

    Public Shared Function FromTree(ByVal tree As BinTree) As Zipper
        Return New Zipper(tree.Value, tree.Left, tree.Right, New List(Of BinTreeCrumb)())
    End Function
End Class
