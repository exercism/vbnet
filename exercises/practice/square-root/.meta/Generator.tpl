Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Assert.Equal({{ test.expected }}, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.radicand }}))
    End Sub
    {{ end -}}
End Class
