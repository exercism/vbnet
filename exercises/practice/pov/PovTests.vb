Imports System
Imports Xunit

Public Class PovTests
    <Fact>
    Public Sub Results_in_the_same_tree_if_the_input_tree_is_a_singleton()
        Dim tree = New Tree("x")
        Dim from = "x"
        Dim expected = New Tree("x")
        Assert.Equal(expected, FromPov(tree, from))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_reroot_a_tree_with_a_parent_and_one_sibling()
        Dim tree = New Tree("parent", New Tree("x"), New Tree("sibling"))
        Dim from = "x"
        Dim expected = New Tree("x", New Tree("parent", New Tree("sibling")))
        Assert.Equal(expected, FromPov(tree, from))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_reroot_a_tree_with_a_parent_and_many_siblings()
        Dim tree = New Tree("parent", New Tree("a"), New Tree("x"), New Tree("b"), New Tree("c"))
        Dim from = "x"
        Dim expected = New Tree("x", New Tree("parent", New Tree("a"), New Tree("b"), New Tree("c")))
        Assert.Equal(expected, FromPov(tree, from))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_reroot_a_tree_with_new_root_deeply_nested_in_tree()
        Dim tree = New Tree("level-0", New Tree("level-1", New Tree("level-2", New Tree("level-3", New Tree("x")))))
        Dim from = "x"
        Dim expected = New Tree("x", New Tree("level-3", New Tree("level-2", New Tree("level-1", New Tree("level-0")))))
        Assert.Equal(expected, FromPov(tree, from))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Moves_children_of_the_new_root_to_same_level_as_former_parent()
        Dim tree = New Tree("parent", New Tree("x", New Tree("kid-0"), New Tree("kid-1")))
        Dim from = "x"
        Dim expected = New Tree("x", New Tree("kid-0"), New Tree("kid-1"), New Tree("parent"))
        Assert.Equal(expected, FromPov(tree, from))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_reroot_a_complex_tree_with_cousins()
        Dim tree = New Tree("grandparent", New Tree("parent", New Tree("x", New Tree("kid-0"), New Tree("kid-1")), New Tree("sibling-0"), New Tree("sibling-1")), New Tree("uncle", New Tree("cousin-0"), New Tree("cousin-1")))
        Dim from = "x"
        Dim expected = New Tree("x", New Tree("kid-1"), New Tree("kid-0"), New Tree("parent", New Tree("sibling-0"), New Tree("sibling-1"), New Tree("grandparent", New Tree("uncle", New Tree("cousin-0"), New Tree("cousin-1")))))
        Assert.Equal(expected, FromPov(tree, from))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Errors_if_target_does_not_exist_in_a_singleton_tree()
        Dim tree = New Tree("x")
        Dim from = "nonexistent"
        Assert.Throws(Of ArgumentException)(Function() FromPov(tree, from))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Errors_if_target_does_not_exist_in_a_large_tree()
        Dim tree = New Tree("parent", New Tree("x", New Tree("kid-0"), New Tree("kid-1")), New Tree("sibling-0"), New Tree("sibling-1"))
        Dim from = "nonexistent"
        Assert.Throws(Of ArgumentException)(Function() FromPov(tree, from))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_find_path_to_parent()
        Dim from = "x"
        Dim [to] = "parent"
        Dim tree = New Tree("parent", New Tree("x"), New Tree("sibling"))
        Dim expected = {"x", "parent"}
        Assert.Equal(expected, PathTo(from, [to], tree))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_find_path_to_sibling()
        Dim from = "x"
        Dim [to] = "b"
        Dim tree = New Tree("parent", New Tree("a"), New Tree("x"), New Tree("b"), New Tree("c"))
        Dim expected = {"x", "parent", "b"}
        Assert.Equal(expected, PathTo(from, [to], tree))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_find_path_to_cousin()
        Dim from = "x"
        Dim [to] = "cousin-1"
        Dim tree = New Tree("grandparent", New Tree("parent", New Tree("x", New Tree("kid-0"), New Tree("kid-1")), New Tree("sibling-0"), New Tree("sibling-1")), New Tree("uncle", New Tree("cousin-0"), New Tree("cousin-1")))
        Dim expected = {"x", "parent", "grandparent", "uncle", "cousin-1"}
        Assert.Equal(expected, PathTo(from, [to], tree))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_find_path_not_involving_root()
        Dim from = "x"
        Dim [to] = "sibling-1"
        Dim tree = New Tree("grandparent", New Tree("parent", New Tree("x"), New Tree("sibling-0"), New Tree("sibling-1")))
        Dim expected = {"x", "parent", "sibling-1"}
        Assert.Equal(expected, PathTo(from, [to], tree))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_find_path_from_nodes_other_than_x()
        Dim from = "a"
        Dim [to] = "c"
        Dim tree = New Tree("parent", New Tree("a"), New Tree("x"), New Tree("b"), New Tree("c"))
        Dim expected = {"a", "parent", "c"}
        Assert.Equal(expected, PathTo(from, [to], tree))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Errors_if_destination_does_not_exist()
        Dim from = "x"
        Dim [to] = "nonexistent"
        Dim tree = New Tree("parent", New Tree("x", New Tree("kid-0"), New Tree("kid-1")), New Tree("sibling-0"), New Tree("sibling-1"))
        Assert.Throws(Of ArgumentException)(Function() PathTo(from, [to], tree))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Errors_if_source_does_not_exist()
        Dim from = "nonexistent"
        Dim [to] = "x"
        Dim tree = New Tree("parent", New Tree("x", New Tree("kid-0"), New Tree("kid-1")), New Tree("sibling-0"), New Tree("sibling-1"))
        Assert.Throws(Of ArgumentException)(Function() PathTo(from, [to], tree))
    End Sub
End Class
