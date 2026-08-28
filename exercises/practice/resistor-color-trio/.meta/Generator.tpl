{{ func expected_label
    ret (vb_string_literal $"{$0.value} {$0.unit}")
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Assert.Equal({{ test.expected | expected_label }}, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.colors | vb_literal }}))
    End Sub
    {{ end -}}
End Class
