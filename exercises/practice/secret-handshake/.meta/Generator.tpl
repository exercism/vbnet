Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        {{- if (array.size test.expected) == 0 }}
        Assert.Empty({{ testedClass }}.{{ test.testedMethod }}({{ test.input.number }}))
        {{- else }}
        Dim expected = {{ test.expected | vb_string_array_literal 2 4 }}
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.number }}))
        {{- end }}
    End Sub
    {{ end -}}
End Class
