{{ func text_literal
    if (array.size $0) == 0
        ret "\"\""
    end

    ret (vb_string_join $0 "vbLf" 2)
end }}
Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim lines = {{ test.input.lines | text_literal }}
        Dim expected = {{ test.expected | text_literal }}

        Assert.Equal(expected, {{ testedClass }}.Text(lines))
    End Sub
    {{ end -}}
End Class
