{{ func record_literal
    ret "New TreeBuildingRecord With {.RecordId = " + $0.recordId + ", .ParentId = " + $0.parentId + "}"
end }}

{{ func records_literal
    if (array.size $0) == 0
        ret "Array.Empty(Of TreeBuildingRecord)()"
    end

    literals = $0 | array.each @record_literal
    item_indent = indent ($1 + 1)
    ret "{\n" + item_indent + (array.join literals (",\n" + item_indent)) + "\n" + (indent $1) + "}"
end }}

{{ func node_id
    if $0.recordId != null
        ret $0.recordId
    end

    ret $0.id
end }}

{{ func tree_assertions
    id = node_id $1
    if $1.children == null || (array.size $1.children) == 0
        ret $"AssertTreeIsLeaf({$0}, id:={id})"
    end

    result = $"AssertTreeIsBranch({$0}, id:={id}, childCount:={array.size $1.children})"
    for child in $1.children
        child_path = $0 + $".Children({for.index})"
        result = result + "\n" + (tree_assertions child_path child)
    end
    ret result
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim records = {{ test.input.records | records_literal 2 }}
        {{- if test.expected.error || (array.size test.input.records) == 0 }}

        Assert.Throws(Of ArgumentException)(Function() TreeBuilder.BuildTree(records))
        {{- else }}
        Dim tree = TreeBuilder.BuildTree(records)

        {{ tree_assertions "tree" test.expected.node }}
        {{- end }}
    End Sub
    {{ end }}
    Private Shared Sub AssertTreeIsBranch(ByVal tree As Tree, ByVal id As Integer, ByVal childCount As Integer)
        Assert.Equal(id, tree.Id)
        Assert.False(tree.IsLeaf)
        Assert.Equal(childCount, tree.Children.Count)
    End Sub

    Private Shared Sub AssertTreeIsLeaf(ByVal tree As Tree, ByVal id As Integer)
        Assert.Equal(id, tree.Id)
        Assert.True(tree.IsLeaf)
    End Sub
End Class
