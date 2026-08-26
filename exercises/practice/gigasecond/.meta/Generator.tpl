Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim moment = Date.Parse({{ test.input.moment | vb_string_literal }})
        Dim expected = Date.Parse({{ test.expected | vb_string_literal }})
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(moment))
    End Sub
    {{ end -}}
End Class
