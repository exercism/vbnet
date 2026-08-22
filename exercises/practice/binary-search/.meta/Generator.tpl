{{ func array_literal
    if (array.size $0) == 0
        ret "System.Array.Empty(Of Integer)()"
    end

    ret (vb_literal $0)
end }}

{{ func expected_value
    if $0.error
        ret -1
    end

    ret $0
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.testMethod }}()
        Dim array = {{ test.input.array | array_literal }}
        Assert.Equal({{ test.expected | expected_value }}, {{ testedClass }}.{{ test.testedMethod }}(array, {{ test.input.value }}))
    End Sub
    {{ end -}}
End Class
