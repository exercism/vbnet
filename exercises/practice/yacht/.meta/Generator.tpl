Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim result = YachtGame.Score(
            {{ test.input.dice | vb_integer_array_literal }},
            {{ test.input.category | enum "YachtCategory" }})

        Assert.Equal({{ test.expected }}, result)
    End Sub
    {{ end -}}
End Class
