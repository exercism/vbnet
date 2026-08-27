Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim strings = {{ test.input.strings | vb_string_array_literal 2 7 }}
        Dim expected = {{ test.expected | vb_string_array_literal 2 1 }}
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(strings))
    End Sub
    {{ end -}}
End Class
