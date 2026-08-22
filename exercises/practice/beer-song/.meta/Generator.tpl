Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.testMethod }}()
        Dim actual = {{ testedClass }}.{{ test.testedMethod }}({{ test.input.startBottles }}, {{ test.input.takeDown }})
        Dim expected = String.Join(vbLf, {
            {{~ for line in test.expected ~}}
            {{ line | vb_string_literal }}{{ if !for.last }},{{ end }}
            {{~ end ~}}
        })
        Assert.Equal(expected, actual)
    End Sub
    {{ end -}}
End Class
