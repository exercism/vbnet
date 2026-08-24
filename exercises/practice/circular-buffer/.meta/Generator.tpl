{{ func operation_call
    if $0.operation == "read" || $0.operation == "clear"
        ret $"{pascalize $0.operation}()"
    end

    ret $"{pascalize $0.operation}({$0.item})"
end }}

{{ func lambda_prefix
    if $0.operation == "read"
        ret "Function()"
    end

    ret "Sub()"
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.testMethod }}()
        Dim buffer = New {{ testedClass }}(Of Integer)(capacity:={{ test.input.capacity }})
        {{- for operation in test.input.operations }}
        {{- if operation.should_succeed == false }}
        Assert.Throws(Of InvalidOperationException)({{ operation | lambda_prefix }} buffer.{{ operation | operation_call }})
        {{- else if operation.operation == "read" }}
        Assert.Equal({{ operation.expected }}, buffer.{{ operation | operation_call }})
        {{- else }}
        buffer.{{ operation | operation_call }}
        {{- end }}
        {{- end }}
    End Sub
    {{ end -}}
End Class
