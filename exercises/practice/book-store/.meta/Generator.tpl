{{ func basket_literal
    if (array.size $0) == 0
        ret "Array.Empty(Of Integer)()"
    end

    ret (vb_literal $0)
end }}

{{ func expected_price
    ret $"{$0 / 100.0}D"
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.testMethod }}()
        Dim basket = {{ test.input.basket | basket_literal }}
        Assert.Equal({{ test.expected | expected_price }}, {{ testedClass }}.{{ test.testedMethod }}(basket))
    End Sub
    {{ end -}}
End Class
