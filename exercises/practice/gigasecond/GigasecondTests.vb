Imports System
Imports Xunit

Public Class GigasecondTests
    <Fact>
    Public Sub Date_only_specification_of_time()
        Assert.Equal(New DateTime(2043, 1, 1, 1, 46, 40), Add(New DateTime(2011, 4, 25)))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Second_test_for_date_only_specification_of_time()
        Assert.Equal(New DateTime(2009, 2, 19, 1, 46, 40), Add(New DateTime(1977, 6, 13)))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Third_test_for_date_only_specification_of_time()
        Assert.Equal(New DateTime(1991, 3, 27, 1, 46, 40), Add(New DateTime(1959, 7, 19)))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Full_time_specified()
        Assert.Equal(New DateTime(2046, 10, 2, 23, 46, 40), Add(New DateTime(2015, 1, 24, 22, 0, 0)))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Full_time_with_day_roll_over()
        Assert.Equal(New DateTime(2046, 10, 3, 1, 46, 39), Add(New DateTime(2015, 1, 24, 23, 59, 59)))
    End Sub
End Class
