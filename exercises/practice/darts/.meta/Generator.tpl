Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.testMethod }}()
        Assert.Equal({{ test.expected }}, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.x }}, {{ test.input.y }}))
    End Sub
    {{ end -}}
End Class
