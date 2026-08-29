Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim expected = {{ test.expected | vb_string_array_literal 2 8 }}
        {{- if test.property == "chromatic" }}
        Assert.Equal(expected, {{ testedClass }}.Chromatic({{ test.input.tonic | vb_string_literal }}))
        {{- else }}
        Assert.Equal(expected, {{ testedClass }}.Interval({{ test.input.tonic | vb_string_literal }}, {{ test.input.intervals | vb_string_literal }}))
        {{- end }}
    End Sub
    {{ end -}}
End Class
