Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        {{- if test.expected.error }}
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() {{ testedClass }}.{{ test.testedMethod }}({{ test.input.number }}))
        {{- else }}
        Assert.Equal({{ test.expected }}, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.number }}))
        {{- end }}
    End Sub
    {{ end -}}
End Class
