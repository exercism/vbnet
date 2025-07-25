Imports System.Collections.Generic
Imports Xunit

Public Class HighScoresTest
    <Fact>
    Public Sub ListOfScores()
        Dim sut = New HighScores(New List(Of Integer) From {
            30,
            50,
            20,
            70
        })
        Assert.Equal(New List(Of Integer) From {
            30,
            50,
            20,
            70
        }, sut.Scores())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub LatestScore()
        Dim sut = New HighScores(New List(Of Integer) From {
            100,
            0,
            90,
            30
        })
        Assert.Equal(30, sut.Latest())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub PersonalBest()
        Dim sut = New HighScores(New List(Of Integer) From {
            40,
            100,
            70
        })
        Assert.Equal(100, sut.PersonalBest())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub PersonalTopThreeFromAListOfScores()
        Dim sut = New HighScores(New List(Of Integer) From {
            10,
            30,
            90,
            30,
            100,
            20,
            10,
            0,
            30,
            40,
            40,
            70,
            70
        })
        Assert.Equal(New List(Of Integer) From {
            100,
            90,
            70
        }, sut.PersonalTopThree())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub PersonalTopHighestToLowest()
        Dim sut = New HighScores(New List(Of Integer) From {
            20,
            10,
            30
        })
        Assert.Equal(New List(Of Integer) From {
            30,
            20,
            10
        }, sut.PersonalTopThree())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub PersonalTopWhenThereIsATie()
        Dim sut = New HighScores(New List(Of Integer) From {
            40,
            20,
            40,
            30
        })
        Assert.Equal(New List(Of Integer) From {
            40,
            40,
            30
        }, sut.PersonalTopThree())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub PersonalTopWhenThereAreLessThan3()
        Dim sut = New HighScores(New List(Of Integer) From {
            30,
            70
        })
        Assert.Equal(New List(Of Integer) From {
            70,
            30
        }, sut.PersonalTopThree())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub PersonalTopWhenThereIsOnlyOne()
        Dim sut = New HighScores(New List(Of Integer) From {
            40
        })
        Assert.Equal(New List(Of Integer) From {
            40
        }, sut.PersonalTopThree())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub LatestScoreAfterPersonalTopScores()
        Dim sut = New HighScores(New List(Of Integer) From {
            70,
            50,
            20,
            30
        })
        Assert.Equal(new List(Of Integer) From {
            70,
            50,
            30
        } , sut.PersonalTopThree())
        Assert.Equal(30, sut.Latest())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub ScoresAfterPersonalTopScores()
        Dim sut = New HighScores(New List(Of Integer) From {
            30,
            50,
            20,
            70
        })
        Assert.Equal(New List(Of Integer) From {
            70,
            50,
            30
        }, sut.PersonalTopThree())
        Assert.Equal(New List(Of Integer) From {
            30,
            50,
            20,
            70
        }, sut.Scores())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub LatestScoreAfterPersonalBest()
        Dim sut = New HighScores(New List(Of Integer) From {
            20,
            70,
            15,
            25,
            30
        })
        Assert.Equal(70, sut.PersonalBest())
        Assert.Equal(30, sut.Latest())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub ScoresAfterPersonalBest()
        Dim sut = New HighScores(New List(Of Integer) From {
            20,
            70,
            15,
            25,
            30
        })
        Assert.Equal(70, sut.PersonalBest())
        Assert.Equal(New List(Of Integer) From {
            20,
            70,
            15,
            25,
            30
        }, sut.Scores())
    End Sub
End Class
