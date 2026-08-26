Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        {{- if (array.size test.expected) == 1 }}
        Dim expected = {{ test.expected[0] | vb_string_literal }}
        {{- else }}
        Dim expected = {{ test.expected | vb_string_join "vbLf" 2 }}
        {{- end }}
        {{- if test.input.startVerse == test.input.endVerse }}
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.startVerse }}))
        {{- else }}
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.startVerse }}, {{ test.input.endVerse }}))
        {{- end }}
    End Sub
    {{ end -}}
End Class
