Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim hands = {{ test.input.hands | vb_string_array_literal 2 2 }}
        Dim expected = {{ test.expected | vb_string_array_literal 2 2 }}
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(hands))
    End Sub
    {{ end -}}
End Class
