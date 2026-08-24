Public Class AnagramTests
    <Fact>
    Public Sub No_matches()
        Dim detector = New Anagram("diaper")
        Dim words = {"hello", "world", "zombies", "pants"}
        Dim expected = Array.Empty(Of String)()
        Assert.Equal(expected, detector.Match(words))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Detects_two_anagrams()
        Dim detector = New Anagram("solemn")
        Dim words = {"lemons", "cherry", "melons"}
        Dim expected = {"lemons", "melons"}
        Assert.Equal(expected, detector.Match(words))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Does_not_detect_anagram_subsets()
        Dim detector = New Anagram("good")
        Dim words = {"dog", "goody"}
        Dim expected = Array.Empty(Of String)()
        Assert.Equal(expected, detector.Match(words))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Detects_anagram()
        Dim detector = New Anagram("listen")
        Dim words = {"enlists", "google", "inlets", "banana"}
        Dim expected = {"inlets"}
        Assert.Equal(expected, detector.Match(words))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Detects_three_anagrams()
        Dim detector = New Anagram("allergy")
        Dim words = {"gallery", "ballerina", "regally", "clergy", "largely", "leading"}
        Dim expected = {"gallery", "largely", "regally"}
        Assert.Equal(expected, detector.Match(words))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Detects_multiple_anagrams_with_different_case()
        Dim detector = New Anagram("nose")
        Dim words = {"Eons", "ONES"}
        Dim expected = {"Eons", "ONES"}
        Assert.Equal(expected, detector.Match(words))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Does_not_detect_non_anagrams_with_identical_checksum()
        Dim detector = New Anagram("mass")
        Dim words = {"last"}
        Dim expected = Array.Empty(Of String)()
        Assert.Equal(expected, detector.Match(words))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Detects_anagrams_case_insensitively()
        Dim detector = New Anagram("Orchestra")
        Dim words = {"cashregister", "Carthorse", "radishes"}
        Dim expected = {"Carthorse"}
        Assert.Equal(expected, detector.Match(words))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Detects_anagrams_using_case_insensitive_subject()
        Dim detector = New Anagram("Orchestra")
        Dim words = {"cashregister", "carthorse", "radishes"}
        Dim expected = {"carthorse"}
        Assert.Equal(expected, detector.Match(words))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Detects_anagrams_using_case_insensitive_possible_matches()
        Dim detector = New Anagram("orchestra")
        Dim words = {"cashregister", "Carthorse", "radishes"}
        Dim expected = {"Carthorse"}
        Assert.Equal(expected, detector.Match(words))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Does_not_detect_an_anagram_if_the_original_word_is_repeated()
        Dim detector = New Anagram("go")
        Dim words = {"goGoGO"}
        Dim expected = Array.Empty(Of String)()
        Assert.Equal(expected, detector.Match(words))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Anagrams_must_use_all_letters_exactly_once()
        Dim detector = New Anagram("tapper")
        Dim words = {"patter"}
        Dim expected = Array.Empty(Of String)()
        Assert.Equal(expected, detector.Match(words))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Words_are_not_anagrams_of_themselves()
        Dim detector = New Anagram("BANANA")
        Dim words = {"BANANA"}
        Dim expected = Array.Empty(Of String)()
        Assert.Equal(expected, detector.Match(words))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Words_are_not_anagrams_of_themselves_even_if_letter_case_is_partially_different()
        Dim detector = New Anagram("BANANA")
        Dim words = {"Banana"}
        Dim expected = Array.Empty(Of String)()
        Assert.Equal(expected, detector.Match(words))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Words_are_not_anagrams_of_themselves_even_if_letter_case_is_completely_different()
        Dim detector = New Anagram("BANANA")
        Dim words = {"banana"}
        Dim expected = Array.Empty(Of String)()
        Assert.Equal(expected, detector.Match(words))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Words_other_than_themselves_can_be_anagrams()
        Dim detector = New Anagram("LISTEN")
        Dim words = {"LISTEN", "Silent"}
        Dim expected = {"Silent"}
        Assert.Equal(expected, detector.Match(words))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Handles_case_of_greek_letters()
        Dim detector = New Anagram("ΑΒΓ")
        Dim words = {"ΒΓΑ", "ΒΓΔ", "γβα", "αβγ"}
        Dim expected = {"ΒΓΑ", "γβα"}
        Assert.Equal(expected, detector.Match(words))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Different_characters_may_have_the_same_bytes()
        Dim detector = New Anagram("a⬂")
        Dim words = {"€a"}
        Dim expected = Array.Empty(Of String)()
        Assert.Equal(expected, detector.Match(words))
    End Sub
End Class
