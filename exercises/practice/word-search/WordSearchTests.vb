Imports System.Collections.Generic
Imports Xunit

Public Class WordSearchTests
    <Fact>
    Public Sub Should_accept_an_initial_game_grid_and_a_target_search_word()
        Dim wordsToSearchFor = {"clojure"}
        Dim grid = "jefblpepre"
        Dim sut = New WordSearch(grid)
        Dim actual = sut.Search(wordsToSearchFor)
        Dim expected = New Dictionary(Of String, ((Integer, Integer), (Integer, Integer))?) From {
    {"clojure", Nothing}
}
        Assert.Equal(expected("clojure"), actual("clojure"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Should_locate_one_word_written_left_to_right()
        Dim wordsToSearchFor = {"clojure"}
        Dim grid = "clojurermt"
        Dim sut = New WordSearch(grid)
        Dim actual = sut.Search(wordsToSearchFor)
        Dim expected = New Dictionary(Of String, ((Integer, Integer), (Integer, Integer))?) From {
    {"clojure", ((1, 1), (7, 1))}
}
        Assert.Equal(expected("clojure"), actual("clojure"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Should_locate_the_same_word_written_left_to_right_in_a_different_position()
        Dim wordsToSearchFor = {"clojure"}
        Dim grid = "mtclojurer"
        Dim sut = New WordSearch(grid)
        Dim actual = sut.Search(wordsToSearchFor)
        Dim expected = New Dictionary(Of String, ((Integer, Integer), (Integer, Integer))?) From {
    {"clojure", ((3, 1), (9, 1))}
}
        Assert.Equal(expected("clojure"), actual("clojure"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Should_locate_a_different_left_to_right_word()
        Dim wordsToSearchFor = {"coffee"}
        Dim grid = "coffeelplx"
        Dim sut = New WordSearch(grid)
        Dim actual = sut.Search(wordsToSearchFor)
        Dim expected = New Dictionary(Of String, ((Integer, Integer), (Integer, Integer))?) From {
    {"coffee", ((1, 1), (6, 1))}
}
        Assert.Equal(expected("coffee"), actual("coffee"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Should_locate_that_different_left_to_right_word_in_a_different_position()
        Dim wordsToSearchFor = {"coffee"}
        Dim grid = "xcoffeezlp"
        Dim sut = New WordSearch(grid)
        Dim actual = sut.Search(wordsToSearchFor)
        Dim expected = New Dictionary(Of String, ((Integer, Integer), (Integer, Integer))?) From {
    {"coffee", ((2, 1), (7, 1))}
}
        Assert.Equal(expected("coffee"), actual("coffee"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Should_locate_a_left_to_right_word_in_two_line_grid()
        Dim wordsToSearchFor = {"clojure"}
        Dim grid = "jefblpepre" & vbLf & "tclojurerm"
        Dim sut = New WordSearch(grid)
        Dim actual = sut.Search(wordsToSearchFor)
        Dim expected = New Dictionary(Of String, ((Integer, Integer), (Integer, Integer))?) From {
    {"clojure", ((2, 2), (8, 2))}
}
        Assert.Equal(expected("clojure"), actual("clojure"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Should_locate_a_left_to_right_word_in_three_line_grid()
        Dim wordsToSearchFor = {"clojure"}
        Dim grid = "camdcimgtc" & vbLf & "jefblpepre" & vbLf & "clojurermt"
        Dim sut = New WordSearch(grid)
        Dim actual = sut.Search(wordsToSearchFor)
        Dim expected = New Dictionary(Of String, ((Integer, Integer), (Integer, Integer))?) From {
    {"clojure", ((1, 3), (7, 3))}
}
        Assert.Equal(expected("clojure"), actual("clojure"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Should_locate_a_left_to_right_word_in_ten_line_grid()
        Dim wordsToSearchFor = {"clojure"}
        Dim grid = "jefblpepre" & vbLf & "camdcimgtc" & vbLf & "oivokprjsm" & vbLf & "pbwasqroua" & vbLf & "rixilelhrs" & vbLf & "wolcqlirpc" & vbLf & "screeaumgr" & vbLf & "alxhpburyi" & vbLf & "jalaycalmp" & vbLf & "clojurermt"
        Dim sut = New WordSearch(grid)
        Dim actual = sut.Search(wordsToSearchFor)
        Dim expected = New Dictionary(Of String, ((Integer, Integer), (Integer, Integer))?) From {
    {"clojure", ((1, 10), (7, 10))}
}
        Assert.Equal(expected("clojure"), actual("clojure"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Should_locate_that_left_to_right_word_in_a_different_position_in_a_ten_line_grid()
        Dim wordsToSearchFor = {"clojure"}
        Dim grid = "jefblpepre" & vbLf & "camdcimgtc" & vbLf & "oivokprjsm" & vbLf & "pbwasqroua" & vbLf & "rixilelhrs" & vbLf & "wolcqlirpc" & vbLf & "screeaumgr" & vbLf & "alxhpburyi" & vbLf & "clojurermt" & vbLf & "jalaycalmp"
        Dim sut = New WordSearch(grid)
        Dim actual = sut.Search(wordsToSearchFor)
        Dim expected = New Dictionary(Of String, ((Integer, Integer), (Integer, Integer))?) From {
    {"clojure", ((1, 9), (7, 9))}
}
        Assert.Equal(expected("clojure"), actual("clojure"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Should_locate_a_different_left_to_right_word_in_a_ten_line_grid()
        Dim wordsToSearchFor = {"fortran"}
        Dim grid = "jefblpepre" & vbLf & "camdcimgtc" & vbLf & "oivokprjsm" & vbLf & "pbwasqroua" & vbLf & "rixilelhrs" & vbLf & "wolcqlirpc" & vbLf & "fortranftw" & vbLf & "alxhpburyi" & vbLf & "clojurermt" & vbLf & "jalaycalmp"
        Dim sut = New WordSearch(grid)
        Dim actual = sut.Search(wordsToSearchFor)
        Dim expected = New Dictionary(Of String, ((Integer, Integer), (Integer, Integer))?) From {
    {"fortran", ((1, 7), (7, 7))}
}
        Assert.Equal(expected("fortran"), actual("fortran"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Should_locate_multiple_words()
        Dim wordsToSearchFor = {"fortran", "clojure"}
        Dim grid = "jefblpepre" & vbLf & "camdcimgtc" & vbLf & "oivokprjsm" & vbLf & "pbwasqroua" & vbLf & "rixilelhrs" & vbLf & "wolcqlirpc" & vbLf & "fortranftw" & vbLf & "alxhpburyi" & vbLf & "jalaycalmp" & vbLf & "clojurermt"
        Dim sut = New WordSearch(grid)
        Dim actual = sut.Search(wordsToSearchFor)
        Dim expected = New Dictionary(Of String, ((Integer, Integer), (Integer, Integer))?) From {
    {"clojure", ((1, 10), (7, 10))},
    {"fortran", ((1, 7), (7, 7))}
}
        Assert.Equal(expected("clojure"), actual("clojure"))
        Assert.Equal(expected("fortran"), actual("fortran"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Should_locate_a_single_word_written_right_to_left()
        Dim wordsToSearchFor = {"elixir"}
        Dim grid = "rixilelhrs"
        Dim sut = New WordSearch(grid)
        Dim actual = sut.Search(wordsToSearchFor)
        Dim expected = New Dictionary(Of String, ((Integer, Integer), (Integer, Integer))?) From {
    {"elixir", ((6, 1), (1, 1))}
}
        Assert.Equal(expected("elixir"), actual("elixir"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Should_locate_multiple_words_written_in_different_horizontal_directions()
        Dim wordsToSearchFor = {"elixir", "clojure"}
        Dim grid = "jefblpepre" & vbLf & "camdcimgtc" & vbLf & "oivokprjsm" & vbLf & "pbwasqroua" & vbLf & "rixilelhrs" & vbLf & "wolcqlirpc" & vbLf & "screeaumgr" & vbLf & "alxhpburyi" & vbLf & "jalaycalmp" & vbLf & "clojurermt"
        Dim sut = New WordSearch(grid)
        Dim actual = sut.Search(wordsToSearchFor)
        Dim expected = New Dictionary(Of String, ((Integer, Integer), (Integer, Integer))?) From {
    {"clojure", ((1, 10), (7, 10))},
    {"elixir", ((6, 5), (1, 5))}
}
        Assert.Equal(expected("clojure"), actual("clojure"))
        Assert.Equal(expected("elixir"), actual("elixir"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Should_locate_words_written_top_to_bottom()
        Dim wordsToSearchFor = {"clojure", "elixir", "ecmascript"}
        Dim grid = "jefblpepre" & vbLf & "camdcimgtc" & vbLf & "oivokprjsm" & vbLf & "pbwasqroua" & vbLf & "rixilelhrs" & vbLf & "wolcqlirpc" & vbLf & "screeaumgr" & vbLf & "alxhpburyi" & vbLf & "jalaycalmp" & vbLf & "clojurermt"
        Dim sut = New WordSearch(grid)
        Dim actual = sut.Search(wordsToSearchFor)
        Dim expected = New Dictionary(Of String, ((Integer, Integer), (Integer, Integer))?) From {
    {"clojure", ((1, 10), (7, 10))},
    {"elixir", ((6, 5), (1, 5))},
    {"ecmascript", ((10, 1), (10, 10))}
}
        Assert.Equal(expected("clojure"), actual("clojure"))
        Assert.Equal(expected("elixir"), actual("elixir"))
        Assert.Equal(expected("ecmascript"), actual("ecmascript"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Should_locate_words_written_bottom_to_top()
        Dim wordsToSearchFor = {"clojure", "elixir", "ecmascript", "rust"}
        Dim grid = "jefblpepre" & vbLf & "camdcimgtc" & vbLf & "oivokprjsm" & vbLf & "pbwasqroua" & vbLf & "rixilelhrs" & vbLf & "wolcqlirpc" & vbLf & "screeaumgr" & vbLf & "alxhpburyi" & vbLf & "jalaycalmp" & vbLf & "clojurermt"
        Dim sut = New WordSearch(grid)
        Dim actual = sut.Search(wordsToSearchFor)
        Dim expected = New Dictionary(Of String, ((Integer, Integer), (Integer, Integer))?) From {
    {"clojure", ((1, 10), (7, 10))},
    {"elixir", ((6, 5), (1, 5))},
    {"ecmascript", ((10, 1), (10, 10))},
    {"rust", ((9, 5), (9, 2))}
}
        Assert.Equal(expected("clojure"), actual("clojure"))
        Assert.Equal(expected("elixir"), actual("elixir"))
        Assert.Equal(expected("ecmascript"), actual("ecmascript"))
        Assert.Equal(expected("rust"), actual("rust"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Should_locate_words_written_top_left_to_bottom_right()
        Dim wordsToSearchFor = {"clojure", "elixir", "ecmascript", "rust", "java"}
        Dim grid = "jefblpepre" & vbLf & "camdcimgtc" & vbLf & "oivokprjsm" & vbLf & "pbwasqroua" & vbLf & "rixilelhrs" & vbLf & "wolcqlirpc" & vbLf & "screeaumgr" & vbLf & "alxhpburyi" & vbLf & "jalaycalmp" & vbLf & "clojurermt"
        Dim sut = New WordSearch(grid)
        Dim actual = sut.Search(wordsToSearchFor)
        Dim expected = New Dictionary(Of String, ((Integer, Integer), (Integer, Integer))?) From {
    {"clojure", ((1, 10), (7, 10))},
    {"elixir", ((6, 5), (1, 5))},
    {"ecmascript", ((10, 1), (10, 10))},
    {"rust", ((9, 5), (9, 2))},
    {"java", ((1, 1), (4, 4))}
}
        Assert.Equal(expected("clojure"), actual("clojure"))
        Assert.Equal(expected("elixir"), actual("elixir"))
        Assert.Equal(expected("ecmascript"), actual("ecmascript"))
        Assert.Equal(expected("rust"), actual("rust"))
        Assert.Equal(expected("java"), actual("java"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Should_locate_words_written_bottom_right_to_top_left()
        Dim wordsToSearchFor = {"clojure", "elixir", "ecmascript", "rust", "java", "lua"}
        Dim grid = "jefblpepre" & vbLf & "camdcimgtc" & vbLf & "oivokprjsm" & vbLf & "pbwasqroua" & vbLf & "rixilelhrs" & vbLf & "wolcqlirpc" & vbLf & "screeaumgr" & vbLf & "alxhpburyi" & vbLf & "jalaycalmp" & vbLf & "clojurermt"
        Dim sut = New WordSearch(grid)
        Dim actual = sut.Search(wordsToSearchFor)
        Dim expected = New Dictionary(Of String, ((Integer, Integer), (Integer, Integer))?) From {
    {"clojure", ((1, 10), (7, 10))},
    {"elixir", ((6, 5), (1, 5))},
    {"ecmascript", ((10, 1), (10, 10))},
    {"rust", ((9, 5), (9, 2))},
    {"java", ((1, 1), (4, 4))},
    {"lua", ((8, 9), (6, 7))}
}
        Assert.Equal(expected("clojure"), actual("clojure"))
        Assert.Equal(expected("elixir"), actual("elixir"))
        Assert.Equal(expected("ecmascript"), actual("ecmascript"))
        Assert.Equal(expected("rust"), actual("rust"))
        Assert.Equal(expected("java"), actual("java"))
        Assert.Equal(expected("lua"), actual("lua"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Should_locate_words_written_bottom_left_to_top_right()
        Dim wordsToSearchFor = {"clojure", "elixir", "ecmascript", "rust", "java", "lua", "lisp"}
        Dim grid = "jefblpepre" & vbLf & "camdcimgtc" & vbLf & "oivokprjsm" & vbLf & "pbwasqroua" & vbLf & "rixilelhrs" & vbLf & "wolcqlirpc" & vbLf & "screeaumgr" & vbLf & "alxhpburyi" & vbLf & "jalaycalmp" & vbLf & "clojurermt"
        Dim sut = New WordSearch(grid)
        Dim actual = sut.Search(wordsToSearchFor)
        Dim expected = New Dictionary(Of String, ((Integer, Integer), (Integer, Integer))?) From {
    {"clojure", ((1, 10), (7, 10))},
    {"elixir", ((6, 5), (1, 5))},
    {"ecmascript", ((10, 1), (10, 10))},
    {"rust", ((9, 5), (9, 2))},
    {"java", ((1, 1), (4, 4))},
    {"lua", ((8, 9), (6, 7))},
    {"lisp", ((3, 6), (6, 3))}
}
        Assert.Equal(expected("clojure"), actual("clojure"))
        Assert.Equal(expected("elixir"), actual("elixir"))
        Assert.Equal(expected("ecmascript"), actual("ecmascript"))
        Assert.Equal(expected("rust"), actual("rust"))
        Assert.Equal(expected("java"), actual("java"))
        Assert.Equal(expected("lua"), actual("lua"))
        Assert.Equal(expected("lisp"), actual("lisp"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Should_locate_words_written_top_right_to_bottom_left()
        Dim wordsToSearchFor = {"clojure", "elixir", "ecmascript", "rust", "java", "lua", "lisp", "ruby"}
        Dim grid = "jefblpepre" & vbLf & "camdcimgtc" & vbLf & "oivokprjsm" & vbLf & "pbwasqroua" & vbLf & "rixilelhrs" & vbLf & "wolcqlirpc" & vbLf & "screeaumgr" & vbLf & "alxhpburyi" & vbLf & "jalaycalmp" & vbLf & "clojurermt"
        Dim sut = New WordSearch(grid)
        Dim actual = sut.Search(wordsToSearchFor)
        Dim expected = New Dictionary(Of String, ((Integer, Integer), (Integer, Integer))?) From {
    {"clojure", ((1, 10), (7, 10))},
    {"elixir", ((6, 5), (1, 5))},
    {"ecmascript", ((10, 1), (10, 10))},
    {"rust", ((9, 5), (9, 2))},
    {"java", ((1, 1), (4, 4))},
    {"lua", ((8, 9), (6, 7))},
    {"lisp", ((3, 6), (6, 3))},
    {"ruby", ((8, 6), (5, 9))}
}
        Assert.Equal(expected("clojure"), actual("clojure"))
        Assert.Equal(expected("elixir"), actual("elixir"))
        Assert.Equal(expected("ecmascript"), actual("ecmascript"))
        Assert.Equal(expected("rust"), actual("rust"))
        Assert.Equal(expected("java"), actual("java"))
        Assert.Equal(expected("lua"), actual("lua"))
        Assert.Equal(expected("lisp"), actual("lisp"))
        Assert.Equal(expected("ruby"), actual("ruby"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Should_fail_to_locate_a_word_that_is_not_in_the_puzzle()
        Dim wordsToSearchFor = {"clojure", "elixir", "ecmascript", "rust", "java", "lua", "lisp", "ruby", "haskell"}
        Dim grid = "jefblpepre" & vbLf & "camdcimgtc" & vbLf & "oivokprjsm" & vbLf & "pbwasqroua" & vbLf & "rixilelhrs" & vbLf & "wolcqlirpc" & vbLf & "screeaumgr" & vbLf & "alxhpburyi" & vbLf & "jalaycalmp" & vbLf & "clojurermt"
        Dim sut = New WordSearch(grid)
        Dim actual = sut.Search(wordsToSearchFor)
        Dim expected = New Dictionary(Of String, ((Integer, Integer), (Integer, Integer))?) From {
    {"clojure", ((1, 10), (7, 10))},
    {"elixir", ((6, 5), (1, 5))},
    {"ecmascript", ((10, 1), (10, 10))},
    {"rust", ((9, 5), (9, 2))},
    {"java", ((1, 1), (4, 4))},
    {"lua", ((8, 9), (6, 7))},
    {"lisp", ((3, 6), (6, 3))},
    {"ruby", ((8, 6), (5, 9))},
    {"haskell", Nothing}
}
        Assert.Equal(expected("clojure"), actual("clojure"))
        Assert.Equal(expected("elixir"), actual("elixir"))
        Assert.Equal(expected("ecmascript"), actual("ecmascript"))
        Assert.Equal(expected("rust"), actual("rust"))
        Assert.Equal(expected("java"), actual("java"))
        Assert.Equal(expected("lua"), actual("lua"))
        Assert.Equal(expected("lisp"), actual("lisp"))
        Assert.Equal(expected("ruby"), actual("ruby"))
        Assert.Equal(expected("haskell"), actual("haskell"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Should_fail_to_locate_words_that_are_not_on_horizontal_vertical_or_diagonal_lines()
        Dim wordsToSearchFor = {"aef", "ced", "abf", "cbd"}
        Dim grid = "abc" & vbLf & "def"
        Dim sut = New WordSearch(grid)
        Dim actual = sut.Search(wordsToSearchFor)
        Dim expected = New Dictionary(Of String, ((Integer, Integer), (Integer, Integer))?) From {
    {"aef", Nothing},
    {"ced", Nothing},
    {"abf", Nothing},
    {"cbd", Nothing}
}
        Assert.Equal(expected("aef"), actual("aef"))
        Assert.Equal(expected("ced"), actual("ced"))
        Assert.Equal(expected("abf"), actual("abf"))
        Assert.Equal(expected("cbd"), actual("cbd"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Should_not_concatenate_different_lines_to_find_a_horizontal_word()
        Dim wordsToSearchFor = {"elixir"}
        Dim grid = "abceli" & vbLf & "xirdfg"
        Dim sut = New WordSearch(grid)
        Dim actual = sut.Search(wordsToSearchFor)
        Dim expected = New Dictionary(Of String, ((Integer, Integer), (Integer, Integer))?) From {
    {"elixir", Nothing}
}
        Assert.Equal(expected("elixir"), actual("elixir"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Should_not_wrap_around_horizontally_to_find_a_word()
        Dim wordsToSearchFor = {"lisp"}
        Dim grid = "silabcdefp"
        Dim sut = New WordSearch(grid)
        Dim actual = sut.Search(wordsToSearchFor)
        Dim expected = New Dictionary(Of String, ((Integer, Integer), (Integer, Integer))?) From {
    {"lisp", Nothing}
}
        Assert.Equal(expected("lisp"), actual("lisp"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Should_not_wrap_around_vertically_to_find_a_word()
        Dim wordsToSearchFor = {"rust"}
        Dim grid = "s" & vbLf & "u" & vbLf & "r" & vbLf & "a" & vbLf & "b" & vbLf & "c" & vbLf & "t"
        Dim sut = New WordSearch(grid)
        Dim actual = sut.Search(wordsToSearchFor)
        Dim expected = New Dictionary(Of String, ((Integer, Integer), (Integer, Integer))?) From {
    {"rust", Nothing}
}
        Assert.Equal(expected("rust"), actual("rust"))
    End Sub
End Class
