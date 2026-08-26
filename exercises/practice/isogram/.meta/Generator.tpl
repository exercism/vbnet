Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Assert.{{ test.expected | vb_literal }}({{ testedClass }}.{{ test.testedMethod }}({{ test.input.phrase | vb_string_literal }}))
    End Sub
    {{ end -}}
End Class
