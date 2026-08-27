Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim value = {{ test.input.value | vb_string_literal }}
        Assert.{{ test.expected | vb_literal }}({{ testedClass }}.{{ test.testedMethod }}(value))
    End Sub
    {{ end -}}
End Class
