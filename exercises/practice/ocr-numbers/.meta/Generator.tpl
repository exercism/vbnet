Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim rows = {{ test.input.rows | vb_string_join "vbLf" 2 }}
        {{- if test.expected.error }}
        Assert.Throws(Of ArgumentException)(Function() {{ testedClass }}.{{ test.testedMethod }}(rows))
        {{- else }}
        Assert.Equal({{ test.expected | vb_string_literal }}, {{ testedClass }}.{{ test.testedMethod }}(rows))
        {{- end }}
    End Sub
    {{ end -}}
End Class
