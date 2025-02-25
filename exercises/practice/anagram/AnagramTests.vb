Imports XUnit


Public Class AnagramTest
    <Fact>
    Public Sub NoMatches()
        Dim detector = New Anagram("diaper")
        Dim words = {"hello", "world", "zombies", "pants"}
        Dim expected = Array.Empty(Of String)()
        Dim result as IEnumerable(Of String) = detector.Match(words)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub DetectSimpleAnagram()
        Dim detector = New Anagram("ant")
        Dim words = {"tan", "stand", "at"}
        Dim expected = {"tan"}
        Dim result as IEnumerable(Of String) = detector.Match(words)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub DetectMultipleAnagrams()
        Dim detector = New Anagram("master")
        Dim words = {"stream", "pigeon", "maters"}
        Dim expected = {"maters", "stream"}
        Dim result as IEnumerable(Of String) = detector.Match(words)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub DoesNotConfuseDifferentDuplicates()
        Dim detector = New Anagram("galea")
        Dim words = {"eagle"}
        Dim expected = Array.Empty(Of String)()
        Dim result as IEnumerable(Of String) = detector.Match(words)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub IdenticalWordIsNotAnagram()
        Dim detector = New Anagram("corn")
        Dim words = {"corn", "dark", "Corn", "rank", "CORN", "cron",
            "park"}
        Dim expected = {"cron"}
        Dim result as IEnumerable(Of String) = detector.Match(words)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub EliminateAnagramsWithSameChecksum()
        Dim detector = New Anagram("mass")
        Dim words = {"last"}
        Dim expected = Array.Empty(Of String)()
        Dim result as IEnumerable(Of String) = detector.Match(words)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub EliminateAnagramSubsets()
        Dim detector = New Anagram("good")
        Dim words = {"dog", "goody"}
        Dim expected = Array.Empty(Of String)()
        Dim result as IEnumerable(Of String) = detector.Match(words)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub DetectAnagrams()
        Dim detector = New Anagram("allergy")
        Dim words = {"gallery", "ballerina", "regally", "clergy", "largely", "leading"}
        Dim expected = {"gallery", "largely", "regally"}
        Dim result as IEnumerable(Of String) = detector.Match(words)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AnagramsAreCaseInsensitive()
        Dim detector = New Anagram("Orchestra")
        Dim words = {"cashregister", "Carthorse", "radishes"}
        Dim expected = {"Carthorse"}
        Dim result as IEnumerable(Of String) = detector.Match(words)
        Assert.Equal(expected, result)
    End Sub

End Class
