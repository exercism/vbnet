Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        {{- if (array.size test.expected) == 0 }}
        Assert.Empty({{ testedClass }}.GetMatrix({{ test.input.size }}))
        {{- else }}
        Dim expected = {{ test.expected | vb_multiline_array_literal 2 1 }}
        Assert.Equal(expected, {{ testedClass }}.GetMatrix({{ test.input.size }}))
        {{- end }}
    End Sub
    {{ end -}}
End Class
