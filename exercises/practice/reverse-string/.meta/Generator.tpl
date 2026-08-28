Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Assert.Equal({{ test.expected | vb_string_literal }}, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.value | vb_string_literal }}))
    End Sub
    {{ end -}}
End Class
