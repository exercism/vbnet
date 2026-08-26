Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        {{- if test.expected.error }}
        Assert.Throws(Of ArgumentException)(Function() {{ testedClass }}.{{ test.testedMethod }}({{ test.input.strand1 | vb_string_literal }}, {{ test.input.strand2 | vb_string_literal }}))
        {{- else }}
        Assert.Equal({{ test.expected }}, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.strand1 | vb_string_literal }}, {{ test.input.strand2 | vb_string_literal }}))
        {{- end }}
    End Sub
    {{ end -}}
End Class
