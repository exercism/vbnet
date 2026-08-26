Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        {{- if test.expected.error }}
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() {{ testedClass }}.{{ test.testedMethod }}({{ test.input.square }}))
        {{- else }}
        Assert.Equal({{ test.expected }}UL, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.square }}))
        {{- end }}
    End Sub
    {{ end -}}
End Class
