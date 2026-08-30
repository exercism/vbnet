Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim expected = {{ test.expected | vb_string_join "vbLf" 2 }}
        {{- if test.input.startVerse == test.input.endVerse }}
        Assert.Equal(expected, {{ testedClass }}.Recite({{ test.input.startVerse }}))
        {{- else }}
        Assert.Equal(expected, {{ testedClass }}.Recite({{ test.input.startVerse }}, {{ test.input.endVerse }}))
        {{- end }}
    End Sub
    {{ end -}}
End Class
