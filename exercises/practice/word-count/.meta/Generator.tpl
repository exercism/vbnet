{{ func count_entry
    ret "{" + (vb_string_literal $0) + ", " + $1 + "}"
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim sentence = {{ test.input.sentence | vb_string_literal }}
        Dim expected = New Dictionary(Of String, Integer) From {
            {{- for word in test.expected | object.keys }}
            {{ count_entry word test.expected[word] }}{{ if !for.last }},{{ end }}
            {{- end }}
        }

        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(sentence))
    End Sub
    {{ end -}}
End Class
