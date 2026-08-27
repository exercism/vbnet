Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim values = {{ test.input.string | vb_string_literal }}
        Dim sut = New {{ testedClass }}(values)
        Assert.Equal({{ test.expected | vb_integer_array_literal }}, sut.{{ test.testedMethod }}({{ test.input.index }}))
    End Sub
    {{ end -}}
End Class
