{{ func factors_literal
    if (array.size $0) == 0
        ret "Array.Empty(Of Integer)()"
    end

    ret (vb_integer_array_literal $0)
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Assert.Equal({{ test.expected }}, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.factors | factors_literal }}, {{ test.input.limit }}))
    End Sub
    {{ end -}}
End Class
