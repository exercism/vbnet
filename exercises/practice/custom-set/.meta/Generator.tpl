{{ func set_literal
    if (array.size $0) == 0
        ret $"New {testedClass}()"
    end

    ret $"New {testedClass}({vb_integer_array_literal $0})"
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        {{- if test.property == "empty" }}
        Dim sut = {{ test.input.set | set_literal }}
        Assert.{{ test.expected | vb_literal }}(sut.{{ test.testedMethod }}())
        {{- else if test.property == "contains" }}
        Dim sut = {{ test.input.set | set_literal }}
        Assert.{{ test.expected | vb_literal }}(sut.{{ test.testedMethod }}({{ test.input.element }}))
        {{- else if test.property == "add" }}
        Dim sut = {{ test.input.set | set_literal }}
        Dim expected = {{ test.expected | set_literal }}
        Assert.Equal(expected, sut.{{ test.testedMethod }}({{ test.input.element }}))
        {{- else }}
        Dim set1 = {{ test.input.set1 | set_literal }}
        Dim set2 = {{ test.input.set2 | set_literal }}
        {{- if test.property == "equal" }}
        Assert.{{ test.expected ? "Equal" : "NotEqual" }}(set1, set2)
        {{- else if (object.typeof test.expected) == "array" }}
        Dim expected = {{ test.expected | set_literal }}
        Assert.Equal(expected, set1.{{ test.testedMethod }}(set2))
        {{- else }}
        Assert.{{ test.expected | vb_literal }}(set1.{{ test.testedMethod }}(set2))
        {{- end }}
        {{- end }}
    End Sub
    {{ end -}}
End Class
