{{ func tree_literal
    if $0 == null
        ret "Nothing"
    end

    if $0.left == null && $0.right == null
        ret $"New BinTree({$0.value}, Nothing, Nothing)"
    end

    ret $"New BinTree({$0.value}, {tree_literal $0.left $1}, {tree_literal $0.right $1})"
end }}

{{ func operation_call
    result = $0
    for operation in $1
        result = result + "." + (pascalize operation.operation) + "("
        if operation.operation == "set_value"
            result = result + operation.item
        else if operation.operation == "set_left" || operation.operation == "set_right"
            result = result + (tree_literal operation.item $2)
        end
        result = result + ")"
    end
    ret result
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim tree = {{ tree_literal test.input.initialTree 2 }}
        Dim sut = Zipper.FromTree(tree)
        Dim actual = {{ operation_call "sut" test.input.operations 2 }}
        {{- if test.property == "sameResultFromOperations" }}
        Dim expectedTree = {{ tree_literal test.expected.initialTree 2 }}
        Dim expectedSut = Zipper.FromTree(expectedTree)
        Dim expected = {{ operation_call "expectedSut" test.expected.operations 2 }}

        Assert.Equal(expected, actual)
        {{- else if test.expected.value == null }}

        Assert.Null(actual)
        {{- else if test.expected.type == "tree" }}
        Dim expected = {{ tree_literal test.expected.value 2 }}

        Assert.Equal(expected, actual)
        {{- else }}

        Assert.Equal({{ test.expected.value }}, actual)
        {{- end }}
    End Sub
    {{ end -}}
End Class
