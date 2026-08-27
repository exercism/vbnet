{{ func count_entry
    ret "{" + (vb_string_literal $0) + "c, " + $1 + "}"
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim strand = {{ test.input.strand | vb_string_literal }}
        {{- if test.expected.error }}
        Assert.Throws(Of ArgumentException)(Function() {{ testedClass }}.Count(strand))
        {{- else }}
        Dim expected = New Dictionary(Of Char, Integer) From {
            {{- for key in test.expected | object.keys }}
            {{ count_entry key test.expected[key] }}{{ if !for.last }},{{ end }}
            {{- end }}
        }
        Assert.Equal(expected, {{ testedClass }}.Count(strand))
        {{- end }}
    End Sub
    {{ end -}}
End Class
