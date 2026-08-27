Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim message = {{ test.input.msg | vb_string_literal }}
        Dim sut = New {{ testedClass }}({{ test.input.rails }})
        Dim expected = {{ test.expected | vb_string_literal }}
        Assert.Equal(expected, sut.{{ test.testedMethod }}(message))
    End Sub
    {{ end -}}
End Class
