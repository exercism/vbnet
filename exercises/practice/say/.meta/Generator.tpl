Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        {{- if test.expected.error }}
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() {{ testedClass }}.InEnglish({{ test.input.number }}L))
        {{- else }}
        Dim expected = {{ test.expected | vb_string_literal }}
        Assert.Equal(expected, {{ testedClass }}.InEnglish({{ test.input.number }}L))
        {{- end }}
    End Sub
    {{ end -}}
End Class
