Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim currency = {{ test.input.currency | vb_string_literal }}
        Dim locale = {{ test.input.locale | string.replace "_" "-" | vb_string_literal }}
        {{- if (array.size test.input.entries) == 0 }}
        Dim entries = Array.Empty(Of LedgerEntry)()
        {{- else }}
        Dim entries = {
            {{~ for entry in test.input.entries ~}}
            {{ testedClass }}.CreateEntry({{ entry.date | vb_string_literal }}, {{ entry.description | vb_string_literal }}, {{ entry.amountInCents }}){{ if !for.last }},{{ end }}
            {{~ end ~}}
        }
        {{- end }}
        {{- if (array.size test.expected) == 1 }}
        Dim expected = {{ test.expected[0] | vb_string_literal }}
        {{- else }}
        Dim expected = {{ test.expected | vb_string_join "vbLf" 2 }}
        {{- end }}
        Assert.Equal(expected, {{ testedClass }}.Format(currency, locale, entries))
    End Sub
    {{ end -}}
End Class
