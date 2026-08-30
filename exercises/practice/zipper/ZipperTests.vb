Public Class ZipperTests
    <Fact>
    Public Sub Data_is_retained()
        Dim tree = New BinTree(1, New BinTree(2, Nothing, New BinTree(3, Nothing, Nothing)), New BinTree(4, Nothing, Nothing))
        Dim sut = Zipper.FromTree(tree)
        Dim actual = sut.ToTree()
        Dim expected = New BinTree(1, New BinTree(2, Nothing, New BinTree(3, Nothing, Nothing)), New BinTree(4, Nothing, Nothing))

        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Left_right_and_value()
        Dim tree = New BinTree(1, New BinTree(2, Nothing, New BinTree(3, Nothing, Nothing)), New BinTree(4, Nothing, Nothing))
        Dim sut = Zipper.FromTree(tree)
        Dim actual = sut.Left().Right().Value()

        Assert.Equal(3, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Dead_end()
        Dim tree = New BinTree(1, New BinTree(2, Nothing, New BinTree(3, Nothing, Nothing)), New BinTree(4, Nothing, Nothing))
        Dim sut = Zipper.FromTree(tree)
        Dim actual = sut.Left().Left()

        Assert.Null(actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Tree_from_deep_focus()
        Dim tree = New BinTree(1, New BinTree(2, Nothing, New BinTree(3, Nothing, Nothing)), New BinTree(4, Nothing, Nothing))
        Dim sut = Zipper.FromTree(tree)
        Dim actual = sut.Left().Right().ToTree()
        Dim expected = New BinTree(1, New BinTree(2, Nothing, New BinTree(3, Nothing, Nothing)), New BinTree(4, Nothing, Nothing))

        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Traversing_up_from_top()
        Dim tree = New BinTree(1, New BinTree(2, Nothing, New BinTree(3, Nothing, Nothing)), New BinTree(4, Nothing, Nothing))
        Dim sut = Zipper.FromTree(tree)
        Dim actual = sut.Up()

        Assert.Null(actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Left_right_and_up()
        Dim tree = New BinTree(1, New BinTree(2, Nothing, New BinTree(3, Nothing, Nothing)), New BinTree(4, Nothing, Nothing))
        Dim sut = Zipper.FromTree(tree)
        Dim actual = sut.Left().Up().Right().Up().Left().Right().Value()

        Assert.Equal(3, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Test_ability_to_descend_multiple_levels_and_return()
        Dim tree = New BinTree(1, New BinTree(2, Nothing, New BinTree(3, Nothing, Nothing)), New BinTree(4, Nothing, Nothing))
        Dim sut = Zipper.FromTree(tree)
        Dim actual = sut.Left().Right().Up().Up().Value()

        Assert.Equal(1, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Set_value()
        Dim tree = New BinTree(1, New BinTree(2, Nothing, New BinTree(3, Nothing, Nothing)), New BinTree(4, Nothing, Nothing))
        Dim sut = Zipper.FromTree(tree)
        Dim actual = sut.Left().SetValue(5).ToTree()
        Dim expected = New BinTree(1, New BinTree(5, Nothing, New BinTree(3, Nothing, Nothing)), New BinTree(4, Nothing, Nothing))

        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Set_value_after_traversing_up()
        Dim tree = New BinTree(1, New BinTree(2, Nothing, New BinTree(3, Nothing, Nothing)), New BinTree(4, Nothing, Nothing))
        Dim sut = Zipper.FromTree(tree)
        Dim actual = sut.Left().Right().Up().SetValue(5).ToTree()
        Dim expected = New BinTree(1, New BinTree(5, Nothing, New BinTree(3, Nothing, Nothing)), New BinTree(4, Nothing, Nothing))

        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Set_left_with_leaf()
        Dim tree = New BinTree(1, New BinTree(2, Nothing, New BinTree(3, Nothing, Nothing)), New BinTree(4, Nothing, Nothing))
        Dim sut = Zipper.FromTree(tree)
        Dim actual = sut.Left().SetLeft(New BinTree(5, Nothing, Nothing)).ToTree()
        Dim expected = New BinTree(1, New BinTree(2, New BinTree(5, Nothing, Nothing), New BinTree(3, Nothing, Nothing)), New BinTree(4, Nothing, Nothing))

        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Set_right_with_null()
        Dim tree = New BinTree(1, New BinTree(2, Nothing, New BinTree(3, Nothing, Nothing)), New BinTree(4, Nothing, Nothing))
        Dim sut = Zipper.FromTree(tree)
        Dim actual = sut.Left().SetRight(Nothing).ToTree()
        Dim expected = New BinTree(1, New BinTree(2, Nothing, Nothing), New BinTree(4, Nothing, Nothing))

        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Set_right_with_subtree()
        Dim tree = New BinTree(1, New BinTree(2, Nothing, New BinTree(3, Nothing, Nothing)), New BinTree(4, Nothing, Nothing))
        Dim sut = Zipper.FromTree(tree)
        Dim actual = sut.SetRight(New BinTree(6, New BinTree(7, Nothing, Nothing), New BinTree(8, Nothing, Nothing))).ToTree()
        Dim expected = New BinTree(1, New BinTree(2, Nothing, New BinTree(3, Nothing, Nothing)), New BinTree(6, New BinTree(7, Nothing, Nothing), New BinTree(8, Nothing, Nothing)))

        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Set_value_on_deep_focus()
        Dim tree = New BinTree(1, New BinTree(2, Nothing, New BinTree(3, Nothing, Nothing)), New BinTree(4, Nothing, Nothing))
        Dim sut = Zipper.FromTree(tree)
        Dim actual = sut.Left().Right().SetValue(5).ToTree()
        Dim expected = New BinTree(1, New BinTree(2, Nothing, New BinTree(5, Nothing, Nothing)), New BinTree(4, Nothing, Nothing))

        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Different_paths_to_same_zipper()
        Dim tree = New BinTree(1, New BinTree(2, Nothing, New BinTree(3, Nothing, Nothing)), New BinTree(4, Nothing, Nothing))
        Dim sut = Zipper.FromTree(tree)
        Dim actual = sut.Left().Up().Right()
        Dim expectedTree = New BinTree(1, New BinTree(2, Nothing, New BinTree(3, Nothing, Nothing)), New BinTree(4, Nothing, Nothing))
        Dim expectedSut = Zipper.FromTree(expectedTree)
        Dim expected = expectedSut.Right()

        Assert.Equal(expected, actual)
    End Sub
End Class
