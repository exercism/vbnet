Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim number = {{ test.input.value | vb_string_literal }}
        Assert.{{ test.expected | vb_literal }}({{ testedClass }}.IsValid(number))
    End Sub
    {{ end -}}
End Class
