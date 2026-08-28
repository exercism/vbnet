Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim text = {{ test.input.text | vb_string_literal }}
        Dim expected = {{ test.expected | vb_string_literal }}
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(text, {{ test.input.shiftKey }}))
    End Sub
    {{ end -}}
End Class
