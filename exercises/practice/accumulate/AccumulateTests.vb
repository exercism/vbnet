Imports XUnit


Public Class AccumulateTest
    <Fact>
    Public Sub EmptyAccumulationProducesEmptyAccumulation()
        Assert.That(New Integer() {}.Accumulate(Function(x) x * x), [Is].EqualTo(New Integer() {}))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub AccumulateSquares()
        Assert.That({1, 2, 3}.Accumulate(Function(x) x * x), [Is].EqualTo({1, 4, 9}))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub AccumulateUpcases()
        Assert.That(New List(Of String)() From {
            "hello",
            "world"
        }.Accumulate(Function(x) x.ToUpper()), [Is].EqualTo(New List(Of String) From {
            "HELLO",
            "WORLD"
        }))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub AccumulateReversedStrings()
        Assert.That("the quick brown fox etc".Split(" "c).Accumulate(AddressOf Reverse), [Is].EqualTo("eht kciuq nworb xof cte".Split(" "c)))
    End Sub

    Private Shared Function Reverse(value As String) As String
        Dim chars = value.ToCharArray()
        Array.Reverse(chars)
        Return New String(chars)
    End Function

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub AccumulateWithinAccumulate()
        Dim actual = New String() {"a", "b", "c"}.Accumulate(Function(c) String.Join(" ", New String() {"1", "2", "3"}.Accumulate(Function(d) c & d)))
        Assert.That(actual, [Is].EqualTo(New String() {"a1 a2 a3", "b1 b2 b3", "c1 c2 c3"}))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub AccumulateIsLazy()
        Dim counter = 0
        Dim accumulation = New Integer() {1, 2, 3}.Accumulate(Function(x) x * System.Math.Max(System.Threading.Interlocked.Increment(counter), counter - 1))

        Assert.That(counter, [Is].EqualTo(0))
        accumulation.ToList()
        Assert.That(counter, [Is].EqualTo(3))
    End Sub
End Class
