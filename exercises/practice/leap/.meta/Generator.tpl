Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Assert.{{ test.expected | vb_literal }}({{ testedClass }}.IsLeapYear({{ test.input.year }}))
    End Sub
    {{ end -}}
End Class
