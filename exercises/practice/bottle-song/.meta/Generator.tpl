Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim expected = {{ test.expected | vb_string_join "vbLf" 2 }}
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.startBottles }}, {{ test.input.takeDown }}))
    End Sub
    {{ end -}}
End Class
