Public Class HighScoresTests
    <Fact>
    Public Sub List_of_scores()
        Dim scores = {30, 50, 20, 70}.ToList()
        Dim sut = New HighScores(scores)
        Dim expected = {30, 50, 20, 70}.ToList()
        Assert.Equal(expected, sut.Scores())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Latest_score()
        Dim scores = {100, 0, 90, 30}.ToList()
        Dim sut = New HighScores(scores)
        Assert.Equal(30, sut.Latest())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Personal_best()
        Dim scores = {40, 100, 70}.ToList()
        Dim sut = New HighScores(scores)
        Assert.Equal(100, sut.PersonalBest())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Personal_top_three_from_a_list_of_scores()
        Dim scores = {
            10, 30, 90, 30,
            100, 20, 10, 0,
            30, 40, 40, 70,
            70
        }.ToList()
        Dim sut = New HighScores(scores)
        Dim expected = {100, 90, 70}.ToList()
        Assert.Equal(expected, sut.PersonalTopThree())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Personal_top_highest_to_lowest()
        Dim scores = {20, 10, 30}.ToList()
        Dim sut = New HighScores(scores)
        Dim expected = {30, 20, 10}.ToList()
        Assert.Equal(expected, sut.PersonalTopThree())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Personal_top_when_there_is_a_tie()
        Dim scores = {40, 20, 40, 30}.ToList()
        Dim sut = New HighScores(scores)
        Dim expected = {40, 40, 30}.ToList()
        Assert.Equal(expected, sut.PersonalTopThree())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Personal_top_when_there_are_less_than_3()
        Dim scores = {30, 70}.ToList()
        Dim sut = New HighScores(scores)
        Dim expected = {70, 30}.ToList()
        Assert.Equal(expected, sut.PersonalTopThree())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Personal_top_when_there_is_only_one()
        Dim scores = {40}.ToList()
        Dim sut = New HighScores(scores)
        Dim expected = {40}.ToList()
        Assert.Equal(expected, sut.PersonalTopThree())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Latest_score_after_personal_top_scores()
        Dim scores = {70, 50, 20, 30}.ToList()
        Dim sut = New HighScores(scores)
        sut.PersonalTopThree()
        Assert.Equal(30, sut.Latest())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Scores_after_personal_top_scores()
        Dim scores = {30, 50, 20, 70}.ToList()
        Dim sut = New HighScores(scores)
        sut.PersonalTopThree()
        Dim expected = {30, 50, 20, 70}.ToList()
        Assert.Equal(expected, sut.Scores())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Latest_score_after_personal_best()
        Dim scores = {
            20, 70, 15, 25,
            30
        }.ToList()
        Dim sut = New HighScores(scores)
        sut.PersonalBest()
        Assert.Equal(30, sut.Latest())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Scores_after_personal_best()
        Dim scores = {
            20, 70, 15, 25,
            30
        }.ToList()
        Dim sut = New HighScores(scores)
        sut.PersonalBest()
        Dim expected = {
            20, 70, 15, 25,
            30
        }.ToList()
        Assert.Equal(expected, sut.Scores())
    End Sub
End Class
