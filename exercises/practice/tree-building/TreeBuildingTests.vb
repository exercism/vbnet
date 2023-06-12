Imports System
Imports Xunit

Public Class TreeBuildingTests
    <Fact>
    Public Sub One_node()
        Dim records = {New TreeBuildingRecord With {
.RecordId = 0,
.ParentId = 0
}}

        Dim tree = BuildTree(records)

        AssertTreeIsLeaf(tree, id:=0)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Three_nodes_in_order()
        Dim records = {New TreeBuildingRecord With {
.RecordId = 0,
.ParentId = 0
}, New TreeBuildingRecord With {
.RecordId = 1,
.ParentId = 0
}, New TreeBuildingRecord With {
.RecordId = 2,
.ParentId = 0
}}

        Dim tree = BuildTree(records)

        AssertTreeIsBranch(tree, id:=0, childCount:=2)
        AssertTreeIsLeaf(tree.Children(0), id:=1)
        AssertTreeIsLeaf(tree.Children(1), id:=2)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Three_nodes_in_reverse_order()
        Dim records = {New TreeBuildingRecord With {
.RecordId = 2,
.ParentId = 0
}, New TreeBuildingRecord With {
.RecordId = 1,
.ParentId = 0
}, New TreeBuildingRecord With {
.RecordId = 0,
.ParentId = 0
}}

        Dim tree = BuildTree(records)

        AssertTreeIsBranch(tree, id:=0, childCount:=2)
        AssertTreeIsLeaf(tree.Children(0), id:=1)
        AssertTreeIsLeaf(tree.Children(1), id:=2)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub More_than_two_children()
        Dim records = {New TreeBuildingRecord With {
.RecordId = 3,
.ParentId = 0
}, New TreeBuildingRecord With {
.RecordId = 2,
.ParentId = 0
}, New TreeBuildingRecord With {
.RecordId = 1,
.ParentId = 0
}, New TreeBuildingRecord With {
.RecordId = 0,
.ParentId = 0
}}

        Dim tree = BuildTree(records)

        AssertTreeIsBranch(tree, id:=0, childCount:=3)
        AssertTreeIsLeaf(tree.Children(0), id:=1)
        AssertTreeIsLeaf(tree.Children(1), id:=2)
        AssertTreeIsLeaf(tree.Children(2), id:=3)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Binary_tree()
        Dim records = {New TreeBuildingRecord With {
.RecordId = 5,
.ParentId = 1
}, New TreeBuildingRecord With {
.RecordId = 3,
.ParentId = 2
}, New TreeBuildingRecord With {
.RecordId = 2,
.ParentId = 0
}, New TreeBuildingRecord With {
.RecordId = 4,
.ParentId = 1
}, New TreeBuildingRecord With {
.RecordId = 1,
.ParentId = 0
}, New TreeBuildingRecord With {
.RecordId = 0,
.ParentId = 0
}, New TreeBuildingRecord With {
.RecordId = 6,
.ParentId = 2
}}

        Dim tree = BuildTree(records)

        AssertTreeIsBranch(tree, id:=0, childCount:=2)
        AssertTreeIsBranch(tree.Children(0), id:=1, childCount:=2)
        AssertTreeIsBranch(tree.Children(1), id:=2, childCount:=2)

        AssertTreeIsLeaf(tree.Children(0).Children(0), id:=4)
        AssertTreeIsLeaf(tree.Children(0).Children(1), id:=5)
        AssertTreeIsLeaf(tree.Children(1).Children(0), id:=3)
        AssertTreeIsLeaf(tree.Children(1).Children(1), id:=6)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Unbalanced_tree()
        Dim records = {New TreeBuildingRecord With {
.RecordId = 5,
.ParentId = 2
}, New TreeBuildingRecord With {
.RecordId = 3,
.ParentId = 2
}, New TreeBuildingRecord With {
.RecordId = 2,
.ParentId = 0
}, New TreeBuildingRecord With {
.RecordId = 4,
.ParentId = 1
}, New TreeBuildingRecord With {
.RecordId = 1,
.ParentId = 0
}, New TreeBuildingRecord With {
.RecordId = 0,
.ParentId = 0
}, New TreeBuildingRecord With {
.RecordId = 6,
.ParentId = 2
}}

        Dim tree = BuildTree(records)

        AssertTreeIsBranch(tree, id:=0, childCount:=2)
        AssertTreeIsBranch(tree.Children(0), id:=1, childCount:=1)
        AssertTreeIsBranch(tree.Children(1), id:=2, childCount:=3)

        AssertTreeIsLeaf(tree.Children(0).Children(0), id:=4)
        AssertTreeIsLeaf(tree.Children(1).Children(0), id:=3)
        AssertTreeIsLeaf(tree.Children(1).Children(1), id:=5)
        AssertTreeIsLeaf(tree.Children(1).Children(2), id:=6)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Empty_input()
        Dim records = New TreeBuildingRecord(-1) {}

        Assert.Throws(Of ArgumentException)(Function() BuildTree(records))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Root_node_has_parent()
        Dim records = {New TreeBuildingRecord With {
.RecordId = 0,
.ParentId = 1
}, New TreeBuildingRecord With {
.RecordId = 1,
.ParentId = 0
}}

        Assert.Throws(Of ArgumentException)(Function() BuildTree(records))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub No_root_node()
        Dim records = {New TreeBuildingRecord With {
.RecordId = 1,
.ParentId = 0
}}

        Assert.Throws(Of ArgumentException)(Function() BuildTree(records))
    End Sub


    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Non_continuous()
        Dim records = {New TreeBuildingRecord With {
.RecordId = 2,
.ParentId = 0
}, New TreeBuildingRecord With {
.RecordId = 4,
.ParentId = 2
}, New TreeBuildingRecord With {
.RecordId = 1,
.ParentId = 0
}, New TreeBuildingRecord With {
.RecordId = 0,
.ParentId = 0
}}

        Assert.Throws(Of ArgumentException)(Function() BuildTree(records))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cycle_directly()
        Dim records = {New TreeBuildingRecord With {
.RecordId = 5,
.ParentId = 2
}, New TreeBuildingRecord With {
.RecordId = 3,
.ParentId = 2
}, New TreeBuildingRecord With {
.RecordId = 2,
.ParentId = 2
}, New TreeBuildingRecord With {
.RecordId = 4,
.ParentId = 1
}, New TreeBuildingRecord With {
.RecordId = 1,
.ParentId = 0
}, New TreeBuildingRecord With {
.RecordId = 0,
.ParentId = 0
}, New TreeBuildingRecord With {
.RecordId = 6,
.ParentId = 3
}}

        Assert.Throws(Of ArgumentException)(Function() BuildTree(records))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cycle_indirectly()
        Dim records = {New TreeBuildingRecord With {
.RecordId = 5,
.ParentId = 2
}, New TreeBuildingRecord With {
.RecordId = 3,
.ParentId = 2
}, New TreeBuildingRecord With {
.RecordId = 2,
.ParentId = 6
}, New TreeBuildingRecord With {
.RecordId = 4,
.ParentId = 1
}, New TreeBuildingRecord With {
.RecordId = 1,
.ParentId = 0
}, New TreeBuildingRecord With {
.RecordId = 0,
.ParentId = 0
}, New TreeBuildingRecord With {
.RecordId = 6,
.ParentId = 3
}}

        Assert.Throws(Of ArgumentException)(Function() BuildTree(records))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Higher_id_parent_of_lower_id()
        Dim records = {New TreeBuildingRecord With {
.RecordId = 0,
.ParentId = 0
}, New TreeBuildingRecord With {
.RecordId = 2,
.ParentId = 0
}, New TreeBuildingRecord With {
.RecordId = 1,
.ParentId = 2
}}

        Assert.Throws(Of ArgumentException)(Function() BuildTree(records))
    End Sub

    Private Sub AssertTreeIsBranch(ByVal tree As Tree, ByVal id As Integer, ByVal childCount As Integer)
        Assert.Equal(id, tree.Id)
        Assert.False(tree.IsLeaf)
        Assert.Equal(childCount, tree.Children.Count)
    End Sub

    Private Sub AssertTreeIsLeaf(ByVal tree As Tree, ByVal id As Integer)
        Assert.Equal(id, tree.Id)
        Assert.True(tree.IsLeaf)
    End Sub
End Class
