Imports Xunit

Public Class AnagramTest

    <Fact>
    Public Sub NoMatches()
        Dim detector As New Anagram("diaper")
        Dim words As String() = New String() {"hello", "world", "zombies", "pants"}
        Dim expected As String() = New String() {}
        Dim actual As IEnumerable(Of String) = detector.Match(words)
        CompareLists(expected, actual)
    End Sub

    <Fact>
    Public Sub DetectSimpleAnagram()
        Dim detector As New Anagram("ant")
        Dim words As String() = New String() {"tan", "stand", "at"}
        Dim expected As String() = New String() {"tan"}
        Dim actual As IEnumerable(Of String) = detector.Match(words)
        CompareLists(expected, actual)
    End Sub

    <Fact>
    Public Sub DetectMultipleAnagrams()
        Dim detector As New Anagram("master")
        Dim words As String() = New String() {"stream", "pigeon", "maters"}
        Dim expected As String() = New String() {"maters", "stream"}
        Dim actual As IEnumerable(Of String) = detector.Match(words)
        CompareLists(expected, actual)
    End Sub

    <Fact>
    Public Sub DoesNotConfuseDifferentDuplicates()
        Dim detector As New Anagram("galea")
        Dim words As String() = New String() {"eagle"}
        Dim expected As String() = New String() {}
        Dim actual As IEnumerable(Of String) = detector.Match(words)
        CompareLists(expected, actual)
    End Sub

    <Fact>
    Public Sub IdenticalWordIsNotAnagram()
        Dim detector As New Anagram("corn")
        Dim words As String() = New String() {"corn", "dark", "Corn", "rank", "CORN", "cron", "park"}
        Dim expected As String() = New String() {"cron"}
        Dim actual As IEnumerable(Of String) = detector.Match(words)
        CompareLists(expected, actual)
    End Sub

    <Fact>
    Public Sub EliminateAnagramsWithSameChecksum()
        Dim detector As New Anagram("mass")
        Dim words As String() = New String() {"last"}
        Dim expected As String() = New String(-1) {}
        Dim actual As IEnumerable(Of String) = detector.Match(words)
        CompareLists(expected, actual)
    End Sub

    <Fact>
    Public Sub EliminateAnagramSubsets()
        Dim detector As New Anagram("good")
        Dim words As String() = New String() {"dog", "goody"}
        Dim expected As String() = New String(-1) {}
        Dim actual As IEnumerable(Of String) = detector.Match(words)
        CompareLists(expected, actual)
    End Sub

    <Fact>
    Public Sub DetectAnagrams()
        Dim detector As New Anagram("allergy")
        Dim words As String() = New String() {"gallery", "ballerina", "regally", "clergy", "largely", "leading"}
        Dim expected As String() = New String() {"gallery", "largely", "regally"}
        Dim actual As IEnumerable(Of String) = detector.Match(words)
        CompareLists(expected, actual)
    End Sub

    <Fact>
    Public Sub AnagramsAreCaseInsensitive()
        Dim detector As New Anagram("Orchestra")
        Dim words As String() = New String() {"cashregister", "Carthorse", "radishes"}
        Dim expected As String() = New String() {"Carthorse"}
        Dim actual As IEnumerable(Of String) = detector.Match(words)
        CompareLists(expected, actual)
    End Sub

    Private Shared Sub CompareLists(expected As IEnumerable(Of String), actual As IEnumerable(Of String))
        'Normalize both lists (same sort order) to ensure it does not fail the tests.
        If (expected IsNot Nothing) AndAlso (actual IsNot Nothing) Then
            expected = From e In expected Order By e
            actual = From e In actual Order By e
        End If
        Assert.Equal(expected, actual)
    End Sub

End Class
