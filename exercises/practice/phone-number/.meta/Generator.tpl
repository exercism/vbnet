Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim phrase = {{ test.input.phrase | vb_string_literal }}
        {{- if test.expected.error }}
        Assert.Throws(Of ArgumentException)(Function() {{ testedClass }}.{{ test.testedMethod }}(phrase))
        {{- else }}
        Assert.Equal({{ test.expected | vb_string_literal }}, {{ testedClass }}.{{ test.testedMethod }}(phrase))
        {{- end }}
    End Sub
    {{ end -}}
End Class
