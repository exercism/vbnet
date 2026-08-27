Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim expected = {{ test.expected | vb_tuple_array_literal "(Integer, Integer, Integer)" 2 }}
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.n }}))
    End Sub
    {{ end -}}
End Class
