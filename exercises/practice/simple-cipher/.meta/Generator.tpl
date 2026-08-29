Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.testMethod }}()
        Dim sut = New {{ testedClass }}({{ if test.input.key }}{{ test.input.key | vb_string_literal }}{{ end }})
        {{- if test.property == "key" }}
        Assert.Matches({{ test.expected.match | vb_string_literal }}, sut.Key)
        {{- else if test.scenarios && test.property == "encode" }}
        Assert.Equal(sut.Key.Substring(0, 10), sut.Encode({{ test.input.plaintext | vb_string_literal }}))
        {{- else if test.scenarios && test.input.plaintext }}
        Assert.Equal({{ test.expected | vb_string_literal }}, sut.Decode(sut.Encode({{ test.input.plaintext | vb_string_literal }})))
        {{- else if test.scenarios }}
        Assert.Equal({{ test.expected | vb_string_literal }}, sut.Decode(sut.Key.Substring(0, 10)))
        {{- else if test.input.plaintext && test.input.ciphertext }}
        Assert.Equal({{ test.expected | vb_string_literal }}, sut.Decode(sut.Encode({{ test.input.plaintext | vb_string_literal }})))
        {{- else if test.property == "encode" }}
        Assert.Equal({{ test.expected | vb_string_literal }}, sut.Encode({{ test.input.plaintext | vb_string_literal }}))
        {{- else }}
        Assert.Equal({{ test.expected | vb_string_literal }}, sut.Decode({{ test.input.ciphertext | vb_string_literal }}))
        {{- end }}
    End Sub
    {{ end -}}
End Class
