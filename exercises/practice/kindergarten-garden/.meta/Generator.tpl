Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim diagram = {{ test.input.diagram | vb_string_literal }}
        Dim expected = { {{~ for plant in test.expected ~}}Plant.{{ plant | pascalize }}{{ if !for.last }}, {{ end }}{{~ end ~}} }
        Assert.Equal(expected, New {{ testedClass }}(diagram).{{ test.testedMethod }}({{ test.input.student | vb_string_literal }}))
    End Sub
    {{ end -}}
End Class
