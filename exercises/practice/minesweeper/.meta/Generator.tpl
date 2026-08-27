Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim minefield = {{ test.input.minefield | vb_string_array_literal 2 1 }}
        {{- if (array.size test.expected) == 0 }}
        Assert.Empty({{ testedClass }}.{{ test.testedMethod }}(minefield))
        {{- else }}
        Dim expected = {{ test.expected | vb_string_array_literal 2 1 }}
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(minefield))
        {{- end }}
    End Sub
    {{ end -}}
End Class
