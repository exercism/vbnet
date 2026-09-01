Public Class LinkedListTests
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim sut = New Deque(Of Integer)()
        {{- for operation in test.input.operations }}
        {{- if operation.operation == "count" }}
        Assert.Equal({{ operation.expected }}, sut.Count)
        {{- else if operation.operation == "push" || operation.operation == "unshift" || operation.operation == "delete" }}
        sut.{{ operation.operation | pascalize }}({{ operation.value }})
        {{- else if operation.expected != null }}
        Assert.Equal({{ operation.expected }}, sut.{{ operation.operation | pascalize }}())
        {{- else }}
        sut.{{ operation.operation | pascalize }}()
        {{- end }}
        {{- end }}
    End Sub
    {{ end -}}
End Class
