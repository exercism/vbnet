{{ func integer_list_literal
    if (array.size $0) == 0
        ret "New List(Of Integer)()"
    end

    ret (vb_literal $0) + ".ToList()"
end }}

{{ func function_literal
    if $0 == "(x) -> x modulo 2 == 1"
        ret "New Func(Of Integer, Boolean)(Function(x) x Mod 2 = 1)"
    end

    if $0 == "(x) -> x + 1"
        ret "New Func(Of Integer, Integer)(Function(x) x + 1)"
    end

    if $0 == "(x, y) -> x / y"
        ret "New Func(Of Integer, Integer, Integer)(Function(x, y) x / y)"
    end

    if $0 == "(acc, el) -> el * acc"
        ret "New Func(Of Integer, Integer, Integer)(Function(acc, el) el * acc)"
    end

    ret "New Func(Of Integer, Integer, Integer)(Function(acc, el) el + acc)"
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.testMethod }}()
        {{- if test.property == "append" }}
        Dim list1 = {{ test.input.list1 | integer_list_literal }}
        Dim list2 = {{ test.input.list2 | integer_list_literal }}
        {{- if (array.size test.expected) == 0 }}
        Assert.Empty({{ testedClass }}.{{ test.testedMethod }}(list1, list2))
        {{- else }}
        Dim expected = {{ test.expected | integer_list_literal }}
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(list1, list2))
        {{- end }}
        {{- else if test.property == "concat" }}
        {{- if (array.size test.input.lists) == 0 }}
        Dim lists = New List(Of List(Of Integer))()
        {{- else if (object.typeof test.expected[0]) == "array" }}
        Dim lists = {
            {{~ for list in test.input.lists ~}}
            {{ list | vb_nested_list_literal "Integer" 0 }}{{ if !for.last }},{{ end }}
            {{~ end ~}}
        }.ToList()
        {{- else }}
        Dim lists = {{ test.input.lists | vb_nested_list_literal "Integer" 2 }}
        {{- end }}
        {{- if (array.size test.expected) == 0 }}
        Assert.Empty({{ testedClass }}.{{ test.testedMethod }}(lists))
        {{- else if (object.typeof test.expected[0]) == "array" }}
        Dim expected = {{ test.expected | vb_nested_list_literal "Integer" 2 }}
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(lists))
        {{- else }}
        Dim expected = {{ test.expected | integer_list_literal }}
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(lists))
        {{- end }}
        {{- else if test.property == "length" }}
        Dim list = {{ test.input.list | integer_list_literal }}
        Assert.Equal({{ test.expected }}, {{ testedClass }}.{{ test.testedMethod }}(list))
        {{- else if test.property == "reverse" && (array.size test.input.list) > 0 && (object.typeof test.input.list[0]) == "array" }}
        Dim list = {{ test.input.list | vb_nested_list_literal "Integer" 2 }}
        Dim expected = {{ test.expected | vb_nested_list_literal "Integer" 2 }}
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(list))
        {{- else if test.property == "reverse" }}
        Dim list = {{ test.input.list | integer_list_literal }}
        {{- if (array.size test.expected) == 0 }}
        Assert.Empty({{ testedClass }}.{{ test.testedMethod }}(list))
        {{- else }}
        Dim expected = {{ test.expected | integer_list_literal }}
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(list))
        {{- end }}
        {{- else }}
        Dim list = {{ test.input.list | integer_list_literal }}
        Dim [function] = {{ test.input.function | function_literal }}
        {{- if test.input.initial != null }}
        Assert.Equal({{ test.expected }}, {{ testedClass }}.{{ test.testedMethod }}(list, {{ test.input.initial }}, [function]))
        {{- else if (array.size test.expected) == 0 }}
        Assert.Empty({{ testedClass }}.{{ test.testedMethod }}(list, [function]))
        {{- else }}
        Dim expected = {{ test.expected | integer_list_literal }}
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(list, [function]))
        {{- end }}
        {{- end }}
    End Sub
    {{ end -}}
End Class
