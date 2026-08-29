Public Class StrainTests
    <Fact>
    Public Sub Keep_on_empty_list_returns_empty_list()
        Dim input = Array.Empty(Of Integer)()
        Assert.Empty(input.Keep(Function(value) True))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Keeps_everything()
        Dim input = {1, 3, 5}
        Dim expected = {1, 3, 5}
        Assert.Equal(expected, input.Keep(Function(value) True))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Keeps_nothing()
        Dim input = {1, 3, 5}
        Assert.Empty(input.Keep(Function(value) False))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Keeps_first_and_last()
        Dim input = {1, 2, 3}
        Dim expected = {1, 3}
        Assert.Equal(expected, input.Keep(Function(value) value Mod 2 = 1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Keeps_neither_first_nor_last()
        Dim input = {1, 2, 3}
        Dim expected = {2}
        Assert.Equal(expected, input.Keep(Function(value) value Mod 2 = 0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Keeps_strings()
        Dim input = {"apple", "zebra", "banana", "zombies", "cherimoya", "zealot"}
        Dim expected = {"zebra", "zombies", "zealot"}
        Assert.Equal(expected, input.Keep(Function(word) word.StartsWith("z")))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Keeps_lists()
        Dim input = {
            {1, 2, 3}.ToList(),
            {5, 5, 5}.ToList(),
            {5, 1, 2}.ToList(),
            {2, 1, 2}.ToList(),
            {1, 5, 2}.ToList(),
            {2, 2, 1}.ToList(),
            {1, 2, 5}.ToList()
        }.ToList()
        Dim expected = {
            {5, 5, 5}.ToList(),
            {5, 1, 2}.ToList(),
            {1, 5, 2}.ToList(),
            {1, 2, 5}.ToList()
        }.ToList()
        Assert.Equal(expected, input.Keep(Function(values) values.Contains(5)))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Discard_on_empty_list_returns_empty_list()
        Dim input = Array.Empty(Of Integer)()
        Assert.Empty(input.Discard(Function(value) True))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Discards_everything()
        Dim input = {1, 3, 5}
        Assert.Empty(input.Discard(Function(value) True))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Discards_nothing()
        Dim input = {1, 3, 5}
        Dim expected = {1, 3, 5}
        Assert.Equal(expected, input.Discard(Function(value) False))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Discards_first_and_last()
        Dim input = {1, 2, 3}
        Dim expected = {2}
        Assert.Equal(expected, input.Discard(Function(value) value Mod 2 = 1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Discards_neither_first_nor_last()
        Dim input = {1, 2, 3}
        Dim expected = {1, 3}
        Assert.Equal(expected, input.Discard(Function(value) value Mod 2 = 0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Discards_strings()
        Dim input = {"apple", "zebra", "banana", "zombies", "cherimoya", "zealot"}
        Dim expected = {"apple", "banana", "cherimoya"}
        Assert.Equal(expected, input.Discard(Function(word) word.StartsWith("z")))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Discards_lists()
        Dim input = {
            {1, 2, 3}.ToList(),
            {5, 5, 5}.ToList(),
            {5, 1, 2}.ToList(),
            {2, 1, 2}.ToList(),
            {1, 5, 2}.ToList(),
            {2, 2, 1}.ToList(),
            {1, 2, 5}.ToList()
        }.ToList()
        Dim expected = {
            {1, 2, 3}.ToList(),
            {2, 1, 2}.ToList(),
            {2, 2, 1}.ToList()
        }.ToList()
        Assert.Equal(expected, input.Discard(Function(values) values.Contains(5)))
    End Sub
End Class
