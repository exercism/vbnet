Imports Xunit
Public Class MatchingBracketsTests
    <Fact>
    Public Sub PairedSquareBrackets()
        Dim value = "[]"
        Assert.True(IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub EmptyString()
        Dim value = ""
        Assert.True(IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub UnpairedBrackets()
        Dim value = "[["
        Assert.False(IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub WrongOrderedBrackets()
        Dim value = "}{"
        Assert.False(IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub WrongClosingBracket()
        Dim value = "{]"
        Assert.False(IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub PairedWithWhitespace()
        Dim value = "{ }"
        Assert.True(IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub PartiallyPairedBrackets()
        Dim value = "{[])"
        Assert.False(IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub SimpleNestedBrackets()
        Dim value = "{[]}"
        Assert.True(IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub SeveralPairedBrackets()
        Dim value = "{}[]"
        Assert.True(IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub PairedAndNestedBrackets()
        Dim value = "([{}({}[])])"
        Assert.True(IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub UnopenedClosingBrackets()
        Dim value = "{[)][]}"
        Assert.False(IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub UnpairedAndNestedBrackets()
        Dim value = "([{])"
        Assert.False(IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub PairedAndWrongNestedBrackets()
        Dim value = "[({]})"
        Assert.False(IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub PairedAndIncompleteBrackets()
        Dim value = "{}["
        Assert.False(IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub TooManyClosingBrackets()
        Dim value = "[]]"
        Assert.False(IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub MathExpression()
        Dim value = "(((185 + 223.85) * 15) - 543)/2"
        Assert.True(IsPaired(value))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub ComplexLatexExpression()
        Dim value = "\left(\begin{array}{cc} \frac{1}{3} & x\\ \mathrm{e}^{x} &... x^2 \end{array}\right)"
        Assert.True(IsPaired(value))
    End Sub
End Class