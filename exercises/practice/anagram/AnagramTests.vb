Imports Xunit

Public Class AnagramTest

    <Fact>
    Public Sub NoMatches()
        Dim detector As New AnagramChecker("diaper")
        Dim words As String() = New String() {"hello", "world", "zombies", "pants"}
        Dim expected As String() = EmptyArray
        Dim actual As IEnumerable(Of String) = detector.Match(words)
        CompareLists(expected, actual)
    End Sub

    <Fact>
    Public Sub DetectSimpleAnagram()
        Dim detector As New AnagramChecker("ant")
        Dim words As String() = New String() {"tan", "stand", "at"}
        Dim expected As String() = New String() {"tan"}
        Dim actual As IEnumerable(Of String) = detector.Match(words)
        CompareLists(expected, actual)
    End Sub

    <Fact>
    Public Sub DetectMultipleAnagrams()
        Dim detector As New AnagramChecker("master")
        Dim words As String() = New String() {"stream", "pigeon", "maters"}
        Dim expected As String() = New String() {"maters", "stream"}
        Dim actual As IEnumerable(Of String) = detector.Match(words)
        CompareLists(expected, actual)
    End Sub

    <Fact>
    Public Sub DoesNotConfuseDifferentDuplicates()
        Dim detector As New AnagramChecker("galea")
        Dim words As String() = New String() {"eagle"}
        Dim expected As String() = EmptyArray
        Dim actual As IEnumerable(Of String) = detector.Match(words)
        CompareLists(expected, actual)
    End Sub

    <Fact>
    Public Sub IdenticalWordIsNotAnagram()
        Dim detector As New AnagramChecker("corn")
        Dim words As String() = New String() {"corn", "dark", "Corn", "rank", "CORN", "cron", "park"}
        Dim expected As String() = New String() {"cron"}
        Dim actual As IEnumerable(Of String) = detector.Match(words)
        CompareLists(expected, actual)
    End Sub

    <Fact>
    Public Sub EliminateAnagramsWithSameChecksum()
        Dim detector As New AnagramChecker("mass")
        Dim words As String() = New String() {"last"}
        Dim expected As String() = EmptyArray
        Dim actual As IEnumerable(Of String) = detector.Match(words)
        CompareLists(expected, actual)
    End Sub

    <Fact>
    Public Sub EliminateAnagramSubsets()
        Dim detector As New AnagramChecker("good")
        Dim words As String() = New String() {"dog", "goody"}
        Dim expected As String() = EmptyArray
        Dim actual As IEnumerable(Of String) = detector.Match(words)
        CompareLists(expected, actual)
    End Sub

    <Fact>
    Public Sub DetectAnagrams()
        Dim detector As New AnagramChecker("allergy")
        Dim words As String() = New String() {"gallery", "ballerina", "regally", "clergy", "largely", "leading"}
        Dim expected As String() = New String() {"gallery", "largely", "regally"}
        Dim actual As IEnumerable(Of String) = detector.Match(words)
        CompareLists(expected, actual)
    End Sub

    <Fact>
    Public Sub AnagramsAreCaseInsensitive()
        Dim detector As New AnagramChecker("Orchestra")
        Dim words As String() = New String() {"cashregister", "Carthorse", "radishes"}
        Dim expected As String() = New String() {"Carthorse"}
        Dim actual As IEnumerable(Of String) = detector.Match(words)
        CompareLists(expected, actual)
    End Sub

    <Fact>
    Public Sub AnagramsAreWhiteSpaceAgnostic()
        Dim detector As New AnagramChecker("Hello Exercism")
        Dim words As String() = New String() {"Hello Exercism", "Heroes Cell Mix", "foo"}
        Dim expected As String() = New String() {"Heroes Cell Mix"}
        Dim actual As IEnumerable(Of String) = detector.Match(words)
        CompareLists(expected, actual)
    End Sub

    <Fact>
    Public Sub DuplicateAnagramsAreReturned()
        Dim detector As New AnagramChecker("Software")
        Dim words As String() = New String() {"sweat for", "waste for", "sweat for", "Sweat For"}
        Dim expected As String() = New String() {"sweat for", "waste for", "sweat for", "Sweat For"}
        Dim actual As IEnumerable(Of String) = detector.Match(words)
        CompareLists(expected, actual)
    End Sub

    <Fact>
    Public Sub AnagramsAreReturnedTheSameWayTheyCameIn()
        Dim detector As New AnagramChecker("allergy")
        Dim words As String() = New String() {"GaLlErY", "ballerina", "re gally", "clergy", "   largely  ", "  leading  ", "   "}
        Dim expected As String() = New String() {"GaLlErY", "   largely  ", "re gally"}
        Dim actual As IEnumerable(Of String) = detector.Match(words)
        CompareLists(expected, actual)
    End Sub

    <Fact>
    Public Sub NullInConstructorThrowsArgumentNullException()
        Dim detector As AnagramChecker
        'Null throws
        Dim action As Action =
            Sub()
                detector = New AnagramChecker(Nothing)
            End Sub
        Assert.Throws(Of ArgumentNullException)(action)
        'Empty and white-space don't
        detector = New AnagramChecker(String.Empty)
        detector = New AnagramChecker("     ")
    End Sub

    <Fact>
    Public Sub NullCollectionIsIgnored()
        Dim words As String()
        Dim actual As IEnumerable(Of String)
        Dim detector As New AnagramChecker("Orchestra")
        Dim expected As String() = EmptyArray

        words = Nothing
        actual = detector.Match(words)
        CompareLists(expected, actual)

        words = EmptyArray
        actual = detector.Match(words)
        CompareLists(expected, actual)
    End Sub

    <Fact>
    Public Sub NullInCollectionIsIgnored()
        Dim detector As New AnagramChecker("Orchestra")
        Dim words As String() = New String() {Nothing, "cashregister", Nothing, "Carthorse", "", "radishes", Nothing, "   "}
        Dim expected As String() = New String() {"Carthorse"}
        Dim actual As IEnumerable(Of String) = detector.Match(words)
        CompareLists(expected, actual)
    End Sub

    <Fact>
    Public Sub OtherEnumerablesThanArrayWorkAsExpected()
        Dim detector As New AnagramChecker("master")
        Dim words As IEnumerable(Of String) = MasterAnagrams
        Dim expected As String() = New String() {"maters", "stream"}
        Dim actual As IEnumerable(Of String)

        actual = detector.Match(words)
        CompareLists(expected, actual)

        actual = detector.Match(words.ToList())
        CompareLists(expected, actual)

        actual = detector.Match(words.ToHashSet())
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

    Private Shared ReadOnly Iterator Property MasterAnagrams As IEnumerable(Of String)
        Get
            Yield "stream"
            Yield "pigeon"
            Yield "maters"
        End Get
    End Property

    Private Shared ReadOnly EmptyArray As String() = Array.Empty(Of String)()

End Class
