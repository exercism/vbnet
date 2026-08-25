{{ func expected_literal
    if (array.size $0) == 0
        ret "System.Array.Empty(Of Integer)()"
    end

    ret (vb_integer_array_literal $0)
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.testMethod }}()
        Dim array = {{ vb_object_array_literal test.input.array 2 }}
        Dim expected = {{ test.expected | expected_literal }}
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(array))
    End Sub
    {{ end -}}
End Class
