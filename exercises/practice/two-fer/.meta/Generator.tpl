Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        {{- if test.input.name == null }}
        Dim actual As String = {{ testedClass }}.Speak()
        {{- else }}
        Dim actual As String = {{ testedClass }}.Speak({{ test.input.name | vb_string_literal }})
        {{- end }}

        Assert.Equal({{ test.expected | vb_string_literal }}, actual)
    End Sub
    {{ end -}}
End Class
