Imports NUnit.Framework

<TestFixture>
Public Class AccumulateTest
    <Test>
    Public Sub Empty_accumulation_produces_empty_accumulation()
        Assert.That(New Integer() {}.Accumulate(Function(x) x * x), [Is].EqualTo(New Integer() {}))
    End Sub

    <Ignore>
    <Test>
    Public Sub Accumulate_squares()
        Assert.That({1, 2, 3}.Accumulate(Function(x) x * x), [Is].EqualTo({1, 4, 9}))
    End Sub

    <Ignore>
    <Test>
    Public Sub Accumulate_upcases()
        Assert.That(New List(Of String)() From { _
            "hello", _
            "world" _
        }.Accumulate(Function(x) x.ToUpper()), [Is].EqualTo(New List(Of String) From { _
            "HELLO", _
            "WORLD" _
        }))
    End Sub

    <Ignore>
    <Test>
    Public Sub Accumulate_reversed_strings()
        Assert.That("the quick brown fox etc".Split(" "c).Accumulate(AddressOf Reverse), [Is].EqualTo("eht kciuq nworb xof cte".Split(" "c)))
    End Sub

    Private Shared Function Reverse(value As String) As String
        Dim array__1 = value.ToCharArray()
        Array.Reverse(array__1)
        Return New String(array__1)
    End Function

    <Ignore>
    <Test>
    Public Sub Accumulate_within_accumulate()
        Dim actual = New String() {"a", "b", "c"}.Accumulate(Function(c) String.Join(" ", New String() {"1", "2", "3"}.Accumulate(Function(d) c + d)))
        Assert.That(actual, [Is].EqualTo(New String() {"a1 a2 a3", "b1 b2 b3", "c1 c2 c3"}))
    End Sub

    <Ignore>
    <Test>
    Public Sub Accumulate_is_lazy()
        Dim counter = 0
        Dim accumulation = New Integer() {1, 2, 3}.Accumulate(Function(x) x * System.Math.Max(System.Threading.Interlocked.Increment(counter), counter - 1))

        Assert.That(counter, [Is].EqualTo(0))
        accumulation.ToList()
        Assert.That(counter, [Is].EqualTo(3))
    End Sub
End Class
