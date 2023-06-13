Imports Xunit
Imports FsCheck.Xunit
Imports FsCheck
Imports System
Imports System.Linq

Public Class DiamondTests
    Public ReadOnly AllLetters As Char() = GetLetterRange("A"c, "Z"c)
    Private Function Rows(ByVal x As String) As String()
        Return x.Split({ChrW(10)}, StringSplitOptions.None)
    End Function

    Private Function LeadingSpaces(ByVal x As String) As String
        Return x.Substring(0, x.IndexOfAny(AllLetters))
    End Function
    Private Function TrailingSpaces(ByVal x As String) As String
        Return x.Substring(x.LastIndexOfAny(AllLetters) + 1)
    End Function
    Private Function GetLetterRange(ByVal min As Char, ByVal max As Char) As Char()
        Return Enumerable.Range(Asc(min), Asc(max) - Asc(min) + 1).[Select](Function(i) Microsoft.VisualBasic.ChrW(i)).ToArray()
    End Function

    <DiamondProperty>
    Public Sub Diamond_is_not_empty(ByVal letter As Char)
        Dim actual = Diamond.Make(letter)

        Assert.NotEmpty(actual)
    End Sub

    <DiamondProperty(Skip:="Remove this Skip property to run this test")>
    Public Sub First_row_contains_a(ByVal letter As Char)
        Dim actual = Diamond.Make(letter)
        Dim rows = DiamondTests.Rows(actual)
        Dim firstRowCharacters = Enumerable.First(rows).Trim()

        Assert.Equal("A", firstRowCharacters)
    End Sub

    <DiamondProperty(Skip:="Remove this Skip property to run this test")>
    Public Sub All_rows_must_have_symmetric_contour(ByVal letter As Char)
        Dim actual = Diamond.Make(letter)
        Dim rows = DiamondTests.Rows(actual)

        Assert.All(rows, Sub(row) Assert.Equal(LeadingSpaces(row), TrailingSpaces(row)))
    End Sub

    <DiamondProperty(Skip:="Remove this Skip property to run this test")>
    Public Sub Top_of_figure_has_letters_in_correct_order(ByVal letter As Char)
        Dim actual = Diamond.Make(letter)
        Dim rows = DiamondTests.Rows(actual)

        Dim expected = GetLetterRange("A"c, letter)
        Dim firstNonSpaceLetters = rows.Take(expected.Length).[Select](Function(row) row.Trim()(0))

        Assert.Equal(firstNonSpaceLetters, expected)
    End Sub

    <DiamondProperty(Skip:="Remove this Skip property to run this test")>
    Public Sub Figure_is_symmetric_around_the_horizontal_axis(ByVal letter As Char)
        Dim actual = Diamond.Make(letter)

        Dim rows = DiamondTests.Rows(actual)
        Dim top = rows.TakeWhile(Function(row) Not row.Contains(letter))
        Dim bottom = rows.Reverse().TakeWhile(Function(row) Not row.Contains(letter))

        Assert.Equal(bottom, top)
    End Sub

    <DiamondProperty(Skip:="Remove this Skip property to run this test")>
    Public Sub Diamond_has_square_shape(ByVal letter As Char)
        Dim actual = Diamond.Make(letter)

        Dim rows = DiamondTests.Rows(actual)
        Dim expected = rows.Length

        Assert.All(rows, Sub(row) Assert.Equal(expected, row.Length))
    End Sub

    <DiamondProperty(Skip:="Remove this Skip property to run this test")>
    Public Sub All_rows_except_top_and_bottom_have_two_identical_letters(ByVal letter As Char)
        Dim actual = Diamond.Make(letter)

        Dim rows = DiamondTests.Rows(actual).Where(Function(row) Not row.Contains("A"c))

        Assert.All(rows, Sub(row)
                             Dim twoCharacters = row.Replace(" ", "").Length = 2
                             Dim identicalCharacters = row.Replace(" ", "").Distinct().Count() = 1
                             Assert.True(twoCharacters AndAlso identicalCharacters, "Does not have two identical letters")
                         End Sub)
    End Sub

    <DiamondProperty(Skip:="Remove this Skip property to run this test")>
    Public Sub Bottom_left_corner_spaces_are_triangle(ByVal letter As Char)
        Dim actual = Diamond.Make(letter)

        Dim rows = DiamondTests.Rows(actual)

        Dim cornerSpaces = rows.Reverse().SkipWhile(Function(row) Not row.Contains(letter)).[Select](New Func(Of String, String)(AddressOf LeadingSpaces))
        Dim spaceCounts = cornerSpaces.[Select](Function(row) row.Length).ToList()
        Dim expected = Enumerable.Range(0, spaceCounts.Count).[Select](Function(i) i).ToList()

        Assert.Equal(expected, spaceCounts)
    End Sub
End Class

Public Class DiamondPropertyAttribute
    Inherits PropertyAttribute
    Public Sub New()
        Arbitrary = {GetType(LettersOnlyStringArbitrary)}
    End Sub
End Class

Public Module LettersOnlyStringArbitrary
    Public Function Chars() As Arbitrary(Of Char)
        Return Arb.Default.Char().Filter(Function(x) x >= "A"c AndAlso x <= "Z"c)
    End Function
End Module
