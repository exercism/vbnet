Public Class AccumulateTests
    <Fact>
    Public Sub Accumulate_empty()
        Dim input As Integer() = {}
        Dim expected As Integer() = {}
        Assert.Equal(expected, input.Accumulate(Function(x) x * x))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Accumulate_squares()
        Dim input As Integer() = {1, 2, 3}
        Dim expected As Integer() = {1, 4, 9}
        Assert.Equal(expected, input.Accumulate(Function(x) x * x))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Accumulate_upcases()
        Dim input As String() = {"Hello", "world"}
        Dim expected As String() = {"HELLO", "WORLD"}
        Assert.Equal(expected, input.Accumulate(Function(x) x.ToUpper()))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Accumulate_reversed_strings()
        Dim input As String() = {"the", "quick", "brown", "fox", "etc"}
        Dim expected As String() = {"eht", "kciuq", "nworb", "xof", "cte"}
        Assert.Equal(expected, input.Accumulate(Function(x) New String(x.Reverse().ToArray())))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Accumulate_recursively()
        Dim input As String() = {"a", "b", "c"}
        Dim expected As String() = {
            "a1 a2 a3",
            "b1 b2 b3",
            "c1 c2 c3"
        }
        Assert.Equal(expected, input.Accumulate(Function(x) String.Join(" ", New String() {"1", "2", "3"}.Accumulate(Function(y) x & y))))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Accumulate_is_lazy()
        Dim counter = 0
        Dim accumulation = New Integer() {1, 2, 3}.Accumulate(
            Function(x)
                counter += 1
                Return x
            End Function)

        Assert.Equal(0, counter)
        accumulation.ToList()
        Assert.Equal(3, counter)
    End Sub
End Class
