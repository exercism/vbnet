Public Class GigasecondTests
    <Fact>
    Public Sub Date_only_specification_of_time()
        Dim moment = Date.Parse("2011-04-25")
        Dim expected = Date.Parse("2043-01-01T01:46:40")
        Assert.Equal(expected, Gigasecond.Add(moment))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Second_test_for_date_only_specification_of_time()
        Dim moment = Date.Parse("1977-06-13")
        Dim expected = Date.Parse("2009-02-19T01:46:40")
        Assert.Equal(expected, Gigasecond.Add(moment))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Third_test_for_date_only_specification_of_time()
        Dim moment = Date.Parse("1959-07-19")
        Dim expected = Date.Parse("1991-03-27T01:46:40")
        Assert.Equal(expected, Gigasecond.Add(moment))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Full_time_specified()
        Dim moment = Date.Parse("2015-01-24T22:00:00")
        Dim expected = Date.Parse("2046-10-02T23:46:40")
        Assert.Equal(expected, Gigasecond.Add(moment))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Full_time_with_day_roll_over()
        Dim moment = Date.Parse("2015-01-24T23:59:59")
        Dim expected = Date.Parse("2046-10-03T01:46:39")
        Assert.Equal(expected, Gigasecond.Add(moment))
    End Sub
End Class
