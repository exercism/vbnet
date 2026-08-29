Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        {{- if test.expected.error }}
        Assert.Throws(Of ArgumentException)(Function() {{ testedClass }}.{{ test.testedMethod }}({{ test.input.series | vb_string_literal }}, {{ test.input.sliceLength }}))
        {{- else }}
        Dim expected = {{ test.expected | vb_string_array_literal 2 4 }}
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.series | vb_string_literal }}, {{ test.input.sliceLength }}))
        {{- end }}
    End Sub
    {{ end -}}
End Class
