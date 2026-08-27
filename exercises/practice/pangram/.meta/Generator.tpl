Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim sentence = {{ test.input.sentence | vb_string_literal }}
        Assert.{{ test.expected | vb_literal }}({{ testedClass }}.{{ test.testedMethod }}(sentence))
    End Sub
    {{ end -}}
End Class
