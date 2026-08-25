{{ func string_array_literal
    if (array.size $0) == 0
        ret "Array.Empty(Of String)()"
    end

    ret (vb_multiline_array_literal $0 2 1)
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.testMethod }}()
        Dim garden = {{ test.input.garden | string_array_literal }}
        Dim expected = {{ test.expected | string_array_literal }}
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(garden))
    End Sub
    {{ end -}}
End Class
