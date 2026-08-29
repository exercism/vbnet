{{ func list_literal
    if (array.size $0) == 0
        ret "New List(Of Integer)()"
    end

    ret (vb_integer_array_literal $0) + ".ToList()"
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim list1 = {{ test.input.listOne | list_literal }}
        Dim list2 = {{ test.input.listTwo | list_literal }}
        Assert.Equal({{ test.expected | enum "SublistType" }}, {{ testedClass }}.Classify(list1, list2))
    End Sub
    {{ end -}}
End Class
