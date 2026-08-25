{{ func legacy_entry
    ret "{" + $0 + ", " + (vb_literal $1) + "}"
end }}

{{ func expected_entry
    ret "{" + (vb_string_literal $0) + ", " + $1 + "}"
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.testMethod }}()
        Dim input = New Dictionary(Of Integer, String()) From {
            {{- for key in test.input.legacy | object.keys }}
            {{ legacy_entry key test.input.legacy[key] }}{{ if !for.last }},{{ end }}
            {{- end }}
        }
        Dim expected = New Dictionary(Of String, Integer) From {
            {{- for key in test.expected | object.keys }}
            {{ expected_entry key test.expected[key] }}{{ if !for.last }},{{ end }}
            {{- end }}
        }
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(input))
    End Sub
    {{ end -}}
End Class
