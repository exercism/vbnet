Imports System
Imports System.Collections.Generic
Imports System.Linq

Public Class BinTree
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

    Public Overrides Function Equals(other As Object) As Boolean
        If other Is Nothing OrElse TypeOf other IsNot BinTree Then Return False
        other = CType(other, BinTree)
        Return GetHashCode() = other.GetHashCode()
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return HashCode.Combine(Value, Left, Right)
    End Function
End Class

Public MustInherit Class BinTreeCrumb
    Public Sub New(value As Integer, tree As BinTree)
        Me.Value = value
        Me.Tree = tree
    End Sub

    Public ReadOnly Property Value As Integer
    Public ReadOnly Property Tree As BinTree
End Class

Public Class BinTreeLeftCrumb
    Inherits BinTreeCrumb
    Public Sub New(value As Integer, tree As BinTree)
        MyBase.New(value, tree)
    End Sub
End Class

Public Class BinTreeRightCrumb
    Inherits BinTreeCrumb
    Public Sub New(value As Integer, tree As BinTree)
        MyBase.New(value, tree)
    End Sub
End Class

Public Class Zipper
    Private ReadOnly valueField As Integer
    Private ReadOnly leftField As BinTree
    Private ReadOnly rightField As BinTree
    Private ReadOnly crumbs As List(Of BinTreeCrumb)

    Public Sub New(value As Integer, left As BinTree, right As BinTree, crumbs As List(Of BinTreeCrumb))
        valueField = value
        leftField = left
        rightField = right
        Me.crumbs = crumbs
    End Sub

    Public Function Value() As Integer
        Return valueField
    End Function

    Public Function SetValue(newValue As Integer) As Zipper
        Return New Zipper(newValue, leftField, rightField, crumbs)
    End Function

    Public Function SetLeft(binTree As BinTree) As Zipper
        Return New Zipper(valueField, binTree, rightField, crumbs)
    End Function

    Public Function SetRight(binTree As BinTree) As Zipper
        Return New Zipper(valueField, leftField, binTree, crumbs)
    End Function

    Public Function Left() As Zipper
        If leftField Is Nothing Then Return Nothing
        Dim newCrumbs As New List(Of BinTreeCrumb) From {
            New BinTreeLeftCrumb(valueField, rightField)
        }
        newCrumbs = newCrumbs.Concat(crumbs).ToList()
        Return New Zipper(leftField.Value, leftField.Left, leftField.Right, newCrumbs)
    End Function

    Public Function Right() As Zipper
        If rightField Is Nothing Then Return Nothing
        Dim newCrumbs As New List(Of BinTreeCrumb) From {
            New BinTreeRightCrumb(valueField, leftField)
        }
        newCrumbs = newCrumbs.Concat(crumbs).ToList()
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

    Public Overrides Function Equals(other As Object) As Boolean
        If other Is Nothing OrElse TypeOf other IsNot Zipper Then Return False
        other = CType(other, Zipper)
        Return ToTree().Equals(other.ToTree())
    End Function

    Public Shared Function FromTree(tree As BinTree) As Zipper
        Return New Zipper(tree.Value, tree.Left, tree.Right, New List(Of BinTreeCrumb)())
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return HashCode.Combine(valueField, leftField, rightField, crumbs)
    End Function
End Class
