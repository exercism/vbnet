Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim digits = {{ test.input.digits | vb_string_literal }}
        {{- if test.expected.error }}
        Assert.Throws(Of ArgumentException)(Function() {{ testedClass }}.GetLargestProduct(digits, {{ test.input.span }}))
        {{- else }}
        Assert.Equal({{ test.expected }}, {{ testedClass }}.GetLargestProduct(digits, {{ test.input.span }}))
        {{- end }}
    End Sub
    {{ end -}}
End Class
