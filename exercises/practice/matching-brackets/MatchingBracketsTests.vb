Public Class MatchingBracketsTests
    <Fact>
    Public Sub Paired_square_brackets()
        Dim value = "[]"
        Assert.True(MatchingBrackets.IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Empty_string()
        Dim value = ""
        Assert.True(MatchingBrackets.IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Unpaired_brackets()
        Dim value = "[["
        Assert.False(MatchingBrackets.IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Wrong_ordered_brackets()
        Dim value = "}{"
        Assert.False(MatchingBrackets.IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Wrong_closing_bracket()
        Dim value = "{]"
        Assert.False(MatchingBrackets.IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Paired_with_whitespace()
        Dim value = "{ }"
        Assert.True(MatchingBrackets.IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Partially_paired_brackets()
        Dim value = "{[])"
        Assert.False(MatchingBrackets.IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Simple_nested_brackets()
        Dim value = "{[]}"
        Assert.True(MatchingBrackets.IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Several_paired_brackets()
        Dim value = "{}[]"
        Assert.True(MatchingBrackets.IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Paired_and_nested_brackets()
        Dim value = "([{}({}[])])"
        Assert.True(MatchingBrackets.IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Unopened_closing_brackets()
        Dim value = "{[)][]}"
        Assert.False(MatchingBrackets.IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Unpaired_and_nested_brackets()
        Dim value = "([{])"
        Assert.False(MatchingBrackets.IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Paired_and_wrong_nested_brackets()
        Dim value = "[({]})"
        Assert.False(MatchingBrackets.IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Paired_and_wrong_nested_brackets_but_innermost_are_correct()
        Dim value = "[({}])"
        Assert.False(MatchingBrackets.IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Paired_and_incomplete_brackets()
        Dim value = "{}["
        Assert.False(MatchingBrackets.IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Too_many_closing_brackets()
        Dim value = "[]]"
        Assert.False(MatchingBrackets.IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Early_unexpected_brackets()
        Dim value = ")()"
        Assert.False(MatchingBrackets.IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Early_mismatched_brackets()
        Dim value = "{)()"
        Assert.False(MatchingBrackets.IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Math_expression()
        Dim value = "(((185 + 223.85) * 15) - 543)/2"
        Assert.True(MatchingBrackets.IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Complex_latex_expression()
        Dim value = "\left(\begin{array}{cc} \frac{1}{3} & x\\ \mathrm{e}^{x} &... x^2 \end{array}\right)"
        Assert.True(MatchingBrackets.IsPaired(value))
    End Sub
End Class
