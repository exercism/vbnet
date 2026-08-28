Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Assert.Equal({{ test.expected | vb_string_literal }}, {{ test.input.number }}.ToRoman())
    End Sub
    {{ end -}}
End Class
