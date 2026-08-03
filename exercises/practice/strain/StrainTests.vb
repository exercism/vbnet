Public Class StrainTests
    <Fact>
    Public Sub Keep_On_Empty_List_Returns_Empty_List()
        Dim input = Array.Empty(Of Integer)()

        Assert.Empty(input.Keep(Function(value) True))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Keeps_Everything()
        Dim input = {1, 3, 5}
        Dim expected = {1, 3, 5}

        Assert.Equal(expected, input.Keep(Function(value) True))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Keeps_Nothing()
        Dim input = {1, 3, 5}

        Assert.Empty(input.Keep(Function(value) False))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Keeps_First_And_Last()
        Dim input = {1, 2, 3}
        Dim expected = {1, 3}

        Assert.Equal(expected, input.Keep(Function(value) value Mod 2 = 1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Keeps_Neither_First_Nor_Last()
        Dim input = {1, 2, 3}
        Dim expected = {2}

        Assert.Equal(expected, input.Keep(Function(value) value Mod 2 = 0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Keeps_Strings()
        Dim input = {"apple", "zebra", "banana", "zombies", "cherimoya", "zealot"}
        Dim expected = {"zebra", "zombies", "zealot"}

        Assert.Equal(expected, input.Keep(Function(word) word.StartsWith("z")))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Keeps_Lists()
        Dim input = {
            New List(Of Integer) From {1, 2, 3},
            New List(Of Integer) From {5, 5, 5},
            New List(Of Integer) From {5, 1, 2},
            New List(Of Integer) From {2, 1, 2},
            New List(Of Integer) From {1, 5, 2},
            New List(Of Integer) From {2, 2, 1},
            New List(Of Integer) From {1, 2, 5}}
        Dim expected = {
            New List(Of Integer) From {5, 5, 5},
            New List(Of Integer) From {5, 1, 2},
            New List(Of Integer) From {1, 5, 2},
            New List(Of Integer) From {1, 2, 5}}

        Assert.Equal(expected, input.Keep(Function(values) values.Contains(5)))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Discard_On_Empty_List_Returns_Empty_List()
        Dim input = Array.Empty(Of Integer)()

        Assert.Empty(input.Discard(Function(value) True))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Discards_Everything()
        Dim input = {1, 3, 5}

        Assert.Empty(input.Discard(Function(value) True))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Discards_Nothing()
        Dim input = {1, 3, 5}
        Dim expected = {1, 3, 5}

        Assert.Equal(expected, input.Discard(Function(value) False))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Discards_First_And_Last()
        Dim input = {1, 2, 3}
        Dim expected = {2}

        Assert.Equal(expected, input.Discard(Function(value) value Mod 2 = 1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Discards_Neither_First_Nor_Last()
        Dim input = {1, 2, 3}
        Dim expected = {1, 3}

        Assert.Equal(expected, input.Discard(Function(value) value Mod 2 = 0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Discards_Strings()
        Dim input = {"apple", "zebra", "banana", "zombies", "cherimoya", "zealot"}
        Dim expected = {"apple", "banana", "cherimoya"}

        Assert.Equal(expected, input.Discard(Function(word) word.StartsWith("z")))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Discards_Lists()
        Dim input = {
            New List(Of Integer) From {1, 2, 3},
            New List(Of Integer) From {5, 5, 5},
            New List(Of Integer) From {5, 1, 2},
            New List(Of Integer) From {2, 1, 2},
            New List(Of Integer) From {1, 5, 2},
            New List(Of Integer) From {2, 2, 1},
            New List(Of Integer) From {1, 2, 5}}
        Dim expected = {
            New List(Of Integer) From {1, 2, 3},
            New List(Of Integer) From {2, 1, 2},
            New List(Of Integer) From {2, 2, 1}}

        Assert.Equal(expected, input.Discard(Function(values) values.Contains(5)))
    End Sub
End Class
