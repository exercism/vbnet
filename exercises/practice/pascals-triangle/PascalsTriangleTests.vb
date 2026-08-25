Public Class PascalsTriangleTests
    <Fact>
    Public Sub Zero_rows()
        Dim expected = Array.Empty(Of Integer())()
        Assert.Equal(expected, PascalsTriangle.Calculate(0))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Single_row()
        Dim expected = {
            New Integer() {1}
        }
        Assert.Equal(expected, PascalsTriangle.Calculate(1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_rows()
        Dim expected = {
            New Integer() {1},
            New Integer() {1, 1}
        }
        Assert.Equal(expected, PascalsTriangle.Calculate(2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Three_rows()
        Dim expected = {
            New Integer() {1},
            New Integer() {1, 1},
            New Integer() {1, 2, 1}
        }
        Assert.Equal(expected, PascalsTriangle.Calculate(3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Four_rows()
        Dim expected = {
            New Integer() {1},
            New Integer() {1, 1},
            New Integer() {1, 2, 1},
            New Integer() {1, 3, 3, 1}
        }
        Assert.Equal(expected, PascalsTriangle.Calculate(4))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Five_rows()
        Dim expected = {
            New Integer() {1},
            New Integer() {1, 1},
            New Integer() {1, 2, 1},
            New Integer() {1, 3, 3, 1},
            New Integer() {1, 4, 6, 4, 1}
        }
        Assert.Equal(expected, PascalsTriangle.Calculate(5))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Six_rows()
        Dim expected = {
            New Integer() {1},
            New Integer() {1, 1},
            New Integer() {1, 2, 1},
            New Integer() {1, 3, 3, 1},
            New Integer() {1, 4, 6, 4, 1},
            New Integer() {1, 5, 10, 10, 5, 1}
        }
        Assert.Equal(expected, PascalsTriangle.Calculate(6))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ten_rows()
        Dim expected = {
            New Integer() {1},
            New Integer() {1, 1},
            New Integer() {1, 2, 1},
            New Integer() {1, 3, 3, 1},
            New Integer() {1, 4, 6, 4, 1},
            New Integer() {1, 5, 10, 10, 5, 1},
            New Integer() {1, 6, 15, 20, 15, 6, 1},
            New Integer() {1, 7, 21, 35, 35, 21, 7, 1},
            New Integer() {1, 8, 28, 56, 70, 56, 28, 8, 1},
            New Integer() {1, 9, 36, 84, 126, 126, 84, 36, 9, 1}
        }
        Assert.Equal(expected, PascalsTriangle.Calculate(10))
    End Sub
End Class
