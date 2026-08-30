Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim integers = {{ test.input.integers | vb_hex_uinteger_array_literal 2 8 }}
        {{- if test.expected.error }}
        Assert.Throws(Of InvalidOperationException)(Function() {{ testedClass }}.{{ test.testedMethod }}(integers))
        {{- else }}
        Dim expected = {{ test.expected | vb_hex_uinteger_array_literal 2 8 }}

        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(integers))
        {{- end }}
    End Sub
    {{ end -}}
End Class
