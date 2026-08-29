{{ func collection_literal
    if string.contains $1 "contains"
        ret (vb_nested_list_literal $0 "Integer" $2)
    end

    if (array.size $0) == 0
        ret "Array.Empty(Of Integer)()"
    end

    ret (vb_literal $0)
end }}

{{ func predicate_literal
    if $0 == "fn(x) -> true"
        ret "Function(value) True"
    end

    if $0 == "fn(x) -> false"
        ret "Function(value) False"
    end

    if $0 == "fn(x) -> x % 2 == 1"
        ret "Function(value) value Mod 2 = 1"
    end

    if $0 == "fn(x) -> x % 2 == 0"
        ret "Function(value) value Mod 2 = 0"
    end

    if string.contains $0 "starts_with"
        ret "Function(word) word.StartsWith(\"z\")"
    end

    ret "Function(values) values.Contains(5)"
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim input = {{ collection_literal test.input.list test.input.predicate 2 }}
        {{- if (array.size test.expected) == 0 }}
        Assert.Empty(input.{{ test.testedMethod }}({{ test.input.predicate | predicate_literal }}))
        {{- else }}
        Dim expected = {{ collection_literal test.expected test.input.predicate 2 }}
        Assert.Equal(expected, input.{{ test.testedMethod }}({{ test.input.predicate | predicate_literal }}))
        {{- end }}
    End Sub
    {{ end -}}
End Class
