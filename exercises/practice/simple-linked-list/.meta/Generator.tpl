Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim list = New {{ testedClass }}(Of Integer)({{ test.input.initialValues | array.join ", " }})
        {{- for operation in test.input.operations }}
        {{- if operation.operation == "count" }}
        Assert.Equal({{ operation.expected }}, list.Count)
        {{- else if operation.operation == "push" }}
        list.Push({{ operation.value }})
        {{- else if operation.operation == "reverse" }}
        list.Reverse()
        {{- else if operation.operation == "toList" }}
        {{- if (array.size operation.expected) == 0 }}
        Assert.Empty(list.ToList())
        {{- else }}
        Assert.Equal({{ operation.expected | vb_integer_array_literal }}, list.ToList())
        {{- end }}
        {{- else if operation.expected.error }}
        Assert.Throws(Of InvalidOperationException)(Function() list.{{ operation.operation | pascalize }}())
        {{- else }}
        Assert.Equal({{ operation.expected }}, list.{{ operation.operation | pascalize }}())
        {{- end }}
        {{- end }}
    End Sub
    {{ end -}}
End Class
