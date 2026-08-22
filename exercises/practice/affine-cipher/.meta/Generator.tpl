Public Class {{ testClass }}
    {{- for test in tests }}
    <Fact{{ if !for.first }}(Skip:="Remove this Skip property to run this test"){{ end }}>
    Public Sub {{ test.shortTestMethod }}()
        {{- if test.expected.error }}
        Assert.Throws(Of ArgumentException)(Function() {{ test.testedMethod }}({{ test.input.phrase | vb_string_literal }}, {{ test.input.key.a }}, {{ test.input.key.b }}))
        {{- else }}
        Dim actual = {{ test.testedMethod }}({{ test.input.phrase | vb_string_literal }}, {{ test.input.key.a }}, {{ test.input.key.b }})
        Dim expected = {{ test.expected | vb_string_literal }}
        Assert.Equal(expected, actual)
        {{- end }}
    End Sub
    {{ end -}}
End Class
