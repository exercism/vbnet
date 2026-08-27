Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim strand = {{ test.input.strand | vb_string_literal }}
        {{- if test.expected.error }}
        Assert.Throws(Of ArgumentException)(Function() {{ testedClass }}.{{ test.testedMethod }}(strand))
        {{- else if (array.size test.expected) == 0 }}
        Assert.Empty({{ testedClass }}.{{ test.testedMethod }}(strand))
        {{- else }}
        Dim expected = {{ test.expected | vb_literal }}
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(strand))
        {{- end }}
    End Sub
    {{ end -}}
End Class
