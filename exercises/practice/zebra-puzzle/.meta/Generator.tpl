Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Assert.Equal({{ test.expected | enum "Nationality" }}, {{ testedClass }}.{{ test.testedMethod }}())
    End Sub
    {{ end -}}
End Class
