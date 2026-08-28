Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        {{- if test.testedMethod == "ColorCode" }}
        Assert.Equal({{ test.expected }}, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.color | vb_string_literal }}))
        {{- else }}
        Dim expected = {{ test.expected | vb_string_array_literal 2 5 }}
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}())
        {{- end }}
    End Sub
    {{ end -}}
End Class
