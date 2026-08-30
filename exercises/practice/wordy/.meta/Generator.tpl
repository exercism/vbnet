Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim question = {{ test.input.question | vb_string_literal }}
        {{- if test.expected.error }}
        Assert.Throws(Of ArgumentException)(Function() {{ testedClass }}.{{ test.testedMethod }}(question))
        {{- else }}
        Assert.Equal({{ test.expected }}, {{ testedClass }}.{{ test.testedMethod }}(question))
        {{- end }}
    End Sub
    {{ end -}}
End Class
