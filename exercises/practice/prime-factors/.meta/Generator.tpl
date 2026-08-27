{{ func long_array_literal
    ret "{" + (array.join $0 "L, ") + "L}"
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        {{- if (array.size test.expected) == 0 }}
        Assert.Empty({{ testedClass }}.{{ test.testedMethod }}({{ test.input.value }}L))
        {{- else }}
        Assert.Equal({{ test.expected | long_array_literal }}, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.value }}L))
        {{- end }}
    End Sub
    {{ end -}}
End Class
