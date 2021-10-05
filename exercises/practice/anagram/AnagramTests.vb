Imports Xunit

Public Class AnagramTest

    <Fact>
    Public Sub NoMatches()
        Dim detector As New Anagram("diaper")
        Dim words As String() = New String() {"hello", "world", "zombies", "pants"}
        Dim results As String() = New String() {}
        Assert.Equal(detector.Match(words), results)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub DetectSimpleAnagram()
        Dim detector As New Anagram("ant")
        Dim words As String() = New String() {"tan", "stand", "at"}
        Dim results As String() = New String() {"tan"}
        Assert.Equal(detector.Match(words), results)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub DetectMultipleAnagrams()
        Dim detector As New Anagram("master")
        Dim words As String() = New String() {"stream", "pigeon", "maters"}
        Dim results As String() = New String() {"maters", "stream"}
        Assert.Equal(detector.Match(words), results)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub DoesNotConfuseDifferentDuplicates()
        Dim detector As New Anagram("galea")
        Dim words As String() = New String() {"eagle"}
        Dim results As String() = New String() {}
        Assert.Equal(detector.Match(words), results)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub IdenticalWordIsNotAnagram()
        Dim detector As New Anagram("corn")
        Dim words As String() = New String() {"corn", "dark", "Corn", "rank", "CORN", "cron", "park"}
        Dim results As String() = New String() {"cron"}
        Assert.Equal(detector.Match(words), results)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub EliminateAnagramsWithSameChecksum()
        Dim detector As New Anagram("mass")
        Dim words As String() = New String() {"last"}
        Dim results As String() = New String(-1) {}
        Assert.Equal(detector.Match(words), results)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub EliminateAnagramSubsets()
        Dim detector As New Anagram("good")
        Dim words As String() = New String() {"dog", "goody"}
        Dim results As String() = New String(-1) {}
        Assert.Equal(detector.Match(words), results)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub DetectAnagrams()
        Dim detector As New Anagram("allergy")
        Dim words As String() = New String() {"gallery", "ballerina", "regally", "clergy", "largely", "leading"}
        Dim results As String() = New String() {"gallery", "largely", "regally"}
        Assert.Equal(detector.Match(words), results)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AnagramsAreCaseInsensitive()
        Dim detector As New Anagram("Orchestra")
        Dim words As String() = New String() {"cashregister", "Carthorse", "radishes"}
        Dim results As String() = New String() {"Carthorse"}
        Assert.Equal(detector.Match(words), results)
    End Sub

End Class
