Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        {{- if (array.size test.expected) == 0 }}
        Dim expected = Array.Empty(Of Integer())()
        {{- else }}
        Dim expected = {
            {{~ for row in test.expected ~}}
            New Integer() {{ row | vb_literal }}{{ if !for.last }},{{ end }}
            {{~ end ~}}
        }
        {{- end }}
        Assert.Equal(expected, {{ testedClass }}.Calculate({{ test.input.count }}))
    End Sub
    {{ end -}}
End Class
