Imports System
Imports Xunit

Public Class PythagoreanTripletTests
    <Fact>
    Public Sub Triplets_whose_sum_is_12()
        Assert.Equal({(3, 4, 5)}, TripletsWithSum(12))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Triplets_whose_sum_is_108()
        Assert.Equal({(27, 36, 45)}, TripletsWithSum(108))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Triplets_whose_sum_is_1000()
        Assert.Equal({(200, 375, 425)}, TripletsWithSum(1000))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub No_matching_triplets_for_1001()
        Assert.Equal(Array.Empty(Of (Integer, Integer, Integer))(), TripletsWithSum(1001))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Returns_all_matching_triplets()
        Assert.Equal({(9, 40, 41), (15, 36, 39)}, TripletsWithSum(90))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Several_matching_triplets()
        Assert.Equal({(40, 399, 401), (56, 390, 394), (105, 360, 375), (120, 350, 370), (140, 336, 364), (168, 315, 357), (210, 280, 350), (240, 252, 348)}, TripletsWithSum(840))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Triplets_for_large_number()
        Assert.Equal({(1200, 14375, 14425), (1875, 14000, 14125), (5000, 12000, 13000), (6000, 11250, 12750), (7500, 10000, 12500)}, TripletsWithSum(30000))
    End Sub
End Class
