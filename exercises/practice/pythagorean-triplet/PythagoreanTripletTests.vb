Public Class PythagoreanTripletTests
    <Fact>
    Public Sub Triplets_whose_sum_is_12()
        Dim expected = {(3, 4, 5)}
        Assert.Equal(expected, PythagoreanTriplet.TripletsWithSum(12))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Triplets_whose_sum_is_108()
        Dim expected = {(27, 36, 45)}
        Assert.Equal(expected, PythagoreanTriplet.TripletsWithSum(108))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Triplets_whose_sum_is_1000()
        Dim expected = {(200, 375, 425)}
        Assert.Equal(expected, PythagoreanTriplet.TripletsWithSum(1000))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub No_matching_triplets_for_1001()
        Dim expected = Array.Empty(Of (Integer, Integer, Integer))()
        Assert.Equal(expected, PythagoreanTriplet.TripletsWithSum(1001))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Returns_all_matching_triplets()
        Dim expected = {
            (9, 40, 41),
            (15, 36, 39)
        }
        Assert.Equal(expected, PythagoreanTriplet.TripletsWithSum(90))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Several_matching_triplets()
        Dim expected = {
            (40, 399, 401),
            (56, 390, 394),
            (105, 360, 375),
            (120, 350, 370),
            (140, 336, 364),
            (168, 315, 357),
            (210, 280, 350),
            (240, 252, 348)
        }
        Assert.Equal(expected, PythagoreanTriplet.TripletsWithSum(840))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Triplets_for_large_number()
        Dim expected = {
            (1200, 14375, 14425),
            (1875, 14000, 14125),
            (5000, 12000, 13000),
            (6000, 11250, 12750),
            (7500, 10000, 12500)
        }
        Assert.Equal(expected, PythagoreanTriplet.TripletsWithSum(30000))
    End Sub
End Class
