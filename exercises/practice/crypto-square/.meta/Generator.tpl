Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.testMethod }}()
        Dim plaintext = {{ test.input.plaintext | vb_string_literal }}
        Dim expected = {{ test.expected | vb_string_literal }}
        Assert.Equal(expected, Crypto.{{ test.testedMethod }}(plaintext))
    End Sub
    {{ end -}}
End Class
