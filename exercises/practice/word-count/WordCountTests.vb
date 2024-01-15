Imports System.Collections.Generic
Imports Xunit

Public Class WordCountTests
    <Fact>
    Public Sub Count_one_word()
        Dim actual = CountWords("word")
        Dim expected = New Dictionary(Of String, Integer) From {
    {"word", 1}
}
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Count_one_of_each_word()
        Dim actual = CountWords("one of each")
        Dim expected = New Dictionary(Of String, Integer) From {
    {"one", 1},
    {"of", 1},
    {"each", 1}
}
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_occurrences_of_a_word()
        Dim actual = CountWords("one fish two fish red fish blue fish")
        Dim expected = New Dictionary(Of String, Integer) From {
    {"one", 1},
    {"fish", 4},
    {"two", 1},
    {"red", 1},
    {"blue", 1}
}
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Handles_cramped_lists()
        Dim actual = CountWords("one,two,three")
        Dim expected = New Dictionary(Of String, Integer) From {
    {"one", 1},
    {"two", 1},
    {"three", 1}
}
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Handles_expanded_lists()
        Dim actual = CountWords("one," & vbLf & "two," & vbLf & "three")
        Dim expected = New Dictionary(Of String, Integer) From {
    {"one", 1},
    {"two", 1},
    {"three", 1}
}
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ignore_punctuation()
        Dim actual = CountWords("car: carpet as java: javascript!!&@$%^&")
        Dim expected = New Dictionary(Of String, Integer) From {
    {"car", 1},
    {"carpet", 1},
    {"as", 1},
    {"java", 1},
    {"javascript", 1}
}
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Include_numbers()
        Dim actual = CountWords("testing, 1, 2 testing")
        Dim expected = New Dictionary(Of String, Integer) From {
    {"testing", 2},
    {"1", 1},
    {"2", 1}
}
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Normalize_case()
        Dim actual = CountWords("go Go GO Stop stop")
        Dim expected = New Dictionary(Of String, Integer) From {
    {"go", 3},
    {"stop", 2}
}
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub With_apostrophes()
        Dim actual = CountWords("'First: don't laugh. Then: don't cry. You're getting it.'")
        Dim expected = New Dictionary(Of String, Integer) From {
    {"first", 1},
    {"don't", 2},
    {"laugh", 1},
    {"then", 1},
    {"cry", 1},
    {"you're", 1},
    {"getting", 1},
    {"it", 1}
}
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub With_quotations()
        Dim actual = CountWords("Joe can't tell between 'large' and large.")
        Dim expected = New Dictionary(Of String, Integer) From {
    {"joe", 1},
    {"can't", 1},
    {"tell", 1},
    {"between", 1},
    {"large", 2},
    {"and", 1}
}
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Substrings_from_the_beginning()
        Dim actual = CountWords("Joe can't tell between app, apple and a.")
        Dim expected = New Dictionary(Of String, Integer) From {
    {"joe", 1},
    {"can't", 1},
    {"tell", 1},
    {"between", 1},
    {"app", 1},
    {"apple", 1},
    {"and", 1},
    {"a", 1}
}
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_spaces_not_detected_as_a_word()
        Dim actual = CountWords(" multiple   whitespaces")
        Dim expected = New Dictionary(Of String, Integer) From {
    {"multiple", 1},
    {"whitespaces", 1}
}
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Alternating_word_separators_not_detected_as_a_word()
        Dim actual = CountWords("," & vbLf & ",one," & vbLf & " ,two " & vbLf & " 'three'")
        Dim expected = New Dictionary(Of String, Integer) From {
    {"one", 1},
    {"two", 1},
    {"three", 1}
}
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Quotation_for_word_with_apostrophe()
        Dim actual = CountWords("can, can't, 'can't'")
        Dim expected = New Dictionary(Of String, Integer) From {
    {"can", 1},
    {"can't", 2}
}
        Assert.Equal(expected, actual)
    End Sub
End Class
