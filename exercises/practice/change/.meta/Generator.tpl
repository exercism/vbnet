{{ func expected_literal
    if $0 == null
        ret "Array.Empty(Of Integer)()"
    end

    if (object.typeof $0) == "array"
        if (array.size $0) == 0
            ret "Array.Empty(Of Integer)()"
        end

        ret (vb_integer_array_literal $0)
    end

    ret (vb_integer_array_literal [$0])
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.testMethod }}()
        Dim coins = {{ test.input.coins | vb_integer_array_literal }}
        {{- if test.expected.error }}
        Assert.Throws(Of ArgumentException)(Function() {{ testedClass }}.{{ test.testedMethod }}(coins, {{ test.input.target }}))
        {{- else }}
        Dim expected = {{ test.expected | expected_literal }}
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(coins, {{ test.input.target }}))
        {{- end }}
    End Sub
    {{ end -}}
End Class
