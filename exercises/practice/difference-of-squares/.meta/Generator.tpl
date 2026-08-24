Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Assert.Equal({{ test.expected }}, {{ testedClass }}.Calculate{{ test.testedMethod }}({{ test.input.number }}))
    End Sub
    {{ end -}}
End Class
