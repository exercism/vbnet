{{ func expected_literal
    if (array.size $0) == 1
        ret (vb_string_literal $0[0])
    end

    ret (vb_string_join $0 "vbCrLf" 2)
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.testMethod }}()
        Dim expected = {{ test.expected | expected_literal }}
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.letter | vb_string_literal }}))
    End Sub
    {{ end -}}
End Class
