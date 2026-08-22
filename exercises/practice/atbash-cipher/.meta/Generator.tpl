Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim actual = {{ testedClass }}.{{ test.testedMethod }}({{ test.input.phrase | vb_string_literal }})
        Dim expected = {{ test.expected | vb_string_literal }}
        Assert.Equal(expected, actual)
    End Sub
    {{ end -}}
End Class
