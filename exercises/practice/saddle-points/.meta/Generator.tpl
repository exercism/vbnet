{{ func matrix_literal
    if (array.size $0) == 0 || (array.size $0[0]) == 0
        ret "New Integer(,) {}"
    end

    ret (vb_multiline_array_literal $0 $1 1)
end }}

{{ func saddle_point_literal
    ret $"({$0.row}, {$0.column})"
end }}

{{ func saddle_points_literal
    points = $0 | array.each @saddle_point_literal
    ret "{" + (array.join points ", ") + "}"
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim matrix = {{ test.input.matrix | matrix_literal 2 }}
        Dim actual = {{ testedClass }}.Calculate(matrix)
        {{- if (array.size test.expected) == 0 }}
        Assert.Empty(actual)
        {{- else }}
        Dim expected = {{ test.expected | saddle_points_literal }}
        Assert.Equal(expected.Order(), actual.Order())
        {{- end }}
    End Sub
    {{ end -}}
End Class
