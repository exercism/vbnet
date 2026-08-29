Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.testMethod }}()
        Dim input = {{ test.input.string | vb_string_literal }}
        Dim expected = {{ test.expected | vb_string_literal }}
        {{- if test.property == "consistency" }}
        Assert.Equal(expected, {{ testedClass }}.Decode({{ testedClass }}.Encode(input)))
        {{- else }}
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(input))
        {{- end }}
    End Sub
    {{ end -}}
End Class
