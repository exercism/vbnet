Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim expected = {{ test.expected | vb_string_literal }}
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.name | vb_string_literal }}, {{ test.input.number }}))
    End Sub
    {{ end -}}
End Class
