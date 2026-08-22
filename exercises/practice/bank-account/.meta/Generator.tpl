{{ func call
    if $0.operation == "balance"
        ret "Balance"
    end

    if $0.amount != null
        ret $"{pascalize $0.operation}({$0.amount}D)"
    end

    ret $"{pascalize $0.operation}()"
end }}

{{ func lambda_prefix
    if $0.operation == "balance"
        ret "Function()"
    end

    ret "Sub()"
end }}

Imports System.Threading.Tasks

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.testMethod }}()
        Dim account = New {{ testedClass }}()
        {{- for operation in test.input.operations }}
        {{- if for.last }}
        {{- if test.expected.error }}
        Assert.Throws(Of InvalidOperationException)({{ operation | lambda_prefix }} account.{{ operation | call }})
        {{- else }}
        Dim actual = account.{{ operation | call }}
        Dim expected = {{ test.expected }}D
        Assert.Equal(expected, actual)
        {{- end }}
        {{- else if operation.operation == "concurrent" }}
        Dim tasks As New List(Of Task)
        For i = 1 To {{ operation.number }}
            tasks.Add(Task.Run(
                Sub()
                    {{- for nested_operation in operation.operations }}
                    account.{{ nested_operation | call }}
                    {{- end }}
                End Sub))
        Next
        Task.WaitAll(tasks.ToArray())
        {{- else }}
        account.{{ operation | call }}
        {{- end }}
        {{- end }}
    End Sub
    {{ end -}}
End Class
